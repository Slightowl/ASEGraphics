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

        public void MethodSetter(List<string> commandList)
        {
            int methodCounter = 0;

            string methodCall = Regex.Replace(commandList[0], @"\(.*$", "", RegexOptions.None, TimeSpan.FromSeconds(0.5));
            string parameters = Regex.Match(commandList[0], @"\(([^)]*)\)").Groups[1].Value;

            System.Diagnostics.Debug.WriteLine(methodCall);

            if (MultiLineTextParser == null)
            {
                MultiLineTextParser = new MultiLineTextParser(Canvas, TextParser, variableTextParser, methodParser, Looper, ifElseParser);
                MultiLineTextParser.MethodList(methodCall);
            }
            else
            {
                MultiLineTextParser.MethodList(methodCall);
            }

            for (int i = 0; i < commandList.Count; i++)
            {
                if (commandList[i].Contains(methodCall))
                {
                    methodCounter = i;
                }
            }

            for(int i = 0; i < commandList.Count; i++)
            {
                if (i > methodCounter)
                {
                    methodList.Add(commandList[i]);
                }
            }
        }
        public void MethodExecute()
        {
            foreach(string command in methodList)
            {
                MultiLineTextParser.MultiParse(command);
            }
        }
            
    }
}
