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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            this._contactDal = contactDal;
        }

        public void ContactAddBL(Contact contact)
        {
            this._contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            this._contactDal.Delete(contact);
        }

        public void ContactUpdate(Contact contact)
        {
            this._contactDal.Update(contact);
        }

        public Contact GetByID(int id)
        {
            return this._contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetList()
        {
            return this._contactDal.List();
        }
    }
}
