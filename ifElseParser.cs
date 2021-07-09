using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Donnatello
{
    public class ifElseParser
    {
        PaintBox Canvas;
        VariableTextParser variableTextParser;
        TextParser TextParser;
        MultiLineTextParser MultiLineTextParser;
        MethodParser methodParser;
        Looper Looper;
        ifElseParser IfElseParser;

        string result = "";
        int result2;
        int elseCounter = 0;
        int ifCounter = 0;
        int ifVal = 0;
        string ifCondition;
        int ifVal2 = 0;
        int elseVal = 0;
        string elseCondition;
        int elseVal2 = 0;
        int ifElseParam = 0;

        List<string> commandList = new List<string>();
        List<string> ifList = new List<string>();
        List<string> elseList = new List<string>();
        Dictionary<string, int> userVariables;


        public ifElseParser(PaintBox paintBox, TextParser textParser, MultiLineTextParser multi)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
            this.MultiLineTextParser = multi;
        }

        /// <summary>Values the converter.</summary>
        /// <param name="varDictionary">
        ///   <para>
        /// Passes key value pairs into class</para>
        /// </param>
        public void ValueConverter(string value)
        {
            result = value;
            System.Diagnostics.Debug.WriteLine(result);

        }

        /// <summary>Ifs the parser.</summary>
        /// <param name="commandList">Parses if / else statements from list</param>
        public void ifParser(List<string> commandList)
        {
            //ifElseParam = int.Parse(result);

            for (int i = 0; i < commandList.Count; i++)
            {
                if (commandList[i].Contains("if") == true)
                {
                    ifCounter = i;
                }
                else if (commandList[i].Contains("else") == true)
                {
                    elseCounter = i;
                }
                else
                {
                    // do nothing
                } 
            }
            for (int i = 0; i < commandList.Count; i++)
            {
                if (i >= ifCounter && i < elseCounter)
                {
                    ifList.Add(commandList[i]);
                }
                else if (i > elseCounter && i <= commandList.Count)
                {
                    elseList.Add(commandList[i]);
                }
            }

            foreach (string inputs in commandList)
            {
                List<string> ifParams = new List<string>(
                                    inputs.Split(new string[] { ",", " " },
                                    StringSplitOptions.RemoveEmptyEntries));

                if (inputs.Contains("if") == true)
                {
                    for (int i = 0; i < ifParams.Count; i++)
                    {
                        if (i == 1)
                        {
                            int testNum = 0;
                            string ifParam = ifParams[i];
                            bool isNum = int.TryParse(ifParam, out testNum);

                            if (isNum == true)
                            {
                                ifVal = int.Parse(ifParam);
                            }
                            else
                            {
                                ifVal = ifElseParam;
                            }

                        }
                        else if (i == 2)
                        {
                            ifCondition = ifParams[i];
                        }
                        else if (i == 3)
                        {
                            ifVal2 = int.Parse(ifParams[i]);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("...");
                        }
                    }
                }
                else if (inputs.Contains("else") == true)
                {
                    for (int i = 0; i < ifParams.Count; i++)
                    {
                        if (i == 1)
                        {

                            int testNum = 0;
                            string ifParam = ifParams[i];
                            bool isNum = int.TryParse(ifParam, out testNum);

                            if (isNum == true)
                            {
                                elseVal = int.Parse(ifParam);
                            }
                            else
                            {
                                elseVal = ifElseParam;
                            }
                        }
                        else if (i == 2)
                        {
                            elseCondition = ifParams[i];
                        }
                        else if (i == 3)
                        {
                            elseVal2 = int.Parse(ifParams[i]);
                            System.Diagnostics.Debug.WriteLine(elseVal2);
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("...");
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("...");
                }
            }
            System.Diagnostics.Debug.WriteLine(ifVal + " " + ifVal2 + " " +  elseVal + " " + elseVal2);
            ifElseDecider(ifVal, ifVal2, elseVal, elseVal2);
        }

        /// <summary>Logic to decide whether if or else</summary>
        /// <param name="ifVal">If value</param>
        /// <param name="ifVal2">If val2</param>
        /// <param name="elseVal">The else value</param>
        /// <param name="elseVal2">The else val2</param>
        public void ifElseDecider(int ifVal, int ifVal2, int elseVal, int elseVal2)
        {
            System.Diagnostics.Debug.WriteLine(ifVal + " " + ifVal2 + " " + elseVal + " " + elseVal2);
            if (ifVal > ifVal2)
            {
                System.Diagnostics.Debug.WriteLine("if statement executing...");
                foreach(string item in ifList)
                {
                    System.Diagnostics.Debug.WriteLine("executing..." + item);
                }
                ifElseExecution(ifList);
            }
            else if (elseVal < elseVal2)
            {
                System.Diagnostics.Debug.WriteLine("else statement executing...");
                foreach (string item in elseList)
                {
                    System.Diagnostics.Debug.WriteLine("executing..." + item);
                }
                ifElseExecution(elseList);
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("invalid if else statement currently...");
            }
        }

        /// <summary>Ifs the else execution.</summary>
        /// <param name="ifExe">Passes commands to multiparser</param>
        public void ifElseExecution(List<string> ifExe)
        {
            foreach(string command in ifExe)
            {
                System.Diagnostics.Debug.WriteLine("...executing: " + command);
                if (MultiLineTextParser == null)
                {
                    MultiLineTextParser = new MultiLineTextParser(Canvas, TextParser, variableTextParser,
                        methodParser, Looper, IfElseParser);
                    MultiLineTextParser.MultiParse(command);
                }
                else
                {
                    MultiLineTextParser.MultiParse(command);
                } 
            }
        }
    }
}
