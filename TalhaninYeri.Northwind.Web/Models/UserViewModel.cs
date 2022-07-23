using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;
namespace TalhaninYeri.Northwind.Web.Models
{
    public class UserViewModel
    {
        public List<AspNetUsers> User { get; set; }
    }
}
