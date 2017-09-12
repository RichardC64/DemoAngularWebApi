import { Component, OnInit } from '@angular/core';
import { PersonsService } from '../services/persons.service';
import { IPerson } from '../entities/iperson';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent implements OnInit {
  persons: IPerson[];

  constructor(private personsService: PersonsService) { }

  ngOnInit() {
    this.personsService.loadPersons().subscribe(
      persons => { this.persons = persons; },
      error => { console.log('arggg'); }
    );
  }
}
