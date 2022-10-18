import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { empleado } from '../interfaces/empleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  private myAppUrl: string = environment.endpoint;
  private myApiUrl: string = 'api/Personas/';

  constructor(private http: HttpClient) { }

  getEmpleado(codZona: number): Observable<empleado[]>{
    return this.http.get<empleado[]>(`${this.myAppUrl}${this.myApiUrl}${codZona}`);
  }

  addEmpleado(empleado: empleado){
    return this.http.post<empleado>(`${this.myAppUrl}${this.myApiUrl}`,empleado)
  }

  deleteEmpleado(id: number): Observable<void>{
    return this.http.delete<void>(`${this.myAppUrl}${this.myApiUrl}${id}`);
  }
}
