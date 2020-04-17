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
  private url = environment.baseURL;
  constructor(private http: HttpClient) {
    if (environment.production) {
      this.url = process.env[environment.baseURL];
    }
  }

  createProduct(model: Product) {
    return this.http.post(`${this.url}/product`, model);
  }

  updateProduct(model: Product) {
    return this.http.put(`${this.url}/product`, model);
  }

  deleteProduct(id: number) {
    return this.http.delete(`${this.url}/product/${id}`);
  }

  getProduct(id: number) {
    return this.http.get<Product>(`${this.url}/product/${id}`);
  }

  getAllProducts(filter: ProductFilter) {
    let filterParams = Object.keys(filter)
      .filter(key => filter[key] !== null)
      .map(key => `${key}=${filter[key]}`);
    let url = `${this.url}/product?${filterParams.join("&")}`;
    return this.http.get<Product[]>(url);
  }
}
