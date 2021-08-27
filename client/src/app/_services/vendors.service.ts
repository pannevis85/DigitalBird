import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Vendor } from '../_models/vendor';
import { HelperService } from './helper.service';

@Injectable({
  providedIn: 'root'
})
export class VendorsService {
  baseUrl = environment.apiUrl;
  vendors: Vendor[] = [];
  //currentVendor$: Vendor;

  constructor(private http: HttpClient, private helper: HelperService) { }
  getVendors() {
    return this.http.get<Vendor[]>(this.baseUrl + 'vendors')
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
    .pipe(map(array => {
      array.map(element=> {
        element.statusUrl = this.helper.getStatusUrl(element.status)
        return element;
      })
      this.vendors = array
      return array;
    }))
  }
  searchVendors(searchTerm:string) {
    if (searchTerm.length === 0) return this.getVendors();
    //if (this.partners.length > 0) return of(this.partners);
    return this.http.get<Vendor[]>(this.baseUrl + 'vendors/search/' + searchTerm)
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
      .pipe(map(array => {
        array.map(element=> {
          element.statusUrl = this.helper.getStatusUrl(element.status)
        })
        this.vendors = array;        
        return array;
    }))      
  }

  getVendor(vendorId: number) {
    return this.http.get<Vendor>(this.baseUrl + "vendors/" + vendorId);
  }
  updateVendor(vendor: Vendor) {
    return this.http.put(this.baseUrl + "vendors/" + vendor.id + "/edit", vendor);
  }
  createVendor(vendor:Vendor) {
    return this.http.post(this.baseUrl + "vendors/create", vendor);
  }
}
