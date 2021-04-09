
using System.Collections.Generic;
using Blogger.Models;
using Blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesService _pservice;
        private readonly BlogsService _admservice;

        public ProfilesController(ProfilesService pservice, BlogsService admservice)
        {
            _pservice = pservice;
            _admservice = admservice;
        }

        [HttpGet("{id}")]
        public ActionResult<Profile> Get(string id)
        {
            try
            {
                return Ok(_pservice.GetProfileById(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpGet("{id}/blogs")]
        public ActionResult<IEnumerable<Blog>> GetBlogs(string id)
        {
            try
            {
                return Ok(_admservice.GetBlogsByProfileId(id));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}