export class TodoDTO {
  constructor(
    public id?: number,
    public name?: string,
    public description?: string,
    public isCompleted?: boolean,
    public userId?: number,
    public sortOrder?: number
  ) {}
}
export class UpdateListTodoDTO {
  constructor(public userId: number, public todos: TodoDTO[]) {
    todos = [] as TodoDTO[];
  }
}
