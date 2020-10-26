using System;
using System.Collections.Generic;
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



        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String input = CommandLine.Text.Trim().ToLower();

                // put input into an array and split it into command and parameters
                String[] inputs = input.Split(' ');

                String command = inputs[0];
                int param1 = int.Parse(inputs[1]);
                int param2 = int.Parse(inputs[2]);

                // moveline, parameter, parameter
                if (inputs[0].Equals("moveline") == true)
                {
                    Canvas.MoveLine(param1, param2);
                    Console.WriteLine("move sucess");
                }

                // drawline, parameter, parameter
                if (inputs[0].Equals("drawline") ==  true)
                {
                    Canvas.DrawLine(param1, param2);
                    Console.WriteLine("line sucess");
                }

                // drawsquare, parameter, parameter
                if (inputs[0].Equals("drawsquare") == true)
                {
                    Canvas.DrawSquare(param1, param2);
                    Console.WriteLine("square sucess");
                }
                CommandLine.Text = "";
                Refresh();
            }
        }
        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            // get graphics context of form (displayed)
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutPutBitmap, 0, 0);
        }
    }
}
