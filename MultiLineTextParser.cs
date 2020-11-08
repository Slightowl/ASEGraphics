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

        /// <summary>Initializes a new instance of the <see cref="MultiLineTextParser" /> class.</summary>
        /// <param name="paintBox">The paint box.</param>
        /// <param name="textParser">The text parser.</param>
        public MultiLineTextParser(PaintBox paintBox, TextParser textParser)
        {
            this.Canvas = paintBox;
            this.TextParser = textParser;
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
                //Console.WriteLine(input);
                TextParser.Parse(input);
            }
        }
    }
}
