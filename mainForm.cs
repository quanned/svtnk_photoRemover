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
using Microsoft.Office.Interop;


namespace catalog_mover
{
    public partial class mainForm : Form
    {
        public const char comma = ',';
        public mainForm()
        {
            InitializeComponent();
            opf.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls|All files(*.*)|*.*";
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void SelectFileBtn_Click(object sender, EventArgs e)
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
            int photoCol = 2;                      
            Microsoft.Office.Interop.Excel.Range photoColumn = ObjWorkSheet.UsedRange.Columns[photoCol];
            System.Array photoValues = (System.Array)photoColumn.Cells.Value2;
            string[] photoArray = photoValues.OfType<object>().Select(o => o.ToString()).ToArray();

            int columnsCount = ObjWorkSheet.UsedRange.Columns.Count;
            int rowCount = ObjWorkSheet.UsedRange.Rows.Count;
            rowCountL.Text += rowCount;
            columnCountL.Text += columnsCount;

            for(int i = 1; i < rowCount; i++)
            {
                
                    photoFilesLB.Items.Add(photoArray[i]);
               
            };
            PhotoCountL.Text += photoFilesLB.Items.Count;


            int modelsCol = 1;
            Microsoft.Office.Interop.Excel.Range modelsColumn = ObjWorkSheet.UsedRange.Columns[modelsCol];
            System.Array modelsColumnValues = (System.Array)modelsColumn.Cells.Value2;
            string[] modelsArray = modelsColumnValues.OfType<object>().Select(o => o.ToString()).ToArray();

            for (int i = 1; i < rowCount; i++)
            {

                ModelsLB.Items.Add(modelsArray[i]);

            };
            ModelsCountL.Text += ModelsLB.Items.Count;


            int morePhotoCol = 3;
            Microsoft.Office.Interop.Excel.Range morePhottoColumn = ObjWorkSheet.UsedRange.Columns[morePhotoCol];
            Array morePhotoValues = (Array)morePhottoColumn.Cells.Value2;
            string[] morePhotoArray = morePhotoValues.OfType<object>().Select(o => o.ToString()).ToArray();

            ObjExcel.Quit();

            for (int i = 1; i < rowCount; i++)
            {
                if (morePhotoArray[i] == "")
                {
                    continue;
                }
                else
                {
                    //if (morephotoarray[i].indexof(comma) >= 1)
                    //{
                    //    string[] morephotosstrarr = morephotoarray[i].split(comma);
                    //    for(int t = 0; t <= morephotosstrarr.length; t++)
                    //    {
                    //        templb.items.add(morephotosstrarr[i]);
                    //    }
                    //}
                    morePhotoFilesLB.Items.Add(morePhotoArray[i]);
                };
            };
            MorePhotoCountL.Text += morePhotoFilesLB.Items.Count;

            string catalogPath = @"j:/katalog";
            string tempPath = @"d:/photo_for_site";

            DirectoryInfo dirInfo = new DirectoryInfo(tempPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            };


            for (int i = 1; i < rowCount; i++)
            {

                //string curFilePath = String.Concat(catalogPath, "/", modelsArray[i], "/", photoArray[i]);
                string curFilePath = String.Concat(catalogPath, "/", photoArray[i].Substring(0, photoArray[i].Length - 4), "/", photoArray[i]);
                string curCatalogPath = String.Concat(tempPath, "/", photoArray[i]);
                TempLB.Items.Add(curFilePath);
                if (Directory.EnumerateFiles(curCatalogPath, curFilePath, SearchOption.TopDirectoryOnly).Count() == 0)
                {
                    continue;
                }
                System.IO.File.Copy( curCatalogPath, curFilePath, true);


                if (i == rowCount)
                {
                    MessageBox.Show("Копирвоание окончено, количество перемещенных файлов: " + i.ToString());
                }
            };

            TempCountL.Text += TempLB.Items.Count;





        }

        private void MoveBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
