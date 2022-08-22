import { AfterViewInit, Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormArray, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { Contacto } from 'src/app/model/contactos.model';

import { Persona } from 'src/app/model/persona.model';
import { PersonaService } from 'src/app/service/persona.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-form-persona',
  templateUrl: './form-persona.component.html',
  styleUrls: ['./form-persona.component.css']
})
export class FormPersonaComponent implements OnInit,AfterViewInit {

  formPersona:FormGroup;
  formContacto:FormGroup;
  telefono:string;
  direccion:string;
  email:string;
  agregar:boolean=false;
  @Input() model:Persona;
  @Output() saveChanges = new EventEmitter<Persona>();
  constructor(private router:Router,private fb:FormBuilder,private spinner:NgxSpinnerService,private servicePersona:PersonaService ) { }

  ngOnInit(): void {

    this.formPersona = this.fb.group({
      id:[0],
      documento:['',[Validators.required,Validators.pattern("^[A-Za-z0-9 -]+$")]],
      nombres:['',[Validators.required,Validators.pattern("^[A-Za-zñÑ -]+$")]],
      apellidos:['',[Validators.required,Validators.pattern("^[A-Za-zñÑ -]+$")]],
      fechaNacimiento:['',[Validators.required]],
      contactos:this.fb.array([])
    });   
    
    this.formContacto=this.fb.group({
      id:[0],
      telefono:['',[Validators.required]],
      direccion:[''],
      email:['',[Validators.email]]
    })

  }


  ngAfterViewInit(): void {
 
    setTimeout(()=>{
      if (this.model) {
        this.formPersona.patchValue(this.model);
        console.log("Contactos",this.model.contactos);
        const datos=  this.formPersona.controls["contactos"] as FormArray;
        this.model.contactos.forEach(element => {
          datos.push( this.fb.group({
            id:element.id,
            telefono:element.telefono,
            direccion:element.direccion,
            email:element.email
          }));
        });     
        
      }
    },1000);    
}

onSalir() {
  this.router.navigateByUrl(`/persona`);
}


  get contactos() {    
    return this.formPersona.controls["contactos"] as FormArray;
  }

    

  onSubmit() {
    console.log("Datos",this.formPersona.value);
  }

  onAgregarContacto(event:any) {
    event.stopPropagation();
    this.agregar=true;

    if (((this.formContacto.get('direccion').value=='' && this.formContacto.get('email').value!='' && !this.formContacto.get('email').invalid  ) || 
           (this.formContacto.get('direccion').value!='' && this.formContacto.get('email').value=='') || 
           (this.formContacto.get('direccion').value!='' && this.formContacto.get('email').value!='' && !this.formContacto.get('email').invalid  ))) {
           
            const datos=  this.formPersona.controls["contactos"] as FormArray;
            const newId = (datos.length * -1) -1;
            datos.push(this.fb.group({     
              id:newId,         
              telefono:this.formContacto.get('telefono').value,
              direccion:this.formContacto.get('direccion').value,
              email:this.formContacto.get('email').value,
            }));

            this.formContacto.get('telefono').setValue("");
            this.formContacto.get('direccion').setValue("");
            this.formContacto.get('email').setValue("");
            this.agregar=false;
            
           }  
  }

  onDeleteContacto(e:any,item:any) {
    e.stopPropagation();

    const datos=  this.formPersona.controls["contactos"] as FormArray;
    const find= datos.value.findIndex(x=>x.id==item.id);
 
    if (item.id<0) {       
        datos.removeAt(find);
    } else {
      if (datos.value.length>1)
      {
        Swal.fire({
          title: `Desea eliminar el contacto  ?`,
          showDenyButton: true,      
          confirmButtonText: 'Si',
          denyButtonText: `No`,
        }).then((result) => {      
          if (result.isConfirmed) {
            this.spinner.show();
            this.servicePersona.eliminar(item.id).subscribe({
              next:(res)=>{
                Swal.fire('Eliminado', 'contacto eliminado', 'success');                   
                this.spinner.hide();               
                datos.removeAt(find);
              },
              error:(err)=>{            
                Swal.fire('Error', err.error.Message, 'error');
              }
            });        
          } 
        })
      }       
    }
  }

  onSave() {    
    this.saveChanges.emit(this.formPersona.value);
  }
}
