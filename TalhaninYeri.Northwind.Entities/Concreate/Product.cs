using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TalhaninYeri.Core.Entities;

namespace TalhaninYeri.Northwind.Entities.Concreate
{
    public class Product : IEntity
    {
        [Required]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Ürün Adı Zorunludur.")]
        public string ProductName { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Bir fiyat giriniz.")]
        public decimal UnitPrice { get; set; }
        [Required(ErrorMessage = "Stokta kaç adet olduğunu giriniz.")]
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        [Required]
        public bool FirsatUrun { get; set; }
        public string Description { get; set; }

        public int SaleCount { get; set; }

        public DateTime Date { get; set; }
        public Product()
        {
            Date = DateTime.Now;
        }
    }
}
