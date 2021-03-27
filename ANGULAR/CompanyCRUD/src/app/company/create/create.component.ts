import { CompanyBranch } from './../icompany';
import { ActivatedRoute, Router } from '@angular/router';
import { CrudService } from './../crud.service';
import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';


@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.css']
})
export class CreateComponent implements OnInit {
  form! : FormGroup;
  companyBranch!: FormArray;
  constructor(private crudService :CrudService,private router:Router,private formBuilder: FormBuilder, private avRoute: ActivatedRoute) { }

  btnvisibility = true;
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      id: [],
      email: new FormControl('', [Validators.required, Validators.email]),
      name: new FormControl('', Validators.required),
      totalEmployee: new FormControl('', Validators.required),
      address: new FormControl('', Validators.required),
      isCompanyActive: new FormControl(''),
      totalBranch: new FormControl('', Validators.required),
      companyBranch: this.formBuilder.array([ ])
    });
  }

  createItem(): FormGroup {
    return this.formBuilder.group({
      branchId: new FormControl('',[Validators.required]),
      branchName: new FormControl('',[Validators.required]),
      branchAddress: new FormControl('',[Validators.required])
    });
  }
  addBranch(): void {
    debugger;
    this.companyBranch = this.form.get('companyBranch') as FormArray;
    this.companyBranch.push(this.createItem());
  }

  getControls() {
    return (this.form.get('companyBranch') as FormArray).controls;
  }

  removeBranch(index: number) {
    this.companyBranch.removeAt(index);
  }
  get formdata(){
    return this.form.controls;
  }

  onSubmit() {

    console.log('Create fire');
    debugger;
    this.crudService.create(this.form.value)
      .subscribe(data => {
        this.router.navigate(['home']);
      },
      error => {
        alert(error);
      });
  }

}
