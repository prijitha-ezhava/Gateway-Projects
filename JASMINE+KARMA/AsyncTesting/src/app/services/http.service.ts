import { Injectable } from '@angular/core';
import { async } from '@angular/core/testing';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  getAllUsers = async () => {
    const users = [
      {
        id: 1,
        Name: "Prijitha",
        Email: "prijitha@gmail.com",
        password: 12345,
        Address: "Ahmedabad"
      },
      {
        id: 2,
        Name: "Prakash",
        Email: "prakash@gmail.com",
        password: "prakash123",
        Address: "Kheda"
      },
      {
        id: 3,
        Name: "Prijith",
        Email: "prijith@gmail.com",
        password: "prijith123",
        Address: "Manama"
      },
      {
        id: 4,
        Name: "Ajitha",
        Email: "ajitha@gmail.com",
        password: "ajitha123",
        Address: "Ahmedabad"
      }
    ]
    return users;
  }
  constructor() { }
}
