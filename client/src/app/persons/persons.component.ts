import { Component, OnInit } from '@angular/core';

import { PersonService } from '../services/person.service';
import { CompanyService } from '../services/company.service';
import { ICompany } from '../entities/icompany';
import { ICompanyPersons } from '../entities/icompany-persons';

@Component({
  selector: 'app-persons',
  templateUrl: './persons.component.html',
  styleUrls: ['./persons.component.css']
})
export class PersonsComponent implements OnInit {
  companyPersons: ICompanyPersons;
  companies: ICompany[];
  private _selectedCompany: ICompany;
  pageIndexes: number[];
  pageSize = 5;
  currentPageIndex = 0;

  constructor(
    private personService: PersonService,
    private companyService: CompanyService) { }

  ngOnInit() {
    this.companyService.loadCompanies().subscribe(
      companies => {
        this.companies = companies;
        this.selectedCompany = companies[0];
      },
      error => { console.log('arggg'); }
    );
  }

  public get selectedCompany(): ICompany {
    return this._selectedCompany;
  }
  public set selectedCompany(v: ICompany) {
    this._selectedCompany = v;
    this.currentPageIndex = 0;
    this.loadPersons();
  }

  private loadPersons() {
    this.companyPersons = null;
    this.pageIndexes = [];
    if (this.selectedCompany == null) {
      return;
    }
    this.personService.loadCompanyPersons(this.selectedCompany.id, this.currentPageIndex, this.pageSize).subscribe(
      persons => {
        this.companyPersons = persons;
        for (let index = 1; index < Math.ceil(this.companyPersons.totalCount / this.pageSize) + 1; index++) {
          this.pageIndexes.push(index);
        }
      },
      error => { console.log('PersonService: arggg'); }
    );

  }

  onChangePageIndex(pageIndex: number) {
    this.currentPageIndex = pageIndex - 1;
    this.loadPersons();
  }

}
