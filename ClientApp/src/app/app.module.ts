import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ClientEditComponent } from './client-edit/client-edit.component';
import { ClientListComponent } from './client-list/client-list.component';
import {ClientService} from "./client.service";
import {ClientsSearchPipe} from "./client-list/clients-search.pipe";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ClientEditComponent,
    ClientListComponent,
    ClientsSearchPipe,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      // { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'clients', component: ClientListComponent },
      { path: 'clients/:id', component: ClientEditComponent },

      { path: '', redirectTo: 'clients', pathMatch: 'full' },
      { path: '**', redirectTo: 'clients' },
    ])
  ],
  providers: [ClientService],
  bootstrap: [AppComponent]
})
export class AppModule { }
