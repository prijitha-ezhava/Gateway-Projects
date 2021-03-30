import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-division',
  templateUrl: './division.component.html',
  styleUrls: ['./division.component.css']
})
export class DivisionComponent implements OnInit {

  constructor() { }

  ngOnInit(): void {
  }

  division(num1:any, num2:any){
    if(num2!=0){
      return num1/num2;
    }
    else{
      return 'Divided by error occured';
    }
  }
}
