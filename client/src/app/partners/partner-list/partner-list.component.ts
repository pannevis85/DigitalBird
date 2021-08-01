import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Partner } from 'src/app/_models/partner';
import { PartnersService } from 'src/app/_services/partners.service';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html',
  styleUrls: ['./partner-list.component.css']
})
export class PartnerListComponent implements OnInit {
  partners$: Observable<Partner[]>;
  searchTerm: string = '';
  filterSelection: string = '';

  constructor(private partnerService: PartnersService) {  }

  ngOnInit(): void {
    this.partners$ = this.partnerService.getPartners();
  }
  searchPartners() {
    this.partners$ = this.partnerService.searchPartners(this.searchTerm);
  }
  
}
