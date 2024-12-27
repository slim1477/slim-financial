import { inject, Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpEventType
} from '@angular/common/http';
import { Observable, tap } from 'rxjs';
import { AuthService } from '../services/auth.service';
import { LoginResponse } from '../core/common/models/login-response';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {
// private authService = inject(AuthService)
private token : string | null = null;
private authService = new AuthService();
  constructor() {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
          // this.token = this.authService.getToken()
          // console.log(request.url)
          // this.token = new AuthService().getToken()
          // const request2 = request.clone({headers: request.headers.set('Authorization',' Bearer  ' + this.token)})
          // console.log("token from interceptor",this.token)
          
          if (request.url.endsWith('/login')) {
            // For login requests, handle the token in the response
            return next.handle(request).pipe(
              tap(event => {
                if (event.type == HttpEventType.Response) {
                  // Store the token in the AuthService
                  const body = event.body as LoginResponse
                  this.authService.setToken(body?.sessionToken);
                }
              })
            );
          } else {
            // For other requests, attach the token to the headers
            const token = this.authService.getToken();
            if (token) {
              request = request.clone({
                setHeaders: {
                  Authorization: `Bearer ${token}`
                }
              });
            }
            return next.handle(request);
          }
        }
    }

  
 
  // if(HttpEventType.Response && request.url == 'https://localhost:7177/api/Person/login'){
  //   console.log(Event.b)
  // }

