import { Component, OnInit } from '@angular/core';
import { Partner } from 'src/app/_models/partner';
import { PartnersService } from 'src/app/_services/partners.service';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html',
  styleUrls: ['./partner-list.component.css']
})
export class PartnerListComponent implements OnInit {
  partners: Partner[];

  constructor(private partnerService: PartnersService) {  }

  ngOnInit(): void {
    this.loadPartners();
  }

  loadPartners() {
    this.partnerService.getPartners().subscribe( partners => {
      this.partners = partners
    })
  }
  

}
