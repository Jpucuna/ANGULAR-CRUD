import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { SharedModule } from './shared/shared.module';  

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AgregaEditarEmpleadoComponent } from './components/agrega-editar-empleado/agrega-editar-empleado.component';
import { ListadoEmpleadoComponent } from './components/listado-empleado/listado-empleado.component';
import { VerEmpleadoComponent } from './components/ver-empleado/ver-empleado.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

@NgModule({
  declarations: [
    AppComponent,
    AgregaEditarEmpleadoComponent,
    ListadoEmpleadoComponent,
    VerEmpleadoComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    SharedModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
