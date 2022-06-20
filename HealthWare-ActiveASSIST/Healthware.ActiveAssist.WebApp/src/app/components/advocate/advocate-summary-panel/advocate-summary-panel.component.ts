import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-advocate-summary-panel',
  templateUrl: './advocate-summary-panel.component.html',
  styleUrls: ['./advocate-summary-panel.component.css']
})
export class AdvocateSummaryPanelComponent implements OnInit {
  assessmentStatus: any;
  assessmentId: any;
  submittedOn: any;
  fullName: any;
  gender: any;
  age: any;
  zipcode: any;
  state: any;
  city: any;
  citizenship: any;
  insuranceStatus: any;
  totalHouseholdMembers: any;
  totalMinorHouseholdMembers: any;
  isEmployed: any;
  receivingAny: any;
  monthlyIncome: any;
  resourceIncome: any;
  serviceProgram: any;
  healthConditions: any;
  isInjured: any;
  updatedNumberOfMembers: any;
  updatedNumberOfMinors: any;
  updatedMonthlyIncome: any;
  updatedNumberOfResource: any;
  showUpdateMembers: boolean = false;
  showUpdateMinors: boolean = false;
  showUpdateIncome: boolean = false;
  showUpdateResource: boolean = false;
  currentTheme: any;
  guarantorCellNUmber: any;
  guarantorEmail: any;
  personalCellNumber: any;
  personalEmail: any;
  preferredCellNumber: any;
  preferredEmail: any;
  @Output() scroll: EventEmitter<any> = new EventEmitter();
  profileImageUrl: any;
  personalCountyCode: any;
  guarantorCountyCode: any;
  preferredCountyCode: any;
  showAdvocatePanel: boolean = false;
  AssessmentIncomplete=StringConstants.advocateSummaryPanel.AssessmentIncomplete;
  DocumentationIncomplete=StringConstants.advocateSummaryPanel.DocumentationIncomplete;
  years=StringConstants.advocateSummaryPanel.years;
  QuickAssessment=StringConstants.advocateSummaryPanel.QuickAssessment;
  panelInfo=StringConstants.advocateSummaryPanel.panelInfo;
  Demographics=StringConstants.advocateSummaryPanel.Demographics;
  ResidentialZipCode=StringConstants.advocateSummaryPanel.ResidentialZipCode;
  Insurance=StringConstants.advocateSummaryPanel.Insurance;
  InsuranceInfo=StringConstants.advocateSummaryPanel.InsuranceInfo;
  Household=StringConstants.advocateSummaryPanel.Household;
  NumberOfMembers=StringConstants.advocateSummaryPanel.NumberOfMembers;
  NumberOfMinors=StringConstants.advocateSummaryPanel.NumberOfMinors;
  AnyoneInHouseholdEmployed=StringConstants.advocateSummaryPanel.AnyoneInHouseholdEmployed;
  ReceivingAny=StringConstants.advocateSummaryPanel.ReceivingAny;
  MonthlyHouseholdIncomeMsg=StringConstants.advocateSummaryPanel.MonthlyHouseholdIncomeMsg;
  MonthlyResourcesMsg=StringConstants.advocateSummaryPanel.MonthlyResourcesMsg;
  GeneralQuestions=StringConstants.advocateSummaryPanel.GeneralQuestions;
  PersonalDetails=StringConstants.advocateSummaryPanel.PersonalDetails;
  PersonalEmail=StringConstants.advocateSummaryPanel.PersonalEmail;
  PersonalCellNumber=StringConstants.advocateSummaryPanel.PersonalCellNumber;
  GuarantorDetails=StringConstants.advocateSummaryPanel.GuarantorDetails;
  GuarantorEmail=StringConstants.advocateSummaryPanel.GuarantorEmail;
  GuarantorCellNumber=StringConstants.advocateSummaryPanel.GuarantorCellNumber;
  PreferredDetails=StringConstants.advocateSummaryPanel.PreferredDetails;
  PreferredEmail=StringConstants.advocateSummaryPanel.PreferredEmail;
  PreferredCellNumber=StringConstants.advocateSummaryPanel.PreferredCellNumber;
  constructor(private authService: AuthService, private dataSharingService: DataSharingService, private router: Router, private toastService: ToastServiceService,
    private quickAssessmentService: QuickAssessmentService, private dashboardService: DashboardService, private fileUpload: FileUpload) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.LoadProfileImage.subscribe(value => {
      this.profileImageUrl = value;
    });
    this.dataSharingService.Tab.subscribe(value => {
      var scrollDiv = document.getElementById('panelScroll');
      if (value == 4 || value == 5 || value == 6 || value == 7) {
        scrollDiv?.scrollTo(0, 300);
      }
      else {
        scrollDiv?.scrollTo(0, 0);
      }
    });
    this.dataSharingService.evaluateHousehold.subscribe(value => {
      if (value == true && this.showAdvocatePanel == true) {
        this.getAdvocateSummaryPanel();
        this.dataSharingService.evaluateHousehold.next(false);
      }
    });
    this.dataSharingService.updatepersonalAdvocateUpdateSummary.subscribe(value => {
      if (value == true && this.showAdvocatePanel == true) {
        this.getAdvocateSummaryPanel();
        this.dataSharingService.updatepersonalAdvocateUpdateSummary.next(false);
      }
    });
    this.dataSharingService.updateguarantorAdvocateUpdateSummary.subscribe(value => {
      if (value == true && this.showAdvocatePanel == true) {
        this.getAdvocateSummaryPanel();
        this.dataSharingService.updateguarantorAdvocateUpdateSummary.next(false);
      }
    });
    this.dataSharingService.updateContactPreferenceAdvocateUpdateSummary.subscribe(value => {
      if (value == true && this.showAdvocatePanel == true) {
        this.getAdvocateSummaryPanel();
        this.dataSharingService.updateContactPreferenceAdvocateUpdateSummary.next(false);
      }
    });
    this.dataSharingService.SavePersonal.subscribe(value => {
      if (value != "" && this.showAdvocatePanel == true)
        this.getAdvocateSummaryPanel();
    });
  }
  ngOnInit() {
    this.dataSharingService.hideVaForProfile.next(false);
    this.assessmentStatus = sessionStorage.getItem("assessmentStatus");
    this.getAdvocateSummaryPanel();
    this.viewProfileImage();
    this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
  }
  ngOnDestroy() {
    this.showAdvocatePanel = false;
  }
  viewProfileImage() {
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
  getAdvocateSummaryPanel() {
    let patientId = +(sessionStorage.getItem('patientId')!);
    let assessmentId = +(sessionStorage.getItem('assessmentId')!);
    const advocateRequest: any = {
      patientId: patientId,
      assessmentId: assessmentId
    }
    this.quickAssessmentService.getAdvocateSummaryPanel(advocateRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {       
        this.assessmentId = sessionStorage.getItem("assessmentId");
        let submitDate = sessionStorage.getItem("submittedOn");
        let date = new Date(submitDate + " UTC");
        this.submittedOn = date.toString();
        this.fullName = sessionStorage.getItem("assessmentPatientFullName");
        this.gender = sessionStorage.getItem("gender");
        this.age = sessionStorage.getItem("age");
        this.zipcode = result.data.zipCode;
        this.state = result.data.stateCode;
        this.city = result.data.city;
        this.citizenship = result.data.citizenshipStatus;
        if (result.data.insurance == "true") {
          this.insuranceStatus = "Yes";
        }
        else if (result.data.insurance == "false") {
          this.insuranceStatus = "No";
        }
        this.totalHouseholdMembers = result.data.numberOfMembers;
        this.totalMinorHouseholdMembers = result.data.numberOfMinors;
        if (result.data.isHouseHoldEmployed == true) {
          this.isEmployed = "Yes";
        }
        else if (result.data.isHouseHoldEmployed == false) {
          this.isEmployed = "No";
        }
        if (result.data.receivingAny == null || result.data.receivingAny == "") {
          this.receivingAny = "None";
        }
        else if (result.data.receivingAny != null) {
          this.receivingAny = result.data.receivingAny;
        }
        this.monthlyIncome = result.data.houseHoldIncomeMonthly;
        this.resourceIncome = result.data.houseHoldResources;
        if (result.data.generalQuestions == null || result.data.generalQuestions == "") {
          this.serviceProgram = "None";
        }
        else if (result.data.generalQuestions != null) {
          this.serviceProgram = result.data.generalQuestions;
        }
        if (result.data.healthConditions == null || result.data.healthConditions == "") {
          this.healthConditions = "None";
        }
        else if (result.data.healthConditions != null) {
          this.healthConditions = result.data.healthConditions;
        }
        if (result.data.beenInjured == null || result.data.beenInjured == "") {
          this.isInjured = "None";
        }
        else if (result.data.beenInjured != null) {
          this.isInjured = result.data.beenInjured;
        }
        if (result.data.updatedNumberOfMembers == null || result.data.updatedNumberOfMembers == "") {
          this.showUpdateMembers = false;
        }
        else if (result.data.numberOfMembers == result.data.updatedNumberOfMembers) {
          this.showUpdateMembers = false;
        }
        else if (result.data.numberOfMembers != result.data.updatedNumberOfMembers) {
          this.showUpdateMembers = true;
          this.updatedNumberOfMembers = result.data.updatedNumberOfMembers;
        }
        if (result.data.updatedNumberOfMinors == null || result.data.updatedNumberOfMinors == "") {
          this.showUpdateMinors = false;
        }
        else if (result.data.numberOfMinors == result.data.updatedNumberOfMinors) {
          this.showUpdateMinors = false;
        }
        else if ((result.data.numberOfMinors != result.data.updatedNumberOfMinors)) {
          this.showUpdateMinors = true;
          this.updatedNumberOfMinors = result.data.updatedNumberOfMinors;
        }
        if (result.data.updatedMonthlyIncome == null || result.data.updatedMonthlyIncome == "") {
          this.showUpdateIncome = false;
        }
        else if (result.data.houseHoldIncomeMonthly < result.data.updatedMonthlyIncome || (result.data.houseHoldIncomeMonthly > result.data.updatedMonthlyIncome)) {
          this.showUpdateIncome = true;
          this.updatedMonthlyIncome = result.data.updatedMonthlyIncome;
        }
        if (result.data.updatedNumberOfResource == null || result.data.updatedNumberOfResource == "") {
          this.showUpdateResource = false;
        }
        else if (result.data.houseHoldResources < result.data.updatedNumberOfResource || (result.data.houseHoldResources > result.data.updatedNumberOfResource)) {
          this.showUpdateResource = true;
          this.updatedNumberOfResource = result.data.updatedNumberOfResource;
        }
        this.personalCountyCode = "+" + result.data.contactSummary.personalCountyCode;
        let personalCell = result.data.contactSummary.personalCell.substring(0, 10);
        this.personalCellNumber = personalCell.replace(/^(\d{0,3})(\d{0,3})(\d{0,4})/, '($1) $2-$3');
        this.personalEmail = result.data.contactSummary.personalEmail;
        if (result.data.contactSummary.guarantorCell == null || result.data.contactSummary.guarantorCell == "") {
          this.guarantorCellNUmber = "None";
        }
        else if (result.data.contactSummary.guarantorCell != null) {
          let guarantorCell = result.data.contactSummary.guarantorCell.substring(0, 10);
          this.guarantorCellNUmber = guarantorCell.replace(/^(\d{0,3})(\d{0,3})(\d{0,4})/, '($1) $2-$3');
        }
        if (result.data.contactSummary.guarantorEmail == null || result.data.contactSummary.guarantorEmail == "") {
          this.guarantorEmail = "None";
        }
        else if (result.data.contactSummary.guarantorEmail != null) {
          this.guarantorEmail = result.data.contactSummary.guarantorEmail;
        }
        if (result.data.contactSummary.guarantorCountyCode == null || result.data.contactSummary.guarantorCountyCode == "") {
          this.guarantorCountyCode = "";
        }
        else if (result.data.contactSummary.guarantorCountyCode != null) {
          this.guarantorCountyCode = "+" + result.data.contactSummary.guarantorCountyCode;
        }
        if (result.data.contactSummary.preferredCell == null || result.data.contactSummary.preferredCell == "") {
          this.preferredCellNumber = "None";
        }
        else if (result.data.contactSummary.preferredCell != null) {
          let preferredCell = result.data.contactSummary.preferredCell.substring(0, 10);
          this.preferredCellNumber = preferredCell.replace(/^(\d{0,3})(\d{0,3})(\d{0,4})/, '($1) $2-$3');
        }
        if (result.data.contactSummary.preferredEmail == null || result.data.contactSummary.preferredEmail == "") {
          this.preferredEmail = "None";
        }
        else if (result.data.contactSummary.preferredEmail != null) {
          this.preferredEmail = result.data.contactSummary.preferredEmail;
        }
        if (result.data.contactSummary.preferredCountyCode == null || result.data.contactSummary.preferredCountyCode == "") {
          this.preferredCountyCode = "";
        }
        else if (result.data.contactSummary.preferredCountyCode != null) {
          this.preferredCountyCode = "+" + result.data.contactSummary.preferredCountyCode;
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
}