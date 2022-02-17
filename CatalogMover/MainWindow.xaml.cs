using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Microsoft;
using Microsoft.Win32;
using Microsoft.Office.Interop;
using System.Text.RegularExpressions;
using MessageBox = System.Windows.MessageBox;

namespace CatalogMover
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {

        System.Windows.Controls.ListBox TLB = new System.Windows.Controls.ListBox();
        System.Windows.Controls.ListBox TempLBForMorePhotoFiles = new System.Windows.Controls.ListBox();
        string catalogPath = @"j:/katalog";
        string tempPath = @"d:/photo_for_site";
        int copiedFilesCount = 0;
        int copyErrors = 0;


        public MainWindow()
        {
            InitializeComponent();
            FilesListBoxCount.Visibility = Visibility.Hidden;
            ModelsListBoxCount.Visibility = Visibility.Hidden;
        }

        public string OpenFile()
        {
            // Configure open file dialog box
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "katalog_ru"; // Default file name
            dlg.DefaultExt = ".xlsx"; // Default file extension
            dlg.Filter = "Excel documents (.xlsx)|*.xlsx"; // Filter files by extension

            // Show open file dialog box
            Nullable<bool> result = dlg.ShowDialog();
            // Process open file dialog box results
            if (result == true)
            {
                // Open document
                return dlg.FileName;
            }
            else
            {
                return null;
            }
            
        }

        private void LoadFileButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string catalogFile = OpenFile();
                //MessageBox.Show(catalogFile);
                //оно работает, поэтому лучше не трогать
                //if (OFD.ShowDialog() == DialogResult.Cancel)
                    //return;
                // получаем выбранный файл
                //string catalogFile = OFD.FileName;

                //pathFileL.Text += catalogFile;
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
                //rowCountL.Text += rowCount;
                //columnCountL.Text += columnsCount;

                for (int i = 1; i < rowCount; i++)
                {
                    PhotosListBox.Items.Add(photoArray[i]);
                };
                //PhotoCountL.Text += photoFilesLB.Items.Count;


                int modelsCol = 1;
                Microsoft.Office.Interop.Excel.Range modelsColumn = ObjWorkSheet.UsedRange.Columns[modelsCol];
                System.Array modelsColumnValues = (System.Array)modelsColumn.Cells.Value2;
                string[] modelsArray = modelsColumnValues.OfType<object>().Select(o => o.ToString()).ToArray();

                for (int i = 1; i < rowCount; i++)
                {

                    ModelsListBox.Items.Add(modelsArray[i]);

                };

                //MessageBox.Show(ModelsListBox.Items.Count.ToString());

                ModelsListBoxCount.Visibility = Visibility.Visible;
                ModelsListBoxCount.Content += ModelsListBox.Items.Count.ToString();

                int morePhotoCol = 3;
                Microsoft.Office.Interop.Excel.Range morePhottoColumn = ObjWorkSheet.UsedRange.Columns[morePhotoCol];
                Array morePhotoValues = (Array)morePhottoColumn.Cells.Value2;
                string[] morePhotoArray = morePhotoValues.OfType<object>().Select(o => o.ToString()).ToArray();

                for (int i = 1; i < rowCount; i++)
                {
                    if (morePhotoArray[i] != "")
                    {
                        TempLBForMorePhotoFiles.Items.Add(morePhotoArray[i]);
                    }
                    else continue;
                };

                ObjExcel.Quit();

                SplitMorePhotoStrings(morePhotoArray);

                for (int i = 0; i < photoArray.Length; i++)
                {
                    CreatePathToFile(photoArray[i], catalogPath);
                }

                for (int i = 0; i <= MorePhotosListBox.Items.Count-1; i++)
                {
                    CreatePathToFile(MorePhotosListBox.Items[i].ToString(), catalogPath);
                }

                FilesListBoxCount.Visibility = Visibility.Visible;
                FilesListBoxCount.Content += FilesListBox.Items.Count.ToString();

                var timer = Stopwatch.StartNew();

                for (int i = 0;i <= FilesListBox.Items.Count-1; i++)
                {
                    CopyFile(FilesListBox.Items[i].ToString());
                }

                timer.Stop();
                string seconds = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) % 60).ToString()).ToString();
                string minutes = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) / 60).ToString()).ToString();
                if (System.Int32.Parse(seconds) < 10)
                {
                    seconds = string.Concat("0", seconds);
                }
                if (System.Int32.Parse(minutes) < 10)
                {
                    minutes = string.Concat("0", minutes);
                }
                else if (System.Int32.Parse(minutes) >= 60)
                {
                    int days = System.Int32.Parse(minutes) / 60;
                    int hours = System.Int32.Parse(minutes) % 60;
                    minutes = string.Concat(days, ":", hours);
                }

                string message = "Копирвоание окончено, количество перемещенных файлов: " + copiedFilesCount.ToString() + "\rКоличество копирований, завершенных с ошибкой: " + copyErrors.ToString() + "\rВремя выполнения: " + minutes + ":" + seconds;
                System.Windows.Forms.MessageBox.Show(message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information); //+ timer.ElapsedMilliseconds/1000 + " сек");

            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show(exc.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CopyFile(string fullFileName)
        {
            string fileName = System.IO.Path.GetFileName(fullFileName);
            string pathToFile = System.IO.Path.GetDirectoryName(fullFileName);

            DirectoryInfo dirInfo = new DirectoryInfo(tempPath);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            System.IO.File.Copy(fullFileName, System.IO.Path.Combine(tempPath, fileName), true);
            if (File.Exists(System.IO.Path.Combine(tempPath, fileName)))
            {
                copiedFilesCount++;
            }
            else
            {
                copyErrors++;
            }
        }

       
        void CreatePathToFile(string fileName, string catalogPath)
        {
            string curFilePath;
            if (fileName.IndexOf('_') >= 1)
            {
                curFilePath = String.Concat(catalogPath, "/", fileName.Substring(0, fileName.Length - 4), "/", fileName);
            }
            else curFilePath = String.Concat(catalogPath, "/", fileName);

            if (File.Exists(curFilePath))
            {
                FilesListBox.Items.Add(curFilePath);
            }
        }

        void SplitMorePhotoStrings(string[] morePhotoArray)
        {
            for (int i = 1; i < morePhotoArray.Length; i++)
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
                        MorePhotosListBox.Items.Add(morePhotoArray[i]);
                       /* Array.Resize(ref MorePhotoFiles, MorePhotoFiles.Length + 1);
                        MorePhotoFiles[MorePhotoFiles.Length - 1] = morePhotoArray[i];*/
                    }
                    else //иначе разложить на необходимое количество моделей и добавить в массив все
                    {
                        //FilesListBox.Items.Add(morePhotoArray[i]);
                        string s = morePhotoArray[i];
                        string[] words = s.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        for (int j = 0; j < words.Count(); j++)
                        {
                            string tempWord = words[j].Trim(new char[] { ' ' });
                            if (tempWord.Contains(".jpg")) //фильтрует неполноценные имена фоток
                            {
                                MorePhotosListBox.Items.Add(tempWord);
                            }
                            else continue;
                        }
                    }
                };
            };
        }

        //public void CreateMorePhotoPathList(int morePhotoCount, string[] morePhotoArray, string catalogPath, string tempPath)

        void RefreshFileCountLabel(int current, int maxCount)
        {
            //RemoveFileCountL.Text = "Progress: ";
            //RemoveFileCountL.Text += current.ToString() + "/" + maxCount.ToString();
        }

        public void MainTimer_Tick(object sender, EventArgs e)
        {
            //RemoveFileCountL.Text =  "Progress: " + removeFilesCount.ToString() + "/" + rowCount.ToString();
            DateTime removeTime = new DateTime();
            //DateTime oneSecond = new DateTime(0, 0, 0, 0, 0, 1);
            //removeTime.AddSeconds(1.0);
            //removeTime.Add(oneSecond);
            Console.WriteLine(removeTime);
            //RemoveFileCountL.Text = removeTime.ToString("mm:ss");
        }

        private void FilesListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start(FilesListBox.SelectedItem.ToString());
        }

        private void MorePhotosListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string fileName = MorePhotosListBox.SelectedItem.ToString();
            string path;
            if (fileName.IndexOf('_') >= 1)
            {
                path = String.Concat(catalogPath, "/", fileName.Substring(0, fileName.Length - 4));
            }
            else path = String.Concat(catalogPath, "/", fileName.Length - 4);

            System.Diagnostics.Process.Start(path);
        }

        private void PhotosListBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string fileName = PhotosListBox.SelectedItem.ToString();
            string path;
            if (fileName.IndexOf('_') >= 1)
            {
                path = String.Concat(catalogPath, "/", fileName.Substring(0, fileName.Length - 4));
            }
            else path = String.Concat(catalogPath, "/", fileName.Length - 4);

            System.Diagnostics.Process.Start(path);
        }
    }
}
