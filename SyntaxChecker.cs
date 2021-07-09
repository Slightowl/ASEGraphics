using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    class SyntaxChecker : Donnatello
    {

        PaintBox Canvas;
        //StatusBar Status;
        VariableTextParser variableTextParser;
        TextParser TextParser;
        MultiLineTextParser MultiLineTextParser;
        MethodParser MethodParser;
        Looper Looper;
        ifElseParser ifElseParser;

        string[] availableCmds = new string[] {"circle"};
        int lineCount = 0;
        int commandCount = 0;
        Dictionary<string, int> varDictionary = new Dictionary<string, int>();

        public SyntaxChecker(PaintBox paintBox, TextParser textParser, MultiLineTextParser multi)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
            this.MultiLineTextParser = multi;
        }

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

        public void SynChecker(string input)
        {
            input = input.Trim().ToLower();

            List<string> inputParams = new List<string>(
                            input.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));

            for(int i = 0; i < inputParams.Count; i++)
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
                            System.Diagnostics.Debug.WriteLine("spelling error on line: " + lineCount + " at space 1");
                            //StatusBar.Text("spelling error on line: " + lineCount + " at space 1");
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
                        System.Diagnostics.Debug.WriteLine("Error with integer on line " + lineCount + " at space 2");
                    }
                }       
            }
        }
    }
}
