using System;
using System.Text; //StringBuilder
using System.Linq; //Arrays

namespace lab2
{
    interface IAgeble
    {
        public int Age();
    }
    public class Mammal:IAgeble
    {
         public int Age()
    {
        var a = DateTime.Now.Year - Birthday.Year;
        if (DateTime.Now.DayOfYear - this.Birthday.DayOfYear > 0)
            a++;
        return a;
    }

        public string Name { get; protected set; }
        public DateTime Birthday { get; protected set; }
        public string Type { get; protected set; }
        public Mammal(string name, DateTime birthday, string type)
        {
            Name = name;
            Birthday = birthday;
            Type = type;

        }


        //.........// Переопределите Еquals //.........//

        public override bool Equals(object? obj)
        {
            var mam = obj as Mammal;
            bool result = false;

            if (mam.Birthday == this.Birthday && mam.Type == this.Type)
                result = true;
            return result;
        }

    }

    class House : Mammal
    {

         public House(string color):base(string nameM)
        {
            Color = color;
        }

        public string Color { get; }
       
    }

    class Program
    {

        static void Main(string args[])
        {

           
        }
    }
}