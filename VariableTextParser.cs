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
        //StatusBar Status;
        VariableTextParser variableTextParser;
        TextParser TextParser;
        MultiLineTextParser MultiLineTextParser;
        MethodParser MethodParser;
        Looper Looper;
        ifElseParser ifElseParser;

        int result;
        int count;
        Dictionary<string, int> varDictionary = new Dictionary<string, int>();

        public VariableTextParser(PaintBox paintBox, TextParser textParser, MultiLineTextParser multi)
        {
            this.Canvas = paintBox;
            //this.Status = statusBar;
            this.TextParser = textParser;
            this.MultiLineTextParser = multi;
        }

        /// <summary>Parses the specified input.</summary>
        /// <param name="input">Parses strings</param>
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

                if (ifElseParser == null)
                {
                    ifElseParser = new ifElseParser(Canvas, TextParser, MultiLineTextParser);
                    string send = updateValue.ToString();
                    ifElseParser.ValueConverter(send);
                }
                else
                {
                    string send = updateValue.ToString();
                    ifElseParser.ValueConverter(send);
                }
            }

            if (MultiLineTextParser == null)
            {
                MultiLineTextParser = new MultiLineTextParser(Canvas, TextParser, variableTextParser, MethodParser, Looper, ifElseParser);
                MultiLineTextParser.ValueConverter(varDictionary);
            }
            else
            {
                MultiLineTextParser.ValueConverter(varDictionary);
            }
            if(MethodParser == null)
            {
                MethodParser = new MethodParser(Canvas, TextParser, MultiLineTextParser);
                MethodParser.ValueConverter(varDictionary);
            }
            else
            {
                MethodParser.ValueConverter(varDictionary);
            }
            if (ifElseParser == null)
            {
                string send = result.ToString();
                ifElseParser = new ifElseParser(Canvas, TextParser, MultiLineTextParser);
                ifElseParser.ValueConverter(send);
            }
            else
            {
                string send = result.ToString();
                ifElseParser.ValueConverter(send);
            }

            TextParser.ValueConverter(varDictionary);
        }
    }
}
