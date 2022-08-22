import { AfterViewInit, Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Persona } from 'src/app/model/persona.model';
import { PersonaService } from 'src/app/service/persona.service';
import Swal from 'sweetalert2';
@Component({
  selector: 'app-edit-persona',
  templateUrl: './edit-persona.component.html',
  styleUrls: ['./edit-persona.component.css']
})
export class EditPersonaComponent implements OnInit {
  model:Persona;
  constructor(private activatedRoute: ActivatedRoute,private servicePersona:PersonaService,private spinner:NgxSpinnerService) { }

  ngOnInit(): void {
    this.activatedRoute.params.subscribe(params=>{
      this.spinner.show();
      this.servicePersona.get(params['id']).subscribe({
        next:(resp:Persona)=>{
          this.model=resp;
          this.spinner.hide();          
        },
        error:(err:any)=> {
          this.spinner.hide();
          Swal.fire("Error","Error al recuperar los datos","error");
        }        
      });
    })
  }


}
