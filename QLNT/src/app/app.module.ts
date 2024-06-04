import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NgxPaginationModule } from 'ngx-pagination';
import { AdminComponent } from './admin/admin.component';
import { UserComponent } from './user/user.component';
import { DiachiComponent } from './admin/diachi/diachi.component';

import { NghiatrangListComponent } from './admin/nghiatrang-list/nghiatrang-list.component';
import { NghiatrangCreateComponent } from './admin/nghiatrang-create/nghiatrang-create.component';
import { ReactiveFormsModule } from '@angular/forms';
import { NghiatrangDetailComponent } from './admin/nghiatrang-detail/nghiatrang-detail.component';

import { HeaderComponent } from './admin/header/header.component';
import { FooterComponent } from './admin/footer/footer.component';
import { DiachiCreateComponent } from './admin/diachi-create/diachi-create.component';
import { DiachiDetailComponent } from './admin/diachi-detail/diachi-detail.component';
import { DiachiQuanCreateComponent } from './admin/diachi-quan-create/diachi-quan-create.component';
import { DiachiQuanDetailComponent } from './admin/diachi-quan-detail/diachi-quan-detail.component';
import { DiachiQuanComponent } from './admin/diachi-quan/diachi-quan.component';
import { DiachiPhuongComponent } from './admin/diachi-phuong/diachi-phuong.component';
import { DiachiPhuongCreateComponent } from './admin/diachi-phuong-create/diachi-phuong-create.component';
import { DiachiPhuongDetailComponent } from './admin/diachi-phuong-detail/diachi-phuong-detail.component';
import { TimkiemComponent } from './user/timkiem/timkiem.component';
import { LietsyComponent } from './admin/lietsy/lietsy.component';
import { LietsyCreateComponent } from './admin/lietsy-create/lietsy-create.component'; 
import { LietsyDetailComponent } from './admin/lietsy-detail/lietsy-detail.component';


@NgModule({
  declarations: [
    AppComponent,   
    AdminComponent,
    UserComponent,
    DiachiComponent,
    NghiatrangListComponent,
    NghiatrangCreateComponent,
    NghiatrangDetailComponent,
  
    HeaderComponent,
       FooterComponent,
       DiachiCreateComponent,
       DiachiDetailComponent,
       DiachiQuanCreateComponent,
       DiachiQuanDetailComponent,
       DiachiQuanComponent,
       DiachiPhuongComponent,
       DiachiPhuongCreateComponent,
       DiachiPhuongDetailComponent,
       TimkiemComponent,
       LietsyComponent,
       LietsyCreateComponent,
       LietsyDetailComponent,
     
       
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    ReactiveFormsModule,
    NgxPaginationModule,
    MatSnackBarModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
