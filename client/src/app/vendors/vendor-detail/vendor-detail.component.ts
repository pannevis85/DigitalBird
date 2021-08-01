import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Vendor } from 'src/app/_models/vendor';
import { VendorsService } from 'src/app/_services/vendors.service';

@Component({
  selector: 'app-vendor-detail',
  templateUrl: './vendor-detail.component.html',
  styleUrls: ['./vendor-detail.component.css']
})
export class VendorDetailComponent implements OnInit {
  vendorId:number;
  vendor:Vendor;

  constructor(private vendorService:VendorsService
    , private activatedRoute:ActivatedRoute) { }

  ngOnInit(): void {
    this.loadVendor();
  }
  loadVendor() {
    this.vendorId = Number(this.activatedRoute.snapshot.paramMap.get('vendorid'));
    this.vendorService.getVendor(this.vendorId).subscribe(response => {
      this.vendor = response;
    })
  }

}
