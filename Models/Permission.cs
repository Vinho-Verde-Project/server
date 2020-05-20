using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("permission")]
    public class Permission
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Desc { get; set; }
    }
}