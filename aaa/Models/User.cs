using System.ComponentModel.DataAnnotations;

namespace aaa.Models
{
        public class User
        {
            public int UserId { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
            public int RoleId { get; set; }
            public Role Role { get; set; }
        }
    
}
