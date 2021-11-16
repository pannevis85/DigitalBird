import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HelperService {

  constructor() { }

  getStatusUrl(status: string) {
    if (!status) return "./assets/images/icon-warning.png";
    if (status.length==0) return "./assets/images/icon-warning.png";
    let statusUrl: string ="./assets/images/";
    switch (status.toLowerCase()) {
      case "in process":
        statusUrl = "icon-circle-yellow.png"
        break;
      case "warning":
        statusUrl = "icon-warning.png"
        break;
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
      case "completed":
        statusUrl = "icon-circle-green.png"
        break;
      case "incomplete":
        statusUrl = "icon-circle-yellow.png"
        break;
      case "difficult":
        statusUrl = "icon-circle-red.png"
        break;
      default:
        statusUrl = "icon-warning.png"
        break;
    }
    
    return  "./assets/images/"+statusUrl;
  }
  
}
