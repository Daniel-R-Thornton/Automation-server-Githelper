namespace Githelper.Helpers.Automation_Server
{
    /// <summary>
    /// Automation server Export Task
    /// </summary>
    public class AccExport : AccAction
    {
        public AccExport(string ExportPath, string Library)
        {
            this.ExportPath = ExportPath;
            this.Library = Library;
            AccType = 'W';
        }
        public string ExportPath { get; set; }
        public override string ToString()
        {
            return $"1{AccType}{Library}|{ExportPath}{Terminator}";
        }
    }

}
