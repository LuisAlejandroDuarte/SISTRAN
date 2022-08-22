import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Persona } from 'src/app/model/persona.model';
import { PersonaService } from 'src/app/service/persona.service';
declare const $: any;
@Component({
  selector: 'app-list-persona',
  templateUrl: './list-persona.component.html',
  styleUrls: ['./list-persona.component.css']
})
export class ListPersonaComponent implements OnInit {
  tabla:any;
  constructor(private router:Router,private servicePersona:PersonaService) { }

  ngOnInit(): void {
  }


  ngAfterViewInit(): void {


    setTimeout(()=>{      
      this.tabla= $('#datatables').DataTable({
        pagingType: "full_numbers",
        lengthMenu: [
          [10, 25, 50, -1],
          [10, 25, 50, "Todos"]
        ],
        data:[],
        dom: '<"top"f>rt<"bottom"lp><"clear">',
        columnDefs: [
          {
              targets: 0,
              className: 'dt-body-left'
          },
          {
            targets: 1,
            className: 'dt-body-left'
        },{
            targets: 2,
            className: 'dt-body-left'
        },{
          targets: 3,
          className: 'dt-body-left'
        }
        ],
        columns:[

                 {title:'Documento',data:'documento',width:'7%'},
                 {title:'Nombres',data:'nombres',width:'35%'},
                 {title:'Apellidos',data:'apellidos',width:'35%'},
                 {title:'Fecha',data:'fechaNacimiento',width:'10%',
                 render: (item,data,key)=> {
                  
                  return new Date(item).toLocaleDateString()
                  }},
                 { title:'Ver',data:'edit',orderable:false,
                    render: (item,data,key)=> {
                        return `<a class="btn btn-link btn-warning btn-just-icon edit"  data-item='Ver'><i class="material-icons">dvr</i></a>`
                  }}
                ],
        paging: true,
        language: {
        search: "_INPUT_",
        searchPlaceholder: "Buscar",
        lengthMenu: "Mostar _MENU_ registros por página",
        zeroRecords: "No hay datos",
        info: "Mostrando _PAGE_ de _PAGES_",
        infoEmpty: "Mostrando 0 a 0 de 0 registros",
        infoFiltered: "(filtered from _MAX_ total registros)",
        paginate: {
          first:      "Primero",
          last:       "Último",
          next:       "Próximo",
          previous:   "Anterior"
        },
      },
          rowCallback: (row: Node, data: any | Object, index: number) => {
            const self = this;
            $('td', row).off('click');
            $('td', row).on('click', (evt) => {
              const  accion=$(evt.target).closest('td').find('a').attr("data-item");
                if (accion) {
                  switch (accion) {
                    case 'Ver':
                      self.onSeleccionar(data);
                      break;
                    default:
                      break;
                  }
                }
            });

          }

        });
        //Obtiene todas las personas
        this.servicePersona.getAll().subscribe({
          next:(resp:Persona[]) =>{
            console.log("Datos",resp);
            $('#datatables').DataTable().clear();
            $('#datatables').DataTable().rows.add(resp);

            $('#datatables').DataTable().draw();

          }
        });



      });

    }

        //Muestra el producto en la vista ver-producto
        onSeleccionar(persona:any) {
          console.log(persona);
          this.router.navigateByUrl(`/ver-persona/${persona.id}`);
        }
    
        onCrearPersona() {
          this.router.navigateByUrl('crear-persona');
        }
}
