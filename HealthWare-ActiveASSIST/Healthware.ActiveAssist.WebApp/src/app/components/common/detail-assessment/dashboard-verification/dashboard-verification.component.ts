import { Component, Input, OnInit, SimpleChanges, ViewChildren } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { DashboardVerificationValidation } from './dashboard-verification.validations';
import { CommonService } from 'src/app/services/common.service';
@Component({
  selector: 'app-dashboard-verification',
  templateUrl: './dashboard-verification.component.html',
  styleUrls: ['./dashboard-verification.component.css']
})
export class DashboardVerificationComponent implements OnInit {
  formInput = ['input1', 'input2', 'input3', 'input4'];
  @ViewChildren('formRow') rows: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  verificationType: any;
  emailVerificationFlag: boolean = true;
  cellVerificationFlag: boolean = false;
  otpVerificationFlag: boolean = false;
  idVerificationFlag: boolean = false;
  addressVerificationFlag: boolean = false;
  incomeVerificationFlag: boolean = false;
  othersFlag: boolean = false;
  addressVerificationForm: any;
  idVerificationForm: any;
  cellVerificationForm: any;
  incomeVerificationForm: any;
  IncomeForm: any;
  modeForm: any;
  otpForm: any;
  otherDocForm: any;
  cellVerifiedFlag: boolean = false;
  otherverificationType: string = "";
  addressverificationType: string = "";
  idverificationType: string = "";
  emailConfirmation: any;
  cellConfirmation: any;
  idUploaded: any;
  otherUploaded: any;
  addressUpdloaded: any;
  incomeUpdloaded: any;
  emailtoken: any;
  patientEmail: any;
  email: string = "";
  countryCode: any;
  cellNumber: any;
  mode: string = "";
  emailConfirmationFlag: boolean = false;
  emailConfirmationTemp: string = "";
  cellConfirmationFlag: boolean = false;
  idProofUploadedFlag: boolean = false;
  otherProofUploadedFlag: boolean = false;
  addressProofUploadedFlag: boolean = false;
  incomeProofUploadedFlag: boolean = false;
  idVerificationFilename: string = "";
  otherVerificationFilename: string = "";
  addressVerificationFilename: string = "";
  incomeVerificationFilename: string = ""
  idVerificationDocumentId: string = "";
  otherVerificationDocumentId: string = "";
  addressVerificationDocumentId: string = "";
  householdMemberId: string = "";
  incomeDocumentType: string = "";
  verificationdocumentdetail: any;
  incomeVerificationDocumentDetail: any;
  resendVerificationFlag: boolean = false;
  token: any = sessionStorage.getItem("token");
  patientId: any;
  memberval: any;
  suite: any;
  streetName: any;
  city: any;
  county: any;
  state: any;
  zipcode: any;
  countyCode: any;
  showadddocumentsform: boolean = false;
  isCellConfirmed: boolean = false;
  isEmailConfirmed: boolean = false;
  supportedFileType: any = ['image/png', 'image/jpeg', 'application/msword', 'application/pdf', 'application/vnd.openxmlformats-officedocument.wordprocessingml.document'];
  isTextClicked: boolean = false;
  isCallClicked: boolean = false;
  deviceValue: any;
  filler: any;
  isVerified: string = "";
  currentDocumentIdForDelete: string = "";
  showAdvocatePanel: boolean = false;
  isEditAllowed: any;
  assessmentStatus: any;
  private _showaddmoredocuments: boolean = true;
  resendClicked: boolean = false;
  timeout: any;
  timeset: any;
  showLoader: boolean = false;
  /*green tick ui*/
  isIncomeDocsUploaded: any;
  isOtherDocsUploaded: any;
  isIdDocsUploaded: any;
  isAddDocsUploaded: any;
  isCellVerify: any;
  isEmailVerify: any;
  /* Validation Check! */
  isVerificationSaved: any;
  isQuickSaved: any;
  isPersonalSaved: any;
  isGuarantorSaved: any;
  isContactSaved: any;
  isApplicationSaved: any;
  isProgramSaved: any;
  isHouseholdSaved: any;
  isPInfoSaved: any;
  isPHomeSaved: any;
  isGInfoSaved: any;
  isGHomeSaved: any;
  notSubmit: boolean = false;
  notConfirm: boolean = false;
  alertSent: boolean = false;
  callVerification: any;
  currentTheme: any;
  currentHouseholdMemberId: any;
  EligibilityExperts = StringConstants.DashboardVerification.EligibilityExperts;
  scheduleAppointment = StringConstants.common.scheduleAppointment;
  CellVerification = StringConstants.DashboardVerification.CellVerification;
  Emailvar = StringConstants.DashboardVerification.Emailvar;
  IDVerification = StringConstants.DashboardVerification.IDVerification;
  AddressVerification = StringConstants.DashboardVerification.AddressVerification;
  IncomeVerification = StringConstants.DashboardVerification.IncomeVerification;
  OtherDocumentation = StringConstants.DashboardVerification.OtherDocumentation;
  YourEmail = StringConstants.activeAccount.YourEmail;
  NotVerified = StringConstants.DashboardVerification.NotVerified;
  Verified = StringConstants.DashboardVerification.Verified;
  EmailCheck = StringConstants.DashboardVerification.EmailCheck;
  PlzReq = StringConstants.DashboardVerification.PlzReq;
  ResendVerificationLink = StringConstants.DashboardVerification.ResendVerificationLink;
  SendVerificationLink = StringConstants.DashboardVerification.SendVerificationLink;
  verifyEmail = StringConstants.toast.verifyEmail;
  ResivePassCodeInfo = StringConstants.DashboardVerification.ResivePassCodeInfo;
  CellNumDuringAssessment = StringConstants.DashboardVerification.CellNumDuringAssessment;
  Cell = StringConstants.profileSetting.Cell;
  CellNumReq = StringConstants.demographics.CellNumReq;
  DeliveryMethod = StringConstants.DashboardVerification.DeliveryMethod;
  Text = StringConstants.var.text;
  Call1 = StringConstants.common.call;
  CodeValid10Min = StringConstants.DashboardVerification.CodeValid10Min;
  ResendCode = StringConstants.Common.ResendCode;
  UploadCertificate = StringConstants.DashboardVerification.UploadCertificate;
  PleaseEnsure = StringConstants.DashboardVerification.PleaseEnsure;
  Documentvalid = StringConstants.DashboardVerification.Documentvalid;
  DocumentvalidInfo = StringConstants.DashboardVerification.DocumentvalidInfo;
  SelectIDType = StringConstants.DashboardVerification.SelectIDType;
  ValidDriverLicense = StringConstants.DashboardVerification.ValidDriverLicense;
  BirthCertificate = StringConstants.DashboardVerification.BirthCertificate;
  StateIssuedIdentificationCard = StringConstants.DashboardVerification.StateIssuedIdentificationCard;
  StudentIdentificationCard = StringConstants.DashboardVerification.StudentIdentificationCard;
  SocialSecurityCard = StringConstants.DashboardVerification.SocialSecurityCard;
  MilitaryIdentificationCard = StringConstants.DashboardVerification.MilitaryIdentificationCard;
  PassportOrPassportCard = StringConstants.DashboardVerification.PassportOrPassportCard;
  IdType = StringConstants.DashboardVerification.IdType;
  UploadDocument = StringConstants.Common.UploadDocument;
  UploadYourBills = StringConstants.DashboardVerification.UploadYourBills;
  HomeAddressAssessment = StringConstants.DashboardVerification.HomeAddressAssessment;
  DocumentlegibleInfo = StringConstants.DashboardVerification.DocumentlegibleInfo;
  SelectDocumentType = StringConstants.DashboardVerification.SelectDocumentType;
  No = StringConstants.Common.No;
  Yes = StringConstants.Common.Yes;
  SelectHouseholdMember = StringConstants.DashboardVerification.SelectHouseholdMember;
  PleaseSelectHouseholdMember = StringConstants.DashboardVerification.PleaseSelectHouseholdMember;
  SelectDocumentType1 = StringConstants.DashboardVerification.SelectDocumentTypet1;
  PanCard = StringConstants.Common.PanCard;
  BankStatement = StringConstants.DashboardVerification.BankStatement;
  SalaryReport = StringConstants.DashboardVerification.SalaryReport;
  Others = StringConstants.Common.Others;
  PleaseSelectDocumentType = StringConstants.DashboardVerification.PleaseSelectDocumentType;
  CompleteIncomeNerification = StringConstants.DashboardVerification.CompleteIncomeNerification;
  UploadImg = StringConstants.DashboardVerification.UploadImg;
  HIPAAPrivacyConsent = StringConstants.DashboardVerification.HIPAAPrivacyConsent;
  ConsentTreat = StringConstants.DashboardVerification.ConsentTreat;
  CompleteStatus: any;
  nameRelation: any = StringConstants.dashboardVerification.nameRelation;
  documentType: any = StringConstants.dashboardVerification.documentType;
  documentName: any = StringConstants.dashboardVerification.documentName;
  title: any = StringConstants.dashboardVerification.title;
  deleteWarning: any = StringConstants.common.deleteWarning;
  moreDocumnets: any = StringConstants.dashboardVerification.moreDocumnets;
  phoneCode: any;
  get showaddmoredocuments(): boolean {
    return this._showaddmoredocuments;
  }
  set showaddmoredocuments(value: boolean) {
    this._showaddmoredocuments = value;
    this.showadddocumentsform = !value;
    this.ClearDropdown();
  }
  private _documentListFlag: boolean = false;
  get documentListFlag(): boolean {
    return this._documentListFlag;
  }
  set documentListFlag(value: boolean) {
    this._documentListFlag = value;
    if (!value) this.showaddmoredocuments = value;
  }
  get assessmentId(): string {
    return sessionStorage.getItem('assessmentId')!;
  }
  constructor(private common: CommonService, private dataSharing: DataSharingService, private validation: DashboardVerificationValidation, private dashboardService: DashboardService,
    private router: Router, private toastService: ToastServiceService, private route: ActivatedRoute, private fileUpload: FileUpload, private formbuilder: FormBuilder,
    private dropdownService: DropdownService, private authService: AuthService) {
    this.dataSharing.alterPaddingForVA.subscribe(value => { //Virtual assist
      this.virtualAssistPadding = value;
    });
    this.dataSharing.ShowVerificationTab.subscribe(value => { // Show verification tab
      this.callVerification = value;
    });
    this.dataSharing.changeTheme.subscribe(value => { //Theme setting
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.fileUpload.idDocumentUploadStatus$.subscribe(value => { //Document status
      if (value) {
        this.showUploadedSuccessToast();
        this.UpdateIdDocumentDetails(this.assessmentId);
      }
      else
        this.showUploadedErrorToast();
    });
    this.fileUpload.otherDocumentUploadStatus$.subscribe(value => { //other document status
      if (value) {
        this.showUploadedSuccessToast();
        this.UpdateOtherDocumentDetails(this.assessmentId);
      }
      else
        this.showUploadedErrorToast();
    });
    this.fileUpload.addressDocumentUploadStatus$.subscribe(value => { // address document status
      if (value) {
        this.showUploadedSuccessToast();
        this.UpdateAddressDocumentDetails(this.assessmentId);
      }
      else
        this.showUploadedErrorToast();
    });
    this.fileUpload.incomeDocumentUploadStatus$.subscribe(value => { //Income document status
      if (value) {
        this.GetIncomeVerificationDocumentDetail(this.assessmentId);
        this.showUploadedSuccessToast();
      }
      else
        this.showUploadedErrorToast();
    });
    this.dataSharing.editable.subscribe(value => { // Assessment status
      this.isEditAllowed = value;
    });
  }
  @Input() set currentTabUpdate(value: boolean) { //Current tab details
    if (value != undefined) {
      this.getTabStatus();
      if (this.showAdvocatePanel == true) {
        this.dataSharing.ShowVerificationTab.next("7");
      }
      else if (this.showAdvocatePanel == false) {
        this.dataSharing.ShowVerificationTab.next("6");
      }
      this.emailVerificationFlag = true;
      this.cellVerificationFlag = false;
      this.idVerificationFlag = false;
      this.addressVerificationFlag = false;
      this.incomeVerificationFlag = false;
      this.otpVerificationFlag = false;
      this.cellVerifiedFlag = false;
      this.othersFlag = false;
      this.UpdateIdDocumentDetails(this.assessmentId);
      this.UpdateOtherDocumentDetails(this.assessmentId);
      this.UpdateAddressDocumentDetails(this.assessmentId);
      this.GetIncomeVerificationDocumentDetail(this.assessmentId);
      this.getDashboardAddressInfo();
      this.getHouseholdMembersNames();
      this.cellVerification();
      this.emailVerification();
      this.getPhoneCode();
    }
  }
  async getPhoneCode(){
    this.phoneCode = await this.common.getPhoneCode();
  }
  showUploadedSuccessToast() { // Toast message
    this.showLoader = false;
    this.getTabStatus();
  }
  showUploadedErrorToast() { //upload document error toast
    this.toastService.showWarning(StringConstants.toast.cannotUpload, StringConstants.toast.empty);
  }
  ApplicationForms() { //Back to application forms
    this.dataSharing.MoveToForms.next(true);
    if (this.showAdvocatePanel == false)
      this.dataSharing.showApplicationFormNext.next("5");
    else if (this.showAdvocatePanel == true)
      this.dataSharing.ShowFormsTab.next("6");
  }
  ClearDropdown() { //Clear dropdown values
    this.incomeDocumentType = "";
    this.householdMemberId = "";
  }
  ngOnInit() {
    this.initForm();
    this.emailConfirmation = sessionStorage.getItem('emailConfirmation');
    this.cellConfirmation = sessionStorage.getItem('cellConfirmation');
    this.idUploaded = sessionStorage.getItem('idUploaded');
    this.addressUpdloaded = sessionStorage.getItem('addressUploaded');
    this.incomeUpdloaded = sessionStorage.getItem('incomeUploaded');
    this.patientId = sessionStorage.getItem('patientId');
    this.emailConfirmationTemp = "";
    this.emailtoken = sessionStorage.getItem('emailtoken');
    this.patientEmail = sessionStorage.getItem('patientEmail');
    this.countyCode = sessionStorage.getItem('patientCountyCode');
    this.cellVerificationForm = this.toFormGroup(this.formInput);
    this.otpForm = this.toFormGroup(this.formInput);
    this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
    if (this.callVerification == "6" || (this.callVerification == "7" && this.showAdvocatePanel == true)) {
      this.emailVerification();
      this.emailVerificationFlag = true;
      this.cellVerificationFlag = false;
      this.idVerificationFlag = false;
      this.addressVerificationFlag = false;
      this.incomeVerificationFlag = false;
      this.otpVerificationFlag = false;
      this.cellVerifiedFlag = false;
      this.othersFlag = false;
      this.UpdateIdDocumentDetails(this.assessmentId);
      this.UpdateOtherDocumentDetails(this.assessmentId);
      this.UpdateAddressDocumentDetails(this.assessmentId);
      this.GetIncomeVerificationDocumentDetail(this.assessmentId);
      this.getDashboardAddressInfo();
      this.getHouseholdMembersNames();
      this.cellVerification();
      this.getTabStatus();
    }
  }
  previewDocument(documentId: string) { // Preview Document
    window.open(this.fileUpload.getDocumentDownloadURL(documentId), "_blank");
  }
  updateDocumentIdForDelete(documentId: string, householdMemberId: any) { // Delete uploaded document
    this.currentDocumentIdForDelete = documentId;
    this.currentHouseholdMemberId = householdMemberId;
  }
  getDashboardAddressInfo() { // Get dashboard address info
    var assessmentId: number = +(this.assessmentId);
    const addressData: any = {
      assessmentId: assessmentId,
      contactTypeId: 2
    };
    this.dashboardService.getDashboardPersonalAddressInfo(addressData).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.suite = result.data.suite;
        this.streetName = result.data.streetAddress;
        this.city = result.data.city;
        this.county = result.data.county;
        this.state = result.data.state;
        this.zipcode = result.data.zip;
      }
    }, (error) => {
      console.log(error)
    });
  }
  getHouseholdMembersNames() { //Get household member names
    this.showLoader = true;
    var assessmentId: number = +(this.assessmentId);
    var patientId: number = +(sessionStorage.getItem('patientId')!);
    const memberRequest: any = {
      patientId: patientId,
      assessmentId: assessmentId
    }
    this.dashboardService.GetHouseHoldMemberNames(memberRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        this.memberval = result.data;
      }
    }, (error) => {
      console.log(error)
    });
  }
  getTabStatus() { //get current tab status
    var assessmentId: number = +(this.assessmentId);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        this.isEmailVerify = result.data.isEmailVerificationComplete;
        this.isCellVerify = result.data.isCellVerificationComplete;
        this.isIdDocsUploaded = result.data.isIdVerificationComplete;
        this.isAddDocsUploaded = result.data.isAddressVerificationComplete;
        this.isIncomeDocsUploaded = result.data.isIncomeVerificationComplete;
        this.isOtherDocsUploaded = result.data.isOtherVerificationComplete;
        this.isQuickSaved = result.data.isQuickAssessmentComplete;
        this.isPInfoSaved = result.data.isPersonalBasicInfoComplete;
        this.isPHomeSaved = result.data.isPersonalHomeComplete;
        this.isGInfoSaved = result.data.isGuarantorBasicInfoComplete;
        this.isGHomeSaved = result.data.isGuarantorHomeComplete;
        this.isPersonalSaved = result.data.isPersonalInfoComplete;
        this.isGuarantorSaved = result.data.isGuarantorInfoComplete;
        this.isContactSaved = result.data.isContactPreferenceComplete;
        this.isHouseholdSaved = result.data.isHouseholdComplete;
        this.isApplicationSaved = result.data.isApplicationFormsComplete;
        this.isProgramSaved = result.data.isProgramsComplete;
        this.isVerificationSaved = result.data.isVerificationComplete;
        if (this.isEmailVerify == true) this.notConfirm = false;
        if (this.isIncomeDocsUploaded == true) this.notSubmit = false;
        if (this.isEmailVerify == true && this.isIncomeDocsUploaded == true) {
          this.dataSharing.SaveVerification.next('true');
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  DeleteIncomeDocument() { //Delete income document
    this.DeleteDocument(this.currentDocumentIdForDelete, this.currentHouseholdMemberId);
    this.getTabStatus();
    setTimeout(() => {
    }, 500)
  }
  ChangeDocumentName() {  //Additional code to retreive uploaded document according to document type
    this.idVerificationFilename = '';
    var AssesssId = sessionStorage.getItem('assessmentId')!;
    this.fileUpload.GetDocumentByAssessmentIdTypeName(AssesssId, this.idverificationType)
      .subscribe(async (result: any) => {
        if (result.errors.length == 0 && result.data != null) {
          this.idverificationType = result.data.documentType;
          this.idVerificationFilename = result.data.documentName;
          this.idVerificationDocumentId = result.data.documentId;
          this.idUploaded = true;
          this.idProofUploadedFlag = true;
        }
      },
        (err) => {
          console.log(StringConstants.toast.errorFetch, err);
        }, () => {
        }
      )
  }
  ChangeAddressDocumentName() {   //Additional code to retreive uploaded document according to document type
    this.addressVerificationFilename = '';
    var AssesssId = sessionStorage.getItem('assessmentId')!;
    this.fileUpload.GetDocumentByAssessmentIdTypeName(AssesssId, this.addressverificationType)
      .subscribe(async (result: any) => {
        if (result.errors.length == 0 && result.data != null) {
          this.addressverificationType = result.data.documentType;
          this.addressVerificationFilename = result.data.documentName;
          this.addressVerificationDocumentId = result.data.documentId;
          this.addressUpdloaded = true;
          this.addressProofUploadedFlag = true;
        }
      },
        (err) => {
          console.log(StringConstants.toast.errorFetch, err);
        }, () => {
        }
      )
  }
  ChangeOtherDocumentName() { //Additional code to retreive uploaded document according to document type
    this.otherVerificationFilename = '';
    var AssesssId = sessionStorage.getItem('assessmentId')!;
    this.fileUpload.GetDocumentByAssessmentIdTypeName(AssesssId, this.otherverificationType)
      .subscribe(async (result: any) => {
        if (result.errors.length == 0 && result.data != null) {
          this.otherverificationType = result.data.documentType;
          this.otherVerificationFilename = result.data.documentName;
          this.otherVerificationDocumentId = result.data.documentId;
          this.otherUploaded = true;
          this.otherProofUploadedFlag = true;
        }
      },
        (err) => {
          console.log(StringConstants.toast.errorFetch, err);
        }, () => {
        }
      )
  }
  showincomeVerificationFields() { //Show verification fields
    this.showaddmoredocuments = false;
  }
  async HandleAddressDocument(event: any) { // To handle address document
    if (event.target.files.length > 0) {
      var filetype: string = event.target.files[0].type;
      if (this.validation.ValidateDocumentForm(this.supportedFileType.includes(filetype))) {
        await this.fileUpload.UploadVerificationDocument(this.assessmentId, this.addressverificationType, StringConstants.var.Address, event.target.files[0]);
        this.showLoader = true;
        this.addressVerificationFilename = event.target.files[0].name;
      }
      else this.toastService.showWarning(StringConstants.toast.fileType, StringConstants.toast.fileSupport);
    }
    event.target.value = '';
  }
  async HandleIdDocument(event: any) { // Handle document
    if (event.target.files.length > 0) {
      var filetype: string = event.target.files[0].type;
      if (this.validation.ValidateDocumentForm(this.supportedFileType.includes(filetype))) {
        await this.fileUpload.UploadVerificationDocument(this.assessmentId, this.idverificationType, StringConstants.var.Identification, event.target.files[0]);
        this.showLoader = true;
        this.idVerificationFilename = event.target.files[0].name;
      }
      else this.toastService.showWarning(StringConstants.toast.fileType, StringConstants.toast.fileSupport);
    }
    event.target.value = '';
  }
  async HandleOtherDocument(event: any) { //Handle other document
    if (event.target.files.length > 0) {
      var filetype: string = event.target.files[0].type;
      if (this.validation.ValidateDocumentForm(this.supportedFileType.includes(filetype))) {
        await this.fileUpload.UploadVerificationDocument(this.assessmentId, this.otherverificationType, StringConstants.var.Other, event.target.files[0]);
        this.showLoader = true;
        this.otherVerificationFilename = event.target.files[0].name;
      }
      else this.toastService.showWarning(StringConstants.toast.fileType, StringConstants.toast.fileSupport);
    }
    event.target.value = '';
  }
  async HandleIncomeDocument(event: any) { // To handle income Document
    if (event.target.files.length > 0) {
      var filetype: string = event.target.files[0].type;
      if (this.validation.ValidateIncomeForm(this.supportedFileType.includes(filetype), this.householdMemberId)) {
        await this.fileUpload.UploadIncomeVerificationDocument(this.assessmentId, this.incomeDocumentType, this.householdMemberId, event.target.files[0]);
        this.showLoader = true;
        this.incomeVerificationFilename = event.target.files[0].name;
      }
      else {
        this.toastService.showWarning(StringConstants.toast.fileType, StringConstants.toast.fileSupport);
      }
    }
    event.target.value = '';
  }
  DeleteDocument(DocumentId: string, householdMemberId: any) { //Delete document
    this.fileUpload.DeleteDocument(DocumentId, householdMemberId)
      .subscribe(async (result: any) => {
      },
        (err) => {
          console.log(StringConstants.toast.errordelete, err);
        }, () => {
          this.getTabStatus();
          this.GetIncomeVerificationDocumentDetail(this.assessmentId);
        }
      )
  }
  GetIncomeVerificationDocumentDetail(AssessmentId: string) { //Get income verification document
    this.fileUpload.GetIncomeVerificationDocumentDetail(AssessmentId)
      .subscribe(async (result: any) => {
        if (result.errors.length == 0 && result.data != null) {
          if (result.data.houseHoldMemberDocument.length > 0) {
            this.showaddmoredocuments = true;
            this.incomeVerificationDocumentDetail = result.data.houseHoldMemberDocument;
            this.documentListFlag = true;
            this.incomeUpdloaded = true;
            this.incomeProofUploadedFlag = true;
          }
          else {
            this.documentListFlag = false;
            this.incomeUpdloaded = false;
            this.incomeProofUploadedFlag = false;
          }
        }
        else {
          this.documentListFlag = false;
          this.incomeUpdloaded = false;
          this.incomeProofUploadedFlag = false;
        }
      },
        (err) => {
          console.log(StringConstants.toast.errorFetch, err);
        }, () => {
        }
      )
  }
  UpdateIdDocumentDetails(AssessmentId: string) { // Upload document details
    this.fileUpload.GetIdVerificationDocumentDetail(AssessmentId)
      .subscribe(async (result: any) => {
        if (result.errors.length == 0 && result.data != null) {
          this.idverificationType = result.data.documentType;
          this.idVerificationFilename = result.data.documentName;
          this.idVerificationDocumentId = result.data.documentId;
          this.idUploaded = true;
          this.idProofUploadedFlag = true;
        }
        else {
          this.idverificationType = "";
          this.idVerificationFilename = "";
          this.idUploaded = false;
          this.idProofUploadedFlag = false;
        }
      },
        (err) => {
          console.log(StringConstants.toast.errorFetch, err);
        }, () => {
        }
      )
  }
  UpdateOtherDocumentDetails(AssessmentId: string) { //Update other document details
    this.fileUpload.GetOtherVerificationDocumentDetail(AssessmentId)
      .subscribe(async (result: any) => {
        if (result.errors.length == 0 && result.data != null) {
          this.otherverificationType = result.data.documentType;
          this.otherVerificationFilename = result.data.documentName;
          this.otherVerificationDocumentId = result.data.documentId;
          this.otherUploaded = true;
          this.otherProofUploadedFlag = true;
        }
        else {
          this.otherverificationType = "";
          this.otherVerificationFilename = "";
          this.otherUploaded = false;
          this.otherProofUploadedFlag = false;
        }
      },
        (err) => {
          console.log(StringConstants.toast.errorFetch, err);
        }, () => {
        }
      )
  }
  UpdateAddressDocumentDetails(AssessmentId: string) { // Update address details
    this.fileUpload.GetAddressVerificationDocumentDetail(AssessmentId)
      .subscribe(async (result: any) => {
        if (result.errors.length == 0 && result.data != null) {
          this.addressverificationType = result.data.documentType;
          this.addressVerificationFilename = result.data.documentName;
          this.addressVerificationDocumentId = result.data.documentId;
          this.addressUpdloaded = true;
          this.addressProofUploadedFlag = true;
        }
        else {
          this.addressverificationType = "";
          this.addressVerificationFilename = "";
          this.addressUpdloaded = false;
          this.addressProofUploadedFlag = false;
        }
      },
        (err) => {
          console.log(StringConstants.toast.errorFetch, err);
        }, () => {
        }
      )
  }
  toFormGroup(elements: any[]) { //To group form controls
    const group: any = {};
    elements.forEach(key => {
      group[key] = new FormControl('', Validators.required);
    });
    return new FormGroup(group);
  }
  initForm() {
    this.idVerificationForm = new FormGroup({
      'idverificationType': new FormControl('', [Validators.required]),
    });
    this.addressVerificationForm = new FormGroup({
      'addressverificationType': new FormControl('', [Validators.required]),
    });
    this.modeForm = new FormGroup({
      'mode': new FormControl(''),
    });
    this.IncomeForm = new FormGroup({
      'cellNumber': new FormControl('', [Validators.required]),
      'countyCode': new FormControl(''),
    });
    this.incomeVerificationForm = new FormGroup({
      'householdMember': new FormControl('', [Validators.required]),
      'incomeDocumentType': new FormControl('', [Validators.required]),
    });
    this.otherDocForm = new FormGroup({
      'otherverificationType': new FormControl('', [Validators.required]),
    })
  }
  emailVerification() { // Email verification tab
    window.scroll(0, 0);
    this.patientEmail = sessionStorage.getItem('patientEmail');
    const request: any = {
      PatientId: +(sessionStorage.getItem('patientId')!),
      AssessmentId: +(this.assessmentId)
    };
    this.dashboardService.GetVerificationStatus(request).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        if ((result.data.isEmailConfirmed) == true) {
          this.emailConfirmationFlag = true;
          this.emailConfirmationTemp = "true";
        }
        else if ((result.data.isEmailConfirmed) == false) {
          this.emailConfirmationFlag = false;
          this.emailConfirmationTemp = "false";
        }
        this.getTabStatus();
      }
    }, (error) => {
      console.log(error)
    });
    this.resendVerificationFlag = false;
    this.othersFlag = false;
    this.otpVerificationFlag = false;
    this.incomeVerificationFlag = false;
    this.addressVerificationFlag = false;
    this.idVerificationFlag = false;
    this.emailVerificationFlag = true;
    this.cellVerificationFlag = false;
    this.isTextClicked = false;
    this.isCallClicked = false;
    this.otpForm.reset();
  }
  cellVerification() { // Cell verification tab
    window.scroll(0, 0);
    this.resendClicked = false;
    clearTimeout(this.timeout);
    clearTimeout(this.timeset);
    this.getTabStatus();
    this.modeForm.reset();
    this.emailVerification();
    this.isTextClicked = false;
    this.isCallClicked = false;
    this.cellVerificationFlag = true;
    this.addressVerificationFlag = false;
    this.emailVerificationFlag = false;
    this.incomeVerificationFlag = false;
    this.othersFlag = false;
    this.IncomeForm.disable();
    this.otpVerificationFlag = false;
    this.resendVerificationFlag = false;
    this.idVerificationFlag = false;
    const request: any = {
      PatientId: +(sessionStorage.getItem('patientId')!),
      AssessmentId: +(this.assessmentId)
    };
    this.dashboardService.GetVerificationStatus(request).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.countyCode = result.data.countyCode;
        this.cellNumber = result.data.cellNumber;
        if ((result.data.isCellConfirmed) == true) {
          this.cellVerifiedFlag = true;
          this.cellConfirmation = true;
          this.cellConfirmationFlag = true;
        }
        else if ((result.data.isCellConfirmed) == false) {
          this.cellVerifiedFlag = false;
          this.cellConfirmation = false;
          this.cellConfirmationFlag = false;
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  idVerification() { //Id verification tab
    window.scroll(0, 0);
    this.cellVerification();
    this.otpForm.reset();
    this.isTextClicked = false;
    this.isCallClicked = false;
    this.emailVerificationFlag = false;
    this.cellVerificationFlag = false;
    this.idVerificationFlag = true;
    this.addressVerificationFlag = false;
    this.incomeVerificationFlag = false;
    this.otpVerificationFlag = false;
    this.resendVerificationFlag = false;
    this.cellVerifiedFlag = false;
    this.othersFlag = false;
    this.UpdateIdDocumentDetails(this.assessmentId);
  }
  addressNext() {  // Go to address tab
    if (this.idVerificationForm.get('idverificationType').value != '' && this.idVerificationFilename == '') {
      this.toastService.showWarning(StringConstants.toast.notUpload, StringConstants.toast.empty);
      return;
    }
    if (this.idVerificationForm.get('idverificationType').value != '' && this.idVerificationFilename != '') {
      this.updateVerificationDocument(this.assessmentId, this.idverificationType, "Identification");
    }
    this.addressVerification();
  }
  updateVerificationDocument(assessmentId: any, type: string, category: string) { //Update verification document
    const basicRequest: any = {
      assessmentId: +(assessmentId),
      documentTypeName: type,
      category: category,
    }
    this.fileUpload.UpdateVerificationDocument(basicRequest).subscribe(async (result: any) => {
      this.getTabStatus();
    });
  }
  addressVerification() { // Address verification tab
    window.scroll(0, 70);
    this.otpForm.reset();
    this.isTextClicked = false;
    this.isCallClicked = false;
    this.emailVerificationFlag = false;
    this.cellVerificationFlag = false;
    this.idVerificationFlag = false;
    this.addressVerificationFlag = true;
    this.incomeVerificationFlag = false;
    this.resendVerificationFlag = false;
    this.otpVerificationFlag = false;
    this.cellVerifiedFlag = false;
    this.othersFlag = false;
    this.UpdateAddressDocumentDetails(this.assessmentId);
    this.getDashboardAddressInfo();
  }
  incomeNext() { //Go to income tab
    if (this.addressVerificationForm.get('addressverificationType').value != '' && this.addressVerificationFilename == '') {
      this.toastService.showWarning(StringConstants.toast.notUpload, StringConstants.toast.empty);
      return;
    }
    if (this.addressVerificationForm.get('addressverificationType').value != '' && this.addressVerificationFilename != '') {
      this.updateVerificationDocument(this.assessmentId, this.addressverificationType, "Address");
    }
    this.incomeVerification();
  }
  incomeVerification() { //INcome verification tab
    window.scroll(0, 70);
    this.otpForm.reset();
    this.isTextClicked = false;
    this.isCallClicked = false;
    this.emailVerificationFlag = false;
    this.cellVerificationFlag = false;
    this.idVerificationFlag = false;
    this.addressVerificationFlag = false;
    this.incomeVerificationFlag = true;
    this.otpVerificationFlag = false;
    this.resendVerificationFlag = false;
    this.cellVerifiedFlag = false;
    this.othersFlag = false;
    this.ClearDropdown();
    if (this.documentListFlag) this.showaddmoredocuments = true;
    else this.showaddmoredocuments = false;
  }
  others() { // Others tab
    window.scrollTo(0, 70);
    this.otpForm.reset();
    this.emailVerificationFlag = false;
    this.cellVerificationFlag = false;
    this.idVerificationFlag = false;
    this.addressVerificationFlag = false;
    this.incomeVerificationFlag = false;
    this.otpVerificationFlag = false;
    this.resendVerificationFlag = false;
    this.cellVerifiedFlag = false;
    this.othersFlag = true;
    this.UpdateOtherDocumentDetails(this.assessmentId);
  }
  sendEmailVerification() { // Email verification 
    this.showLoader = true;
    var assessmentId: number = +(this.assessmentId);
    var patientId: number = +(sessionStorage.getItem('patientId')!);
    const emailAddress: any = {
      patientId: patientId,
      assessmentId: assessmentId
    };
    this.dashboardService.EmailVerification(emailAddress).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        this.toastService.showSuccess(StringConstants.toast.emailSent, StringConstants.toast.empty);
        this.resendVerificationFlag = true;
      }
    }, (error) => {
      this.showLoader = false;
    });
  }
  chooseType() { // Select communication mode type
    if (this.modeForm.get('mode').value == StringConstants.var.text) {
      this.isTextClicked = true;
      this.isCallClicked = false;
      this.sendOtpForNumberVerification();
    }
    else if (this.modeForm.get('mode').value == StringConstants.var.call) {
      this.otpVerificationFlag = false;
      this.isCallClicked = true;
      this.isTextClicked = false;
      this.Call();
    }
  }
  setMode(type: string) { // Set communication mode
    if (type == StringConstants.var.text) {
      this.modeForm.controls['mode'].setValue(StringConstants.var.text);
    }
    else {
      this.modeForm.controls['mode'].setValue(StringConstants.var.call);
    }
    this.chooseType();
  }
  Call() { // Call button event
    this.resendClicked = false;
    clearTimeout(this.timeout);
    clearTimeout(this.timeset);
  }
  sendOtpForNumberVerification() { // Send otp verification
    if (!this.resendClicked) {
      this.resendClicked = true;
      clearTimeout(this.timeset);
      this.timeset = setTimeout(() => {
        this.resendClicked = false;
      }, 31000)
      var assessmentId: number = +(this.assessmentId);
      var patientId: number = +(sessionStorage.getItem('patientId')!);
      const otpRequest: any = {
        patientId: patientId,
        cellNumber: this.IncomeForm.value.cellNumber,
        assessmentId: assessmentId
      }
      this.dashboardService.CellVerification(otpRequest).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.otpVerificationFlag = true;
        }
      }, (error) => {
        this.toastService.showError(StringConstants.toast.enterValidOtp, StringConstants.toast.empty);
        console.log(error)
      });
    }
  }
  reSendOtp() {//Resend OTP
    if (!this.resendClicked) {
      this.resendClicked = true;
      clearTimeout(this.timeout);
      this.timeout = setTimeout(() => {
        this.resendClicked = false;
      }, 31000)
      var assessmentId: number = +(this.assessmentId);
      var patientId: number = +(sessionStorage.getItem('patientId')!);
      const otpRequest: any = {
        patientId: patientId,
        cellNumber: this.IncomeForm.value.cellNumber,
        assessmentId: assessmentId
      }
      this.dashboardService.CellVerification(otpRequest).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.otpVerificationFlag = true;
        }
      }, (error) => {
        this.toastService.showError(StringConstants.toast.enterValidOtp, StringConstants.toast.empty);
        console.log(error)
      });
    }
  }
  default(e: any) {
    e.preventDefault();
  }
  keyUpEvent(event: { keyCode: number; which: number; ctrlKey: boolean; key: string }, index: number) {
    let isBackSpaced = false;
    if (event.ctrlKey || event.key == 'Control') {
      this.rows._results[0].nativeElement.focus();
    }
    else {
      let pos = index;
      var test = this.rows._results[pos].nativeElement.value;
      if (event.keyCode === 8 && event.which === 8) {
        isBackSpaced = true;
        if (test == "")
          pos = pos - 1;
      }
      else if (event.keyCode === 46 && event.which === 46) {
        if (test == "")
          pos = pos;
      }
      else {
        pos = index + 1;
      }
      if (pos > -1 && pos < this.formInput.length) {
        this.rows._results[pos].nativeElement.focus();
        if (isBackSpaced) {
          this.rows._results[pos].nativeElement.select();
        }
        else
          this.rows._results[pos].nativeElement.focus();
      }
    }
  }
  ValidateOtpVerification() { // Validate OTP 
    if (this.otpVerificationFlag == false) {
      this.idVerification();
    }
    else {
      if (!this.otpForm.valid) {
        this.toastService.showWarning(StringConstants.toast.enterOtp, StringConstants.toast.empty);
      }
      else {
        var assessmentId: number = +(this.assessmentId);
        var patientId: number = +(sessionStorage.getItem('patientId')!);
        const otpLoginData: any = {
          OTPNumber: this.otpForm.value.input1 + this.otpForm.value.input2 + this.otpForm.value.input3 + this.otpForm.value.input4,
          patientId: patientId,
          assessmentId: assessmentId,
          cellNumber: this.IncomeForm.value.cellNumber,
        };
        this.dashboardService.ValidateCellVerification(otpLoginData).subscribe(async (result: any) => {
          if (result.wasSuccessful) {
            this.cellVerifiedFlag = true;
            this.idVerification();
          }
        }, (error) => {
          this.toastService.showError(StringConstants.toast.enterValidOtp, StringConstants.toast.invalidOtp);
          console.log(error)
        });
      }
    }
  }
  checkType() { // Check all tab status
    if (this.showAdvocatePanel == true) {
      if (this.isQuickSaved == true && this.isPersonalSaved == true && this.isGuarantorSaved == true &&
        this.isContactSaved == true && this.isHouseholdSaved == true && this.isApplicationSaved &&
        this.isVerificationSaved == true && this.isProgramSaved == true) {
        this.CompleteStatus = true;
      }
      else {
        this.CompleteStatus = false;
      }
    }
    else {
      if (this.emailConfirmationTemp == "true" && this.incomeProofUploadedFlag == true && this.isQuickSaved == true && this.isPersonalSaved == true && this.isGuarantorSaved == true &&
        this.isContactSaved == true && this.isHouseholdSaved == true && this.isApplicationSaved &&
        this.isVerificationSaved == true) {
        this.CompleteStatus = true;
      }
      else {
        this.CompleteStatus = false;
      }
    }
  }
  GoToSubmit() { // Submit verification
    if (this.otherDocForm.get('otherverificationType').value != '' && this.otherVerificationFilename == '') {
      this.toastService.showWarning(StringConstants.toast.notUpload, StringConstants.toast.empty);
      return;
    }
    if (this.otherDocForm.get('otherverificationType').value != '' && this.otherVerificationFilename != '') {
      this.updateVerificationDocument(this.assessmentId, this.otherverificationType, "Other");
    }
    this.getTabStatus();
    this.checkType();
    if (this.CompleteStatus == true) {
      this.notConfirm = false;
      this.notSubmit = false;
      var assessmentId: number = +(this.assessmentId);
      var patientId: number = +(sessionStorage.getItem('patientId')!);
      var status = StringConstants.var.documentIncomplete;
      const statusUpdateRequest: any = {
        PatientId: patientId,
        Status: StringConstants.var.documentIncomplete,
        AssessmentId: assessmentId
      }
      this.dashboardService.SubmitApplication(statusUpdateRequest).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          sessionStorage.setItem('isEditable', "false");
          sessionStorage.setItem('statusDisplay', 'Under Review');
          this.dataSharing.changeAssessmentStatus.next(status);
          this.dataSharing.EnableSubmit.next("true");
          this.dataSharing.SaveVerification.next("true");
          if (this.assessmentStatus == StringConstants.var.incomplete) {
            this.toastService.showSuccess(StringConstants.toast.submitAssessment, StringConstants.toast.empty);
          }
          this.dataSharing.editable.next(false);
          if (this.showAdvocatePanel == false) {
            this.dataSharing.showHouseholdTab.next("7");
            sessionStorage.setItem('assessmentStatus', status);
            sessionStorage.setItem('statusDisplay', 'Under Review');
          }
          else if (this.showAdvocatePanel == true) {
            this.router.navigate(['dashboard-advocate']);
          }
        }
      }, (error) => {
        this.toastService.showError(StringConstants.toast.statusUpdateFailed, StringConstants.toast.empty);
        console.log(error)
      });
    }
    else {
      if (!this.isQuickSaved) this.dataSharing.SaveQuickAssessment.next('false');
      if (!this.isPersonalSaved) this.dataSharing.SavePersonal.next('false');
      if (!this.isPInfoSaved) this.dataSharing.SavePersonalInfo.next('false');
      if (!this.isPHomeSaved) this.dataSharing.SavePersonalHome.next('false');
      if (!this.isGuarantorSaved) this.dataSharing.SaveGuarantor.next('false');
      if (!this.isGInfoSaved) this.dataSharing.SaveGuarantorInfo.next('false');
      if (!this.isGHomeSaved) this.dataSharing.SaveGuarantorHome.next('false');
      if (!this.isContactSaved) this.dataSharing.SaveContactPreference.next('false');
      if (!this.isHouseholdSaved) this.dataSharing.SaveHousehold.next('false');
      if (!this.isApplicationSaved) this.dataSharing.SaveApplicationForms.next('false');
      if (!this.isProgramSaved) this.dataSharing.SavePrograms.next('false');
      if (!this.isVerificationSaved) this.dataSharing.SaveVerification.next('false');
      if (this.emailConfirmationTemp == "false" && this.incomeProofUploadedFlag == false) {
        this.alertSent = true;
        this.notSubmit = true;
        this.notConfirm = true;
        this.toastService.showWarning(StringConstants.toast.completeVerify, StringConstants.toast.empty);
        this.dataSharing.SaveVerification.next("false");
      }
      else {
        this.alertSent = false;
        this.notConfirm = false;
        this.notSubmit = false;
      }
      if (this.emailConfirmationTemp == "false" && this.alertSent == false) {
        this.notConfirm = true;
        this.notSubmit = false;
        this.toastService.showWarning(StringConstants.toast.verifyEmail, StringConstants.toast.empty);
        this.dataSharing.SaveVerification.next("false");
      }
      if (this.incomeProofUploadedFlag == false && this.alertSent == false) {
        this.notSubmit = true;
        this.notConfirm = false;
        this.toastService.showWarning(StringConstants.toast.attachDocs, StringConstants.toast.empty);
        this.dataSharing.SaveVerification.next("false");
      }
    }
  }
}
export interface FileDetails {
  AssessmentId: string
  UserId: any
  HouseHoldMemberId: string
  ProgramId: string
  DocumentTitle: string
  DocumentCategory: string
  DocumentType: string
}