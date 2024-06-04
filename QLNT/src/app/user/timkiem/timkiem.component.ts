import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { LietsyService } from 'src/app/shared/service/lietsy/lietsy.service';
import { DiachiService } from 'src/app/shared/service/diachi/diachi.service';
import { Diachi } from 'src/app/shared/model/diachi/diachi';
import { Lietsy } from 'src/app/shared/model/lietsy/lietsy';

@Component({
  selector: 'app-timkiem',
  templateUrl: './timkiem.component.html',
  styleUrls: ['./timkiem.component.css']
})
export class TimkiemComponent implements OnInit {
  formTimKiem: FormGroup;
  list: Diachi[] = [];
  listLietSy: Lietsy[] = [];
  homeDistricts: Diachi[] = [];
  homeWards: Diachi[] = [];
  cemeteryDistricts: Diachi[] = [];
  cemeteryWards: Diachi[] = [];
  years: number[] = [];

  constructor(
    private fb: FormBuilder,
    private lietsyService: LietsyService,
    private diachiService: DiachiService
  ) {
    this.formTimKiem = this.fb.group({
      ten: ['', Validators.required],
      namSinh: [''],
      namHySinh: [''],
      thanhPho: [''],
      quan: [''],
      phuong: [''],
      nghiaTrangThanhpho: [''],
      nghiaTrangQuan: [''],
      nghiaTrangPhuong: [''],
      nghiaTrangId: ['']
    });
  }

  ngOnInit(): void {
    this.diachiService.refreshList().subscribe(res => {
      this.list = res;
    });

    const currentYear = new Date().getFullYear();
    for (let year = currentYear; year >= 1900; year--) {
      this.years.push(year);
    }
  }

  onCityChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const cityId = +selectElement.value;
    if (cityId > 0) {
      this.diachiService.getDiaChiChild(cityId).subscribe(res => {
        this.homeDistricts = res;
        this.homeWards = [];
      });
    } else {
      this.homeDistricts = [];
      this.homeWards = [];
    }
  }

  onDistrictChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const districtId = +selectElement.value;
    if (districtId > 0) {
      this.diachiService.getDiaChiChild(districtId).subscribe(res => {
        this.homeWards = res;
      });
    } else {
      this.homeWards = [];
    }
  }

  nghiaTrangOnCityChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const cityId = +selectElement.value;
    if (cityId > 0) {
      this.diachiService.getDiaChiChild(cityId).subscribe(res => {
        this.cemeteryDistricts = res;
        this.cemeteryWards = [];
      });
    } else {
      this.cemeteryDistricts = [];
      this.cemeteryWards = [];
    }
  }

  nghiaTrangOnDistrictChange(event: Event): void {
    const selectElement = event.target as HTMLSelectElement;
    const districtId = +selectElement.value;
    if (districtId > 0) {
      this.diachiService.getDiaChiChild(districtId).subscribe(res => {
        this.cemeteryWards = res;
      });
    } else {
      this.cemeteryWards = [];
    }
  }

  search(): void {
    const formData = this.formTimKiem.value;
    this.lietsyService.searchLietsy(
      formData.ten,
      formData.namSinh,
      formData.namHySinh,
      formData.thanhPho,
      formData.quan,
      formData.phuong,
      formData.nghiaTrangThanhpho,
      formData.nghiaTrangQuan,
      formData.nghiaTrangPhuong,
      formData.nghiaTrangId
    ).subscribe(res => {
      this.listLietSy = res;
    });
  }
}
