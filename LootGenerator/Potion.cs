using LootGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LootGenerator.Characters;

namespace LootGenerator
{
    public class Potion : Item, IConsumable
    {


        private int healAmount;
        public int HealAmount
        {
            get
            {
                return this.healAmount;
            }
            set
            {
                if (value < 10 || value > 100)
                {
                    throw new Exception("Value can't be below 10 or above 100");
                }
                this.healAmount= value;
            }
        }

        public Potion(int healAmount, string name,int value) : base(name,value)
        {
            HealAmount = healAmount;

        }

        public override string ToString()
        {
            return  $"{ base.ToString()}\n{GetDescription()}  " ;
        }

        public void Use(Character c)
        {
            if (c.currentHp +HealAmount < c.baseHp)
            {
                c.currentHp += HealAmount;
            }
            else
            {
                HealAmount = c.baseHp;
                c.currentHp = HealAmount;

            }
        }

        public string GetDescription()
        {
            string f = $"Potion gives target and increase in current HP\nHealAmount: {HealAmount}";
            return f;
        }
    }
}
