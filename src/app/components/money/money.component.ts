import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators,FormControl } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { MoneyService } from 'src/app/services/money.service';

@Component({
  selector: 'app-money',
  templateUrl: './money.component.html',
  styleUrls: ['./money.component.css']
})
export class MoneyComponent implements OnInit {

  moneyAddForm:FormGroup;

  constructor(private formBuilder:FormBuilder,private moneyService:MoneyService,
    private toastrService:ToastrService ) { }

  ngOnInit(): void {
    this.createMoneyAddForm();
  }
  createMoneyAddForm(){
    this.moneyAddForm=this.formBuilder.group({
      
      kullaniciId:["",Validators.required],
      miktar:["",Validators.required],
      dovizKodu:["",Validators.required]
    });

  }

 moneyAdd(){
   if(this.moneyAddForm.valid){
    let moneyModel=Object.assign({},this.moneyAddForm.value)
    this.moneyService.moneyAdd(moneyModel).subscribe(response=>{
      console.log(response)
      this.toastrService.success("para ekleme işlemi basarili")
    })
    
   }
   
  
 }
}
