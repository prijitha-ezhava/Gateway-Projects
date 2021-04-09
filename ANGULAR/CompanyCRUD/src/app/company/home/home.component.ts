import { CrudService } from './../crud.service';
import { Company } from './../icompany';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  companies : Company[] = [];
 
  constructor(public crudService: CrudService, private router : Router,  public toastr: ToastrService
  ) {
  }
    

  ngOnInit(): void {  

    // subscribing getAll() to retrieve all companies data
    this.crudService.getAll().subscribe((data : Company[])=>{
      console.log(data);
      this.companies = data;
  })
  }

  //delete click event method
  deleteData(company:Company){
    this.crudService.delete(company.id).subscribe(data=>{
      this.crudService.getAll().subscribe((data:Company[])=>{
        this.companies=data;
      });
      this.toastr.success('Successfully deleted!');
    });
  };


  //Edit  click event method
  editData(company:Company):void{
    localStorage.removeItem('companyId');
    localStorage.setItem('companyId', company.id.toString());
    this.router.navigate(['update']);
  }

  //Detail click event method
  detailData(company :Company):void{
    localStorage.removeItem('companyId');
    localStorage.setItem('companyId', company.id.toString());
    this.router.navigate(['details']);
  }
  
}
