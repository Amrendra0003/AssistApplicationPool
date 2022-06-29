import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-email-verification',
  templateUrl: './email-verification.component.html',
  styleUrls: ['./email-verification.component.css']
})
export class EmailVerificationComponent implements OnInit {
  tokenForEmail: any;
  constructor(private _route: ActivatedRoute, private router: Router) { }

  ngOnInit(){
    const token = this._route.snapshot.queryParams['token'];
    sessionStorage.setItem('tokenForLogin',token);
    sessionStorage.setItem('assessmentIdFromUrl',this._route.snapshot.queryParams['assessmentid']);
    this.router.navigate(['login']);
  }
}
