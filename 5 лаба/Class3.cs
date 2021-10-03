using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_лаба
{
    public interface ICarManagement
    {
        public bool PoweringEngine(Engine engine);
    }
    public class Engine
    {
        public bool TryToPowering()
        {
            Console.Write("Попытка завести Двигатель: ");
            var rand = new Random();
            bool res = rand.Next(2) == 1;
            return res;
        }
    }
}
