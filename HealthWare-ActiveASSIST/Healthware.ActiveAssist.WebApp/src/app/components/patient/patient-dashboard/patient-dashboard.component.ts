import { AfterViewInit, Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
declare var $: any;
@Component({
  selector: 'app-patient-dashboard',
  templateUrl: './patient-dashboard.component.html',
  styleUrls: ['./patient-dashboard.component.css'],
})
export class DashboardDetailsComponent implements OnInit {
  token: any;
  result: any;
  assessmentSubmitStatus: any;
  assessmentVerificationStatus: any;
  userId: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  assessmentMoreOptions: any = {};
  closeResult = '';
  deleteAssessmentId: any;
  dashboardForm: any;
  showEmptyMessage: boolean = false;
  editTooltip: string = "";
  showLoader: boolean = false;
  search: any;
  allowApplication: boolean = false;
  allowVerification: boolean = false;
  currentTheme: any;
  searchText: any;
  submittedDate: any;
  hospitalName: any = StringConstants.patientDashboard.hospitalName;
  cell: any = StringConstants.common.cell;
  home: any = StringConstants.common.home;
  PriorSubmissions = StringConstants.patientDashboard.PriorSubmissions;
  StartNewAssessment = StringConstants.dashboardAdvocate.StartNewAssessment;
  NoRecordsFound = StringConstants.dashboardAdvocate.NoRecordsFound;
  years = StringConstants.advocateSummaryPanel.years;
  AssessmentID = StringConstants.dashboardAdvocate.AssessmentID;
  logoutMsg = StringConstants.dashboardAdvocate.logoutMsg;
  No = StringConstants.Common.No;
  Yes = StringConstants.Common.Yes;
  SubmittedBy = StringConstants.patientDashboard.SubmittedBy;
  scheduleAppointment = StringConstants.common.scheduleAppointment;
  NeedAssistance = StringConstants.patientDashboard.NeedAssistance;
  ChatWithExpert = StringConstants.patientDashboard.ChatWithExpert;
  PhoneCall = StringConstants.patientDashboard.PhoneCall;
  VideoCall = StringConstants.patientDashboard.VideoCall;
  deleteWarning = StringConstants.common.deleteWarning;
  partial: any;
  canCreateAssessment: any;
  constructor(private quickAssessmentService: QuickAssessmentService, private dataSharing: DataSharingService, private fileUpload: FileUpload, private Fb: FormBuilder, private toastService: ToastServiceService, private modalService: NgbModal, private dataSharingService: DataSharingService, private dashboardService: DashboardService, private router: Router, private formbuilder: FormBuilder) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => { //Virtual assistance
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => { //Theme setting
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit(): void {
    
    window.scroll(0, 0);
    this.dataSharingService.showUserNameInHeader.next(true);
    this.token = sessionStorage.getItem("token");
    this.userId = sessionStorage.getItem('userId');
    this.dashboardForm = this.Fb.group({
      'searchText': new FormControl('')
    });
    let partialName = "";
    this.getDashboardDetails(partialName);
    
  }
  getDashboardDetails(searchWord: any) { // Get dashboard details
    
    if (typeof searchWord == "undefined")
      searchWord = "";
    if (searchWord.target)
      var searchWord = searchWord.target.value;
    else
      var searchWord = searchWord;
    this.showLoader = true;
    this.dashboardForm.reset();
    var userId: number = +(this.userId);
    this.dashboardService.getDashboardDetails(userId, searchWord).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        if (result.data.dashboardDetailResponse.length == 0 && result.data.partialAssessment == null) {
          this.showEmptyMessage = true;
          this.dataSharing.canCreate.next(true);
          this.canCreateAssessment = true;
        }
        else {
          
          this.showEmptyMessage = false;
          this.result = result.data.dashboardDetailResponse;
          this.partial = result.data.partialAssessment;
          this.canCreateAssessment = result.data.canCreateNewAssessment;
          this.dataSharing.canCreate.next(this.canCreateAssessment);
          sessionStorage.setItem('loggedInPatientFullName', result.data.dashboardDetailResponse[0]?.submittedBy.name);
          var loggedInPatientFullName = sessionStorage.getItem('loggedInPatientFullName');
          if (loggedInPatientFullName)
            this.dataSharingService.changeFullName.next(loggedInPatientFullName);
          this.assessmentVerificationStatus = result.data.assessmentStatus;
          sessionStorage.setItem('resultID', this.partial?.partialAssessmentId);
          if(sessionStorage.getItem("tokenForEmail") != null){
            
            const assessmentId = sessionStorage.getItem("assessmentIdFromUrl");
            const result = this.result.filter((e:any) => e.assessmentId == assessmentId);
            const index = result.length - 1;
            this.dashboardInfo(result[index].assessmentId , result[index].gender, result[index].age , result[index].fullName , result[index].submittedBy.submittedOn , result[index].assessmentStatus , result[index].patientId , result[index].userId, '0');
          }
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  editPartialAssessment(quickAssessmentResultId: any) { // Edit partial assessement
    
    console.log(quickAssessmentResultId);
    sessionStorage.setItem('resultID', quickAssessmentResultId);
    this.router.navigate(['dynamic-questions']);
  }
  deletePartialAssessment(quickAssessmentResultId: any) { // Delete partial assessment
    console.log("Delete");
    this.quickAssessmentService.deletePartialAssessment(quickAssessmentResultId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.toastService.showSuccess(StringConstants.toast.assessmentDelete, StringConstants.toast.empty);
        let searchWord = "";
        this.getDashboardDetails(searchWord);
      }
    }, (error) => {
      console.log(error);
    });
  }
  startNewAssessment() { // Start new assessment
    if (this.canCreateAssessment == false) {
      this.toastService.showWarning("Kindly complete the incomplete assessment.", "");
    }
    else {
      this.router.navigate(['']);
    }
  }
  resetTabStatus() { // Reset tab status
    this.dataSharing.SaveQuickAssessment.next("");
    this.dataSharing.SavePersonal.next("");
    this.dataSharing.SavePersonalHome.next("");
    this.dataSharing.SaveGuarantor.next("");
    this.dataSharing.SaveGuarantorHome.next("");
    this.dataSharing.SaveHousehold.next("");
    this.dataSharing.SaveContactPreference.next("");
    this.dataSharing.SaveHousehold.next("");
    this.dataSharing.SaveApplicationForms.next("");
    this.dataSharing.SavePrograms.next("");
    this.dataSharing.SaveVerification.next("");
  }
  dashboardInfo(assessmentId: any, gender: any, age: any, fullName: any, submittedOn: any, assessmentStatus: any, patientId: any, userId: any, navigateTab: string) { // Get dashboard personal info
    
    const formValidate = {
      patientId: patientId,
      assessmentId: assessmentId
    }
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.getDashboardPersonalBasicInfo(formValidate).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        sessionStorage.setItem('patientEmail', result.data.emailAddress);
      }
    });
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.resetTabStatus();
        if (result.data.isApplicationFormEnabled == true) {
          this.allowApplication = true;
          this.dataSharingService.EnableDocumentation.next("true");
        }
        else {
          this.allowApplication = false;
          this.dataSharingService.EnableDocumentation.next("false");
        }
        if (result.data.isApplicationFormsComplete == true) this.allowVerification = true;
        else this.allowVerification = false;

        if (this.allowApplication != true && navigateTab == "5") {
          this.toastService.showWarning(StringConstants.toast.completeEsign, StringConstants.toast.empty);
        }
        else if (this.allowVerification != true && navigateTab == "6") {
          this.toastService.showWarning(StringConstants.toast.completeDocs, StringConstants.toast.empty);
        }
        else {
          this.router.navigate(['detail-assessment'], { queryParams: { tab: navigateTab } });
        }
      }
    });
    sessionStorage.setItem("assessmentId", assessmentId);
    sessionStorage.setItem('gender', gender);
    sessionStorage.setItem('patientId', patientId);
    sessionStorage.setItem('age', age);
    sessionStorage.setItem('submittedOn', submittedOn);
    sessionStorage.setItem('assessmentStatus', assessmentStatus);
    sessionStorage.setItem('assessmentPatientFullName', fullName);
    sessionStorage.setItem('assessmentUserId', userId);
    this.dataSharingService.isGuarantorData.next("");
    var AId = this.result.filter((AId: any) => AId.assessmentId === assessmentId)[0].isEditable;
    sessionStorage.setItem('isEditable', AId);
    var Status = this.result.filter((Status: any) => Status.assessmentId === assessmentId)[0].statusDisplayName;
    sessionStorage.setItem('statusDisplay', Status);
  }
  moreOptions(assessmentId: string) { // More options
    this.assessmentMoreOptions[assessmentId] = !this.assessmentMoreOptions[assessmentId];
  }
  open(deleteAssessment: any, assessmentId: any) { // Open modal
    this.deleteAssessmentId = assessmentId;
    this.modalService.open(deleteAssessment,
      { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult =
          `Dismissed ${this.getDismissReason(reason)}`;
      });
    var btn = document.getElementById("deleteButton");
  }
  private getDismissReason(reason: any): string { // Close modal 
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  hideModal() {
    $("#deleteAssessment").modal("hide");
  }
  deleteDashboardAssessment(assessmentId: any) { //Delete dasboard assessment
    this.hideModal()
    var deleteAssessmentId = assessmentId;
    const assessment: any = {
      assessmentId: deleteAssessmentId
    }
    this.dashboardService.deleteAssessmentDashboard(assessment).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.toastService.showSuccess(StringConstants.toast.assessmentDelete, StringConstants.toast.empty);
        let searchWord = "";
        this.getDashboardDetails(searchWord);
      }
    }, (error) => {
      console.log(error)
    });
  }
}
