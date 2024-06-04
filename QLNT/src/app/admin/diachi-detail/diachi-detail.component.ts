import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DiachiService } from 'src/app/shared/service/diachi/diachi.service'; 

@Component({
  selector: 'app-diachi-detail',
  templateUrl: './diachi-detail.component.html',
  styleUrls: ['./diachi-detail.component.css',
  '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
  '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class DiachiDetailComponent implements OnInit{
  id: number = 0;
  DiaChi: any;
  diachiFormEdit: FormGroup;
  constructor(private diachiSrv: DiachiService, private _router: ActivatedRoute) {
    this.diachiFormEdit = new FormGroup({
     
      diaChiId: new FormControl(),
      ten: new FormControl(),
     
    });
  }
  ngOnInit(): void {
    this.id = this._router.snapshot.params.id;
    this.diachiSrv.getDiaChi(this.id).subscribe(data => {
        this.DiaChi = data;
        this.diachiFormEdit.patchValue({
            diaChiId: this.DiaChi.diaChiId,
            parentId: this.DiaChi.parentId === 0 ? null : this.DiaChi.parentId,
            ten: this.DiaChi.ten,
            cap: "Thanh Pho",
            trangthai: "active"
        });
    });
}


  onUpdate(): void {
    if (this.diachiFormEdit.valid) {
      alert("Cập nhật thành công")
      this.diachiSrv.updateDiaChi(this.diachiFormEdit.value).subscribe(data => {
        
        console.log('Updated data:', data);
      });
    }
  }
}
