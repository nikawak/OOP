using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лаба
{
    //..........//КЛАССИЧЕСКИЙ ИНТЕРФЕЙС Icloneable//..........//
    interface Icloneable
    {
        bool DoClone();
    }
    abstract class BaseClone
    {
        public abstract bool DoClone(bool res);
    }
    class User:BaseClone,Icloneable
    {
        public bool DoClone()
        {
            Console.WriteLine("Клонирование прошло успешно!");
            return true;
        }
        
        
        public override bool DoClone(bool res)
        {
            if (res)
                Console.WriteLine("Почти одинаковые методы\nКлонировние так же прошло успешно");
            else Console.WriteLine("Почти одинаковые методы\nКлонировние прошло провально!");
            return res;
        }

    }
}
