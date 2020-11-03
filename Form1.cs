using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donnatello
{
    public partial class Donnatello : Form
    {
        static int ScreenSizeY = 640;
        static int ScreenSizeX = 480;

        Bitmap OutPutBitmap = new Bitmap(ScreenSizeY, ScreenSizeX); 
        PaintBox Canvas;

        public Donnatello()
        {
            InitializeComponent();
            // canvas class handles drawing
            Canvas = new PaintBox(Graphics.FromImage(OutPutBitmap));
        }

        // method handles single textbox commands
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String input = CommandLine.Text.Trim().ToLower();

                // put input into an array and split it into command and parameters
                String[] inputs = input.Split(' ', ',');

                try
                {
                    String command = inputs[0];
                    int param1 = int.Parse(inputs[1]);
                    int param2 = int.Parse(inputs[2]);

                    if (inputs[0].Equals("moveline") == true)
                    {
                        Canvas.MoveLine(param1, param2);
                        StatusBar.Text = "Sucess! Moved pen to: " + "x " +
                            param1.ToString() + " y " + param2.ToString() + " coordinates";
                    }

                    else if (inputs[0].Equals("drawline") == true)
                    {
                        Canvas.DrawLine(param1, param2);
                        StatusBar.Text = "Sucess! Line drawn to: " + "x " + 
                            param1.ToString()+ " y " + param2.ToString() + " coordinates";
                    }

                    else if (inputs[0].Equals("drawsquare") == true)
                    {
                        Canvas.DrawSquare(param1, param2);
                        StatusBar.Text = "Sucess! Sqaure drawn with: " + "width " + 
                            param1.ToString() + " length " + param2.ToString() + " dimensions";
                    }
                    else if (inputs[0].Equals("run") == true)
                    {
                        MultiLineInputs();
                    }

                    CommandLine.Text = "";
                    Refresh();
                }
                catch (FormatException i)
                {
                    StatusBar.Text = "Format should be 'command number number' ... " + i.Message;
                }
                catch (IndexOutOfRangeException i)
                {
                    StatusBar.Text = "Format should be 'command number number' ... " + i.Message;
                }

                
            }
        }

        public string[] MultiLineInputs()
        {
            string commands = MultiCommand.Text;
            string[] lines = MultiCommand.Lines;

            for (int i = 0; i < lines.Length; i++)
            {
                Console.WriteLine(lines[i]);
            }
            return lines[];
        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            // get graphics context of form (displayed)
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutPutBitmap, 0, 0);
        }
    }
}
