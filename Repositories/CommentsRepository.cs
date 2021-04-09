using System.Collections.Generic;
using System.Data;
using Dapper;
using Blogger.Models;

namespace Blogger.Repositories
{
    public class CommentsRepository
    {
        public readonly IDbConnection _db;

        public CommentsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Comment> Get()               //GET
        {
            string sql = "SELECT * FROM comments;";
            return _db.Query<Comment>(sql);
        }

        internal Comment Get(string Id)                 //GET WITH ID
        {
            string sql = "SELECT * FROM commentss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Comment>(sql, new { Id });
        }

        internal IEnumerable<Comment> GetByBlogId(int id)
        {
            string sql = "SELECT * FROM blog WHERE commentId = @id";
            return _db.Query<Comment>(sql, new { id });
        }

        internal Comment Create(Comment newComments)             //POST
        {
            string sql = @"
      INSERT INTO commentss
      (body, blogId)
      VALUES
      (@Name, @CastleId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newComments);
            newComments.id = id;
            return newComments;
        }

        internal Comment Edit(Comment commentsToEdit)          //EDIT
        {
            string sql = @"
      UPDATE comments
      SET
          body = @Body,
          blogId = @BlogId,
          WHERE id = @Id;
          SELECT * FROM commentss WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Comment>(sql, commentsToEdit);

        }

        internal void Delete(string id)            //DELORT
        {
            string sql = "DELETE FROM commentss WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}