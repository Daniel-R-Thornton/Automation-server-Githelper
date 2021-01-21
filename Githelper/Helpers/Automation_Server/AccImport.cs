namespace Githelper.Helpers.Automation_Server
{
    /// <summary>
    /// Automation server import task
    /// </summary>
    public class AccImport : AccAction
    {
        /// <summary>
        /// Instantiate Import
        /// </summary>
        /// <param name="ImportPath">Path to import from </param>
        /// <param name="Library">Library to import into</param>
        public AccImport(string ImportPath, string Library)
        {

            this.ImportPath = ImportPath;
            this.Library = Library;
            AccType = 'Q';
        }

        public string ImportPath { get; set; }
        public override string ToString()
        {
            return $"1{AccType}{Library}|{ImportPath}{Terminator}";
        }
    }

}
