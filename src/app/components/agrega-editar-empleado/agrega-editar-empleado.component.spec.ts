import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AgregaEditarEmpleadoComponent } from './agrega-editar-empleado.component';

describe('AgregaEditarEmpleadoComponent', () => {
  let component: AgregaEditarEmpleadoComponent;
  let fixture: ComponentFixture<AgregaEditarEmpleadoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AgregaEditarEmpleadoComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AgregaEditarEmpleadoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
