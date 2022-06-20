import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { FileUpload } from 'src/app/services/fileupload.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DatePipe } from '@angular/common';
import DateValidation from 'src/app/components/controls/date-validation-control';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
import { CommonService } from 'src/app/services/common.service';
@Component({
  selector: 'app-dashboard-personal',
  templateUrl: './dashboard-personal.component.html',
  styleUrls: ['./dashboard-personal.component.css']
})
export class DashboardPersonalComponent implements OnInit {
  today = new Date();
  basicInfoForm: any;
  homeAddressForm: any;
  workAddressForm: any;
  basicInfoFlag: boolean = true;
  homeAddressFlag: boolean = false;
  workAddressFlag: boolean = false;
  addressID: any;
  activeTab: number = 0;
  pattern = { X: { pattern: new RegExp('\\d'), symbol: '*' }, '0': { pattern: new RegExp('[0-9]') } };
  supportedImageType: any = ['image/png', 'image/jpeg'];
  firstName: any;
  middleName: any;
  lastName: any;
  suffix: any;
  maiden: any;
  dob: any;
  cellno: any;
  countyCode: any;
  ssn: any;
  reasonNoSSN: any;
  userId: any;
  email: any;
  patientId: any;
  addressType: any;
  streetName: any;
  suite: any;
  country: any;
  city: any;
  state: any;
  stateCode: any;
  pincode: any;
  homeNo: any;
  employer: any;
  gender: string = "";
  town: any;
  maritalStatus: string = "";
  assessmentId: any;
  datas: any;
  entityType: any;
  genderval: any;
  martialStatusVal: any;
  fileToUpload: any;
  profileImageUrl: any;
  userEmail: any;
  isguarantor: string = "false";
  personalcountyCode: any;
  isBasicSaved: any;
  isHomeSaved: any;
  isWorkSaved: any;
  isInfoComplete: any;
  isHomeComplete: any;
  isWorkComplete: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  isPersonalSaved: any;
  isEditAllowed: any;
  assessmentStatus: any;
  fromGuarantor: any;
  showLoader: boolean = false;
  isGuarantorSaved: any;
  showAdvocatePanel: boolean = false;
  currentTheme: any;
  contactTypeId: any;
  bsVal: any;
  dobTextbox: any;
  HomeAddress = StringConstants.profileSetting.HomeAddress;
  workAddress1 = StringConstants.var.workAddress;
  PatientBasicInfo = StringConstants.DashboardPersonal.PatientBasicInfo;
  NameReq = StringConstants.demographics.NameReq;
  NameAlp = StringConstants.demographics.NameAlp;
  NameMax = StringConstants.demographics.NameMax;
  NameChar = StringConstants.demographics.NameChar;
  MidNameAlp = StringConstants.profileSetting.MidNameAlp;
  MidNameMax = StringConstants.profileSetting.MidNameMax;
  LastNamereq = StringConstants.demographics.LastNamereq;
  LastNameAlp = StringConstants.demographics.LastNameAlp;
  LastNameMax = StringConstants.demographics.LastNameMax;
  SuffixMax = StringConstants.DashboardHousehold.SuffixMax;
  MaidenNameAlp = StringConstants.DashboardPersonal.MaidenNameAlp;
  MaidenNameMax = StringConstants.DashboardPersonal.MaidenNameMax;
  DateReq = StringConstants.demographics.DateReq;
  DateFormate = StringConstants.demographics.DateFormate;
  DateFut = StringConstants.demographics.DateFut;
  GenderReq = StringConstants.demographics.GenderReq;
  MartialReq = StringConstants.demographics.MartialReq;
  EmailReq = StringConstants.demographics.EmailReq;
  EmailVal = StringConstants.demographics.EmailVal;
  EmailMax = StringConstants.demographics.EmailMax;
  Cell = StringConstants.var.cell;
  CellNumReq = StringConstants.demographics.CellNumReq;
  CellVal = StringConstants.demographics.CellVal;
  SSN = StringConstants.DashboardHousehold.SSN;
  No = StringConstants.Common.No;
  Yes = StringConstants.Common.Yes;
  SuffixAlp = StringConstants.DashboardHousehold.SuffixAlp;
  ChangeGuarantor = StringConstants.DashboardPersonal.ChangeGuarantor;
  reasons: any;
  maskEnabled: boolean = true;
  phoneCode: any;
  constructor(private datepipe: DatePipe, private dashboardService: DashboardService, private router: Router, private toastService: ToastServiceService,
    private route: ActivatedRoute, private dataSharingService: DataSharingService, private formbuilder: FormBuilder, private dropdownService: DropdownService,
    private fileUpload: FileUpload, private authService: AuthService, public common: CommonService) {
    this.dataSharingService.changeTheme.subscribe(value => { // Theme setting
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.SavePersonalHome.subscribe(value => { //To get home save details
      switch (value) {
        case 'true': this.isHomeSaved = true; break;
        case 'false': this.isHomeSaved = false;
      }
      this.isHomeComplete = this.isHomeSaved;
    });
    this.dataSharingService.SavePersonalWork.subscribe(value => { //To save personal  details
      switch (value) {
        case 'true': this.isWorkSaved = true; break;
        case 'false': this.isWorkSaved = false;
      }
      this.isWorkComplete = this.isWorkSaved;
    });
    this.dataSharingService.SavePersonalInfo.subscribe(value => { //Save personal details
      switch (value) {
        case 'true': this.isBasicSaved = true; break;
        case 'false': this.isBasicSaved = false;
      }
      this.isInfoComplete = this.isBasicSaved;
    });
    this.dataSharingService.alterPaddingForVA.subscribe(value => { //Virtual assistance
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.MoveToPWork.subscribe(value => { //Move to personal work address
      this.fromGuarantor = value;
    });
    this.dataSharingService.editable.subscribe(value => {//Assessment status
      this.isEditAllowed = value;
    });
  }
  @Input() set currentTabUpdate(value: boolean) {
    if (value != undefined) {
      this.getDashboardPersonalBasicInfo();
      if (this.fromGuarantor == true) {
        this.nextButtonClickedEvent(true);
        this.dataSharingService.MoveToPWork.next(false);
      }
      else {
        this.basicInfoFlag = true;
        this.homeAddressFlag = false;
        this.workAddressFlag = false;
        this.getGenderValues();
        this.getMartialValues();
        this.getReasonNoSSN();
        this.getPhoneCode();
        this.viewProfileImage();
        this.getTabStatus();
        this.dataSharingService.showPersonalTab.next("1");
      }
      document.getElementById('firstName')?.focus();
    }
  }
  ngOnInit(): void {
    this.initForm();
    this.patientId = sessionStorage.getItem('patientId');
    this.assessmentId = sessionStorage.getItem('assessmentId');
    this.userEmail = sessionStorage.getItem('userEmail');
    this.getDashboardPersonalBasicInfo();
    this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
  }
  checkG() //Check guarantor
  {
    if (this.basicInfoForm.get('isguarantor').value == 'true') {
      this.basicInfoForm.controls['isguarantor'].setValue('false');
    }
    else if (this.basicInfoForm.get('isguarantor').value == 'false') {
      this.basicInfoForm.controls['isguarantor'].setValue('true');
    }
  }
  handleFileInput(event: any) { // To handle image
    if (event.target.files.length > 0) {
      var filetype: string = event.target.files[0].type;
      if (this.supportedImageType.includes(filetype)) {
        this.uploadAssessmentProfileImage(this.assessmentId, event.target.files[0]);
      }
      else {
        this.toastService.showWarning(StringConstants.toast.fileFormat, StringConstants.toast.empty);
      }
      event.target.value = '';
    }
  }
  uploadAssessmentProfileImage(AssessmentId: string, file: File) { // To upload image
    this.fileUpload.uploadImage(AssessmentId, file)
      .subscribe(async event => {
        if (event.type == HttpEventType.UploadProgress) {
        } else if (event instanceof HttpResponse) {
        }
      },
        (err) => {
          console.log(StringConstants.toast.uploadError, err);
        }, () => {
          this.viewProfileImage();
        }
      )
    this.toastService.showSuccess(StringConstants.toast.profileImgUpdated, StringConstants.toast.empty);
  }
  QuickAssessmentResultTab() {//Go to quick assessment tab
    this.dataSharingService.showQuickAssessmentResultsTab.next("0");
  }
  viewProfileImage() { // View profile image
    this.fileUpload.GetAssessmentProfileImage(this.assessmentId)
      .subscribe(async (result: any) => {
        this.profileImageUrl = result;
        this.dataSharingService.LoadProfileImage.next(this.profileImageUrl);
      },
        (err) => {
          console.log(StringConstants.toast.fetchError, err);
        }, () => {
        }
      )
  }
  async getReasonNoSSN() { //To get reasonNoSSN values
    this.reasons = await this.common.getReasonNoSSN();
  }
  async getGenderValues() { //To get gender values
    this.genderval = await this.common.getGenderValues();
  }
  async getMartialValues() {//To get martial status option values
    this.martialStatusVal = await this.common.getMartialValues();
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  private initForm() {
    this.basicInfoForm = new FormGroup({
      'firstName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'middleName': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'lastName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'suffix': new FormControl('', [Validators.pattern('^[a-zA-Z., ]*$'), Validators.maxLength(50)]),
      'email': new FormControl('', [Validators.required, Validators.pattern('^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'), Validators.maxLength(100)]),
      'cellno': new FormControl('', [Validators.required, Validators.minLength(10)]),
      'ssn': new FormControl(''),
      'gender': new FormControl('', Validators.required),
      'maiden': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(15)]),
      'dob': new FormControl('', [Validators.required, DateValidation.validateDateFormat, DateValidation.futureDateValidation]),
      'maritalStatus': new FormControl('', Validators.required),
      'isguarantor': new FormControl('', [Validators.required]),
      'countyCode': new FormControl('', [Validators.required]),
      'reasonNoSSN': new FormControl(''),
    });
  }
  space(e: any) {
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
  ssnChange(event: any) { // SSN change event
    this.basicInfoForm.get('ssn').setValidators([Validators.required]);
    this.basicInfoForm.get('ssn').updateValueAndValidity();
    this.basicInfoForm.get('reasonNoSSN').clearValidators();
    this.basicInfoForm.get('reasonNoSSN').updateValueAndValidity();
    this.reasonNoSSN = null;
  }
  noSSNChange() {// SSN change event
    this.basicInfoForm.get('reasonNoSSN').setValidators([Validators.required]);
    this.basicInfoForm.get('reasonNoSSN').updateValueAndValidity();
    this.basicInfoForm.get('ssn').clearValidators();
    this.basicInfoForm.get('ssn').updateValueAndValidity();
    this.ssn = null;
  }
  focusIn() {
    this.maskEnabled = false;
  }
  focusOut() {
    this.maskEnabled = true;
  }
  // Date-picker JS starts here!
  selectDate(event: any) { //Select DOB date
    if (event != undefined && event != "" && event != null) {
      var newVal = this.datepipe.transform(event, 'MM/dd/yyyy');
      var oldVal = this.basicInfoForm.get('dob').value;
      if (newVal !== oldVal && oldVal != undefined) {
        this.basicInfoForm.controls['dob'].setValue(newVal);
        this.basicInfoForm.markAsDirty();
      }
    }
  }
  closeCalendar() { //Close calendar
    DateValidation.closeCal();
    this.captureDateInDatepicker();
  }
  captureDateInDatepicker() { //To capture date
    if (this.basicInfoForm.controls.dob.errors == null) {
      var bsValueDOB = this.basicInfoForm.get('dob').value;
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
    } else {
      this.bsVal = "";
    }
  }
  checkpattern() { //Chaeck date pattern
    var result = false;
    var dateCheck;
    this.dobTextbox = document.getElementById('dob');
    var bsValueDOB = this.basicInfoForm.get('dob').value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
        dateCheck = this.datepipe.transform(bsValueDOB, 'MM/dd/yyyy');
        result = DateValidation.validateFutureDate(dateCheck != null ? dateCheck : "");
      }
    }
    if (!result) {
      this.basicInfoForm.patchValue({
        dob: ""
      });
      this.dobTextbox.focus();
      this.basicInfoForm.controls['dob'].setErrors({ pattern: true });
    } else {
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
      this.basicInfoForm.controls['dob'].setValue(dateCheck);
    }
  }
  keyPress(event: KeyboardEvent) {
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  } // Date-picker JS ends here!
  basicInfo() { // Navigate to personal tab
    this.basicInfoFlag = true;
    this.homeAddressFlag = false;
    this.workAddressFlag = false;
    this.getDashboardPersonalBasicInfo();
    this.getTabStatus();
  }
  homeAddress() { //Navigate to personal home address tab
    this.basicInfoFlag = false;
    this.workAddressFlag = false;
    this.addressType = "HomeAddress";
    this.contactTypeId = 2;
    this.getDashboardAddressInfo(this.contactTypeId);
  }
  workAddress() { //Navigate to personal work address tab
    this.basicInfoFlag = false;
    this.homeAddressFlag = false;
    this.addressType = "WorkAddress";
    this.contactTypeId = 3;
    this.getDashboardAddressInfo(this.contactTypeId);
  }
  nextButtonClickedEvent(message: boolean): void {
    this.workAddress();
  }
  backToPersonalHomeEvent(message: boolean): void {
    this.homeAddress();
  }
  backToPersonalEvent(message: boolean): void { // Back to persoanl
    this.basicInfoFlag = true;
    this.homeAddressFlag = false;
    this.workAddressFlag = false;
    this.getDashboardPersonalBasicInfo();
  }
  getDashboardPersonalBasicInfo() { // To get persoanl info
    this.showLoader = true;
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const basicRequest: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.getDashboardPersonalBasicInfo(basicRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        sessionStorage.setItem('emailConfirmation', result.data.emailConfirmed);
        sessionStorage.setItem('cellConfirmation', result.data.cellNumberConfirmed);
        sessionStorage.setItem('emailtoken', result.data.emailVerificationToken);
        sessionStorage.setItem('patientEmail', result.data.emailAddress);
        sessionStorage.setItem('patientCellNumber', result.data.cellNumber);
        sessionStorage.setItem('patientCountyCode', result.data.countyCode);
        sessionStorage.setItem('isGuarantor', result.data.areYouGuarantor);
        this.firstName = result.data.firstName;
        this.middleName = result.data.middleName;
        this.lastName = result.data.lastName;
        this.suffix = result.data.suffix;
        this.maiden = result.data.maidenName;
        this.dob = result.data.dateOfBirth;
        this.bsVal = new Date(this.dob);
        this.cellno = result.data.cellNumber;
        this.countyCode = result.data.countyCode;
        this.ssn = result.data.ssnNumberUnMasked;
        this.reasonNoSSN = result.data.reasonNoSsn;;
        this.userId = result.data.userId;
        this.email = result.data.emailAddress;
        this.gender = result.data.gender;
        this.maritalStatus = result.data.maritalStatus;
        this.isguarantor = (result.data.areYouGuarantor).toString();
        this.dataSharingService.isGuarantorData.next(this.isguarantor);
        if (this.ssn == null) {
          this.basicInfoForm.get('reasonNoSSN').setValidators([Validators.required]);
          this.basicInfoForm.get('reasonNoSSN').updateValueAndValidity();
          this.basicInfoForm.get('ssn').clearValidators();
          this.basicInfoForm.get('ssn').updateValueAndValidity();
        }
        else {
          this.basicInfoForm.get('ssn').setValidators([Validators.required]);
          this.basicInfoForm.get('ssn').updateValueAndValidity();
          this.basicInfoForm.get('reasonNoSSN').clearValidators();
          this.basicInfoForm.get('reasonNoSSN').updateValueAndValidity();
        }
      }
    }, (error) => {
      console.log(error);
    });
  }
  getDashboardAddressInfo(contactTypeId: any) { //Get dashboared personal address
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const addressData: any = {
      contactTypeId: contactTypeId,
      assessmentId: assessmentId,
    };
    this.dashboardService.getDashboardPersonalAddressInfo(addressData).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        if (contactTypeId === 2) {
          this.homeAddressFlag = true;
        }
        else if (contactTypeId === 3) {
          this.workAddressFlag = true;
        }
        if (result.data !== null) {
          sessionStorage.setItem('addressID', result.data.id);
          this.employer = result.data.name;
          this.streetName = result.data.streetAddress;
          this.city = result.data.city;
          this.country = result.data.county;
          this.homeNo = result.data.cell;
          this.state = result.data.state;
          this.stateCode = result.data.stateCode;
          this.suite = result.data.suite;
          this.pincode = result.data.zip;
          this.entityType = StringConstants.var.patient;
          this.datas = StringConstants.var.dataAvailable;
          this.town = result.data.county;
          this.addressID = result.data.id;
          this.isguarantor = this.isguarantor;
          this.personalcountyCode = result.data.countyCode;
        }
        else {
          this.datas = "";
          this.employer = "";
          this.streetName = "";
          this.city = "";
          this.country = "";
          this.homeNo = "";
          this.state = "";
          this.stateCode = "";
          this.suite = "";
          this.entityType = StringConstants.var.patient;
          this.pincode = "";
          this.town = '';
          this.addressID = "";
          this.isguarantor = this.isguarantor;
          this.personalcountyCode = "1";
        }
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
        if (result.data.isPersonalInfoComplete == true)
          this.dataSharingService.SavePersonal.next('true');
        if (result.data.isPersonalBasicInfoComplete == true)
          this.dataSharingService.SavePersonalInfo.next('true');
        if (result.data.isPersonalHomeComplete == true)
          this.dataSharingService.SavePersonalHome.next('true');
        if (result.data.isPersonalWorkComplete == true)
          this.dataSharingService.SavePersonalWork.next('true');
        this.isGuarantorSaved = result.data.isGuarantorInfoComplete;
        this.isBasicSaved = result.data.isPersonalBasicInfoComplete;
        this.isHomeSaved = result.data.isPersonalHomeComplete;
        this.isWorkSaved = result.data.isPersonalWorkComplete;
        if (result.data.isHouseholdComplete == true) {
          this.dataSharingService.SaveHousehold.next('true');
        }
        else if (result.data.isHouseholdComplete == false) {
          this.dataSharingService.SaveHousehold.next('false');
        }
        else
          this.dataSharingService.SaveHousehold.next('');
        if (this.isguarantor == "true") {
          this.dataSharingService.isGuarantorData.next("true");
          if (this.isGuarantorSaved == true)
            this.dataSharingService.SaveGuarantor.next("true");
        }
        else {
          this.dataSharingService.isGuarantorData.next("false");
          if (this.isGuarantorSaved == null) {
            this.dataSharingService.SaveGuarantor.next("");
          }
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  basicInfoNext(basicInfo: any) { //Save Persoanl Details
    if (this.basicInfoForm.dirty) {
      if (!this.basicInfoForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharingService.SavePersonalInfo.next("false");
        this.dataSharingService.SavePersonal.next("false");
      }
      else {
        var assessmentId: number = +(this.assessmentId);
        var patientID: number = +(this.patientId);
        if (basicInfo.dob.length == 10) {
          var a = basicInfo.dob;
          var b = "/";
          var position = 2;
          var secondPosition = 4;
          this.dob = [a.slice(0, position), a.slice(4, secondPosition), a.slice(position)].join('');
        }
        else {
          this.dob = basicInfo.dob.toLocaleDateString("en-US", {
            year: "numeric",
            day: "2-digit",
            month: "2-digit",
          });
        }
        var ssnData = (basicInfo.ssn == "") ? null : basicInfo.ssn;
        this.isguarantor = basicInfo.isguarantor;
        let guarantorFlag = (/true/i).test(basicInfo.isguarantor)
        const personalData: any = {
          id: patientID,
          firstName: basicInfo.firstName,
          lastName: basicInfo.lastName,
          middleName: basicInfo.middleName,
          suffix: basicInfo.suffix,
          maidenName: basicInfo.maiden,
          gender: basicInfo.gender,
          maritalStatus: basicInfo.maritalStatus,
          emailAddress: (basicInfo.email).toLowerCase(),
          dateOfBirth: this.dob,
          cell: basicInfo.cellno,
          isGuarantor: guarantorFlag,
          assessmentId: assessmentId,
          countyCode: this.countyCode,
          ssn: ssnData,
          reasonNoSsn: basicInfo.reasonNoSSN,
        }
        this.dashboardService.updateDashboardPersonalBasicInfo(personalData).subscribe(async (result: any) => {
          if (result.wasSuccessful) {
            this.basicInfoForm.markAsPristine();
            if (this.userEmail == basicInfo.email) {
              var age = this.calculateAge(this.dob);
              sessionStorage.setItem('age', age.toString());
              sessionStorage.setItem('gender', this.gender);
              this.dataSharingService.changeFullName.next(this.firstName + " " + this.lastName);
              this.dataSharingService.showUserNameInHeader.next(true);
              sessionStorage.setItem('userFirstName', this.firstName);
              this.dataSharingService.changeFirstName.next(this.firstName);
              sessionStorage.setItem('assessmentPatientFullName', this.firstName + " " + this.lastName);
            }
            else {
              var age = this.calculateAge(this.dob);
              sessionStorage.setItem('age', age.toString());
              sessionStorage.setItem('gender', this.gender);
              this.dataSharingService.changeFullName.next(this.firstName + " " + this.lastName);
              sessionStorage.setItem('assessmentPatientFullName', this.firstName + " " + this.lastName);
            }
            sessionStorage.setItem('patientEmail', (basicInfo.email).toLowerCase());
            this.basicInfoFlag = false;
            this.dataSharingService.updatepersonalAdvocateUpdateSummary.next(true);
            let contactTypeId = 2;
            this.getDashboardAddressInfo(contactTypeId);
            this.dataSharingService.SavePersonalInfo.next('true');
            this.getTabStatus();
          }
        }, (error) => {
          console.log(error)
        });
      }
    }
    else {
      if (!this.basicInfoForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharingService.SavePersonalInfo.next("false");
        this.dataSharingService.SavePersonal.next("false");
      }
      else {
        this.basicInfoFlag = false;
        let contactTypeId = 2;
        this.getDashboardAddressInfo(contactTypeId);
      }
    }
  }
  private calculateAge(dateOfBirth: string): number { //Calculate age
    if (dateOfBirth) {
      var timeDiff = Math.abs(Date.now() - new Date(dateOfBirth).getTime());
      var age = Math.floor(timeDiff / (1000 * 3600 * 24) / 365.25);
      return age;
    }
    return 0;
  }
}
