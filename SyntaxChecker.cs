using System;
using System.Collections.Generic;

namespace Donnatello
{
    class SyntaxChecker
    {

        string[] availableCmds = new string[] { "circle" };
        int lineCount = 0;
        List<string> synList = new List<string>();

        public SyntaxChecker(PaintBox paintBox, TextParser textParser, MultiLineTextParser multi)
        {

        }

        /// <summary>parses commands.</summary>
        /// <param name="commands">
        ///   <para>
        /// string list of commands</para>
        /// </param>
        public void SyntaxParse(string commands)
        {

            List<string> commandList = new List<string>(
                            commands.Split(new string[] { "\r\n" },
                            StringSplitOptions.RemoveEmptyEntries));

            foreach (string line in commandList)
            {
                lineCount++;
                SynChecker(line);
            }
        }

        /// <summary>
        ///   <para>
        /// Does some logic to locate errors</para>
        /// </summary>
        /// <param name="input">The input.</param>
        public void SynChecker(string input)
        {
            input = input.Trim().ToLower();

            List<string> inputParams = new List<string>(
                            input.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));

            for (int i = 0; i < inputParams.Count; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 0; j < availableCmds.Length; j++)
                    {
                        if (inputParams[i] == availableCmds[j])
                        {
                            // do nothing
                        }
                        else
                        {
                            string updater = "spelling error on line: " + lineCount + " at space 1";
                            synList.Add(updater);
                            //System.Windows.Forms.MessageBox.Show(updater);
                        }
                    }
                }
                else
                {
                    int testNum = 0;
                    string numCommand = inputParams[i];
                    bool isNum = int.TryParse(numCommand, out testNum);

                    if (isNum == true)
                    {
                        // do nothing
                    }
                    else
                    {
                        string updater2 = "Error with integer on line " + lineCount + " at space 2";
                        synList.Add(updater2);
                        //System.Windows.Forms.MessageBox.Show(updater2);
                    }
                }
            }
            messageProvider(synList);
        }

        public void messageProvider(List<string> vs)
        {      
            string delimiter = "\n\r";
            string concList = String.Join(delimiter, vs);
            System.Windows.Forms.MessageBox.Show(concList);  
        }
    }
}
