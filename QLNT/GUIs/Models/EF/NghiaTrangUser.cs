using System;
using System.Collections.Generic;

#nullable disable

namespace GUIs.Models.EF
{
    public partial class NghiaTrangUser
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? NghiaTrangId { get; set; }
        public DateTime? LastUpdateTime { get; set; }
        public string TrangThai { get; set; }

        public virtual NghiaTrang NghiaTrang { get; set; }
        public virtual QuanLy User { get; set; }
    }
}
