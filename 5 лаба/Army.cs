using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_лаба
{
    class Army
    {

        //..........//ПОЛЯ И СВОЙСТВА//..........//
        public string Team { get; private set; }
        public IIntelligentCreature[] arr;
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



        //..........//МЕТОДЫ//..........//
        public Army Add(IIntelligentCreature a)
        {
            
            Army b = new Army(sizeArmy + 1,Team);
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
            for(int i=0,j=0;i<sizeArmy;j++,i++)
            {
                if (arr[i].Name != name||end)
                {
                    b[j] = arr[i];
                }
                else j--;
            }
            return b;
        }
        public IIntelligentCreature Find(int year)
        {
            for(int i=0;i<sizeArmy;i++)
            {
                if(arr[i].YearOfBirth == year)
                {
                    return arr[i];
                }
            }
            return arr[0];
        }
        public Army FindPower(int min,int max)
        {
            int counter = 0;
            for(int i=0;i<SizeArmy;i++)
            {
                if (arr[i] is Transformer)
                {
                    var b = new Transformer();
                    b = arr[i] as Transformer;
                    if(b.EnginePower<max&&b.EnginePower>min)
                    {
                        counter++;
                    }
                }
            }
            Army a = new Army(counter, Team);
            for(int i=0,j=0;i<sizeArmy&&j<counter;i++)
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
        public void Print()
        {
            Console.WriteLine("Отряд: "+Team+"\n");
            for (int i = 0; i < sizeArmy; i++)
            {
                Console.WriteLine(arr[i]);
                Console.WriteLine(new String('-', 40) + "\n");
            }
        }
    }
}
