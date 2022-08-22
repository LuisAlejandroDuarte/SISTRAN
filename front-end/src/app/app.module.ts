import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from 'src/shared/material/material.module';
import { FormsModule,ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { ListComponent } from './forms/productos/list.component';
import { NgxSpinnerModule } from "ngx-spinner";
import { TimerService } from 'src/resource/main.service';
import { ListPersonaComponent } from './forms/persona/list-persona/list-persona.component';
import { FormPersonaComponent } from './forms/persona/form-persona/form-persona.component';
import { CrearPersonaComponent } from './forms/persona/crear-persona/crear-persona.component';
import { EditPersonaComponent } from './forms/persona/edit-persona/edit-persona.component';




@NgModule({
  declarations: [
    AppComponent,
    ListComponent,        
    ListPersonaComponent,
    FormPersonaComponent,
    CrearPersonaComponent,
    EditPersonaComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MaterialModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    NgxSpinnerModule
  ],
  providers: [ TimerService],
  bootstrap: [AppComponent]
})
export class AppModule { }
