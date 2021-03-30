import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  add(num1:any, num2:any){
    if(num1==0 && num2==0)
      return 0;
    else
      return num1+num2;
  }
}
