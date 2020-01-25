import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { LoginComponent } from './login/login.component';
import { AdminComponent } from './admin/admin.component'
import { UsersComponent } from './admin/users/users.component'
import { ServicesComponent } from './admin/services/services.component'

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    AdminComponent,
    UsersComponent,
    ServicesComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'admin', component: AdminComponent },

    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
