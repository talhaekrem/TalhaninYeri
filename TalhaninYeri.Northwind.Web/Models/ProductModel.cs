using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.Web.Models
{
    public class ProductModel
    {
        public List<Product> Products { get; internal set; }
        public List<Category> Categories { get; internal set; }

        public string filter { get; set; }
        public int PageCount { get; internal set; }
        public int PageSize { get; internal set; }
        public int CurrentPage { get; internal set; }
        public int CurrentCategory { get; internal set; }
        public int CurrentCategoryPaging { get; internal set; }

        public int Pcount { get; set; }
    }
}
