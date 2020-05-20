using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("task")]
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }

        [Required]
        public string Status { get; set; }
    }
}