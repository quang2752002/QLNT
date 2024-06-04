import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdminComponent } from './admin/admin.component';
import { DiachiComponent } from './admin/diachi/diachi.component';
import { NghiatrangListComponent } from './admin/nghiatrang-list/nghiatrang-list.component'; 
import { NghiatrangCreateComponent } from './admin/nghiatrang-create/nghiatrang-create.component';
import { NghiatrangDetailComponent } from './admin/nghiatrang-detail/nghiatrang-detail.component';
import { DiachiQuanComponent } from './admin/diachi-quan/diachi-quan.component';
import { DiachiCreateComponent } from './admin/diachi-create/diachi-create.component';
import { DiachiDetailComponent } from './admin/diachi-detail/diachi-detail.component';
import { DiachiQuanCreateComponent } from './admin/diachi-quan-create/diachi-quan-create.component';
import { DiachiQuanDetailComponent } from './admin/diachi-quan-detail/diachi-quan-detail.component';
import { DiachiPhuongComponent } from './admin/diachi-phuong/diachi-phuong.component';
import { DiachiPhuongCreateComponent } from './admin/diachi-phuong-create/diachi-phuong-create.component';
import { DiachiPhuongDetailComponent } from './admin/diachi-phuong-detail/diachi-phuong-detail.component';
import { UserComponent } from './user/user.component'; 
import { TimkiemComponent } from './user/timkiem/timkiem.component';
import { LietsyComponent } from './admin/lietsy/lietsy.component';
import { LietsyCreateComponent } from './admin/lietsy-create/lietsy-create.component';
import { LietsyDetailComponent } from './admin/lietsy-detail/lietsy-detail.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './shared/service/auth.guard'; 

const routes: Routes = [
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachi', component: DiachiComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachicreate', component: DiachiCreateComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachidetail/:id', component: DiachiDetailComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachiquan/:id', component: DiachiQuanComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachiquancreate/:id', component: DiachiQuanCreateComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachiquandetail/:id', component: DiachiQuanDetailComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachiphuong/:id', component: DiachiPhuongComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachiphuongcreate/:id', component: DiachiPhuongCreateComponent, canActivate: [AuthGuard] },
  { path: 'admin/diachiphuongdetail/:id', component: DiachiPhuongDetailComponent, canActivate: [AuthGuard] },
  { path: 'admin/nghiatrang', component: NghiatrangListComponent, canActivate: [AuthGuard] },
  { path: 'admin/nghiatrangcreate', component: NghiatrangCreateComponent, canActivate: [AuthGuard] },
  { path: 'admin/nghiatrangdetail/:id', component: NghiatrangDetailComponent, canActivate: [AuthGuard] },
  { path: 'admin/lietsy', component: LietsyComponent, canActivate: [AuthGuard] },
  { path: 'admin/lietsycreate', component: LietsyCreateComponent, canActivate: [AuthGuard] },
  { path: 'admin/lietsydetail/:id', component: LietsyDetailComponent, canActivate: [AuthGuard] },
  { path: 'trangchu', component: UserComponent },
  { path: 'timkiem', component: TimkiemComponent },
  // Add routes for login or other public routes here
  { path: 'login', component: LoginComponent }, // Add login component route
  { path: '**', redirectTo: 'login' } // Redirect to login for any undefined routes
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
