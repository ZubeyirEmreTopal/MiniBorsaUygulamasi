import { Injectable } from '@angular/core';
import {HttpClient} from '@angular/common/http'

import { Observable } from 'rxjs';
import { ListResponseModel } from '../models/listResponseModel';
import { Product } from '../models/product';
import { Category } from '../models/category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  apiUrl="https://localhost:44307/api/categories/getall";

  constructor(private HttpClient:HttpClient) { }

  getCategories():Observable<ListResponseModel<Category>>{

  return   this.HttpClient.get<ListResponseModel<Category>>(this.apiUrl);  
  }
}
