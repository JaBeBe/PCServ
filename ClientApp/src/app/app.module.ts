import { RequestResetComponent } from './password-reset/request-reset/request-reset.component';
import { NewPasswordComponent } from './password-reset/new-password/new-password.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component'
import { UsersComponent } from './admin/users/users.component'
import { ServicesComponent } from './admin/services/services.component';
import { AppRoutingModule } from './app-routing.module'
import { RegisterComponent } from './register/register.component';
import { AddNewComponent } from './dashboard/add-new/add-new.component';
import { CheckStatusComponent } from './dashboard/check-status/check-status.component'
import { DataSharingService } from './shared/data-sharing.service';
import { StuffComponent } from './admin/stuff/stuff.component'
@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    AdminComponent,
    UsersComponent,
    ServicesComponent,
    RegisterComponent,
    DashboardComponent,
    AddNewComponent,
    CheckStatusComponent,
    NewPasswordComponent,
    RequestResetComponent,
    StuffComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule
  ],
  providers: [DataSharingService],
  bootstrap: [AppComponent]
})
export class AppModule { }
