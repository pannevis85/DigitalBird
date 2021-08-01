import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Service } from 'src/app/_models/service';
import { ServicesService } from 'src/app/_services/services.service';

@Component({
  selector: 'app-service-detail',
  templateUrl: './service-detail.component.html',
  styleUrls: ['./service-detail.component.css']
})
export class ServiceDetailComponent implements OnInit {
  serviceId: number;
  service: Service;
  constructor(private serviceService: ServicesService
    , private activatedRoute: ActivatedRoute) {  }
ngOnInit(): void {
    this.loadService();
  }
  loadService() {
    this.serviceId = Number(this.activatedRoute.snapshot.paramMap.get('serviceid'))
    this.serviceService.getService(this.serviceId).subscribe(response => {
      this.service = response;
    })
  }
}