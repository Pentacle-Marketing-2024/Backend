using System;
using System.Collections.Generic;

namespace Repository.Models
{
    public partial class Form
    {
        public int Id { get; set; }
        public string Email { get; set; } = null!;
        public string FullName { get; set; } = null!;
        public string Method { get; set; } = null!;
        public string Description { get; set; } = null!;
        public DateTime CreateDate { get; set; }
    }
}
