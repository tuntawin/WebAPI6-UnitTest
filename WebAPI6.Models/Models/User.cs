using System;
using System.Collections.Generic;

namespace WebAPI6.Models.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime? LastUpdateDate { get; set; }
    }
}
