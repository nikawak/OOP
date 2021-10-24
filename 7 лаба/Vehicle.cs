using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лаба
{
    //..........//ТРАНСПОРТОМ МОЖНО УПРАВЛЯТЬ//..........//
    public abstract class Vehicle : ICarManagement
    {
        protected string model;
        public string Model
        {
            get { return model; }
        }
        protected byte wheels;
        public byte Wheels
        {
            get { return wheels; }
        }
        protected int enginePower;
        public int EnginePower { get { return enginePower; } }



        public virtual bool PoweringEngine(Engine engine)
        { 
            Console.WriteLine(GetType().Name);
            Console.WriteLine("\n"+ToString());
            bool res = engine.TryToPowering();
            Console.WriteLine(res);
            if (res) { Console.WriteLine("Получилось!!! Машина едет"); }
            else { Console.WriteLine("Двигатель сломался"); }
            return res;
        }
        public override string ToString()
        {
            string res = "Объект класса " + GetType().Name;
            if (model != null) res += "\nМодель: " + model;
            else res += "\n";
            res += " имеет " + Wheels + " колес(а)\nМощность его двигателя составляет " + EnginePower + " л.с.";
            return res;
        }
        public override bool Equals(object obj)
        {
            //динамическая идентификация типов
            if(obj is Vehicle && obj != null)
            {
                return this.GetType() == obj.GetType();
            }
            return false;
        }
        public override int GetHashCode()
        {
            Random rand = new Random();
            return rand.Next(1000000);
        }
    }

    public sealed class Car : Vehicle
    {
        public Car()
        {
            this.wheels = 4;
            Random rand = new Random();
            enginePower = rand.Next(100, 300)/10*10;
        }
        public Car(string model):this()
        {
            this.model = model;
        }
    }

    //..........//ТРАНСПОРТ + РАЗУМНОЕ СУЩЕСТВО//..........//
    public class Transformer : Vehicle, IIntelligentCreature
    {
        private string name;
        public string Name { get => name; }

        private int yearOfBirth;
        public int YearOfBirth { get => yearOfBirth; }

        
        public Transformer()
        {
            this.wheels = 16;
            enginePower = new Random().Next(1000000)/1000*1000 ;
        }
        public Transformer(string name,string model,int yearOfBirth):this()
        {
            enginePower = yearOfBirth * 1000;
            this.yearOfBirth = yearOfBirth;
            this.name = name;
            this.model = model;
        }
        public override string ToString()
        {
            string res = "Объект класса " + GetType().Name;
            if (model != null) res += "\nИмя: "+name+"; Модель: " + model;
            else res += "\n";
            res += " имеет " + Wheels + " колес(а)\nМощность его двигателя составляет " + EnginePower + " л.с.";
            return res;
        }
        public override bool PoweringEngine(Engine engine)
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine("\n" + ToString());
            bool res = engine.TryToPowering();
            Console.WriteLine(res);
            if (res) { Console.WriteLine("Получилось, Трансформер едет!!!\nНет... БЕЖИТ!"); }
            else { Console.WriteLine("Он слишком стар..."); }
            return res;
        }
    }

    public class Bike : Vehicle
    {
        public Bike()
        {
            this.wheels = 2;
            Random rand = new Random();
            enginePower = rand.Next(10, 50)/10 *10;
        }
        public Bike(string model) : this()
        {
            this.model = model;
        }
        public override bool PoweringEngine(Engine engine)
        {
            Console.WriteLine(GetType().Name);
            Console.WriteLine("\n" + ToString());
            bool res = engine.TryToPowering();
            Console.WriteLine(res);
            if (res) { Console.WriteLine("Получилось!!! Байк едет"); }
            else { Console.WriteLine("Он сломался. Пойду пешком"); }
            return res;
        }
    }
}
