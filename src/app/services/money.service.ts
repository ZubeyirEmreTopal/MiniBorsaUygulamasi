import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Money } from '../models/money';
import { ResponseModel } from '../models/responseModel';

@Injectable({
  providedIn: 'root'
})
export class MoneyService {
  apiUrl='https://localhost:44307/api/';

  constructor(private httpClient:HttpClient) { }

  add(money:Money):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"moneys/add",money);

  }
}
