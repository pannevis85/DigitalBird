import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
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

  dataSource: any;
  displayedColumns = ['name', 'group', 'type', 'status', 'action'];
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;

  constructor(private vendorService: VendorsService) { }

  ngOnInit(): void {
    this.dataSource = this.vendorService.getVendors();
  }
  searchVendors() {
    this.dataSource = this.vendorService.searchVendors(this.searchTerm);
  }
  

}
