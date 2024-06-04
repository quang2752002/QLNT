export class Lietsy {
    lietSyId: number;
    nghiaTrangId: number;
    diaChiId: number;
    hoTen: string;
    sdt: string;
    ngaySinh: Date;
    ngayMat: Date;
    donVi: string;
    capBac: string;
    viTriHang: number;
    viTriCot: number;
    moTa: string;
    tinhTrang: string;
    trangThai: string;
  
    constructor(
      lietSyId: number,
      nghiaTrangId: number,
      diaChiId: number,
      hoTen: string,
      sdt: string,
      ngaySinh: Date,
      ngayMat: Date,
      donVi: string,
      capBac: string,
      viTriHang: number,
      viTriCot: number,
      moTa: string,
      tinhTrang: string,
      trangThai: string
    ) {
      this.lietSyId = lietSyId;
      this.nghiaTrangId = nghiaTrangId;
      this.diaChiId = diaChiId;
      this.hoTen = hoTen;
      this.sdt = sdt;
      this.ngaySinh = ngaySinh;
      this.ngayMat = ngayMat;
      this.donVi = donVi;
      this.capBac = capBac;
      this.viTriHang = viTriHang;
      this.viTriCot = viTriCot;
      this.moTa = moTa;
      this.tinhTrang = tinhTrang;
      this.trangThai = trangThai;
    }
  }
  