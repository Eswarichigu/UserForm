import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public users: User[] = [];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<User[]>(baseUrl + 'weatherforecast/GetUsers').subscribe(result => {
      console.log(result);
      this.users = result;
    }, error => console.error(error));
  }
}

interface User {
  id: number;
  firstName: string;
  lastName: string;
  mobile: string;
  email: string;
}
