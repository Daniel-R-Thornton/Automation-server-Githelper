using Githelper.Helpers.Automation_Server;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Githelper.Helpers
{
    class AccFile
    {
        public AccFile(string fileName)
        {
            FileName = fileName;
            Actions = new List<AccAction>();
            
        }
        public string FileName { get; set; }
        public List<AccAction> Actions;

        public void WriteFile()
        {
            
            if(File.Exists(FileName))
            {
                File.Delete(FileName);
            }

            if (!Directory.Exists(Directory.GetParent(FileName).FullName))
            {
                Directory.CreateDirectory(Directory.GetParent(FileName).FullName);
            }

            File.AppendAllLines(FileName, Actions.Select(p=>p.ToString()));
        }

        public void AddRecalcs()
        {
            foreach (string path in GlobalSettings.RecalcOrder)
            {
                Actions.Add(new AccRecalc(path));
            }
        }
        public void AddImports()
        {
            foreach(string path in GlobalSettings.Libraries)
            {
                if(path.Contains('\\'))
                {
                    Actions.Add(new AccImport(GlobalSettings.GitLibraryFolder  + "\\"+GlobalSettings.SubFolderPath +"\\"+ path+path.Substring(path.LastIndexOf("\\"))+".xml", path));
                }
                else
                {
                    Actions.Add(new AccImport(GlobalSettings.GitLibraryFolder + "\\" + path+"\\"+path + ".xml", path));
                }
                
            }
        }
        public void AddExports()
        {
            foreach (string path in GlobalSettings.Libraries)
            {
                if (path.Contains('\\'))
                {
                    Actions.Add(new AccExport(GlobalSettings.GitLibraryFolder + "\\" + GlobalSettings.SubFolderPath + "\\" + path + path.Substring(path.LastIndexOf("\\")) + ".xml", path));
                }
                else
                {
                    Actions.Add(new AccExport(GlobalSettings.GitLibraryFolder + "\\" + path + "\\" + path + ".xml", path));
                }

            }
        }
    }
}
