using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public delegate double OperationHP(); //обрабочик

    class Game
    { 
        private event OperationHP AddHP;
        private event OperationHP SubHP;

        public void Action(OperationHP deleg)
        {
            object obj = deleg.Target;
            Brawler brawler = obj as Brawler;

            AddHP = deleg;
            SubHP = deleg;
            
            if (brawler.Team == brawler.Target.Team)
            {
                if(deleg() != 0 || brawler.HealDamage ==0) //чтоб не атаковать союзников
                    Console.WriteLine(brawler.Target.GetHeal(AddHP()));
                else
                    Console.WriteLine(brawler.Target.GetDamage(SubHP()));
            }
            else if (brawler.Team != brawler.Target.Team)
            {
                if (deleg() != 0) //чтоб не лечить противников
                    Console.WriteLine(brawler.Target.GetDamage(SubHP()));
                else
                    Console.WriteLine(brawler.Target.GetHeal(AddHP()));
            }
        }
    }
}
