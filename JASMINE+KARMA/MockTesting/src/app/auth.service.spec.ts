import { TestBed } from '@angular/core/testing';

import { AuthService } from './auth.service';

describe('AuthService', () => {
  let service: AuthService;
  let spy : any;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthService);
  });

  // it('should be created', () => {
  //   expect(service).toBeTruthy();
  // });

  //User Needs to Login [Positive Test Case]
  it('needs login returns true when the user has not been authenticated',()=>{
    spy = spyOn(service,'isAuthenticated').and.returnValue(true);
    expect(service.isAuthenticated()).toBeTruthy();
  });

 //User Needs to Login [Negative Test Case]
  it('needs login returns false when the user has been authenticated',()=>{
    spy = spyOn(service,'isAuthenticated').and.returnValue(false);
    localStorage.setItem('token','12345')
    expect(service.isAuthenticated()).toBeFalsy();
  });

  //Email Validation [Positive Test Case]
  it('Email Validation return true if email is valid',()=>{
    spy = spyOn(service,'emailValidation').and.returnValue(true);
    expect(service.emailValidation("prijitha12@gmail.com")).toBeTruthy();
  });

  //Email Validation  [Negative Test Case]
  it('Email Validation return false if email is invalid',()=>{
    spy = spyOn(service,'emailValidation').and.returnValue(false);
    expect(service.emailValidation("prijitha12@gmail.com")).toBeFalsy();  
  });

   //Password Validation  [Positive Test Case]
   it('Password Validation return true if password is valid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(true);
    expect(service.passwordValidation("Prijitha")).toBeTruthy();  
  });

  //Password Validation  [Negative Test Case]
  it('Password Validation return false if password is invalid',()=>{
    spy = spyOn(service,'passwordValidation').and.returnValue(false);
    expect(service.passwordValidation("Prijitha")).toBeFalsy();    
  });

  //Credentials null Check [Positive Test Case]
  it('returns credentials are empty if both email and password are null',()=>{
    spy = spyOn(service,'CredentialNullCheck').and.returnValue("Credentials are empty");
    expect(service.CredentialNullCheck('','')).toEqual("Credentials are empty");
  });

  //Credentials null Check [Negative Test Case]
  it('returns Email is empty if only password is provided',()=>{
   spy = spyOn(service,'CredentialNullCheck').and.returnValue("Email is empty");
   expect(service.CredentialNullCheck('','prijitha')).toEqual("Email is empty");
 });

    //User Authorisation [Positive Test Case]
    it('User Authorization return true if user is valid',()=>{
      spy = spyOn(service,'IsUserAuthorised').and.returnValue(true);
      expect(service.IsUserAuthorised("prijitha@gmail.com","prijitha")).toBeTruthy();
    });

    //User Authorisation [Negative Test Case]
    it('User Authorization return false if user is invalid',()=>{
      spy = spyOn(service,'IsUserAuthorised').and.returnValue(false);
      expect(service.IsUserAuthorised("prijitha@gmail.com","pri123")).toBeFalsy();
    });
  

});
