using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Endpoint
{
    public class Post
    {
        [Key] public string IDPost { get; set; }
        [Required] public string IDAccount { get; set; }
        [Required] public DateTime DateTimeUTC { get; set; }
        [Required] public string Body { get; set; }
        public virtual List<Account> Likes { get; set; }
        public virtual List<Comment> Comments { get; set; }
    }
}