import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-subtract',
  templateUrl: './subtract.component.html',
  styleUrls: ['./subtract.component.css']
})
export class SubtractComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  subtraction(num1:any, num2:any){
    return num1-num2;
  }
}
