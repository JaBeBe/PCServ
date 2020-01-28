import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
@Injectable({
    providedIn: 'root'
})
export class HttpService {
    constructor(private http: HttpClient) { }

    addUser(user: any): Observable<any> {
        return this.http.post<any>(`http://localhost:8089/topics/${user.userId}`, user);
    }

    getUserById(userId: any): Observable<any> {
        return this.http.get(`http://localhost:8089/topics/${userId}`);
    }
}