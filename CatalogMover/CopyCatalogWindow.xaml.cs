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
                string[] katalogFoldersList = GetFoldersFromDirectory(GetPathFROM());

                CountFilesL.Content = "Files count: " + katalogFoldersList.Length.ToString();
                int counter = 0;
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
                    }
                    else
                    {
                        pathToFileTo = String.Concat(GetPatTO(), @"\", fileName, ".jpg");
                        //Console.WriteLine("Path:" + pathToFileFrom);
                        FileInfo file = new FileInfo(pathToFileFrom);
                        long size = file.Length;
                        Console.WriteLine("Size of {0} file = {1} bytes", file.ToString(), size.ToString());
                        if (size <= 1000000)
                        {
                            if (!File.Exists(pathToFileTo))
                            {
                                File.Copy(pathToFileFrom, pathToFileTo, true);
                            }
                            else
                            {
                                counter++;
                                continue;
                            }
                            
                        }
                        else
                        {
                            if(!File.Exists(pathToFileTo))
                            {
                                File.Copy(pathToFileFrom, pathToFileTo);
                                string command = "/C pingo.exe -jpgquality=100 -resize=1920 " + pathToFileTo.ToString();
                                Console.WriteLine("Command = {0}", command);
                                System.Diagnostics.Process.Start("CMD.exe", command);
                                System.Threading.Thread.Sleep(1000);
                            }
                            else
                            {
                                counter++;
                                continue;
                            }
                        }
                    }
                }


                string[] katalogFilesList = GetFilesFromDirectory(GetPathFROM());

                /*foreach(string katalogFile in katalogFilesList)
                {
                    Console.WriteLine("File: " + katalogFile);
                }*/

                for (int i = 0; i < katalogFilesList.Length; i++)
                {
                    MatchCollection matches = regex.Matches(katalogFilesList[i].Substring(GetPathFROM().Length+1));
                    if (matches.Count > 0)
                    {
                        FileInfo file = new FileInfo(katalogFilesList[i]);
                        long size = file.Length;
                        Console.WriteLine("Size of {0} file = {1} bytes", file.ToString(), size.ToString());
                        if (size <= 1000000)
                        {
                            if (!File.Exists(String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1), true)))
                            {
                                File.Copy(katalogFilesList[i], String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1)));
                            }
                            else
                            {
                                counter++;
                                continue;
                            }

                        }
                        else
                        {
                            if (!File.Exists(String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1), true)))
                            {
                                File.Copy(katalogFilesList[i], String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1)));
                                string command = "/C pingo.exe -jpgquality=100 -resize=1920 " + String.Concat(GetPatTO(), @"\", katalogFilesList[i].Substring(GetPathFROM().Length + 1));
                                 Console.WriteLine("Command = {0}", command);
                                System.Diagnostics.Process.Start("CMD.exe", command);
                                System.Threading.Thread.Sleep(1000);
                            }
                            else
                            {
                                counter++;
                                continue;
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("\nFile: " + katalogFilesList[i].Substring(GetPathFROM().Length + 1));
                        Console.WriteLine("Совпадений не найдено");
                        counter++;
                    }
                }

                


                timer.Stop();
                int seconds = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) % 60).ToString());
                int minutes = System.Int32.Parse(((timer.ElapsedMilliseconds / 1000) / 60).ToString());
                MessageBox.Show("Копирование завершено, прошло: " + minutes.ToString() + ":" + seconds.ToString() + "\nКоличество ошибок копирования: " + counter.ToString(), "End", MessageBoxButton.OK, MessageBoxImage.Information);
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
