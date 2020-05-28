import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/services/auth.service';
import { UserDTO } from 'src/model/UserDTO';
import { NotificationService } from 'src/services/notification.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css'],
})
export class LoginPageComponent implements OnInit {
  userDto = new UserDTO();
  constructor(
    private router: Router,
    private authService: AuthService,
    private notification: NotificationService
  ) {}

  ngOnInit(): void {}
  login(): void {
    if (this.userDto.UserName && this.userDto.Password) {
      this.authService.login(this.userDto).subscribe(
        (data) => {
          this.notification.showSuccess('Logged In Successful', '');
        },
        (error) => {
          this.notification.showError('failed to LogIn !!!', '');
        },
        () => {
          this.router.navigate(['/home']);
        }
      );
      // this.router.navigate(['home']);
    } else {
      alert('Invalid credentials');
    }
  }
}
