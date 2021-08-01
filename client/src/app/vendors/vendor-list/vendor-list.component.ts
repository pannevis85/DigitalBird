import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Vendor } from 'src/app/_models/vendor';
import { VendorsService } from 'src/app/_services/vendors.service';

@Component({
  selector: 'app-vendor-list',
  templateUrl: './vendor-list.component.html',
  styleUrls: ['./vendor-list.component.css']
})
export class VendorListComponent implements OnInit {
  vendors$: Observable<Vendor[]>;  
  searchTerm: string = '';
  filterSelection: string = '';

  constructor(private vendorService: VendorsService) { }

  ngOnInit(): void {
    this.vendors$ = this.vendorService.getVendors();
  }
  searchVendors() {
    this.vendors$ = this.vendorService.searchVendors(this.searchTerm);
  }
  

}
