import {Pipe, PipeTransform} from "@angular/core";
import {Client} from "../client.service";

@Pipe({
  name: 'clientsSearch',
  pure: false
})
export class ClientsSearchPipe implements PipeTransform {
  transform(items: Client[], filter: string): any {
    if (!items || !filter) {
      return items;
    }
    // filter items array, items which match and return true will be
    // kept, false will be filtered out
    return items.filter(item => {

      return item && filter &&
        ( item.name && item.name.toLowerCase().indexOf(filter.toLowerCase()) !== -1 ) ||
        ( item.id && item.id == filter ) ||
        ( item.address && item.address.toLowerCase().indexOf(filter) !== -1 ) ||
        ( item.zipCode && item.zipCode.indexOf(filter) !== -1 ) ||
        ( item.phoneNumber && item.phoneNumber.indexOf(filter) !== -1 )
        ;
    });
  }
}
