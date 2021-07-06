﻿using System;
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
        Dictionary<string, List<string>> storedMethod = new Dictionary<string, List<string>>();


        List<string> commandList = new List<string>();
        List<string> mList = new List<string>();
        List<string> mResult = new List<string>();
        List<string> loopList = new List<string>();

        bool loopFlag;
        int loopIterations = 0;
        int loopCount = 0;

        string methodCall = "method";
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

        public void ValueConverter(Dictionary<string, int> varDictionary)
        {
            storedVariables = varDictionary;
        }

        public void MethodList(List<string> methodList)
        {
            mList = methodList;
            methodCall = mList.FirstOrDefault();
            System.Diagnostics.Debug.WriteLine(methodCall);
            mList.RemoveAt(0);

            foreach (string item in mList)
            {
                System.Diagnostics.Debug.WriteLine(item);
            }
            try
            {
                storedMethod.Add(methodCall, mList);
            }
            catch (ArgumentException)
            {
                System.Diagnostics.Debug.WriteLine(methodCall + " - Variable already exists");
            }
            foreach (KeyValuePair<string, List<string>> kvp in storedMethod)
            {
                 System.Diagnostics.Debug.WriteLine("Key = {0}, Value = {1}", kvp.Key, kvp.Value);
            }
                commandList.Clear();
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
                if (input.Contains("()") == true)
                {
                    for (int i = 0; i < commandList.Count; i++)
                    {
                        string methodInput = commandList[i];
                        if (MethodParser == null)
                        {
                            MethodParser = new MethodParser(Canvas, TextParser, multiLineTextParser);
                            MethodParser.MethodParse(methodInput);
                        }
                        else
                        {
                            MethodParser.MethodParse(methodInput);
                        }
                    }
                }
                
                else if (input.Contains(methodCall) == true)
                {
                    storedMethod.TryGetValue(methodCall, out mResult);
                    System.Diagnostics.Debug.WriteLine(mResult);

                    for (int i = 1; i < mResult.Count; i++)
                    {
                        MultiParse(mResult[i]);
                    }
                }
                //************************//
                // handle loop statements //
                //************************//
                else if (input.Contains("loop") == true)
                {
                    //if (Looper == null)
                        //{
                        //    Looper = new Looper(Canvas, TextParser, multiLineTextParser);
                        //    Looper.commandParse(commandList);
                        //}
                        //else
                        //{
                        //    Looper.commandParse(commandList);
                        //}
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
