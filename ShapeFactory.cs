using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    class ShapeFactory
    {
        public Shapes GetShapes(string shapeType)
        {
            shapeType = shapeType.ToUpper().Trim();

            if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }
            else if (shapeType.Equals("CIRCLE"))
            {
                return new Circle();
            }
            else
            {
                System.ArgumentException e = new System.ArgumentException(
                    "Error: " + shapeType + " does not exist");

                throw e;
            }
        }
    }
}
