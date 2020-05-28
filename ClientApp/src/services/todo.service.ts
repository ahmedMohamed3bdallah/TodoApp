import { Injectable } from '@angular/core';
import { TodoDTO } from 'src/model/TodoDTO';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http';
import { map } from 'rxjs/internal/operators/map';
import { AuthService } from './auth.service';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  baseUrl = 'https://localhost:44354/Todo/';

  constructor(private http: HttpClient, private authService: AuthService) {}
   get(id: number){
    return this.http
    .get(this.baseUrl + 'Get/' + id.toString() , this.requestOptions())
    .pipe(
      map((response: HttpResponse<any>) => {
        const user = response;
        console.log(user);
      })
    );
   }
   getAll() {
    return this.http
    .get(this.baseUrl + 'GetAll/' + this.authService.decodedToken['nameid'] , this.requestOptions())
    .pipe(
      map((response: HttpResponse<any>) => {
        const user = response;
        console.log(user);
      })
    );
   }
  update(todoDTO: TodoDTO) {
    return this.http
      .put(this.baseUrl + 'Update', todoDTO, this.requestOptions())
      .pipe(
        map((response: HttpResponse<any>) => {
          const user = response;
          console.log(user);
        })
      );
  }
  delete(id: number) {
    return this.http
      .delete(this.baseUrl + 'Create/' + id.toString(), this.requestOptions())
      .pipe(
        map((response: HttpResponse<any>) => {
          const user = response;
          console.log(user);
        })
      );
  }
  add(todoDTO: TodoDTO) {
    return this.http
      .post(this.baseUrl + 'Create', todoDTO, this.requestOptions())
      .pipe(
        map((response: HttpResponse<any>) => {
          const user = response;
          console.log(user);
        })
      );
  }
  private requestOptions() {
    const headers = new HttpHeaders({ 'Content-type': 'application/json' });
    const options = { headers };
    return options;
  }
}
