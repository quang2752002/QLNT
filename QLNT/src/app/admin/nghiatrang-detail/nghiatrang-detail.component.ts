import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NghiatrangService } from 'src/app/shared/service/nghiatrang/nghiatrang.service';

@Component({
  selector: 'app-nghiatrang-detail',
  templateUrl: './nghiatrang-detail.component.html',
  styleUrls: ['./nghiatrang-detail.component.css',
  '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
  '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class NghiatrangDetailComponent implements OnInit {
  id: number = 0;
  NghiaTrang: any;
  nghiaTrangFormEdit: FormGroup;

  constructor(private nghiatrangSrv: NghiatrangService, private _router: ActivatedRoute) {
    this.nghiaTrangFormEdit = new FormGroup({
      nghiaTrangId: new FormControl(),
      diaChiId: new FormControl(),
      ten: new FormControl(),
      sdt: new FormControl(),
      email: new FormControl(),
      soluong: new FormControl(),
      dienTich: new FormControl(),
      moTa: new FormControl(),
    });
  }

  ngOnInit(): void {
    this.id = this._router.snapshot.params.id;
    this.nghiatrangSrv.getNghiaTrang(this.id).subscribe(data => {
      this.NghiaTrang = data;
      this.nghiaTrangFormEdit.patchValue({
        nghiaTrangId: this.NghiaTrang.nghiaTrangId,
        diaChiId: this.NghiaTrang.diaChiId,
        ten: this.NghiaTrang.ten,
        sdt: this.NghiaTrang.sdt,
        email: this.NghiaTrang.email,
        soluong: this.NghiaTrang.soluong,
        dienTich: this.NghiaTrang.dienTich,
        moTa: this.NghiaTrang.moTa,
      });
    });
  }

  onUpdate(): void {
    if (this.nghiaTrangFormEdit.valid) {
      this.nghiatrangSrv.updateNghiaTrang(this.nghiaTrangFormEdit.value).subscribe(data => {
        console.log('Updated data:', data);
      });
    }
  }
}
