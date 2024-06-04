import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { DiachiService } from 'src/app/shared/service/diachi/diachi.service';

@Component({
  selector: 'app-diachi-quan-detail',
  templateUrl: './diachi-quan-detail.component.html',
  styleUrls: ['./diachi-quan-detail.component.css',
    '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
    '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class DiachiQuanDetailComponent implements OnInit {
  id: number = 0;
  DiaChi: any;
  diachiFormEdit: FormGroup;

  constructor(private diachiSrv: DiachiService, private _router: ActivatedRoute) {
    this.diachiFormEdit = new FormGroup({
      diaChiId: new FormControl(),
      ten: new FormControl(),
      // Remove parentId from the form initialization
    });
  }

  ngOnInit(): void {
    const url = window.location.href;
    const segments = url.split('/');
    const parentIdSegment = segments[segments.length - 1];
    this.id = parseInt(parentIdSegment);
    this.diachiSrv.getDiaChi(this.id).subscribe(data => {
      this.DiaChi = data;
      this.diachiFormEdit.patchValue({
        diaChiId: this.DiaChi.diaChiId,
        ten: this.DiaChi.ten,
        cap: "Thanh Pho",
        trangthai: "active"
        // Remove parentId from the patch value logic
      });
    });
  }

  onUpdate(): void {
    if (this.diachiFormEdit.valid) {
      alert("Cập nhật thành công");
      this.diachiSrv.updateDiaChiChild(this.diachiFormEdit.value).subscribe(data => {
        console.log('Updated data:', data);
      });
    }
  }
}
