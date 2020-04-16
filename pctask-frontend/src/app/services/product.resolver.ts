import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot } from "@angular/router";
import { Observable, EMPTY } from "rxjs";
import { Product } from "../models/product";
import { ProductService } from "./product.service";

@Injectable({ providedIn: "root" })
export class ProductResolver implements Resolve<Product> {
  constructor(private productService: ProductService) {}
  resolve(route: ActivatedRouteSnapshot): Observable<Product> | Product {
    const id = +route.paramMap.get("id");
    if (id && !isNaN(id)) return this.productService.getProduct(id);
    else return EMPTY;
  }
}
