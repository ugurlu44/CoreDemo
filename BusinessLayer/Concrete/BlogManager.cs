﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class BlogManager : IBlogService
    {
        IBlogDal _blogDal;

        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public void Insert(Blog t)
        {
            _blogDal.Insert(t);
        }

        public void Update(Blog t)
        {
            _blogDal.Update(t);
        }

        public void Delete(Blog t)
        {
            _blogDal.Delete(t);
        }

        public List<Blog> GetBlogListWithCategory()
        {
            return _blogDal.GetListWithCategory().Where(x=>x.BlogStatus==true).ToList();
        }

        public List<Blog> GetListWithCategoryByWriterBm(int id)
        {
            return _blogDal.GetListWithCategoryByWriter(id);
        }

        public Blog TGetById(int id)
        {
            return _blogDal.GetById(id);
        }

        public List<Blog> GetBlogByID(int id)
        {
            return _blogDal.GetListAll(x=>x.BlogID==id).ToList();
        }

        public List<Blog> GetList()
        {
            return _blogDal.GetListAll();
        }

        public List<Blog> GetLast3Blog()
        {
            return _blogDal.GetListAll().OrderByDescending(x=>x.BlogCreateDate).Take(3).ToList();
        }

        public List<Blog> GetBlogListByWriter(int id)
        {
            return _blogDal.GetListAll(x => x.WriterID == id);
        }

        public List<Blog> GetListWithCategoryAndWriter()
        {
            return _blogDal.GetListWithCategoryAndWriter();
        }
    }
}
