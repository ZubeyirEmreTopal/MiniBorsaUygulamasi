import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from '../models/responseModel';
import { Teklif } from '../models/teklifAdd';

@Injectable({
  providedIn: 'root'
})
export class TeklifService {
  apiUrl='https://localhost:44307/api/';

  constructor(private httpClient:HttpClient) { }


  teklifVer(teklif:Teklif):Observable<ResponseModel>{
    return this.httpClient.post<ResponseModel>(this.apiUrl+"teklifs/add",teklif)

  }
}
