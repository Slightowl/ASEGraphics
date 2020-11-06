using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    class Circle : Shapes
    {
        int radius;

        public Circle():base()
        {
            // explicitly calls base class method (see Shapes class)
        }

        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }

        // setting colours, x, y & radius
        public override void set(Color colour, params int[] list)
        {
            // format: x, y, radius
            base.set(colour, list[0], list[1]);
            this.radius = list[2];
        }

        // set pen and draw circle
        public override void draw(Graphics g)
        {
            Pen pen = new Pen(Color.Green, 3);
            SolidBrush brush = new SolidBrush(colour);
            g.FillEllipse(brush, x, y, radius * 2, radius * 2);
            g.DrawEllipse(pen, x, y, radius * 2, radius * 2);
        }


        // calculating circle area
        public override double calcArea()
        {
            return Math.PI * (radius ^ 2);
        }


        public override double calcPerimeter()
        {
            return 2 * Math.PI * radius;
        }

        public override string ToString()
        {
            return base.ToString() + "   " + this.radius;
        }

    }
}
