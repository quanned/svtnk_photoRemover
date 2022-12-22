using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CatalogMover
{
    /// <summary>
    /// Логика взаимодействия для CopyCatalogWindow.xaml
    /// </summary>
    public partial class CopyCatalogWindow : Window
    {
        string fileName, pathToFileFrom, pathToFileTo;

        public CopyCatalogWindow()
        {
            InitializeComponent();
        }

        private void CompressFilesBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] katalogFoldersList = GetFoldersFromDirectory(GetPathFROM());

                CountFilesL.Content = "Files count: " + katalogFoldersList.Length.ToString();

                var timer = Stopwatch.StartNew();

                for (int i = 0; i < katalogFoldersList.Length; i++)
                {
                    fileName = "";
                    pathToFileFrom = "";
                    pathToFileTo = "";
                    fileName = katalogFoldersList[i].Substring(GetPathFROM().Length + 1);
                    //Console.WriteLine(fileName);
                    pathToFileFrom = String.Concat(katalogFoldersList[i], @"\", fileName, ".jpg");
                    pathToFileTo = String.Concat(GetPatTO(), @"\", fileName, ".jpg");
                    //Console.WriteLine("Path:" + pathToFileFrom);
                    FileInfo file = new FileInfo(pathToFileFrom);
                    long size = file.Length;
                    if (size <= 1000000)
                    {
                        File.Copy(pathToFileFrom, pathToFileTo);
                    }
                    else
                    {
                        File.Copy(pathToFileFrom, pathToFileTo);
                        string command = "/C pingo.exe -jpgquality=100 -resize=1920 " + pathToFileTo.ToString();
                        System.Diagnostics.Process.Start("CMD.exe", command);
                        System.Threading.Thread.Sleep(1000);
                    }

                }

                timer.Stop();
                int seconds = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) % 60).ToString());
                int minutes = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) / 60).ToString());
                MessageBox.Show("Копирование завершено, прошло: " + minutes.ToString() + ":" + seconds.ToString(), "End", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.ToString());
            }
        }



        string[] GetFoldersFromDirectory(string path)
        {
            string[] allFolders = Directory.GetDirectories(path);
            foreach (string folder in allFolders)
            {
                Console.WriteLine(folder);
            }
            return allFolders;
        }

        string[] GetFilesFromDirectory(string path)
        {
            string[] allFiles = Directory.GetFiles(path);
            foreach (string folder in allFiles)
            {
                Console.WriteLine(folder);
            }
            return allFiles;
        }


        string GetPathFROM()
        {
            string path = FromTB.Text.ToString();
            if (Directory.Exists(path))
            {
                return path;
            }
            else
                return null;
        }

        string GetPatTO()
        {
            string path = ToTB.Text.ToString();
            if (Directory.Exists(path))
            {
                return path;
            }
            else
            {
                Directory.CreateDirectory(path);
                return path;
            }
        }
    }
}
