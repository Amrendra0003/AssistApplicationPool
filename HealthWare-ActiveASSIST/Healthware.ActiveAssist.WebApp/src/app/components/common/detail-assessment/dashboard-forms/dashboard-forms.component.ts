import { Input, SimpleChanges, } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { FormDialogComponent } from '../../form-dialog/form-dialog.component';
import { Component, ViewChild, OnInit, Output, EventEmitter, ElementRef, AfterViewInit } from '@angular/core';
import { Subject } from 'rxjs';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { FormControl, FormGroup } from '@angular/forms';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
const FileSaver = require('file-saver');
declare var $: any;
declare const WebViewer: any;
@Component({
  selector: 'app-dashboard-forms',
  templateUrl: './dashboard-forms.component.html',
  styleUrls: ['./dashboard-forms.component.css']
})
export class DashboardFormsComponent implements OnInit {
  applicationForm: any;
  panelOpenStateForms: boolean = true;
  veteransAdminFlag: boolean = true;
  financialAssistanceFlag: boolean = false;
  closeModal: any;
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
  documentInstance: any;
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
  isFormSigned: string = "";
  programId: any;
  currentTheme: any;
  programIdData: any;
  fromViewForm: boolean = false;
  EsignStatus: any = {};
  notSigned: any;
  DashboardFormInfo1 = StringConstants.DashboardForm.DashboardFormInfo1;
  DashboardFormInfo2 = StringConstants.DashboardForm.DashboardFormInfo2;
  EligibilityExperts = StringConstants.DashboardForm.EligibilityExperts;
  scheduleAppointment = StringConstants.common.scheduleAppointment;
  KindlyReview = StringConstants.DashboardForm.KindlyReview;
  Forms = StringConstants.common.formsTitle;
  NotUploaded = StringConstants.applicationForms.NotUploaded;
  ESign = StringConstants.Common.ESign;
  Share = StringConstants.Common.Share;
  download = StringConstants.applicationForms.download;
  uploadForms = StringConstants.applicationForms.uploadForms;
  saveClose = StringConstants.applicationForms.saveClose;
  close = StringConstants.applicationForms.close;
  constructor(private toastService: ToastServiceService, private dataSharingService: DataSharingService, private modalService: NgbModal, private dialog: MatDialog,
    private dashboardService: DashboardService, private fileUpload: FileUpload, private authService: AuthService) {
    this.documentLoaded$ = new Subject<void>();
    this.dataSharingService.changeTheme.subscribe(value => { // To change theme
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.fileUpload.uploadedDocumentId$.subscribe(response => { // To upload documents
      let programDocumentId = response.ProgramDocumentId;
      let documentId = response.DocumentId;
      var index = this.programDocumentDetails.findIndex(val => val.programDocumentId == programDocumentId);
      this.programDocumentDetails[index].documentId = documentId;
      if (this.isSavedForm) {
        // Reset the form status flag
        this.isSavedForm = false;
      }
      else {
        if (documentId == "0")
          this.toastService.showWarning(StringConstants.toast.submitEform, StringConstants.toast.empty);
        else (documentId != "0")
        {
          this.showLoader = false;
          this.EsignStatus[programDocumentId] = true;
        }
      }
    });
    this.dataSharingService.MoveToForms.subscribe(value => { // Go to Forms
      this.fromVerification = value;
    });
    this.dataSharingService.sendProgramID.subscribe(value => { // Send program Id
      this.programIdData = value;
      if (value != "" && this.fromViewForm == false) {
        this.fromViewForm = true;
      }
    });
    this.dataSharingService.editable.subscribe(value => { // Check assessment status incomplete or under review
      this.isEditAllowed = value;
    });
  }
  ngAfterViewInit(): void {
    this.isAdvocate = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
    if (this.viewerInstance == null) {
      this.loadDocument();
    }
  }
  ngOnInit(): void {
    this.assessmentId = sessionStorage.getItem('assessmentId');
    this.patientId = sessionStorage.getItem('patientId');
    this.initForm();
  }
  private initForm() {
    this.applicationForm = new FormGroup({
      'programStatus': new FormControl('')
    });
  }
  @Input() set currentTabUpdate(value: boolean) { // To get current tab details
    if (value != undefined) {
      this.EsignStatus = {};
      this.dataSharingService.ShowFormsTab.next("6");
      this.GetActiveReviewPrograms();
      this.getEFormData();
      this.applicationForm.controls['programStatus'].setValue('true');
      this.programActiveStatus = 'true';
    }
  }
  async saveApplication() { // To save application
    var programId = this.programDocumentDetails.find(val => val.programDocumentId == this.CurrentProgramDocumentId)?.programId!;
    var documentName = this.programDocumentDetails.find(val => val.programDocumentId == this.CurrentProgramDocumentId)?.documentName!;
    const doc = this.documentInstance.getDocument();
    const xfdfString = await this.annonationInstance.exportAnnotations();
    const options = { xfdfString, flatten: true };
    const data = await doc.getFileData(options);
    const arr = new Uint8Array(data);
    const blob = new Blob([arr], { type: 'application/pdf' });
    var myFile = new File([blob], documentName + ".pdf");
    this.isSavedForm = true;
    var response = await this.fileUpload.UploadProgramDocument(this.assessmentId, programId, this.CurrentProgramDocumentId, myFile);
    this.formsModal.hide();
  }
  async downloadApplicationForm(programDocumentId: string) { // To download application
    var downloadUrl = this.fileUpload.GetProgramDocumentDownloadURL(programDocumentId);
    var FileSaver = require('file-saver');
    var fileName = this.programName + ".pdf";
    let blob = await fetch(downloadUrl).then(r => r.blob());
    FileSaver.saveAs(blob, fileName, { type: 'application/pdf' });
  }
  loadDocumentOpen(documentName: string, ProgramDocumentId: string, documentId: string) { // To open loaded document 
    this.CurrentProgramDocumentId = ProgramDocumentId;
    var data;
    var currentDocumentId;
    if (documentId == "0") {  //Get call to fetch the document using ProgramDocumentId
      data = this.fileUpload.GetProgramDocumentDownloadURL(ProgramDocumentId);
      currentDocumentId = ProgramDocumentId;
    }
    else { //Get call to fetch the document using documentId
      data = this.fileUpload.getDocumentDownloadURL(documentId);
      currentDocumentId = documentId;
    }
    this.documentInstance.loadDocument(data, { extension: 'pdf', documentId: currentDocumentId });
    if (this.annonationInstance && documentId != "0") {
      this.annonationInstance.enableReadOnlyMode();
      this.annonationInstance.disableFreeTextEditing();
      this.annonationInstance.flatten = true;
    }
    this.documentName = documentName;
  }
  loadDocument() { // To load document
    if (this.viewerInstance != null)
      return;
    WebViewer({
      path: '../HealthwareApp/wv-resources/lib',
    }, this.viewerRef.nativeElement).then((instance: { UI: { disableElements: (arg0: string[]) => void; disableTools: (arg0: string[]) => void; FitMode: any; setFitMode: (arg0: any) => void; }; Core: { documentViewer: any; annotationManager: any; }; }) => {
      this.viewerInstance = instance;
      instance.UI.disableElements(['toolbarGroup-Edit']);
      instance.UI.disableElements(['toolbarGroup-View']);
      instance.UI.disableElements(['toolbarGroup-Annotate']);
      instance.UI.disableElements(['toolbarGroup-Insert']);
      instance.UI.disableElements(['toolbarGroup-Shapes']);
      instance.UI.disableElements(['toolbarGroup-Forms']);
      instance.UI.disableTools(['AnnotationCreateFreeText', 'AnnotationCreateFreeText']);
      var FitMode = instance.UI.FitMode;
      instance.UI.setFitMode(FitMode.FitWidth);
      const { documentViewer, annotationManager } = instance.Core;
      this.documentInstance = documentViewer;
      this.annonationInstance = annotationManager;
      documentViewer.addEventListener('documentLoaded', () => {
        documentViewer.getAnnotationsLoadedPromise().then(() => {
          const fieldManager = annotationManager.getFieldManager();
          //Veteran document
          const nameOfVeteran = fieldManager.getField("PATLastFirst");
          if (nameOfVeteran) {
            nameOfVeteran.setValue(this.fullName);
          }
          const relationship = fieldManager.getField("Check Box99");
          if (relationship) {
            relationship.setValue('Yes');
          }
          const homeCell = fieldManager.getField("PATHomePhone");
          if (homeCell) {
            homeCell.setValue(this.homeCell);
          }
          const workCell = fieldManager.getField("PATWorkPhone");
          if (workCell) {
            workCell.setValue(this.workCell);
          }
          const address = fieldManager.getField("6 MY ADDRESS IS Number Street or losl Oflice Rox City State  ZIP ode");
          if (address) {
            address.setValue(this.fullAddress);
          }
          //Memorial Hospital Document 1
          const nameOfVictim = fieldManager.getField("PATFullName");
          if (nameOfVictim) {
            nameOfVictim.setValue(this.fullName);
          }
          const victimAddress = fieldManager.getField("PATAddressBothLines");
          if (victimAddress) {
            victimAddress.setValue(this.fullAddress);
          }
          const city = fieldManager.getField("PATCity");
          if (city) {
            city.setValue(this.city);
          }
          const state = fieldManager.getField("PATState");
          if (state) {
            state.setValue(this.state);
          }
          const zipcode = fieldManager.getField("PATZip");
          if (zipcode) {
            zipcode.setValue(this.zipcode);
          }
          const dateOfBirth = fieldManager.getField("PATDOB");
          if (dateOfBirth) {
            dateOfBirth.setValue(this.dateOfBirth);
          }
          const victimCounty = fieldManager.getField("Country of Birth  National Origin");
          if (victimCounty) {
            victimCounty.setValue(this.county);
          }
          const gender = fieldManager.getField("PATGender");
          if (gender) {
            if (this.gender == "Male") {
              gender.setValue("Choice1");
            }
            else if (this.gender == "Female") {
              gender.setValue("Choice3");
            }
          }
          const maritalStatus = fieldManager.getField("PATMaritalStatus");
          if (maritalStatus) {
            if (this.maritalStatus == "Single") {
              maritalStatus.setValue("S");
            }
            else if (this.maritalStatus == "Married") {
              maritalStatus.setValue("M");
            }
            else if (this.maritalStatus == "Separated") {
              maritalStatus.setValue("X");
            }
            else if (this.maritalStatus == "Divorced") {
              maritalStatus.setValue("D");
            }
            else if (this.maritalStatus == "Widowed") {
              maritalStatus.setValue("W");
            }
          }
          //Memorial Hospital Document 1
          const individualName = fieldManager.getField("PATFirstName");
          if (individualName) {
            individualName.setValue(this.firstName);
          }
          const middlename = fieldManager.getField("PATMiddleName");
          if (middlename) {
            middlename.setValue(this.middleName);
          }
          const lastname = fieldManager.getField("PATLastNameSuffix");
          if (lastname) {
            lastname.setValue(this.lastName);
          }
          const county = fieldManager.getField("Text6");
          if (county) {
            county.setValue(this.county);
          }
        });
      });
    })
  }
  closeDocument() { // To close document
    if (this.documentInstance)
      this.documentInstance.dispose()
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
  getEFormData() { // Get form details
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
  SaveReviewProgram() { // To save review programs
    this.assessmentId = +(sessionStorage.getItem('assessmentId')!);
    this.patientId = +(sessionStorage.getItem('patientId')!);
    var data: ProgramsUpdateDto = {
      patientId: this.patientId,
      assessmentId: this.assessmentId,
      programId: this.currentselectedProgram,
      isActive: (/true/i).test(this.programStatus!)
    }
    this.ProgramsUpdateDetails.push(data);
    this.dashboardService.UpdatePatientReviewPrograms(this.ProgramsUpdateDetails)
      .subscribe(async (result: any) => {
        this.ProgramsUpdateDetails.pop();
      }, (error) => {
        console.log(error)
      });
  }
  ProgramsOnChange(programId: string) { // Programs change event
    this.ChangeBackground(programId);
    var result = this.getProgramDetail(programId);
    this.programName = result.programName;
    this.benefitsDescription = result.benefits;
    this.UpdateProgramDocumentDetail(programId);
    this.panelOpenStateForms = true;
    this.currentselectedProgram = programId;
    this.applicationForm.controls['programStatus'].setValue(this.programstatusMap.get(programId)!.toString());
  }

  ChangeBackground(programId: string) { // To show side bar div
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
  getTabStatus() { // To get tab status
    var assessmentId: number = +(this.assessmentId);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        switch (result.data.isApplicationFormsComplete) {
          case true: this.isFormSigned = "true"; break;
          case false: this.isFormSigned = "false"; break;
          case null: this.isFormSigned = "";
        }
        this.dataSharingService.SaveApplicationForms.next(this.isFormSigned);
      }
    }, (error) => {
      console.log(error)
    });
  }
  navBackward(programId: string) { // To navigate backward
    var index = this.activeprogramIdList.indexOf(programId);
    if (index == 0)
      this.dataSharingService.showHouseholdTab.next("5");
    else
      this.ProgramsOnChange(this.activeprogramIdList[--index]);
  }
  navForward(programId: string) { // To navigate forward
    this.SaveReviewProgram();
    this.programstatusMap.set(programId, (/true/i).test(this.applicationForm.controls['programStatus'].value));
    var index = this.activeprogramIdList.indexOf(programId);
    // To check if the active program is the last program or there is only one program.
    if (index == (this.activeprogramIdList.length - 1) || this.activeprogramIdList.length == 1) {
      if (this.isAdvocate) {
        this.getTabStatus();
        this.dataSharingService.ShowVerificationTab.next("7");
      }
      else {
        this.getTabStatus();
        this.dataSharingService.ShowVerificationTab.next("6");
      }
    }
    else
      this.ProgramsOnChange(this.activeprogramIdList[++index]);
  }
  HandleProgramDocument(event: any) { // To handle document
    var Id = event.target.id.split("_");
    if (event.target.files.length > 0) {
      this.fileUpload.UploadProgramDocument(this.assessmentId, Id[1], Id[0], event.target.files[0]);
      this.showLoader = true;
    }
  }
  previewDocument(documentId: string) { // To preview document
    window.open(this.fileUpload.getDocumentDownloadURL(documentId), "_blank");
  }
  GetActiveReviewPrograms() { //To get active review programs
    this.showLoader = true;
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const request: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.GetActiveReviewPrograms(request)
      .subscribe(async (result: any) => {
        this.activeReviewProgramDetails = result.data.reviewPrograms.filter
          ((reviewProgram: { status: string; }) => reviewProgram.status == 'Application Submitted');
        this.showLoader = false;
        if (this.activeReviewProgramDetails.length == 0) {
          this.toShowActivePrograms = false;
        }
        else if (this.activeReviewProgramDetails.length != 0) {
          this.toShowActivePrograms = true;
          this.saveAllProgramIds(this.activeReviewProgramDetails);
          if (this.fromViewForm == true) {
            this.ProgramsOnChange(this.programIdData);
            this.fromViewForm = false;
            this.dataSharingService.sendProgramID.next("");
          }
          else if (this.fromVerification == true) {
            this.ProgramsOnChange(this.activeReviewProgramDetails[this.activeReviewProgramDetails.length - 1].programId);
            this.dataSharingService.MoveToForms.next(false);
          }
          else
            this.ProgramsOnChange(this.activeReviewProgramDetails[0].programId);
          this.programStatus = 'true';
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
      this.programstatusMap.set(detail.programId, true);
    });
  }
  UpdateProgramDocumentDetail(programId: string) { //Update document details
    var IsEvaluated = true;
    this.fileUpload.GetProgramDocumentDetails(programId, this.assessmentId, IsEvaluated)
      .subscribe(async (result: any) => {
        this.programDocumentDetails = result.data;
        this.EsignStatus[result.data.programDocumentId] = result.data.isProgramDocumentEsigned;
      },
        (err) => {
          console.log(StringConstants.toast.error, err);
        }, () => {
        })
  }
  getProgramDetail(programId: string) { // To get program details
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
  private getDismissReason(reason: any): string { // To close modal
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  getDocumentLoadedObservable() { // To get loaed document
    return this.documentLoaded$.asObservable();
  }
}
export interface ActiveProgramsResponse {
  programId: string;
  programName: string;
  benefits: string;
}
export interface ProgramDocument {
  programId: string;
  programDocumentId: string;
  documentName: string;
  documentDescription: string;
  documentId: string;
  isProgramDocumentEsigned: boolean;
}
export interface ProgramsUpdateDto {
  patientId: number;
  assessmentId: number;
  programId: number;
  isActive: boolean;
}

