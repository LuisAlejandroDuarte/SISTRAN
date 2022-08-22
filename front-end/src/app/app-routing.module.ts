import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './guads/auth.guard';
import { ListComponent } from './forms/productos/list.component';
import { CrearPersonaComponent } from './forms/persona/crear-persona/crear-persona.component';
import { ListPersonaComponent } from './forms/persona/list-persona/list-persona.component';
import { EditPersonaComponent } from './forms/persona/edit-persona/edit-persona.component';


const routes: Routes = [
  {path: '', redirectTo: 'persona',pathMatch: 'full'},
  { path: 'productos', component: ListComponent,canActivate:[AuthGuard]},    
  { path: 'crear-persona', component: CrearPersonaComponent},
  { path: 'ver-persona/:id', component: EditPersonaComponent},
  { path: 'persona', component: ListPersonaComponent}
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
