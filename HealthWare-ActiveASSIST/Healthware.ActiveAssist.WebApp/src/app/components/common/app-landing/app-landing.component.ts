import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { DashboardService } from 'src/app/services/dashboard.service';
@Component({
  selector: 'app-app-landing',
  templateUrl: './app-landing.component.html',
  styleUrls: ['./app-landing.component.css']
})
export class AppLandingComponent implements OnInit, OnDestroy {
  showloginButton: boolean = true;
  virtualAssistPadding: string = "virtual-assist-padding";
  logoutClicked: boolean = false;
  currentTheme: any;
  messageInfo: string = StringConstants.landingPage.messageInfo;
  messageTitle: string = StringConstants.landingPage.messageTitle;
  buttonLabel: string = StringConstants.landingPage.buttonLabel;
  TodayCost = StringConstants.appLanding.TodayCost;
  showScreen: boolean = true;
  userId: any;
  canCreateAssessment: any;
  constructor(private toastService: ToastServiceService, private dashboardService: DashboardService, private dataSharingService: DataSharingService, private router: Router, private authService: AuthService) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.canCreate.subscribe(value => {
      this.showScreen = value;
    })
  }
  ngOnDestroy(): void {
    this.dataSharingService.showloginButton.next(false);
  }
  isLoggedIn(): boolean {
    if ((sessionStorage.getItem('isLoggedIn') || sessionStorage.getItem('isLoggedIn')) == 'true') {
      return true;
    } else {
      return false;
    }
  }
  ngOnInit(): void {
    this.userId = sessionStorage.getItem('userId');
    this.getDashboardDetails();
    this.dataSharingService.hideVaForProfile.next(false);
    sessionStorage.removeItem('QuestionAndAnswer');
    if (this.isLoggedIn())
      this.dataSharingService.showloginButton.next(false);
    else
      this.dataSharingService.showloginButton.next(true);
  }
  getDashboardDetails() {
    var userId: number = +(this.userId);
    var searchWord = "";
    this.dashboardService.getDashboardDetails(userId, searchWord).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        if (result.data?.dashboardDetailResponse?.length == 0 && result.data.partialAssessment == null) {
          this.dataSharingService.canCreate.next(true);
          this.canCreateAssessment = true;
        }
        else {
          this.canCreateAssessment = result.data.canCreateNewAssessment;
          this.dataSharingService.canCreate.next(this.canCreateAssessment);
          sessionStorage.setItem('resultID', result.data.partialAssessment?.partialAssessmentId!);
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  nextToPatient() {
    if (this.isLoggedIn()) {
      sessionStorage.removeItem('QuestionAndAnswer');
      sessionStorage.removeItem('QuickAssessmentSSN');
      sessionStorage.removeItem('checkboxQuestionAndAnswer');
      let hasAccessToCreateAssessment = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.createAssessmentByAdvocate);

      if (hasAccessToCreateAssessment)
        this.router.navigate(['create-assessment']);
      else {
        if (this.showScreen == false) {
          this.toastService.showWarning("Kindly complete the incomplete assessment.", "");
        }
        else
          this.router.navigate(['dynamic-questions']);
      }
    }
    else {
      this.router.navigate(['login']);
    }
  }
}