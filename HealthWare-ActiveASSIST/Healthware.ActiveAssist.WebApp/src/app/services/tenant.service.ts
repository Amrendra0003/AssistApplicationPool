import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiConstants } from 'src/assets/constants/url';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class TenantService {
  authorization: any = sessionStorage.getItem('token');
  constructor(private http: HttpClient) {
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set("tenant", (sessionStorage.getItem('tenant')!)).set("tenant", (sessionStorage.getItem('tenant')!));
  }
  getUserDetails(email: any) { // Get user Details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetUserDetails + "?email=" + email);
  }
  updateUserDetails(userDetails: any) { //UPdate user details
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.updateUserDetails, userDetails, { headers: this.headers });
  }
  getPasswordPolicy(subDomain: string) { //Get password policy
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetPasswordPolicy + "?subDomain=" + subDomain);
  }
}