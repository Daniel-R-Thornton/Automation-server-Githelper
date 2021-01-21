using System;
using System.Collections.Generic;
using System.Text;

namespace Githelper.Helpers.Automation_Server
{
    public abstract class AccAction
    {
        //Export Char 
        public char AccType;
        
        public char Terminator;

        public string Library;

        public abstract override string ToString();

        protected AccAction()
        {
            //set Line Terminator
            Terminator = ';';
        }

    }

}
