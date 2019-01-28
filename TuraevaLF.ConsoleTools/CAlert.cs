using System;

namespace TuraevaLF.ConsoleTools
{
    public class CAlert : CDialog
    {
        private string message;

        public CAlert(string message)
           : base(null, "Для продолжения нажмите Enter.")
        {
            this.message = message;
        }

        public CAlert(string header, string message)
            : base(header, "Для продолжения нажмите Enter.")
        {
            this.message = message;
        }

        protected override void PrintContent()
        {
            CPrinter.PrintText(message);
        }

        protected override bool Run()
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.Enter:
                case ConsoleKey.Escape:
                case ConsoleKey.X:
                    return false;
                default:
                    return true;
            }
        }

        public static void Show(string message)
        {
            Show(null, message);
        }

        public static void Show(string header, string message)
        {
            CAlert alert = new CAlert(header, message);
            alert.Show();
        }
    }
}
