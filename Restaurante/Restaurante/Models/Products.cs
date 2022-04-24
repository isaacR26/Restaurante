using System;
using System.Collections.Generic;
using System.Text;
using SQLite; //plugin SQLite-net-pcl

namespace Restaurante.Models
{
    public class Products
    {
        [PrimaryKey, AutoIncrement] public int IdProduct { get; set; }
        [MaxLength(50)] public string NameProduct { get; set; }
        public double PriceProduct { get; set; }
        public int QuantyProduct { get; set; }
        [MaxLength(250)] public string Description { get; set; }
        
    }
}
