using System;
using System.Collections.Generic;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class NghiaTrang
    {
        public NghiaTrang()
        {
            AnhNghiaTrangs = new HashSet<AnhNghiaTrang>();
            LietSies = new HashSet<LietSy>();
            NghiaTrangUsers = new HashSet<NghiaTrangUser>();
        }

        public int NghiaTrangId { get; set; }
        public int? DiaChiId { get; set; }
        public string Ten { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public int? Soluong { get; set; }
        public string DiaChi { get; set; }
        public double? DienTich { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }

        public virtual DiaChi DiaChiNavigation { get; set; }
        public virtual ICollection<AnhNghiaTrang> AnhNghiaTrangs { get; set; }
        public virtual ICollection<LietSy> LietSies { get; set; }
        public virtual ICollection<NghiaTrangUser> NghiaTrangUsers { get; set; }
    }
}
