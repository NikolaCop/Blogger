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
        private readonly CommentsService _service;

        public CommentssController(CommentsService service)
        {
            _service = service;
        }


        [HttpGet] //Get
        public ActionResult<IEnumerable<Comment>> Get()
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
        public ActionResult<Comment> GetById(string commentssId)
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
        public ActionResult<Comment> editComments(string commentId, Comment editComments)
        {
            try
            {
                editComments.CommentId = commentId;
                return Ok(_service.Edit(editComments));

            }
            catch (System.Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        [HttpPost] //Create
        public ActionResult<Comment> Create([FromBody] Comment newCommentss)
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
        public ActionResult<string> DeleteComments(string id)
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