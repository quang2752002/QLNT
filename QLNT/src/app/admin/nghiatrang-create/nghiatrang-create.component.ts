import { Component,OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { NghiatrangService } from '../../shared/service/nghiatrang/nghiatrang.service'; 
import { Nghiatrang } from '../../shared/model/nghiatrang/nghiatrang';

@Component({
  selector: 'app-nghiatrang-create',
  templateUrl: './nghiatrang-create.component.html',
  styleUrls: ['./nghiatrang-create.component.css',
  '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
  '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class NghiatrangCreateComponent implements OnInit  {
  

  constructor(private nghiatrangSrv:NghiatrangService) { }
  nghiaTrangForm :FormGroup=new FormGroup({
    diaChiId: new FormControl(),
    ten: new FormControl(),
    sdt: new FormControl(),
    email:new FormControl(),
    soluong: new FormControl(),
    dientich: new FormControl(),
    mota: new FormControl(),
  });
 
  ngOnInit(): void {
    
  }

  onCreate(): void {
    this.nghiatrangSrv.createNghiaTrang(this.nghiaTrangForm.value).subscribe(data=>{
      console.log(this.nghiaTrangForm.value);
    })
    
  }
}
