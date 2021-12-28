using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_лаба
{
    partial class Observation
    {
        public static int ghoul { get; set; } = 1000;
        public static void Ghoul(object num)
        {
            Console.WriteLine("╔╩╠═╬╧╨╓╫--/!!  "+(ghoul-7).ToString()+ @"  !!\--╫╓╨╧╬═╠╩╦");
            ghoul -= 7;
        }
    }
}
