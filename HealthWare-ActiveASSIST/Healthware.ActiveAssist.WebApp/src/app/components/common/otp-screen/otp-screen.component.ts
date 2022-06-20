import { Component, OnInit, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { LoginService } from 'src/app/services/login.service';
import { Location } from '@angular/common';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { AuthService } from 'src/app/services/auth.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-otp-screen',
  templateUrl: './otp-screen.component.html',
  styleUrls: ['./otp-screen.component.css']
})
export class OtpScreenComponent implements OnInit {
  otpForm: any;
  modeForm: any
  formInput = ['input1', 'input2', 'input3', 'input4'];
  otpFormFlag: any;
  @ViewChildren('formRow') rows: any;
  userEmail: any;
  contactNumber: any;
  userName: any;
  loginFlag: any;
  countryCode: any;
  mode: string = "";
  clicked: boolean = false;
  mobClicked: boolean = false;
  isResendClicked: boolean = false;
  isBeginClicked: boolean = false;
  userImageUrl: any;
  isSend: any;
  isResend: any;
  isSendFlag: any;
  isResendFlag: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  currentTheme: any;
  PleaseWait = StringConstants.OtpScreen.PleaseWait;
  ConfirmIdentity = StringConstants.OtpScreen.ConfirmIdentity;
  ConfirmationCodeSent = StringConstants.OtpScreen.ConfirmationCodeSent;
  ConfirmationCodeSent2Hours = StringConstants.OtpScreen.ConfirmationCodeSent2Hours;
  NotReceive = StringConstants.OtpScreen.NotReceive;
  ResendCode = StringConstants.Common.ResendCode;
  Cancel = StringConstants.Common.Cancel;
  Login = StringConstants.header.Login;
  Next = StringConstants.common.nextLabel;
  constructor(private loginService: LoginService, private router: Router, private formbuilder: FormBuilder,
    private activatedRoute: ActivatedRoute, private location: Location, private toastService: ToastServiceService,
    private dataSharingService: DataSharingService, private authService: AuthService, private fileUpload: FileUpload) {
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
  ngOnInit() {
    this.dataSharingService.hideVaForProfile.next(false);
    if (this.authService.isLoggedIn) this.router.navigate(['dashboard']);
    this.userEmail = sessionStorage.getItem('userEmail');
    this.contactNumber = sessionStorage.getItem('contactNumber');
    this.userName = sessionStorage.getItem('userName');
    this.countryCode = sessionStorage.getItem('countryCode');
    this.initForm();
    this.otpForm = this.toFormGroup(this.formInput);
    this.modeForm.reset();
  }
  toFormGroup(elements: any[]) {
    const group: any = {};
    elements.forEach(key => {
      group[key] = new FormControl('', Validators.required);
    });
    return new FormGroup(group);
  }
  private initForm() {
    const flag = JSON.stringify(this.activatedRoute.snapshot.queryParams);
    const flagObj = JSON.parse(flag);
    this.loginFlag = (/true/i).test(flagObj.loginFlag);
    if (flagObj.loginFlag == "true") {
      this.userEmail = sessionStorage.getItem('userEmail');
    }
    else if (flagObj.loginFlag == "false") {
      this.userEmail = flagObj.emailAddress;
      this.contactNumber = flagObj.contactNumber;
      this.countryCode = flagObj.countryCode;
      sessionStorage.setItem('resetEmail', this.userEmail);
    }
    this.modeForm = new FormGroup({
      'mode': new FormControl(''),
    });
  }
  default(e: any) {
    e.preventDefault();
  }
  setMode(type: string) {
    if (type == StringConstants.var.cell) {
      this.modeForm.controls['mode'].setValue('Cell');
    }
    else if (type == StringConstants.var.mail) {
      this.modeForm.controls['mode'].setValue('Mail');
    }
    this.chooseMode();
  }
  chooseMode() {
    if (this.modeForm.get('mode').value == StringConstants.var.cell) {
      this.mobClicked = true;
      this.clicked = false;
      this.sendOtpForMobile();
    }
    else if (this.modeForm.get('mode').value == StringConstants.var.mail) {
      this.clicked = true;
      this.mobClicked = false;
      this.sendOtp();
    }
  }
  sendOtpForMobile() {
  }
  sendOtp() {
    this.otpFormFlag = false;
    this.isResendClicked = true;
    setTimeout(() => {
      this.isResendClicked = false;
    }, 35000)
    this.isSendFlag = true;
    const loginData: any = {
      EmailAddress: this.userEmail,
      LoginFlag: this.loginFlag
    };
    this.loginService.sendOtp(loginData).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.isResendFlag = false;
        this.otpFormFlag = true;
        this.toastService.showSuccess(StringConstants.toast.checkMail, StringConstants.toast.otpSent);
        this.isResend = this.isResendFlag;
        this.isSend = this.isSendFlag;
      }
    }, (error: { status: string; error: { errors: any; }; }) => {
      console.log(error);
    });
  }
  resendOtp() {
    if (!this.isResendClicked) {
      this.isResendClicked = true;
      setTimeout(() => {
        this.isResendClicked = false;
      }, 31000)
      this.isResendFlag = true;
      const loginData: any = {
        EmailAddress: this.userEmail,
        LoginFlag: this.loginFlag
      };
      this.loginService.sendOtp(loginData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.isSendFlag = false;
          this.otpFormFlag = true;
          this.toastService.showSuccess(StringConstants.toast.checkMail, StringConstants.toast.otpResent);
          this.isSend = this.isSendFlag;
          this.isResend = this.isResendFlag;
          setTimeout(() => {
            this.isResendFlag = false;
            this.isSendFlag = true;
          }, 25000)
        }
      }, (error: { status: string; error: { errors: any; }; }) => {
        console.log(error);
      });
    }
  }
  validateOtpForLogin() {
    if (this.isResendFlag == true && this.isSendFlag == true || this.isSendFlag == false && this.isResendFlag == false) {
    }
    else if (this.isSend == true && this.isResend == false || this.isResend == true && this.isSend == false) {
      if (!this.otpForm.valid) {
        this.toastService.showWarning(StringConstants.toast.enterOtp, StringConstants.toast.empty);
      }
      else {
        const otpLoginData: any = {
          OTPNumber: this.otpForm.value.input1 + this.otpForm.value.input2 + this.otpForm.value.input3 + this.otpForm.value.input4,
          emailAddress: this.userEmail
        };
        this.loginService.validateOtp(otpLoginData).subscribe(async (result: any) => {
          if (result.wasSuccessful) {
            sessionStorage.setItem('token', result.data.token);
            sessionStorage.setItem('loginUserEmail', result.data.emailAddress);
            sessionStorage.setItem('loggedInPatientFullName', result.data.patientFullName);
            sessionStorage.setItem('loginUserpatientId', result.data.patientId);
            sessionStorage.setItem('userFirstName', result.data.signedInFirstName);
            sessionStorage.setItem('userId', result.data.userId);
            sessionStorage.setItem('role', result.data.role);
            sessionStorage.setItem('isLoggedIn', 'true');
            this.dataSharingService.isLoggedIn.next(true);
            this.loginService.applyPermissions(result.data.roleId);
            this.viewUserImage();
            this.dataSharingService.showUserNameInHeader.next(true);
            let role = result.data.role;
            switch (role) {
              case StringConstants.var.PATIENT:
                if (this.isBeginClicked == false)
                  this.router.navigate(['dashboard']);
                else
                  this.router.navigate(['patient']);
                break;
              case StringConstants.var.ADVOCATE:
                if (this.isBeginClicked == false)
                  this.router.navigate(['dashboard-advocate']);
                else
                  this.router.navigate(['create-assessment']);
                break;
              default: {
                break;
              }
            }

          }
        }, (error: { status: string; error: { errors: any; }; }) => {
          if (error.status = '500') {
            this.toastService.showError(StringConstants.toast.enterValidOtp, StringConstants.toast.invalidOtp);
          }
          else {
            console.log(error);
          }
        });
      }
    }
  }
  validateOtpForResetPassword() {
    if (this.isResendFlag == true && this.isSendFlag == true || this.isSendFlag == false && this.isResendFlag == false) {
    }
    else if (this.isSend == true && this.isResend == false || this.isResend == true && this.isSend == false) {
      if (!this.otpForm.valid) {
        this.toastService.showWarning(StringConstants.toast.enterOtp, StringConstants.toast.empty);
      }
      else {
        const otpResetData: any = {
          OTPNumber: this.otpForm.value.input1 + this.otpForm.value.input2 + this.otpForm.value.input3 + this.otpForm.value.input4,
          emailAddress: this.userEmail
        };
        this.loginService.validateOtp(otpResetData).subscribe(async (result: any) => {
          if (result.wasSuccessful) {
            this.router.navigate(['reset-password']);
          }
        }, (error: { status: string; error: { errors: any; }; }) => {
          if (error.status = '500') {
            this.toastService.showError(StringConstants.toast.enterValidOtp, StringConstants.toast.invalidOtp);
          }
          else {
            console.log(error);
          }
        });
      }
    }
  }
  viewUserImage() {
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
  keyUpEvent(event: { keyCode: number; which: number; ctrlKey: boolean; key: string }, index: number) {
    if (event.ctrlKey || event.key == 'Control') {
      this.rows._results[0].nativeElement.focus();
    }
    else {
      let pos = index;
      if (event.keyCode === 8 && event.which === 8) {
        pos = index - 1;
      } else {
        pos = index + 1;
      }
      if (pos > -1 && pos < this.formInput.length) {
        this.rows._results[pos].nativeElement.focus();
      }
    }
  }
  cancelform() {
    this.router.navigate(['login']);
  }
}