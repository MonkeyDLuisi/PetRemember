using System;
using System.Collections.Generic;
using System.Text;

namespace PetRemember.Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Class { get; set; }
        public string SubClass { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Animal { get; set; }
        public string Breed { get; set; }
        public int MinWeight { get; set; }
        public int MaxWeight { get; set; }
        public int MinMonths { get; set; }
        public int MaxMonths { get; set; }
    }
}
