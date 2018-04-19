using OnlineSinav.BLL.Abstract;
using OnlineSinav.DAL.Concrete.EntityFramework.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSinav.BLL.Concrete
{
    public class CategoryService : ICategoryService
    {
        EFCategoryDAL _categoryDAL;

        public CategoryService()
        {
            _categoryDAL = new EFCategoryDAL();
        }

        public void Add(Model.Category entity)
        {
            //if (string.IsNullOrEmpty(entity.Name))
            //{
            //    throw new Exception();
            //}

            _categoryDAL.Add(entity);
        }

        public void Update(Model.Category entity)
        {
            _categoryDAL.Update(entity);
        }

        public void Delete(Model.Category entity)
        {
            entity.IsActive = false;
            _categoryDAL.Update(entity);
        }

        public Model.Category GetByID(int id)
        {
            return _categoryDAL.Get(a => a.CategoryID == id && a.IsActive);
        }

        public ICollection<Model.Category> GetList()
        {
            return _categoryDAL.GetAll();
        }
    }
}
