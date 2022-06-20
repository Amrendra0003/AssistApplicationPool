import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-pagenotfound',
  templateUrl: './pagenotfound.component.html',
  styleUrls: ['./pagenotfound.component.css']
})
export class PagenotfoundComponent implements OnInit {
  AccessDenied = StringConstants.Common.AccessDenied;
  constructor(private router: Router) {
  }
  ngOnInit(): void {
  }
  redirectToLogin() {
    this.router.navigate(['login']);
  }
}