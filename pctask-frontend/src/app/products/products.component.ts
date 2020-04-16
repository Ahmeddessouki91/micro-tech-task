import { FormGroup, FormBuilder } from "@angular/forms";
import { Component, OnInit } from "@angular/core";
import { ProductService } from "../services/product.service";
import { ProductFilter } from "../models/product-filter";
import { Observable } from "rxjs";
import { Product } from "../models/product";

@Component({
  selector: "app-products",
  templateUrl: "./products.component.html",
  styleUrls: ["./products.component.scss"]
})
export class ProductsComponent implements OnInit {
  form: FormGroup;
  product$: Observable<Product[]>;

  constructor(
    private productService: ProductService,
    private fb: FormBuilder
  ) {}

  ngOnInit(): void {
    this.form = this.fb.group({
      name: [null],
      startPrice: [null],
      endPrice: [null]
    });
    this.product$ = this.productService.getAllProducts(this.form.value);
  }

  search() {
    this.product$ = this.productService.getAllProducts(this.form.value);
  }
}
