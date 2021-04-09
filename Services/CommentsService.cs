using System;
using System.Collections.Generic;
using Blogger.Models;
using Blogger.Repositories;

namespace Blogger.Services
{
    public class CommentsService
    {
        private readonly CommentsRepository _repo;

        public CommentsService(CommentsRepository repo)
        {
            _repo = repo;
        }
        //GET
        public IEnumerable<Comment> Get()
        {
            return _repo.Get();
        }

        //GET
        internal Comment GetById(string id)
        {
            Comment comments = _repo.Get(id);
            if (comments == null)
            {
                throw new Exception("invalid id");
            }
            return comments;
        }

        internal IEnumerable<Comment> GetByBlogId(int id)
        {
            return _repo.GetByBlogId(id);
        }


        //CREATE/POST
        internal Comment Create(Comment newComments)
        {
            return _repo.Create(newComments);
        }

        //EDIT/PUT
        internal Comment Edit(Comment editComments)
        {
            Comment original = GetById(editComments.CommentId);

            // original.Name = editComments.Name != null ? editComments.Name : original.Name;
            // original.CastleId = editComments.CastleId != null ? editComments.CastleId : original.CastleId;

            return _repo.Edit(original);
        }

        //DELORT
        internal Comment Delete(string id)
        {
            Comment original = GetById(id);
            _repo.Delete(id);
            return original; ;
        }
    }
}