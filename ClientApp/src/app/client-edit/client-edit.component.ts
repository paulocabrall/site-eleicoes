import { Component } from '@angular/core';
import {Client, ClientService} from "../client.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-client-edit',
  templateUrl: './client-edit.component.html'
})
export class ClientEditComponent {
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
    public clientSvc: ClientService,
    public router: Router) {}

  public saveClient() {
    this.clientSvc.saveClient(this.client)
      .subscribe(result => {
        this.router.navigateByUrl(`/clients/${result.id}`);
      }, error => console.log(error));
  }

}
