using LootGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LootGenerator.Characters;

namespace LootGenerator
{
    public class Grenade : Item, IConsumable
    {
        private int grenadeDamage;
        public int GrenadeDamage
        {
            get
            {
                return this.grenadeDamage;
            }
            set
            {
                if(value < 0)
                {
                    this.grenadeDamage = 0;
                    value = 0;
                }
                this.grenadeDamage = value;
            }
        }

        public Grenade(int damage,string name, int value) : base(name, value)
        {
            GrenadeDamage = damage;
        }
        public override string ToString()
        {
            return $"Grenade Type: { base.ToString()}\nDescription: {GetDescription()}\n  ";
        }
        public string GetDescription()
        {
            return $"Grenade takes off limbs and damages HP\nGrenade Damage: {GrenadeDamage}";
        }

        public void Use(Character c)
        {
            
            c.currentHp -= GrenadeDamage;
            if(c.currentHp < 0)
            {
                c.currentHp = 0;
            }
        }
    }
}
