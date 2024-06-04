using System;
using System.Collections.Generic;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class AnhMoPhan
    {
        public int AnhId { get; set; }
        public int? LietSyId { get; set; }
        public string Img { get; set; }
        public string MoTa { get; set; }
        public string TrangThai { get; set; }

        public virtual LietSy LietSy { get; set; }
    }
}
