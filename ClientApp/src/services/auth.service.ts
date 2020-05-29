import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserDTO } from 'src/model/UserDTO';
import { Router } from '@angular/router';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = environment.BaseURL + 'api/Admin/';

  helper = new JwtHelperService();
  token: any;
  decodedToken: any;

  constructor(private http: HttpClient, private router: Router) {}

  login(model: UserDTO) {
    return this.http
      .post(this.baseUrl + 'login', model, this.requestOptions())
      .pipe(
        map((response: HttpResponse<any>) => {
          const user = response;
          if (user) {
            // tslint:disable-next-line: no-string-literal
            const token = user['tokenString'];
            localStorage.setItem('token', token);
            this.token = token;
            this.decodedToken = this.helper.decodeToken(this.token);
          }
        })
      );
  }
  loggedIn() {
    this.token = localStorage.getItem('token');

    if (this.token === null) {
      return false;
    } else {
      if(!this.decodedToken){
        this.decodedToken = this.helper.decodeToken(this.token);
      }
      return !this.helper.isTokenExpired(this.token);
    }
  }
  logOut() {
    localStorage.removeItem('token');
    this.token = null;
    this.router.navigate(['/login']);
  }

  private requestOptions() {
    const headers = new HttpHeaders({ 'Content-type': 'application/json' });
    const options = { headers };
    return options;
  }

  private handleError(error: any) {
    // const applicationError = error.headers.get('Application-Error');
    // if (applicationError) {
    //   // tslint:disable-next-line: deprecation
    //   return Observable.throw(applicationError);
    // }
    // const serverError = error.json();
    // let modelStateError = '';
    // if (serverError) {
    //   for (const key in serverError) {
    //     if (serverError[key]) {
    //       modelStateError += serverError[key] + '\n';
    //     }
    //   }
    // }
    // tslint:disable-next-line: deprecation
    // return Observable.throw(modelStateError || 'Server Error');
  }
}
