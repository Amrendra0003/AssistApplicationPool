import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { StringConstants } from 'src/assets/constants/string.constants';
import { FormGroup, FormControl, FormArray, Validators } from '@angular/forms';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { AuthService } from 'src/app/services/auth.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { FileUpload } from 'src/app/services/fileupload.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: any;
  emailAddress: any;
  password: any;
  invalidLogin = ' ';
  disableLogin = false;
  public errorMessage = '';
  submitted = false;
  form: any = {};
  isLoggedIn = false;
  isLoginFailed = false;
  roles: string[] = [];
  strongRegex = new RegExp('^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#\$%\^&\*])(?=.{8,})');
  invalidEmail = false;
  invalidPassword = false;
  eventEmitterService: any;
  isRememberMe: any;
  rememberMe: any;
  fieldType: string = StringConstants.var.typePassword;
  isCheck: boolean = false;
  virtualAssistPadding: string = "virtual-assist-padding";
  isBeginClicked: boolean = false;
  currentTheme: any;
  userImageUrl: any;
  tokenForEmail: any;
  email: any
  tenantId: any;
  showLoader: any;
  welcome = StringConstants.login.welcome;
  LoginInfo = StringConstants.login.LoginInfo;
  Emailreq = StringConstants.login.Emailreq;
  EmailVal = StringConstants.login.EmailVal;
  Emailmax = StringConstants.login.Emailmax;
  RememberMe = StringConstants.login.RememberMe;
  ForgotPassword = StringConstants.login.ForgotPassword;
  Next = StringConstants.login.Next;
  NewUserInfo = StringConstants.login.NewUserInfo;
  constructor(private _route: ActivatedRoute, private dataSharingService: DataSharingService, private authService: AuthService, private loginService: LoginService,
    private router: Router, private activatedRoute: ActivatedRoute, private formbuilder: FormBuilder, private toastService: ToastServiceService, private fileUpload: FileUpload) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => { //Virtual assist
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.beginFlag.subscribe(value => { //To click begin button
      this.isBeginClicked = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => { //Theme setting
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  async ngOnInit() {
    
    this.tokenForEmail = sessionStorage.getItem("tokenForLogin");
    this.dataSharingService.hideVaForProfile.next(false);
    this.loginService.getTenantBySubDomain(window.location.host).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.tenantId = result.data;
        sessionStorage.setItem('tenant', this.tenantId);
        if(this.tokenForEmail != null){
          this.loginService.EmailTokenConfirm(this.tokenForEmail).subscribe(async (result: any) => { 
            this.toastService.showSuccessWithTime("Your email is verified, please login to continue","Email Verified");
            sessionStorage.removeItem("tokenForLogin");
          },
          (error) => {
              console.log(error);
              sessionStorage.removeItem("tokenForLogin");
          });
        }
      }
    });
    if (this.authService.isLoggedIn) {
      let hasAccessToAdvocateDashboard = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewAdvocateDashboard);
      if (hasAccessToAdvocateDashboard)
        this.router.navigate(['dashboard-advocate']);
      else
        this.router.navigate(['dashboard']);
    }
    this.initForm();
    const params = JSON.stringify(this.activatedRoute.snapshot.queryParams);
    const emailAddress = JSON.parse(params);
    this.emailAddress = emailAddress.email;
    this.getUserData();
  }
  private initForm() {
    this.loginService.getTenantBySubDomain(window.location.host).subscribe(async (result: any) => {
      this.tenantId = result.data;
      sessionStorage.setItem('tenant', this.tenantId);
    });
    this.loginForm = new FormGroup({
      'emailAddress': new FormControl('', [Validators.required, Validators.pattern('^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'), Validators.maxLength(50)]),
      'password': new FormControl('', [Validators.required]),
      'isRememberMe': new FormControl('')
    });
  }
  space(e: any) {
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
  toggleField() {
    if (this.fieldType == StringConstants.var.typeText) this.fieldType = StringConstants.var.typePassword;
    else this.fieldType = StringConstants.var.typeText;
  }
  default(e: any) {
    e.preventDefault();
  }
  checkLoginDetails() { // Login details
    let validation = true;
    if (!this.email.value || this.email.invalid) {
      this.invalidEmail = true; validation = false;
    }
    if (!this.password.value || this.password.invalid) {
      this.invalidPassword = true; validation = false;
    }
    return validation;
  }
  forgotPasswordLink() { // Forgot password
    if (!this.loginForm.value.emailAddress) {
      this.toastService.showWarning(StringConstants.toast.enterEmail, StringConstants.toast.emailRequired);
    }
    else {
      const ForgotData: any = {
        EmailAddress: this.loginForm.value.emailAddress,
      };
      this.invalidEmail = this.invalidPassword = false;
      this.loginService.ForgotPassword(ForgotData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.router.navigate(['otp'], {
            queryParams: {
              loginFlag: false,
              emailAddress: result.data.emailAddress,
              contactNumber: result.data.contactNumber,
              countryCode: result.data.countryCode
            }
          });
        }

      }, (error) => {
        if (error.status = '500') {
          this.toastService.showError(error.error.errors, StringConstants.toast.empty)
          console.log(error);
        }
        else {
          console.log(error);
        }
      });
    }
  }
  changeRememberMe(event: any) { // Remember me change event
    if (event.target.checked) {
      this.isRememberMe = true;
    }
    else {
      this.isRememberMe = false;
    }
  }
  storeUserData() { // Stroe user data
    if (this.isRememberMe == true || this.isRememberMe == "true") {
      localStorage.setItem('loginEmail', this.emailAddress);
      localStorage.setItem('loginPassword', this.password)
      localStorage.setItem('loginRememberMe', this.isRememberMe);
    }
    else if (this.isRememberMe == false || this.isRememberMe == "false") {
      if (this.emailAddress == localStorage.getItem('loginEmail')) {
        localStorage.removeItem('loginEmail');
        localStorage.removeItem('loginPassword');
        localStorage.removeItem('loginRememberMe');
      }
    }
  }
  getUserData() { //User data
    this.emailAddress = localStorage.getItem('loginEmail');
    this.password = localStorage.getItem('loginPassword');
    this.isRememberMe = localStorage.getItem('loginRememberMe');
  }
  loginMethod(loginDetails: any, tokenForEmail:any){
    
    const loginData: any = {
      emailAddress: loginDetails.emailAddress,
      password: loginDetails.password,
      enableRememberMe: this.isRememberMe,
    };
    if (!this.loginForm.valid) {
      this.submitted = true;
      return;
    }
    else {
      this.showLoader = true;
      this.invalidEmail = this.invalidPassword = false;
      this.loginService.loginUser(loginData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          sessionStorage.removeItem('showAccount');
          sessionStorage.removeItem('showText');
          this.showLoader = false;
          if (!result.data.isOTPEnabled) {
            this.showLoader = false;
            sessionStorage.setItem('token', result.data.token);
            sessionStorage.setItem('loginUserEmail', result.data.emailAddress);
            sessionStorage.setItem('loggedInPatientFullName', result.data.patientFullName);
            sessionStorage.setItem('loginUserpatientId', result.data.patientId);
            sessionStorage.setItem('userFirstName', result.data.signedInFirstName);
            sessionStorage.setItem('userId', result.data.userId);
            sessionStorage.setItem('role', result.data.role);
            sessionStorage.setItem('isLoggedIn', 'true');
            this.dataSharingService.isLoggedIn.next(true);
            await this.loginService.applyPermissions(result.data.roleId);
            this.storeUserData();
            this.viewUserImage();
            this.dataSharingService.showUserNameInHeader.next(true);
            
            if (result.data.role == StringConstants.var.ADVOCATE) {
              if (tokenForEmail != null){
                sessionStorage.setItem('tokenForEmail',tokenForEmail);
                this.router.navigate(['dashboard-advocate']);
              }
              else if (this.isBeginClicked == false)
                this.router.navigate(['dashboard-advocate']);
              else
                this.router.navigate(['create-assessment']);
            }
            else {
              this.showLoader = false;
              if (tokenForEmail != null){
                sessionStorage.setItem('tokenForEmail',tokenForEmail);
                this.router.navigate(['dashboard']);
              }
              else if (this.isBeginClicked == false)
                this.router.navigate(['dashboard']);
              else
                this.router.navigate(['patient']);
            }
          }
          else {
            this.showLoader = false;
            this.loginService.clearAllStorage();
            await this.loginService.setUserInfo(result.data);
            this.loginService.storeUserSession(result.data, this.rememberMe, loginData);
            this.router.navigate(['otp'], { queryParams: { loginFlag: true } });
          }
        }

      }, (error) => {
        this.showLoader = false;
        this.toastService.showError(error.error.errors[0], '');
      });
    }
  }
  loginUser(loginDetails: any) { //Login user
    
    const tokenForEmail = this.tokenForEmail;
    this.loginMethod(loginDetails,tokenForEmail);
  }
  viewUserImage() { // View user image
    var userId = (sessionStorage.getItem('userId')!);
    this.fileUpload.UserProfileImageDownload(userId)
      .subscribe(async (result: any) => {
        
        this.userImageUrl = result;
        this.dataSharingService.LoadUserImage.next(this.userImageUrl);
      },
        (err) => {
          console.log(StringConstants.toast.fetchError, err);
        }, () => {
        }
      )
  }
  navigateToBegin() {
    this.router.navigate(['']);
  }
}
