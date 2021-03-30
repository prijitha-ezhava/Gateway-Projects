import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';

import { UserComponent } from './user/user.component';
import { SubtractComponent } from './subtract/subtract.component';
import { MultiplyComponent } from './multiply/multiply.component';
import { DivisionComponent } from './division/division.component';
import { AddComponent } from './add/add.component';

@NgModule({
  declarations: [
    AppComponent,
    UserComponent,
    SubtractComponent,
    MultiplyComponent,
    DivisionComponent,
    AddComponent
  ],
  imports: [
    BrowserModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
