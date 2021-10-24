using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_лаба
{
    public enum MyState : byte
    {
        Annoyed,
        Chill,
        Happy,
        Tired,
        Sad,
        DeadInside
    }
    struct Nadeya
    {
        public bool GoodDay;
        public MyState State;

        public override string ToString()
        {
            string res;
            if (GoodDay) res = "Today is Good Day I'm ";
            else res = "Today is Bad Day I'm ";
            res += State;
            return res;
        }
    }

    
}



