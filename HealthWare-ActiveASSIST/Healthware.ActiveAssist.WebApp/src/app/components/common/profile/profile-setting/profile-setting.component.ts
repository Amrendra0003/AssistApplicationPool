import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Session } from 'inspector';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { FileUpload } from 'src/app/services/fileupload.service';
import { LoginService } from 'src/app/services/login.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { DatePipe } from '@angular/common';
import DateValidation from 'src/app/components/controls/date-validation-control';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
import { CommonService } from 'src/app/services/common.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { AddressVerificationComponent } from '../../address-verification/address-verification.component';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
@Component({
  selector: 'app-profile-setting',
  templateUrl: './profile-setting.component.html',
  styleUrls: ['./profile-setting.component.css']
})
export class ProfileSettingComponent implements OnInit {
  profileSettingForm: any;
  today = new Date();
  logoutFlag: boolean = false;
  changePasswordFlag: boolean = false;
  profileSettingsFlag: boolean = false;
  changePasswordForm: any;
  email: any = "";
  fieldType: string = StringConstants.var.typePassword;
  mustMatch!: boolean;
  firstName: any = "";
  middleName: any = "";
  lastName: any = "";
  gender: any = "";
  dob: any = "";
  contactCellNumber: any = "";
  contactCountyCode: any = "1";
  genderval: any = " ";
  dateOfBirth: any = "";
  countyCode: any = "1";
  cell: any = "";
  streetName: any = "";
  suite: any = "";
  city: any = "";
  state: any = "";
  county: any = "";
  zipcode: any = "";
  homeCountyCode: any = "1";
  homeCellNumber: any = "";
  showAdvocatepanel: boolean = false;
  themeSettings: any;
  assessmentCount: any = "";
  Theme = StringConstants.profileSetting.Theme;
  Light = StringConstants.profileSetting.Light;
  Dark = StringConstants.profileSetting.Dark;
  prifileSettingMsg1 = StringConstants.profileSetting.prifileSettingMsg1;
  prifileSettingMsg2 = StringConstants.profileSetting.prifileSettingMsg2;
  prifileSettingMsg3 = StringConstants.profileSetting.prifileSettingMsg3;
  PSet = StringConstants.header.PSet;
  PersonalInfo = StringConstants.profileSetting.PersonalInfo;
  NameReq = StringConstants.demographics.NameReq;
  NameAlp = StringConstants.demographics.NameAlp;
  NameMax = StringConstants.demographics.NameMax;
  NameChar = StringConstants.demographics.NameChar;
  MidNameReq = StringConstants.profileSetting.MidNameReq;
  MidNameAlp = StringConstants.profileSetting.MidNameAlp;
  MidNameMax = StringConstants.profileSetting.MidNameMax;
  LastNamereq = StringConstants.demographics.LastNamereq;
  LastNameAlp = StringConstants.demographics.LastNameAlp;
  LastNameMax = StringConstants.demographics.LastNameMax;
  DateReq = StringConstants.demographics.DateReq;
  DateFormate = StringConstants.demographics.DateFormate;
  DateFut = StringConstants.demographics.DateFut;
  Gender = StringConstants.demographics.Gender;
  GenderReq = StringConstants.demographics.GenderReq;
  ContactDetails = StringConstants.profileSetting.ContactDetails;
  Emailreq = StringConstants.login.Emailreq;
  EmailVal = StringConstants.login.EmailVal;
  EmailMax = StringConstants.demographics.EmailMax;
  Cell = StringConstants.profileSetting.Cell;
  CellNumReq = StringConstants.demographics.CellNumReq;
  CellVal = StringConstants.demographics.CellVal;
  HomeAddress = StringConstants.profileSetting.HomeAddress;
  MailingAddress = StringConstants.profileSetting.MailingAddress;
  StreetAddressReg = StringConstants.profileSetting.StreetAddressReg;
  StreetAddressMax = StringConstants.profileSetting.StreetAddressMax;
  SuiteReq = StringConstants.profileSetting.SuiteReq;
  SuiteMax = StringConstants.profileSetting.SuiteMax;
  ZipReq = StringConstants.demographics.ZipReq;
  ZipVal = StringConstants.demographics.ZipVal;
  ZipNum = StringConstants.demographics.ZipNum;
  ZipMin = StringConstants.demographics.ZipMin;
  ZipMax = StringConstants.demographics.ZipMax;
  CountyAlp = StringConstants.profileSetting.CountyAlp;
  CountyMax = StringConstants.profileSetting.CountyMax;
  CityReq = StringConstants.demographics.CityReq;
  CityAlp = StringConstants.demographics.CityAlp;
  CityMax = StringConstants.demographics.CityMax;
  StateAlp = StringConstants.profileSetting.StateAlp;
  StateReq = StringConstants.demographics.StateReq;
  home = StringConstants.common.home;
  Phone = StringConstants.Common.Phone;
  ValidHomeNum = StringConstants.profileSetting.ValidHomeNum;
  Dynamic = StringConstants.profileSetting.Dynamic;
  Update = StringConstants.ChangePassword.Update;
  @Output() nextChangeButtonClicked: EventEmitter<boolean> = new EventEmitter<boolean>(false);
  currentTheme: any;
  bsVal: any;
  stateCode: any;
  dobTextbox: any;
  dynamic: any = 'true';
  dobErrorMessage: any;
  result: any;
  phoneCode: any;
  constructor(public modalService: BsModalService, private modalRef: BsModalRef, private dashboardService: DashboardService, private datepipe: DatePipe, private dataSharingService: DataSharingService, private loginService: LoginService, private router: Router, private toastService: ToastServiceService, private formbuilder: FormBuilder,
    private activatedRoute: ActivatedRoute, private quickAssessmentService: QuickAssessmentService, private dropdownService: DropdownService, private fileUpload: FileUpload, private authService: AuthService, private common: CommonService) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit(): void {
    this.initForm();
    this.themeSettings = sessionStorage.getItem("theme");
    if (this.themeSettings == null) {
      this.themeSettings = "false";
      sessionStorage.setItem("themeSettings", "root");
      this.dataSharingService.changeTheme.next("root");
      sessionStorage.setItem("theme", this.themeSettings);
    }
    else if (this.themeSettings == "true") {
      this.themeSettings = "true";
      this.dataSharingService.changeTheme.next("dark-mode");
      sessionStorage.setItem("themeSettings", "dark-mode");
      sessionStorage.setItem("theme", this.themeSettings);
    }
    else if (this.themeSettings == "false") {
      this.themeSettings = "false";
      this.dataSharingService.changeTheme.next("root");
      sessionStorage.setItem("themeSettings", "root");
      sessionStorage.setItem("theme", this.themeSettings);
    }
    this.getGenderValues();
    this.getProfileDetails();
    this.getPhoneCode();
    this.showAdvocatepanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
  }
  async getGenderValues() { //To get gender values
    this.genderval = await this.common.getGenderValues();
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  private initForm() {
    this.profileSettingForm = new FormGroup({
      'themeSettings': new FormControl(''),
      'firstName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'middleName': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'lastName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(1), Validators.maxLength(50)]),
      'gender': new FormControl('', Validators.required),
      'dob': new FormControl('', [Validators.required, DateValidation.validateDateFormat, DateValidation.futureDateValidation]),
      'contactCellNumber': new FormControl('', [Validators.required, Validators.minLength(10)]),
      'email': new FormControl(''), // Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.com$')]),
      'contactCountyCode': new FormControl('1', [Validators.required]),
      'suite': new FormControl('', [Validators.maxLength(250)]),
      'county': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'city': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'state': new FormControl('', [Validators.required]),
      'zipcode': new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$'), Validators.minLength(5), Validators.maxLength(50)]),
      'homeCellNumber': new FormControl('', [Validators.minLength(10)]),
      'streetName': new FormControl('', [Validators.required, Validators.maxLength(250)]),
      'homeCountyCode': new FormControl(''),
      'dynamic': new FormControl('true')
    });
  }
  // Date-picker JS starts here!
  selectDate(event: any) {
    if (event != undefined && event != "" && event != null) {
      var newVal = this.datepipe.transform(event, 'MM/dd/yyyy');
      this.profileSettingForm.controls['dob'].setValue(newVal);
      this.checkpattern();
    }
  }
  keyPress(event: KeyboardEvent) {
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  }
  closeCalendar() {
    DateValidation.closeCal();
    this.captureDateInDatepicker();
  }
  captureDateInDatepicker() {
    if (this.profileSettingForm.controls.dob.errors == null) {
      var bsValueDOB = this.profileSettingForm.get('dob').value;
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
    } else {
      this.bsVal = "";
    }
  }
  checkpattern() {
    var result = false;
    var futureValidation = false;
    var dateCheck;
    this.dobTextbox = document.getElementById('dob');
    var bsValueDOB = this.profileSettingForm.get('dob').value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
        dateCheck = this.datepipe.transform(bsValueDOB, 'MM/dd/yyyy');
        if (DateValidation.validateFutureDate(dateCheck != null ? dateCheck : "")) {
          result = true;
        } else {
          result = false;
          futureValidation = true;
        }
      }
    }
    if (!result) {
      this.profileSettingForm.patchValue({
        dob: ""
      });
      this.dobTextbox.focus();
      this.bsVal = "";
      this.dobErrorMessage = futureValidation ? "Date of Birth can not be in future." : "Date must be in mm/dd/yyyy format."
      this.profileSettingForm.controls['dob'].setErrors({ pattern: true });
    } else {
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
      this.profileSettingForm.controls['dob'].setValue(dateCheck);
    }
  }
  // Date-picker JS ends here!
  changeTheme(event: any) {
    let theme = event;
    sessionStorage.removeItem("themeSettings");
    sessionStorage.removeItem("theme");
    try {
      sessionStorage.setItem("theme", theme);
      switch (theme) {
        case "true":
          this.dataSharingService.changeTheme.next("dark-mode");
          sessionStorage.setItem("themeSettings", "dark-mode");
          break;
        case "false":
          this.dataSharingService.changeTheme.next("root");
          sessionStorage.setItem("themeSettings", "root");
          break;
        default:
          break;
      }
    } catch (error) {
      console.log(StringConstants.toast.themeChange);
    }
  }
  async getStateAndCity() {
    const val = this.profileSettingForm.get('zipcode').value;
    if (val.length >= 5) {
      this.result = await this.common.getStateAndCity(val);
      if (this.result.wasSuccessful == true) {
        if (this.result.data != null) {
          this.city = this.result.data.city;
          this.state = this.result.data.stateCode;
          this.stateCode = this.result.data.stateCode;
          this.profileSettingForm.controls['zipcode'].setErrors(null);
        }
        else {
          this.city = "";
          this.state = "";
          this.profileSettingForm.controls['zipcode'].setErrors({ 'invalid': true });
        }
      }
      else if (this.result.wasSuccessful == false) {
      }
    }
    else {
      this.city = "";
      this.state = "";
    }
  }
  getProfileDetails() {
    var userId: number = +(sessionStorage.getItem('userId')!);
    this.quickAssessmentService.getProfileDetails(userId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.firstName = result.data.firstName;
        this.lastName = result.data.lastName;
        this.middleName = result.data.middleName;
        this.dob = result.data.dateOfBirth;
        this.bsVal = new Date(this.dob);
        this.gender = result.data.gender;
        this.email = result.data.email;
        this.contactCountyCode = result.data.countyCode;
        this.contactCellNumber = result.data.cell;
        this.streetName = result.data.streetAddress;
        this.suite = result.data.suite;
        this.city = result.data.city;
        this.state = result.data.state;
        this.county = result.data.county;
        this.zipcode = result.data.zipCode;
        this.homeCountyCode = result.data.mailingAddressCountyCode;
        this.homeCellNumber = result.data.mailingAddressCell;
        this.assessmentCount = result.data.assessmentCount;
        this.dynamic = result.data.isDynamic;
      }
    }, (error) => {
      console.log(error)
    });
  }
  updateProfile(){
    this.dataSharingService.changeFullName.next(this.firstName + " " + this.lastName);
    this.dataSharingService.showUserNameInHeader.next(true);
    sessionStorage.setItem('userFirstName', this.firstName);
    this.dataSharingService.changeFirstName.next(this.firstName);
    sessionStorage.setItem('assessmentPatientFullName', this.firstName + " " + this.lastName);
    this.toastService.showSuccess(StringConstants.toast.updateProfile, StringConstants.toast.empty);
  }
  saveProfileSettingsDetails(profileSettings: any) {
    var assessmentId: number = +(sessionStorage.getItem('assessmentId')!);
    var userId: number = +(sessionStorage.getItem('userId')!);
    if (!this.profileSettingForm.valid) {
      this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
    }
    else {
      const profileRequest: any = {
        userId: userId,
        firstName: profileSettings.firstName,
        lastName: profileSettings.lastName,
        middleName: profileSettings.middleName,
        dateOfBirth: profileSettings.dob,
        gender: profileSettings.gender,
        email: profileSettings.email,
        countyCode: profileSettings.contactCountyCode,
        cell: profileSettings.contactCellNumber,
        streetAddress: profileSettings.streetName,
        suite: profileSettings.suite,
        city: profileSettings.city,
        state: profileSettings.state,
        stateCode: this.stateCode,
        county: profileSettings.county,
        zipCode: profileSettings.zipcode,
        mailingAddressCountyCode: profileSettings.homeCountyCode,
        mailingAddressCell: profileSettings.homeCellNumber,
        isDynamic: 'true',
      }
      this.dashboardService.verifyAddressDetails(profileRequest.streetAddress,profileRequest.suite,profileRequest.city,profileRequest.state,profileRequest.zipCode).subscribe(async (result: any) =>{
        if(result.data == null){
          this.toastService.showWarning(StringConstants.toast.MissCommunicationWithAddressApi, StringConstants.toast.empty);
        }
        else{
          const addressSuggested = result.data.cassResult;
          if(addressSuggested.status.type == 0){ 
            if(profileRequest.suite == null){
              profileRequest.suite = '';
            }
            if(profileRequest.county == null){
              profileRequest.county = '';
            }
          if(addressSuggested.address1.toLowerCase() == profileRequest.streetAddress.toLowerCase().trim() && addressSuggested.city.toLowerCase() == profileRequest.city.toLowerCase().trim() && addressSuggested.county.toLowerCase() == profileRequest.county.toLowerCase().trim() && addressSuggested.state.toLowerCase() == profileRequest.state.toLowerCase().trim() && addressSuggested.zip.toLowerCase() == profileRequest.zipCode.toLowerCase().trim() && addressSuggested.address2.toLowerCase() == profileRequest.suite.toLowerCase().trim()){
           
            this.quickAssessmentService.updateProfileDetails(profileRequest).subscribe(async (result: any) => {
              if (result.wasSuccessful) {
                this.updateProfile();
              }
            }, (error) => {
              console.log(error)
            });
          }
          else{
            const addressData: any = {
              streetAddress: '',
              suite: '',
              city: '',
              state: '',
              zipCode: '',
              county: ''
            }
            addressData.streetAddress = profileRequest.streetAddress;
            addressData.city = profileRequest.city;
            addressData.county = profileRequest.county;
            addressData.state = profileRequest.state;
            addressData.zipCode = profileRequest.zipCode;
            addressData.suite = profileRequest.suite;
            this.modalRef = this.modalService.show(AddressVerificationComponent, {
              initialState: { addressData, addressSuggested  },
              animated: true,
              keyboard: false,
              backdrop : 'static',
              class: 'modal-lg'
            });
            
            this.modalRef.content.action.subscribe((value:any) => {
              
              if(value == "radioActualAddress"){
                this.quickAssessmentService.updateProfileDetails(profileRequest).subscribe(async (result: any) => {
                  if (result.wasSuccessful) {
                    this.updateProfile();
                  }
                }, (error) => {
                  console.log(error)
                });
              }
              else{
                profileRequest.streetAddress = addressSuggested.address1;
                profileRequest.city = addressSuggested.city;
                profileRequest.county = addressSuggested.county;
                profileRequest.state = addressSuggested.state;
                profileRequest.zipCode = addressSuggested.zip;
                profileRequest.suite = addressSuggested.address2;
                this.quickAssessmentService.updateProfileDetails(profileRequest).subscribe(async (result: any) => {
                  if (result.wasSuccessful) {
                    this.updateProfile();
                    this.streetName = addressSuggested.address1;
                    this.suite = addressSuggested.address2;
                    this.city = addressSuggested.city;
                    this.state = addressSuggested.state;
                    this.county = addressSuggested.county;
                    this.zipcode = addressSuggested.zip;
                  }
                }, (error) => {
                  console.log(error)
                });
              }
            })
          }
          }
          else{
            this.toastService.showWarning(StringConstants.toast.AddressNotFound, StringConstants.toast.empty);
          }
        }
  }, (error) => {
    console.log(error)
  });
    }
  }
}
