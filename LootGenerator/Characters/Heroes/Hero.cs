using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGenerator.Characters.Heroes
{
    public class Hero : Character
    {

   
        public override int Attack()
        {
            int dmg = EquippedWeapon.DamageMax;

            return dmg;
        }

        public override int TakeDamage(int damage)
        {
            if (currentHp == 0)
            {
                return 0;
            }
            damage = damage - EquippedArmor.DamageReduction + 2;
   
            currentHp -= damage;
            if (damage < 0)
            {
                return 0;
            }
            return damage;
        }

        public Hero(string name, Weapon w, Armor a,int strBa, int intBa,int dexBa, int strMo,int intMo, int dexMo) : base(name,w,a,strBa,intBa,dexBa)
        {
            strMod = strMo;
            intMod = intMo;
            dexMod = dexMo;
            //equippedArmor = a;
            //equippedWeapon = w;
            //Name = name;
            //baseHp = Strength * 15;
            //currentHp = baseHp;
            
        }
        public override string ToString()
        {
            return $" Name: {Name}\tBaseHP: {baseHp}\tCurrentHp: {currentHp}\nStrength: {Strength}\tIntelligence: {Intelligence}\tDexterity: {Dexterity}\nBase Str: {STR}\tBase int: {INT}\tBase Dex: {DEX}\nStrength Mod: {strMod}\tIntelligence Mod: {intMod}" +
                $"\tDexterity Mod: {dexMod}\nWeapon: {EquippedWeapon}\nArmor: {EquippedArmor}" +
                $"Heroes Have +2 Damage Reduction\n";
        }
    }
}
