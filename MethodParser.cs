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
        int result;

        public MethodParser(PaintBox paintBox, TextParser textParser, MultiLineTextParser multi)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
            this.MultiLineTextParser = multi;
        }

        /// <summary>Dictionary transferrer</summary>
        /// <param name="varDictionary">
        ///   <para>
        /// Transfers key value pairs to class</para>
        /// </param>
        public void ValueConverter(Dictionary<string, int> varDictionary)
        {
            userVariables = varDictionary;
 
        }

        /// <summary>Methods the setter.</summary>
        /// <param name="commandList">Sets defined method up</param>
        public void MethodSetter(List<string> commandList)
        {
            int methodCounter = 0;
            int paramCounter = 0;

            string methodCall = Regex.Replace(commandList[1], @"\(.*$", "", RegexOptions.None, TimeSpan.FromSeconds(0.5));
            string parameters = Regex.Match(commandList[1], @"\(([^)]*)\)").Groups[1].Value;

            userVariables.TryGetValue(parameters, out result);
            
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
                if (commandList[i].Contains(methodCall))
                {
                    paramCounter = i;
                }
            }
            
            for (int i = 0; i < commandList.Count; i++)
            {
                string shape;
                string paramShape;

                if (i > methodCounter)
                {
                    if (commandList[i].Contains("value"))
                    {
                        methodList.Add(commandList[i]);
                    }

                    string trimmed = commandList[i].Trim().ToLower();

                    List<string> inputParams = new List<string>(
                            trimmed.Split(new string[] { ",", " " },
                            StringSplitOptions.RemoveEmptyEntries));

                    for(int j = 0; j < inputParams.Count; j++)
                    {
                        if (userVariables == null)
                        {
                            methodList.Add(commandList[i]);
                        }
                        else
                        {
                            if (inputParams[j].Contains(parameters))
                            {
                                System.Diagnostics.Debug.WriteLine("annoyed");
                            }
                            else if (inputParams[j].Contains("circle"))
                            {
                                paramShape = "circle" + " " + parameters;
                                methodList.Add(paramShape);
                            }
                            else if (inputParams[j].Contains("rect"))
                            {
                                paramShape = "rect" + " " + parameters + " " +  parameters;
                                methodList.Add(paramShape);
                            }
                            else
                            {
                                methodList.Add(commandList[i]);
                            }
                        }
                    }
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
