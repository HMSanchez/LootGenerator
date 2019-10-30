using LootGenerator.Characters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LootGenerator.Interfaces
{
   public interface IConsumable
    {
        void Use(Character c);
        string GetDescription();
        //Describes effect of consumable on enemy
    }
}
