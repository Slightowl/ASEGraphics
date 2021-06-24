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
        int result;
        int count;
        Dictionary<string, int> varDictionary = new Dictionary<string, int>();

        public VariableTextParser(PaintBox paintBox, TextParser textParser, StatusBar statusBar)
        {
            this.Canvas = paintBox;
            this.Status = statusBar;
            this.TextParser = textParser;
        }

        public void Parse(string input)
        {

            string variableName = "Test-num";
            string equalsOp = "=";
            string additionOp = "+";
            int variableAssignment = 0;
            int variableAssignment2 = 0;



            input = input.Trim().ToLower();

            List<string> inputParams = new List<string>(
                            input.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));


            for (int i = 0; i < inputParams.Count; i++)
            {
                if (i == 0)
                {
                    variableName = inputParams[i];
                }
                else if (i == 1)
                {
                    equalsOp = inputParams[i];
                }
                else if (i == 2)
                {
                    if (varDictionary.ContainsKey(variableName))
                    {
                        variableName = inputParams[i];
                    }
                    else
                    {
                        variableAssignment = Int32.Parse(inputParams[i]);
                    }

                }
                else if (i == 3)
                {
                    additionOp = inputParams[i];
                }
                else if (i == 4)
                {
                    System.Diagnostics.Debug.WriteLine(variableAssignment2);
                    variableAssignment2 = Int32.Parse(inputParams[i]);
                }
                else
                {
                    Console.WriteLine("too many parameters");
                }
            }

            try 
            { 
                varDictionary.Add(variableName, variableAssignment);
            }
            catch (ArgumentException)
            {
                System.Diagnostics.Debug.WriteLine(variableName + " - Variable already exists");
            }

            if (varDictionary.ContainsKey(variableName))
            {
                varDictionary.TryGetValue(variableName, out result);
                int updateValue = result + variableAssignment2;
                varDictionary[variableName] = updateValue;
            }

            TextParser.ValueConverter(varDictionary);
        }




    }
}
