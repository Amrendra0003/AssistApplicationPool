import { reset } from '@angular-devkit/core/src/terminal';
import { Component, EventEmitter, Input, OnInit, Output, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { GuarantorInfoRequest } from 'src/app/shared/guarantorInfoRequest';
import { DatePipe } from '@angular/common';
import DateValidation from 'src/app/components/controls/date-validation-control';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
import { CommonService } from 'src/app/services/common.service';
@Component({
  selector: 'app-dashboard-guarantor',
  templateUrl: './dashboard-guarantor.component.html',
  styleUrls: ['./dashboard-guarantor.component.css']
})
export class DashboardGuarantorComponent implements OnInit {
  pattern = { X: { pattern: new RegExp('\\d'), symbol: '*' }, '0': { pattern: new RegExp('[0-9]') } };
  guarantorInfoFlag: boolean = true;
  guarantorHomeAddressFlag: boolean = false;
  guarantorWorkAddressFlag: boolean = false;
  guarantorNotFoundFlag: boolean = false;
  guarantorId: any;
  guarantorID: any;
  bsVal: any;
  advocatepanel: any;
  guarantorInfoForm: any;
  relation: string = "";
  firstName: any;
  middleName: any;
  lastName: any;
  suffix: any;
  cellno: any;
  ssn: any;
  sssn: any;
  userId: any;
  email: any;
  patientId: any;
  assessmentId: any;
  data: any;
  addressType: any;
  employer: any;
  city: any;
  streetName: any;
  country: any;
  homeNo: any;
  state: any;
  suite: any;
  pincode: any;
  entityType: any;
  datas: any;
  town: any;
  addressID: any;
  relationval: any;
  submitted: any;
  guarantorCountyCode: any;
  countyCode: string = "1";
  dob: any;
  today = new Date();
  showAdvocatePanel: boolean = false;
  GuarantorSaved: string = "";
  isGuarantorSaved: any;
  isWorkSaved: any;
  isHomeSaved: any;
  isInfoComplete: any;
  isHomeComplete: any;
  isWorkComplete: any;
  isEditAllowed: any;
  assessmentStatus: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  @ViewChild('myform') myForm: any;
  isguarantor: any;
  isGuarantorVal: any;
  guarantorTemp: any;
  val: any;
  fromContact: any;
  showLoader: boolean = false;
  currentTheme: any;
  maskEnabled: boolean = true;
  contactTypeId: any;
  tempDate: any;
  dobTextbox: any;
  relationTitle: any = StringConstants.guarantor.relationTitle;
  guarantor: any = StringConstants.guarantor.guarantor;
  ssnLabel: any = StringConstants.common.ssn;
  cellLabel: any = StringConstants.common.cell;
  @Output() backToGuarantorHome: EventEmitter<boolean> = new EventEmitter<boolean>();
  disableSelf: boolean = false;
  reasons: any;
  reasonNoSSN: any;
  phoneCode:any;
  constructor(private datepipe: DatePipe, private dashboardService: DashboardService, private router: Router, private dropdownService: DropdownService,
    private toastService: ToastServiceService, private formbuilder: FormBuilder, private dataSharingService: DataSharingService, private authService: AuthService, private common: CommonService) {
    this.dataSharingService.changeTheme.subscribe(value => { // To Change theme
      this.currentTheme = value;
    });
    this.dataSharingService.SaveGuarantorInfo.subscribe(value => { // To get saved
      switch (value) {
        case 'true': this.isGuarantorSaved = true; break;
        case 'false': this.isGuarantorSaved = false;
      }
      this.isInfoComplete = this.isGuarantorSaved;
    });
    this.dataSharingService.SaveGuarantorHome.subscribe(value => { // To save gurantor home details
      switch (value) {
        case 'true': this.isHomeSaved = true; break;
        case 'false': this.isHomeSaved = false;
      }
      this.isHomeComplete = this.isHomeSaved;
    });
    this.dataSharingService.SaveGuarantorWork.subscribe(value => { // To save guarantor work address
      switch (value) {
        case 'true': this.isWorkSaved = true; break;
        case 'false': this.isWorkSaved = false;
      }
      this.isWorkComplete = this.isWorkSaved;
    });
    this.dataSharingService.alterPaddingForVA.subscribe(value => { // To adjust virtual assist panel padding
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.MoveToGWork.subscribe(value => { //Move to guarantor work address
      this.fromContact = value;
    });
    this.dataSharingService.isGuarantorData.subscribe(value => { //To get guarantor data
      this.isGuarantorVal = value;
      if (this.fromContact == true)
        this.guarantorTemp = value;
      if (this.guarantorTemp == "true" || this.guarantorTemp == "false") {
        this.getGuarntorInfo();
        this.guarantorTemp = "";
      }
    });
    this.dataSharingService.editable.subscribe(value => { // To get assessment status 
      this.isEditAllowed = value;
    })
  }
  @Input() set currentTabUpdate(value: boolean) { // To get current tab details
    if (value != undefined) {
      this.dataSharingService.showGuarantorTab.next("2");
      this.guarantorInfo();
      this.getRelationValues();
      this.getReasonNoSSN();
      this.getPhoneCode();
      if (this.fromContact == true) {
        this.dataSharingService.MoveToGWork.next(false);
        this.nextButtonClickedEvent(true);
      }
      else {
        this.guarantorInfoFlag = true;
        this.guarantorHomeAddressFlag = false;
        this.guarantorWorkAddressFlag = false;
        this.guarantorNotFoundFlag = false;
        this.getTabStatus();
        this.dataSharingService.showGuarantorTab.next("2");
        this.myForm.submitted = false;
      }
      document.getElementById('relation')?.focus();
    }
  }
  async getRelationValues() { // To get relatives options
    this.relationval = await this.common.getRelationValues();
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  ngOnInit(): void {
    this.initForm();
    this.assessmentId = sessionStorage.getItem('assessmentId');
    this.patientId = sessionStorage.getItem('patientId');
    this.guarantorCountyCode = sessionStorage.getItem('isGuarantor');
    this.getGuarntorInfo();
    this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
  }
  private initForm() {
    this.guarantorInfoForm = new FormGroup({
      'firstName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50), Validators.minLength(2)]),
      'middleName': new FormControl('', [Validators.maxLength(50), Validators.pattern('^[a-zA-Z ]*$')]),
      'lastName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'suffix': new FormControl('', [Validators.pattern('^[a-zA-Z., ]*$'), Validators.maxLength(50)]),
      'email': new FormControl('', [Validators.required, Validators.pattern('^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'), Validators.maxLength(100)]),
      'cellno': new FormControl('', [Validators.required, Validators.minLength(10)]),
      'ssn': new FormControl(''),
      'relation': new FormControl('', [Validators.required]),
      'sssn': new FormControl(''),
      'countyCode': new FormControl(''),
      'id': new FormControl(''),
      'dob': new FormControl('', [Validators.required, DateValidation.validateDateFormat, DateValidation.futureDateValidation]),
      'reasonNoSSN': new FormControl(''),
      'NoSSN': new FormControl(''),
    });
  }
  space(e: any) { // To prevent space
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
  async getReasonNoSSN() { //To get reasonNoSSN values
    this.reasons = await this.common.getReasonNoSSN();
  }
  keyPress(event: KeyboardEvent) { // To get key event
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  }
  // Date-picker JS starts here!
  selectDate(event: any) {
    
    if (event != undefined && event != "" && event != null) {
      var newVal = this.datepipe.transform(event, 'MM/dd/yyyy');
      var oldVal = this.guarantorInfoForm.get('dob').value;
      if (newVal !== oldVal) {
        this.guarantorInfoForm.controls['dob'].setValue(newVal);
        this.guarantorInfoForm.markAsDirty();
      }
    }
  }
  closeCalendar() { // to close calendar
    DateValidation.closeCal();
    this.captureDateInDatepicker();
  }
  captureDateInDatepicker() { // To get Date from date of birth
    if (this.guarantorInfoForm.controls.dob.errors == null) {
      var bsValueDOB = this.guarantorInfoForm.get('dob').value;
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
    } else {
      this.bsVal = "";
    }
  }
  checkpattern() { // To check dob date
    var result = false;
    var dateCheck;
    this.dobTextbox = document.getElementById('dob');
    var bsValueDOB = this.guarantorInfoForm.get('dob').value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
        dateCheck = this.datepipe.transform(bsValueDOB, 'MM/dd/yyyy');
        result = DateValidation.validateFutureDate(dateCheck != null ? dateCheck : "");
      }
    }
    if (!result) {
      this.guarantorInfoForm.patchValue({
        dob: ""
      });
      this.dobTextbox.focus();
      this.guarantorInfoForm.controls['dob'].setErrors({ pattern: true });
    } else {
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
      this.guarantorInfoForm.controls['dob'].setValue(dateCheck);
    }
  }
  // Date-picker JS ends here!
  PersonalTab() { // To move personal tab
    this.dataSharingService.MoveToPWork.next(true);
    this.dataSharingService.showPersonalTab.next("1");
  }
  getRelationValuesForSelf() { // To get self details based on self selects
    this.dropdownService.GetRelationship().subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.relationval = result.data;
        for (let data in this.relationval) {
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  guarantorInfo() { // To get guarantor tab
    this.guarantorInfoFlag = true;
    this.guarantorHomeAddressFlag = false;
    this.guarantorWorkAddressFlag = false;
    this.getGuarntorInfo();
    this.guarantorNotFoundFlag = false;
    let isguarantor = (/true/i).test(sessionStorage.getItem('isGuarantor')!);
    this.guarantorInfoForm.markAsPristine();
  }
  guarantorHomeAddress() { // To get home address tab
    sessionStorage.setItem('relation', this.relation);
    if (this.guarantorId == undefined) {
      this.guarantorInfoFlag = false;
      this.guarantorNotFoundFlag = true;
      this.guarantorHomeAddressFlag = true;
      this.guarantorWorkAddressFlag = false;
    }
    else if (this.guarantorId == "") {
      this.guarantorInfoFlag = false;
      this.guarantorNotFoundFlag = true;
      this.guarantorHomeAddressFlag = true;
      this.guarantorWorkAddressFlag = false;
    }
    else {
      this.guarantorInfoFlag = false;
      this.guarantorWorkAddressFlag = false;
      this.guarantorNotFoundFlag = false;
      this.contactTypeId = 5;
      this.getDashboardAddressInfo(this.contactTypeId);
    }
  }
  guarantorWorkAddress() { //To get work address tab
    sessionStorage.setItem('relation', this.relation);
    if (this.guarantorId == undefined) {
      this.guarantorInfoFlag = false;
      this.guarantorNotFoundFlag = true;
      this.guarantorHomeAddressFlag = false;
      this.guarantorWorkAddressFlag = true;
    }
    else if (this.guarantorId == "") {
      this.guarantorInfoFlag = false;
      this.guarantorNotFoundFlag = true;
      this.guarantorHomeAddressFlag = false;
      this.guarantorWorkAddressFlag = true;
    }
    else {
      this.guarantorInfoFlag = false;
      this.guarantorHomeAddressFlag = false;
      this.guarantorNotFoundFlag = false;
      this.contactTypeId = 6;
      this.getDashboardAddressInfo(this.contactTypeId);
    }
  }
  nextButtonClickedEvent(message: boolean): void { //Click on next button 
    this.guarantorWorkAddress();
  }
  backToGuarantorHomeEvent(message: boolean): void { // Back to home address
    this.guarantorHomeAddress();
  }
  backToGuarantorEvent(message: boolean): void { // Back to guarantor tab
    this.guarantorInfo();
  }
  onChange($event: any) { // Onchange event 
    this.relation = this.guarantorInfoForm.get("relation").value;
    this.myForm.submitted = false;
  }
  relationChange() { // Based on relationship option select
    if (this.relation == 'Self') {
      this.GetPersonalInfo();
      this.disableSelf = true;
      this.guarantorInfoForm.get('ssn').clearValidators();
      this.guarantorInfoForm.get('ssn').updateValueAndValidity();
      this.guarantorInfoForm.get('reasonNoSSN').clearValidators();
      this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
    }
    else {
      
      this.disableSelf = false;
      this.guarantorInfoForm.get('reasonNoSSN').setValidators([Validators.required]);
      this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
      this.guarantorInfoForm.get('ssn').clearValidators();
      this.guarantorInfoForm.get('ssn').updateValueAndValidity();
      this.countyCode = "1";
      this.bsVal = "";
    }
  }
  GetPersonalInfo() { // To get personal details
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const basicRequest: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.getDashboardPersonalBasicInfo(basicRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.firstName = result.data.firstName;
        this.middleName = result.data.middleName;
        this.lastName = result.data.lastName;
        this.suffix = result.data.suffix;
        this.cellno = result.data.cellNumber;
        this.sssn = result.data.ssnNumber;
        this.ssn = result.data.ssnNumber;
        this.reasonNoSSN = result.data.reasonNoSsn;
        this.userId = result.data.userId;
        this.email = result.data.emailAddress;
        this.countyCode = result.data.countyCode;
        this.dob = result.data.dateOfBirth;
        this.bsVal = new Date(result.data.dateOfBirth);
      }
    }, (error) => {
      console.log(error)
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
        if (result.data.isGuarantorInfoComplete == true)
          this.dataSharingService.SaveGuarantor.next('true');
        if (result.data.isGuarantorBasicInfoComplete)
          this.dataSharingService.SaveGuarantorInfo.next('true');
        if (result.data.isGuarantorHomeComplete)
          this.dataSharingService.SaveGuarantorHome.next('true');
        if (result.data.isGuarantorWorkComplete)
          this.dataSharingService.SaveGuarantorWork.next('true');
        if (result.data.isHouseholdComplete == true) {
          this.dataSharingService.SaveHousehold.next('true');
        }
        else if (result.data.isHouseholdComplete == false) {
          this.dataSharingService.SaveHousehold.next('false');
        }
        else
          this.dataSharingService.SaveHousehold.next('');
        this.isGuarantorSaved = result.data.isGuarantorBasicInfoComplete;
        this.isHomeSaved = result.data.isGuarantorHomeComplete;
        this.isWorkSaved = result.data.isGuarantorWorkComplete;
      }
    }, (error) => {
      console.log(error)
    });
  }
  getGuarntorInfo() { // To get guarantor details
    this.showLoader = true;
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const basicRequest: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.getGuarantorBasicInfo(assessmentId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        this.data = result.data;
        if (result.data !== null) {
          this.relation = result.data.relationShipWithPatient;
          sessionStorage.setItem('relation', this.relation);
          this.guarantorId = result.data.id;
          this.firstName = result.data.firstName;
          this.middleName = result.data.middleName;
          this.lastName = result.data.lastName;
          this.suffix = result.data.suffix;
          this.cellno = result.data.cell;
          this.ssn = result.data.ssnNumber;
          this.sssn = result.data.ssnNumber;
          this.userId = result.data.userId;
          this.email = result.data.emailAddress;
          this.countyCode = result.data.countyCode;
          this.dob = result.data.dateOfBirth;
          this.bsVal = (this.dob == null || this.dob == "") ? '' : new Date(this.dob);
          this.reasonNoSSN = result.data.reasonNoSsn;
          sessionStorage.setItem('guarantorId', result.data.id);
          this.relation = result.data.relationShipWithPatient;
          sessionStorage.setItem('relation', this.relation);
          if (this.relation == StringConstants.var.self) {
            this.guarantorInfoForm.get('firstName').disable();
            this.guarantorInfoForm.get('middleName').disable();
            this.guarantorInfoForm.get('lastName').disable();
            this.guarantorInfoForm.get('suffix').disable();
            this.guarantorInfoForm.get('cellno').disable();
            this.guarantorInfoForm.get('ssn').disable();
            this.guarantorInfoForm.get('sssn').disable();
            this.guarantorInfoForm.get('countyCode').disable();
            this.guarantorInfoForm.get('relation').disable();
            this.guarantorInfoForm.get('email').disable();
            this.guarantorInfoForm.get('dob').disable();
            this.getRelationValuesForSelf();
            this.guarantorInfoForm.get('ssn').clearValidators();
            this.guarantorInfoForm.get('ssn').updateValueAndValidity();
            this.guarantorInfoForm.get('reasonNoSSN').clearValidators();
            this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
            this.disableSelf = true;
          }
          else {
            this.guarantorInfoForm.enable();
            this.disableSelf = false;
            if (this.ssn != null) {
              this.guarantorInfoForm.get('ssn').setValidators([Validators.required]);
              this.guarantorInfoForm.get('ssn').updateValueAndValidity();
              this.guarantorInfoForm.get('reasonNoSSN').clearValidators();
              this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
            }
            else if (this.ssn == null) {
              this.guarantorInfoForm.get('reasonNoSSN').setValidators([Validators.required]);
              this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
              this.guarantorInfoForm.get('ssn').clearValidators();
              this.guarantorInfoForm.get('ssn').updateValueAndValidity();
            }
          }
        }
        else {
          this.disableSelf = false;
          this.guarantorInfoForm.enable();
          this.guarantorId = "";
          this.firstName = "";
          this.middleName = "";
          this.lastName = "";
          this.suffix = "";
          this.cellno = "";
          this.ssn = null;
          this.userId = "";
          this.email = "";
          this.relation = "";
          this.dob = "";
          this.bsVal = "";
          this.countyCode = "1";
          this.reasonNoSSN = null;
          this.guarantorInfoForm.get('reasonNoSSN').setValidators([Validators.required]);
          this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
          this.guarantorInfoForm.get('ssn').clearValidators();
          this.guarantorInfoForm.get('ssn').updateValueAndValidity();
        }
      }
    }, (error) => {
      console.log(error)
    });
    this.guarantorInfoForm.markAsPristine();
    this.getTabStatus();
  }
  ssnChange(event: any) { // To Change ssn dropdown
    this.guarantorInfoForm.get('ssn').setValidators([Validators.required]);
    this.guarantorInfoForm.get('ssn').updateValueAndValidity();
    this.guarantorInfoForm.get('reasonNoSSN').clearValidators();
    this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
    this.reasonNoSSN = null;
  }
  noSSNChange() { // Reason for No SSN
    this.guarantorInfoForm.get('reasonNoSSN').setValidators([Validators.required]);
    this.guarantorInfoForm.get('reasonNoSSN').updateValueAndValidity();
    this.guarantorInfoForm.get('ssn').clearValidators();
    this.guarantorInfoForm.get('ssn').updateValueAndValidity();
    this.ssn = null;
  }
  focusIn() {
    this.maskEnabled = false;
  }
  focusOut() {
    this.maskEnabled = true;
  }
  GoToHomeAddress() {
    this.guarantorHomeAddress();
  }
  workAddressNext() {
    this.dataSharingService.showHouseholdTab.next("3");
  }
  goToBasicInfo() {
    this.guarantorInfo();
  }
  homeAddressNext() {
    this.guarantorWorkAddress();
  }
  updateGuarantor(guarantorInfo: any) { // Update guarantor details
    if (this.guarantorInfoForm.dirty) {
      if (!this.guarantorInfoForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharingService.SaveGuarantorInfo.next("false");
        this.dataSharingService.SaveGuarantor.next("false");
      }
      else {
        var assessmentId: number = +(this.assessmentId);
        if (this.data == null) {
          this.guarantorID = 0;
        }
        else if (this.data == " ") {
          this.guarantorID = 0;
        }
        else {
          this.guarantorID = this.guarantorId;
        }
        if (this.relation == 'Self') {
          var tempssn = guarantorInfo.sssn;
        }
        else {
          var tempssn = guarantorInfo.ssn
        }
        guarantorInfo.dob = new Date(guarantorInfo.dob);
        var dob = guarantorInfo.dob.toLocaleDateString("en-US", {
          year: "numeric",
          day: "2-digit",
          month: "2-digit",
        });
        const guarantorData: GuarantorInfoRequest = {
          assessmentId: assessmentId,
          basicInfoId: +(this.patientId),
          guarantorId: this.guarantorID,
          relationshipWithPatient: this.relation,
          firstName: this.firstName,
          lastName: this.lastName,
          middleName: this.middleName,
          suffix: this.suffix,
          dateOfBirth: this.dob,
          emailAddress: this.email.toString(),
          cell: this.cellno,
          ssnNumber: tempssn,
          sssnNumber: tempssn,
          countyCode: this.countyCode,
          reasonNoSsn: this.reasonNoSSN,
        };
        if (this.data === null || undefined || '') {
          this.dashboardService.addGuarantorBasicInfo(guarantorData).subscribe(async (result: any) => {
            if (result.wasSuccessful) {
              this.guarantorInfoForm.markAsPristine();
              this.firstName = result.data.firstName;
              this.middleName = result.data.middleName;
              this.lastName = result.data.lastName;
              this.suffix = result.data.firstName;
              this.cellno = result.data.cellNumber;
              this.ssn = result.data.ssnNumber;
              this.userId = result.data.userId;
              this.email = result.data.emailAddress;
              this.dob = result.data.dateOfBirth;
              this.bsVal = (this.dob == null || this.dob == "") ? '' : new Date(this.dob);
              this.reasonNoSSN = result.data.reasonNoSsn;
              sessionStorage.setItem('guarantorId', result.data);
              this.guarantorId = result.data;
              this.countyCode = result.data.countyCode;
              this.guarantorInfoFlag = false;
              this.dataSharingService.updateguarantorAdvocateUpdateSummary.next(true);
              this.getDashboardAddressInfo(5);
              this.guarantorHomeAddress();
              this.dataSharingService.SaveGuarantorInfo.next('true');
              this.getTabStatus();
            }
          }, (error) => {
            console.log(error)
          });
        }
        else {
          this.dashboardService.updateGuarantorBasicInfo(guarantorData).subscribe(async (result: any) => {
            if (result.wasSuccessful) {
              this.guarantorInfoForm.markAsPristine();
              this.firstName = result.data.firstName;
              this.middleName = result.data.middleName;
              this.lastName = result.data.lastName;
              this.suffix = result.data.firstName;
              this.cellno = result.data.cellNumber;
              this.ssn = result.data.ssnNumber;
              this.reasonNoSSN = result.data.reasonNoSsn;
              this.userId = result.data.userId;
              this.email = result.data.emailAddress;
              this.dob = result.data.dateOfBirth;
              this.bsVal = new Date(this.dob);
              this.guarantorInfoFlag = false;
              this.dataSharingService.updateguarantorAdvocateUpdateSummary.next(true);
              this.dataSharingService.SaveGuarantorInfo.next('true');
              this.countyCode = result.data.countyCode;
              this.getDashboardAddressInfo(5);
              this.guarantorHomeAddress();
              this.getTabStatus();
            }
          }, (error) => {
            console.log(error)
          });
        }
      }
    }
    else {
      if (!this.guarantorInfoForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharingService.SaveGuarantorInfo.next("false");
        this.dataSharingService.SaveGuarantor.next("false");
      }
      else {
        this.getDashboardAddressInfo(5);
      }
    }
  }
  getDashboardAddressInfo(contactTypeId: any) { // To get dashboard Address details
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const addressData: any = {
      contactTypeId: contactTypeId,
      assessmentId: assessmentId,
    };
    this.dashboardService.getDashboardPersonalAddressInfo(addressData).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        if (contactTypeId === 5) {
          this.guarantorHomeAddressFlag = true;
          this.guarantorInfoFlag = false;
          this.guarantorWorkAddressFlag = false;
        }
        else {
          this.guarantorHomeAddressFlag = false;
          this.guarantorInfoFlag = false;
          this.guarantorWorkAddressFlag = true;
        }
        if (result.data !== null) {
          sessionStorage.setItem('guarantorAddressID', result.data.id);
          this.employer = result.data.name;
          this.streetName = result.data.streetAddress;
          this.city = result.data.city;
          this.country = result.data.county;
          this.homeNo = result.data.cell;
          this.state = result.data.state;
          this.suite = result.data.suite;
          this.pincode = result.data.zip;
          this.entityType = StringConstants.var.guarantor,
            this.datas = StringConstants.var.dataAvailable;
          this.town = result.data.county;
          this.dob = result.data.dateOfBirth;
          this.bsVal = (this.dob == null || this.dob == "") ? '' : new Date(this.dob);
          this.addressID = result.data.id;
          this.isguarantor = sessionStorage.getItem('isGuarantor');
          this.guarantorCountyCode = result.data.countyCode;
        }
        else {
          this.datas = "";
          this.employer = "";
          this.streetName = "";
          this.city = "";
          this.country = "";
          this.homeNo = "";
          this.state = "";
          this.suite = "";
          this.entityType = StringConstants.var.guarantor,
            this.pincode = "";
          this.town = "";
          this.addressID = "";
          this.dob = "";
          this.bsVal = null;
          this.isguarantor = sessionStorage.getItem('isGuarantor');
          this.guarantorCountyCode = "1";
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
}
