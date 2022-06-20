import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiConstants } from '../../assets/constants/url'
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class DropdownService {
  authorization: any = sessionStorage.getItem('token');
  constructor(private http: HttpClient) {
  }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': "application/json",
      'token': this.authorization
    })
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
  }
  GetGenderValues() { // Gender options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.Gender);
  }
  GetRelationship() { // Relation options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.Relatioship, { headers: this.headers });
  }
  GetMaritalStatus() { //Marital status options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.Marital);
  }
  GetIncome() { // Income options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.Income, { headers: this.headers });
  }
  GetIcomeCurrentStatus() { //Income current status
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.IcomeCurrentStatus, { headers: this.headers });
  }
  GetVerification() { //Get verification
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.Verification, { headers: this.headers });
  }
  GetGrossPayPeriod() { // Gross pay period options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GrossPayPeriod, { headers: this.headers });
  }
  GetResource() { // Resource options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.Resource, { headers: this.headers });
  }
  GetResourceCurrentStatus() { // Resource current status options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.ResourceCurrentStatus, { headers: this.headers });
  }
  GetPreferredCell(address: any) { // Preferred cell
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetPreferredCell, address, { headers: this.headers });
  }
  GetPreferredAddress(address: any) { // Preferred address
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetPreferredAddress, address, { headers: this.headers });
  }
  GetPreferredEmail(address: any) { //Preferred email
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetPreferredEmail, address, { headers: this.headers })
  }
  GetReasonNoSSN() { //SSN options
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetReasonNoSSN, { headers: this.headers });
  }
}