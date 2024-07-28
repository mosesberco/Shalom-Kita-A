using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace final_project
{
    internal class Itemstore
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        public Itemstore(string name, decimal price, string imagePath)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
        public override string ToString()
        {
            return $"{Name}: ${Price}";
        }
    }
}

