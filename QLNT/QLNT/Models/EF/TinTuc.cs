using System;
using System.Collections.Generic;

namespace QLNT.Models.EF
{
    public partial class TinTuc
    {
        public int Id { get; set; }
        public string? Anh { get; set; }
        public string? Tieude { get; set; }
        public string? Noidung { get; set; }
        public string? TrangThai { get; set; }
    }
}
