﻿namespace CosmeticApp5.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Price { get; set; } = "";
        public string Address { get; set; } = "";
        public DateTime ModifiedDate { get; set; }
    }
}
