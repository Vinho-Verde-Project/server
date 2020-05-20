using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("role")]
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        public int PermissionId { get; set; }

        [Required]
        public Permission Permission { get; set; }
    }
}