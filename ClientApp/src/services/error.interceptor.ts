import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { AuthService } from './auth.service';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private authService: AuthService) {}

  intercept(
    request: HttpRequest<any>,
    next: HttpHandler
  ): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(
      catchError(error => {
        if (error.status === 401) {
          // auto logout if 401 response returned from api
          // this.authService.logOut();
          // location.reload(true);
          console.error('Error Interceptor:', error);
        } else {
          // Todo: Log Error to log file
          console.error('Error Interceptor:', error);
          return throwError(error);
        }
      })
    );
  }
}
