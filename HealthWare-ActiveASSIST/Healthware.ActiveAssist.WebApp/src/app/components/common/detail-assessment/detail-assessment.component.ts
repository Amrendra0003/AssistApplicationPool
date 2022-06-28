import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-detail-assessment',
  templateUrl: './detail-assessment.component.html',
  styleUrls: ['./detail-assessment.component.css', './detail-assessment.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class DetailAssessmentComponent implements OnInit {
  activeTab: number = 0;
  fullName: any;
  assessmentId: any;
  gender: any;
  age: any;
  submittedOn: any;
  assessmentStatus: any = "";
  statusDisplay: any = "";
  selectedIndex: number = 0;
  appdashboardquickassessment: any;
  appdashboardhousehold: any;
  appdashboardguarantor: any;
  appdashboardpersonal: any;
  appdashboaredContactpreference: any;
  appdashboardVerification: any;
  appdashboardApplicationForms: any;
  appdashboardForms: any;
  appdashboardPrograms: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  patientId: any;
  data: any;
  QuickSaved: any;
  PersonalSaved: any;
  GuarantorSaved: any;
  ContactPreferenceSaved: any;
  HouseHoldSaved: any;
  ApplicationFormsSaved: any;
  VerificationSaved: any;
  ProgramSaved: any;
  QuickComplete: any = null;
  PersonalComplete: any = null;
  GuarantorComplete: any = null;
  ContactComplete: any = null;
  HouseholdComplete: any = null;
  ApplicationComplete: any = null;
  VerificationComplete: any = null;
  ProgramComplete: any = null;
  submitDone: string = "false";
  submitDetails: any;
  navigateTab: string = "";
  showLoader: boolean = false;
  profileImageUrl: any;
  showAdvocatePanel: any;
  showApplicationFormsTab: boolean = false;
  showFormsTab: boolean = false;
  showProgramsTab: boolean = false;
  currentTheme: any;
  isEditAllowed: any;
  isQuickAssessmentResults: any;
  isPersonal: any;
  isGuarantor: any;
  isHousehold: any;
  isContactPreference: any;
  isApplicationForms: any;
  isForms: any;
  isPrograms: any;
  isVerification: any;
  isSubmit: any;
  AppFormActive: any;
  AssessmentID = StringConstants.DashboardInfo.AssessmentID;
  QuickAssessmentResults = StringConstants.DashboardInfo.QuickAssessmentResults;
  Personal = StringConstants.DashboardInfo.Personal;
  Guarantor = StringConstants.DashboardInfo.Guarantor;
  title = StringConstants.contactPreference.title;
  Household = StringConstants.quickAssessment1.Household;
  ApplicationForms = StringConstants.DashboardInfo.ApplicationForms;
  Programs = StringConstants.dashboardAdvocate.Programs;
  Forms = StringConstants.Common.Forms;
  verification = StringConstants.dashboardHouseholdMember.verification;
  Submit = StringConstants.Common.Submit;
  YourApplicationComplete = StringConstants.DashboardInfo.YourApplicationComplete;
  SubmittingVerificationInformation = StringConstants.DashboardInfo.SubmittingVerificationInformation;
  SubmittingVerificationInformationMsg = StringConstants.DashboardInfo.SubmittingVerificationInformationMsg;
  GoDashboard = StringConstants.DashboardInfo.GoDashboard;
  constructor(private route: ActivatedRoute, private dashboardService: DashboardService, private dataSharingService: DataSharingService,
    private router: Router, private fileUpload: FileUpload, private formbuilder: FormBuilder, private location: Location,
    private dataSharing: DataSharingService, private authService: AuthService) {
      
    this.dataSharingService.changeTheme.subscribe(value => { // Theme setting
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    })
    this.dataSharing.showApplicationFormNext.subscribe(value => { // Show application forms
      this.selectedIndex = Number(value);
    });
    this.dataSharing.showPersonalTab.subscribe(value => { // Show prsonal tab
      this.selectedIndex = Number(value);
    });
    this.dataSharing.showGuarantorTab.subscribe(value => { //Show guarantor tab
      this.selectedIndex = Number(value);
    });
    this.dataSharing.showHouseholdTab.subscribe(value => { //Show household tab
      this.selectedIndex = Number(value);
    });
    this.dataSharing.showContactPreferenceTab.subscribe(value => {//Show contact preference
      this.selectedIndex = Number(value);
    });
    this.dataSharing.showQuickAssessmentResultsTab.subscribe(value => { //Show quick assessment
      this.selectedIndex = Number(value);
    });
    this.dataSharing.ShowVerificationTab.subscribe(value => { // Show verification tab
      this.selectedIndex = Number(value);
    });
    this.dataSharing.ShowFormsTab.subscribe(value => { //Show forms tab
      this.selectedIndex = Number(value);
    });
    this.dataSharing.ShowProgramsTab.subscribe(value => { //show programs tab
      this.selectedIndex = Number(value);
    });
    this.dataSharingService.LoadProfileImage.subscribe(value => { // load profile image
      this.profileImageUrl = value;
    });
    this.dataSharingService.alterPaddingForVA.subscribe(value => { //Virtual assistance
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.changeFullName.subscribe(value => { // Change name
      this.fullName = value;
    });
    this.dataSharingService.changeAssessmentStatus.subscribe(value => {/*Change Assessment Status*/
      this.assessmentStatus = value;
      this.getAssessmentStatus();
    });
    this.dataSharingService.SaveQuickAssessment.subscribe(value => {  /* ValidationSummary*/
      switch (value) {
        case 'true': this.QuickSaved = true; break;
        case 'false': this.QuickSaved = false; break;
        default: this.QuickSaved = null;
      }
      this.QuickComplete = this.QuickSaved;
    });
    this.dataSharingService.SavePersonal.subscribe(value => {
      switch (value) {
        case 'true': this.PersonalSaved = true; break;
        case 'false': this.PersonalSaved = false; break;
        default: this.PersonalSaved = null;
      }
      this.PersonalComplete = this.PersonalSaved;
    });
    this.dataSharingService.SaveGuarantor.subscribe(value => {
      switch (value) {
        case 'true': this.GuarantorSaved = true; break;
        case 'false': this.GuarantorSaved = false; break;
        default: this.GuarantorSaved = null;
      }
      this.GuarantorComplete = this.GuarantorSaved;
    });
    this.dataSharingService.SaveContactPreference.subscribe(value => {
      switch (value) {
        case 'true': this.ContactPreferenceSaved = true; break;
        case 'false': this.ContactPreferenceSaved = false; break;
        default: this.ContactPreferenceSaved = null;
      }
      this.ContactComplete = this.ContactPreferenceSaved;
    });
    this.dataSharingService.SaveHousehold.subscribe(value => {
      switch (value) {
        case 'true': this.HouseHoldSaved = true; break;
        case 'false': this.HouseHoldSaved = false; break;
        default: this.HouseHoldSaved = null;
      }
      this.HouseholdComplete = this.HouseHoldSaved;
    });
    this.dataSharingService.SaveApplicationForms.subscribe(value => {
      switch (value) {
        case 'true': this.ApplicationFormsSaved = true; break;
        case 'false': this.ApplicationFormsSaved = false; break;
        default: this.ApplicationFormsSaved = null;
      }
      this.ApplicationComplete = this.ApplicationFormsSaved;
    });
    this.dataSharingService.SavePrograms.subscribe(value => {
      switch (value) {
        case 'true': this.ProgramSaved = true; break;
        case 'false': this.ProgramSaved = false; break;
        default: this.ProgramSaved = null;
      }
      this.ProgramComplete = this.ProgramSaved;
    });
    this.dataSharingService.SaveVerification.subscribe(value => {
      switch (value) {
        case 'true': this.VerificationSaved = true; break;
        case 'false': this.VerificationSaved = false; break;
        default: this.VerificationSaved = null;
      }
      this.VerificationComplete = this.VerificationSaved;
    });
    this.dataSharingService.EnableSubmit.subscribe(value => {
      this.submitDone = value;
    });
    this.dataSharingService.EnableDocumentation.subscribe(value => {
      switch (value) {
        case 'true': this.AppFormActive = true; break;
        case 'false': this.AppFormActive = false; break;
      }
    })
    if (this.router && !this.router.navigated)
      this.router.navigate(['']);
  }
  ngOnInit() {
    
    this.dataSharingService.hideVaForProfile.next(false);
    this.dataNull();
    window.scroll(0, 0);
    if(sessionStorage.getItem("tokenForEmail") != null){
      this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
      if(this.showAdvocatePanel == true)
        this.navigateTab = "7";
      else
        this.navigateTab = "6";
      sessionStorage.removeItem('tokenForEmail');
    }
    else{
      this.navigateTab = this.route.snapshot.queryParams.tab;
    }
    this.initForm();
    this.viewProfileImage();
    this.getTabStatus();
    this.getAssessmentStatus();
    this.statusDisplay = sessionStorage.getItem("statusDisplay");
    this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
    this.PermissionUpdate();
  }
  async dataNull() {
    this.QuickComplete = null;
    this.PersonalComplete = null;
    this.GuarantorComplete = null;
    this.ContactComplete = null;
    this.HouseholdComplete = null;
    this.ApplicationComplete = null;
    this.VerificationComplete = null;
    this.ProgramComplete = null;
    this.QuickSaved = null;
    this.PersonalSaved = null;
    this.GuarantorSaved = null;
    this.ContactPreferenceSaved = null;
    this.HouseHoldSaved = null;
    this.ApplicationFormsSaved = null;
    this.VerificationSaved = null;
    this.ProgramSaved = null;
  }
  getAssessmentStatus() { //Get assessment status
    this.isEditAllowed = (sessionStorage.getItem("isEditable") == "true") ? true : false;
    if (this.isEditAllowed) {
      sessionStorage.setItem('statusDisplay', StringConstants.var.yetToSubmit);
      this.statusDisplay = StringConstants.var.yetToSubmit;
    }
    else {
      sessionStorage.setItem('statusDisplay', StringConstants.var.underReview);
      this.statusDisplay = StringConstants.var.underReview;
    }
    this.dataSharing.editable.next(this.isEditAllowed);
  }
  getsessionvalue(control: string): string { //get session value
    return sessionStorage.getItem(control)!;
  }
  ngAfterViewInit() {
    
    if (this.showAdvocatePanel == true) {
      switch (this.navigateTab) {
        case "0": {
          this.dataSharingService.showQuickAssessmentResultsTab.next(this.navigateTab);
          break;
        }
        case "1": {
          this.dataSharingService.showPersonalTab.next(this.navigateTab);
          break;
        }
        case "2": {
          this.dataSharingService.showGuarantorTab.next(this.navigateTab);
          break;
        }
        case "3": {
          this.dataSharingService.showContactPreferenceTab.next(this.navigateTab);
          break;
        }
        case "4": {
          this.dataSharingService.showHouseholdTab.next(this.navigateTab);
          break;
        }
        case "5": {
          this.dataSharingService.ShowProgramsTab.next(this.navigateTab);
          break;
        }
        case "6": {
          this.dataSharingService.ShowFormsTab.next(this.navigateTab);
          break;
        }
        case "7": {
          this.dataSharingService.ShowVerificationTab.next(this.navigateTab);
          break;
        }
        default: {
          break;
        }
      }
    }
    else if (this.showAdvocatePanel == false) {
      switch (this.navigateTab) {
        case "0": {
          this.dataSharingService.showQuickAssessmentResultsTab.next(this.navigateTab);
          break;
        }
        case "1": {
          this.dataSharingService.showPersonalTab.next(this.navigateTab);
          break;
        }
        case "2": {
          this.dataSharingService.showGuarantorTab.next(this.navigateTab);
          break;
        }
        case "3": {
          this.dataSharingService.showContactPreferenceTab.next(this.navigateTab);
          break;
        }
        case "4": {
          this.dataSharingService.showHouseholdTab.next(this.navigateTab);
          break;
        }
        case "5": {
          this.dataSharingService.showApplicationFormNext.next(this.navigateTab);
          break;
        }
        case "6": {
          this.dataSharingService.ShowVerificationTab.next(this.navigateTab);
          break;
        }
        default: {
          break;
        }
      }
    }
  }
  viewProfileImage() { // View profiel image
    this.fileUpload.GetAssessmentProfileImage(sessionStorage.getItem('assessmentId')!)
      .subscribe(async (result: any) => {
        this.profileImageUrl = result;
      },
        (err) => {
          console.log(StringConstants.toast.fetchError, err);
        }, () => {
        }
      )
  }
  currentTabUpdateFn($event: any) { //Get current tab status
    var currentTab = Number([$event.index]);
    if (this.showAdvocatePanel == true) {
      try {
        this.dataSharingService.Tab.next(currentTab);
        switch (currentTab) {
          case 0: { this.appdashboardquickassessment = !this.appdashboardquickassessment; break; }
          case 1: { this.appdashboardpersonal = !this.appdashboardpersonal; break; }
          case 2: { this.appdashboardguarantor = !this.appdashboardguarantor; break; }
          case 3: { this.appdashboaredContactpreference = !this.appdashboaredContactpreference; break; }
          case 4: { this.appdashboardhousehold = !this.appdashboardhousehold; break; }
          case 5: { this.appdashboardPrograms = !this.appdashboardPrograms; break; }
          case 6: { this.appdashboardForms = !this.appdashboardForms; break; }
          case 7: { this.appdashboardVerification = !this.appdashboardVerification; break; }
          default: break;
        }
      }
      catch { }
    }
    else if (this.showAdvocatePanel == false) {
      try {
        this.dataSharingService.Tab.next(currentTab);
        switch (currentTab) {
          case 0: { this.appdashboardquickassessment = !this.appdashboardquickassessment; break; }
          case 1: { this.appdashboardpersonal = !this.appdashboardpersonal; break; }
          case 2: { this.appdashboardguarantor = !this.appdashboardguarantor; break; }
          case 3: { this.appdashboaredContactpreference = !this.appdashboaredContactpreference; break; }
          case 4: { this.appdashboardhousehold = !this.appdashboardhousehold; break; }
          case 5: { this.appdashboardApplicationForms = !this.appdashboardApplicationForms; break; }
          case 6: { this.appdashboardVerification = !this.appdashboardVerification; break; }
          default: break;
        }
      }
      catch { }
    }
  }
  private initForm() {
    const patientAssessment = JSON.stringify(this.location.getState());
    const patientAssessmentDetails = JSON.parse(patientAssessment);
    this.fullName = sessionStorage.getItem("assessmentPatientFullName");
    this.assessmentId = +(sessionStorage.getItem("assessmentId")!);
    this.gender = sessionStorage.getItem("gender");
    this.age = sessionStorage.getItem("age");
    this.submittedOn = sessionStorage.getItem("submittedOn");
    let date = new Date(this.submittedOn + " UTC");
    
    this.submittedOn = date.toString();
    this.assessmentStatus = sessionStorage.getItem("assessmentStatus");
    this.patientId = sessionStorage.getItem('patientId');
  }
  goToDashboard() { // Go to dashboard
    this.router.navigate(['dashboard']);
  }
  Scroll(event: any) {
    window.scroll(0, 0);
  }
  getTabStatus() { //Get current tab status
    this.showLoader = true;
    var assessmentId: number = +(this.assessmentId);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        this.QuickSaved = result.data.isQuickAssessmentComplete;
        this.PersonalSaved = result.data.isPersonalInfoComplete;
        this.GuarantorSaved = result.data.isGuarantorInfoComplete;
        this.ContactPreferenceSaved = result.data.isContactPreferenceComplete;
        this.HouseHoldSaved = result.data.isHouseholdComplete;
        this.submitDetails = result.data.canEvaluate;
        this.AppFormActive = result.data.isApplicationFormEnabled;
        this.ApplicationFormsSaved = result.data.isApplicationFormsComplete;
        this.VerificationSaved = result.data.isVerificationComplete;
        this.ProgramSaved = result.data.isProgramsComplete;
        this.showLoader = false;
        if (this.ApplicationFormsSaved == true && this.VerificationSaved == true)
          this.submitDone = 'true';
        else
          this.submitDone = 'false';
      }
    }, (error) => {
      console.log(error)
    });
  }
  PermissionUpdate() { /*Permissions*/
    this.isQuickAssessmentResults = this.authService.checkIfUserHasPermission('ViewComponentQuickAssessment');
    this.isPersonal = this.authService.checkIfUserHasPermission('ViewComponentPersonal');
    this.isGuarantor = this.authService.checkIfUserHasPermission('ViewComponentGuarantor');
    this.isContactPreference = this.authService.checkIfUserHasPermission('ViewComponentContactPreference');
    this.isHousehold = this.authService.checkIfUserHasPermission('ViewComponentHouseHold');
    this.isApplicationForms = this.authService.checkIfUserHasPermission('ViewComponentApplicationForms');
    this.isForms = this.authService.checkIfUserHasPermission('ViewComponentForms');
    this.isPrograms = this.authService.checkIfUserHasPermission('ViewComponentPrograms');
    this.isVerification = this.authService.checkIfUserHasPermission('ViewComponentVerification');
    this.isSubmit = this.authService.checkIfUserHasPermission('ViewComponentApplicationCompleted');
  }
}
