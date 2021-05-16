import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/models/product';


import { from } from 'rxjs';
import { ProductService } from 'src/app/services/product.service';
import { ActivatedRoute } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {

  products:Product[]=[];
  dataLoaded=false;
  filterText="";
 
 
  constructor(private productService:ProductService,
    private activatedRoute:ActivatedRoute,
    private toastrService:ToastrService,
    private cartService:CartService) { }


  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      if(params["kategoriId"]){
        this.getProductsByCategory(params["kategoriId"])
      }else{
        this.getProducts()
        
      }
    })
}
  
  getProducts(){
    this.productService.getProducts().subscribe(response=>{
      this.products=response.data
      this.dataLoaded=true;

    })
  }


  getProductsByCategory(kategoriId:number) {
    this.productService.getProductsByCategory(kategoriId).subscribe(response=>{
      this.products = response.data
      this.dataLoaded = true;
    })   
  }

  addToCart(product:Product){
    if(product.urunId===1){
      this.toastrService.error("sepete eklenemez");
    }
    else{
      this.toastrService.success("sepete Eklendi",product.urunAdi);
      this.cartService.addToCart(product);
    }

  }

}
