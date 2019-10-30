using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGenerator.Characters.Monsters
{
    public class Monster : Character
    {

        //public Weapon EquippedWeapon { get; set; }
        //public Armor EquippedArmor { get; set; }
        public override int Attack()
        {
            int dmg = EquippedWeapon.DamageMax + 5;

            return dmg;
        }

        public override int TakeDamage(int damage)
        {
            if (currentHp == 0)
            {
                return 0;
            }
            damage = damage + 3;

            currentHp -= damage;
            if (damage < 0)
            {
                return 0;
            }
            return damage;
        }

        public Monster(string name, Weapon w, Armor a,int strBa, int intBa, int dexBa, int strMo, int intMo, int dexMo) : base(name, w, a, strBa, intBa, dexBa)
        {
            strMod = strMo;
            intMod = intMo;
            dexMod = dexMo;
        }
        public override string ToString()
        {
            return $" Name: {Name}\tBaseHP: {baseHp}\tCurrentHp: {currentHp}\nStrength: {Strength}\tIntelligence: {Intelligence}\tDexterity: {Dexterity}\nBase Str: {STR}\tBase int: {INT}\tBase Dex: {DEX}\nStrength Mod: {strMod}\tIntelligence Mod: {intMod}" +
                $"\tDexterity Mod: {dexMod}\nWeapon: {EquippedWeapon}\nArmor: {EquippedArmor}" +
                $"Monsters Take 3 extra damage from an attack but deal 5 more than Heroes\n";
        }
    }
}
