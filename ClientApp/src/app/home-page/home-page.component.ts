import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/services/auth.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  title = 'Todo Application';
  constructor(private authService: AuthService) { }

  ngOnInit(): void {
  }
  Logout(){
    this.authService.logOut();
  }

}
