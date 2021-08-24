import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Service } from '../_models/service';
import { HelperService } from './helper.service';

@Injectable({
  providedIn: 'root'
})
export class ServicesService {
  baseUrl = environment.apiUrl;
  services: Service[] = [];
  
  constructor(private http:HttpClient, private helper:HelperService) { }

  getServices() {
    return this.http.get<Service[]>(this.baseUrl + 'services')
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
    .pipe(map(array => {
      array.map(element=> {
        element.statusUrl = this.helper.getStatusUrl(element.status)
        return element;
      })
      this.services = array
      return array;
    }))
  }
  getService(serviceId: number) {
    return this.http.get<Service>(this.baseUrl + "services/" + serviceId);
  }
  updateService(service: Service) {
    return this.http.put(this.baseUrl + "services/" + service.id + "/edit", service);
  }
  createService(service:Service) {
    return this.http.post(this.baseUrl + "services/create", service);
  }
}
