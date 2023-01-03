import { Component, OnInit } from '@angular/core';    
import { Router } from '@angular/router';    
import { LoginService } from '../services/login.service';    
 import { FormsModule } from '@angular/forms';    

@Component({    
  selector: 'app-login',    
  templateUrl: './login.component.html',    
  styleUrls: ['./login.component.css']    
})    
export class LoginComponent {    
  model : any={};    

  errorMessage?:string;    
  constructor(private router:Router,private LoginService:LoginService) { }    

  ngOnInit() {    
    sessionStorage.removeItem('UserName');    
    sessionStorage.clear();    
  }    
  login(){    
    debugger;    
    this.LoginService.Login(this.model).subscribe(    
      data => {    
        // debugger;    
        if(data != 'User Not Found')    
        {       
          this.router.navigate(['/Dashboard']);    
          // debugger;    
        }    
        else{    
          this.errorMessage = data;    
        }    
      },    
      error => {    
        debugger;  
        this.errorMessage = error.message;    
      });    
  };    
 }    