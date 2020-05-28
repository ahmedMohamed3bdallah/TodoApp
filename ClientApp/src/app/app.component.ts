import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/services/auth.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  constructor(private authService: AuthService, private route: Router) {}
  ngOnInit(): void {
    if (!this.authService.loggedIn) {
      this.route.navigate(['/login']);
    }
  }
}
