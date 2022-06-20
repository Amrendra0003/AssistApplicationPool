import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { LoginService } from 'src/app/services/login.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-create-account',
  templateUrl: './create-account.component.html',
  styleUrls: ['./create-account.component.css']
})
export class CreateAccountComponent implements OnInit {
  createAccountForm: any;
  emailAddress: any;
  fieldType: string = 'password';
  mustMatch!: boolean;
  virtualAssistPadding: string = "virtual-assist-padding";
  password: any;
  firstName: any;
  lastName: any;
  dateOfBirth: any;
  gender: any;
  maritalStatus: any;
  cellNumber: any;
  countyCode: any;
  currentTheme: any;
  invalidEmail = false;
  invalidPassword = false;
  rememberMe: any;
  userImageUrl: any;
  titleMessage: string = StringConstants.account.title;
  PassReq = StringConstants.account.PassReq;
  Emailmax = StringConstants.login.Emailmax;
  Emailreq = StringConstants.login.Emailreq;
  PassReq1 = StringConstants.account.PassReq1;
  PassMin = StringConstants.account.PassMin;
  PassMax = StringConstants.account.PassMax;
  ReEnterYourPassword = StringConstants.ChangePassword.ReEnterYourPassword;
  PasswordMustMatch = StringConstants.ChangePassword.PasswordMustMatch;
  passwordMessageInfo: string = StringConstants.account.passwordMessageInfo;
  loginLabel: string = StringConstants.common.loginLabel;
  messageInfo: string = StringConstants.account.messageInfo;
  constructor(private dataSharingService: DataSharingService, private loginService: LoginService, private router: Router, private toastService: ToastServiceService, private formbuilder: FormBuilder,
    private activatedRoute: ActivatedRoute, private fileUpload: FileUpload, private quickAssessmentService: QuickAssessmentService) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
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
    this.initForm();
    this.emailAddress = sessionStorage.getItem('userEmail');
    this.firstName = sessionStorage.getItem('userFirstName');
    this.lastName = sessionStorage.getItem('userLastName');
    this.dateOfBirth = sessionStorage.getItem('userDateOfBirth');
    this.gender = sessionStorage.getItem('userGender');
    this.maritalStatus = sessionStorage.getItem('userMaritalStatus');
    this.cellNumber = sessionStorage.getItem('userCellNumber');
    this.countyCode = sessionStorage.getItem('userCountyCode');

  }
  toggleField() {
    if (this.fieldType == 'text') this.fieldType = 'password';
    else this.fieldType = 'text';
  }
  MustMatch(controlName: string, matchingControlName: string) {
    return (formGroup: FormGroup) => {
      const control = formGroup.controls[controlName];
      const matchingControl = formGroup.controls[matchingControlName];
      if (matchingControl.errors && !matchingControl.errors.mustMatch) {
        return
      }
      if (control.value !== matchingControl.value) {
        matchingControl.setErrors({ mustMatch: true });
      }
      else {
        matchingControl.setErrors(null)
      }
    }
  }
  private initForm() {
    this.createAccountForm = this.formbuilder.group({
      emailAddress: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required, Validators.pattern('^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'), Validators.maxLength(20), Validators.minLength(8)]),
      confirmnewPassword: new FormControl('', [Validators.required]),
    },
      {
        validator: this.MustMatch('password', 'confirmnewPassword'),
      }
    );
  }
  space(e: any) {
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
  default(e: any) {
    e.preventDefault();
  }
  createAccont(createAccountForm: any) {
    if (!this.createAccountForm.valid) {
      this.toastService.showWarning(StringConstants.toast.enterPassword, StringConstants.toast.empty);
    }
    else {
      const userDetails = {
        firstName: this.firstName,
        lastName: this.lastName,
        dateOfBirth: this.dateOfBirth,
        gender: this.gender,
        maritalStatus: this.maritalStatus,
        emailAddress: this.emailAddress,
        cellNumber: this.cellNumber,
        countyCode: this.countyCode,
        password: createAccountForm.password
      }
      this.quickAssessmentService.createUserProfile(userDetails).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.invalidEmail = this.invalidPassword = false;
          const loginData: any = {
            EmailAddress: this.emailAddress,
            Password: createAccountForm.password,
          };
          this.loginService.LoginWithoutOtp(loginData).subscribe(async (result: any) => {
            if (result.wasSuccessful) {
              sessionStorage.setItem('token', result.data.token);
              sessionStorage.setItem('loggedInPatientFullName', result.data.signedInFirstName + "" + result.data.signedInLastName);
              sessionStorage.setItem('loginUserpatientId', result.data.patientId);
              sessionStorage.setItem('userFirstName', result.data.signedInFirstName);
              sessionStorage.setItem('userId', result.data.userId);
              sessionStorage.setItem('role', result.data.role);
              sessionStorage.setItem('isLoggedIn', 'true');
              this.dataSharingService.isLoggedIn.next(true);
              this.loginService.applyPermissions(result.data.roleId);
              this.viewUserImage();
              this.dataSharingService.showUserNameInHeader.next(true);
              this.router.navigate(['patient-zipcode']);
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
      }, (error) => {
        console.log(error)
      });
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
}
