import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTable } from '@angular/material/table';
import { Observable } from 'rxjs';
import { Service } from 'src/app/_models/service';
import { ServicesService } from 'src/app/_services/services.service';

@Component({
  selector: 'app-service-list',
  templateUrl: './service-list.component.html',
  styleUrls: ['./service-list.component.css']
})
export class ServiceListComponent implements OnInit {
  
  dataSource: any;
  displayedColumns = ['name', 'description', 'status', 'action'];
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;

  constructor(private serviceService: ServicesService) { }

  ngOnInit(): void {
    this.dataSource = this.serviceService.getServices();
  }
  
}
