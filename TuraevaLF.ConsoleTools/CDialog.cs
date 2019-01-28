using System;

namespace TuraevaLF.ConsoleTools
{
    public abstract class CDialog
    {
        public string Header { get; protected set; }
        public string Footer { get; protected set; }

        public CDialog()
            : this(null, null)
        {
        }

        public CDialog(string header)
            : this(header, null)
        {
        }

        public CDialog(string header, string footer)
        {
            Header = header;
            Footer = footer;
        }

        public void Show()
        {
            do
            {
                Console.Clear();
                CPrinter.PrintHeader(Header);
                CPrinter.PrintEmptyLine();
                PrintContent();
                CPrinter.PrintEmptyLine();
                CPrinter.PrintFooter(Footer);
            }
            while (Run());
        }

        protected abstract void PrintContent();
        protected abstract bool Run();
    }
}