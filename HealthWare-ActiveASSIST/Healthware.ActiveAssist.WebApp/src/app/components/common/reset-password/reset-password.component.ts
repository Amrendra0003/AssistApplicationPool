import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { LoginService } from 'src/app/services/login.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { TenantService } from 'src/app/services/tenant.service'
@Component({
  selector: 'app-reset-password',
  templateUrl: './reset-password.component.html',
  styleUrls: ['./reset-password.component.css']
})
export class ResetPasswordComponent implements OnInit {
  resetForm: any;
  email: any;
  fieldType: string = StringConstants.var.typePassword;
  mustMatch!: boolean;
  virtualAssistPadding: string = "virtual-assist-padding";
  Pattern: any;
  MinLength: any;
  MaxLength: any;
  ResetYourPassword = StringConstants.ResetPassword.ResetYourPassword;
  NewPassReq = StringConstants.ChangePassword.NewPassReq;
  PassVal = StringConstants.ChangePassword.PassVal;
  PassMinLen = StringConstants.ChangePassword.PassMinLen;
  PassMaxLen = StringConstants.ChangePassword.PassMaxLen;
  PassStrInfo = StringConstants.ChangePassword.PassStrInfo;
  RetypeYourPassword = StringConstants.ResetPassword.RetypeYourPassword;
  PasswordMustMatch = StringConstants.ChangePassword.PasswordMustMatch;
  Reset = StringConstants.ResetPassword.Reset;
  constructor(private tenentService: TenantService, private dataSharingService: DataSharingService, private loginService: LoginService, private router: Router, private toastService: ToastServiceService, private formbuilder: FormBuilder,
    private activatedRoute: ActivatedRoute) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    //Logic to prevent direct url access only accessible via predefined url
    if (this.router && !this.router.navigated)
      this.router.navigate(['']);
  }
  ngOnInit() {
    this.dataSharingService.hideVaForProfile.next(false);
    this.passwordPolicy();
  }
  toggleField() {
    if (this.fieldType == StringConstants.var.typeText) this.fieldType = StringConstants.var.typePassword;
    else this.fieldType = StringConstants.var.typeText;
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
    this.resetForm = this.formbuilder.group({
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
  resetPassword(resetPassword: any) {
    if (!this.resetForm.valid) {
      this.toastService.showWarning(StringConstants.toast.enterPassword, StringConstants.toast.empty);
    }
    else {
      this.email = sessionStorage.getItem('resetEmail');
      const resetData: any = {
        emailAddress: this.email,
        Password: resetPassword.newPassword,
        confirmPassword: resetPassword.confirmnewPassword,
        fromProfileSettings: false
      };
      this.loginService.ResetPassword(resetData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.toastService.showSuccess(StringConstants.toast.passwordUpdated, StringConstants.toast.empty);
          this.router.navigate(['login']);
        }
      }, (error) => {
        if (error.status = '500') {
          this.toastService.showError(StringConstants.toast.samePassword, StringConstants.toast.tryAgain);
        }
        else {
          console.log(error);
        }
      });
    }
  }
}