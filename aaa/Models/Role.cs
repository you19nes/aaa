using System.ComponentModel.DataAnnotations;

namespace aaa.Models
{
    public class Role
    {
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
        public string NormalizedName { get; set; }
    }
}
