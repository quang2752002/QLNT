using System;
using System.Collections.Generic;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class QuanLy
    {
        public QuanLy()
        {
            NghiaTrangUsers = new HashSet<NghiaTrangUser>();
        }

        public int UserId { get; set; }
        public int? DiaChiId { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string TrangThai { get; set; }

        public virtual DiaChi DiaChiNavigation { get; set; }
        public virtual ICollection<NghiaTrangUser> NghiaTrangUsers { get; set; }
    }
}
