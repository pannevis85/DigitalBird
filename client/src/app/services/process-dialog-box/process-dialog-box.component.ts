import { Inject, Optional } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Process } from 'src/app/_models/process';

@Component({
  selector: 'app-process-dialog-box',
  templateUrl: './process-dialog-box.component.html',
  styleUrls: ['./process-dialog-box.component.css']
})
export class ProcessDialogBoxComponent {
  
  action:string;
  local_data:any;
  constructor(
    public dialogRef: MatDialogRef<ProcessDialogBoxComponent>,
    //@Optional() is used to prevent error if no data is passed
    @Optional() @Inject(MAT_DIALOG_DATA) public data: Process) {
    console.log(data);
    this.local_data = {...data};
    this.action = this.local_data.action;
  }

  doAction(){    
    this.dialogRef.close({event:this.action,data:this.local_data});
    
  }

  closeDialog(){
    this.dialogRef.close({event:'Cancel'});
  }


}
