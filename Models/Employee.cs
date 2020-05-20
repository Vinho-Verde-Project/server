using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Api.Models
{
    [Table("employee")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Nif { get; set; }

        public DateTime Birthdate { get; set; }

        [Required]
        public string Adress { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string HashedPassword { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        public int RoleId { get; set; }

        [Required]
        public Role Role { get; set; }
    }
}