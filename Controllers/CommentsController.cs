using System.Collections.Generic;
using Blogger.Models;
using Blogger.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CommentssController : ControllerBase
    {
        private readonly CommentssService _service;

        public CommentssController(CommentssService service)
        {
            _service = service;
        }


        [HttpGet] //Get
        public ActionResult<IEnumerable<Comments>> Get()
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

        [HttpGet("{commentssId}")] //Get By ID
        public ActionResult<Comments> GetById(string commentssId)
        {
            try
            {
                return Ok(_service.GetById(commentssId));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpPut("{commentssId}")] //EDIT
        public ActionResult<Comments> editCommentss(string commentsId, Comments editCommentss)
        {
            try
            {
                editCommentss.commentsId = commentsId;
                return Ok(_service.Edit(editCommentss));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost] //Create
        public ActionResult<Comments> Create([FromBody] Comments newCommentss)
        {
            try
            {
                return Ok(_service.Create(newCommentss));
            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }

        [HttpDelete("{id}")] //Delort
        public ActionResult<string> DeleteCommentss(string id)
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