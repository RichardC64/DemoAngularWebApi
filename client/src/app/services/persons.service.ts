import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { IPerson } from '../entities/iperson';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';

@Injectable()
export class PersonsService {
  private apiPersons = environment.apiUrl + 'persons';
  constructor(private httpClient: HttpClient) { }

  loadPersons(): Observable<IPerson[]> {
    return this.httpClient.get<IPerson[]>(this.apiPersons);
  }
}
