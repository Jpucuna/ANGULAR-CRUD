import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { empleado } from 'src/app/interfaces/empleado';
import { sector } from 'src/app/interfaces/sector';
import { Zona } from 'src/app/interfaces/zona';
import { EmpleadoService } from 'src/app/services/empleado.service';
import { SectorService } from 'src/app/services/sector.service';
import { ZonaService } from 'src/app/services/zona.service';

@Component({
  selector: 'app-agrega-editar-empleado',
  templateUrl: './agrega-editar-empleado.component.html',
  styleUrls: ['./agrega-editar-empleado.component.css']
})
export class AgregaEditarEmpleadoComponent implements OnInit {

  sectores!: sector[];
  form: FormGroup;
  public sec:string="1";

  
  public zonas!: Observable<Zona[]>; 
  public SelCountryId:string="1";

  constructor(private _snackBar: MatSnackBar,private fb: FormBuilder, private _sectorservice: SectorService, private _zonaservice: ZonaService, private _empleadoservice: EmpleadoService,private router: Router) {
    

      this.form = fb.group({
      nombre: ['', Validators.required],
      fechaNacimiento: ['', Validators.required],
      sector: ['', Validators.required],
      zona: ['', Validators.required],
      sueldo: ['',Validators.required]  
      });
      
  }

  ngOnInit(): void {
    this.obtenerSectores();
    
    

    
  }

  obtenerSectores(){
      //se agrega lo del loading porque no se logra apreciar 
      this._sectorservice.getSectores().subscribe(data =>{
        this.sectores = data;//esto es para presentar la data que se obtuvo de la bd
      },error =>{//manejo de errores cuando no hay data
        alert('Oops, ocurrió un error :(');
      })
      
  }

  mensajeExito(text: string){
    this._snackBar.open(`El empleado fue ${text} con éxito`, "",{
      duration: 2000,
      //elementos que se pasan para manejar la posicion del snackbar
      horizontalPosition: "right",
      verticalPosition: "bottom",//por defecto es abajo la posicion asi que no haria falta poner esto, pero si es top si
      });
  }

  onSubmit(){
    const empleado: empleado = {
      nomPersona: this.form.value.nombre,
      fecNac: this.form.value.fechaNacimiento,
      codSector: this.form.value.sector,
      codZona: this.form.value.zona,
      sueldo: this.form.value.sueldo,
    }
    
    this._empleadoservice.addEmpleado(empleado).subscribe(()=>{ 
      this.mensajeExito("agregado");
      this.router.navigate(['/listEmpleado']);
    });
  }
  
  llenarZonas(){
    this.zonas=this._zonaservice.getZonasId(parseInt(this.sec));  
    console.log(this.sec);
  }  

}


