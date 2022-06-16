using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Endpoint
{
    public class Account
    {
        [Key] public string IDAccount { get; set; }
        [Required, StringLength(150)] public string Email { get; set; }
        [Required] public string PasswordHash { get; set; }
        [Required, ForeignKey("UserRol")] public string IDUserRol { get; set; }
        public bool IsVerified { get; set; }
        public bool RequirePasswordReset { get; set; }
        [Required] public DateTime CreatedAt { get; set; }
        public UserRol UserRol { get; set; }
    }
    public class UserRol {
        [Key] public string IDUserRol { get; set; }
        [Required] public int UserLevel { get; set; }
        [Required] public string UserRolName { get; set; }
        [Required] public string UserRolPermisions { get; set; }
    }
}