import { DashboardComponent } from './dashboard/dashboard.component';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
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

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    LoginComponent,
    AdminComponent,
    UsersComponent,
    ServicesComponent,
<<<<<<< HEAD
    RegisterComponent
=======
    DashboardComponent
>>>>>>> 7b62f6d... Add RegisterController
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
<<<<<<< HEAD
    AppRoutingModule
=======
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'login', component: LoginComponent },
      { path: 'admin', component: AdminComponent },
      { path: 'dashboard', component: DashboardComponent }

    ])
>>>>>>> 7b62f6d... Add RegisterController
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
