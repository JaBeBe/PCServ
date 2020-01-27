import { LoginForm } from './login-form';
import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from '../user/user';
import { Observable } from 'rxjs';
import { resolve } from 'url';

@Injectable({
    providedIn: 'root'
})
export class HttpService {

    constructor(private http: HttpClient) { }


    getData() {
        return this.http.get("../assets/fakeData.json")
    }
}
