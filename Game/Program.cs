using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new();

            Brawler carry = new("Красная команда","carry",3.9, 2.2);
            Brawler support = new("Красная команда","support", 3.4, 1.2, 1.2);
            Brawler tank = new("Синяя команда", "tank", 7.2, 1.3);

            //Console.WriteLine(carry.HasError);
            //Console.WriteLine(support.HasError);
            //Console.WriteLine(tank.HasError);


            tank.Target = support;
            game.Action(tank.Attack);

            carry.Target = support; 
            game.Action(carry.Heal);

            Console.WriteLine(Math.Round(support.HP,1));





            

        }
    }
}
