using Database;
using Models.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryPost
    {
        public static int Add(Post p)
        {
            using (var db = new Context())
            {
                db.Posts.Add(p);
                return db.SaveChanges();
            }
        }
    }
}
