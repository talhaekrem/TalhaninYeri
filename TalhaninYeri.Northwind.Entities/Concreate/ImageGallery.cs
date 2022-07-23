using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using TalhaninYeri.Core.Entities;

namespace TalhaninYeri.Northwind.Entities.Concreate
{
    public class ImageGallery : IEntity
    {
        [Key]
        public int ImageId { get; set; }
        public string Path { get; set; }
        public int ProductId { get; set; }
    }
}
