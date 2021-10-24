using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лаба
{
    class Army
    {

        //..........//ПОЛЯ И СВОЙСТВА//..........//
        public string Team { get; private set; }
        private IIntelligentCreature[] arr;
        private int sizeArmy;
        public int SizeArmy { get => sizeArmy; }
        public IIntelligentCreature this[int i]
        {
            get { return arr[i]; }
            set { arr[i] = value; }
        }

        //..........//КОНСТРУКТОРЫ//..........//
        public Army(int size, string team)
        {
            Team = team;
            sizeArmy = size;
            arr = new IIntelligentCreature[size];
        }
        public Army(string team)
        {
            Team = team;
            arr = new IIntelligentCreature[0];
        }
        private Army() { }


        //..........//МЕТОДЫ//..........//
        public Army Add(IIntelligentCreature a)
        {

            Army b = new Army(sizeArmy + 1, Team);
            for (int i = 0; i < sizeArmy; i++)
            {
                b[i] = arr[i];
            }
            b[sizeArmy] = a;
            return b;
        }
        public Army Del(string name)
        {
            bool end = false;
            Army b = new Army(sizeArmy - 1, Team);
            for (int i = 0, j = 0; i < sizeArmy; j++, i++)
            {
                if (arr[i].Name != name || end)
                {
                    b[j] = arr[i];
                }
                else j--;
            }
            return b;
        }
        //public IIntelligentCreature Find(int year)
        //{
        //    for (int i = 0; i < sizeArmy; i++)
        //    {
        //        if (arr[i].YearOfBirth == year)
        //        {
        //            return arr[i];
        //        }
        //    }
        //    return arr[0];
        //}

        //public Army FindPower(int min, int max)
        //{
        //    int counter = 0;
        //    for (int i = 0; i < SizeArmy; i++)
        //    {
        //        if (arr[i] is Transformer)
        //        {
        //            var b = new Transformer();
        //            b = arr[i] as Transformer;
        //            if (b.EnginePower < max && b.EnginePower > min)
        //            {
        //                counter++;
        //            }
        //        }
        //    }
        //    Army a = new Army(counter, Team);
        //    for (int i = 0, j = 0; i < sizeArmy && j < counter; i++)
        //    {
        //        var b = new Transformer();
        //        b = arr[i] as Transformer;
        //        if (b.EnginePower < max && b.EnginePower > min)
        //        {
        //            a[j] = arr[i];
        //            j++;
        //        }
        //    }
        //    return a;
        //}
        public void Print()
        {
            Console.WriteLine("Отряд: " + Team + "\n");
            for (int i = 0; i < sizeArmy; i++)
            {
                Console.WriteLine(arr[i]);
                Console.WriteLine(new String('-', 40) + "\n");
            }
        }
       
    }

    public static class ArmyControl //тупизм
    {
        internal static IIntelligentCreature Find(Army a, int year)
        {
            for (int i = 0; i < a.SizeArmy; i++)
            {
                if (a[i].YearOfBirth == year)
                {
                    return a[i];
                }
            }
            return a[0];
        }
        internal static Army FindPower(Army arr, int min, int max)
        {
            int counter = 0;
            for (int i = 0; i < arr.SizeArmy; i++)
            {
                if (arr[i] is Transformer)
                {
                    var b = new Transformer();
                    b = arr[i] as Transformer;
                    if (b.EnginePower < max && b.EnginePower > min)
                    {
                        counter++;
                    }
                }
            }
            Army a = new Army(counter, arr.Team);
            for (int i = 0, j = 0; i < arr.SizeArmy && j < counter; i++)
            {
                var b = new Transformer();
                b = arr[i] as Transformer;
                if (b.EnginePower < max && b.EnginePower > min)
                {
                    a[j] = arr[i];
                    j++;
                }
            }
            return a;
        }
        internal static Army InitFromFile(string team, string path)
        {
            var a = new Army(team);
            using StreamReader sr = new StreamReader(path);

            string f;
            do
            {
                f = sr.ReadLine();
                if (f != null)
                {
                    var s = f.Split(' ');
                    foreach(string str in s)
                    {
                        if (str == "")
                            throw new ExTestReadFile("Данные из файла считаны неккоректно");
                    }
                    a = a.Add(new Transformer(s[0], s[1], Int32.Parse(s[2])));
                }
            } while (f != null);



            return a;
        }

        //internal static Army InitFromJson(string path)
        //{
        //    var json = File.ReadAllText("Json.json");
        //    var army = new Army("Дельта");
        //    army = JsonConvert.DeserializeObject<Army>(json); 

        //    return army;
        //}
    }
}
