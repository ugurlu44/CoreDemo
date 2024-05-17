using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class GenericManager<T> where T : class
    {
        IGenericDal<T> _genericDal;

        public GenericManager(IGenericDal<T> genericDal)
        {
            _genericDal = genericDal;
        }

        
        public void GenericAdd(T t)
        {
            _genericDal.Insert(t);
        }

        public void GenericDelete(T t)
        {
            _genericDal.Delete(t);
        }

        public void CategoryUpdate(T t)
        {
            _genericDal.Update(t);
        }

        public T GetById(int id)
        {
            return _genericDal.GetById(id);
        }

        public List<T> GetList()
        {
            return _genericDal.GetListAll();
        }
    }
}
