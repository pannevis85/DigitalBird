import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute, NavigationEnd, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from 'src/app/_models/user';
import { UserPassword } from 'src/app/_models/userpassword';
import { UsersService } from 'src/app/_services/users.service';

@Component({
  selector: 'app-user-edit',
  templateUrl: './user-edit.component.html',
  styleUrls: ['./user-edit.component.css']
})
export class UserEditComponent implements OnInit {
  userId: number;
  user: User;
  userPassword: UserPassword;
  passwordFormToggle: boolean = false;
  @ViewChild('passwordForm') passwordForm: NgForm;
  @ViewChild('editForm') editForm: NgForm;
  mySubscription: any;
  

  constructor( 
    private userService: UsersService,
    private router: Router,
    private activatedRoute: ActivatedRoute,
    private toastr: ToastrService) { 
      
      this.router.routeReuseStrategy.shouldReuseRoute = () => false;
      this.mySubscription = this.router.events.subscribe((event) => {
      if (event instanceof NavigationEnd) {
         // Trick the Router into believing it's last link wasn't previously loaded
         this.router.navigated = false;
      }
    });
  }

  ngOnInit(): void {
    this.loadUser();
    this.userPassword = { 
      userId: this.userId
    };
  }
  
  loadUser() {
    this.userId = Number(this.activatedRoute.snapshot.paramMap.get('userid'));
    this.userService.getUser(this.userId).subscribe(response => {
      this.user = response;
      this.user.userId = this.userId;      
    })
  } 
  updateUser() {
    this.userService.updateUser(this.user).subscribe(response => {      
      this.toastr.success('Profile updated')
      this.reloadRoute();  
    }, error => {
      console.log(error);
      this.toastr.error(error.error);
    });
    
  }
  formToggle() {
    this.passwordFormToggle = !this.passwordFormToggle;
  }
  updateUserPassword() {
    console.log(this.userPassword);
    this.userService.updateUserPassword(this.userPassword).subscribe(response => {
      this.toastr.success('Password changed')
      this.reloadRoute();  
    });
  }
  reloadRoute() {
    this.router.navigate([this.router.url]);
  }
}
