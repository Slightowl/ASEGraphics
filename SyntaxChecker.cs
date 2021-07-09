using System;
using System.Collections.Generic;

namespace Donnatello
{
    class SyntaxChecker : Donnatello
    {

        string[] availableCmds = new string[] { "circle" };
        int lineCount = 0;
        Dictionary<string, int> varDictionary = new Dictionary<string, int>();

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
<<<<<<< HEAD
                            string updater = "spelling error on line: " + lineCount + " at space 1";
                            System.Windows.Forms.MessageBox.Show(updater);
=======
                            System.Diagnostics.Debug.WriteLine("spelling error on line: " + lineCount + " at space 1");
                            //StatusBar.Text("spelling error on line: " + lineCount + " at space 1");
>>>>>>> c4f5aae87c7d113f22b2d090650b84f374613ee5
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
                        System.Windows.Forms.MessageBox.Show(updater2);
                    }
                }
            }
        }
    }
}
