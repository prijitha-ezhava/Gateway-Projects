import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-multiply',
  templateUrl: './multiply.component.html',
  styleUrls: ['./multiply.component.css']
})
export class MultiplyComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  multiplication(num1:any, num2:any){
    if(num1 ==0 && num2==0)
      return 0;
    else
      return num1*num2;
  }

}
