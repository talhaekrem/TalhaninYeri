using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Core.Entities;

namespace TalhaninYeri.Northwind.Entities.Concreate
{
    public class AspNetUsers : IEntity
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
    }
}
