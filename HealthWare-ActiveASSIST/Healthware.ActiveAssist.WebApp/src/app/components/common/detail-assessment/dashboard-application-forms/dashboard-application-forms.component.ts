import { Input, SimpleChanges, } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { Router } from '@angular/router';
import { Component, ViewChild, OnInit, Output, EventEmitter, ElementRef, AfterViewInit } from '@angular/core';
import { Subject } from 'rxjs';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { FormControl, FormGroup } from '@angular/forms';
import { StringConstants } from 'src/assets/constants/string.constants';
import { environment } from 'src/environments/environment';
import { ApiConstants } from 'src/assets/constants/url';
import { HttpClient } from '@angular/common/http';
import { Identifiers } from '@angular/compiler';
import { AuthService } from 'src/app/services/auth.service';
const FileSaver = require('file-saver');
declare const WebViewer: any;
declare var $: any;
@Component({
  selector: 'app-dashboard-application-forms',
  templateUrl: './dashboard-application-forms.component.html',
  styleUrls: ['./dashboard-application-forms.component.css']
})
export class DashboardApplicationFormsComponent implements OnInit, AfterViewInit {
  applicationForm: any;
  panelOpenStateForms: boolean = false;
  panelOpenStateBenefits: boolean = false;
  veteransAdminFlag: boolean = true;
  financialAssistanceFlag: boolean = false;
  @ViewChild('closeModal')
  closeModal: ElementRef | any;
  patientId: any;
  assessmentId: any;
  activeReviewProgramDetails: ActiveProgramsResponse[] = {} as ActiveProgramsResponse[];
  programDocumentDetails: ProgramDocument[] = {} as ProgramDocument[];
  programDocumentDownloadUrl: string = "";
  programName: string = "";
  benefitsDescription: string = "";
  activeprogramIdList: string[] = [];
  inactiveprogramIds: string[] = [];
  selectedProgram: boolean = false;
  programMenuDivClass: any = {};
  programMenuLabelClass: any = {};
  currentselectedProgram: any;
  programActiveStatus: any;
  programStatus: any;
  fullName: any;
  address: string = "";
  homeCell: any;
  workCell: any;
  ProgramsUpdateDetails: ProgramsUpdateDto[] = [];
  annonationInstance: any;
  documentName: string = "";
  firstName: any;
  middleName: any;
  lastName: any;
  dateOfBirth: any;
  gender: any;
  maritalStatus: any;
  city: any;
  state: any;
  zipcode: any;
  county: any;
  fullAddress: string = "";
  formsModal: any;
  toShowActivePrograms: boolean = false;
  viewerInstance: any;
  CurrentProgramDocumentId: string = "";
  isSavedForm: boolean = false;
  @ViewChild('viewer')
  viewerRef!: ElementRef;
  wvInstance: any;
  @Output() coreControlsEvent: EventEmitter<any> = new EventEmitter();
  programstatusMap = new Map<string, boolean>();
  fromVerification: any;
  showLoader: boolean = false;
  isAdvocate: boolean = false;
  private documentLoaded$: Subject<void>;
  closeResult = '';
  isEditAllowed: any;
  assessmentStatus: any;
  isFormSigned: any;
  eSignDone: string = "";
  callApplication: any;
  currentTheme: any;
  benefitsLabel: any = StringConstants.applicationForms.benefitsTitle;
  formsTitleLabel: any = StringConstants.common.formsTitle;
  esignLabel: any = StringConstants.applicationForms.eSign;
  shareLabel: any = StringConstants.applicationForms.share;
  downloadLabel: any = StringConstants.applicationForms.download;
  uploadFormsLabel: any = StringConstants.applicationForms.uploadForms;
  closeLabel: any = StringConstants.applicationForms.close;
  saveAndCloseLabel: any = StringConstants.applicationForms.saveClose;
  programsNotApplied: any = StringConstants.applicationForms.programsNotApplied;
  noLabel: any = StringConstants.common.no;
  applyLabel: any = StringConstants.common.apply;
  topHeaderLabel: any = StringConstants.applicationForms.topHeader;
  topTitleLabel: any = StringConstants.applicationForms.topTilte;
  messageInfo: any = StringConstants.applicationForms.messageInfo;
  scheduleAppointment: any = StringConstants.common.scheduleAppointment;
  moreInformation: any = StringConstants.applicationForms.moreInformation;
  EsignStatus: any = {};
  notSigned: any;
  signed: any;
  formattedDocumentId: any;
  previousFile: any;
  benefitsUrl: string = "";
  disableFlag: any = {};
  Uploaded = StringConstants.applicationForms.Uploaded;
  NotUploaded = StringConstants.applicationForms.NotUploaded;
  programID: any;
  constructor(private toastService: ToastServiceService, private dataSharingService: DataSharingService, private modalService: NgbModal, private dialog: MatDialog,
    private dashboardService: DashboardService, private fileUpload: FileUpload, private http: HttpClient, private authService: AuthService, private router: Router) {
    this.documentLoaded$ = new Subject<void>();
    this.fileUpload.uploadedDocumentId$.subscribe(response => {
      let programDocumentId = response.ProgramDocumentId;
      let documentId = response.DocumentId;
      var index = this.programDocumentDetails.findIndex(val => val.programDocumentId == programDocumentId);
      this.programDocumentDetails[index].documentId = documentId;
      if (this.isSavedForm) { // Reset the form status flag
        this.getTabStatus();
        this.isSavedForm = false;
      }
      else {
        if (documentId == "0")
          this.toastService.showWarning(StringConstants.toast.submitEform, StringConstants.toast.empty);
        else (documentId != "0")
        {
          this.showLoader = false;
          this.previousFile = null;
          this.closeModal.nativeElement.click()
          this.toastService.showSuccess(StringConstants.toast.formUpload, StringConstants.toast.empty);
          this.getTabStatus();
          this.EsignStatus[programDocumentId] = true;
        }
      }
    });
    this.dataSharingService.MoveToForms.subscribe(value => {//To go next forms
      this.fromVerification = value;
    });
    this.dataSharingService.showApplicationFormNext.subscribe(value => {//To show next application
      this.callApplication = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => { //To Change theme
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.editable.subscribe(value => { // Check assessment is incomplete or under review
      this.isEditAllowed = value;
    });
  }
  ngAfterViewInit(): void {
    this.isAdvocate = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
  }
  ngOnInit(): void {
    this.assessmentId = sessionStorage.getItem('assessmentId');
    this.patientId = sessionStorage.getItem('patientId');
    this.initForm();
    if (this.callApplication == "5") {
      this.GetActiveReviewPrograms();
      this.getEFormData();
      this.programActiveStatus = 'true';
      this.getTabStatus();
      this.notSigned = false;
    }
  }
  valueChange(event: any, id: any) {
    this.disableFlag[id] = event.value;
  }
  previewDocument(documentId: string) { // To preview application document
    window.open(this.fileUpload.getDocumentDownloadURL(documentId), "_blank");
  }
  private initForm() {
    this.applicationForm = new FormGroup({
      'programStatus': new FormControl('')
    });
  }
  @Input() set currentTabUpdate(value: boolean) {//Click event for current tab
    if (value != undefined) {
      this.EsignStatus = {};
      this.dataSharingService.showApplicationFormNext.next("5");
      this.GetActiveReviewPrograms();
      this.getEFormData();
      this.programActiveStatus = 'true';
      this.getTabStatus();
      this.notSigned = false;
    }
  }
  async downloadApplicationForm(programDocumentId: string) { // To download application forms
    this.showLoader = true;
    var downloadUrl = await this.fileUpload.GetProgramDocumentDownloadURL(programDocumentId);
    var FileSaver = require('file-saver');
    var fileName = this.programName + ".pdf";
    let blob = await fetch(downloadUrl).then(r => r.blob());
    FileSaver.saveAs(blob, fileName, { type: 'application/pdf' });
    this.showLoader = false;
  }
  async loadDocumentOpen(documentName: string, programDocumentId: string, documentId: string, programId: string) {// To get program list based on assessment
    this.CurrentProgramDocumentId = programDocumentId;
    var data: string;
    var currentDocumentId;
    const fileDetails: FileDetails = {
      AssessmentId: +(this.assessmentId),
      UserId: +(sessionStorage.getItem("patientId")!),
      HouseHoldMemberId: 0,
      ProgramId: programId,
      DocumentTitle: "programdocument",
      DocumentCategory: "Eforms",
      DocumentType: "Eforms",
      ProgramDocumentId: +(programDocumentId),
      DocumentName: documentName
    };
    this.showLoader = true;
    var result = await this.http.post<any>(environment.apiBaseUrl + ApiConstants.url.GetAssessmentProgramDocument, fileDetails).toPromise();
    if (result) {
      this.formattedDocumentId = result.data;
      this.previousFile = result.nextAction;
      if (documentId == "0") {
        data = this.fileUpload.GetProgramDocumentDownloadURL(programDocumentId);
        currentDocumentId = programDocumentId;
      }
      else {
        data = this.fileUpload.getDocumentDownloadURL(documentId);
        currentDocumentId = documentId;
      }
      this.router.navigate(['esign-document'], { queryParams: { documentId: this.formattedDocumentId, documentName: documentName, programId: programId } });
      this.showLoader = false;
    }
  }
  async getProgramDocument(assessmentId: string, programId: string, programDocumentId: string, documentName: string) {// Get programs document
    const fileDetails: FileDetails = {
      AssessmentId: +(assessmentId),
      UserId: +(sessionStorage.getItem("patientId")!),
      HouseHoldMemberId: 0,
      ProgramId: programId,
      DocumentTitle: "programdocument",
      DocumentCategory: "Eforms",
      DocumentType: "Eforms",
      ProgramDocumentId: +(programDocumentId),
      DocumentName: documentName
    };
    this.fileUpload.createProgramDocument(fileDetails).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.formattedDocumentId = result.data;
      }
    }, (error) => {
      console.log(error)
    });
  }
  async closeDocument() { // To close document
    if (this.formattedDocumentId > 0 && this.previousFile != null) {
      await this.fileUpload.UpdateDocumentPathById(this.formattedDocumentId, this.previousFile).subscribe(async event => {
        this.previousFile = null;
      },
        (err) => {
          console.log(StringConstants.toast.uploadError, err);
        }, () => {
        }
      )
    }
  }
  downloadDocument() { // To download document
    var instance = this.viewerInstance;
    if (instance) {
      instance.UI.downloadPdf({
        includeAnnotations: true,
        flatten: true,
      });
    }
  }
  getEFormData() { // To get form data
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const eformRequest: any = {
      patientId: patientID,
      assessmentId: assessmentId,
    }
    this.dashboardService.GetEFormData(eformRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.fullName = result.data.mainApplicantDetails.forename + ' ' + result.data.mainApplicantDetails.surname,
          this.homeCell = result.data.mainApplicantDetails.homeCellNumber,
          this.workCell = result.data.mainApplicantDetails.workCellNumber,
          this.fullAddress = result.data.mainApplicantDetails.address + ' ' + result.data.mainApplicantDetails.zipCode,
          this.city = result.data.mainApplicantDetails.city,
          this.state = result.data.mainApplicantDetails.state,
          this.zipcode = result.data.mainApplicantDetails.zipCode,
          this.county = result.data.mainApplicantDetails.county,
          this.dateOfBirth = result.data.mainApplicantDetails.dateOfBirth,
          this.gender = result.data.mainApplicantDetails.gender,
          this.maritalStatus = result.data.mainApplicantDetails.maritalStatus,
          this.firstName = result.data.mainApplicantDetails.forename,
          this.middleName = result.data.mainApplicantDetails.middleName,
          this.lastName = result.data.mainApplicantDetails.surname
      }
    }, (error) => {
      console.log(error)
    });
  }
  SaveReviewProgram() { // To update review program details
    this.assessmentId = +(sessionStorage.getItem('assessmentId')!);
    this.patientId = +(sessionStorage.getItem('patientId')!);
    var data: ProgramsUpdateDto = {
      patientId: this.patientId,
      assessmentId: this.assessmentId,
      programId: this.currentselectedProgram,
      isActive: (/true/i).test(this.applicationForm.get('programStatus').value!),
      isEvaluated: true
    }
    this.ProgramsUpdateDetails.push(data);
    this.dashboardService.UpdatePatientReviewPrograms(this.ProgramsUpdateDetails)
      .subscribe(async (result: any) => {
        this.ProgramsUpdateDetails.pop();
        this.getTabStatus();
      }, (error) => {
        console.log(error)
      });
  }
  ProgramsOnChange(programId: string) { // To change program status
    this.ChangeBackground(programId);
    var result = this.getProgramDetail(programId);
    this.programName = result.programName;
    this.programID = programId;
    this.benefitsDescription = result.benefits;
    this.benefitsUrl = result.benefitsUrl;
    this.UpdateProgramDocumentDetail(programId);
    this.panelOpenStateBenefits = false;
    this.panelOpenStateForms = false;
    this.currentselectedProgram = programId;
    this.applicationForm.controls['programStatus'].setValue(this.programstatusMap.get(programId)!.toString());
  }
  ChangeBackground(programId: string) { // To change current page div
    this.programMenuDivClass[programId] = "dasboard-side-div";
    this.programMenuLabelClass[programId] = "dashboard-side-div-label";
    this.inactiveprogramIds = [];
    for (var i of this.activeprogramIdList) {
      this.inactiveprogramIds.push(i);
    }
    if (this.activeprogramIdList) {
      const index = this.activeprogramIdList.indexOf(programId);
      if (index > -1) {
        this.inactiveprogramIds.splice(index, 1);
      }
    }
    this.inactiveprogramIds.forEach(inactiveprogramId => {
      this.programMenuDivClass[inactiveprogramId] = "";
      this.programMenuLabelClass[inactiveprogramId] = "";
    });
  }
  getTabStatus() { // To get current tab status
    var assessmentId: number = +(this.assessmentId);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        this.isFormSigned = result.data.isApplicationFormsComplete;
        switch (result.data.isApplicationFormsComplete) {
          case true: this.eSignDone = "true"; this.signed = true; break;
          case false: this.eSignDone = "false"; this.signed = false; break;
          default: this.eSignDone = ""; this.signed = false;
        }
        this.dataSharingService.SaveApplicationForms.next(this.eSignDone);
        if (result.data.canEvaluate == true && result.data.isApplicationFormsComplete == true) {
          this.dataSharingService.EnableDocumentation.next('true');
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  async getFinalTab() { // To get current tab status
    var assessmentId: number = +(this.assessmentId);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.showLoader = true;
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        await this.isFormSigned;
        this.isFormSigned = result.data.isApplicationFormsComplete;
        switch (this.isFormSigned) {
          case true: this.eSignDone = "true"; this.signed = true; break;
          case false: this.eSignDone = "false"; this.signed = false; break;
          default: this.eSignDone = ""; this.signed = false;
        }
        this.dataSharingService.SaveApplicationForms.next(this.eSignDone);
        if (result.data.canEvaluate == true && result.data.isApplicationFormsComplete == true) {
          this.dataSharingService.EnableDocumentation.next('true');
        }
        setTimeout(() => {
          if (this.signed == true) {
            this.dataSharingService.ShowVerificationTab.next("6");
            this.notSigned = false;
            this.showLoader = false;
          }
          else if (this.signed == false) {
            this.toastService.showWarning(StringConstants.toast.submitOrUploadForm, StringConstants.toast.empty);
            this.notSigned = true;
            this.dataSharingService.SaveApplicationForms.next("false");
            this.showLoader = false;
          }
        }, 500);
      }
    }, (error) => {
      console.log(error)
    });
  }
  navBackward(programId: string) {// To navigate backward
    var index = this.activeprogramIdList.indexOf(programId);
    if (index == 0)
      this.dataSharingService.showHouseholdTab.next("4");
    else
      this.ProgramsOnChange(this.activeprogramIdList[--index]);
  }
  navForward(programId: string) { // To navigate forward
    this.SaveReviewProgram();
    this.getTabStatus();
    this.programstatusMap.set(programId, (/true/i).test(this.applicationForm.controls['programStatus'].value));
    var index = this.activeprogramIdList.indexOf(programId);
    if (index == (this.activeprogramIdList.length - 1)) {
      this.getFinalTab();
    }
    else
      this.ProgramsOnChange(this.activeprogramIdList[++index]);
  }
  HandleProgramDocument(event: any) { // To handle program documents
    var Id = event.target.id.split("_");
    if (event.target.files.length > 0) {
      this.fileUpload.UploadProgramDocument(this.assessmentId, Id[1], Id[0], event.target.files[0]);
      this.showLoader = true;
    }
  }
  GetActiveReviewPrograms() { // To get active program list
    this.showLoader = true;
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const request: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.GetEvaluatedReviewPrograms(request)
      .subscribe(async (result: any) => {
        this.activeReviewProgramDetails = result.data.reviewPrograms;
        this.showLoader = false;
        if (this.activeReviewProgramDetails.length == 0) {
          this.toShowActivePrograms = false;
        }
        else if (this.activeReviewProgramDetails.length != 0) {
          for (let data of this.activeReviewProgramDetails) {
            this.disableFlag[data.programId] = (data.isActive.toString());
            this.programstatusMap.set(data.programId, data.isActive)
          }
          this.toShowActivePrograms = true;
          this.saveAllProgramIds(this.activeReviewProgramDetails);
          if (this.fromVerification == true) {
            this.ProgramsOnChange(this.activeReviewProgramDetails[this.activeReviewProgramDetails.length - 1].programId);
            this.dataSharingService.MoveToForms.next(false);
          }
          else
            this.ProgramsOnChange(this.activeReviewProgramDetails[0].programId);
        }
      },
        (err) => {
          console.log(StringConstants.toast.error, err);
        }, () => {
        }
      )
  }
  saveAllProgramIds(activeReviewProgramDetails: ActiveProgramsResponse[]) { // To save programs
    this.activeprogramIdList = [];
    activeReviewProgramDetails.forEach(detail => {
      this.activeprogramIdList.push(detail.programId);
      this.programstatusMap.set(detail.programId, detail.isActive);
    });
  }
  UpdateProgramDocumentDetail(programId: string) { // Update program document
    var IsEvaluated = (/true/i).test(this.disableFlag[programId]);
    this.fileUpload.GetProgramDocumentDetails(programId, this.assessmentId, IsEvaluated)
      .subscribe(async (result: any) => {
        this.programDocumentDetails = result.data;
        for (let data of this.programDocumentDetails) {
          this.EsignStatus[data.programDocumentId] = data.isProgramDocumentEsigned;
        }
        console.log(this.EsignStatus);
        this.disableFlag[programId] = this.programstatusMap.get(programId)!.toString();
      },
        (err) => {
          console.log(StringConstants.toast.error, err);
        }, () => {
        })
  }
  getProgramDetail(programId: string) {// Get program details
    var data: ActiveProgramsResponse = {} as ActiveProgramsResponse;
    this.activeReviewProgramDetails.forEach(element => {
      if (element.programId == programId) data = element;
    });
    return data;
  }
  veteransAdmin() {
    this.veteransAdminFlag == true;
    this.financialAssistanceFlag == false;
  }
  financialAssistance() {
    this.veteransAdminFlag == false;
    this.financialAssistanceFlag == true;
  }
  open(content: any) { // To open modal
    this.modalService.open(content,
      { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult =
          `Dismissed ${this.getDismissReason(reason)}`;
      });
  }
  private getDismissReason(reason: any): string { // To dismiss modal
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  getDocumentLoadedObservable() { // To load document
    return this.documentLoaded$.asObservable();
  }
}
export interface ActiveProgramsResponse {
  programId: string;
  programName: string;
  benefits: string;
  status: any;
  benefitsUrl: string;
  isActive: boolean;
}
export interface ProgramDocument {
  programId: string;
  programDocumentId: string;
  documentName: string;
  documentDescription: string;
  documentId: string;
  isProgramDocumentEsigned: boolean;
  esignFlag: boolean;
}
export interface ProgramsUpdateDto {
  patientId: number;
  assessmentId: number;
  programId: number;
  isActive: boolean;
  isEvaluated: boolean;
}
export interface FileDetails {
  AssessmentId: any
  UserId: any
  HouseHoldMemberId: any
  ProgramId: string
  DocumentTitle: string
  DocumentCategory: string
  DocumentType: string
  ProgramDocumentId: any
  DocumentName?: string
}
