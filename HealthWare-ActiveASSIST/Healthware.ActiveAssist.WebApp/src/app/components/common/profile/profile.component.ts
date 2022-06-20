import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { LoginService } from 'src/app/services/login.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { CommonService } from 'src/app/services/common.service';
@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {
  today = new Date();
  logoutFlag: boolean = false;
  changePasswordFlag: boolean = false;
  profileSettingsFlag: boolean = false;
  changePasswordForm: any;
  profileSettingsForm: any;
  email: any;
  fieldType: string = StringConstants.var.typePassword;
  mustMatch!: boolean;
  firstName: any;
  middleName: any;
  lastName: any;
  gender: any;
  dob: any;
  cellNumber: any;
  changeEmail: any;
  countyCode: any;
  homeSuite: any;
  homeCounty: any;
  homeCity: any;
  homeState: any;
  homePincode: any;
  homeCellNumber: any;
  homeStreetName: any;
  homeCountyCode: any;
  genderval: any;
  supportedImageType: any = ['image/png', 'image/jpeg'];
  assessmentId: any;
  userImageUrl: any;
  userName: any;
  currentTheme: any;
  Dashboard = StringConstants.profile.Dashboard;
  PSet = StringConstants.header.PSet;
  ChangePassword = StringConstants.ChangePassword.ChangePassword;
  LogOut = StringConstants.header.LogOut;
  LogQues = StringConstants.header.LogQues;
  Yes = StringConstants.Common.Yes;
  No = StringConstants.Common.No;
  constructor(private common:CommonService,private dataSharingService: DataSharingService, private loginService: LoginService, private router: Router, private toastService: ToastServiceService, private formbuilder: FormBuilder,
    private activatedRoute: ActivatedRoute, private dropdownService: DropdownService, private fileUpload: FileUpload, private authService: AuthService) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.changeFirstName.subscribe(value => {
      this.userName = value;
    });
    this.dataSharingService.navigateToChangePassword.subscribe(value => {
      if (value == "true") {
        this.clickChangePassword()
      }
    });
  }
  ngOnInit() {
    this.dataSharingService.hideVaForProfile.next(true);
    this.initForm();
    this.userName = sessionStorage.getItem('userFirstName');
    this.clickProfileSettingsFlag();
  }
  private initForm() {
    this.viewUserImage();
  }
  async getGenderValues() { //To get gender values
    this.genderval = await this.common.getGenderValues();
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
  clickProfileSettingsFlag() {
    window.scroll(0, 0);
    this.logoutFlag = false;
    this.changePasswordFlag = false;
    this.profileSettingsFlag = true;
  }
  clickChangePassword() {
    window.scroll(0, 0);
    this.logoutFlag = false;
    this.changePasswordFlag = true;
    this.profileSettingsFlag = false;
  }
  nextChangeButtonClicked(message: any): void {
    this.logoutFlag = false;
    this.changePasswordFlag = true;
    this.profileSettingsFlag = false;
  }
  clearsessionStorageAndNavigateLoginPage() {
    this.logoutFlag = true;
    this.changePasswordFlag = false;
    this.profileSettingsFlag = false;
    var userId = (sessionStorage.getItem('userId')!);
    this.loginService.Logout(userId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        sessionStorage.clear();
        this.dataSharingService.showUserNameInHeader.next(false);
        this.dataSharingService.beginFlag.next(false);
        this.dataSharingService.logoutTriggered.next(true);
        this.dataSharingService.showloginButton.next(true);
        this.router.navigate([''])
      }
    }, (error) => {
      console.log(error);
      if (error.error.errors[0] == StringConstants.toast.activeUser) {
        sessionStorage.clear();
        this.dataSharingService.showUserNameInHeader.next(false);
        this.dataSharingService.beginFlag.next(false);
        this.dataSharingService.logoutTriggered.next(true);
        this.router.navigate(['']);
      }
    });

  }
  toggleField() {
    this.fieldType = StringConstants.var.typeText;
    if (this.fieldType == StringConstants.var.typeText) {
      setTimeout(() => {
        this.fieldType = StringConstants.var.typePassword
      }, 15000)
    }
  }
  handleFileInput(event: any) {
    if (event.target.files.length > 0) {
      var filetype: string = event.target.files[0].type;
      var userId = (sessionStorage.getItem('userId')!);
      if (this.supportedImageType.includes(filetype)) {
        this.uploadUserProfileImage(userId, event.target.files[0]);
      }
      else {
        this.toastService.showWarning(StringConstants.toast.fileFormat, StringConstants.toast.empty);
      }
      event.target.value = '';
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
  uploadUserProfileImage(userId: string, file: File) {
    this.fileUpload.uploadUserProfileImage(userId, file)
      .subscribe(async event => {
        if (event.type == HttpEventType.UploadProgress) {
        } else if (event instanceof HttpResponse) {
          this.viewUserImage();
        }
      },
        (err) => {
          console.log(StringConstants.toast.uploadError, err);
        }, () => {
          console.log(StringConstants.toast.uploadDone);
          this.viewUserImage();
        }
      )
    this.toastService.showSuccess(StringConstants.toast.profileUpload, StringConstants.toast.empty);
  }
  goToDashboard() {
    let hasAccessToAdvocteDashboard = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewAdvocateDashboard);
    if (hasAccessToAdvocteDashboard)
      this.router.navigate(['dashboard-advocate']);
    else
      this.router.navigate(['dashboard']);
  }
}