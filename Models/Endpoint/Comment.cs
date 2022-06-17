using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Endpoint
{
    public class Comment
    {
        [Key] public string IDComment { get; set; }
        [Required, ForeignKey("Account")] public string IDAccount { get; set; }
        [Required, ForeignKey("Post")] public string IDPost { get; set; }
        [Required] public DateTime DateTimeUTC { get; set; }
        [Required] public string Content { get; set; }
        public Account Account { get; set; }
        public Post Post { get; set; }
    }
}