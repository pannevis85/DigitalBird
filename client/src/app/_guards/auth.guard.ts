import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { AccountService } from '../_services/account.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private accountService:AccountService, private toastr:ToastrService) {}

  canActivate(): Observable<boolean> {
    
    return this.accountService.currentUserToken$.pipe(
      map(user => {
        return true; //allow all navigation
        /*
        if (user) return true;
        this.toastr.error('You shall not pass! -Gandalf');
        console.log('You shall not pass! -Gandalf');
        return false;
        */
      })
    )
  }
  
}
