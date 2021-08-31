import { Component, Inject, OnInit, Optional } from '@angular/core';
import { FormControl } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Service } from 'src/app/_models/service';
import { Vendor } from 'src/app/_models/vendor';
import { ServicesService } from 'src/app/_services/services.service';
import { VendorsService } from 'src/app/_services/vendors.service';

@Component({
  selector: 'app-partnerservice-dialog',
  templateUrl: './partnerservice-dialog.component.html',
  styleUrls: ['./partnerservice-dialog.component.css']
})
export class PartnerserviceDialogComponent {
  action:string;
  local_data:any;
  serviceList:Service[] = [];
  vendorList:Vendor[] = [];
  yearList: number[] = [2019, 2020, 2021, 2022, 2023];
  statusList: string[] = ['Active', 'Inactive', 'Terminated', 'Suspended', 'In Process', 'Setup stage'];
  constructor(
    public dialogRef: MatDialogRef<PartnerserviceDialogComponent>
    , private serviceService: ServicesService
    , private vendorService: VendorsService
    //@Optional() is used to prevent error if no data is passed
    ,@Optional() @Inject(MAT_DIALOG_DATA) public data: any) {
    //console.log(data);
    this.local_data = {...data};
    this.action = this.local_data.action;
    
    this.serviceService.getServices().subscribe(response => {
      this.serviceList = response;
    });
    this.vendorService.getVendors().subscribe(response => {
      this.vendorList = response;
    })
    
  }

  doAction(){    
    this.dialogRef.close({event:this.action,data:this.local_data});
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }
}
