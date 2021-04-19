import { SignInComponent } from './../../components/sign-in/sign-in.component';
import { Injectable, NgZone } from '@angular/core';
import { User } from "../services/user";
import { auth } from 'firebase/app';
import { AngularFirestore, AngularFirestoreDocument } from '@angular/fire/firestore';
import { Router } from "@angular/router";
import { AngularFireAuth } from '@angular/fire/auth';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  userData: any;

  constructor(public afs: AngularFirestore,public afAuth: AngularFireAuth,public router: Router, public ngZone: NgZone) { 
    
    /* Saving user data in localstorage when 
    logged in and setting up null when logged out */
    this.afAuth.authState.subscribe(user=>{
      if(user){
        this.userData=user;
        localStorage.setItem('user', JSON.stringify(this.userData));
        JSON.parse(localStorage.getItem('user')|| '{}');
      }
      else{
        localStorage.setItem('user', '');
        JSON.parse(localStorage.getItem('user')|| '{}');
      }
    })
  }

  //Sign using email and Password

  SignIn(email: any,password: any)
  {
    return this.afAuth.auth.signInWithEmailAndPassword(email,password)
    .then((result: { user: any; })=>{
      this.ngZone.run(()=>{
        this.router.navigate(['dashboard']);
      });
      this.SetUserData(result.user);
    }).catch((error: { message: any; })=>{
      window.alert(error.message)
    })
  }

  // Sign up with email/password
  SignUp(email: any, password: any) {
    return this.afAuth.auth.createUserWithEmailAndPassword(email, password)
      .then((result: { user: any; }) => {
        /* Call the SendVerificaitonMail() function when new user sign 
        up and returns promise */
        this.SendVerificationMail();
        this.SetUserData(result.user);
      }).catch((error: { message: any; }) => {
        window.alert(error.message)
      })
  }

   // Reset Forggot password
   ForgotPassword(passwordResetEmail: any) {
    return this.afAuth.auth.sendPasswordResetEmail(passwordResetEmail)
    .then(() => {
      window.alert('Password reset email sent, check your inbox.');
    }).catch((error: any) => {
      window.alert(error.message)
    })
  }

   // Send email verfificaiton when new user sign up
   SendVerificationMail() {
    return this.afAuth.auth.currentUser.sendEmailVerification()
    .then(() => {
      this.router.navigate(['verify-email-address']);
    })
  }

  // Sign in with Google
  GoogleAuth() {
    return this.AuthLogin(new auth.GoogleAuthProvider());
  }  

  // Auth logic to run auth providers
  AuthLogin(provider: any) {
    return this.afAuth.auth.signInWithPopup(provider)
    .then((result: { user: any; }) => {
       this.ngZone.run(() => {
          this.router.navigate(['dashboard']);
        })
      this.SetUserData(result.user);
    }).catch((error: any) => {
      window.alert(error)
    })
  }

  SetUserData(user: { uid: any; email: any; displayName: any; photoURL: any; emailVerified: any; }) {
    const userRef: AngularFirestoreDocument<any> = this.afs.doc(`users/${user.uid}`);
    const userData: User = {
      uid: user.uid,
      email: user.email,
      displayName: user.displayName,
      photoURL: user.photoURL,
      emailVerified: user.emailVerified
    }
    return userRef.set(userData, {
      merge: true
    })
  }

  // Sign out 
  SignOut() {
    return this.afAuth.auth.signOut().then(() => {
      localStorage.removeItem('user');
      this.router.navigate(['sign-in']);
    })
  }
}
