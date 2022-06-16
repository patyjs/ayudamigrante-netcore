using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Endpoint
{
    public class Session
    {
        [Key] public string IDSession { get; set; }
        [Required] public string IDAccount { get; set; }
        public string SessionToken { get; set; }
        [Required] public DateTime LastLogin { get; set; }
    }
}