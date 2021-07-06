using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Donnatello
{
    public class MethodParser
    {
        PaintBox Canvas;
        VariableTextParser variableTextParser;
        TextParser TextParser;
        MultiLineTextParser MultiLineTextParser;
        MethodParser methodParser;
        Looper Looper;
        ifElseParser ifElseParser;

        Dictionary<string, int> userVariables = new Dictionary<string, int>();
        List<string> methodList = new List<string>();

        public MethodParser(PaintBox paintBox, TextParser textParser, MultiLineTextParser multi)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
            this.MultiLineTextParser = multi;
        }

        public void MethodParse(string inputs)
        {
            if (inputs.Contains("()") == true)
            {
                try
                {
                    string modifiedInput = Regex.Replace(inputs, @"[^0-9a-zA-Z]+", "", RegexOptions.None, TimeSpan.FromSeconds(0.5));
                    methodList.Add(modifiedInput);

                    if (MultiLineTextParser == null)
                    {
                        MultiLineTextParser = new MultiLineTextParser(Canvas, TextParser, variableTextParser, methodParser, Looper, ifElseParser);
                        MultiLineTextParser.MethodList(methodList);
                    }
                    else
                    {
                        MultiLineTextParser.MethodList(methodList);
                    }
                }
                catch (RegexMatchTimeoutException)
                {
                    System.Diagnostics.Debug.WriteLine("Regex failed");
                }
            }
            else
            {
                methodList.Add(inputs);
                MultiLineTextParser.MethodList(methodList);
            }
        }
    }
}
