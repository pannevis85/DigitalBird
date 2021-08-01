import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HelperService {

  constructor() { }

  getStatusUrl(status: string) {
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
