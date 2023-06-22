using BusinessLayer.Abstact;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            this._aboutDal = aboutDal;
        }

        public void AboutAdd(About about)
        {
            this._aboutDal.Insert(about);
        }

        public void AboutDelete(About about)
        {
            this._aboutDal.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            this._aboutDal.Update(about);
        }

        public About GetByID(int id)
        {
            return this._aboutDal.Get(x => x.AboutID == id);
        }

        public List<About> GetList()
        {
            return this._aboutDal.List();
        }
    }
}
