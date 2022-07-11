import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';
import { Observable } from 'rxjs';
const AUTH_API = 'https://secure.na1.echosign.com/public/oauth/v2/';
const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};



@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(
    private activatedRoute: ActivatedRoute,
    private http: HttpClient) { }


}

