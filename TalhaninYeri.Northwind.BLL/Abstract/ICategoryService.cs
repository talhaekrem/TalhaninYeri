using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetAll();

        string GetCategoryNameById(int categoryId);

        void Add(Category category);
        void Update(Category category);
        void Delete(int categoryId);
        Category GetCategory(int categoryId);
    }
}
