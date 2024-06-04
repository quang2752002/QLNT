using System;
using System.Collections.Generic;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class Admin
    {
        public int Id { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TrangThai { get; set; }
    }
}
