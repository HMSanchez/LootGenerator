using LootGenerator.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LootGenerator.Characters;

namespace LootGenerator
{
    public class Item 
    {


        private string name;
        public string Name
        {
    
            set
            {
                if (string.IsNullOrEmpty(value)) throw new ArgumentException("Invalid null string");
                this.name = value;
            }
            get { return this.name; }
        }


        //public string Name { get; set; }
        private int value;
        public int Value
        {
            get
            {
                return this.value;
            }
            set
            {
                if (value <0)
                {
                    throw new Exception("value is smaller than 0");
                }
                this.value = value;
            }
        }

        public Item(string name, int value)
        {
            Name = name;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Name}\tValue: {Value}\n";
        }


    }
}
