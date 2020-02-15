import { NewPasswordComponent } from './password-reset/new-password/new-password.component';
import { RequestResetComponent } from './password-reset/request-reset/request-reset.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { RegisterComponent } from './register/register.component';
import { AddNewComponent } from './dashboard/add-new/add-new.component';
import { CheckStatusComponent } from './dashboard/check-status/check-status.component';
import { AuthGuardService } from './shared/auth-guard.service'
import { AuthRoleGuardService } from './shared/auth-role-guard.service';

const routes: Routes = [
  { path: '', component: HomeComponent, pathMatch: 'full' },
  { path: 'login', component: LoginComponent },
  { path: 'admin', component: AdminComponent, canActivate: [AuthGuardService] },
  { path: 'dashboard', component: DashboardComponent, canActivate: [AuthGuardService] },
  { path: 'register', component: RegisterComponent },
  { path: 'addnew', component: AddNewComponent },
  { path: 'checkstatus', component: CheckStatusComponent },
  { path: 'request-password-reset', component: RequestResetComponent },
  { path: 'set-new-password', component: NewPasswordComponent }
];


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    RouterModule.forRoot(routes)
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
