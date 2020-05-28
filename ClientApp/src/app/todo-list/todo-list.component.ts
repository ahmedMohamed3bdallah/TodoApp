import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { MatDialog } from '@angular/material/dialog';
import { TodoEditDialogComponent } from '../todo-edit-dialog/todo-edit-dialog.component';
import { TodoDTO } from 'src/model/TodoDTO';
import { TodoService } from 'src/services/todo.service';
import { NotificationService } from 'src/services/notification.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
})
export class TodoListComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private todoService: TodoService,
    private notification: NotificationService
  ) {}
  TodoList: TodoDTO[] = [] as TodoDTO[];
  ngOnInit() {
    this.TodoList.push(new TodoDTO(1, 'ahmed', 'desc 1', true, 1));
    this.TodoList.push(new TodoDTO(2, 'ahmed1', 'desc 2', false, 1));
    this.TodoList.push(new TodoDTO(3, 'ahmed2', 'desc 3', true, 1));
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.TodoList, event.previousIndex, event.currentIndex);
  }

  openEditDialog(current: TodoDTO): void {
    const temp = current;
    const dialogRef = this.dialog.open(TodoEditDialogComponent, {
      width: '250px',
      data: temp,
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.notification.showInfo('The dialog was closed', '');
      current = result;
    });
  }

  openNewDialog(): void {
    const dialogRef = this.dialog.open(TodoEditDialogComponent, {
      width: '250px',
      data: new TodoDTO(),
    });

    dialogRef.afterClosed().subscribe((result) => {
      this.notification.showInfo('The dialog was closed', '');
      this.todoService.add(result).subscribe(
        (data) => {
          this.notification.showInfo('Done', '');
          console.log(data);
        },
        (error) => {
          console.log(error);
          this.notification.showError('erro', '');
        }
      );

      // this.TodoList.push(result);
      // console.log(result);
    });
  }
  Delete(current: TodoDTO) {}
}
