import {Component, OnInit} from '@angular/core';
import {Client, ClientService} from "../client.service";
import {ActivatedRoute, Router} from "@angular/router";
import {take} from "rxjs/operators";

@Component({
  selector: 'app-client-edit',
  templateUrl: './client-edit.component.html'
})
export class ClientEditComponent implements OnInit {
  public client: Client = {
    id: undefined,
    address: undefined,
    addressComplement: undefined,
    email: undefined,
    name: undefined,
    notes: undefined,
    phoneNumber: undefined,
    zipCode: undefined
  };

  constructor(
    private clientSvc: ClientService,
    private route: ActivatedRoute,
    private router: Router) {

  }

  ngOnInit(): void {
    this.route.params.pipe(take(1)).subscribe(params => {
      const clientId = params['id'];
      this.loadClient(clientId);
    });
  }

  public saveClient() {
    this.clientSvc.saveClient(this.client)
      .subscribe(result => {
        this.router.navigateByUrl(`/clients/${result.id}`);
      }, error => console.log(error));
  }

  public removeClient() {
    const ok = confirm("Remover cliente?");
    if(!ok) return;
    this.clientSvc.removeClient(this.client)
      .subscribe(result => {
        this.router.navigateByUrl(`/clients`);
      }, error => console.log(error));
  }

  public listClients() {
    this.router.navigateByUrl(`/clients`);
  }

  private loadClient(clientId: string) {
    this.clientSvc.findClientById(clientId)
      .subscribe(result => {
        this.client = result;
      }, error => console.log(error));
  }

}
