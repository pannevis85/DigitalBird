import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { of } from 'rxjs';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Partner } from '../_models/partner';
import { HelperService } from './helper.service';


@Injectable({
  providedIn: 'root'
})
export class PartnersService {
  baseUrl = environment.apiUrl;
  partners: Partner[] = [];

  //currentPartner$: Partner;

  constructor(private http: HttpClient, private helper:HelperService) {
  }

  getPartners() {
    //if (this.partners.length > 0) return of(this.partners);
    return this.http.get<Partner[]>(this.baseUrl + 'partners')
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
      .pipe(map(array => {
        array.map(partner=> {
          partner.statusUrl = this.helper.getStatusUrl(partner.status)
        })
        this.partners = array;        
        return array;
      }))      
  }
  searchPartners(searchTerm:string) {
    if (searchTerm.length === 0) return this.getPartners();
    //if (this.partners.length > 0) return of(this.partners);
    return this.http.get<Partner[]>(this.baseUrl + 'partners/search/' + searchTerm)
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
      .pipe(map(array => {
        array.map(element=> {
          element.statusUrl = this.helper.getStatusUrl(element.status)
        })
        this.partners = array;        
        return array;
    }))      
  }

  getPartner(partnerId: number) {
    //const partner = this.partners.find(p => p.id === partnerId);
    //if (partner !== undefined) return of(partner);
    return this.http.get<Partner>(this.baseUrl + 'partners/' + partnerId);
  }
  updatePartner(partner: Partner) {
    return this.http.put(this.baseUrl + "partners/" + partner.id + "/edit",partner);
  }
  createPartner(partner: Partner) {
    return this.http.post(this.baseUrl + "partners/create", partner);
  }
  
}
