import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Persona } from 'src/app/model/persona.model';
import { PersonaService } from 'src/app/service/persona.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-crear-persona',
  templateUrl: './crear-persona.component.html',
  styleUrls: ['./crear-persona.component.css']
})
export class CrearPersonaComponent implements OnInit {

  constructor(private router:Router,private servicePersona:PersonaService,private spinner:NgxSpinnerService) { }

  ngOnInit(): void {
  }

  saveChanges(persona:Persona) {
    this.spinner.show();
    this.servicePersona.addPersona(persona).subscribe({
      next:(resp:Persona)=>{
        this.spinner.hide();
        this.router.navigateByUrl('persona');
          Swal.fire("Guardado","Persona guardada","success");
      },
      error:(err:any) =>{
        this.spinner.hide();
        console.log("Error",err);
        Swal.fire("Error",err.error.Message,"error");
      }
    })
  }

}
