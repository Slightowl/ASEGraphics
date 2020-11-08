using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donnatello
{

    class PaintBox
    {
        Graphics g;
        Pen Pen;
        Brush Brush;
        bool fillShape;
     
        int xPos, yPos;


        /// <summary>Initializes a new instance of the <see cref="PaintBox" /> class.</summary>
        /// <param name="g">The g.</param>
        public PaintBox(Graphics g)
        {
            this.g = g;
            xPos = yPos = 25;
            Pen = new Pen(Color.Green, 5);
            Brush = new SolidBrush(Color.Aqua);
            Pen.EndCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            Pen.StartCap = System.Drawing.Drawing2D.LineCap.RoundAnchor;
            
        }

        /// <summary>Turns the brush on.</summary>
        public void SolidBrushOn()
        {
            fillShape = true;
        }

        /// <summary>Turns the brush off.</summary>
        public void SolidBrushOff()
        {
            fillShape = false;
        }

        /// <summary>Pens the colour red.</summary>
        public void PenColourRed()
        {
            Pen.Color = Color.Red;
        }

        
        /// <summary>Pens the colour blue.</summary>
        public void PenColourBlue()
        {
            Pen.Color = Color.Blue;
        }

        /// <summary>Pens the colour green.</summary>
        public void PenColourGreen()
        {
            Pen.Color = Color.Green;
        }

        /// <summary>Moves the line.</summary>
        /// <param name="MoveToX">The move to x.</param>
        /// <param name="MoveToY">The move to y.</param>
        public void MoveLine(int MoveToX, int MoveToY)
        {
            xPos = MoveToX;
            yPos = MoveToY;
        }

        /// <summary>Draws the line.</summary>
        /// <param name="MoveToX">The move to x.</param>
        /// <param name="MoveToY">The move to y.</param>
        public void DrawLine(int MoveToX, int MoveToY)
        {
            g.DrawLine(Pen, xPos, yPos, MoveToX, MoveToY);
            xPos = MoveToX;
            yPos = MoveToY;
        }

        /// <summary>Draws the square.</summary>
        /// <param name="width">The width.</param>
        /// <param name="length">The length.</param>
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

        
        /// <summary>Draws the circle.</summary>
        /// <param name="radius">The radius.</param>
        public void DrawCircle(int radius)
        {
            
            if (fillShape == true)
            {
                g.FillEllipse(Brush, xPos, yPos, radius*2, radius*2);
                g.DrawEllipse(Pen, xPos, yPos, radius*2, radius*2);
            }
            else
            {
                g.DrawEllipse(Pen, xPos, yPos, radius * 2, radius * 2);
            }
        }

        public void DrawTriangle()
        {
            //Todo
        }


        /// <summary>Clears this instance.</summary>
        public void Clear()
        {
            g.Clear(Color.Black);
        }

        /// <summary>Resets the specified move to x, y.</summary>
        /// <param name="MoveToX">The move to x.</param>
        /// <param name="MoveToY">The move to y.</param>
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
