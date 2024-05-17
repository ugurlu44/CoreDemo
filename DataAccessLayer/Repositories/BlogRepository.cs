using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    class BlogRepository : IBlogDal
    {
        Context c = new Context();
        public void AddBlog(Blog blog)
        {
            c.Add(blog);
            c.SaveChanges();
        }

        public void Delete(Blog t)
        {
            throw new NotImplementedException();
        }

        public void DeleteBlog(Blog blog)
        {
            c.Remove(blog);
            c.SaveChanges();
        }

        public Blog GetById(int id)
        {
            return c.Blogs.Find(id);
        }

        public List<Blog> GetListAll()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListAll(Expression<Func<Blog, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListWithCategory()
        {
            throw new NotImplementedException();
        }

        public List<Blog> GetListWithCategoryAndWriter()
        {
            return c.Blogs.ToList();
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            return c.Blogs.Where(x=>x.WriterID == id).ToList();
        }

        public void Insert(Blog t)
        {
            throw new NotImplementedException();
        }

        public List<Blog> ListAllBlog()
        {
            return c.Blogs.ToList();
        }

        public void Update(Blog t)
        {
            throw new NotImplementedException();
        }

        public void UpdateBlog(Blog blog)
        {
            c.Update(blog);
            c.SaveChanges();
        }
    }
}
