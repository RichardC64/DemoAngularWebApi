import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { ICompany } from '../entities/icompany';

@Injectable()
export class CompanyService {
  private apiCompanies = environment.apiUrl + 'company';
  constructor(private httpClient: HttpClient) { }

  loadCompanies(): Observable<ICompany[]> {
    return this.httpClient.get<ICompany[]>(this.apiCompanies);
  }
}
