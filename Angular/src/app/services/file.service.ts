import {  
    Injectable  
} from '@angular/core';  
import {  
    Observable  
} from 'rxjs';  
import {  
    HttpClient,  
    HttpHeaders  
} from '@angular/common/http';  
@Injectable({  
    providedIn: 'root'  
})  
export class FileService {  
    url = "https://accountbalanceapi.azurewebsites.net/api";
    // url = 'https://localhost:44359/api';  
    constructor(private http: HttpClient) {}  
    // public downloadFile(docFile: string): Observable < Blob > {  
    //     return this.http.get(this.url + '/GetFile?docFile=' + docFile, {  
    //         responseType: 'blob'  
    //     });  
    // }  
    // public downloadImage(image: string): Observable < Blob > {  
    //     return this.http.get(this.url + '/GetImage?image=' + image, {  
    //         responseType: 'blob'  
    //     });  
    // }  
    // public getFiles(): Observable < any[] > {  
    //     return this.http.get < any[] > (this.url + '/GetFileDetails');  
    // }  
    AddFileDetails(data: FormData): Observable < string > {  
        let headers = new HttpHeaders({
            'Authorization': 'BASIC YWxsZW46MTIz',
        });  
        const httpOptions =  {  
            headers: headers,
        };  
        return this.http.post<string>(this.url + '/UploadAccount', data, httpOptions);  
    }  

    GetAccount(): Observable < string > {  
        // debugger;
        let headers = new HttpHeaders({
            'Content-Type':"application/json",
            'Authorization': 'BASIC YWxsZW46MTIz'
        });  
        // headers.append('Authorization', 'BASIC YWxsZW46MTIz');  
        // headers.append('Content-Type', 'application/json');  
        const httpOptions =  {  
            headers: headers,
        };  
        return this.http.get < string > (this.url + '/GetAllAccounts', httpOptions);  
    }  
}  