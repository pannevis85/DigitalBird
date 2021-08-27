import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { PartnerService } from '../_models/partnerservice';
import { HelperService } from './helper.service';

@Injectable({
  providedIn: 'root'
})
export class PartnerservicesService {
  baseUrl = environment.apiUrl;

  constructor(private http:HttpClient,
    private helper:HelperService) 
    { }

    getPartnerServices(partnerId: number) {
      //if (this.partners.length > 0) return of(this.partners);
      return this.http.get<PartnerService[]>(this.baseUrl + 'partnerservice/' + partnerId)
      //this pipe is just to create a url for status string to icons
      //this is a list, the array needs to be mapped and within that each element
        .pipe(map(array => {
          array.map(element=> {
            element.statusUrl = this.helper.getStatusUrl(element.status);
            if(element.gdprStatus == undefined) element.gdprStatus = 'warning';
            element.gdprStatusUrl = this.helper.getStatusUrl(element.gdprStatus);
          })
          return array;
        }))     
    }
    updatePartnerService(partnerService: PartnerService) {
      return this.http.put(this.baseUrl + "partnerservice/" + partnerService.id + "/edit", partnerService);
    }
    createPartnerService(partnerService: PartnerService) {
      return this.http.post(this.baseUrl + "partnerservice/create", partnerService);
    }
    deletePartnerService(partnerServiceId: number) {
      return this.http.post(this.baseUrl + "partnerservice/delete/" + partnerServiceId, partnerServiceId);    
    }
}
