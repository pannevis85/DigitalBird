
import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
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
  partnerId: number;
  partner: Partner;
  isNewPartner: boolean;
  partnerForm: FormGroup;
  agencyList = [{ value: 'OMG', display:"OMG"}, { value:'PHD', display:'PHD'},
    { value:'OMD', display:'OMD'},
    { value:'OTHER', display:'OTHER'}];
  statusList = [{ value: 'New', display:"New"}, 
    { value:'Active', display:'Active'},
    { value:'Inactive', display:'Inactive'},
    { value:'in Process', display:'In process'},
    { value:'Archived', display:'Archived'}];
  
  @ViewChild('editForm') editForm: NgForm;
  mySubscription: any;

  constructor( private partnerService: PartnersService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService
    ) { 
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
         // Trick the Router into believing it's last link wasn't previously loaded
         this.router.navigated = false;
      }
    });
    }

  ngOnInit(): void {
    this.partnerId = Number(this.activatedRoute.snapshot.paramMap.get('partnerid'))
    //when creating new partner, partnerid is missing from url, so it will default to 0
    this.isNewPartner = (this.partnerId === 0) ? true : false;
    if (this.isNewPartner) {
      let newObject = <Partner> {}; 
      this.partner = newObject;
    }
    else { 
      this.loadPartner(); 
    }
  }
  loadPartner() {    
    this.partnerService.getPartner(this.partnerId).subscribe(response => {
      this.partner = response;
    });
  }

  updatePartner() {
    this.partnerService.updatePartner(this.partner).subscribe(response => {
      this.toastr.success("Partner updated");
      this.router.navigateByUrl("partners/" + this.partnerId);
    })
  } 
  createPartner() {
    this.partnerService.createPartner(this.partner).subscribe(response => {
      this.toastr.success("Partner created");
      this.router.navigateByUrl("partners")
    })
  }
  reloadRoute() {
    this.router.navigate([this.router.url]);
  }

}
