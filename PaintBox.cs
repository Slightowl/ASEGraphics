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


        public void PenColourRed()
        {
            Pen.Color = Color.Red;
        }

        // moves pen to designated coordinate
        public void MoveLine(int MoveToX, int MoveToY)
        {
            xPos = MoveToX;
            yPos = MoveToY;
        }

        // draws a straight line
        public void DrawLine(int MoveToX, int MoveToY)
        {
            g.DrawLine(Pen, xPos, yPos, MoveToX, MoveToY);
            xPos = MoveToX;
            yPos = MoveToY;
        }

        // draws rectangle or square
        public void DrawSquare(int width, int length)
        {
            g.DrawRectangle(Pen, xPos, yPos, width, length);
        }

        //draws circle
        public void DrawCircle(int MoveToX, int MoveToY)
        {
            g.DrawEllipse(Pen, xPos, yPos, MoveToX, MoveToY);
        }

        // clears canvas
        public void Clear()
        {
            g.Clear(Color.Black);
        }
        public void Reset(int MoveToX, int MoveToY)
        {
            // moves pen to 0,0 coordinate
            MoveToX = 0;
            MoveToY = 0;

            xPos = MoveToX;
            yPos = MoveToY;
        }
       



    }

}
