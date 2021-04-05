import { AuthService } from './../auth.service';
import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LoginComponent } from './login.component';


// export class MockAuthService{
//   authenticated  =false;
//   isEmailValid = false;
//   isPasswordValid = false;
//   msg= '';
//   validUser = false;

//   isAuthenticated():boolean{
//     return this.authenticated;
//   }

//   emailValidation(email) : boolean{
//     return this.isEmailValid;
//   }

//   passwordValidation(password) : boolean{
//     return this.isPasswordValid;
//   }

//   CredentialNullCheck(email,password){
//     return this.msg;
//   }

//   IsUserAuthorised(email,password){
//     return this.validUser;
//   }
// }

describe('LoginComponent', () => {
  let login: LoginComponent;
  let service: AuthService;
  let spy :any;

  // let fixture: ComponentFixture<LoginComponent>;

  // beforeEach(async () => {
  //   await TestBed.configureTestingModule({
  //     declarations: [ LoginComponent ]
  //   })
  //   .compileComponents();
  // });

  // beforeEach(() => {
  //   fixture = TestBed.createComponent(LoginComponent);
  //   component = fixture.componentInstance;
  //   fixture.detectChanges();
  // });

  // it('should create', () => {
  //   expect(component).toBeTruthy();
  // });

  beforeEach(()=>{
    service = new AuthService();
    login = new LoginComponent(service);
  })

  afterEach(()=>{
    service=null;
    login=null;
  })

  //User Needs to Login [Positive Test Case]
  it('needs login returns true when the user has not been authenticated',()=>{
    spy = spyOn(service,'isAuthenticated').and.returnValue(false);
    expect(login.needsLogin()).toBeTruthy();
    expect(service.isAuthenticated).toHaveBeenCalled();
  });

 //User Needs to Login [Negative Test Case]
  it('needs login returns false when the user has been authenticated',()=>{
    spy = spyOn(service,'isAuthenticated').and.returnValue(true);
    localStorage.setItem('token','12345')
    expect(login.needsLogin()).toBeFalsy();
    expect(service.isAuthenticated).toHaveBeenCalled();
  });


  //Email Validation [Positive Test Case]
  it('Email Validation return true if email is valid',()=>{
    spy = spyOn(service,'emailValidation').and.returnValue(true);
    expect(login.validateEmail("prijitha12@gmail.com")).toBeTruthy();
    expect(service.emailValidation).toHaveBeenCalled();    
  });

  //Email Validation  [Negative Test Case]
  it('Email Validation return false if email is invalid',()=>{
    spy = spyOn(service,'emailValidation').and.returnValue(false);
    expect(login.validateEmail("prijitha12@gmail.com")).toBeFalsy();
    expect(service.emailValidation).toHaveBeenCalled();    
  });

  //Password Validation  [Positive Test Case]
  it('Password Validation return true if password is valid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(true);
    expect(login.validatePassword("Prijitha")).toBeTruthy();
    expect(service.passwordValidation).toHaveBeenCalled();    
  });

  //Password Validation  [Negative Test Case]
  it('Password Validation return false if password is invalid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(false);
    expect(login.validatePassword("Prijitha")).toBeFalsy();
    expect(service.passwordValidation).toHaveBeenCalled();    
  });

  //Credentials null Check [Positive Test Case]
   it('returns credentials are empty if both email and password are null',()=>{
     spy = spyOn(service,'CredentialNullCheck').and.returnValue("Credentials are empty");
     expect(login.IsCredentialsEmpty('','')).toEqual("Credentials are empty");
     expect(service.CredentialNullCheck).toHaveBeenCalled();   
   });

   //Credentials null Check [Negative Test Case]
   it('returns Email is empty if only password is provided',()=>{
    spy = spyOn(service,'CredentialNullCheck').and.returnValue("Email is empty");
    expect(login.IsCredentialsEmpty('','prijitha')).toEqual("Email is empty");
    expect(service.CredentialNullCheck).toHaveBeenCalled();   
  });

    //User Authorisation [Positive Test Case]
    it('User Authorization return true if user is valid',()=>{
      spy = spyOn(service,'IsUserAuthorised').and.returnValue(true);
      expect(login.IsUserValid("prijitha@gmail.com","prijitha")).toBeTruthy();
      expect(service.IsUserAuthorised).toHaveBeenCalled();    
    });

    //User Authorisation [Negative Test Case]
    it('User Authorization return false if user is invalid',()=>{
      spy = spyOn(service,'IsUserAuthorised').and.returnValue(false);
      expect(login.IsUserValid("prijitha@gmail.com","pri123")).toBeFalsy();
      expect(service.IsUserAuthorised).toHaveBeenCalled();    
    });
  
});
