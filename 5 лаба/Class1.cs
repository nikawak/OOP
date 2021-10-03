using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_лаба
{
    public abstract class Vehicle : ICarManagement
    {
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
            return "Объект класса " + GetType().Name + " имеет " + Wheels + " колес(а)\nМощность его двигателя составляет " + EnginePower + " л.с.";
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
    }


    public class Transformer : Vehicle, IIntelligentCreature
    {
        
        public Transformer()
        {
            this.wheels = 16;
            Random rand = new Random();
            enginePower = rand.Next(1000, 10000) / 100*100 ;
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
