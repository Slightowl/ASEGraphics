using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    public class Looper
    {

        PaintBox Canvas;
        VariableTextParser variableTextParser;
        TextParser TextParser;
        MultiLineTextParser MultiLineTextParser;
        MethodParser methodParser;
        Looper looper;
        ifElseParser ifElseParser;

        List<string> commandList = new List<string>();
        List<string> loopList = new List<string>();

        bool loopFlag;
        int loopIterations = 0;
        int loopCount = 0;

        public Looper(PaintBox paintBox, TextParser textParser, MultiLineTextParser multi)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
            this.MultiLineTextParser = multi;
        }

        public void commandParse(List<string> commands)
        {
            commandList = commands;
            foreach(string input in commandList)
            {
                LoopParse(input);
            }
        }

        public void LoopParse(string input)
        {
            string loopInput = input.Trim().ToLower();

            List<string> inputParams = new List<string>(
                            loopInput.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));

            int loopIterations = Int32.Parse(inputParams[2]);
            System.Diagnostics.Debug.WriteLine(loopIterations);

            foreach (string inputLoop in commandList)
            {
                if (inputLoop.Contains("end") == true)
                {
                    for (int i = 0; i < loopIterations; i++)
                    {
                        foreach (string j in loopList)
                        {
                            string loopText = j;
                            if (MultiLineTextParser == null)
                            {
                                MultiLineTextParser = new MultiLineTextParser(Canvas, TextParser, variableTextParser,
                                    methodParser, looper, ifElseParser);
                                MultiLineTextParser.MultiParse(loopText);
                            }
                            else
                            {
                                MultiLineTextParser.MultiParse(loopText);
                            }
                        }
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
    }
}
