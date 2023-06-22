using BusinessLayer.Abstact;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this._writerDal = writerDal;
        }
        public Writer GetByID(int id)
        {
            return this._writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> GetList()
        {
            return this._writerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
            this._writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            this._writerDal.Delete(writer);
        }   

        public void WriterUpdate(Writer writer)
        {
            this._writerDal.Update(writer);
        }
    }
}
