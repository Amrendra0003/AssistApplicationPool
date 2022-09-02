import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { throwError } from 'rxjs';
import { LoginRequest } from '../shared/loginRequest';
import { ApiConstants } from '../../assets/constants/url'
import { environment } from 'src/environments/environment';
import { NgxPermissionsService } from 'ngx-permissions';
@Injectable({
  providedIn: 'root'
})
export class LoginService {
  static userInfo: any;
  static emailAddress: any;
  constructor(private http: HttpClient, private permissionsService: NgxPermissionsService) {
  }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set("tenant", (sessionStorage.getItem('tenant')!)).set("tenant", (sessionStorage.getItem('tenant')!));
  }
  httpgetRequest(url: string) { 
    return this.http.get(url);
  }
  loginUser(loginDetails: LoginRequest) { // login
    
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.Login, loginDetails, { headers: this.headers });
  }
  EmailTokenConfirm(token: any){
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.EmailToken + "?token=" + token , { headers: this.headers });
  }
  LoginWithoutOtp(loginDetails: LoginRequest) { // login without otp
    
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.LoginWithoutOtp, loginDetails, this.httpOptions);
  }
  async setUserInfo(userInfo: any) {
    LoginService.userInfo = userInfo;
  }
  Logout(logoutDetails: any) { //user info
    
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.Logout + "?userId=" + logoutDetails, this.httpOptions);
  }
  storeUserSession(userDetails: any, rememberMe: any, loginData: LoginRequest) { //User session
    sessionStorage.setItem('userEmail', userDetails.emailAddress);
    sessionStorage.setItem('userName', userDetails.userName);
    sessionStorage.setItem('contactNumber', userDetails.contactNumber);
    sessionStorage.setItem('countryCode', userDetails.countryCode);
    if (loginData.enableRememberMe == true) {
      localStorage.setItem('userCrendentials', JSON.stringify(loginData));
      localStorage.setItem('isRememberMe', 'true');
    }
  }
  clearAllStorage() {
    sessionStorage.clear();
  }
  isLoggedIn(): boolean { // isLogin
    if ((sessionStorage.getItem('isLoggedIn') || sessionStorage.getItem('isLoggedIn')) == 'true') {
      return true;
    } else {
      return false;
    }
  }
  getUserCredentials() { // User credentials
    return JSON.parse(localStorage.getItem('userCrendentials')!);
  }
  isRememberMe() { // Remember me
    if (localStorage.getItem('isRememberMe') === 'true') {
      return true;
    }
    return false;
  }
  sendOtp(loginOptions: any) { // Send Otp
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.Otp, loginOptions, this.httpOptions);
  }
  validateOtp(validation: any) { // Validate Otp
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.ValidateOtp, validation, this.httpOptions);
  }
  ResetPassword(resetPwd: any) { // Reset password
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.ResetPassword, resetPwd, { headers: this.headers });
  }
  ChangePassword(resetPwd: any) { // Change password
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.ChangePassword, resetPwd, { headers: this.headers });
  }
  ForgotPassword(emailDetails: any) { // Forgot password
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.ForgotPassword, emailDetails, this.httpOptions);
  }
  async applyPermissions(roleId: any): Promise<void> { // To apply permission
    this.getUserPermission(roleId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        const perm = result.data;
        if (perm) {
          this.permissionsService.loadPermissions(perm)
          sessionStorage.setItem('permissions', JSON.stringify(perm));
        }
      }
    });
  }
  getTenantBySubDomain(subDomain: string) { // Get tenant By Subdomain
    
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetTenantBySubDomain + "?subDomain=" + subDomain);
  }
  getUserPermission(roleId: any) { // Get user permission
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.GetUserPermissions + "?roleId=" + roleId);
  }
  handleError(error: any) {  // Error handling 
    let errorMessage = '';
    if (error.error instanceof ErrorEvent) {  // Get client-side error
      errorMessage = error.error.message;
    } else { // Get server-side error
      errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
    }
    window.alert(errorMessage);
    return throwError(errorMessage);
  }
}
