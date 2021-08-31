import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { GdprRecord } from 'src/app/_models/gdprrecord';
import { GdprService } from 'src/app/_services/gdpr.service';

@Component({
  selector: 'app-gdpr-list',
  templateUrl: './gdpr-list.component.html',
  styleUrls: ['./gdpr-list.component.css']
})
export class GdprListComponent implements OnInit {
  partnerId: number;
  vendorId: number;
  serviceId: number;
  
  year: number;  
  gdprList: GdprRecord[];
  dataSource: any;
  displayedColumns = ['category', 'activity', 'gdprRequirement', 'status', 'contractStatus', 'action'];
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  mySubscription: any;


  constructor(
    private gdprService: GdprService
    , private activatedRoute: ActivatedRoute    
    , private router: Router
    , private toastr: ToastrService
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
    this.loadGdprList()
  }
  loadGdprList() {
    this.partnerId = Number(this.activatedRoute.snapshot.paramMap.get('partnerid'));
    this.vendorId = Number(this.activatedRoute.snapshot.paramMap.get('vendorid'));
    this.serviceId = Number(this.activatedRoute.snapshot.paramMap.get('serviceid'));
    this.year = Number(this.activatedRoute.snapshot.paramMap.get('year'));
    this.gdprService.getGdprList(this.partnerId, this.vendorId, this.serviceId, this.year).subscribe(response => {
      if (response.length !== 0) {
        this.dataSource = response;
      }
      
      console.log(response);
    });
    
  }
  createGdprRecord(gdpr: GdprRecord) {
    this.gdprService.createGdpr(gdpr).subscribe(response => {
      this.toastr.success("Gdpr record created");
      this.loadGdprList();
    })
  }
  deleteGdprRecord(gdprId: number) {
    this.gdprService.deleteGdpr(gdprId).subscribe(response => {
      this.toastr.success("Gdpr record deleted");
      this.loadGdprList();
    })
  }

}
