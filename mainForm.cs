using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft;
using Microsoft.Office.Interop;
using System.Text.RegularExpressions;


namespace catalog_mover
{
    public partial class mainForm : Form
    {

        public mainForm()
        {
            InitializeComponent();
            OFD.Filter = "Excel files(*.xlsx)|*.xlsx|Excel files(*.xls)|*.xls|All files(*.*)|*.*";
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        public void SelectFileBtn_Click(object sender, EventArgs e)
        {
            try
            {
                //оно работает, поэтому лучше не трогать
                if (OFD.ShowDialog() == DialogResult.Cancel)
                    return;
                // получаем выбранный файл
                string catalogFile = OFD.FileName;

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
                //получаем массив данных
                string[] photoArray = photoValues.OfType<object>().Select(o => o.ToString()).ToArray();

                //получаем вспомогательные данные
                int columnsCount = ObjWorkSheet.UsedRange.Columns.Count;
                int rowCount = ObjWorkSheet.UsedRange.Rows.Count;
                rowCountL.Text += rowCount;
                columnCountL.Text += columnsCount;

                for (int i = 1; i < rowCount; i++)
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

                CopyFiles(photoArray, morePhotoArray, rowCount);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CopyFiles(string[] photoArray, string[] morePhotoArray, int rowCount)
        {
            MorePhotoArraySplit(morePhotoArray, rowCount);

            MorePhotoCountL.Text += morePhotoFilesLB.Items.Count;

            string catalogPath = @"j:/katalog";
            string tempPath = @"d:/photo_for_site";
            int removeFilesCount = 0;

            DirectoryInfo dirInfo = new DirectoryInfo(tempPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }
            //else MessageBox.Show("Ошибка создания каталога", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            var timer = Stopwatch.StartNew();

            CreateMorePhotoPathList(GetMorePhotoSplitCount(), GetSplitMorePhotoArray(), catalogPath, tempPath);

            //ConcatPathArrays(GetMorePhotoPathCount(), GetMorePhotoPathArray());

            RefreshFileCountLabel(0, rowCount);

            for (int i = 1; i < rowCount; i++)
            {
                string curFilePath;
                //string curFilePath = String.Concat(catalogPath, "/", modelsArray[i], "/", photoArray[i]);
                if (photoArray[i].IndexOf('_') >= 1)
                {
                    curFilePath = String.Concat(catalogPath, "/", photoArray[i].Substring(0, photoArray[i].Length - 4), "/", photoArray[i]);
                }
                else curFilePath = String.Concat(catalogPath, "/", photoArray[i]);
                // string curFilePath = String.Concat(catalogPath, "/", photoArray[i].Substring(0, photoArray[i].Length - 4), "/", photoArray[i]);
                string curCatalogPath = String.Concat(tempPath, "/", photoArray[i]);
                TempLB.Items.Add(curFilePath);

                //RemoveFileCountL.Text += removeFilesCount.ToString() + "/" + rowCount.ToString();
                System.IO.File.Copy(curFilePath, curCatalogPath, true);
                removeFilesCount++;
                RefreshFileCountLabel(i, rowCount - 1);
                if (i == rowCount - 1)
                {
                    timer.Stop();
                    string seconds = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) % 60).ToString()).ToString();
                    string minutes = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) / 60).ToString()).ToString();
                    if (System.Int32.Parse(seconds) < 10)
                    {
                        seconds = string.Concat("0", seconds);
                    }
                    if (System.Int32.Parse(minutes) < 10)
                    {
                        string minutesEnd = string.Concat("0", minutes);
                    }else if (System.Int32.Parse(minutes) >= 60)
                    {
                        int days = System.Int32.Parse(minutes) / 60;
                        int hours = System.Int32.Parse(minutes) % 60;
                        minutes = string.Concat(days, ":", hours);
                    }
                    string message = "Копирвоание окончено, количество перемещенных моделей: " + removeFilesCount.ToString() + " + \rВремя выполнения: " + minutes + ":" + seconds;
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //+ timer.ElapsedMilliseconds/1000 + " сек");
                }
            };
            TempCountL.Text += TempLB.Items.Count;
        }
        void RefreshFileCountLabel(int current, int maxCount)
        {
            RemoveFileCountL.Text = "Progress: ";
            RemoveFileCountL.Text += current.ToString() + "/" + maxCount.ToString();
        }

        public void MainTimer_Tick(object sender, EventArgs e)
        {
            //RemoveFileCountL.Text =  "Progress: " + removeFilesCount.ToString() + "/" + rowCount.ToString();
            DateTime removeTime = new DateTime();
            //DateTime oneSecond = new DateTime(0, 0, 0, 0, 0, 1);
            //removeTime.AddSeconds(1.0);
            //removeTime.Add(oneSecond);
            Console.WriteLine(removeTime);
            RemoveFileCountL.Text = removeTime.ToString("mm:ss");
        }

        public void button1_Click(object sender, EventArgs e)
        {
            MainTimer.Enabled = MainTimer.Enabled ? false : true;
        }

        /*public void CopyFiles(string[] photoArray, int arrayLength)
        {
            var timer = Stopwatch.StartNew();
            int removeFilesCount = 0;
            string sourceFileName , destFileName ;
            string photoForSitePath = @"d:/photo_for_site";
            for (int i = 0; i < arrayLength; i++)
            {
                sourceFileName = photoArray[i];
                destFileName = photoForSitePath + ;
                System.IO.File.Copy(sourceFileName, destFileName, true);
                removeFilesCount++;
                RefreshFileCountLabel(i, arrayLength - 1);
                if (i == arrayLength - 1)
                {
                    //MainTimer.Stop();
                    timer.Stop();
                    int seconds = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) % 60).ToString());
                    int minutes = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) / 60).ToString());
                    string message = "Копирвоание окончено, количество перемещенных файлов: " + removeFilesCount.ToString() + "\rВремя выполнения: " + minutes + ":" + seconds;
                    MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //+ timer.ElapsedMilliseconds/1000 + " сек");
                }
            }
        }*/


        public void MorePhotoArraySplit(string[] morePhotoArray, int rowCount)
        {
            for (int i = 1; i < rowCount; i++)
            {
                if (morePhotoArray[i] == "")
                {
                    continue;
                }
                else
                {
                    MatchCollection matches = Regex.Matches(morePhotoArray[i], ",");
                    if (matches.Count == 0) //если одна - добавить
                    {
                        morePhotoFilesLB.Items.Add(morePhotoArray[i]);
                    }
                    else //иначе разложить на необходимое количество моделей и добавить в массив все
                    {
                        morePhotoFilesLB.Items.Add(morePhotoArray[i]);
                        string s = morePhotoArray[i];
                        string[] words = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < words.Count(); j++)
                        {
                            string tempWord = words[j].Trim(new char[] { ' ' });
                            if (tempWord.Contains(".jpg")) //фильтрует неполноценные имена фоток
                            {
                                TLB.Items.Add(tempWord);
                            }
                            else continue;
                        }
                    }
                };
            };
        }

        private int GetMorePhotoSplitCount()
        {
            return TLB.Items.Count;
        }

        private int GetMorePhotoPathCount()
        {
            return MorePhotoPathListLB.Items.Count;
        }

        private string[] GetSplitMorePhotoArray()
        {
            int itemCount = TLB.Items.Count;
            string[] stopWordArray = new string[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                stopWordArray[i] = TLB.Items[i].ToString();
            }
            return stopWordArray;
        }

        private string[] GetMorePhotoPathArray()
        {
            int itemCount = MorePhotoPathListLB.Items.Count;
            string[] stopWordArray = new string[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                stopWordArray[i] = MorePhotoPathListLB.Items[i].ToString();
            }
            return stopWordArray;
        }

        private void ConcatPathArrays(int morePhotoPathCount, string[] morePhotoPathArray)
        {
            int rowCount = morePhotoPathCount;
            for (int i = 0; i < rowCount; i++)
            {
                TempLB.Items.Add(morePhotoPathArray[i]);
            }
        }

        public void CreateMorePhotoPathList(int morePhotoCount, string[] morePhotoArray, string catalogPath, string tempPath)
        {
            for (int i = 0; i < morePhotoCount - 1; i++)
            {
                string curFilePath;
                //string curFilePath = String.Concat(catalogPath, "/", modelsArray[i], "/", photoArray[i]);
                if (morePhotoArray[i].IndexOf('_') >= 1)
                {
                    curFilePath = String.Concat(catalogPath, "/", morePhotoArray[i].Substring(0, morePhotoArray[i].Length - 4), "/", morePhotoArray[i]);
                }
                else curFilePath = String.Concat(catalogPath, "/", morePhotoArray[i]);
                //string curFilePath = String.Concat(catalogPath, "/", photoArray[i].Substring(0, photoArray[i].Length - 4), "/", photoArray[i]);
                string curCatalogPath = String.Concat(tempPath, "/", morePhotoArray[i]);

                MorePhotoPathListLB.Items.Add(curFilePath);

                System.IO.File.Copy(curFilePath, curCatalogPath, true);
            }
            label7.Text += GetMorePhotoPathCount();
        }

    }
}
