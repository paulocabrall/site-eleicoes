import {Component, Inject, OnInit} from '@angular/core';
import { HttpClient } from '@angular/common/http';
import {ClientService, Client} from "../client.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-client-list',
  templateUrl: './client-list.component.html'
})
export class ClientListComponent implements OnInit {
  public clients: Client[];

  constructor(
    private clientSvc: ClientService,
    private router: Router) {
  }

  ngOnInit(): void {
    this.clientSvc.findAllClients().subscribe(result => {
      this.clients = result;
    }, error => console.error(error));
  }

  public editClient(clientId: number) {
    this.router.navigateByUrl(`/clients/${clientId}`);
  }

}

interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
