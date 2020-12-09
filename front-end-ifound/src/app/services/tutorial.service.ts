import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

const baseUrl = 'http://localhost:5016/api/lostorfound';

@Injectable({
  providedIn: 'root'
})
export class TutorialService {

  constructor(private http: HttpClient) { }

  getAll(): Observable<any> {
    return this.http.get(`${baseUrl}/GetAllObjects`);
  }

  get(id): Observable<any> {
    return this.http.get(`${baseUrl}/GetAllObjects?$Filter=Object/ObjectId eq ${id}`);
  }

  create(data): Observable<any> {
    return this.http.post(`${baseUrl}/AddObject`, data);
  }

  update(id, data): Observable<any> {
    return this.http.post(`${baseUrl}/UpdateObject`, data);
  }

  delete(id): Observable<any> {
    return this.http.delete(`${baseUrl}/${id}`);
  }

  // deleteAll(): Observable<any> {
  //   return this.http.delete(baseUrl);
  // }

  findByTitle(title): Observable<any> {
    return this.http.get(`${baseUrl}?Filter=Contains(Object/ObjectName ,${title})`);
  }
}
