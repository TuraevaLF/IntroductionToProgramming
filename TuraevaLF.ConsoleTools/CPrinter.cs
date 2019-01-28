using System;
using System.Collections.Generic;
using System.Text;

namespace TuraevaLF.ConsoleTools
{
    public static class CPrinter
    {
        public static void PrintHeader()
        {
            FillLine('=');
        }

        public static void PrintHeader(string header)
        {
            FillLine('=');
            if (header != null)
            {
                PrintEmptyLine();
                PrintText(header.ToUpper(), 3, 3);
                PrintEmptyLine();
                FillLine('=');
            }
        }

        public static void PrintFooter()
        {
            FillLine('=');
        }

        public static void PrintFooter(string text)
        {
            FillLine('=');
            if (text != null)
            {
                PrintText(text);
                FillLine('=');
            }
        }
        
        public static void PrintEmptyLine()
        {
            FillLine(' ');
        }

        public static void PrintSeparator()
        {
            FillLine('-');
        }

        public static void PrintList(IEnumerable<string> items)
        {
            foreach(string item in items)
            {
                PrintText(item, 5);
            }
        }

        public static void FillLine(char pattern)
        {
            PrintText(new string(pattern, Console.WindowWidth - 3), 0, 0);
        }

        public static void PrintText(string text, int paddingLeft = 1, int paddingRight = 1)
        {
            int paddingTotal = paddingLeft + paddingRight;
            int maxTextLength = Console.WindowWidth - paddingTotal - 3;
            SplitToLines(text, maxTextLength).ForEach(line => 
            {
                Console.WriteLine("*{0}{1}{2}*",
                    new string(' ', paddingLeft),
                    line.PadRight(maxTextLength),
                    new string(' ', paddingRight));
            });
        }

        private static List<string> SplitToLines(string text, int maxLineLength)
        {
            List<string> lines = new List<string>();

            foreach(string paragrapgh in text.Split(new[] { Environment.NewLine }, StringSplitOptions.None))
            {
                (int From, int To) range = (0, Math.Min(maxLineLength, paragrapgh.Length));
            
                while(range.To - range.From > 0)
                {
                    int lastSpaceIdx = -1;

                    if (paragrapgh.Length - range.From > maxLineLength)
                    {
                        lastSpaceIdx = paragrapgh.LastIndexOf(' ', range.To, range.To - range.From);
                    }

                    lastSpaceIdx = lastSpaceIdx > -1 ? lastSpaceIdx : range.To;

                    lines.Add(paragrapgh.Substring(range.From, lastSpaceIdx - range.From));
                    range.From = lastSpaceIdx + 1;
                    range.To = Math.Min(range.To + maxLineLength, paragrapgh.Length);
                }
            }
            return lines;
        }
    }
}