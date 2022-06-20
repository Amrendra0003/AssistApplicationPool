import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { LoginService } from 'src/app/services/login.service';
import { TenantService } from 'src/app/services/tenant.service'
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import DateValidation from '../../controls/date-validation-control';
import { DatePipe } from '@angular/common';
import { DropdownService } from 'src/app/services/dropdown.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { CommonService } from 'src/app/services/common.service';
@Component({
  selector: 'app-activate-user',
  templateUrl: './activate-user.component.html',
  styleUrls: ['./activate-user.component.css']
})
export class ActivateUserComponent implements OnInit {
  newAccountForm: any;
  Pattern: any;
  MinLength: any;
  MaxLength: any;
  martialStatusVal: any;
  firstName: any;
  middleName: any;
  lastName: any;
  dob: any;
  cellNumber: any;
  countyCode: any = "1";
  emailAddress: any;
  newPassword: any;
  confirmnewPassword: any;
  retypePassword: any;
  passwordField: string = StringConstants.var.typePassword;
  ConfirmPasswordField: string = StringConstants.var.typePassword;
  mustMatch!: boolean;
  today = new Date();
  bsVal: any;
  dobTextbox: any;
  dobErrorMessage: any;
  currentTheme: any;
  userId: any;
  token: any;
  showLoader: any;
  genderval: any;
  maritalStatus: string = "";
  gender: string = "";
  // String Constants!
  SecureAccount = StringConstants.SetPassword.SecureAccount;
  NameReq = StringConstants.demographics.NameReq;
  NameAlp = StringConstants.demographics.NameAlp;
  NameMax = StringConstants.demographics.NameMax;
  NameChar = StringConstants.demographics.NameChar;
  MidNameReq = StringConstants.profileSetting.MidNameReq;
  MidNameAlp = StringConstants.profileSetting.MidNameAlp;
  MidNameMax = StringConstants.profileSetting.MidNameMax;
  LastNamereq = StringConstants.demographics.LastNamereq;
  LastNameAlp = StringConstants.demographics.LastNameAlp;
  LastNameMax = StringConstants.demographics.LastNameMax;
  LastNameMin = StringConstants.demographics.LastNameMin;
  DateReq = StringConstants.demographics.DateReq;
  DateFormate = StringConstants.demographics.DateFormate;
  DateFut = StringConstants.demographics.DateFut;
  GenderReq = StringConstants.demographics.GenderReq;
  Cell = StringConstants.profileSetting.Cell;
  CellNumReq = StringConstants.demographics.CellNumReq;
  CellVal = StringConstants.demographics.CellVal;
  MartialReq = StringConstants.demographics.MartialReq;
  EmailReq = StringConstants.demographics.EmailReq;
  EmailVal = StringConstants.demographics.EmailVal;
  EmailMax = StringConstants.demographics.EmailMax;
  NewPassReq = StringConstants.ChangePassword.NewPassReq;
  PassVal = StringConstants.ChangePassword.PassVal;
  PassMinLen = StringConstants.ChangePassword.PassMinLen;
  PassMaxLen = StringConstants.ChangePassword.PassMaxLen;
  PassStrInfo = StringConstants.ChangePassword.PassStrInfo;
  ReEnterYourPassword = StringConstants.ChangePassword.ReEnterYourPassword;
  PasswordMustMatch = StringConstants.ChangePassword.PasswordMustMatch;
  Create = StringConstants.Common.Create;
  errorText: any;
  showForm: any = true;
  userImageUrl: any;
  tenantId: any;
  phoneCode: any;
  constructor(private common: CommonService,private loginService: LoginService, private formbuilder: FormBuilder, private toastService: ToastServiceService, private tenentService: TenantService, private router: Router, private datepipe: DatePipe,
    private dataSharingService: DataSharingService, private dropdownService: DropdownService, private fileUpload: FileUpload) { }
  ngOnInit() {
    this.initForm();
    this.passwordPolicy();
    this.getMartialValues();
    this.getGenderValues();
    this.getPhoneCode();
  }
  getUserDetails() {
    var email = sessionStorage.getItem('emailAuth');
    this.tenentService.getUserDetails(email).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        console.log(result.data);
        this.newAccountForm.controls['firstName'].setValue(result.data.firstName);
        this.newAccountForm.controls['middleName'].setValue(result.data.middleName);
        this.newAccountForm.controls['lastName'].setValue(result.data.lastName);
        this.newAccountForm.controls['dob'].setValue(result.data.dateOfBirth);
        this.newAccountForm.controls['cellNumber'].setValue(result.data.cell);
        this.newAccountForm.controls['countyCode'].setValue(result.data.countyCode);
        this.newAccountForm.controls['emailAddress'].setValue(result.data.email);
        this.userId = result.data.userId;
      }
      else {
        this.showForm = false;
        this.toastService.showError(result.error[0], StringConstants.toast.empty);
      }
    }, (error) => {
      console.log(error);
      if (error.status == '500') {
        this.showForm = false;
        var message = JSON.parse(JSON.stringify(error))
        this.errorText = message.error.errors[0];
        this.toastService.showError(message.error.errors[0], StringConstants.toast.empty);
      }
      else if (error.status == '400') {
        this.showForm = false;
        var message = JSON.parse(JSON.stringify(error))
        this.errorText = message.error.errors[0];
        this.toastService.showError(message.error.errors[0], StringConstants.toast.empty);
      }
    });
  }
  createUserAccount(createPasswordForm: any) {
    if (!this.newAccountForm.valid) {
      this.toastService.showWarning(StringConstants.createUser.ErrorMessage, StringConstants.toast.empty);
    }
    else {
      const userData: any = {
        firstName: createPasswordForm.firstName,
        middleName: createPasswordForm.middleName,
        lastName: createPasswordForm.lastName,
        gender: createPasswordForm.gender,
        maritalStatus: createPasswordForm.maritalStatus,
        dateOfBirth: createPasswordForm.dob,
        cellNumber: createPasswordForm.cellNumber,
        countyCode: createPasswordForm.countyCode,
        emailAddress: createPasswordForm.emailAddress,
        password: createPasswordForm.newPassword,
        userId: +(this.userId),
        primaryEmail: (sessionStorage.getItem('emailAuth')!),
      };
      this.tenentService.updateUserDetails(userData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          const loginData: any = {
            emailAddress: createPasswordForm.emailAddress,
            password: createPasswordForm.newPassword,
          };
          this.loginService.loginUser(loginData).subscribe(async (result: any) => {
            if (result.wasSuccessful) {
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
                this.viewUserImage();
                this.dataSharingService.showUserNameInHeader.next(true);
                this.router.navigate(['dynamic-questions']);
                sessionStorage.removeItem('showAccount');
              }
              else {
                this.showLoader = false;
                this.loginService.clearAllStorage();
                await this.loginService.setUserInfo(result.data);
                this.loginService.storeUserSession(result.data, false, loginData);
                this.router.navigate(['otp'], { queryParams: { loginFlag: true } });
              }
            }
          }, (error) => {
            this.showLoader = false;
            console.log(error);
          });
        }
      }, (error) => {
        this.toastService.showError(error.error.errors[0], '');
        console.log(error);
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
  private initForm() {
    this.newAccountForm = this.formbuilder.group({
      'firstName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'middleName': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'lastName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'dob': new FormControl('', [Validators.required, DateValidation.validateDateFormat, DateValidation.futureDateValidation]),
      'cellNumber': new FormControl('', [Validators.required, Validators.minLength(10)]),
      'countyCode': new FormControl('1', [Validators.required]),
      'emailAddress': new FormControl('', [Validators.required,Validators.pattern('^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'), Validators.maxLength(50)]),
      'newPassword': new FormControl('', [Validators.required, Validators.pattern(this.Pattern), Validators.maxLength(this.MaxLength), Validators.minLength(this.MinLength)]),
      'confirmnewPassword': new FormControl('', [Validators.required]),
      'maritalStatus': new FormControl('', Validators.required),
      'gender': new FormControl('', Validators.required),
    },
      {
        validator: this.MustMatch('newPassword', 'confirmnewPassword'),
      }
    );
    this.getUserDetails();
  }
  space(e: any) {
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
  passwordPolicy() {
    this.tenentService.getPasswordPolicy(window.location.host).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.Pattern = result.data.pattern;
        this.MinLength = result.data.minimumLength;
        this.MaxLength = result.data.maximumLength;
        this.initForm();
      }
    });
  }
  async getMartialValues() {//To get martial status option values
    this.martialStatusVal = await this.common.getMartialValues();
  }
  togglePassword() {
    if (this.passwordField == StringConstants.var.typeText) this.passwordField = StringConstants.var.typePassword;
    else this.passwordField = StringConstants.var.typeText;
  }
  toggleConfirmPassword() {
    if (this.ConfirmPasswordField == StringConstants.var.typeText) this.ConfirmPasswordField = StringConstants.var.typePassword;
    else this.ConfirmPasswordField = StringConstants.var.typeText;
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
  async getGenderValues() { //To get gender values
    this.genderval = await this.common.getGenderValues();
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  selectDate(event: any) {
    if (event != undefined && event != "" && event != null) {
      var newVal = this.datepipe.transform(event, 'MM/dd/yyyy');
      this.newAccountForm.controls['dob'].setValue(newVal);
      this.checkpattern();
    }
  }
  keyPress(event: KeyboardEvent) {
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  }
  closeCalendar() {
    DateValidation.closeCal();
    this.captureDateInDatepicker();
  }
  captureDateInDatepicker() {
    if (this.newAccountForm.controls.dob.errors == null) {
      var bsValueDOB = this.newAccountForm.get('dob').value;
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
    } else {
      this.bsVal = "";
    }
  }
  checkpattern() {
    var result = false;
    var futureValidation = false;
    var dateCheck;
    this.dobTextbox = document.getElementById('dob');
    var bsValueDOB = this.newAccountForm.get('dob').value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
        dateCheck = this.datepipe.transform(bsValueDOB, 'MM/dd/yyyy');
        if (DateValidation.validateFutureDate(dateCheck != null ? dateCheck : "")) {
          result = true;
        } else {
          result = false;
          futureValidation = true;
        }
      }
    }
    if (!result) {
      this.newAccountForm.patchValue({
        dob: ""
      });
      this.dobTextbox.focus();
      this.bsVal = "";
      this.dobErrorMessage = futureValidation ? "Date of Birth can not be in future." : "Date must be in mm/dd/yyyy format."
      this.newAccountForm.controls['dob'].setErrors({ pattern: true });
    } else {
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
      this.newAccountForm.controls['dob'].setValue(dateCheck);
    }
  }
}
