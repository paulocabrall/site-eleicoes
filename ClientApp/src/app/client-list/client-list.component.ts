import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {ClientService, Client} from "../client.service";

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html'
})
export class ClientListComponent {
  public clients: Client[];

  constructor(clientSvc: ClientService) {
    clientSvc.findAllClients().subscribe(result => {
      this.clients = result;
    }, error => console.error(error));
  }

}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
