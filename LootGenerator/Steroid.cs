using LootGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LootGenerator.Characters;

namespace LootGenerator
{
    public class Steroid : Item, IConsumable
    {
        private int strengthBoost;
        public int StrengthBoost
        {
            get
            {
                return this.strengthBoost;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Strength Boost can't be less than 0");
                }
                this.strengthBoost = value;
            }
        }

        public Steroid(int boostAmt,string name, int value) : base(name, value)
        {
            StrengthBoost = boostAmt;
        }
        public override string ToString()
        {
            return $"{ base.ToString()}\nDescription: {GetDescription()}\n  ";
        }
        public string GetDescription()
        {
            return $"Steroids give target an increase in base HP\nSteroid HP Boost: {StrengthBoost}";
        }

        public void Use(Character c)
        {
         
           
            c.baseHp += StrengthBoost;
           
        }
    }
}
