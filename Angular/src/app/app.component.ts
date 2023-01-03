import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { LoginService } from './services/login.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'account-balance-dashboard';
  constructor(private router:Router,private loginService: LoginService) { }

  ngOnInit() {
    // debugger;
    this.loginService.isLogged.subscribe(logged => {
      debugger;
      // this.isLogged = logged;
      var hasRoles = this.loginService.checkRoleStatus();
      if (hasRoles) {
        // this.loginService.getCurrentUser().subscribe(() => {
        //   this.loading = false;
        // });
        this.router.navigate(['/Dashboard']);   
      }
      else{
        this.router.navigate(['/login']);    
      }
    });
    this.loginService.checkStatus(); // don't forget this!
  }


}
