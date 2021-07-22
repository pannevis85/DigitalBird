import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Partner } from '../_models/partner';


@Injectable({
  providedIn: 'root'
})
export class PartnersService {
  baseUrl = environment.apiUrl;
  partners: Partner[] = [];
  currentPartner$: Partner;

  constructor(private http: HttpClient) {

  }

  getPartners() {
    //return this.http.get<Partner[]>(this.baseUrl + 'partners');    
    return this.http.get<Partner[]>(this.baseUrl + 'partners')
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
      .pipe(map(array => {
        array.map(partner=> {
          partner.statusUrl = this.getPartnerStatusUrl(partner.status)
          return partner;
        })
        this.partners = array;
        return array;
      }))
      
  }

  getPartner(partnerId: number) {
    //return this.http.get<Partner>(this.baseUrl + 'partners/' + partnerId)
    return this.http.get<Partner>(this.baseUrl + 'partners/' + partnerId);
  }
  updatePartner(partner: Partner) {
    console.log(partner);
    return this.http.put(this.baseUrl + "partners/" + partner.id + "/edit",partner);
  }

  getPartnerStatusUrl(status: string) {
    let statusUrl: string ="./assets/images/";
    switch (status) {
      case "inactive":
        statusUrl = "icon-circle-gray.png"
        break;
      case "active":
        statusUrl = "icon-circle-green.png"
        break;
      case "new":
        statusUrl = "icon-circle-blue.png"
        break;
      case "lost":
        statusUrl = "icon-circle-gray.png"
        break;
      case "archived":
        statusUrl = "icon-circle-gray.png"
        break;
      case "complete":
        statusUrl = "icon-circle-green.png"
        break;
      case "incomplete":
        statusUrl = "icon-circle-yellow.png"
        break;
      case "difficult":
        statusUrl = "icon-circle-red.png"
        break;
      default:
        statusUrl = "icon-circle-yellow.png"
        break;
    }
    
    return  "./assets/images/"+statusUrl;
  }
  
}
