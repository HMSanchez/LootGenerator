using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGenerator
{
    public class Armor : Item
    {
        private int ArmorR;
        public int ArmorRating
        {
            set
            {
                if (value < 8 || value > 17)
                {
                    throw new Exception("Value must be set between 10 and 100");
                }
                this.ArmorR = value;
            }
            get { return this.ArmorR; }
        }
        private int DamageReduc;
        public int DamageReduction
        {
            set
            {
                if (value < 0 || value > 10)
                {
                    throw new Exception("Value must be set between 10 and 100");
                }
                this.DamageReduc = value;
            }
            get { return this.DamageReduc; }
        }
        private int AgilityMod;
        public int AgilityModifier
        {
            set
            {
                if (value < -6 || value > 0)
                {
                    throw new Exception("Value must be set between 10 and 100");
                }
                this.AgilityMod = value;
            }
            get { return this.AgilityMod; }
        }

        public Armor(int armorRating,int damageReduction,int agilityModifier,string name, int value) : base(name, value)
        {
            ArmorRating = armorRating;
            DamageReduction = damageReduction;
            AgilityModifier = agilityModifier;
        }

        public override string ToString()
        {
            return $"{ base.ToString()}\nArmorRating: {ArmorRating}\nDamageReduction: {DamageReduction}\nAgilityModifier: {AgilityModifier}\n ";
            
        }

    }

}
