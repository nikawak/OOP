using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Brawler
    {
        public Brawler()
        {

        }
        public bool HasError { get; private set; }
        public string Name { get; private set; }
        public double Damage { get; private set; }
        public double HealDamage { get; private set; }
        public double HP { get; private set; } 
        public double MaxHP { get; private set; }
        private bool Alive { get; set; } = true;
        public string Team { get; private set; }
        private Brawler target;
        public Brawler Target {
            get { return target; }
            set 
            { 
                if (value != null && value.IsAlive())
                    target = value;
            }
        }
        public bool IsAlive()
        {
            return Alive;
        }
        public bool IsValid(string name, double damage, double hp, string team)
        {
            bool res = false;
            if (!string.IsNullOrEmpty(name))
                if (damage != 0)
                    if (hp != 0)
                    {
                        res = true;
                        HasError = false;
                    }
                    else
                    {
                        HasError = true;
                    }

            return res;
        }
        public Brawler(string team, string name, double hp, double damage, double healDamage = 0)
        {
            if (IsValid(name, damage, hp, team))
            {
                Name = name;
                Damage = damage;
                HealDamage = healDamage;
                MaxHP = hp;
                HP = hp;
                Team = team;
            }
        }
        public void State()
        {
            this.ToString();
        }
        public double Attack()
        {
            if (Target.Team != this.Team)
                return Damage;
            else return 0;
        }
        public double Heal()
        {
            if (Target.Team == this.Team&& HealDamage != 0)
                return Damage;
            else if(Target.Team == this.Team&&HealDamage == 0)
            {
                return -1;
            }
            else return 0;
        }
        public string GetDamage(double num)
        {
            string res = "";
            if (IsAlive())
            {
                if (num != 0)
                {
                    if (HP > num)
                    {
                        HP -= num;
                        res += $"Боец {this.Name} получил {num} единицы урона и остался жив";
                    }
                    else
                    {
                        HP -= num;
                        Alive = false;
                        res += $"Боец {this.Name} получил {num} единицы урона и умирает";
                    }
                }
                else
                {
                    res += "Невозможно атаковать союзника!";
                }
            }
            return res;
        }
        public string GetHeal(double num)
        {

            string res = "";
            if (num == -1)
            {
                res += "Данный боец не может лечить";
            }
            else if (num != 0)
            {
                if (HP < MaxHP)
                {
                    HP += num;
                    if (HP < MaxHP)
                        res += $"Боец {this.Name} вылечил {num} единиц здоровья";
                    if (HP >= MaxHP)
                        res += $"Боец {this.Name} вылечил {MaxHP - HP - num} единиц здоровья. Его здоровье на максимуме";
                }
                else
                {
                    res += $"Здоровье бойца {this.Name} на максимуме";
                }
            }
            
            else
            {
                res += "Невозможно вылечить противника";
            }

            return res;
        }
        
    }
    
}
