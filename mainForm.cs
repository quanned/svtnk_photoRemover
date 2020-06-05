using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft;
using Microsoft.Office.Interop.Excel;

namespace catalog_mover
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            opf.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls|All files(*.*)|*.*";
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
            //test line
            //comment line 1
        }

        public void selectFileBtn_Click(object sender, EventArgs e)
        {

            if (opf.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string catalogFile = opf.FileName;

            pathFileL.Text += catalogFile;
            string pathToFile = catalogFile;
            Microsoft.Office.Interop.Excel.Application ObjExcel = new Microsoft.Office.Interop.Excel.Application();
            //Открываем книгу.                                                                                                                                                        
            Microsoft.Office.Interop.Excel.Workbook ObjWorkBook = ObjExcel.Workbooks.Open(pathToFile, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Выбираем таблицу(лист).
            Microsoft.Office.Interop.Excel.Worksheet ObjWorkSheet;
            ObjWorkSheet = (Microsoft.Office.Interop.Excel.Worksheet)ObjWorkBook.Sheets[1];

            // Указываем номер столбца (таблицы Excel) из которого будут считываться данные.
            int numCol = 2;

            Range usedColumn = ObjWorkSheet.UsedRange.Columns[numCol];
            System.Array myvalues = (System.Array)usedColumn.Cells.Value2;
            string[] strArray = myvalues.OfType<object>().Select(o => o.ToString()).ToArray();

            //Workbook xlWorkbook = Workbooks.Open(Path.GetFullPath(pathToFile));
           // Worksheet xlWorksheet = (Worksheet)ObjWorkSheet.Sheet[1].get_Item(1);
            


            //Console.WriteLine("Count column: " + xlWorksheet.UsedRange.Columns.Count);

            int columnsCount = ObjWorkSheet.UsedRange.Columns.Count;
            int rowCount = ObjWorkSheet.UsedRange.Rows.Count;

            rowCountL.Text += rowCount;
            columnCountL.Text += columnsCount;


            // Выходим из программы Excel.
            ObjExcel.Quit();

            for(int i = 1; i < rowCount; i++)
            {
                
                    selectedFilesLB.Items.Add(strArray[i]);
               
            };


        }


    }
}
