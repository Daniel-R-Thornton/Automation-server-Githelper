using System;
using System.IO;

namespace Githelper
{
    public static class GlobalSettings
    {
        public static string LibraryPath;
        public static string QasPath;
        public static string GitPath;
        public static string SubFolderPath;
        public static string[] Libraries;
        public static string[] RecalcOrder;
        public static string BlankLib;
        public static string GitLibraryFolder;

        static GlobalSettings()
        {
            InitSettings();
            ResetSettings();
        }

        public static void EditSettings()
        {
            Console.Clear();
            Console.WriteLine("============================Settings=========================\r\n");
            Console.WriteLine($"1: Library Path: {LibraryPath}");
            Console.WriteLine($"2: Recalc Qas Path: {QasPath}");
            Console.WriteLine($"3: Git Path: {GitPath}");
            Console.WriteLine($"4: SubLibrary Stub: {SubFolderPath}");
            Console.WriteLine("5: <- Back");

            char Input = Console.ReadKey().KeyChar;

            switch (Input)
            {
                case '1':
                    {
                        Console.Clear();
                        Console.WriteLine("Enter new Library Path:");
                        LibraryPath = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Commit New Path as {LibraryPath} Y/N");
                        string inp = Console.ReadLine();
                        if (inp == "Y" || inp == "y")
                        {
                            WriteSettings();
                        }
                        else
                        {
                            ResetSettings();
                        }

                        EditSettings();

                        break;
                    }

                case '2':
                    {
                        Console.Clear();
                        Console.WriteLine("Enter new Qas Path:");
                        QasPath = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Commit New Path as {QasPath} Y/N");
                        string inp = Console.ReadLine();
                        if (inp == "Y" || inp == "y")
                        {
                            WriteSettings();
                        }
                        else
                        {
                            ResetSettings();
                        }

                        EditSettings();
                        break;
                    }

                case '3':
                    {
                        Console.Clear();
                        Console.WriteLine("Enter new Git Path:");
                        GitPath = Console.ReadLine();
                        GitLibraryFolder = GitPath + "\\Library";
                        Console.Clear();
                        Console.WriteLine($"Commit New Path as {GitPath} Y/N");
                        string inp = Console.ReadLine();
                        if (inp == "Y" || inp == "y")
                        {
                            WriteSettings();
                        }
                        else
                        {
                            ResetSettings();
                        }

                        EditSettings();
                        break;
                    }
                case '4':
                    {
                        Console.Clear();
                        Console.WriteLine("Enter new sub library stub:");
                        SubFolderPath = Console.ReadLine();
                        Console.Clear();
                        Console.WriteLine($"Commit New Path as {SubFolderPath} Y/N");
                        string inp = Console.ReadLine();
                        if (inp == "Y" || inp == "y")
                        {
                            WriteSettings();
                        }
                        else
                        {
                            ResetSettings();
                        }

                        EditSettings();
                        break;
                    }

                default:
                    {
                        Console.Clear();
                        break;
                    }
            }
        }
        private static string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
        private static void WriteSettings()
        {
            File.WriteAllText(baseDirectory + "\\Setup\\Settings.txt", $"{LibraryPath}\r\n{QasPath}\r\n{GitPath}\r\n{SubFolderPath}");
        }

        private static void ResetSettings()
        {
            
           

            LibraryPath = File.ReadAllLines(baseDirectory + "\\Setup\\Settings.txt")[0];
            QasPath = File.ReadAllLines(baseDirectory + "\\Setup\\Settings.txt")[1];
            GitPath = File.ReadAllLines(baseDirectory + "\\Setup\\Settings.txt")[2];
            GitLibraryFolder = File.ReadAllLines(baseDirectory + "\\Setup\\Settings.txt")[2] + "\\Library";
            SubFolderPath = File.ReadAllLines(baseDirectory + "\\Setup\\Settings.txt")[3];
            Libraries = File.ReadAllLines(baseDirectory + "\\Setup\\Libraries.txt");
            BlankLib = baseDirectory  + "\\Setup\\Blank.qil";
            RecalcOrder = File.ReadAllLines(baseDirectory + "\\Setup\\RecalcOrder.txt");
        }
        private static void InitSettings()
        {
            Console.Clear();
            if (!File.Exists(baseDirectory + "\\Setup\\Settings.txt"))
            {
                File.WriteAllText(baseDirectory + "\\Setup\\Settings.txt", " \r\n \r\n \r\n \r\n");
                          
            }

            if (!File.Exists(baseDirectory + "\\Setup\\Libraries.txt"))
            {
                Console.Beep();
                Console.Beep(2700,100);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Missing Libraries.TXT");
                File.WriteAllText(baseDirectory + "\\Setup\\Libraries.txt", " \r\n");
                Console.ReadLine();
            }

            if (!File.Exists(baseDirectory + "\\Setup\\RecalcOrder.txt"))
            {
                Console.Beep();
                Console.Beep(1500, 100);
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("Missing RecalcOrder.TXT");
                File.WriteAllText(baseDirectory + "\\Setup\\RecalcOrder.txt", " \r\n")  ;
                Console.ReadLine();
      
            }
        }
    }
}