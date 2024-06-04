import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DiachiService } from 'src/app/shared/service/diachi/diachi.service';

@Component({
  selector: 'app-diachi-create',
  templateUrl: './diachi-create.component.html',
  styleUrls: ['./diachi-create.component.css',
    '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
    '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class DiachiCreateComponent implements OnInit {
  DiachiForm: FormGroup;

  constructor(private diachiSrv: DiachiService, private snackBar: MatSnackBar) {
    this.DiachiForm = new FormGroup({
      ten: new FormControl('', Validators.required),
    });
  }

  ngOnInit(): void {
  }

  onCreate(): void {
    if (this.DiachiForm.valid) {
      alert("Địa chỉ đã được thêm mới thành công")
      this.diachiSrv.createDiaChi(this.DiachiForm.value).subscribe(
        data => {
          console.log(this.DiachiForm.value);
         
          this.snackBar.open('Địa chỉ đã được thêm mới thành công!', 'Đóng', {
            duration: 3000, // Duration in milliseconds
            verticalPosition: 'top', // Position on the screen
            horizontalPosition: 'center' // Position on the screen
          });
          this.DiachiForm.reset(); // Optional: Reset the form after successful submission
        },
        error => {
          this.snackBar.open('Đã xảy ra lỗi khi thêm địa chỉ.', 'Đóng', {
            duration: 3000,
            verticalPosition: 'top',
            horizontalPosition: 'center'
          });
        }
      );
    }
  }
}
