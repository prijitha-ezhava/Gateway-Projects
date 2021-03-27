import { HttpClientModule } from '@angular/common/http';
import { CrudService } from './company/crud.service';
import { CompanyModule } from './company/company.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
// import { AngularFontAwesomeModule } from 'angular-font-awesome';

@NgModule({
  declarations: [
    AppComponent,
   
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    CompanyModule,
    FormsModule,
    ReactiveFormsModule
    //AngularFontAwesomeModule
  ],
  providers: [CrudService],
  bootstrap: [AppComponent]
})
export class AppModule { }
