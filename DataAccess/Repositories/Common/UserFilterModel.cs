using System;

namespace DataAccess.Repositories.Common
{
    public class UserFilterModel
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
