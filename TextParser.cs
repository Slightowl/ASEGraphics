using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donnatello
{
    public class TextParser
    {
        PaintBox Canvas;

        /// <summary>Initializes a new instance of the <see cref="TextParser" /> class.</summary>
        /// <param name="paintBox">The paint box.</param>
        /// <param name="statusBar">The status bar.</param>
        public TextParser(PaintBox paintBox, StatusBar statusBar)
        {
            this.Canvas = paintBox;
        }

        /// <summary>Parses the specified input.</summary>
        /// <param name="input">The input.</param>
        public void Parse(string input)
        {

            string command = "default";
            string assign = "=";
            int param1 = 0;
            int param2 = 0;
            int param3 = 0;
            int param4 = 0;
            int param5 = 0;
            int param6 = 0;
            
            //string status = StatusBar.Text;

            input = input.Trim().ToLower();

            List<string> inputParams = new List<string>(
                            input.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));


            // loops through list and assigns paramters to needed user parameters
            for (int j = 0; j < inputParams.Count; j++)
            {
                if (j == 0)
                {
                        command = inputParams[j];
                }
                else if (j == 1)
                {
                    try
                    {
                        if(inputParams[j] == "=")
                        {
                            
                            assign = param1.ToString();
                        }
                        else
                        {
                            param1 = int.Parse(inputParams[j]);

                        }

                    }
                    catch (FormatException e)
                    {
                        //StatusBar.Text = "Invalid parameter (must be an integer): " + e.Message;

                        Console.WriteLine("Parameter 1 Inavlid (must be an integer): " + e.Message);
                    }
                }
                else if (j == 2)
                {
                    try
                    {
                        param2 = int.Parse(inputParams[j]);
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Parameter 2 Inavlid  (must be an integer): " + e.Message);
                    }
                }
                else if (j == 3)
                {
                    param3 = int.Parse(inputParams[j]);
                }
                else if ( j == 4)
                {
                    param4 = int.Parse(inputParams[j]);
                }
                else if (j == 5)
                {
                    param5 = int.Parse(inputParams[j]);
                }
                else if (j == 6)
                {
                    param6 = int.Parse(inputParams[j]);
                }
                else
                {
                    //StatusBar.Text = "Error: Either Invalid Command or Parameter";
                }
                Console.WriteLine(command + " " + assign + " " + param1);
            }
            try
            {
                if (command.Equals("moveto") == true)
                {
                    Canvas.MoveLine(param1, param2);
                    /*statusUpdate = "Sucess! Moved pen to: " + "x " +
                        param1.ToString() + " y " + param2.ToString() + " coordinates";*/
                }

                else if (command.Equals(command + " " + assign + " " + param2))
                {
                    Console.WriteLine(command + " " + assign + param2);
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
                else if (command.Equals("filloff") == true)
                {
                    Canvas.SolidBrushOff();
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
                else if (command.Equals("triangle") == true)
                {
                    Canvas.DrawTriangle(param1, param2, param3, param4, param5, param6);
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
                    Console.WriteLine("Invalid command: Needs to be a valid command");
                }

            }
            catch (ArgumentException e)
            {
                Console.WriteLine("Command was invalid, please enter a valid command. Error: " + e.Message);
            }
            
        }
    }
}
