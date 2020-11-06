using System;
using System.Collections;
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

        ArrayList shapes = new ArrayList();
        Bitmap OutPutBitmap = new Bitmap(ScreenSizeY, ScreenSizeX); 
        PaintBox Canvas;

        public Donnatello()
        {
            InitializeComponent();
            // canvas class handles drawing
            Canvas = new PaintBox(Graphics.FromImage(OutPutBitmap));
        }

        

        // method handles single textbox commands
        public void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            ShapeFactory factory = new ShapeFactory();

            try
            {
                shapes.Add(factory.GetShapes("circle"));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Invalid shape: " + ex);

            }


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
                    else if (inputs[0].Equals("drawcircle") == true)
                    {
                        
                    }

                    else if (inputs[0].Equals("drawline") == true)
                    {
                        Canvas.DrawLine(param1, param2);
                        StatusBar.Text = "Sucess! Line drawn to: " + "x " + 
                            param1.ToString()+ " y " + param2.ToString() + " coordinates";
                    }

                    else if (inputs[0].Equals("drawrect") == true)
                    {
                        Canvas.DrawSquare(param1, param2);
                        StatusBar.Text = "Sucess! Sqaure drawn with: " + "width " + 
                            param1.ToString() + " length " + param2.ToString() + " dimensions";
                    }
                    else if (inputs[0].Equals("run") == true)
                    {
                        string commands = MultiCommand.Text;
                        //string[] lines = MultiCommand.Lines;

                        List<string> commandList = new List<string>(
                            commands.Split(new string[] { "\r\n" },
                            StringSplitOptions.RemoveEmptyEntries));

                        // commandList.ForEach(Console.WriteLine);

                        foreach (string _command in commandList)
                        {
                            String[] _commands = _command.Split(' ', ',');

                            String p1 = _commands[0];
                            int p2 = int.Parse(_commands[1]);
                            int p3 = int.Parse(_commands[2]);

                            if (p1.Equals("drawline") == true)
                            {
                                Canvas.DrawLine(p2, p3);
                                StatusBar.Text = "Sucess! Line drawn to: " + "x " +
                                    p2.ToString() + " y " + p3.ToString() + " coordinates";

                                System.Threading.Thread.Sleep(500);
                            }
                            else if (p1.Equals("drawrect") == true)
                            {
                                Canvas.DrawSquare(p2, p3);
                                StatusBar.Text = "Sucess! Sqaure drawn with: " + "width " +
                                    p2.ToString() + " length " + p3.ToString() + " dimensions";

                                System.Threading.Thread.Sleep(500);
                            }
                        }
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
            return lines;
        }

        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            // get graphics context of form (displayed)
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutPutBitmap, 0, 0);
            
        }
    }
}
