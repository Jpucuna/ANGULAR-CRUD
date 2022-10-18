import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AgregaEditarEmpleadoComponent } from './components/agrega-editar-empleado/agrega-editar-empleado.component';
import { ListadoEmpleadoComponent } from './components/listado-empleado/listado-empleado.component';
import { VerEmpleadoComponent } from './components/ver-empleado/ver-empleado.component';

const routes: Routes = [
  {path:'', redirectTo:'listEmpleado', pathMatch:'full'},
  {path:'listEmpleado', component: ListadoEmpleadoComponent},
  {path:'verEmpleado/:codZona', component: VerEmpleadoComponent},
  {path:'agregarEmpleado', component: AgregaEditarEmpleadoComponent},
  {path:'**', redirectTo: 'listEmpleado', pathMatch: 'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
