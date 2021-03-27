import { Company, CompanyBranch } from './../icompany';
import { Component, OnInit } from '@angular/core';
import { CrudService } from '../crud.service';
import { Router, ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {
  companyObj:any
  // branches:any;
  constructor(public crudService: CrudService, private route : ActivatedRoute, private router:Router) { }

  ngOnInit(): void {

    // subscribing getById() to retrieve company data by Id
    let companyID = window.localStorage.getItem("companyId");
      this.crudService.getById(companyID).subscribe(data=>{
        console.log(data);
        this.companyObj=data;
        
        // this.branches=this.companyObj.CompanyBranch;
        // console.log(this.branches);
      })
  }

}
