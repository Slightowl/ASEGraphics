using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    class PaintBox
    {
        Graphics g;
        Pen Pen;
        int xPos, yPos;


        public PaintBox(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;
            Pen = new Pen(Color.Green, 5);
        }
        public void MoveLine(int MoveToX, int MoveToY)
        {
            xPos = MoveToX;
            yPos = MoveToY;
        }
        public void DrawLine(int MoveToX, int MoveToY)
        {
            g.DrawLine(Pen, xPos, yPos, MoveToX, MoveToY);
            xPos = MoveToX;
            yPos = MoveToY;
        }
        public void DrawSquare(int width, int length)
        {
            g.DrawRectangle(Pen, xPos, yPos, length + width, length + width);
        }



    }

}
