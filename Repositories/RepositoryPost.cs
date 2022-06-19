using Database;
using Models.Endpoint;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System;

namespace Repositories
{
    public class RepositoryPost
    {
        public static int Add(Post p)
        {
            using (var db = new Context())
            {
                db.Posts.Update(p);
                return db.SaveChanges();
            }
        }
        public static List<Post> Get(Expression<Func<Post, bool>> predicate)
        {
            using (var db = new Context())
            {
                return db.Posts.Where(predicate).ToList();
            }
        }
        public static Post Get(string id)
        {
            using (var db = new Context())
            {
                return db.Posts.Single(x => x.IDPost == id);
            }
        }
    }
}
