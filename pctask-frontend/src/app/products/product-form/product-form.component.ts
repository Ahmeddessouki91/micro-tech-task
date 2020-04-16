import { ProductService } from "./../../services/product.service";
import { Product } from "./../../models/product";
import { Component, OnInit } from "@angular/core";
import { FormGroup, FormBuilder, Validators } from "@angular/forms";
import { ToastrService } from "ngx-toastr";
import { error } from "@angular/compiler/src/util";
import { Router, ActivatedRoute } from "@angular/router";

@Component({
  selector: "app-product-form",
  templateUrl: "./product-form.component.html",
  styleUrls: ["./product-form.component.scss"]
})
export class ProductFormComponent implements OnInit {
  form: FormGroup;
  product: Product;
  constructor(
    private fb: FormBuilder,
    private toastr: ToastrService,
    private productService: ProductService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  get f() {
    return this.form.controls;
  }

  ngOnInit(): void {
    const data = this.route.snapshot.data;
    this.product = data.product;
    this.initForm(data.product);
  }

  initForm(product?: Product) {
    this.form = this.fb.group({
      id: [null],
      name: [null, Validators.required],
      price: [null, [Validators.required, Validators.min(1)]],
      photo: [null, Validators.required]
    });
    if (product) this.form.patchValue(product);
  }
  onSubmit() {
    if (!this.form.valid) this.toastr.error("Please fill all required fields!");
    else {
      const product = this.form.value as Product;
      // Update product
      if (product.id && product.id > 0) {
        this.productService.updateProduct(product).subscribe(
          res => {
            this.toastr.success("Product Updated successfully");
            this.form.reset();
            this.router.navigateByUrl("/products");
          },
          e => this.toastr.error(e)
        );
      } else {
        // Create Product
        this.productService.createProduct(product).subscribe(
          res => {
            this.toastr.success("Product created successfully");
            this.form.reset();
          },
          e => this.toastr.error(e)
        );
      }
    }
  }

  delete() {
    let result = confirm("Are you sure to remove this product");
    if (!result) return;
    else
      this.productService.deleteProduct(this.product.id).subscribe(
        res => {
          this.toastr.success("Product deleted successfully");
          this.router.navigateByUrl("/products");
        },
        error => this.toastr.error("Something went wrong!")
      );
  }
}
