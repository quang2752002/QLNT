using System;
using System.Collections.Generic;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class DiaChi
    {
        public DiaChi()
        {
            InverseParent = new HashSet<DiaChi>();
            LietSies = new HashSet<LietSy>();
            NghiaTrangs = new HashSet<NghiaTrang>();
            QuanLies = new HashSet<QuanLy>();
        }

        public int DiaChiId { get; set; }
        public int? ParentId { get; set; }
        public string Ten { get; set; }
        public string Cap { get; set; }
        public string TrangThai { get; set; }

        public virtual DiaChi Parent { get; set; }
        public virtual ICollection<DiaChi> InverseParent { get; set; }
        public virtual ICollection<LietSy> LietSies { get; set; }
        public virtual ICollection<NghiaTrang> NghiaTrangs { get; set; }
        public virtual ICollection<QuanLy> QuanLies { get; set; }
    }
}
