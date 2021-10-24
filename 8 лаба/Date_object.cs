using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_лаба
{
    partial class Array<T>
    {
        //............//КЛАСС ДАТА//............//
        public class Date
        {
            private static DateTime myTime;
            public DateTime MyTime
            {
                get { return myTime; }
            }
            public Date()
            {
                myTime = DateTime.Now;
            }
            public override string ToString()
            {
                return $"Дата создания объекта:\n{myTime.Hour} часов {myTime.Minute} минут";
            }
        }
        //............//ОБЪЕКТ OWNER//............//
        private static readonly Owner owner = new Owner{ID = 324680432, name ="nikawak"};
        public static Owner Owner
        {
            get { return owner; }
        }
        

    }
    //............//КЛАСС OWNER//............//
    public class Owner
    {
        public long ID;
        public string name;
    }

}
