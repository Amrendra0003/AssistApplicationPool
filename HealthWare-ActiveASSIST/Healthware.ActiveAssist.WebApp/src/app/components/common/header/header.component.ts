import { Component, HostListener, Inject, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { AuthService } from 'src/app/services/auth.service';
import { Overlay } from '@angular/cdk/overlay';
import { ViewContainerRef, ViewEncapsulation } from '@angular/core';
import { DOCUMENT } from '@angular/common';
import { FileUpload } from 'src/app/services/fileupload.service';
import { LoginService } from 'src/app/services/login.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { UserIdleService } from 'angular-user-idle';
declare var $: any;
@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
  encapsulation: ViewEncapsulation.None,
  preserveWhitespaces: false,
})
export class HeaderComponent implements OnInit {
  fullName: any;
  userName: any;
  unionIconPaddingLeft: any;
  unionIconMarginLeft: any;
  basiceModal: any;
  nextPosition: number = 0;
  isMenuOpen: boolean = false;
  isOpen = false;
  isMenuOn = false;
  private _loginBtnFlag: boolean = true;
  fullScreenToggleIcon: string = "assets/images/icons/union-icon.svg";
  panelState: any;
  isSettings = false;
  currentTheme: any;
  userImageUrl: any;
  profileVirtualAssist: boolean = false;
  InstruMessage = StringConstants.header.InstruMessage;
  InstruMessageBody1 = StringConstants.header.InstruMessageBody1;
  InstruMessageBody2 = StringConstants.header.InstruMessageBody2;
  InstruMessageBody3 = StringConstants.header.InstruMessageBody3;
  BtoDash = StringConstants.header.BtoDash;
  Hello = StringConstants.header.Hello;
  PSet = StringConstants.header.PSet;
  LogOut = StringConstants.header.LogOut;
  LogQues = StringConstants.header.LogQues;
  No = StringConstants.header.No;
  Yes = StringConstants.header.Yes;
  Appointment = StringConstants.header.Appointment;
  VirtualAssist = StringConstants.header.VirtualAssist;
  Login = StringConstants.header.Login;
  clickLanding: boolean = true;
  constructor(@Inject(DOCUMENT) private document: Document, private loginService: LoginService, public overlay: Overlay, public viewContainerRef: ViewContainerRef, private router: Router, private formbuilder: FormBuilder,
    private dataSharingService: DataSharingService, private authService: AuthService, private fileUpload: FileUpload,
    private userIdle: UserIdleService,) {
    this.dataSharingService.showloginButton.subscribe(value => {
      this.loginBtnFlag = value;
    });
    this.dataSharingService.showUserNameInHeader.subscribe(value => {
      this.userNameSpanFlag = value;
    });
    this.dataSharingService.changeFirstName.subscribe(value => {
      this.fullName = value;
    });
    this.dataSharingService.askAssistanceHelp.subscribe(value => {
      this.panelState = value;
      this.handleVirtualAssistPanelSpan(this.panelState);
    });
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.LoadUserImage.subscribe(value => {
      this.userImageUrl = value;
    });
    this.dataSharingService.hideVaForProfile.subscribe(value => {
      this.profileVirtualAssist = value;
    });
    this.dataSharingService.allowLanding.subscribe(value => {
      this.clickLanding = value;
    });
    this.dataSharingService.isLoggedIn.subscribe(value => {
      if (value == true) {
        //Start watching for user inactivity.
        this.userIdle.startWatching();
        // Start watching when user idle is starting.
        this.userIdle.onTimerStart().subscribe(count => console.log(count));
        // Start watch when time is up.
        this.userIdle.onTimeout().subscribe(() => {
          this.userIdle.stopTimer();
          this.userIdle.stopWatching();
          this.userIdle.resetTimer();
          this.clearsessionStorageAndNavigateLoginPage();
          console.log('Time is up!');
        });
      }
    });
    if((sessionStorage.getItem('isLoggedIn')!) == 'true'){
      this.dataSharingService.isLoggedIn.next(true);
    }
  }
  elem: any;
  @HostListener('document:fullscreenchange', ['$event'])
  @HostListener('document:webkitfullscreenchange', ['$event'])
  @HostListener('document:mozfullscreenchange', ['$event'])
  @HostListener('document:MSFullscreenChange', ['$event'])
  ngOnInit(): void {
    this.viewUserImage();
    this.elem = document.documentElement;
    if (this.authService.isLoggedIn)
      this.userNameSpanFlag = true;
    else
      this.userNameSpanFlag = false;
  }
  get loginBtnFlag(): boolean {
    return this._loginBtnFlag;
  }
  set loginBtnFlag(value: boolean) {
    this._loginBtnFlag = value;
  }
  FullScreenToggle() {
    if (document.fullscreenElement) {
      this.fullScreenToggleIcon = "assets/images/icons/union-icon.svg";
      if (this.document.exitFullscreen) {
        this.document.exitFullscreen();
      }
    } else {
      this.fullScreenToggleIcon = "assets/images/icons/exit-full-screen.svg";
      if (this.elem.requestFullscreen) {
        this.elem.requestFullscreen();
      } else if (this.elem.mozRequestFullScreen) {
        this.elem.mozRequestFullScreen();
      } else if (this.elem.webkitRequestFullscreen) {
        this.elem.webkitRequestFullscreen();
      } else if (this.elem.msRequestFullscreen) {
        this.elem.msRequestFullscreen();
      }
    }
  }
  private _userNameSpanFlag: boolean = true;
  get userNameSpanFlag(): boolean {
    return this._userNameSpanFlag;
  }
  set userNameSpanFlag(value: boolean) {
    this._userNameSpanFlag = value;
    if (value) {
      this.fullName = sessionStorage.getItem('userFirstName');
    }
    else {
    }
  }
  loginPage() {
    this.router.navigate(['login'])
    this.dataSharingService.showUserNameInHeader.next(false);
  }
  clearsessionStorageAndNavigateLoginPage() {
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
  navigateToprofileSettings() {
    this.router.navigate(['profile']);
  }
  navigateToDashboard() {
    let hasAccessToAdvocateDashboard = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewAdvocateDashboard);

    if (hasAccessToAdvocateDashboard)
      this.router.navigate(['dashboard-advocate']);
    else
      this.router.navigate(['dashboard']);
  }
  navigateToLandingPage() {
    this.router.navigate(['']);
  }
  toggle() {
    if (this.isOpen == false) {
      this.isOpen = true;
      this.handleVirtualAssistPanelSpan(true);
    }
    else if (this.isOpen == true) {
      this.isOpen = false;
      this.handleVirtualAssistPanelSpan(false);
    }
  }
  viewUserImage() {
    var userId = (sessionStorage.getItem('userId')!);
    if (!userId)
      return;
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
  handleVirtualAssistPanelSpan(panel: any) {
    if (this.profileVirtualAssist == true) {
      this.isOpen = false;
      this.dataSharingService.alterPaddingForVA.next("virtual-assist-padding");
      let virtualAssist = document.getElementById('virtual-assist');
    }
    else if (this.profileVirtualAssist == false) {
      let userHasAdvocatePermission = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
      if (userHasAdvocatePermission) {
        if (panel == false) {
          this.isOpen = false;
          this.dataSharingService.alterPaddingForVA.next("virtual-assist-padding");
        }
        else if (panel == true) {
          this.isOpen = true;
          this.dataSharingService.alterPaddingForVA.next("advocate-virtual-assist-padding-right");
        }
      }
      else {
        if (panel == false) {
          this.isOpen = false;
          this.dataSharingService.alterPaddingForVA.next("virtual-assist-padding");
        }
        else if (panel == true) {
          this.isOpen = true;
          this.dataSharingService.alterPaddingForVA.next("virtual-assist-padding-right");
        }
      }
    }
  }
}
