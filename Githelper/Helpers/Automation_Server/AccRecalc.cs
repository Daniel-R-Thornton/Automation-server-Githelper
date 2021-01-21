using System;
using System.Collections.Generic;
using System.Text;

namespace Githelper.Helpers.Automation_Server
{
    /// <summary>
    /// Automation server recalc Task
    /// </summary>
    public class AccRecalc : AccAction
    {
        /// <summary>
        /// Instantiate New Recalc
        /// </summary>
        /// <param name="Library">Library to re-calc</param>
        public AccRecalc(string Library)
        {
            this.Library = Library;
            AccType = 'L';
        }

        public override string ToString()
        {
            return $"1{AccType}{Library}{Terminator}";
        }

    }

}
