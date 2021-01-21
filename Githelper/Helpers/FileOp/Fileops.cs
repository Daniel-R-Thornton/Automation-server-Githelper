using System;
using System.IO;

namespace Githelper.Helpers.FileOp
{
    public static class Fileops
    {
        public static bool Overitelibraries(string[] Libraries)
        {
            Console.Clear();
            Console.WriteLine("Libraries Are About To Be OverWritten.");
            Console.WriteLine("Please Type in :\"I want to replace my libraries\" To Continue. ");
            if (string.Equals(Console.ReadLine(), "I want to replace my libraries", StringComparison.OrdinalIgnoreCase))
            {
                foreach (string library in Libraries)
                {
                    File.Copy(GlobalSettings.BlankLib, GlobalSettings.LibraryPath + "\\" + library + ".qil", true);
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}