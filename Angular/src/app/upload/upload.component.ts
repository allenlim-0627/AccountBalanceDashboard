import { Component, OnInit, ViewChild } from '@angular/core';
import { FileService } from '../services/file.service';
import {
  Validators,
  FormBuilder
} from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.css']
})
export class UploadComponent implements OnInit {
  @ViewChild('fileInput', {
    static: true
  }) fileInput;
  selectedFile: File | any = null;
  saveFileForm: any;
  uploadMessage?:string;   
  constructor(private _router: Router,private FileService: FileService) { }

  ngOnInit(): void {
  }

  onExpSubmit() {
    // debugger;
    // if (this.saveFileForm.invalid) {  
    //     return;  
    // }  
    let formData = new FormData();
    if(this.fileInput.nativeElement.files.length == 0){
      this.uploadMessage = "Please select one file."
      return;
    }
    formData.append('files', this.fileInput.nativeElement.files[0]);
    this.FileService.AddFileDetails(formData).subscribe(
      result => { 
      this.uploadMessage = result;
      },
      error => {    
        // debugger;  
        this.uploadMessage = error.error;    
      }
    );
  }

  navigateToDashboard() {
    this._router.navigate(['/Dashboard']);
  }
}
