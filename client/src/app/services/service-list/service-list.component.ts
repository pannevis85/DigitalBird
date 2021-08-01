import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Service } from 'src/app/_models/service';
import { ServicesService } from 'src/app/_services/services.service';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrls: ['./service-list.component.css']
})
export class ServiceListComponent implements OnInit {
  services$: Observable<Service[]>;

  constructor(private serviceService: ServicesService) { }

  ngOnInit(): void {
    this.services$ = this.serviceService.getServices();
  }
  
}
