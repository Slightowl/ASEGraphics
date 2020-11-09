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
        bool testing;

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


        public PaintBox()
        {
            testing = true;
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

            // testing purposes
            if (testing == false)
            {
                g.DrawLine(Pen, xPos, yPos, MoveToX, MoveToY);
            }

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

        /// <summary>Draws the triangle.</summary>
        /// <param name="point1">1st x pos.</param>
        /// <param name="point2">1st y pos.</param>
        /// <param name="point3">2nd x pos.</param>
        /// <param name="point4">2nd y pos.</param>
        /// <param name="point5">3rd x pos.</param>
        /// <param name="point6">3rd y pos.</param>
        public void DrawTriangle(int point1, int point2, int point3
            , int point4, int point5, int point6)
        {
            Point pointOne = new Point(point1, point2);
            Point pointTwo = new Point(point3, point4);
            Point pointThree = new Point(point5, point6);
            Point[] curvePoints =
            {
                pointOne,
                pointTwo,
                pointThree
            };

            if (fillShape == true)
            {
                g.FillPolygon(Brush, curvePoints);
                g.DrawPolygon(Pen, curvePoints);
            }
            else
            {
                g.DrawPolygon(Pen, curvePoints);
            }

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
