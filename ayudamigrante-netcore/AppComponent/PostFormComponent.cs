using Models.Endpoint;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ayudamigrante_netcore.AppComponent
{
    public class PostFormComponent
    {
        public static void SubmitForm(string body, string authorid)
        {
            Post p = new Post()
            {
                IDPost = Guid.NewGuid().ToString(),
                IDAccount = authorid,
                Body = body,
                DateTimeUTC = DateTime.UtcNow
            };

            Console.WriteLine(p);
        }
    }
}
