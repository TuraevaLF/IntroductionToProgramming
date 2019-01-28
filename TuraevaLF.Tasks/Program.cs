using System;
using TuraevaLF.ConsoleTools;

namespace TuraevaLF.Tasks
{
    class Program
    {
        const string Task1Name = "Задание № 1 - Генерация случайных чисел";
        const string Task2Name = "Задание № 2 - Сортировка массива методом пузырька";
        const string Task3Name = "Задание № 3 - Сортировка массива методом вставки";
        const string Task4Name = "Задание № 4 - Программа, решающая линейную регрессию";
        const string Task5Name = "Задание № 5 - Программа, осуществляющая интерполяцию функции";

        static void Main(string[] args)
        {
            CMenu menu = new CMenu("Лабораторные работы Тураевой Лилии.");
            menu.AddItem(Task1Name, RunLab1);
            menu.AddItem(Task2Name, RunLab2);
            menu.AddItem(Task3Name, RunLab3);
            menu.Show();
        }

        static void RunLab1()
        {
            int rangeFrom = 0, rangeTo = 0;

            while (rangeFrom >= rangeTo)
            {
                rangeFrom = CPrompt.GetInt(Task1Name, "Введите начало диапазона:");
                rangeTo = CPrompt.GetInt(Task1Name, "Введите конец диапазона:");

                if(rangeFrom >= rangeTo)
                {
                    CAlert.Show($"Неверный диапазон. Начальное значение { rangeFrom } больше или равно конечному { rangeTo }");
                }
            }

            var randomGen = new RandomGenerator(rangeFrom, rangeTo);

            CPrinter.PrintHeader(Task1Name);
            CPrinter.PrintEmptyLine();

            ConsoleKeyInfo keyInfo;
            do
            {
                CPrinter.PrintText($"Случайное значение: { randomGen.GetNext() }");
                CPrinter.PrintEmptyLine();
                CPrinter.PrintFooter("Для выхода нажмите X или Escape. Для генерации следующего значения - любую другую клавишу.");
                keyInfo = Console.ReadKey(true);
                Console.CursorTop -= 4;
            }
            while (keyInfo.Key != ConsoleKey.Escape && keyInfo.Key != ConsoleKey.X);
        }

        static void RunLab2()
        {
            CPrinter.PrintHeader(Task2Name);
            CPrinter.PrintEmptyLine();

            int[] arr = new int[] { 64, 11, 127, -10, 4};

            CPrinter.PrintText($"Сортировка { arr.AsString() } => { arr.SortBubble().AsString() }");
            CPrinter.PrintEmptyLine();
            CPrinter.PrintFooter("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
        }

        static void RunLab3()
        {
            CPrinter.PrintHeader(Task3Name);
            CPrinter.PrintEmptyLine();

            int[] array = new int[] { 64, 11, 127, -10, 4};

            CPrinter.PrintText($"Сортировка { array.AsString() } => { array.SortInsertion().AsString() }");
            CPrinter.PrintEmptyLine();
            CPrinter.PrintFooter("Для продолжения нажмите любую клавишу.");
            Console.ReadKey();
        }
    }
}
