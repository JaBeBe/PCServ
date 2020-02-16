import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class HttpService {

  result: Observable<number>;

  constructor(
    private http: HttpClient,
    @Inject('BASE_URL') private baseUrl: string
  ) { }

  getUserByLogin(userLogin: string) {
    return this.http.get(this.baseUrl + 'user/search/' + userLogin)
  }

  getUserById(userId: number) {
    return this.http.get(this.baseUrl + 'user/search/' + userId)
  }

  getProductById(productId: number) {
    return this.http.get(this.baseUrl + 'Product/Get/' + productId)
  }

  getProductBySerialNo(serialNo: number) {
    return this.http.get(this.baseUrl + 'Product/Search/' + serialNo)
  }

  getProductByName(productName: string) {
    return this.http.get(this.baseUrl + 'Product/Browse/' + productName)
  }

  getRequestById(requestId: number) {
    return this.http.get(this.baseUrl + 'ServiceRequest/get/' + requestId)
  }

  getRequestByClient(client: string) {
    return this.http.get(this.baseUrl + 'RequestHistory/GetByClient/' + client)
  }

  postProduct(product: any) {
    return this.http.post(this.baseUrl + 'Product/Create/', product)
  }

  postRequest(request: any) {
    return this.http.post(this.baseUrl + 'ServiceRequest/Create/', request)
  }

}
