using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;


namespace Donnatello
{
    public class VariableTextParser
    {
        PaintBox Canvas;
        StatusBar Status;
        TextParser TextParser;

        public VariableTextParser(PaintBox paintBox, TextParser textParser, StatusBar statusBar)
        {
            this.Canvas = paintBox;
            this.Status = statusBar;
            this.TextParser = textParser;
        }

        public void Parse(string input)
        {

            string variableName = "Test-num";
            string op = "=";
            int variableAssignment = 35;

            input = input.Trim().ToLower();

            List<string> inputParams = new List<string>(
                            input.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));


            for (int i = 0; i < inputParams.Count; i++)
            {
                if (i == 0)
                {
                    variableName = inputParams[i];
                    Console.WriteLine(variableName);
                }
                else if (i == 1)
                {
                    op = inputParams[i];
                    Console.WriteLine(op);
                }
                else if (i == 2)
                {
                    variableAssignment = Int32.Parse(inputParams[i]);
                    Console.WriteLine(variableAssignment);
                }
                else
                {
                    Console.WriteLine("too many parameters");
                }
            }
            //System.Diagnostics.Debug.WriteLine(variableName + " " + op + " " + variableAssignment);

            var varDictionary = new Dictionary<string, int>
            {
                [variableName] = variableAssignment
            };

            TextParser.ValueConverter(varDictionary);

        }


    }
}
