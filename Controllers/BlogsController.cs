using System;
using System.Collections.Generic;
using Blogger.Models;
using Blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BlogsController : ControllerBase
    {
        private readonly BlogsService _service;
        private readonly CommentsService _Cservice;

        public BlogsController(BlogsService service, CommentsService Cservice)
        {
            _service = service;
            _Cservice = Cservice;
        }



        [HttpGet] //Get
        public ActionResult<IEnumerable<Blog>> Get()
        {
            try
            {
                return Ok(_service.Get());
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{blogsId}")] //Get By ID
        public ActionResult<Blog> GetById(string blogsId)
        {
            try
            {
                return Ok(_service.GetById(blogsId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpGet("{id}/comments")]   //GET COMMENTS BY BLOG ID
        public ActionResult<IEnumerable<Comment>> GetComments(int id)
        {
            try
            {
                return Ok(_Cservice.GetByBlogId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{blogsId}")] //EDIT
        public ActionResult<Blog> editBlogs(string blogId, Blog editBlogs)
        {
            try
            {
                editBlogs.blogId = blogId;
                return Ok(_service.Edit(editBlogs));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost] //Create
        public ActionResult<Blog> Create([FromBody] Blog newBlogs)
        {
            try
            {
                return Ok(_service.Create(newBlogs));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")] //Delort
        public ActionResult<string> DeleteBlogs(string id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}