import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { ActivatedRoute } from '@angular/router';
import { empleado } from 'src/app/interfaces/empleado';
import { EmpleadoService } from 'src/app/services/empleado.service';
import { ZonaService } from 'src/app/services/zona.service';

@Component({
  selector: 'app-ver-empleado',
  templateUrl: './ver-empleado.component.html',
  styleUrls: ['./ver-empleado.component.css']
})
export class VerEmpleadoComponent implements OnInit {

  codZona: number;
  displayedColumns: string[] = ['Cod. de persona', 'Nombre', 'Sueldo', 'Acciones'];
  dataSource = new MatTableDataSource<empleado>()
  
  constructor(private _snackBar: MatSnackBar ,private _empleadoService: EmpleadoService,private aRoute: ActivatedRoute) {
    this.codZona = Number(this.aRoute.snapshot.paramMap.get("codZona"));
   }

  ngOnInit(): void {

    this.obtenerEmpleado();
  }

  obtenerEmpleado(){
    this._empleadoService.getEmpleado(this.codZona).subscribe(data=>{
      this.dataSource.data = data;
    });
    
  }

  eliminarEmpleado(id:number){
    this._empleadoService.deleteEmpleado(id).subscribe(data =>{
      this.mensajeExito();
      this.obtenerEmpleado();//con esto refrescamos la pantalla
    });
  }
  

  mensajeExito(){
    this._snackBar.open(`El empleado fue eliminado con éxito`, "",{
      duration: 2000,
      //elementos que se pasan para manejar la posicion del snackbar
      horizontalPosition: "right",
      verticalPosition: "bottom",//por defecto es abajo la posicion asi que no haria falta poner esto, pero si es top si
      });
  }

}
