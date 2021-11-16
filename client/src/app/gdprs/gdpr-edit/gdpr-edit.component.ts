import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { GdprRecord } from 'src/app/_models/gdprrecord';
import { GdprService } from 'src/app/_services/gdpr.service';

@Component({
  selector: 'app-gdpr-edit',
  templateUrl: './gdpr-edit.component.html',
  styleUrls: ['./gdpr-edit.component.css']
})
export class GdprEditComponent implements OnInit {
  gdprId: number;
  gdprRecord: GdprRecord;
  contractStatusList = [
    { value:'Blank record', display:'Blank Record'}, 
    { value:'New', display:'New'}, 
    { value:'Active', display:'Active'},
    { value:'Inactive', display:'Inactive'},
    { value:'In process', display:'In process'},
    { value:'Under negotiation', display:'Under negotiation'},
    { value:'Waiting for partner', display:'Waiting for partner'},
    { value:'Signed', display:'Signed'},
    { value:'Archived', display:'Archived'}];
  statusList = [
    { value:'Blank record', display:'Blank Record'}, 
    { value:'New', display:'New'}, 
    { value:'Active', display:'Active'},
    { value:'Inactive', display:'Inactive'},
    { value:'In process', display:'In process'},
    { value:'Completed', display:'Completed'},
    { value:'Archived', display:'Archived'}];
  lawList = ['EU Gdpr','US Big Eye','NSA'];
  
  @ViewChild('editForm') editForm: NgForm;
  
  constructor(
    private gdprService: GdprService
    , private activatedRoute: ActivatedRoute    
    , private router: Router
    , private toastr: ToastrService
  ) { }

  ngOnInit(): void {
    this.loadGdpr()
  }
  loadGdpr() {
    this.gdprId = Number(this.activatedRoute.snapshot.paramMap.get('gdprid'));
    this.gdprService.getGdprRecord(this.gdprId).subscribe(response => {
      this.gdprRecord = response;
      console.log(response);
    })
  }
  updateGdpr() {
    console.log(this.gdprRecord);
    this.gdprService.updateGdpr(this.gdprRecord).subscribe(response => {
      this.toastr.success("Gdpr record updated")
      this.loadGdpr();
      this.editForm.onReset();
    })
  }
}
