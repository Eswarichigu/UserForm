import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router'; 

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  public firstName: string = '';
  public lastName: string = '';
  public mobile: string = '';
  public email: string = '';
  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: Router) {
  }

  Save() {
    var user = new User();
    user.firstName = this.firstName;
    user.lastName = this.lastName;
    user.mobile = this.mobile;
    user.email = this.email;
    let headers = new HttpHeaders();
    headers.append('Content-Type', 'application/json');
    this.http.post(this.baseUrl + 'weatherforecast/SaveUser', user, { headers: headers })
      .subscribe(res => {
        this.route.navigate(['/fetch-data']); 
      });


    
  }
}
class User {
  id: number=0;
  firstName: string='';
  lastName: string = '';;
  mobile: string = '';;
  email: string = '';;
}


