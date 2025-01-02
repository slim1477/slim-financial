import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Credentials } from '../core/common/models/credentials';
import { Observable } from 'rxjs';
import {jwtDecode} from 'jwt-decode';
import { LoginResponse } from '../core/common/models/login-response';

interface AuthUser{
    Person : string
}
@Injectable()
export class AuthService {
    private http = inject(HttpClient)
    private token : string  = '';
    private authPerson = ''
    private endpoint: string = 'https://localhost:7177/api/Person/login'

    login(credentials: Credential) : Observable<any>{
        return this.http.post(this.endpoint,credentials)
    }

    setToken(token: string): void {
      this.token = token;
      localStorage.setItem('sessionToken', token); 
    }
  
    getToken(): string | null {
      return this.token || localStorage.getItem('sessionToken');
    }
  
    clearToken(): void {
      this.token = '';
      localStorage.removeItem('sessionToken');
    }
  getAuthPerson() {
    const token = localStorage.getItem('sessionToken');
    this.authPerson = (jwtDecode(token!) as AuthUser).Person
        return this.authPerson
    }
 
}
