using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donnatello
{
    class MultiLineTextParser
    {
        PaintBox Canvas;
        TextParser TextParser;

        public MultiLineTextParser(PaintBox paintBox, TextParser textParser)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
        }

        public void MultiParse(string commands)
        {
            /*string command = "default";
            int param1 = 10;
            int param2 = 10;*/

            List<string> commandList = new List<string>(
                            commands.Split(new string[] { "\r\n" },
                            StringSplitOptions.RemoveEmptyEntries));

            foreach (string input in commandList)
            {
                //String[] inputs = command.Split(' ', ',');
                Console.WriteLine(input);
                TextParser.Parse(input);
            }
        }
    }
}
