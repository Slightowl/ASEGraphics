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

        public Bitmap OutPutBitmap = new Bitmap(ScreenSizeY, ScreenSizeX); // change later
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
                if (input.Equals("line") ==  true)
                {
                    Canvas.DrawLine(160, 120);
                    Console.WriteLine("line sucess");
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
