import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from '../services/login.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  isAdmin?: boolean;
  constructor(private _router: Router,private loginService: LoginService) { }

  ngOnInit(): void {
    debugger;
    var roles = this.loginService.userRoles;
    if(roles.includes("Admin")){
      this.isAdmin = true;
    }
    else{
      this.isAdmin = false;
    }
  }

  navigateToUpload() {
    this._router.navigate(['/upload']);
  }

  navigateToAccount() {
    this._router.navigate(['/account']);
  }

  navigateToSignOut(){
    localStorage.setItem('roles', '');
    this.loginService.checkStatus();
  }

}
