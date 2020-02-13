import { NewPasswordForm } from './new-password-form';
import { RequestResetForm } from './request-reset-form';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class PasswordServiceService {

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string) { }

  requestPasswordReset(requestResetForm: RequestResetForm, callback: (n: boolean) => any) {
   const url = 'ResetPassword/RequestReset';
    this.http.post(this.baseUrl + url, requestResetForm).subscribe(result => {
      console.log(result);
      callback(true);
    }, error => {
      console.error(error);
      callback(false);
    });
  }

  setNewPassword(newPasswordForm: NewPasswordForm, userId: number, resetToken: string, callback: (n: boolean) => any) {
    const url = 'ResetPassword/NewPassword';
    this.http.post(this.baseUrl + url + `?userId=${userId}&resetToken=${resetToken}`, newPasswordForm).subscribe(result => {
      console.log(result);
      callback(true);
    }, error => {
      console.error(error);
      callback(false);
    });
  }
}
