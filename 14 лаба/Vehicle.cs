using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace _14_лаба
{
    [Serializable]
    public abstract class Vehicle
    {
        public string Model { get; protected set; }
        public byte Wheels { get; protected set; }
        public int EnginePower { get; set; }
        

        public override string ToString()
        {
            string res = "Объект класса " + GetType().Name;
            if (Model != null) res += "\nМодель: " + Model;
            else res += "\n";
            res += " имеет " + Wheels + " колес(а)\nМощность его двигателя составляет " + EnginePower + " л.с.";
            return res;
        }
        public override bool Equals(object obj)
        {
            //динамическая идентификация типов
            if (obj is Vehicle && obj != null)
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




    [Serializable]
    public class Car : Vehicle
    {

        [field: NonSerialized] // поля нет в файле (значит изначальное значение не имеет значение)
        public bool IsSerializableField { get; protected set; } = false;


        [OnDeserialized]
        private void Beforerialization(StreamingContext context)
        {
            Random rand = new Random();
            EnginePower = rand.Next(100, 300) / 10 * 10;
        } 

        public Car()
        {
            Wheels = 4;
            Random rand = new Random();
            EnginePower = rand.Next(100, 300) / 10 * 10;
        }
        public Car(string model) : this()
        {
            IsSerializableField = true;
            Model = model;
        }
        public Car(string model, byte wheels):this(model)
        {
            Wheels = wheels;
        }
    }

    [DataContract]
    public class Student
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int Age { get; set; }
        [DataMember]
        public double AvgMark { get; set; }
        public Student(string name, int age, double avgMark)
        {
            Name = name;
            Age = age;
            AvgMark = avgMark;
        }
       
        public Student() { }
        public override string ToString()
        {
            return $"Student: {Name}\nAge: {Age}\nAverage Mark: {AvgMark}";
        }
    }
}
