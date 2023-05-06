using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }

        public void CategoryAddBL(Category category)
        {
            this._categoryDal.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            this._categoryDal.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            this._categoryDal.Update(category);
        }

        public Category GetByID(int id)
        {
            return this._categoryDal.Get(x => x.CategoryID == id); 
        }

        public List<Category> GetList()
        {
            return this._categoryDal.List();
        }

        

        //GenericRepository<Category> repository = new GenericRepository<Category>();

        //public List<Category> GetAllBL()
        //{
        //    return this.repository.List();
        //}

        //public void CategoryAddBL(Category p)
        //{
        //    this.repository.Insert(p);
        //    /*
        //    if (p.CategryName == "" || p.CategryName.Length <= 3 || 
        //        p.CategryName.Length >= 50 || p.CategoryDescription == "")
        //    {
        //        // hata mesajı
        //    }
        //    else
        //    {
        //        this.repository.Insert(p);
        //    }
        //    */
        //}
    }
}
