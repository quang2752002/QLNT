import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { DiachiService } from 'src/app/shared/service/diachi/diachi.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-diachi-quan-create',
  templateUrl: './diachi-quan-create.component.html',
  styleUrls: ['./diachi-quan-create.component.css',
  '../../../assets/Themes2/vendor/fontawesome-free/css/all.min.css',
  '../../../assets/Themes2/css/sb-admin-2.min.css']
})
export class DiachiQuanCreateComponent implements OnInit {
  DiachiForm: FormGroup;
  parentId: number=0;

  constructor(
    private diachiSrv: DiachiService,
    private snackBar: MatSnackBar,
    private route: ActivatedRoute, // Inject ActivatedRoute
    private fb: FormBuilder // Inject FormBuilder
  ) {
    this.DiachiForm = this.fb.group({
      ten: ['', Validators.required],
      parentId: [''] // Add parentId field to the form
    });
  }

  ngOnInit(): void {
    this.getParentIdFromUrl();
  }

  getParentIdFromUrl(): void {
    this.route.paramMap.subscribe(params => {
      // Extracting parentId from URL
      const parentIdFromUrl = params.get('id');
      if (parentIdFromUrl) {
        // Set parentId in the form
        this.DiachiForm.patchValue({ parentId: parentIdFromUrl });
      }
    });
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
