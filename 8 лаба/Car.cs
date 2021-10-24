using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_лаба
{
    public struct Car
    {
        private string model;
        public string Model
        {
            get { return model; }
        }
        private byte wheels;
        public byte Wheels
        {
            get { return wheels; }
        }
        private int enginePower;
        public int EnginePower { get { return enginePower; } }

        public Car(string model)
        {
            this.wheels = 4;
            Random rand = new Random();
            enginePower = rand.Next(100, 300) / 10 * 10;
            this.model = model;
        }

        public override string ToString()
        {
            string res = "Объект класса " + GetType().Name;
            if (model != null) res += "\nМодель: " + model;
            else res += "\n";
            res += " имеет " + Wheels + " колес(а)\nМощность его двигателя составляет " + EnginePower + " л.с.";
            return res;
        }
    }
}
