using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Donnatello
{
   
    public partial class Donnatello : Form
    {
        static int ScreenSizeY = 640;
        static int ScreenSizeX = 480;

        TextParser textParser;
        VariableTextParser variableTextParser;
        MultiLineTextParser multi;
        PaintBox Canvas;
        StatusBar Status;

        Bitmap OutPutBitmap = new Bitmap(ScreenSizeY, ScreenSizeX);

        /// <summary>Initializes a new instance of the <see cref="Donnatello" /> class.</summary>
        public Donnatello()
        {
            InitializeComponent();
            Canvas = new PaintBox(Graphics.FromImage(OutPutBitmap));
            textParser = new TextParser(Canvas, Status);
            variableTextParser = new VariableTextParser(Canvas, textParser, Status);
            multi = new MultiLineTextParser(Canvas, textParser, variableTextParser);
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
                String commands = MultiCommand.Text.Trim().ToLower();


                if (input.Equals("run") == true)
                {
                    multi.MultiParse(commands);
                    StatusBar.Text = "string";
                    
                }

                else if (input.Equals("saveprogram") == true)
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

                else if (input.Equals("loadprogram") == true)
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
                    textParser.Parse(input); 
                }

                CommandLine.Text = "";
                Refresh();
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
