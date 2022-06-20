import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { LoginService } from 'src/app/services/login.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { TenantService } from 'src/app/services/tenant.service'
@Component({
  selector: 'app-change-password',
  templateUrl: './change-password.component.html',
  styleUrls: ['./change-password.component.css']
})
export class ChangePasswordComponent implements OnInit {
  changePasswordForm: any;
  email: any;
  mustMatch!: boolean;
  passwordToggle: string = StringConstants.var.typePassword;
  newPasswordToggle: string = StringConstants.var.typePassword;
  confirmPasswordToggle: string = StringConstants.var.typePassword;
  currentTheme: any;
  Pattern: any;
  MinLength: any;
  MaxLength: any;
  ChangePassword = StringConstants.ChangePassword.ChangePassword;
  EnterCurrentPassword = StringConstants.ChangePassword.EnterCurrentPassword;
  PassReq = StringConstants.ChangePassword.PassReq;
  PassVal = StringConstants.ChangePassword.PassVal;
  PassMinLen = StringConstants.ChangePassword.PassMinLen;
  PassMaxLen = StringConstants.ChangePassword.PassMaxLen;
  NewPass = StringConstants.ChangePassword.NewPass;
  NewPassReq = StringConstants.ChangePassword.NewPassReq;
  ReEnterYourPassword = StringConstants.ChangePassword.ReEnterYourPassword;
  PasswordMustMatch = StringConstants.ChangePassword.PasswordMustMatch;
  PassStrInfo = StringConstants.ChangePassword.PassStrInfo;
  Cancel = StringConstants.Common.Cancel;
  Update = StringConstants.ChangePassword.Update;
  constructor(private tenentService: TenantService, private dataSharingService: DataSharingService, private loginService: LoginService, private router: Router, private toastService: ToastServiceService, private formbuilder: FormBuilder,
    private activatedRoute: ActivatedRoute) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit(): void {
    this.passwordPolicy();
  }
  togglePassword() {
    if (this.passwordToggle == StringConstants.var.typeText)
      this.passwordToggle = StringConstants.var.typePassword;
    else this.passwordToggle = StringConstants.var.typeText;
  }
  toggleNewPassword() {
    if (this.newPasswordToggle == StringConstants.var.typeText)
      this.newPasswordToggle = StringConstants.var.typePassword;
    else this.newPasswordToggle = StringConstants.var.typeText;
  }
  toggleConfirmPassword() {
    if (this.confirmPasswordToggle == StringConstants.var.typeText)
      this.confirmPasswordToggle = StringConstants.var.typePassword;
    else this.confirmPasswordToggle = StringConstants.var.typeText;
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
    this.changePasswordForm = this.formbuilder.group({
      currentPassword: new FormControl('', [Validators.required, Validators.pattern(this.Pattern), Validators.maxLength(this.MaxLength), Validators.minLength(this.MinLength)]),
      newPassword: new FormControl('', [Validators.required, Validators.pattern(this.Pattern), Validators.maxLength(this.MaxLength), Validators.minLength(this.MinLength)]),
      confirmnewPassword: new FormControl('', [Validators.required]),
    },
      {
        validator: this.MustMatch('newPassword', 'confirmnewPassword'),
      }
    );
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
  changePassword(changePassword: any) {
    if (!this.changePasswordForm.valid) {
      this.toastService.showWarning(StringConstants.toast.enterPassword, StringConstants.toast.empty);
    }
    else {
      this.email = sessionStorage.getItem('loginUserEmail');
      const resetData: any = {
        emailAddress: sessionStorage.getItem('loginUserEmail'),
        oldPassword: changePassword.currentPassword.trim(),
        newPassword: changePassword.confirmnewPassword.trim(),
        fromProfileSettings: true
      };
      this.loginService.ChangePassword(resetData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.toastService.showSuccess(StringConstants.toast.passwordUpdated, StringConstants.toast.empty);
          sessionStorage.clear();
          this.dataSharingService.showUserNameInHeader.next(false);
          this.dataSharingService.beginFlag.next(false);
          this.dataSharingService.logoutTriggered.next(true);
          this.router.navigate(['login']);
        }
      }, (error) => {
        if (error.status = '400') {
          this.toastService.showError(error.error.errors[0], StringConstants.toast.tryAgain);
        }
        else {
        }
      });
    }
  }
}