import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators'
import { environment } from 'src/environments/environment';
import { UserToken } from '../_models/usertoken';


@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.apiUrl; 
  private currentUserTokenSource = new ReplaySubject<UserToken>(1);
  currentUserToken$ = this.currentUserTokenSource.asObservable();

  constructor(private http:HttpClient) { }

  login(model:any) {
    return this.http.post<UserToken>(this.baseUrl + 'account/login', model).pipe(
      map((response: UserToken) => {
          const user = response;
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserTokenSource.next(user);
          } 
        })
    );
  }
  register(model:any) {
    return this.http.post<UserToken>(this.baseUrl + 'account/register', model).pipe(
      map((user: UserToken) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserTokenSource.next(user);
        }
      })
    )
  }
  setCurrentUser (user: UserToken) {
    this.currentUserTokenSource.next(user);
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUserTokenSource.next(null);
  }

}
