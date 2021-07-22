import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { User } from '../_models/user';
import { UserPassword } from '../_models/userpassword';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  baseUrl = environment.apiUrl;
  
  constructor(private http:HttpClient) { }

  getUser(userid: number) {
    return this.http.get<User>(this.baseUrl + 'users/' + userid);
  }

  updateUser(user: User) {
    return this.http.put(this.baseUrl + "users/update", user);
  }
  updateUserPassword(userPassword: UserPassword) {
    return this.http.put(this.baseUrl + "users/password", userPassword);
  }
  
}
