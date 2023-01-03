import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { FileService } from '../services/file.service';  

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  accounts:any;
  balanceYear?:string;   

  constructor(private _router: Router,private FileService:FileService) { }    

  ngOnInit(): void {
    this.FileService.GetAccount()
    .subscribe(response => {
      debugger;
      this.accounts = response;
      let result= <any>response;
      this.balanceYear = result[0].Month + " " + result[0].Year ;
    });
  }

  navigateToDashboard() {
    this._router.navigate(['/Dashboard']);
  }
}
