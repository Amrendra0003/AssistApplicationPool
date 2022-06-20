import { Component, HostListener } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './services/auth.service';
import { NgxPermissionsService } from 'ngx-permissions';
import { HttpClient } from '@angular/common/http';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(private authService: AuthService, private router: Router, private permissionsService: NgxPermissionsService,
    private http: HttpClient) { }
  ngOnInit(): void {
  }
  title = 'Healthware';
  @HostListener('window:click', ['$event'])
  HandleOnclick(event: MouseEvent) {
    this.checkUserActiveness();
  }
  async checkUserActiveness() {
    const isUserActive = await this.authService.IsSessionActive();
    if (isUserActive) {
      await this.authService.keepSessionAlive();
    } else {
      await this.authService.logout();
      this.router.navigate(['login']);
    }
  }
}
