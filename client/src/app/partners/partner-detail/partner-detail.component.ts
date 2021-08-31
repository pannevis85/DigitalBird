import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Partner } from 'src/app/_models/partner';
import { PartnerService } from 'src/app/_models/partnerservice';
import { PartnersService } from 'src/app/_services/partners.service';
import { PartnerservicesService } from 'src/app/_services/partnerservices.service';
import { PartnerserviceDialogComponent } from '../partnerservices/partnerservice-dialog/partnerservice-dialog.component';

@Component({
  selector: 'app-partner-detail',
  templateUrl: './partner-detail.component.html',
  styleUrls: ['./partner-detail.component.css']
})
export class PartnerDetailComponent implements OnInit {
  partnerId: number;
  partner: Partner;
  services: PartnerService[];

  dataSource: any;
  displayedColumns = ['vendorName', 'serviceName', 'year', 'status', 'action'];
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  mySubscription: any;

  constructor(private partnerService: PartnersService
    , private partnerserviceService:PartnerservicesService
    , private activatedRoute: ActivatedRoute    
    , private router: Router
    , private toastr: ToastrService
    , private dialog: MatDialog
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
    this.loadPartner();
  }
  loadPartner() {
    this.partnerId = Number(this.activatedRoute.snapshot.paramMap.get('partnerid'));
    this.partnerService.getPartner(this.partnerId).subscribe(response => {
      this.partner = response;
    })
    this.loadServices();
  }
  loadServices() {
    this.partnerserviceService.getPartnerServices(this.partnerId).subscribe( response => {
      this.dataSource = response;
    })
  }
  openDialog(action,element) {
    element.action = action;
    let dimensions = { width: "600px", height: "400px"};

    const dialogRef = this.dialog.open(PartnerserviceDialogComponent, {
      width: dimensions.width,
      height: dimensions.height,
      data:element
    });

    dialogRef.afterClosed().subscribe(result => {
      //check if result is empty
      console.log(result);
      
      if (result.event == 'Cancel') return;
      //create object of process returned from dialog
      
      let service:PartnerService = {
        id: result.data.id,
        status: result.data.status,
        partnerId: this.partner.id,
        partnerName: this.partner.name,
        vendorId: 0,
        vendorName: result.data.vendorName,
        serviceId: 0,
        serviceName: result.data.serviceName,
        year: result.data.year,
        note: result.data.note
      };


      if(result.event == 'Add'){
        this.partnerserviceService.createPartnerService(service).subscribe(response => {
          this.toastr.success("Partner service created")
          this.loadPartner();
        });
      }else if(result.event == 'Update'){        
        this.partnerserviceService.updatePartnerService(service).subscribe(response => {
          this.toastr.success("Partner service edited")
          this.loadPartner();
        });
      }else if(result.event == 'Delete'){
        this.partnerserviceService.deletePartnerService(service.id).subscribe(response => {
          this.toastr.success("Partner service deleted")
          this.loadPartner();
        });
      }
    
    });
  }
  openGdprList(row) {
    console.log("this would navigate to gdpr list of " + row.serviceName);
  }
}
