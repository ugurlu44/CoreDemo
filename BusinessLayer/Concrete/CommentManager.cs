using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CommentManager : IGenericService<Comment>
    {
        ICommentDal _commentdal;
        public CommentManager(ICommentDal commentdal)
        {
            _commentdal = commentdal;
        }

        public void Delete(Comment t)
        {
            throw new NotImplementedException();
        }

        public object GetList(object blogId)
        {
            throw new NotImplementedException();
        }

        public Comment TGetById(int id)
        {
            return _commentdal.GetById(id);
        }

        public List<Comment> GetList(int id)
        {
            return _commentdal.GetListAll(x=>x.BlogID==id);
        }

        public List<Comment> GetList()
        {
            throw new NotImplementedException();
        }

        public void Insert(Comment t)
        {
            _commentdal.Insert(t);
        }

        public void Update(Comment t)
        {
            throw new NotImplementedException();
        }
    }
}
