using System;

namespace _9_лаба
{
    
    internal class Program
    {
        public delegate string Func(ref string arg);
        private static void Main(string[] args)
        {

            Func clearingString = DeleteUnnecessarySpaces;
            clearingString += DeleteAllMarks;
            clearingString += UpperCase;
            clearingString += LowerCase;

            
            string str = " ПРоБеЛ!!  ДвА_ПрОбела,   ТрИ_проБела....    ЧЕтыре_пробЕлА,\n";
            Console.WriteLine($"Начальная строка:\n{str}");


            Console.WriteLine($"Обработанная строка:\n{clearingString(ref str)}");
        }

        private static string UpperCase(ref string str)
        {
            return str.ToUpper();
        }

        private static string LowerCase(ref string str)
        {
            return str.ToLower();
        }

        private static string DeleteUnnecessarySpaces(ref string str)
        {
            var s = str.Split(" ");
            str = "";
            foreach (var item in s)
            {
                str += item;
                if(!string.IsNullOrEmpty(item))
                str += " ";
            }

            return str;
        }

        private static string DeleteAllMarks(ref string str)
        {
            var chStart = str.ToCharArray();
            int counter = 0;
            foreach (var ch in chStart)
            {
                if (ch != ',' && ch != '.' && ch != '!')
                {
                    counter++;
                }
            }


            char[] chEnd = new char[counter];
            counter = 0;
            for(int i=0; i<chStart.Length; i++)
            {
                if (chStart[i] != ',' && chStart[i] != '.' && chStart[i] != '!')
                {
                    chEnd[counter] = chStart[i];
                    counter++;
                }
            }

            str = new string(chEnd);
            return str;
        }
    }
}
