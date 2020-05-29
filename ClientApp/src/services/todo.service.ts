import { Injectable } from '@angular/core';
import { TodoDTO, UpdateListTodoDTO } from 'src/model/TodoDTO';
import { HttpHeaders, HttpClient, HttpResponse } from '@angular/common/http';
import { map } from 'rxjs/internal/operators/map';
import { AuthService } from './auth.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class TodoService {
  baseUrl = environment.BaseURL + 'Todo/';

  constructor(private http: HttpClient, private authService: AuthService) {}
  get(id: number) {
    return this.http
      .get<TodoDTO>(
        this.baseUrl + 'Get/' + id.toString(),
        this.requestOptions()
      )
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
  getAll() {
    return this.http
      .get<TodoDTO[]>(
        this.baseUrl + 'GetAll/' + this.authService.decodedToken['nameid'],
        this.requestOptions()
      )
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
  update(todoDTO: TodoDTO) {
    return this.http
      .put(this.baseUrl + 'Update', todoDTO, this.requestOptions())
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
  delete(id: number) {
    return this.http
      .delete(this.baseUrl + 'Delete/' + id.toString(), this.requestOptions())
      .pipe(
        map((response: HttpResponse<any>) => {
          const user = response;
        })
      );
  }
  add(todoDTO: TodoDTO) {
    return this.http
      .post<TodoDTO>(this.baseUrl + 'Create', todoDTO, this.requestOptions())
      .pipe(
        map((response) => {
          return response;
        })
      );
  }
  updateList(todoList: TodoDTO[]) {
    const request = new UpdateListTodoDTO(
      +this.authService.decodedToken['nameid'],
      todoList
    );
    return this.http
      .put(this.baseUrl + 'UpdateList', request, this.requestOptions())
      .pipe(
        map((response) => {
          return response;
        })
      );
  }

  private requestOptions() {
    const headers = new HttpHeaders({ 'Content-type': 'application/json' });
    const options = { headers };
    return options;
  }
}
