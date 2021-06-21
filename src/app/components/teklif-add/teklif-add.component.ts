import { Component, OnInit } from '@angular/core';
import { FormGroup,FormBuilder,FormControl,Validators } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';
import { TeklifService } from 'src/app/services/teklif.service';

@Component({
  selector: 'app-teklif-add',
  templateUrl: './teklif-add.component.html',
  styleUrls: ['./teklif-add.component.css']
})
export class TeklifAddComponent implements OnInit {

  teklifAddForm:FormGroup;

  constructor(private formBuilder:FormBuilder,private teklifService:TeklifService,private toastrService:ToastrService) { }

  ngOnInit(): void {
    this.createTeklifAddForm();
  }

  createTeklifAddForm(){
    this.teklifAddForm=this.formBuilder.group({
      kullaniciId:["",Validators.required],
      urunId:["",Validators.required],
      miktar:["",Validators.required],
      fiyat:["",Validators.required]

    });

  }

  teklifVer(){
    if(this.teklifAddForm.valid){
      let teklifModel=Object.assign({},this.teklifAddForm.value)
      this.teklifService.teklifVer(teklifModel).subscribe(response=>{

        this.toastrService.success("teklif verildi");
      })
      
     
    }
    else{
      this.toastrService.error("formunuz eksik");
    }
    
  }

}
