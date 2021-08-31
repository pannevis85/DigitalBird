import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { GdprRecord } from '../_models/gdprrecord';
import { HelperService } from './helper.service';

@Injectable({
  providedIn: 'root'
})
export class GdprService {
  baseUrl = environment.apiUrl;
  gdprList: GdprRecord[] = [];

  constructor(
        private http: HttpClient,
        private helper: HelperService,
        ) { }

  getGdprList(partnerId: number, vendorId: number, serviceId: number, year: number) {
    return this.http.get<GdprRecord[]>(this.baseUrl + 'gdpr/processlist/' + partnerId + '/' + vendorId + '/' + serviceId + '/' + year)
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
      .pipe(map(array => {
        array.map(element=> {
          if(element.status == "false") element.contractStatus = 'Doesnt exist'
          element.statusUrl = this.helper.getStatusUrl(element.status);
          
        })
        this.gdprList = array;        
        return array;
      }))      
  }
  getGdprRecord(gdprId: number) {
    return this.http.get<GdprRecord>(this.baseUrl + "gdpr/" + gdprId);
  }
  updateGdpr(gdpr: GdprRecord) {
    return this.http.put(this.baseUrl + "gdpr/edit/" + gdpr.id , gdpr);
  }
  createGdpr(gdpr: GdprRecord) {
    return this.http.post(this.baseUrl + "gdpr/create", gdpr);
  }
  deleteGdpr(gdprId: number) {
    return this.http.post(this.baseUrl + "gdpr/delete/" + gdprId, gdprId);    
  }
}
