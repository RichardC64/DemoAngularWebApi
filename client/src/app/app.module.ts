import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule} from '@angular/router';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { PersonsComponent } from './persons/persons.component';
import { PersonsService } from './services/persons.service';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    PersonsComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', redirectTo: 'home', pathMatch: 'full' },
      { path: 'home', component: HomeComponent },
      { path: 'persons', component: PersonsComponent }
    ])
  ],
  providers: [PersonsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
