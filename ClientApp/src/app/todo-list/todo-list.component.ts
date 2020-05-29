import { Component, OnInit } from '@angular/core';
import { CdkDragDrop, moveItemInArray } from '@angular/cdk/drag-drop';
import { MatDialog } from '@angular/material/dialog';
import { TodoEditDialogComponent } from '../todo-edit-dialog/todo-edit-dialog.component';
import { TodoDTO } from 'src/model/TodoDTO';
import { TodoService } from 'src/services/todo.service';
import { NotificationService } from 'src/services/notification.service';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-todo-list',
  templateUrl: './todo-list.component.html',
  styleUrls: ['./todo-list.component.css'],
})
export class TodoListComponent implements OnInit {
  constructor(
    private dialog: MatDialog,
    private todoService: TodoService,
    private notification: NotificationService,
    private authService: AuthService
  ) {}
  TodoList: TodoDTO[] = [] as TodoDTO[];

  ngOnInit() {
    this.todoService.getAll().subscribe((data) => {
      this.TodoList = data;
    });
  }

  drop(event: CdkDragDrop<string[]>) {
    moveItemInArray(this.TodoList, event.previousIndex, event.currentIndex);
  }

  openEditDialog(current: TodoDTO, index: number): void {
    this.todoService.get(current.id).subscribe((data) => {
      const temp = data;

      const dialogRef = this.dialog.open(TodoEditDialogComponent, {
        width: '250px',
        data: temp,
      });

      dialogRef.afterClosed().subscribe((result) => {
        if (result) {
          this.todoService.update(result).subscribe(
            () => {
              this.notification.showInfo('Done', '');
              this.TodoList[index] = result;
            },
            (error) => {
              this.notification.showError('error', '');
            }
          );
        }
      });
    });
  }

  openNewDialog(): void {
    const dialogRef = this.dialog.open(TodoEditDialogComponent, {
      width: '500px',
      data: new TodoDTO(
        0,
        '',
        '',
        false,
        +this.authService.decodedToken['nameid'],
        this.TodoList.length + 1
      ),
    });

    dialogRef.afterClosed().subscribe((result) => {
      if (result) {
        this.todoService.add(result).subscribe(
          (data) => {
            this.notification.showInfo('Done', '');
            this.TodoList.push(data);
          },
          (error) => {
            this.notification.showError('error', '');
          }
        );
      }
    });
  }

  Delete(current: TodoDTO, index: number) {
    this.todoService.delete(current.id).subscribe(
      () => {
        this.TodoList.splice(index, 1);
        this.notification.showInfo('Delete Successful', '');
      },
      (error) => {
        this.notification.showError('error', '');
      }
    );
  }
  saveReorderTodo() {
    for (let i = 0; i < this.TodoList.length; i++) {
      this.TodoList[i].sortOrder = i + 1 ;
    }
    this.todoService.updateList(this.TodoList).subscribe(
      () => {
        this.notification.showInfo('update Task Order Successful', '');
      },
      () => {
        this.notification.showError('error', '');
      }
    );
  }
  getRandomColor() {
    // [ngStyle]="{'background-color': getRandomColor() }"
    const letters = '0123456789ABCDEF';
    let color = '#';
    for (let i = 0; i < 6; i++) {
      color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
  }
}
