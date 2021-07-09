using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    public class MultiLineTextParser
    {
        PaintBox Canvas;
        TextParser TextParser;
        VariableTextParser VariableTextParser;
        MethodParser MethodParser;
        MultiLineTextParser multiLineTextParser;
        Looper Looper;
        ifElseParser ifElseParser;

        Dictionary<string, int> storedVariables = new Dictionary<string, int>();
        List<string> loopList = new List<string>();

        bool loopFlag;
        int loopIterations = 0;
        int loopCount = 0;

        string methodCall = "";
        string eq = "=";

        /// <summary>Initializes a new instance of the <see cref="MultiLineTextParser" /> class.</summary>
        /// <param name="paintBox">The paint box.</param>
        /// <param name="textParser">The text parser.</param>
        public MultiLineTextParser(PaintBox paintBox, TextParser textParser, VariableTextParser variableTextParser, 
            MethodParser methodParser, Looper looper, ifElseParser ifElseParser)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
            this.VariableTextParser = variableTextParser;
            this.MethodParser = methodParser;
            this.Looper = looper;
            this.ifElseParser = ifElseParser;
        }

        /// <summary>Transfers dictionary data</summary>
        /// <param name="varDictionary">User defined key value pair</param>
        public void ValueConverter(Dictionary<string, int> varDictionary)
        {
            storedVariables = varDictionary;
        }

        /// <summary>Methods the list.</summary>
        /// <param name="method">Passes method name into class</param>
        public void MethodList(string method)
        {
            methodCall = method;
        }

        /// <summary>Multis the parse.</summary>
        /// <param name="commands">The commands.</param>
        public void MultiParse(string commands)
        {
            List<string> commandList = new List<string>(
                            commands.Split(new string[] { "\r\n" },
                            StringSplitOptions.RemoveEmptyEntries));

            foreach (string input in commandList)
            {
                //##############//
                //***METHODS****//
                //##############//
                if (input.Contains(methodCall + "()") == true)
                {
                    if (MethodParser == null)
                    {
                        MethodParser = new MethodParser(Canvas, TextParser, multiLineTextParser);
                        MethodParser.MethodExecute();
                    }
                    else
                    {
                        MethodParser.MethodExecute();
                    }
                }
                else if (input.Contains("(") == true)
                {
                    
                    if (MethodParser == null)
                    {
                        MethodParser = new MethodParser(Canvas, TextParser, multiLineTextParser);
                        MethodParser.MethodSetter(commandList);
                    }
                    else
                    {
                        MethodParser.MethodSetter(commandList);
                    }
                    break;
                }
                
                //************************//
                // handle loop statements //
                //************************//
                else if (input.Contains("loop") == true)
                {
                    string loopInput = input.Trim().ToLower();

                    List<string> inputParams = new List<string>(
                                    loopInput.Split(new string[] { ",", " " },
                                    StringSplitOptions.RemoveEmptyEntries));


                    int loopIterations = Int32.Parse(inputParams[2]);

                    foreach (string inputLoop in commandList)
                    {
                        if (inputLoop.Contains("end") == true)
                        {
                            for (int i = 0; i < loopIterations; i++)
                            {
                                foreach (string j in loopList)
                                {
                                    string loopText = j;
                                    MultiParse(loopText);
                                }
                                System.Diagnostics.Debug.WriteLine("loop count: " + i);
                            }
                        }
                        else
                        {
                            if (inputLoop.Contains("loop") == true)
                            {
                                System.Diagnostics.Debug.WriteLine("ignore loop command for loopList");
                            }
                            else
                            {
                                loopList.Add(inputLoop);
                            }
                        }
                    }
                }

                //*********************//
                // handle if statements//
                //*********************//
                else if (input.Contains("if") == true)
                {
                    if (ifElseParser == null)
                    {
                        ifElseParser = new ifElseParser(Canvas, TextParser, multiLineTextParser);
                        ifElseParser.ifParser(commandList);
                    }
                    else
                    {
                        ifElseParser.ifParser(commandList);
                    }
                    break;
                }
                //*********************//
                //  handle variables   //
                //*********************//
                else if (input.Contains(eq) == true)
                {
                    if (VariableTextParser == null)
                    {
                        VariableTextParser = new VariableTextParser(Canvas, TextParser, multiLineTextParser);
                        VariableTextParser.Parse(input);
                    }
                    else
                    {
                        VariableTextParser.Parse(input);

                    }
                }
                else
                {
                    TextParser.Parse(input);
                }
            }
        }
    }
}
