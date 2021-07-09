using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    class ShapeTooBigException : Exception
    {

        public void MaxShapeException()
        {
            System.InvalidOperationException argX = new System.InvalidOperationException("Integer input was too large for this shape");
            System.Windows.Forms.MessageBox.Show("Exception: " + argX);
        }
    }
}
