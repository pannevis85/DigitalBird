import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { MatTable } from '@angular/material/table';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Process } from 'src/app/_models/process';
import { Service } from 'src/app/_models/service';
import { ProcessService } from 'src/app/_services/process.service';
import { ServicesService } from 'src/app/_services/services.service';
import { ProcessDialogBoxComponent } from '../process-dialog-box/process-dialog-box.component';


@Component({
  selector: 'app-process-edit',
  templateUrl: './process-edit.component.html',
  styleUrls: ['./process-edit.component.css']
})
export class ProcessEditComponent implements OnInit {
  serviceId:number;
  service:Service;
  process:Process[];
  
  displayedColumns: string[] = ['sortOrder', 'category', 'activity', 'note', 'gdprRequirement', 'action'];
  dataSource: any;  
  @ViewChild(MatTable,{static:true}) table: MatTable<any>;
  mySubscription: any;

  constructor(
    private serviceService: ServicesService,
    private processService: ProcessService,
    private activatedRoute:ActivatedRoute,
    private router: Router,
    private toastr: ToastrService,
    private dialog: MatDialog) { 
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
         // Trick the Router into believing it's last link wasn't previously loaded
         this.router.navigated = false;
      }
    });
    }

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
  updateProcess() {
    this.toastr.info("update should be done")
  }

  openDialog(action,element) {
    element.action = action;
    let dimensions = { width: "600px", height: "600px"};
    if (action === "Delete"){
      dimensions.height = "300px"
    }

    const dialogRef = this.dialog.open(ProcessDialogBoxComponent, {
      width: dimensions.width,
      height: dimensions.height,
      data:element
    });

    dialogRef.afterClosed().subscribe(result => {
      //check if result is empty
      if(result == undefined) return;
      //create object of process returned from dialog
      let processStep:Process = {
        id: result.data.id,
        name: result.data.name,
        status: result.data.status,
        serviceId: this.service.id,
        serviceName: this.service.name,
        category: result.data.category,
        activity: result.data.activity,
        note: result.data.note,
        gdprRequirement: result.data.gdprRequirement,
        sortOrder: result.data.sortOrder
      };

      if(result.event == 'Add'){
        this.processService.updateProcess(processStep).subscribe(response => {
          this.toastr.success("Process created")
        })
      }else if(result.event == 'Update'){        
        this.processService.createProcess(processStep).subscribe(response => {
          this.toastr.success("Process updated")
        })
      }else if(result.event == 'Delete'){
        this.processService.deleteProcess(processStep.id).subscribe(response => {
          this.toastr.success("Process deleted")
        })
      }
      this.router.navigate([this.router.url]);
    });
    
  }

}
