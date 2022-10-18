import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { grupoZona } from '../interfaces/grupoZona';
import { Zona } from '../interfaces/zona';

@Injectable({
  providedIn: 'root'
})
export class ZonaService {

  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = 'api/Zonas/';

  constructor(private http: HttpClient) { }

  getZonas(): Observable<grupoZona[]>{
    return this.http.get<grupoZona[]>(`${this.myAppUrl}${this.myApiUrl}`);
  }

  getZonasId(id:number): Observable<Zona[]>  
  {  
    return this.http.get<Zona[]>(`${this.myAppUrl}${this.myApiUrl}${id}`);  
  }
}
