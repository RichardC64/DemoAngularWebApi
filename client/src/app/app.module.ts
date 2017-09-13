import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PersonsComponent } from './persons/persons.component';
import { PersonService } from './services/person.service';
import { CompanyService } from './services/company.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PersonsComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'persons', component: PersonsComponent }
    ])
  ],
  providers: [
    PersonService,
    CompanyService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
