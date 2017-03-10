using DataAccess.Common.Attributes;
using System.ComponentModel.DataAnnotations;

namespace DataAccess.Models
{
    public class User:IEntity
    {
        [Key]
        public string Id { get; set; }
        [Unique]
        public string Email { get; set; }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
