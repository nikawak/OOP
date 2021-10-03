using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_лаба
{
    interface IIntelligentCreature
    {
        
    }
    interface ICanDrive : IIntelligentCreature
    {
        void Driving(ICarManagement DriveYourCar);
    }

    public class Human : ICanDrive
    {

        public void Driving(ICarManagement DriveYourCar)
        {
            DriveYourCar.PoweringEngine(new Engine()); 
        }
    }


}
