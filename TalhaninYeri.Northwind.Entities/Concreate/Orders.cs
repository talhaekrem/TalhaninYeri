using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TalhaninYeri.Core.Entities;

namespace TalhaninYeri.Northwind.Entities.Concreate
{
    public class Orders : IEntity
    {
        [Required]
        [Key]
        public int OrderID { get; set; }

        [Required(ErrorMessage = "Ad zorunludur.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Soyad zorunludur.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "E-posta alanı zorunludur.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Şehir zorunludur.")]
        public string City { get; set; }

        [Required(ErrorMessage = "Adres zorunludur.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Telefon numarası zorunludur.")]
        public string Phone { get; set; }

        public DateTime OrderDate { get; set; }

        public DateTime? DeliveredTime { get; set; }

        [Required]
        public bool IsDelivered { get; set; }

        public decimal OrderTotal { get; set; }
    }
}
