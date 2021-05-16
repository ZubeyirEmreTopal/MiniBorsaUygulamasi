import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MoneyService } from 'src/app/services/money.service';

@Component({
  selector: 'app-money',
  templateUrl: './money.component.html',
  styleUrls: ['./money.component.css']
})
export class MoneyComponent implements OnInit {

  moneyAddForm:FormGroup;

  constructor(private formBuilder:FormBuilder,private moneyService:MoneyService,private toastrService:ToastrService ) { }

  ngOnInit(): void {
    this.createMoneyAddForm();
  }
  createMoneyAddForm(){
    this.moneyAddForm=this.formBuilder.group({
      ıd:["",Validators.required],
      kullaniciId:["",Validators.required],
      miktar:["",Validators.required]
    })

  }

  add(){
    if(this.moneyAddForm.valid){
    let moneyModel=Object.assign({},this.moneyAddForm.value)
    this.moneyService.add(moneyModel).subscribe(response=>{
      
      this.toastrService.success(response.message ,"başarılı")

    },responseError=>{
      if(responseError.error.Errors.length>0){
        for (let i = 0; i <responseError.error.Errors.length; i++) {
          this.toastrService.error(responseError.error.Errors[i].ErrorMessage
            ,"Doğrulama hatası")
        }       
      } 
    })
    
  }else{
    this.toastrService.error("Formunuz eksik","Dikkat")
  }
  
 }

}
