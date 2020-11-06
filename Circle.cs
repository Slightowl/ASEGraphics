using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    class Circle
    {
        Graphics g;
        Pen p;
        int positionX, positionY;

        public Circle(Graphics g)
        {
            this.g = g;
            positionX = positionY = 0;
            p = new Pen(Color.Black, 1);
        }

        public void createCircle(int destinationX, int destinationY)
        {
            g.DrawEllipse(p, positionX, positionY, destinationX, destinationY);
        }
    }

}
