using System;
using System.Collections.Generic;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class LietSy
    {
        public LietSy()
        {
            AnhMoPhans = new HashSet<AnhMoPhan>();
        }

        public int LietSyId { get; set; }
        public int? NghiaTrangId { get; set; }
        public int? DiaChiId { get; set; }
        public string HoTen { get; set; }
        public string Sdt { get; set; }
        public DateTime? NgaySinh { get; set; }
        public DateTime? NgayMat { get; set; }
        public string DonVi { get; set; }
        public string CapBac { get; set; }
        public int? ViTriHang { get; set; }
        public int? ViTriCot { get; set; }
        public string MoTa { get; set; }
        public string TinhTrang { get; set; }
        public string TrangThai { get; set; }

        public virtual DiaChi DiaChi { get; set; }
        public virtual NghiaTrang NghiaTrang { get; set; }
        public virtual ICollection<AnhMoPhan> AnhMoPhans { get; set; }
    }
}
