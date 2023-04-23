using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager
    {
        GenericRepository<Category> repository = new GenericRepository<Category>();

        public List<Category> GetAllBL()
        {
            return this.repository.List();
        }

        public void CategoryAddBL(Category p)
        {
            if (p.CategryName == "" || p.CategryName.Length <= 3 || 
                p.CategryName.Length >= 50 || p.CategoryDescription == "")
            {
                // hata mesajı
            }
            else
            {
                this.repository.Insert(p);
            }
        }

    }
}
