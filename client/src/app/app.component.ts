import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserToken } from './_models/usertoken';
import { AccountService } from './_services/account.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'DigitalBird';
  users: any;

  constructor(private AccountService: AccountService) {}
  
  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: UserToken = JSON.parse(localStorage.getItem('user'));
    if(user != null) {
      this.AccountService.setCurrentUser(user);
      //console.log("user set from token");
    }
    
  }
  
}
