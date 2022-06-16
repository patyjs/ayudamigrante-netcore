using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Endpoint
{
    public class Post
    {
        [Key] public string IDProfile { get; set; }
        [Required] public string IDAccount { get; set; }
        [Required] public DateTime DateTimeUTC { get; set; }
        [Required] public string Body { get; set; }
        public List<Account> LikedBy { get; set; }
        public List<Comment> Comments { get; set; }
    }
}