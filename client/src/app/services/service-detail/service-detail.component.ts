import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
import { Service } from 'src/app/_models/service';
import { Process } from 'src/app/_models/process';
import { ProcessService } from 'src/app/_services/process.service';
import { ServicesService } from 'src/app/_services/services.service';

@Component({
  selector: 'app-service-detail',
  templateUrl: './service-detail.component.html',
  styleUrls: ['./service-detail.component.css']
})
export class ServiceDetailComponent implements OnInit {
  serviceId: number;
  service: Service;
  process: Process[];

  dataSource: any;
  displayedColumns = ['sortOrder', 'category', 'activity', 'note', 'gdprRequirement'];
  
  constructor(
    private serviceService: ServicesService,
    private processService: ProcessService,
    private activatedRoute: ActivatedRoute) {  }

ngOnInit(): void {
    this.loadService();
    
  }
  loadService() {    
    this.serviceId = Number(this.activatedRoute.snapshot.paramMap.get('serviceid'))
    this.serviceService.getService(this.serviceId).subscribe(response => {
      this.service = response;    
    })
    this.loadProcess();    
  }
  loadProcess() {
    this.processService.getProcess(this.serviceId).subscribe(response => {
      this.process = response;
      this.dataSource = response;  
    })    
  }
}