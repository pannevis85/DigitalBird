import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Partner } from 'src/app/_models/partner';
import { PartnersService } from 'src/app/_services/partners.service';

@Component({
  selector: 'app-partner-edit',
  templateUrl: './partner-edit.component.html',
  styleUrls: ['./partner-edit.component.css']
})
export class PartnerEditComponent implements OnInit {
  title:string;
  partnerId: number;
  partner: Partner;
  @ViewChild('editForm') editForm: NgForm;
  mySubscription: any;

  constructor( private partnerService: PartnersService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService) { 
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
         // Trick the Router into believing it's last link wasn't previously loaded
         this.router.navigated = false;
      }
    });
    }

  ngOnInit(): void {
    this.loadPartner();
    this.title = "Edit " + this.partner.name.toString();
  }
  loadPartner() {
    this.partnerId = Number(this.activatedRoute.snapshot.paramMap.get('partnerid'))
    this.partnerService.getPartner(this.partnerId).subscribe(partner => {
      this.partner = partner;
    })
  }
  updatePartner() {
    this.partnerService.updatePartner(this.partner).subscribe(response => {
      this.toastr.success("Partner updated");
      this.reloadRoute();
    })
  }
  reloadRoute() {
    this.router.navigate([this.router.url]);
  }

}
