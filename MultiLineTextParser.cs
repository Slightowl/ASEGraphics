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
        string loopInput;
        string loopText;
        List<string> loopList = new List<string>();
        bool loopFlag;
        int loopIterations = 0;
        int loopCount = 0;
        int ifValue = 0;
        int ifCondition = 0;
        string eq = "=";


        /// <summary>Initializes a new instance of the <see cref="MultiLineTextParser" /> class.</summary>
        /// <param name="paintBox">The paint box.</param>
        /// <param name="textParser">The text parser.</param>
        public MultiLineTextParser(PaintBox paintBox, TextParser textParser, VariableTextParser variableTextParser)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
            this.VariableTextParser = variableTextParser;
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
                System.Diagnostics.Debug.WriteLine(input);

                //************************//
                // handle loop statements //
                //************************//
                // TODO: needs refactoring put into own class
                if (input.Contains("loop") == true)
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
                    string loopInput = input.Trim().ToLower();

                    List<string> inputParams = new List<string>(
                                    loopInput.Split(new string[] { ",", " " },
                                    StringSplitOptions.RemoveEmptyEntries));

                    int ifCondition = Int32.Parse(inputParams[2]);
                    int ifValue = Int32.Parse(inputParams[3]);


  

                }
                else if (input.Contains(eq) == true)
                {
                    VariableTextParser.Parse(input);
                }
                else
                {
                    TextParser.Parse(input);
                }
            }
        }
    }
}
