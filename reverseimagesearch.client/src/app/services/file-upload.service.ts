import { Injectable } from '@angular/core';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import {Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {

  constructor(private _http: HttpClient) { }

  uploadFile(file: File): Observable<any> {
    const formData = new FormData();
    formData.append('file', file); // Append the file to the FormData object

    return this._http.post('api/image/upload', formData, {
      headers: new HttpHeaders({
        'enctype': 'multipart/form-data',
      }),
    });
  }
}
