using LootGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LootGenerator.Characters;

namespace LootGenerator
{
    public class PoisonDart : Item, IConsumable
    {
        private int healthLoss;
        public int HealthLoss
        {
            get
            {
                return this.healthLoss;
            }
            set
            {
                if (value < 0)
                {
                    throw new Exception("Health Loss can't be less than 0 or null");
                }
                this.healthLoss = value;
            }
        }
        public PoisonDart(int healthloss,string name, int value) : base(name, value)
        {
            HealthLoss = healthloss;
        }
        public override string ToString()
        {
            return $"{ base.ToString()}\nDescription: {GetDescription()}\n  ";
        }
        public string GetDescription()
        {
            return $"Poison Dart poisons target which causes current HP loss over time\nTotal Health Loss: {HealthLoss} ";
        }

        public void Use(Character c)
        {
            c.currentHp -= HealthLoss * (int)1.5;
            if(c.currentHp < 0)
            {
                c.currentHp = 0;
            }
        }


    }

}
