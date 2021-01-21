using System;
using System.Collections.Generic;
using System.Text;

namespace Githelper.Helpers.Automation_Server
{
    class AccRun : AccAction
    {
        public string RunPath;
        public AccRun(string RunPath)
        {
            AccType = 'Z';
            this.RunPath = RunPath;
        }

        public override string ToString()
        {
            return $"1{AccType}{RunPath}{Terminator}";
        }
    }
}
