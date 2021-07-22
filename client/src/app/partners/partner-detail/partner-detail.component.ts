import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Partner } from 'src/app/_models/partner';
import { PartnersService } from 'src/app/_services/partners.service';

@Component({
  selector: 'app-partner-detail',
  templateUrl: './partner-detail.component.html',
  styleUrls: ['./partner-detail.component.css']
})
export class PartnerDetailComponent implements OnInit {
  partnerId: number;
  partner: Partner;
  constructor(private partnerService: PartnersService, private activatedRoute: ActivatedRoute) {

    }

  ngOnInit(): void {
    this.loadPartner();
  }

  loadPartner() {
    this.partnerId = Number(this.activatedRoute.snapshot.paramMap.get('partnerid'))
    this.partnerService.getPartner(this.partnerId).subscribe(partner => {
      this.partner = partner;
    })
  }
}
