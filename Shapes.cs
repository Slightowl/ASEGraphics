using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    abstract class Shapes:ShapeInterface
    {
        protected Color colour; // shape colour
        protected int x, y;

        public Shapes()
        {
            colour = Color.Green;
            x = y = 50;
        }

        public Shapes(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }

        public abstract void draw(Graphics g);
        public abstract double calcArea();
        public abstract double calcPerimeter();

        // declared virutal to be overridden by more specialised child
        // used for generic operations
        // variable param list used for ability to pass multiple integers in if needed
        public virtual void set(Color colour, params int[] list)
        {
            this.colour = colour;
            this.x = list[0];
            this.y = list[1];
        }

        public override string ToString()
        {
            return base.ToString()+ "  " + this.x + "," + this.y + " : ";
        }
    }
}
