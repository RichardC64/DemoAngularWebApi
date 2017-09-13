import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { environment } from '../../environments/environment';
import { ICompanyPersons } from '../entities/icompany-persons';

@Injectable()
export class PersonService {
  private apiPersons = environment.apiUrl + 'person';
  constructor(private httpClient: HttpClient) { }

  loadCompanyPersons(idCompany: number, pageIndex: number, pageSize: number): Observable<ICompanyPersons> {
    const params = new HttpParams()
      .set('id', idCompany.toString())
      .set('pageSize', pageSize.toString())
      .set('pageIndex', pageIndex.toString());

    return this.httpClient.get<ICompanyPersons>(this.apiPersons, { params: params });
  }
}
