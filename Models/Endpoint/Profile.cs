using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Endpoint
{
    public class Profile
    {
        [Key] public string IDProfile { get; set; }
        [Required, ForeignKey("Account")] public string IDAccount { get; set; }
        [Required] public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string AboutMe { get; set; }
        public string OriginCity { get; set; }
        public DateTime BirthDay { get; set; }
        public Account Account { get; set; }
    }
}