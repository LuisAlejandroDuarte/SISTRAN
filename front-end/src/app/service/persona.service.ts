import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Persona } from '../model/persona.model';
const base_url = environment.base_url;
@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  constructor(private http:HttpClient) { }


   //Agrega una persona
   addPersona(datos:Persona) {
    return this.http.post(`${base_url}/CrearPersona/`,datos);
   }

   getAll() {
    return this.http.get(`${base_url}/GetAllPersonas/`);
   }

   get(id:number) {
    return this.http.get(`${base_url}/GetPersona/${id}`);
   }

   eliminar(id:number) {
    return this.http.delete(`${base_url}/EliminarContacto/${id}`);
   }
}
