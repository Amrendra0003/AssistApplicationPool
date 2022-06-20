import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { DropdownService } from './dropdown.service';
import { ApiConstants } from '../../assets/constants/url';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class CommonService {
  genderval: any;
  headers: any;
  response: any;
  martialStatusVal: any;
  relationval: any;
  resultSuccessful: any;
  result: any;
  phoneCode = {"1": "1","91": "91","44": "44",}
  reasonNoSSN: any;
  constructor(public dropdownService: DropdownService, private http: HttpClient) {
  }
  async getGenderValues() { //To get gender values
    this.headers = new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
    this.response = await this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.Gender, { headers: this.headers }).toPromise();
    this.genderval = this.response.data;
    return this.genderval;
  }
  async getMartialValues() { //To get martial values
    this.headers = new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
    this.response = await this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.Marital, { headers: this.headers }).toPromise();
    this.martialStatusVal = this.response.data;
    return this.martialStatusVal;
  }
  async getRelationValues() { //To get relation values
    this.headers = new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
    this.response = await this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.Relatioship, { headers: this.headers }).toPromise();
    this.relationval = this.response.data;
    return this.relationval;
  }
  async getStateAndCity(zipCode: any) { // To get state and city
    this.headers = new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
    this.response = await this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.GetStateAndCity + "?zipcode=" + zipCode, { headers: this.headers }).toPromise();
    return this.response;
  }
  async getReasonNoSSN(){
    this.headers = new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
    this.response = await this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.GetReasonNoSSN, { headers: this.headers }).toPromise();
    this.reasonNoSSN = this.response.data;
    return this.reasonNoSSN;
  }
  async getPhoneCode(){
    this.response = this.phoneCode;
    return this.response;
  }
}

