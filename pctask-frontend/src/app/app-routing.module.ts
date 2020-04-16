import { ProductFormComponent } from "./products/product-form/product-form.component";
import { ProductsComponent } from "./products/products.component";
import { NgModule } from "@angular/core";
import { Routes, RouterModule } from "@angular/router";
import { ProductViewComponent } from "./products/product-view/product-view.component";
import { ProductResolver } from "./services/product.resolver";

const routes: Routes = [
  {
    path: "",
    redirectTo: "products",
    pathMatch: "full"
  },
  {
    path: "products",
    component: ProductsComponent
  },
  {
    path: "products/new",
    component: ProductFormComponent
  },
  {
    path: "products/edit/:id",
    component: ProductFormComponent,
    resolve: {
      product: ProductResolver
    }
  },
  {
    path: "products/view/:id",
    component: ProductViewComponent,
    resolve: {
      product: ProductResolver
    }
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {}
