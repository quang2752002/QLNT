using System;
using System.Collections.Generic;

namespace QLNT.Models.EF
{
    public partial class AnhNghiaTrang
    {
        public int AnhId { get; set; }
        public int? NghiaTrangId { get; set; }
        public string? Img { get; set; }
        public string? MoTa { get; set; }
        public string? TrangThai { get; set; }

        public virtual NghiaTrang? NghiaTrang { get; set; }
    }
}
