using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donnatello
{
   
    public partial class Donnatello : Form
    {
        static int ScreenSizeY = 640;
        static int ScreenSizeX = 480;

        TextParser textParser;
        // StatusBar statusBar;

        string command = "drawline";
        int param1 = 100;
        int param2 = 100;

        Bitmap OutPutBitmap = new Bitmap(ScreenSizeY, ScreenSizeX);
        PaintBox Canvas;


        /// <summary>Initializes a new instance of the <see cref="Donnatello" /> class.</summary>
        public Donnatello()
        {
            InitializeComponent();
            Canvas = new PaintBox(Graphics.FromImage(OutPutBitmap));
            textParser = new TextParser(Canvas);
            

        }

        /// method handles commandline inputs
        /// <summary>Handles the KeyDown event of the CommandLine control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="KeyEventArgs" /> instance containing the event data.</param>
        public void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                String input = CommandLine.Text.Trim().ToLower();

                try
                {
                    if (command.Equals("run") == true)
                    {
                        string commands = MultiCommand.Text;


                        List<string> commandList = new List<string>(
                            commands.Split(new string[] { "\r\n" },
                            StringSplitOptions.RemoveEmptyEntries));


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

                            }
                            else if (p1.Equals("drawrect") == true)
                            {
                                Canvas.DrawSquare(p2, p3);
                                StatusBar.Text = "Sucess! Sqaure drawn with: " + "width " +
                                    p2.ToString() + " length " + p3.ToString() + " dimensions";

                            }
                            System.Threading.Thread.Sleep(500);
                        }
                    }

                    else if (command.Equals("saveprogram") == true)
                    {
                        SaveFileDialog newProgram = new SaveFileDialog();
                        string getProgram = MultiCommand.Text;

                        List<string> commandList = new List<string>(
                            getProgram.Split(new string[] { "\r\n" },
                            StringSplitOptions.RemoveEmptyEntries));

                        if (newProgram.ShowDialog() == DialogResult.OK)
                        {
                            StreamWriter writer = new StreamWriter(newProgram.FileName);

                            for (int k = 0; k < commandList.Count; k++)
                            {
                                writer.WriteLine(commandList[k]);
                            }
                            writer.Close();
                        }
                    }

                    else if (command.Equals("loadprogram") == true)
                    {
                        var fileContent = string.Empty;
                        var filePath = string.Empty;

                        using (OpenFileDialog openFileDialog = new OpenFileDialog())
                        {
                            if (openFileDialog.ShowDialog() == DialogResult.OK)
                            {
                                filePath = openFileDialog.FileName;

                                var fileStream = openFileDialog.OpenFile();

                                using (StreamReader reader = new StreamReader(fileStream))
                                {
                                    fileContent = reader.ReadToEnd();
                                    MultiCommand.Text = fileContent;
                                }
                            }
                        }
                    }

                    else
                    {
                        textParser.Parse(CommandLine.Text);
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

        /// <summary>Handles the Paint event of the PaintBox control.</summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="PaintEventArgs" /> instance containing the event data.</param>
        private void PaintBox_Paint(object sender, PaintEventArgs e)
        {
            // get graphics context of form (displayed)
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutPutBitmap, 0, 0);
            
        }
    }
}
