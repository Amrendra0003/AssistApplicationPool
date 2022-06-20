import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NgxPermissionsService } from 'ngx-permissions';
import { AuthService } from 'src/app/services/auth.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { LoginService } from 'src/app/services/login.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  [x: string]: any;
  accountForm: any;
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
  fieldType: string = 'password';
  isCheck: boolean = false;
  virtualAssistPadding: string = "virtual-assist-padding";
  isBeginClicked: boolean = false;
  currentTheme: any;
  rememberMe: any;
  titleMessage: string = StringConstants.account.CreatedAccountTitle;
  loginLabel: string = StringConstants.common.loginLabel;
  toggleField() {
    if (this.fieldType == 'text') this.fieldType = 'password';
    else this.fieldType = 'text';
  }
  constructor(private dataSharingService: DataSharingService, private authService: AuthService, private loginService: LoginService,
    private router: Router, private formbuilder: FormBuilder, private toastService: ToastServiceService, private permissionsService: NgxPermissionsService) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.beginFlag.subscribe(value => {
      this.isBeginClicked = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    if (this.router && !this.router.navigated)
      this.router.navigate(['']);
  }
  ngOnInit(): void {
    this.dataSharingService.hideVaForProfile.next(false);
    this.emailAddress = sessionStorage.getItem('userEmail');
    this.initForm();
  }
  private initForm() {
    this.accountForm = new FormGroup({
      'emailAddress': new FormControl('', [Validators.required, Validators.pattern('^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'), Validators.maxLength(50)]),
      'password': new FormControl('', [Validators.required]),
    });
  }
  space(e: any) {
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
  default(e: any) {
    e.preventDefault();
  }
  checkLoginDetails() {
    let validation = true;
    if (!this.email.value || this.email.invalid) {
      this.invalidEmail = true; validation = false;
    }
    if (!this.password.value || this.password.invalid) {
      this.invalidPassword = true; validation = false;
    }
    return validation;
  }
  forgotPasswordLink() {
    console.log(this.accountForm.value);
    if (!this.accountForm.value.emailAddress) {
      this.toastService.showWarning(StringConstants.toast.enterEmail, StringConstants.toast.emailRequired);
    }
    else {
      const ForgotData: any = {
        EmailAddress: this.accountForm.value.emailAddress,
      };
      this.invalidEmail = this.invalidPassword = false;
      this.loginService.ForgotPassword(ForgotData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          console.log(result.data);
          this.loginService.clearAllStorage();
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
        this.toastService.showError(error.error.errors, "")
        console.log(error);
      });
    }
  }
  loginUser(loginDetails: any) {
    const loginData: any = {
      EmailAddress: loginDetails.emailAddress,
      Password: loginDetails.password,
    };
    if (!this.accountForm.valid) {
      this.submitted = true;
      return;
    }
    else {
      this.invalidEmail = this.invalidPassword = false;
      this.loginService.loginUser(loginData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          if (!result.data.isOTPEnabled) {
            sessionStorage.setItem('token', result.data.token);
            sessionStorage.setItem('loggedInPatientFullName', result.data.patientFullName);
            sessionStorage.setItem('loginUserpatientId', result.data.patientId);
            sessionStorage.setItem('userFirstName', result.data.signedInFirstName);
            sessionStorage.setItem('userId', result.data.userId);
            sessionStorage.setItem('role', result.data.role);
            sessionStorage.setItem('isLoggedIn', 'true');
            this.dataSharingService.isLoggedIn.next(true);
            this.dataSharingService.showUserNameInHeader.next(true);
            this.router.navigate(['patient-zipcode']);
          }
          else {
            this.loginService.clearAllStorage();
            await this.loginService.setUserInfo(result.data);
            this.loginService.storeUserSession(result.data, this.rememberMe, loginData);
            this.router.navigate(['otp'], { state: { loginFlag: true } });
          }
        }
      }, (error) => {
        if (error.status = '500') {
          this.toastService.showError(StringConstants.toast.incorrectPassword, StringConstants.toast.loginFailed);
        }
        else {
          this.toastService.showWarning(StringConstants.toast.httpError, StringConstants.toast.serverError);
        }
      });
    }
  }
}