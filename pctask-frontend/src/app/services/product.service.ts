import { ProductFilter } from "./../models/product-filter";
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { Product } from "../models/product";
import { environment } from "src/environments/environment";
import { Observable } from "rxjs";

@Injectable({
  providedIn: "root"
})
export class ProductService {
  constructor(private http: HttpClient) {}

  createProduct(model: Product) {
    return this.http.post(`${environment.baseURL}/product`, model);
  }

  updateProduct(model: Product) {
    return this.http.put(`${environment.baseURL}/product`, model);
  }

  deleteProduct(id: number) {
    return this.http.delete(`${environment.baseURL}/product/${id}`);
  }

  getProduct(id: number) {
    return this.http.get<Product>(`${environment.baseURL}/product/${id}`);
  }

  getAllProducts(filter: ProductFilter) {
    let filterParams = Object.keys(filter)
      .filter(key => filter[key] !== null)
      .map(key => `${key}=${filter[key]}`);
    let url = `${environment.baseURL}/product?${filterParams.join("&")}`;
    console.log(url);
    return this.http.get<Product[]>(url);
  }
}
