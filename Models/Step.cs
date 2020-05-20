using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Api.Models
{
    [Table("step")]
    public class Step
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Desc { get; set; }

        [Required]
        public string Status { get; set; }

        public float Quantity { get; set; }

        [Required]
        public DateTime StartedAt { get; set; }

        public DateTime EndedAt { get; set; }

        public int EmployeeId { get; set; }

        [Required]
        public Employee Employee { get; set; }

        public int TaskId { get; set; }

        [Required]
        public Task Task { get; set; }
    }
}