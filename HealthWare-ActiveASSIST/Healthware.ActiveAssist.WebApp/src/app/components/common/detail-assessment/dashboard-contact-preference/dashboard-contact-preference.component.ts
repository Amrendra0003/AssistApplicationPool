import { Component, Input, OnInit, SimpleChanges, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
@Component({
  selector: 'app-dashboard-contact-preference',
  templateUrl: './dashboard-contact-preference.component.html',
  styleUrls: ['./dashboard-contact-preference.component.css']
})
export class DashboardContactPreferenceComponent implements OnInit {
  virtualAssistPadding: string = "virtual-assist-padding";
  contactPreferencesForm: any;
  preferredCell: string = "";
  preferredTime: any = "";
  otherCell: any = "";
  preferredEmail: any = "";
  preferredMailAddress: string = "";
  nicKName: any;
  streetName: any;
  suite: any;
  county: any;
  city: any;
  state: any;
  zipcode: any;
  homeNo: any;
  countyCode: any;
  cellno: any;
  cellNumberType: any;
  contactMode: string = "";
  @ViewChild('myform') myForm: any;
  chooseMail: boolean = false;
  chooseCell: boolean = false;
  typeMail: string = "";
  typeCell: string = "";
  preferredCellVal: any;
  preferredAddressVal: any;
  assessmentId: any;
  patientId: any;
  isModeCall: string = StringConstants.var.call;
  isModeMail: string = StringConstants.var.mail;
  isModeEmail: string = StringConstants.var.email;
  isModeText: string = StringConstants.var.text;
  data: any;
  entityID: any;
  entityType: any;
  addressType: any;
  cellType: any;
  addressId: any;
  addressID: any;
  contactPreferencesId: number = 0;
  modeOfContact: string = "";
  CellDetails: CellDetails[] = [];
  AddressDetails: AddressDetails[] = [];
  CellMap = new Map<any, CellDetails>();
  addressMap = new Map<any, AddressDetails>();
  user: any;
  gMail: any;
  isText: boolean = false;
  isCall: boolean = false;
  isMail: boolean = false;
  isEmail: boolean = false;
  addressUniqueId: any;
  cellPlace: string = StringConstants.var.landlineNumber;
  isEditAllowed: boolean = true;
  assessmentStatus: any;
  isContactSaved: any;
  showLoader: any;
  currentTheme: any;
  phoneId: any;
  phoneID: any;
  UniqueId: any;
  preferredEmailDropdownValueList: any;
  preferredMailAddressUniqueId: any;
  preferredMailAddressContactId: any;
  preferredCellUniqueId: any;
  preferredCellContactId: any;
  advocatepanel: any;
  GuarantorData: any;
  title: any = StringConstants.contactPreference.title;
  preferredCellLabel: any = StringConstants.contactPreference.preferredCell;
  callingTime: any = StringConstants.contactPreference.callingTime;
  preferredEmailAddress: any = StringConstants.contactPreference.preferredEmailAddress;
  preferredMailingAddress: any = StringConstants.contactPreference.preferredMailingAddress;
  preferredModeofCommunication: any = StringConstants.contactPreference.preferredModeofCommunication;
  landline: any = StringConstants.common.landline;
  text: any = StringConstants.common.text;
  call: any = StringConstants.common.call;
  email: any = StringConstants.common.email;
  mail: any = StringConstants.common.mail;
  cell: any = StringConstants.common.cell;
  showAdvocatePanel: any;
  Time1 = StringConstants.contactPreference.Time1;
  Time2 = StringConstants.contactPreference.Time2;
  Time3 = StringConstants.contactPreference.Time3;
  Time4 = StringConstants.contactPreference.Time4;
  PreferredNumReq = StringConstants.contactPreference.PreferredNumReq;
  TimeReq = StringConstants.contactPreference.TimeReq;
  NumReq = StringConstants.contactPreference.NumReq;
  NumVal1 = StringConstants.contactPreference.NumVal1;
  NumVal2 = StringConstants.contactPreference.NumVal2;
  Select = StringConstants.Common.Select;
  MailingReq = StringConstants.contactPreference.MailingReq;
  NickNameReq = StringConstants.contactPreference.NickNameReq;
  NickNameAlp = StringConstants.contactPreference.NickNameAlp;
  NickNameMax = StringConstants.contactPreference.NickNameMax;
  NickNameMin = StringConstants.contactPreference.NickNameMin;
  StreetAddressReg = StringConstants.profileSetting.StreetAddressReg;
  StreetAddressMax = StringConstants.profileSetting.StreetAddressMax;
  StreetAddressMinCharacters = StringConstants.contactPreference.StreetAddressMinCharacters;
  SuiteReq = StringConstants.profileSetting.SuiteReq;
  SuiteMax = StringConstants.profileSetting.SuiteMax;
  ZipNum = StringConstants.demographics.ZipNum;
  ZipVal = StringConstants.demographics.ZipVal;
  ZipMin = StringConstants.demographics.ZipMin;
  ZipMax = StringConstants.demographics.ZipMax;
  CountyReq = StringConstants.profileSetting.CountyReq;
  CountyAlp = StringConstants.profileSetting.CountyAlp;
  CountyMax = StringConstants.profileSetting.CountyMax;
  CityReq = StringConstants.demographics.CityReq;
  CityAlp = StringConstants.demographics.CityAlp;
  CityMax = StringConstants.demographics.CityMax;
  StateReq = StringConstants.demographics.StateReq;
  ModeOfCommunication = StringConstants.contactPreference.ModeOfCommunication;
  @ViewChild('myform') CForm: any;
  constructor(private quickAssessmentService: QuickAssessmentService, private Fb: FormBuilder, private dashboardService: DashboardService, private toastService: ToastServiceService,
    private router: Router, private formbuilder: FormBuilder, private dropdownService: DropdownService, private dataSharing: DataSharingService, private authService: AuthService) {
    this.dataSharing.alterPaddingForVA.subscribe(value => { // To show virtual assist panel
      this.virtualAssistPadding = value;
    });
    this.dataSharing.changeTheme.subscribe(value => { // To change theme
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharing.editable.subscribe(value => { // To check assessment is incomplete or under review
      this.isEditAllowed = value;
    });
    this.dataSharing.isGuarantorData.subscribe(value => { // To get guarantor details
      this.GuarantorData = value;
    })
  }
  @Input() set currentTabUpdate(value: boolean) { // To get current tab details
    if (value != undefined) {
      document.getElementById('preferredCell')?.focus();
      this.getPreferredEmail();
      this.dataSharing.showHouseholdTab.next("3");
      this.isText = false;
      this.isCall = false;
      this.isEmail = false;
      this.isMail = false;
      this.cellPlace = StringConstants.var.landlineNumber;
      this.CForm.submitted = false;
      this.falseOtherCellValidation();
      this.getPreferredCell();
      this.getPreferredAddress();
      this.getTabStatus();
    }
  }
  ngOnInit(): void {
    this.assessmentId = sessionStorage.getItem('assessmentId');
    this.patientId = sessionStorage.getItem('patientId');
    this.initForm();
    this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
  }
  private initForm() {
    this.contactPreferencesForm = new FormGroup({
      'preferredCell': new FormControl('', [Validators.required]),
      'preferredTime': new FormControl(''),
      'cellno': new FormControl(''), //[Validators.required, Validators.pattern('^[a-zA-Z ]*$')]
      'otherCell': new FormControl(''),
      'preferredEmail': new FormControl('', [Validators.required]),
      'preferredMailAddress': new FormControl('', [Validators.required]),
      'nicKName': new FormControl(''), // 
      'streetName': new FormControl(''),
      'suite': new FormControl(''),
      'county': new FormControl(''), // [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]
      'city': new FormControl(''), // [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]
      'state': new FormControl(''), // [Validators.required]
      'zipcode': new FormControl(''), // [Validators.required, Validators.pattern('^[0-9]*$'), Validators.minLength(5)]
      'homeNo': new FormControl(''), // [Validators.required, Validators.minLength(10)]),
      'countyCode': new FormControl(''),
      'cellNumberType': new FormControl(''),
      'modeOfContact': new FormControl('', [Validators.required])
    });
  }
  toggle() { // To get mode of contact
    if (this.contactPreferencesForm.get('modeOfContact').value == StringConstants.var.text) {
      this.isText = true;
      this.isCall = false;
      this.isMail = false;
      this.isEmail = false;
    }
    else if (this.contactPreferencesForm.get('modeOfContact').value == StringConstants.var.call) {
      this.isText = false;
      this.isCall = true;
      this.isMail = false;
      this.isEmail = false;
    }
    else if (this.contactPreferencesForm.get('modeOfContact').value == StringConstants.var.email) {
      this.isText = false;
      this.isCall = false;
      this.isMail = false;
      this.isEmail = true;
    }
    else if (this.contactPreferencesForm.get('modeOfContact').value == StringConstants.var.mail) {
      this.isText = false;
      this.isCall = false;
      this.isMail = true;
      this.isEmail = false;
    }
  }
  setMode(type: string) { // To set contact mode
    switch (type) {
      case 'Text': this.contactPreferencesForm.controls['modeOfContact'].setValue('Text'); break;
      case 'Call': this.contactPreferencesForm.controls['modeOfContact'].setValue('Call'); break;
      case 'Email': this.contactPreferencesForm.controls['modeOfContact'].setValue('Email'); break;
      case 'Mail': this.contactPreferencesForm.controls['modeOfContact'].setValue('Mail'); break;
    }
    this.toggle();
  }
  getStateAndCity() { // To get state and city
    const val = this.contactPreferencesForm.get('zipcode').value;
    if (val.length >= 5) {
      this.quickAssessmentService.getStateAndCity(val).subscribe(async (result: any) => {
        if (result.wasSuccessful == true) {
          if (result.data != null) {
            this.city = result.data.city;
            this.state = result.data.state;
            this.county = result.data.county;
            this.contactPreferencesForm.controls['zipcode'].setErrors(null);
          }
          else {
            this.city = "";
            this.state = "";
            this.county = "";
            this.contactPreferencesForm.controls['zipcode'].setErrors({ 'invalid': true });
          }
        }
        else if (result.wasSuccessful == false) {
        }
      }, (error) => {
        console.log(error)
      });
    }
    else {
      this.city = "";
      this.state = "";
      this.county = "";
    }
  }
  getPreferredCell() { // To get preferred cell details
    this.showLoader = true;
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const addressData: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    var CellDetail: CellDetails[] = [];
    this.dropdownService.GetPreferredCell(addressData).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.preferredCellVal = result.data.preferredCellDropdownValueList;
        this.contactPreferencesForm.reset();
        this.GetContactPreference();
      }
    }, (error) => {
      console.log(error)
    });
  }
  getPreferredAddress() { // To get preferred address
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const addressData: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    var AddressDetails: AddressDetails[] = [];
    this.dropdownService.GetPreferredAddress(addressData).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        this.preferredAddressVal = result.data.preferredAddressDropdownValueList;
        this.contactPreferencesForm.reset();
        this.GetContactPreference();
      }
    }, (error) => {
      console.log(error)
    });
  }
  getPreferredEmail() { // To get preferred email
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const addressData: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dropdownService.GetPreferredEmail(addressData).subscribe(async (result: any) => {
      
      if (result.wasSuccessful) {
        this.preferredEmailDropdownValueList = result.data.preferredEmailDropdownValueList;
      }
    }, (error) => {
      console.log(error)
    });
  }
  onCellPlace($event: any) { // To select cell number type
    if (this.contactPreferencesForm.get('cellNumberType').value == StringConstants.var.landline) this.cellPlace = StringConstants.var.landlineNumber;
    else this.cellPlace = StringConstants.var.cellNumber;
  }
  onChangeMailAddress(event: any) { // Onchange mail address
    let preferredMailAddress = event.target.value.split('-');
    this.preferredMailAddressUniqueId = preferredMailAddress[0];
    this.preferredMailAddressContactId = preferredMailAddress[1];
    this.typeMail = this.contactPreferencesForm.get('preferredMailAddress').value;
    if (this.typeMail == 'Other-0') {
      this.chooseMail = true;
      this.preferredMailAddressUniqueId = StringConstants.var.other;
      this.preferredMailAddressContactId = 0;
      this.trueOtherMailValidation();
    }
    else {
      this.chooseMail = false;
      this.contactPreferencesForm.get('nicKName').reset();
      this.contactPreferencesForm.get('streetName').reset();
      this.contactPreferencesForm.get('suite').reset();
      this.contactPreferencesForm.get('city').reset();
      this.contactPreferencesForm.get('county').reset();
      this.contactPreferencesForm.get('state').reset();
      this.contactPreferencesForm.get('zipcode').reset();
      this.falseOtherMailValidation();
    }
    this.addressUniqueId = this.addressMap.get(this.typeMail)?.preferedAddressUniqueId;
    this.addressID = this.addressMap.get(this.typeMail)?.addressId;
  }
  onChangeCell(event: any) { //Onchange cell number
    this.otherCell = this.preferredTime;
    let preferredCell = event.target.value.split('-');
    this.preferredCellUniqueId = preferredCell[0];
    this.preferredCellContactId = preferredCell[1];
    this.typeCell = this.contactPreferencesForm.get('preferredCell').value;
    if (this.typeCell == 'Other-0') {
      this.chooseCell = true;
      this.trueOtherCellValidation();
      this.preferredCellUniqueId = StringConstants.var.other;
      this.preferredCellContactId = 0;
    }
    else {
      this.chooseCell = false;
      this.contactPreferencesForm.get('cellno').reset();
      this.falseOtherCellValidation();
    }
    this.UniqueId = this.CellMap.get(this.typeCell)?.uniqueId;
    this.phoneID = this.CellMap.get(this.typeCell)?.phoneId;
  }
  getTabStatus() { // To get current tab status
    var assessmentId: number = +(this.assessmentId);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        this.isContactSaved = result.data.isContactPreferenceComplete;

        if (result.data.isContactPreferenceComplete) {
          this.dataSharing.SaveContactPreference.next('true');
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  contactPreference(contactDetails: any) { // To save contact preference details
    if (this.contactPreferencesForm.dirty) {
      if (!this.contactPreferencesForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharing.SaveContactPreference.next("false");
      }
      else {
        this.typeCell = this.contactPreferencesForm.get('preferredCell').value;
        let preferredCell = this.typeCell.split('-');
        this.preferredCellUniqueId = preferredCell[0];
        this.preferredCellContactId = preferredCell[1];
        this.typeMail = this.contactPreferencesForm.get('preferredMailAddress').value;
        let preferredMailAddress = this.typeMail.split('-');
        this.preferredMailAddressUniqueId = preferredMailAddress[0];
        this.preferredMailAddressContactId = preferredMailAddress[1];
        var patientID: number = +(this.patientId);
        var assessmentId: number = +(this.assessmentId);
        var contactPreferenceId: number = +(this.contactPreferencesId);
        var AddressID: number = +(this.addressID);
        var PhoneID: number = +(this.phoneID);
        var preferredCellEntityId: number = +(this.entityID);
        var pretime = "";
        var TypeOfCell = "";
        if (this.typeCell == "Other-0") {
          pretime = contactDetails.otherCell;
          TypeOfCell = contactDetails.cellNumberType;
          this.preferredCellUniqueId = StringConstants.var.other;
          this.preferredCellContactId = 0;
        }
        else {
          pretime = contactDetails.preferredTime;
          TypeOfCell = this.cellType;
        }
        if (this.typeMail == 'Other-0') {
          this.chooseMail = true;
          this.preferredMailAddressUniqueId = StringConstants.var.other;
          this.preferredMailAddressContactId = 0;
          this.trueOtherMailValidation();
        }
        else {
          this.chooseMail = false;
          this.contactPreferencesForm.get('nicKName').reset();
          this.contactPreferencesForm.get('streetName').reset();
          this.contactPreferencesForm.get('suite').reset();
          this.contactPreferencesForm.get('city').reset();
          this.contactPreferencesForm.get('county').reset();
          this.contactPreferencesForm.get('state').reset();
          this.contactPreferencesForm.get('zipcode').reset();
          this.falseOtherMailValidation();
        }
        let emailValue = contactDetails.preferredEmail.split('-');
        if ((this.data === undefined || this.data === null)) { //To create new contact details
          const contactData = {
            assessmentId: assessmentId,
            countyCode: contactDetails.countyCode,
            cellNumber: contactDetails.cellno,
            preferredCellEntityId: preferredCellEntityId,
            preferredCellType: TypeOfCell,
            timeOfCalling: pretime,
            name: contactDetails.nicKName,
            suite: contactDetails.suite,
            streetAddress: contactDetails.streetName,
            city: contactDetails.city,
            state: contactDetails.state,
            zipCode: contactDetails.zipcode,
            county: contactDetails.county,
            modeOfCommunication: contactDetails.modeOfContact,
            UniqueEmailId: emailValue[0],
            ContactEmailId: +(emailValue[1]),
            UniqueAddressId: this.preferredMailAddressUniqueId,
            ContactAddressId: +(this.preferredMailAddressContactId),
            UniquePhoneId: this.preferredCellUniqueId,
            ContactPhoneId: +(this.preferredCellContactId),
          }
          this.dashboardService.SaveContactPreference(contactData).subscribe(async (result: any) => {
            if (result.wasSuccessful) {
              this.contactPreferencesForm.markAsPristine();
              this.dataSharing.updateContactPreferenceAdvocateUpdateSummary.next(true);
              this.dataSharing.SaveContactPreference.next("true");
              this.dataSharing.showHouseholdTab.next("4");
            }
          },
            (error) => {
              console.log(error)
            });
        }
        else { // Update contact preference details
          const contactData = {
            contactPreferenceId: contactPreferenceId,
            assessmentId: assessmentId,
            countyCode: contactDetails.countyCode,
            cellNumber: contactDetails.cellno,
            preferredCellEntityId: preferredCellEntityId,
            preferredCellType: TypeOfCell,
            timeOfCalling: pretime,
            name: contactDetails.nicKName,
            suite: contactDetails.suite,
            streetAddress: contactDetails.streetName,
            city: contactDetails.city,
            state: contactDetails.state,
            zipCode: contactDetails.zipcode,
            county: contactDetails.county,
            modeOfCommunication: contactDetails.modeOfContact,
            UniqueEmailId: emailValue[0],
            ContactEmailId: +(emailValue[1]),
            UniqueAddressId: this.preferredMailAddressUniqueId,
            ContactAddressId: +(this.preferredMailAddressContactId),
            UniquePhoneId: this.preferredCellUniqueId,
            ContactPhoneId: +(this.preferredCellContactId),
          }
          this.dashboardService.UpdateContactPreference(contactData).subscribe(async (result: any) => {
            if (result.wasSuccessful) {
              this.contactPreferencesForm.markAsPristine();
              this.dataSharing.updateContactPreferenceAdvocateUpdateSummary.next(true);
              this.dataSharing.SaveContactPreference.next("true");
              this.dataSharing.showHouseholdTab.next("4");
            }
          },
            (error) => {
              console.log(error)
            });
        }
      }
    }
    else {
      if (!this.contactPreferencesForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharing.SaveContactPreference.next("false");
      }
      else {
        this.dataSharing.showHouseholdTab.next("4");
        this.dataSharing.SaveContactPreference.next("true");
      }
    }
  }
  GetContactPreference() { // To get contact preference details
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    var contactPreferenceId: number = +(this.contactPreferencesId);
    const contactRequest: any = {
      patientId: patientID,
      assessmentId: assessmentId,
      contactPreferenceId: contactPreferenceId,
    }
    this.dashboardService.GetContactPreference(contactRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.data = result.data;
        if ((this.data != undefined)) {
          if (result.data.preferedCellUniqueId == null && result.data.UniquePhoneId == null) {
            this.preferredCell = "";
            this.dataSharing.SaveContactPreference.next("false");
          }
          else {
            this.preferredCell = result.data.uniquePhoneId + '-' + result.data.preferedCellUniqueId;
          }
          this.preferredTime = result.data.timeOfCalling;
          this.otherCell = result.data.timeOfCalling;
          this.cellno = result.data.cellNumber;
          if (result.data.uniqueEmailId == null && result.data.preferedEmailUniqueId == null) {
            this.preferredEmail = "";
            this.dataSharing.SaveContactPreference.next("false");
          }
          else {
            this.preferredEmail = result.data.uniqueEmailId + '-' + result.data.preferedEmailUniqueId;
          }
          if (result.data.uniqueAddressId == null && result.data.preferedAddressUniqueId == null) {
            this.preferredMailAddress = "";
            this.dataSharing.SaveContactPreference.next("false");
          }
          else {
            this.preferredMailAddress = result.data.uniqueAddressId + '-' + result.data.preferedAddressUniqueId;
          }
          this.nicKName = result.data.name;
          this.streetName = result.data.streetAddress;
          this.suite = result.data.suite;
          this.county = result.data.county;
          this.city = result.data.city;
          this.state = result.data.state;
          this.zipcode = result.data.zipcode;
          this.countyCode = result.data.countyCode;
          this.cellNumberType = result.data.preferedCellType;
          this.modeOfContact = result.data.modeOfCommunication;
          this.contactPreferencesId = result.data.contactPreferenceId;
          this.addressID = result.data.addressId;
          this.phoneID = result.data.phoneId;
          this.entityID = result.data.preferedCellEntityId;
          if (this.modeOfContact == StringConstants.var.text) this.isText = true;
          if (this.modeOfContact == StringConstants.var.call) this.isCall = true;
          if (this.modeOfContact == StringConstants.var.mail) this.isMail = true;
          if (this.modeOfContact == StringConstants.var.email) this.isEmail = true;
          if (this.cellNumberType == StringConstants.var.landline) this.cellPlace = StringConstants.var.landlineNumber;
          else this.cellPlace = StringConstants.var.cellNumber;
          let preferredCell = this.preferredCellVal.filter((e: { preferredPhoneUniqueId: any; }) => e.preferredPhoneUniqueId == result.data.uniquePhoneId);
          if (preferredCell.length == 0) {
            this.preferredCell = '';
            this.dataSharing.SaveContactPreference.next("false");
          }
          let preferredEmail = this.preferredEmailDropdownValueList.filter((e: { preferredEmailUniqueId: any; }) => e.preferredEmailUniqueId == result.data.uniqueEmailId);
          if (preferredEmail.length == 0) {
            this.preferredEmail = '';
            this.dataSharing.SaveContactPreference.next("false");
          }
          let preferredMailAddress = this.preferredAddressVal.filter((e: { preferedAddressUniqueId: any; }) => e.preferedAddressUniqueId == result.data.uniqueAddressId);
          if (preferredMailAddress.length == 0) {
            this.preferredMailAddress = '';
            this.dataSharing.SaveContactPreference.next("false");
          }
          if (this.preferredCell == 'Other-0') {
            this.chooseCell = true;
            this.trueOtherCellValidation();
          }
          else {
            this.chooseCell = false;
            this.countyCode = '1';
            this.cellNumberType = StringConstants.var.landline;
            this.falseOtherCellValidation();
          }
          if (this.preferredMailAddress == 'Other-0') {
            this.chooseMail = true;
            this.trueOtherMailValidation();
          }
          else {
            this.chooseMail = false;
            this.falseOtherMailValidation();
          }
        }
        else {
          this.preferredCell = '';
          this.preferredTime = '';
          this.otherCell = '';
          this.cellno = '';
          this.preferredEmail = '';
          this.preferredMailAddress = '';
          this.nicKName = '';
          this.streetName = '';
          this.suite = '';
          this.county = '';
          this.city = '';
          this.state = '';
          this.zipcode = '';
          this.countyCode = '1';
          this.cellNumberType = StringConstants.var.landline;
          this.modeOfContact = '';
          if (this.cellNumberType == StringConstants.var.landline) this.cellPlace = StringConstants.var.landlineNumber;
          else this.cellPlace = StringConstants.var.cellNumber;
          this.chooseCell = false;
          this.chooseMail = false;
          this.CForm.submitted = false;
        }
      }
    },
      (error) => {
        console.log(error);
      }
    );
  }
  BackToGuarantor() { // Go back to guarantor
    if (this.GuarantorData == "false") {
      this.dataSharing.MoveToGWork.next(true);
      this.dataSharing.showGuarantorTab.next("2");
    }
    else {
      this.dataSharing.MoveToPWork.next(true);
      this.dataSharing.showPersonalTab.next("1");
    }
  }
  public trueOtherCellValidation() { // Other cell validation
    this.contactPreferencesForm.get('otherCell').setValidators([Validators.required]);
    this.contactPreferencesForm.get('otherCell').updateValueAndValidity();
    this.contactPreferencesForm.get('cellno').setValidators([Validators.required, Validators.minLength(10)]);
    this.contactPreferencesForm.get('cellno').updateValueAndValidity();
    this.contactPreferencesForm.get('preferredTime').clearValidators();
    this.contactPreferencesForm.get('preferredTime').updateValueAndValidity();
  }
  public falseOtherCellValidation() {// Other cell validation
    this.contactPreferencesForm.get('preferredTime').setValidators([Validators.required]);
    this.contactPreferencesForm.get('preferredTime').updateValueAndValidity();
    this.contactPreferencesForm.get('otherCell').clearValidators();
    this.contactPreferencesForm.get('otherCell').updateValueAndValidity();
    this.contactPreferencesForm.get('cellno').clearValidators();
    this.contactPreferencesForm.get('cellno').updateValueAndValidity();
  }
  public trueOtherMailValidation() { // Other mail validation
    this.contactPreferencesForm.get('nicKName').setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50), Validators.minLength(2)]);
    this.contactPreferencesForm.get('nicKName').updateValueAndValidity();
    this.contactPreferencesForm.get('streetName').setValidators([Validators.required, Validators.minLength(3), Validators.maxLength(250)]);
    this.contactPreferencesForm.get('streetName').updateValueAndValidity();
    this.contactPreferencesForm.get('suite').setValidators([Validators.maxLength(250)]);
    this.contactPreferencesForm.get('suite').updateValueAndValidity();
    this.contactPreferencesForm.get('city').setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]);
    this.contactPreferencesForm.get('city').updateValueAndValidity();
    this.contactPreferencesForm.get('county').setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]);
    this.contactPreferencesForm.get('county').updateValueAndValidity();
    this.contactPreferencesForm.get('state').setValidators([Validators.required]);
    this.contactPreferencesForm.get('state').updateValueAndValidity();
    this.contactPreferencesForm.get('zipcode').setValidators([Validators.required, Validators.pattern('^[0-9 ]*$'), Validators.maxLength(50), Validators.minLength(5)]);
    this.contactPreferencesForm.get('zipcode').updateValueAndValidity();
  }
  public falseOtherMailValidation() {// Other mail validation
    this.contactPreferencesForm.get('nicKName').clearValidators();
    this.contactPreferencesForm.get('nicKName').updateValueAndValidity();
    this.contactPreferencesForm.get('streetName').clearValidators();
    this.contactPreferencesForm.get('streetName').updateValueAndValidity();
    this.contactPreferencesForm.get('suite').clearValidators();
    this.contactPreferencesForm.get('suite').updateValueAndValidity();
    this.contactPreferencesForm.get('city').clearValidators();
    this.contactPreferencesForm.get('city').updateValueAndValidity();
    this.contactPreferencesForm.get('county').clearValidators();
    this.contactPreferencesForm.get('county').updateValueAndValidity();
    this.contactPreferencesForm.get('state').clearValidators();
    this.contactPreferencesForm.get('state').updateValueAndValidity();
    this.contactPreferencesForm.get('zipcode').clearValidators();
    this.contactPreferencesForm.get('zipcode').updateValueAndValidity();
  }
}
export interface CellDetails {
  fullName: any,
  entityType: any,
  type: any,
  countyCode: any,
  cellNumber: any,
  entityId: any,
  uniqueId: any,
  phoneId: any;
}
export interface AddressDetails {
  fullName: any,
  entityType: any,
  type: any,
  address: any,
  addressId: any,
  countyCode: any,
  cellNumber: any,
  preferedAddressUniqueId: any
}
