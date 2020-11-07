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
        Brush Brush;
        bool fillShape;
     
        int xPos, yPos;


        public PaintBox(Graphics g)
        {
            this.g = g;
            xPos = yPos = 0;
            Pen = new Pen(Color.Green, 5);
            Brush = new SolidBrush(Color.Aqua);
         
        }

        public void SolidBrushOn()
        {
            fillShape = true;

        }

        // change pen colour red
        public void PenColourRed()
        {
            Pen.Color = Color.Red;
        }

        // change pen colour blue
        public void PenColourBlue()
        {
            Pen.Color = Color.Blue;
        }

        // change pen colour green (default)
        public void PenColourGreen()
        {
            Pen.Color = Color.Green;
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
            if (fillShape == true)
            {
                g.FillRectangle(Brush, xPos, yPos, width, length);
                g.DrawRectangle(Pen, xPos, yPos, width, length);
            }
            else
            {
                g.DrawRectangle(Pen, xPos, yPos, width, length);
            }
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
