using _3ShapeChallenge.Misc;
using Newtonsoft.Json;
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
        [JsonConverter(typeof(StrictDateConverter))]
        public DateTime Birthday { get; set; }
    }
}
