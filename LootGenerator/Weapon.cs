using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGenerator
{
    public class Weapon : Item
    {
        private int damageM;
        public int DamageMin
        {
            set
            {
                if (value < 1 || value > 100)
                {
                    throw new Exception("Value must be set between 1 and 100");
                }
                this.damageM = value;
            }
            get { return this.damageM; }
        }
        private int damageMx;
        public int DamageMax
        {
            set
            {
                if (value < 10 || value > 100)
                {
                    throw new Exception("Value must be set between 10 and 100");
                }
                this.damageMx = value;
            }
            get { return this.damageMx; }
        }

        public Weapon(int damageMin,int damageMax,string name, int value) : base(name, value)
        {
            if(damageMax < damageMin)
            {
                
            DamageMax = damageMin;
            DamageMin = damageMin;
            }
            else
            {

                DamageMax = damageMax;
                DamageMin = damageMin;
            }
        }
        public override string ToString()
        {
            return  $"{ base.ToString()}\nDamageMin: {DamageMin}\tDamageMax: {DamageMax}\n " ;
           
        }
    }

}
