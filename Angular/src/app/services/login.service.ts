import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { from, Observable, ReplaySubject, tap } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class LoginService {
    Url: string;
    header: any;
    private roles?: string;
    private logged = new ReplaySubject<boolean>(1);
    isLogged = this.logged.asObservable();

    constructor(private http: HttpClient) {
        this.Url = "https://accountbalanceapi.azurewebsites.net/api/Login";
        // this.Url = 'https://localhost:44359/api/Login';
        const headerSettings: { [name: string]: string | string[]; } = {};
        this.header = new HttpHeaders(headerSettings);
    }

    Login(model: any): Observable<string> {
        const httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json' }) };
        return this.http.post<string>(this.Url + '?username=' + model.UserName + '&password=' + model.Password, { headers: this.header }).pipe(
            tap(res => {
                debugger;
                this.roles = <any>res;
                localStorage.setItem('roles', <any>res);
                this.logged.next(true);
            })
        );
    }

    get userRoles(): string {
        var local = localStorage.getItem('roles');
        if (local != null)
            return local;
        else
            return "";
    }

    checkStatus() {
        if (this.roles) {
            this.logged.next(true);
        } else {
            this.logged.next(false);
        }
    }

    checkRoleStatus() {
        if (localStorage.getItem('roles') != '') {
            return true;
        } else {
            return false;
        }
    }
}  