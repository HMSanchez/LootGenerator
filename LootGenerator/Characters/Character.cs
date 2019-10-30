using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGenerator.Characters
{
    public abstract class Character
    {
        private Weapon equippedWeapon;
        public Weapon EquippedWeapon
        {
            get
            {
                return  this.equippedWeapon;
            }
            set
            {
                if(value == null)
                {
                    throw new Exception("null field");
                }
                this.equippedWeapon = value;
            }
        }
        private Armor equippedArmor;
        public Armor EquippedArmor
        {
            get
            {
                return this.equippedArmor;
            }
            set
            {
                if (value == null)
                {
                    throw new Exception("null field");
                }
                this.equippedArmor = value;
            }
        }
        private string name;
        public string Name
        {

            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid null string" );
                this.name = value;
            }
            get { return this.name; }
        }
        //public string Name { get; set; }

        
        private int strBase;
        public int STR
        {
            set
            {
                if (value < 3 || value > 33)
                {
                    throw new Exception("Value must be set between 3 and 33");
                }
                    this.strBase = value;
            }
            get { return this.strBase; }
        }

        protected int intBase;
        public int INT
        {
            set
            {
                if (value < 3 || value > 33)
                {
                    throw new Exception("Value must be set between 3 and 33");
                }
                this.intBase = value;
            }
            get { return this.intBase; }
        }
        protected int dexBase;
        public int DEX
        {
            set
            {
                if (value < 3 || value > 33)
                {
                    throw new Exception("Value must be set between 3 and 33");
                }
                this.dexBase = value;
            }
            get { return this.dexBase; }
        }

        protected int strMod { get; set; } = 0;
        protected int intMod { get; set; } = 0;
        protected int dexMod { get; set; } = 0;
        //
        public int strength;
        public int Strength
        {
            get
            {
                return this.STR + this.strMod;
            }
        }
        public int intelligence;
        public int Intelligence
        {
            get
            {
                return this.INT + this.intMod;
            }
        }

        public int dexterity;
        public int Dexterity
        {
            get
            {
                return this.DEX + this.dexMod;
            }
        }
        //
        private int bHp;
        public int baseHp
        {
            get
            {
                return this.bHp;
            }
            set
            {
                if (value < 0  )
                {
                    throw new Exception("Base Hp can't be less than 0");
                }
                this.bHp = value;
            }
        }
        private  int cHP;
        public int currentHp
        {
            get
            {
                return this.cHP;
            }
            set
            {
                if (value > this.baseHp || value < 0 )
                {
                    throw new Exception("Current Hp can't be less than 0 or greater than Base Hp");
                }
                this.cHP = value;
            }
        }


        public abstract int Attack();
        public abstract int TakeDamage(int damage);

        public Character(string name,Weapon ew, Armor ea, int strB,int intB, int dexB)
        {
            this.Name = name;
            this.equippedWeapon = ew;
            this.equippedArmor = ea;
            this.STR = strB;
            this.intBase = intB;
            this.dexBase = dexB;
            
            //Strength = (this.STR + this.strMod);
            //this.Intelligence = intBase + intMod;
            int temp = this.dexBase + this.dexMod;
            //this.Dexterity = temp + this.equippedArmor.AgilityModifier;
            this.baseHp = this.Strength * 10;
            this.currentHp = this.baseHp;


            if (currentHp > baseHp)
            {
                currentHp = baseHp;
            }   
            if(currentHp < 0)
            {
                currentHp = 0;
            }

        }

        public override string ToString()
        {
            return $"Name: {Name}\tBase Str: {STR}\tBase int: {intBase}\tBase Dex: {dexBase}\nStrength Mod: {strMod}\tIntelligence Mod: {intMod}" +
                $"\tDexterity Mod: {dexMod}\nStrength: {Strength}\tIntelligence: {Intelligence}\tDexterity: {Dexterity}" +
                $"\nBase HP: {baseHp}\tCurrent HP: {currentHp}\nEquipped Weapon: {equippedWeapon}\nEquipped Armor: {equippedArmor}\tEquipped Armor: {equippedArmor}";
        }

    }
}
