using Githelper.Helpers;
using Githelper.Helpers.FileOp;
using Githelper.Helpers.Git;
using System;
using System.IO;

namespace Githelper
{
    internal enum ExitCode : int
    {
        Success = 0,
        UnknownError = 10
    }

    internal static class Program
    {
        private static int Main(string[] args)
        {
            //instantiate AccFile with default path of C:\\

            AccFile accFile = new AccFile(AppDomain.CurrentDomain.BaseDirectory + "\\Setup\\Temp.qas");
            //Write out blank file first just in case julian closes the program.
            accFile.WriteFile();

            bool terminate = false;
            while (!terminate)
            {
                Console.WriteLine("Select the Type of action to perform\r\n");
                Console.WriteLine("=======================Git Operations=======================\r\n");
                Console.WriteLine("1:Pull Branch, Full Import & Full Re-calc");
                Console.WriteLine("2:Pull Branch, Full Import");
                Console.WriteLine("3:Pull Branch, Import & Full Re-calc");
                Console.WriteLine("4:Pull Branch, Import");

                Console.WriteLine("=====================CabMaster Operations===================\r\n");
                Console.WriteLine("5:Import and re-calc");
                Console.WriteLine("6:Import All");
                Console.WriteLine("7:Export All");
                Console.WriteLine("8:Recalc");

                Console.WriteLine("============================SPECIAL==========================\r\n");
                Console.WriteLine("b:Build");

                Console.WriteLine("============================Settings=========================\r\n");
                Console.WriteLine("S: Settings");
                Console.WriteLine("X: Exit");

                switch (Console.ReadKey().KeyChar)
                {
                    //Pull Branch, smart Import & Full Re - calc
                    case '1':
                        {
                            if (Fileops.Overitelibraries(GlobalSettings.Libraries))
                            {
                                GitActions.ChangeBranch();
                                accFile.AddImports();
                                accFile.AddRecalcs();
                                terminate = true;
                            }
                            break;
                        }
                    //Pull Branch, full Import
                    case '2':
                        {
                            if (Fileops.Overitelibraries(GlobalSettings.Libraries))
                            {
                                GitActions.ChangeBranch();
                                accFile.AddImports();
                            }
                            terminate = true;
                            break;
                        }
                    //Pull Branch, Import & Full Re-calc
                    case '3':
                        {
                            if (Confirm("Pull Branch, Import & Full Re-calc"))
                            {
                                GitActions.ChangeBranch();
                                accFile.AddImports();
                                accFile.AddRecalcs();
                                terminate = true;
                            }
                            break;
                        }
                    //Pull Branch, Import
                    case '4':
                        {
                            if (Confirm("Pull Branch, Import"))
                            {
                                GitActions.ChangeBranch();
                                accFile.AddImports();
                                terminate = true;
                            }
                            break;
                        }
                    //Import and re-calc
                    case '5':
                        {
                            if (Confirm("Import and re-calc"))
                            {
                                accFile.AddImports();
                                accFile.AddRecalcs();
                                terminate = true;
                            }
                            break;
                        }
                    //Import All
                    case '6':
                        {
                            if (Confirm("Import All"))
                            {
                                accFile.AddImports();
                                terminate = true;
                            }
                            break;
                        }
                    //Export All
                    case '7':
                        {
                            if (Confirm("Export All"))
                            {
                                accFile.AddExports();
                                terminate = true;
                            }
                            break;
                        }

                    case '8':
                        {
                            if (Confirm("Recalc"))
                            {
                                accFile.AddRecalcs();
                                terminate = true;
                            }
                            break;
                        }

                    case 'b':
                    case 'B':
                        {
                            if (Confirm("Build"))
                            {
                                Fileops.Overitelibraries(GlobalSettings.Libraries);
                                accFile.AddImports();
                                accFile.AddRecalcs();
                                terminate = true;
                            }
                            break;
                        }
                    //settings
                    case 's':
                    case 'S':
                        {
                            //enter settings menu defer logic until there
                          GlobalSettings.EditSettings();
                         
                          
                                
                            
                            break;
                        }
                    case 'x':
                    case 'X':
                        {
                            //enter settings menu defer logic until there
                            terminate = true;
                            break;
                        }
                    default:
                        {
                            Console.Clear();
                            break;
                        }
                }
                if (terminate)
                {
                    accFile.WriteFile();
                }
            }

            return (int)ExitCode.Success;
        }

        

        static private bool Confirm(string action)
        {
            Console.Clear();
            Console.WriteLine($"Are you sure you want to {action} [y/n]");
            var input = Console.ReadKey();

            return input.KeyChar == 'y';
        }

        
    }
}