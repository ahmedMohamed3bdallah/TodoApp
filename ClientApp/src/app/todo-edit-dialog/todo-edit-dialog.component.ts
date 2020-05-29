import { Component, OnInit, Inject } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { TodoDTO } from 'src/model/TodoDTO';

@Component({
  selector: 'app-todo-edit-dialog',
  templateUrl: './todo-edit-dialog.component.html',
  styleUrls: ['./todo-edit-dialog.component.css'],
})
export class TodoEditDialogComponent implements OnInit {
  constructor(@Inject(MAT_DIALOG_DATA) public data: TodoDTO) {
  }

  ngOnInit(): void {}
  onNoClick() {}
}
