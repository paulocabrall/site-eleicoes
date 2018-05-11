import {Inject, Injectable} from "@angular/core";
import {HttpClient} from "@angular/common/http";

@Injectable()
export class ClientService {

  constructor(
    @Inject('BASE_URL') public baseUrl: string,
    public http: HttpClient) {}

  findAllClients() {
    return this.http.get<Client[]>(this.baseUrl + 'api/clients');
  }

  saveClient(c: Client) {
    return this.http.post<Client>(this.baseUrl + 'api/clients', c);
  }

  updateClient(c: Client) {
    return this.http.put<Client>(this.baseUrl + `api/clients/${c.id}`, c);
  }

}

export interface Client {
  id: string;
  name: string;
  address: string;
  phoneNumber: string;
  addressComplement: string;
  notes: string;
  zipCode: string;
  email: string;
}
