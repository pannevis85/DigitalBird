import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { Process } from '../_models/process';
import { HelperService } from './helper.service';

@Injectable({
  providedIn: 'root'
})
export class ProcessService {
  baseUrl = environment.apiUrl;
  process: Process[] = [];
  constructor(
          private http: HttpClient,
          private helper: HelperService,
          ) { }

  
  getProcess(serviceId: number) {
    return this.http.get<Process[]>(this.baseUrl + 'process/' + serviceId)
    //this pipe is just to create a url for status string to icons
    //this is a list, the array needs to be mapped and within that each element
      .pipe(map(array => {
        array.map(element=> {
          element.statusUrl = this.helper.getStatusUrl(element.status);
        })
        this.process = array;        
        return array;
      }))      
  }
  updateProcess(process: Process) {
    return this.http.put(this.baseUrl + "process/" + process.serviceId + "/edit", process);
  }
  createProcess(process: Process) {
    return this.http.post(this.baseUrl + "process/" + process.serviceId + "/create", process);
  }
  deleteProcess(processId: number) {
    return this.http.post(this.baseUrl + "process/delete/" + processId, processId);    
  }

  
}
