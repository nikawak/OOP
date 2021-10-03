using System;

namespace _5_лаба
{
    class Program
    {
        static void Main(string[] args)
        {
            ICanDrive person = new Human();
            ICarManagement[] vehicle = {new Car(), new Transformer(), new Bike() };

            foreach(ICarManagement item in vehicle)
            {
                person.Driving(item);
                Console.WriteLine("\n"+new String('-', 40));
            }

            Icloneable user1 = new User();
            user1.DoClone();
            BaseClone user2 = new User();
            user2.DoClone(false);


            Vehicle a = new Car();
            Console.Write("\nCar == Car: ");
            Console.Write(a.Equals(new Car()));
            Console.Write("\nCar == Bike: ");
            Console.WriteLine(a.Equals(new Bike()));
        }
    }
}
