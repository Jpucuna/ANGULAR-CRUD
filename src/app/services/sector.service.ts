import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { sector } from '../interfaces/sector';

@Injectable({
  providedIn: 'root'
})
export class SectorService {

  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = 'api/Sectors';

  constructor(private http: HttpClient) { }

  getSectores(): Observable<sector[]>{
    return this.http.get<sector[]>(`${this.myAppUrl}${this.myApiUrl}`);
  }

}
