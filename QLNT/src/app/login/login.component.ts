// login.component.ts

import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms'; // Import FormBuilder và FormGroup từ '@angular/forms'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm!: FormGroup; // Khai báo loginForm là một FormGroup

  constructor(private formBuilder: FormBuilder) {} // Inject FormBuilder vào constructor

  ngOnInit(): void {
    // Khởi tạo form và các FormControl
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required], // FormControl cho username, giá trị mặc định là '', và yêu cầu bắt buộc
      password: ['', Validators.required]  // FormControl cho password, giá trị mặc định là '', và yêu cầu bắt buộc
    });
  }

  // Phương thức để xử lý sự kiện khi submit form
  login() {
    if (this.loginForm.valid) {
      // Xử lý đăng nhập
      const username = this.loginForm.value.username;
      const password = this.loginForm.value.password;
      // Gọi phương thức login từ AuthService hoặc service tương ứng
    } else {
      // Hiển thị thông báo hoặc xử lý khi form không hợp lệ
    }
  }
}
