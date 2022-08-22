import { Contacto } from "./contactos.model";

export class Persona {
    Id?:number;
    documento?: string;
    nombres?:string;
    apellidos?:string;
    fechaNacimiento?:Date;
    contactos?:Contacto[];
}