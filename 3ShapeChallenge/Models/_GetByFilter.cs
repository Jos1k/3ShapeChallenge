using _3ShapeChallenge.Misc;
using System.ComponentModel.DataAnnotations;

namespace _3ShapeChallenge.Models
{
    public class _GetByFilter
    {
        public string Id { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StrictDate]
        public string ToDate { get; set; }
    }
}
