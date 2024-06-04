export class Diachi {
    diaChiId: number;
    parentId: number;
    ten: string;
    cap: string;
    trangThai: string;
  
    constructor(DiaChiId: number, ParentId: number, Ten: string, Cap: string, TrangThai: string) {
      this.diaChiId = DiaChiId;
      this.parentId = ParentId;
      this.ten = Ten;
      this.cap = Cap;
      this.trangThai = TrangThai;
    }
  }
  