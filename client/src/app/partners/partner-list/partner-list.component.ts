import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { Observable } from 'rxjs';
import { Partner } from 'src/app/_models/partner';
import { PartnersService } from 'src/app/_services/partners.service';

@Component({
  selector: 'app-partner-list',
  templateUrl: './partner-list.component.html',
  styleUrls: ['./partner-list.component.css']
})
export class PartnerListComponent implements OnInit {
  
  searchTerm: string = '';
  filterSelection: string = '';

  dataSource: any;
  displayedColumns = ['name', 'group', 'agency', 'status', 'action'];
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;

  constructor(private partnerService: PartnersService) {  }

  ngOnInit(): void {
    this.dataSource = this.partnerService.getPartners();
    
  }
  searchPartners() {
    this.dataSource = this.partnerService.searchPartners(this.searchTerm);
  }  
}
