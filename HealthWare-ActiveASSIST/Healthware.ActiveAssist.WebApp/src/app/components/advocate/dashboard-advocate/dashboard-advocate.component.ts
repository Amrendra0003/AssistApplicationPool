import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AdvocateDashboardService } from 'src/app/services/advocate-dashboard.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { DatePipe } from '@angular/common'
import { StringConstants } from 'src/assets/constants/string.constants';
declare var $: any;
@Component({
  selector: 'app-dashboard-advocate',
  templateUrl: './dashboard-advocate.component.html',
  styleUrls: ['./dashboard-advocate.component.css']
})
export class DashboardAdvocateComponent implements OnInit {
  dashboard: any;
  dashboardAdvocateForm: any
  token: any;
  result: any;
  assessmentSubmitStatus: any;
  assessmentVerificationStatus: any;
  patientId: any;
  moreOptionsImg: boolean = false;
  virtualAssistPadding: string = "virtual-assist-padding";
  filterLabel: string = "Last 7 Days";
  orderByLabel: string = "Newest First";
  filter: any = "Last 7 Days";
  orderBy: any = "Newest First";
  showLoader: boolean = false;
  assessmentMoreOptions: any = {};
  isMenuOn = false;
  showEmptyMessageForAdvocate: boolean = false;
  showEmptyMessageForOthers: boolean = false;
  search: any;
  deleteAssessmentId: any;
  currentTheme: any;
  resultForAdvocate:any;
  resultForOthers:any;
  searchText: any = "";
  unamePattern = "^[a-z0-9_-]{8,15}$";
  PriorSubmissions = StringConstants.dashboardAdvocate.PriorSubmissions;
  OtherAssessment = StringConstants.dashboardAdvocate.OtherAssessment;
  AdvocateAssessment = StringConstants.dashboardAdvocate.AdvocateAssessment;
  SelectDate = StringConstants.dashboardAdvocate.SelectDate;
  Last7Days = StringConstants.dashboardAdvocate.Last7Days;
  Today = StringConstants.dashboardAdvocate.Today;
  Yesterday = StringConstants.dashboardAdvocate.Yesterday;
  ThisMonth = StringConstants.dashboardAdvocate.ThisMonth;
  Last3Days = StringConstants.dashboardAdvocate.Last3Days;
  SelectFilter = StringConstants.dashboardAdvocate.SelectFilter;
  NewestFirst = StringConstants.dashboardAdvocate.NewestFirst;
  OldestFirst = StringConstants.dashboardAdvocate.OldestFirst;
  StartNewAssessment = StringConstants.dashboardAdvocate.StartNewAssessment;
  NoRecordsFound = StringConstants.dashboardAdvocate.NoRecordsFound;
  AssessmentID = StringConstants.dashboardAdvocate.AssessmentID;
  Status = StringConstants.dashboardAdvocate.Status;
  Patient = StringConstants.dashboardAdvocate.Patient;
  Gender = StringConstants.dashboardAdvocate.Gender;
  From = StringConstants.dashboardAdvocate.From;
  Programs = StringConstants.dashboardAdvocate.Programs;
  logoutMsg = StringConstants.dashboardAdvocate.logoutMsg;
  No = StringConstants.dashboardAdvocate.No;
  Yes = StringConstants.dashboardAdvocate.Yes;
  count = false;
  advocateResult: any;
  constructor(private httpClient: HttpClient, private dataSharingService: DataSharingService,
    private toastService: ToastServiceService, private advocateDashboardService: AdvocateDashboardService,
    private dashboardService: DashboardService, private router: Router, private formbuilder: FormBuilder,
    private datePipe: DatePipe) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit(): void {
    window.scroll(0, 0);
    this.dataSharingService.hideVaForProfile.next(false);
    this.dataSharingService.showUserNameInHeader.next(true);
    this.token = sessionStorage.getItem("token");
    this.patientId = sessionStorage.getItem('userId');
    let searchWord = "";
    this.getAdvocateDashboardDetails(searchWord);
    this.initForm();
  }
  createAssessment() {
    this.router.navigate(['create-assessment']);
  }
  private initForm() {
    this.dashboardAdvocateForm = new FormGroup({
      'filter': new FormControl('Last 7 Days'),
      'orderBy': new FormControl('Newest First'),
      'searchText': new FormControl('')
    });
  }
  onChangeDays(event: any) {
    this.filterLabel = event.target.value;
    this.getAdvocateDashboardDetails(this.searchText);
  }
  onChangeOrders(event: any) {
    this.orderByLabel = event.target.value;
    this.getAdvocateDashboardDetails(this.searchText);
  }
  getAdvocateDashboardDetails(searchWord: any) {
    if (typeof searchWord == "undefined")
      searchWord = "";
    if (searchWord.target)
      var searchWord = searchWord.target.value;
    else
      var searchWord = searchWord;
    this.showLoader = true;
    this.filterLabel = this.filterLabel;
    this.orderByLabel = this.orderByLabel;
    var patientID: number = +(this.patientId);
    var browserDate = this.dateTranformation();
    this.advocateDashboardService.getAdvocateDashboardDetails(patientID, this.filterLabel, this.orderByLabel, searchWord, browserDate).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        if (result.data[0] == null || result.data[0].length == 0) {
          this.showEmptyMessageForAdvocate = true;
        }
        else{
          this.showEmptyMessageForAdvocate = false;
          this.result = result.data;
          this.resultForAdvocate = this.result[0];
          sessionStorage.setItem('patientEmail', this.resultForAdvocate[0].dashboardAssessments[0].email);
          if(sessionStorage.getItem("tokenForEmail") != null){
            const assessmentId = sessionStorage.getItem("assessmentIdFromUrl");
            for(let i =0; i < this.resultForAdvocate.length; i++){
              for(let j=0; this.resultForAdvocate[i].dashboardAssessments.length; j++){
                if(this.resultForAdvocate[i].dashboardAssessments[j].assessmentId == assessmentId){
                  this.count = true;
                  const advocateResult = this.resultForAdvocate[i].dashboardAssessments[j];
                  const index = advocateResult.length - 1;
                  this.dashboardInfo(advocateResult[index].assessmentId,advocateResult[index].gender,advocateResult[index].age,advocateResult[index].patientName,advocateResult[index].assessmentStatus,advocateResult[index].assessmentPatientId,advocateResult[index].userId,advocateResult[index].submittedOn,'0');
                }
              }
            }
          }
        }
        if(result.data[1] == null || result.data[1].length == 0){
          this.showEmptyMessageForOthers = true;
        }
        else{
          this.showEmptyMessageForOthers = false;
          this.result = result.data;
          this.resultForOthers = this.result[1];
          if(this.showEmptyMessageForAdvocate == true){
            sessionStorage.setItem('patientEmail', this.resultForAdvocate[0].dashboardAssessments[0].email);
          }
          
          if(sessionStorage.getItem("tokenForEmail") != null){
            const assessmentId = sessionStorage.getItem("assessmentIdFromUrl");
          if(this.count == false){
            for(let i =0; i < this.resultForOthers.length; i++){
              for(let j=0; this.resultForOthers[i].dashboardAssessments.length; j++){
                if(this.resultForOthers[i].dashboardAssessments[j].assessmentId == assessmentId){
                  const advocateResult = this.resultForOthers[i].dashboardAssessments[j];
                  const index = advocateResult.length - 1;
                  this.dashboardInfo(advocateResult[index].assessmentId,advocateResult[index].gender,advocateResult[index].age,advocateResult[index].patientName,advocateResult[index].assessmentStatus,advocateResult[index].assessmentPatientId,advocateResult[index].userId,advocateResult[index].submittedOn,'0');
                }
              }
            }
          }
        }
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  deleteDashboardAssessment(assessmentId: any) {
    if (this.deleteAssessmentId)
      assessmentId = this.deleteAssessmentId;
    this.hideModal()
    var deleteAssessmentId = assessmentId;
    const assessment: any = {
      assessmentId: deleteAssessmentId
    }
    this.dashboardService.deleteAssessmentDashboard(assessment).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.toastService.showSuccess(StringConstants.toast.deleteAssessment, StringConstants.toast.empty);
        let searchWord = "";
        this.getAdvocateDashboardDetails(searchWord);
      }
    }, (error) => {
      console.log(error)
    });
  }
  hideModal() {
    $("#deleteAssessment").modal("hide");
  }
  openModel(assessmentId: any) {
    this.deleteAssessmentId = assessmentId;
  }
  resetTabStatus() {
    this.dataSharingService.SaveQuickAssessment.next("");
    this.dataSharingService.SavePersonal.next("");
    this.dataSharingService.SavePersonalHome.next("");
    this.dataSharingService.SaveGuarantor.next("");
    this.dataSharingService.SaveGuarantorHome.next("");
    this.dataSharingService.SaveHousehold.next("");
    this.dataSharingService.SaveContactPreference.next("");
    this.dataSharingService.SaveHousehold.next("");
    this.dataSharingService.SaveApplicationForms.next("");
    this.dataSharingService.SavePrograms.next("");
    this.dataSharingService.SaveVerification.next("");
  }
  dashboardInfo(assessmentId: any, gender: any, age: any, fullName: any, assessmentStatus: any, patientId: any, userId: any, submittedOn: any, navigateTab: string) {
    const formValidate = {
      patientId: patientId,
      assessmentId: assessmentId
    }
    this.dashboardService.getDashboardPersonalBasicInfo(formValidate).subscribe((result: any) => {
      if (result.wasSuccessful) {
        sessionStorage.setItem('patientEmail', result.data.emailAddress);
        this.resetTabStatus();
        if (navigateTab == "7") {
          this.dataSharingService.ShowVerificationTab.next("7");
          this.router.navigate(['detail-assessment'], { queryParams: { tab: navigateTab } });
        }
        else if (navigateTab == "5") {
          this.dataSharingService.ShowProgramsTab.next("5");
          this.router.navigate(['detail-assessment'], { queryParams: { tab: navigateTab } });
        }
        else
          this.router.navigate(['detail-assessment'], { queryParams: { tab: navigateTab } });
        sessionStorage.setItem("assessmentId", assessmentId);
        sessionStorage.setItem('gender', gender);
        sessionStorage.setItem('patientId', patientId);
        sessionStorage.setItem('age', age);
        sessionStorage.setItem('submittedOn', submittedOn);
        sessionStorage.setItem('assessmentStatus', assessmentStatus);
        sessionStorage.setItem('assessmentPatientFullName', fullName);
        sessionStorage.setItem('assessmentUserId', userId);
        this.dataSharingService.isGuarantorData.next("");
        let e = this.advocateResult?.filter((e: any) => e.assessmentId === assessmentId)[0]?.isEditable;
        sessionStorage.setItem('isEditable', e);
      }
    });
  }
  dateTranformation(): string {
    var date = Date.now();
    let tranformedDate = this.datePipe.transform(date, 'M/d/yyyy, h:mm a');
    if (tranformedDate)
      return tranformedDate;
    return "";
  }
}
