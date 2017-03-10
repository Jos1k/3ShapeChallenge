using System;
using System.ComponentModel.DataAnnotations;

namespace _3ShapeChallenge.Models
{
    public class _AddUser
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime Birthday { get; set; }
    }
}
