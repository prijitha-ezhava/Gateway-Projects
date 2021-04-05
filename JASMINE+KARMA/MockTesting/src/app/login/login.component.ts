import { AuthService } from './../auth.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private auth:AuthService) { }

  ngOnInit(): void {
  }

  //User needs to be logged in using token
  needsLogin(){
    return !this.auth.isAuthenticated();
  }

  //Email Validation using regular expression
  validateEmail(email:any){
    return this.auth.emailValidation(email);
  }

  //Password Validation using regular expression
  validatePassword(password:any){
    return this.auth.passwordValidation(password);
  }

  //Checking if the user's login credentials aren't null or empty
  IsCredentialsEmpty(email:any, password:any){
    return this.auth.CredentialNullCheck(email,password);
  }

  //Validating the user using email and password
  IsUserValid(email:any, password:any){
    return this.auth.IsUserAuthorised(email,password);
  }

}