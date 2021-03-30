import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  @Input() name!: string ;
  @Output() readonly speak = new EventEmitter<string>();
  constructor() { }

  ngOnInit(): void {
  }

  sayHello() {
    this.speak.emit('Hello');
  }

   sayGoodbye() {
    this.speak.emit('Goodbye');
   }

  

}
