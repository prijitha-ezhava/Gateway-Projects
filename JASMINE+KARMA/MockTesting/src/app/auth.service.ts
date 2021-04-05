import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
 msg: string;
  constructor() { }

  //User authentication using tokens
  isAuthenticated():boolean{
    return !localStorage.getItem('token');
  }

  //Email validation using regular expression
  emailValidation(email) : boolean{
    const regularExpression = /^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$/;
    return regularExpression.test(String(email).toLowerCase());
  }

  //Password validation using regular expression
  passwordValidation(password) : boolean{
    const regularExpression = /(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})/;
    return regularExpression.test(String(password));
  }


  //Checking if Email and Password is null or not
  CredentialNullCheck(email,password){
    if(email==null && password==null)
    {
      this.msg = "Both are empty";
      return this.msg;
    }
    else if(email==null && password==password)
    {
      this.msg = "Email is empty";
      return this.msg;
    }
    else
    {
      this.msg = "Credentials are okay";
      return this.msg;
    }
  }


  //User Authorization using email and password
  IsUserAuthorised(email:any, password:any){
    if(email=="prijitha@gmail.com" && password=="prijitha"){
      return true;
    }
    else
      return false;
  }
}
