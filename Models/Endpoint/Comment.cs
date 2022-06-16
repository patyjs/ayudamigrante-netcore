using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Endpoint
{
    public class Comment
    {
        [Key] public string IDComment { get; set; }
        [Required] public string IDAccount { get; set; }
        [Required] public DateTime DateTimeUTC { get; set; }
        [Required] public string Content { get; set; }
    }
}