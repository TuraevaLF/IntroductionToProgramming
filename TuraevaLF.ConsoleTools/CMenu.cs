using System;
using System.Collections.Generic;
using System.Linq;

namespace TuraevaLF.ConsoleTools
{
    public class CMenu : CDialog
    {
        private CMenuOption currentOption;
        private List<CMenuOption> options;
        private string notice;


        public CMenu(string header)
            : base(header, "Для выхода нажмите X или Escape")
        {
            options = new List<CMenuOption>();
        }


        public void AddItem(string name, Action execute)
        {
            AddItem(name, _ => execute(), null);
        }

        public void AddItem(string name, Action<object> execute, object state)
        {
            options.Add(new CMenuOption(name, execute, state));
            currentOption = currentOption ?? options[0];
        }

        public void AddItem<TState>(string name, Action<TState> execute, TState state)
        {
            options.Add(new CMenuOption<TState>(name, execute, state));
            currentOption = currentOption ?? options[0];
        }

        protected override bool Run()
        {
            switch(Console.ReadKey().Key)
            {
                case ConsoleKey.UpArrow:    SelectPrev();       return true;
                case ConsoleKey.DownArrow:  SelectNext();       return true;
                case ConsoleKey.Enter:      Execute();          return true;
                
                case ConsoleKey.Escape:
                case ConsoleKey.X:
                    return false;
                default:
                    return true;
            }
        }

        private void Execute()
        {
            if(currentOption == null)
            {
                return;
            }

            try
            {
                Console.Clear();
                currentOption.Execute();
                notice = $"'{ currentOption.Name }' - Завершено!)";
            }
            catch(Exception ex)
            {
                notice = $"Во время выполнения '{ currentOption.Name }' произошла ошибка :( {Environment.NewLine}{ ex.Message } ";
            }
        }

        private void SelectNext()
        {
            if(options.Count <= 1)
            {
                return;
            }

            int idx = options.IndexOf(currentOption);
            currentOption = ++idx == options.Count ? options[0] : options[idx];
        }

        private void SelectPrev()
        {
            if(options.Count <= 1)
            {
                return;
            }

            int idx = options.IndexOf(currentOption);
            currentOption = --idx < 0 ? options[options.Count - 1] : options[idx];
        }

        protected override void PrintContent()
        {
            CPrinter.PrintList(options.Select(o => $"[{ (o == currentOption ? '*' : ' ') }] { o.Name } "));

            if (!string.IsNullOrWhiteSpace(notice))
            {
                CPrinter.PrintEmptyLine();
                CPrinter.PrintText(notice);
            }
        }
    }
}
