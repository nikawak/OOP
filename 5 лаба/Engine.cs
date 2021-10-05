using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_лаба
{
    //..........//У ТРАНСПОРТА ЕСТЬ ЗАПУСК ДВИГАТЕЛЯ//..........//
    public interface ICarManagement
    { 
        public bool PoweringEngine(Engine engine);
    }
    public class Engine
    {
        private bool Try;
        public bool TryToPowering()
        { 
            Console.Write("Попытка завести Двигатель: ");
            var rand = new Random();
            bool res = rand.Next(2) == 1;
            Try = res;
            return res;
        }
    }
}
