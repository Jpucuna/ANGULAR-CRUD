export interface empleado{//export es para que otros modulos los puedan utilizar
    codPersona?: number,
    nomPersona: string,
    fecNac?: Date,
    codSector?: number,
    codZona: number,
    sueldo: number,
    codSectorNavigation?: [],
    codZonaNavigation?: []

}