using System;
using System.Collections.Generic;
using Blogger.Models;
using Blogger.Repositories;

namespace Blogger.Services
{
    public class BlogsService
    {
        private readonly BlogsRepository _repo;

        public BlogsService(BlogsRepository repo)
        {
            _repo = repo;
        }
        //GET
        public IEnumerable<Blog> Get()
        {
            return _repo.Get();
        }

        //GET
        internal Blog GetById(string id)
        {
            Blog blogs = _repo.Get(id);
            if (blogs == null)
            {
                throw new Exception("invalid id");
            }
            return blogs;
        }


        //CREATE/POST
        internal Blog Create(Blog newBlogs)
        {
            return _repo.Create(newBlogs);
        }

        //EDIT/PUT
        internal Blog Edit(Blog editBlogs)
        {
            Blog original = GetById(editBlogs.blogId);

            // original.Make = editBlogs.Make != null ? editBlogs.Make : original.Make;
            // original.Model = editBlogs.Model != null ? editBlogs.Model : original.Model;
            // original.Year = editBlogs.Year != null ? editBlogs.Year : original.Year;

            return _repo.Edit(original);
        }

        internal object GetBlogsByProfileId(string id)
        {
            throw new NotImplementedException();
        }

        //DELORT
        internal Blog Delete(string id)
        {
            Blog original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}