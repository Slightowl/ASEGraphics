using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello 
{
    class NotAStringException : Exception
    {
        public void StringException()
        {
            System.InvalidOperationException argX = new System.InvalidOperationException("Command inputted was not a string");
            System.Windows.Forms.MessageBox.Show("Exception: " + argX);
        }
    }
}
