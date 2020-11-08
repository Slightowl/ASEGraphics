using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donnatello
{
    class TextParser
    {
        PaintBox Canvas;

        /// <summary>Initializes a new instance of the <see cref="TextParser" /> class.</summary>
        /// <param name="paintBox">The paint box.</param>
        /// <param name="statusBar">The status bar.</param>
        public TextParser(PaintBox paintBox)
        {
            this.Canvas = paintBox;
            //this.StatusBar = statusBar;
        }

        /// <summary>Parses the specified input.</summary>
        /// <param name="input">The input.</param>
        public void Parse(string input)
        {

            string command = "default";
            int param1 = 10;
            int param2 = 10;

            input = input.Trim().ToLower();
            //String[] inputs = input.Split(' ', ',');

            List<string> inputParams = new List<string>(
                            input.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));


            // loops through list and assigns paramters to needed user parameters
            for (int j = 0; j < inputParams.Count; j++)
            {

                if (j == 0)
                {
                    command = inputParams[j];
                    Console.WriteLine(command);
                }
                else if (j == 1)
                {
                    param1 = int.Parse(inputParams[j]);
                    Console.WriteLine(param1);
                }
                else if (j == 2)
                {
                    param2 = int.Parse(inputParams[j]);
                    Console.WriteLine(param2);
                }
                else
                {
                    // needs proper error handling
                    //StatusBar.Text = "You shouldn't need anymore parameters than this for now";
                    Console.WriteLine("no");
                }
            }


            if (command.Equals("moveto") == true)
            {
                Canvas.MoveLine(param1, param2);
                /*StatusBar.Text = "Sucess! Moved pen to: " + "x " +
                    param1.ToString() + " y " + param2.ToString() + " coordinates";*/
            }

            else if (command.Equals("penred") == true)
            {
                Canvas.PenColourRed();
                //StatusBar.Text = "Pen changed to red";
            }

            else if (command.Equals("penblue") == true)
            {
                Canvas.PenColourBlue();
                //StatusBar.Text = "Pen changed to blue";
            }

            else if (command.Equals("pengreen") == true)
            {
                Canvas.PenColourGreen();
                //StatusBar.Text = "Pen changed to green";
            }

            else if (command.Equals("fillon") == true)
            {
                Canvas.SolidBrushOn();
                //StatusBar.Text = "Fill shape is activated";

            }

            else if (command.Equals("drawto") == true)
            {
                Canvas.DrawLine(param1, param2);
                /*StatusBar.Text = "Sucess! Line drawn to: " + "x " +
                    param1.ToString() + " y " + param2.ToString() + " coordinates";*/
            }

            else if (command.Equals("rect") == true)
            {
                Canvas.DrawSquare(param1, param2);
                /*StatusBar.Text = "Sucess! Sqaure drawn with: " + "width " +
                    param1.ToString() + " length " + param2.ToString() + " dimensions";*/
            }

            else if (command.Equals("circle") == true)
            {
                Canvas.DrawCircle(param1);
            }

            else if (command.Equals("clear") == true)
            {
                Canvas.Clear();
            }

            else if (command.Equals("reset") == true)
            {
                Canvas.Reset(0, 0);
            }
            else
            {

            }

            
        }
    }
}
