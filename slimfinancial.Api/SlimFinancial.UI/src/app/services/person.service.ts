import { inject, Injectable } from '@angular/core';
import { AuthService } from './auth.service';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../core/common/models/person';
import { jwtDecode } from 'jwt-decode';


interface JwtDecoded {
  Person: string;
  email: string;
  exp: number;
  iat : number
  jti: string;
  nameid: string;
  nbf: number
}
@Injectable()
export class PersonService {

  private http = inject(HttpClient);
  private service = inject(AuthService)
  private authPerson = this.service.getAuthPerson()
  private baseurl = `https://localhost:7177/api/Person/`
  constructor() { }

  getAuthPerson(): Observable<Person> {
    const token = this.service.getToken();
    const decodedToken: JwtDecoded = jwtDecode(token!);
    return this.http.get<Person>(this.baseurl.concat(decodedToken.Person));
    
  }

}
