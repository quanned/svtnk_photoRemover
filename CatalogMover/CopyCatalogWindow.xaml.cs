using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
        Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]{0,2}[0-9]{4,8}[a-zA-Zа-яА-Я]{0,2}\.(jpg|JPG|jpeg)$");
        //Regex regex = new Regex(@"^[a-zA-Zа-яА-Я]{0,2}[0-9]{4,8}.jpg$");

        public CopyCatalogWindow()
        {
            InitializeComponent();
        }

        private void CompressFilesBTN_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Console.WriteLine("Список обрабатываемых файлов и каталогов (" + DateTime.Now.ToString() + "):");
                string[] katalogFoldersList = GetFoldersFromDirectory(GetPathFROM());
                string[] katalogFilesList = GetFilesFromDirectory(GetPathFROM());
                Console.WriteLine("Количество подпапок = {0}, количество файлов в корне = {1}", katalogFoldersList.Length, katalogFilesList.Length); //, 

                //CountFilesL.Content = "Folders count: " + katalogFoldersList.Length.ToString() + " + ";
                //CountFilesL.Content += katalogFoldersList.Length.ToString();
                int errorCounter = 0;
                int copyCounter = 0;
                int resizeCounter = 0;
                var timer = Stopwatch.StartNew();

                for (int i = 0; i < katalogFoldersList.Length; i++)
                {
                    fileName = "";
                    pathToFileFrom = "";
                    pathToFileTo = "";
                    fileName = katalogFoldersList[i].Substring(GetPathFROM().Length + 1);
                    //Console.WriteLine(fileName);
                    pathToFileFrom = String.Concat(katalogFoldersList[i], @"\", fileName, ".jpg");
                    if (!File.Exists(pathToFileFrom))
                    {
                        continue;
                        errorCounter++;
                    }
                    else
                    {
                        pathToFileTo = String.Concat(GetPatTO(), @"\", fileName, ".jpg");
                        //Console.WriteLine("Path:" + pathToFileFrom);
                        FileInfo file = new FileInfo(pathToFileFrom);
                        Console.WriteLine("\nВ обработке файл: " + file.FullName.ToString());
                        long size = file.Length;
                        Console.WriteLine("Размер файла {0} = {1} байт", file.ToString(), size.ToString());
                        if (size <= 1000000)
                        {
                            if (!File.Exists(pathToFileTo))
                            {
                                File.Copy(pathToFileFrom, pathToFileTo, true);
                                Console.WriteLine("Копирование файла {0} по пути {1} без сжатия", pathToFileFrom, pathToFileTo);
                                copyCounter++;
                            }
                            else
                            {
                                Console.WriteLine("Файл {0} на шаге {1} уже существует, скип", pathToFileTo, i.ToString());
                                errorCounter++;
                                continue;
                            }

                        }
                        else
                        {
                            if (!File.Exists(pathToFileTo))
                            {
                                File.Copy(pathToFileFrom, pathToFileTo);
                                Console.WriteLine("Копирование файла {0} по пути {1} со сжатием", pathToFileFrom, pathToFileTo);
                                string command = "/C pingo.exe -jpgquality=100 -resize=1920 " + pathToFileTo.ToString();
                                Console.WriteLine("Комманда для сжатия = {0}", command);
                                System.Diagnostics.Process.Start("CMD.exe", command);
                                System.Threading.Thread.Sleep(1000);
                                resizeCounter++;
                            }
                            else
                            {
                                Console.WriteLine("Файл {0} на шаге {1} уже существует, скип", pathToFileTo, i.ToString());
                                errorCounter++;
                                continue;
                            }
                        }
                    }
                }




               /* foreach (string katalogFile in katalogFilesList)
                {
                    Console.WriteLine("File: " + katalogFile);
                }*/

                for (int i = 0; i < katalogFilesList.Length - 1; i++)
                {
                    MatchCollection matches = regex.Matches(katalogFilesList[i].Substring(GetPathFROM().Length + 1));
                    if (matches.Count > 0)
                    {
                        FileInfo file = new FileInfo(katalogFilesList[i]);
                        Console.WriteLine("\nВ обработке файл: " + file.FullName.ToString());
                        long size = file.Length;
                        Console.WriteLine("Размер файла {0} = {1} байт", file.ToString(), size.ToString());
                        if (size <= 1000000)
                        {
                            if (!File.Exists(String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1))))
                            {
                                File.Copy(katalogFilesList[i], String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1)), true);
                                copyCounter++;
                                Console.WriteLine("Копирование файла {0} по пути {1} без сжатия", katalogFilesList[i], String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1)));
                            }
                            else
                            {
                                Console.WriteLine("Файл {0} на шаге {1} уже существует, скип", katalogFilesList[i], i.ToString());
                                errorCounter++;
                                continue;
                            }
                        }
                        else
                        {
                            if (!File.Exists(String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1))))
                            {
                                File.Copy(katalogFilesList[i], String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length)));
                                Console.WriteLine("Копирование файла {0} по пути {1} со сжатием", katalogFilesList[i], String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length)));
                                string command = "/C pingo.exe -jpgquality=100 -resize=1920 " + String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1));
                                Console.WriteLine("Комманда для сжатия = {0}", command);
                                System.Diagnostics.Process.Start("CMD.exe", command);
                                System.Threading.Thread.Sleep(1000);
                                resizeCounter++;
                            }
                            else
                            {
                                Console.WriteLine("Файл {0} на шаге {1} уже существует, скип", katalogFilesList[i], i.ToString());
                                errorCounter++;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nВ обработке файл: " + katalogFilesList[i].Substring(GetPathFROM().Length + 1));
                        Console.WriteLine("Некорректное имя файла, скип");
                        errorCounter++;
                    }
                }



                timer.Stop();
                int seconds = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) % 60).ToString());
                int minutes = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) / 60).ToString());
                MessageBox.Show("Копирование завершено, время выполнения: " + minutes.ToString() + ":" + seconds.ToString() + "\nКоличество ошибок копирования: " + errorCounter.ToString() + "\nКоличество сжатий: " + resizeCounter.ToString() + "\nКоличество успешных копирований: " + copyCounter.ToString(), "End", MessageBoxButton.OK, MessageBoxImage.Information);
                Console.WriteLine("Копирование завершено, время выполнения: " + minutes.ToString() + ":" + seconds.ToString() + "\nКоличество ошибок копирования: " + errorCounter.ToString() + "\nКоличество сжатий: " + resizeCounter.ToString() + "\nКоличество успешных копирований: " + copyCounter.ToString(), "End", MessageBoxButton.OK, MessageBoxImage.Information);

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
