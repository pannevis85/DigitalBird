import { Component, OnInit, ViewChild } from '@angular/core';
import { FormGroup, NgForm } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Service } from 'src/app/_models/service';
import { ServicesService } from 'src/app/_services/services.service';

@Component({
  selector: 'app-service-edit',
  templateUrl: './service-edit.component.html',
  styleUrls: ['./service-edit.component.css']
})
export class ServiceEditComponent implements OnInit {
  serviceId:number;
  service:Service;
  isNewService:boolean;
  statusList = [{ value: 'Primary', display:"Primary"}, 
    { value:'Active', display:'Active'},
    { value:'Inactive', display:'Inactive'},
    { value:'Archived', display:'Archived'}];
    
    serviceForm: FormGroup;
    @ViewChild('editForm') editForm: NgForm;
    mySubscription: any;
  
  constructor(private serviceService: ServicesService,
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
    
    this.serviceId = Number(this.activatedRoute.snapshot.paramMap.get('serviceid'))
    //when creating new partner, partnerid is missing from url, so it will default to 0
    this.isNewService = (this.serviceId === 0) ? true : false;
    if (this.isNewService) {
      let newObject = <Service> {}; 
      this.service = newObject;
    }
    else { 
      console.log(this.serviceId + " is serviceId");
      this.loadService(); 
    }
  }
  loadService() {        
    this.serviceService.getService(this.serviceId).subscribe(response => {
      this.service = response;      
    });
  }
  updateService() {
    this.serviceService.updateService(this.service).subscribe(response => {
      this.toastr.success("Service updated");
      this.router.navigateByUrl("services/" + this.serviceId);
    })
  }
  createService() {
    this.serviceService.createService(this.service).subscribe(response => {
      this.toastr.success("Service created");
      this.router.navigateByUrl("services")
    })
  }
  reloadRoute() {
    this.router.navigate([this.router.url]);
  }

}
