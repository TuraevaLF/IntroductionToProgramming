using System;
using System.ComponentModel;
using System.Text;

namespace TuraevaLF.ConsoleTools
{
    public static class CPrompt
    {
        public const int DefaultMaxLength = 25;

        public static int GetInt(string message)
        {
            return Get<int>(message);
        }

        public static int GetInt(string header, string message, int maxLength = CPrompt.DefaultMaxLength)
        {
            return Get<int>(header, message, maxLength);
        }

        public static string GetString(string message)
        {
            return Get<string>(message);
        }


        public static string GetString(string header, string message, int maxLength = DefaultMaxLength)
        {
            return Get<string>(header, message, maxLength);
        }

        public static double GetDouble(string message)
        {
            return Get<double>(message);
        }

        public static double GetDouble(string header, string message, int maxLength = DefaultMaxLength)
        {
            return Get<double>(header, message, maxLength);
        }

        public static T Get<T>(string message)
        {
            CPrompt<T> input = new CPrompt<T>(message);
            input.Show();
            return input.Result;
        }

        public static T Get<T>(string header, string message, int maxLength = DefaultMaxLength)
        {
            CPrompt<T> input = new CPrompt<T>(header, message, maxLength);
            input.Show();
            return input.Result;
        }
    }

    public class CPrompt<T> : CDialog
    {
        private string message;
        private string notice;
        private StringBuilder sb;
        private TypeConverter converter;
        private int maxInputLength;
        private int cTop;
        private int cLeft;

        public T Result { get; private set; }

        public CPrompt (string message)
            : this(null, message)
        {
        }

        public CPrompt(string header, string message, int maxInputLength = CPrompt.DefaultMaxLength)
            : base(header)
        {
            sb = new StringBuilder();
            cLeft = 6;
            converter = TypeDescriptor.GetConverter(typeof(T));

            if (converter == null || !converter.CanConvertFrom(typeof(string)))
            {
                throw new NotSupportedException($"�� �������������� ��� { typeof(T).Name }");
            }

            this.message = message;
            this.maxInputLength = maxInputLength;
        }

        protected override void PrintContent()
        {
            if (message != null)
            {
                CPrinter.PrintText(message);
                CPrinter.PrintEmptyLine();
            }
            cTop = Console.CursorTop;
            CPrinter.PrintText(sb.ToString().PadRight(maxInputLength, '_'), 5);

            if (notice != null)
            {
                CPrinter.PrintEmptyLine();
                CPrinter.PrintText(notice);
            }
        }

        protected override bool Run()
        {
            Console.CursorTop = cTop;
            Console.CursorLeft = cLeft;

            ConsoleKeyInfo keyInfo = Console.ReadKey(true);

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                try
                {
                    Result = (T)converter.ConvertFromString(sb.ToString());
                    Console.Clear();
                }
                catch
                {
                    notice = $"�������� ������ �����������.";
                    return true;
                }
                return false;
            }
            else if (keyInfo.Key == ConsoleKey.Backspace)
            {
                if (sb.Length > 0)
                {
                    sb.Remove(sb.Length - 1, 1);
                    cLeft--;
                }
            }
            else if(keyInfo.KeyChar != 0)
            {
                if(sb.Length == maxInputLength)
                {
                    Console.Beep();
                    return true;
                }

                sb.Append(keyInfo.KeyChar);
                cLeft++;
            }
            return true;
        }
    }
}