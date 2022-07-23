using System;
using System.Collections.Generic;
using System.Text;
using TalhaninYeri.Northwind.BLL.Abstract;
using TalhaninYeri.Northwind.DAL.Abstract;
using TalhaninYeri.Northwind.Entities.Concreate;

namespace TalhaninYeri.Northwind.BLL.Concreate
{
    public class CategoryManager : ICategoryService
    {
        private ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void Add(Category category)
        {
            _categoryDal.Add(category);
        }

        public void Delete(int categoryId)
        {
            _categoryDal.Delete(new Category { CategoryId = categoryId });
        }

        public List<Category> GetAll()
        {
            return _categoryDal.GetList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId);
        }

        public string GetCategoryNameById(int categoryId)
        {
            return _categoryDal.Get(c => c.CategoryId == categoryId).CategoryName;
        }

        public void Update(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
