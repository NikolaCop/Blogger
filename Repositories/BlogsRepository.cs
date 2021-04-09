using System.Collections.Generic;
using System.Data;
using Dapper;
using Blogger.Models;

namespace Blogger.Repositories
{
    public class BlogsRepository
    {
        public readonly IDbConnection _db;

        public BlogsRepository(IDbConnection db)
        {
            _db = db;
        }

        public IEnumerable<Blog> Get()               //GET
        {
            string sql = "SELECT * FROM blogss;";
            return _db.Query<Blog>(sql);
        }

        internal Blog Get(string Id)                 //GET WITH ID
        {
            string sql = "SELECT * FROM blogs WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Blog>(sql, new { Id });
        }

        internal Blog Create(Blog newBlog)             //POST
        {
            string sql = @"
      INSERT INTO blogs
      (title, body)
      VALUES
      (@Title, @Body);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBlog);
            newBlog.id = id;
            return newBlog;
        }

        internal Blog Edit(Blog blogsToEdit)          //EDIT
        {
            string sql = @"
      UPDATE blogss
      SET
          title = @Title,
          body = @Body
          WHERE id = @Id;
          SELECT * FROM blogs WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Blog>(sql, blogsToEdit);

        }

        internal void Delete(string id)            //DELORT
        {
            string sql = "DELETE FROM blogs WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}