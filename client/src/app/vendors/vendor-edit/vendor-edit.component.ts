import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Vendor } from 'src/app/_models/vendor';
import { VendorsService } from 'src/app/_services/vendors.service';

@Component({
  selector: 'app-vendor-edit',
  templateUrl: './vendor-edit.component.html',
  styleUrls: ['./vendor-edit.component.css']
})
export class VendorEditComponent implements OnInit {
  vendorId: number;
  vendor: Vendor;
  isNewVendor: boolean;
  @ViewChild('editForm') editForm: NgForm;
  mySubscription: any;

  constructor( private vendorService: VendorsService,
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
    this.vendorId = Number(this.activatedRoute.snapshot.paramMap.get('vendorid'))
    //when creating new partner, partnerid is missing from url, so it will default to 0
    //0 represents new partner
    this.isNewVendor = (this.vendorId === 0) ? true : false;
    if(this.isNewVendor) {
      let newObject = <Vendor> { }
      this.vendor = newObject;
    }
    else {
      this.loadVendor();
    }    
  }
  loadVendor() {
    this.vendorService.getVendor(this.vendorId).subscribe(response => {
      this.vendor = response;
    })
  }
  updateVendor() {
    this.vendorService.updateVendor(this.vendor).subscribe(response => {
      this.toastr.success("Vendor updated");
      this.router.navigateByUrl("vendors/" + this.vendorId);
    })
  }
  createVendor() {
    this.vendorService.createVendor(this.vendor).subscribe(response => {
      this.toastr.success("Vendor created");
      this.router.navigateByUrl("vendors")
    })
  }
  reloadRoute() {
    this.router.navigate([this.router.url]);
  }

}
