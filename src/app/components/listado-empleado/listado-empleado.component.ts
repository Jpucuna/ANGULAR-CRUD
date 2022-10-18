import { Component, OnInit } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { grupoZona } from 'src/app/interfaces/grupoZona';
import { ZonaService } from 'src/app/services/zona.service';

@Component({
  selector: 'app-listado-empleado',
  templateUrl: './listado-empleado.component.html',
  styleUrls: ['./listado-empleado.component.css']
})
export class ListadoEmpleadoComponent implements OnInit {

  displayedColumns: string[] = ['Sector', 'Zona', 'Sueldo', 'Acciones'];
  dataSource = new MatTableDataSource<grupoZona>()
  constructor(private _zonaService: ZonaService) { }

  ngOnInit(): void {
    this.obtenerZonas()
  }

  obtenerZonas(){
    //se agrega lo del loading porque no se logra apreciar 
    this._zonaService.getZonas().subscribe(data =>{
      this.dataSource.data = data;//esto es para presentar la data que se obtuvo de la bd
    },error =>{//manejo de errores cuando no hay data
      alert('Oops, ocurrió un error :(');
    })
  }

}
