using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_лаба
{

    interface IForGeneric<T> where T : struct
    {
        public void Print();
        public Array<T> DeleteForNum(T num);
        public Array<Car> Add(Car n);
    }
}
