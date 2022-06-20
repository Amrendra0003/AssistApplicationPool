import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { DatePipe } from '@angular/common';
import DateValidation from 'src/app/components/controls/date-validation-control';
import { StringConstants } from 'src/assets/constants/string.constants';
import { CommonService } from 'src/app/services/common.service';
@Component({
  selector: 'app-demographics',
  templateUrl: './demographics.component.html',
  styleUrls: ['./demographics.component.css']
})
export class DemographicsComponent implements OnInit {
  demographicsForm: any;
  genderval: any;
  martialStatusVal: any;
  firstName: any = "";
  lastName: any = "";
  middleName: any = "";
  city: any = "";
  state: any = "";
  zipCode: any;
  ZipCodeInvalid: string = "";
  dob: any = "";
  gender: any;
  maritalStatus: any;
  email: any;
  cellNumber: any;
  countyCode: any = "1";
  patient: boolean = false;
  relation: any = "";
  relationCellNumber: any;
  relationCountyCode: any = "1";
  relationEmail: any;
  relationFirstName: any;
  relationMiddleName: any;
  relationLastName: any;
  relationval: any;
  citizenshipStatus: any = " ";
  public patientContactPerson: boolean = false;
  today = new Date();
  result: any;
  zipMappingId: any;
  zipQuestionId: any;
  cityMappingId: any;
  cityQuestionId: any;
  stateMappingId: any;
  stateQuestionId: any;
  citizenshipMappingId: any;
  citizenshipQuestionId: any;
  citizenshipOptions: any;
  firstmappingId: any;
  firstQuestionId: any;
  middleMappingId: any;
  middleQuestionId: any;
  lastMappingId: any;
  lastQuestionId: any;
  dobQuestionId: any;
  dobMappingId: any;
  genderMappingId: any;
  genderQuestionId: any;
  genderOptionId: any;
  martialMappingId: any;
  martialQuestionId: any;
  martialOptionId: any;
  emailMappingId: any;
  emailQuestionId: any;
  cellMappingId: any;
  cellQuestionId: any;
  QuestionAndAnswer: QuestionAndAnswer[] = [];
  bindGetQuestionAndAnswer: QuestionAndAnswer[] = [];
  demographicsQuestionAndAnswer: QuestionAndAnswer[] = [];
  citizenshipQuestionAndAnswer: QuestionAndAnswer[] = [];
  isPatient: boolean = false;
  getQuestionAndAnswer: QuestionAndAnswer[] = [];
  currentTheme: any;
  bsVal: any;
  dobTextBox: any;
  info = StringConstants.demographics.info;
  NameReq = StringConstants.demographics.NameReq;
  NameAlp = StringConstants.demographics.NameAlp;
  NameMax = StringConstants.demographics.NameMax;
  NameChar = StringConstants.demographics.NameChar;
  NameLegal = StringConstants.demographics.NameLegal;
  MiddleNameReq = StringConstants.demographics.MiddleNameReq;
  MiddleNameAlp = StringConstants.demographics.MiddleNameAlp;
  MiddleNameMax = StringConstants.demographics.MiddleNameMax;
  MiddleNameChar = StringConstants.demographics.MiddleNameChar;
  LastNamereq = StringConstants.demographics.LastNamereq;
  LastNameAlp = StringConstants.demographics.LastNameAlp;
  LastNameMax = StringConstants.demographics.LastNameMax;
  DateReq = StringConstants.demographics.DateReq;
  DateFormate = StringConstants.demographics.DateFormate;
  DateFut = StringConstants.demographics.DateFut;
  Gender = StringConstants.demographics.Gender;
  GenderReq = StringConstants.demographics.GenderReq;
  Marital = StringConstants.demographics.Marital;
  MartialReq = StringConstants.demographics.MartialReq;
  ZipMsg = StringConstants.demographics.ZipMsg;
  ZipReq = StringConstants.demographics.ZipReq;
  ZipNum = StringConstants.demographics.ZipNum;
  ZipMin = StringConstants.demographics.ZipMin;
  ZipMax = StringConstants.demographics.ZipMax;
  ZipVal = StringConstants.demographics.ZipVal;
  CityReq = StringConstants.demographics.CityReq;
  CityAlp = StringConstants.demographics.CityAlp;
  CityMax = StringConstants.demographics.CityMax;
  StateReq = StringConstants.demographics.StateReq;
  ConfirmCitizenshipStatus = StringConstants.demographics.ConfirmCitizenshipStatus;
  CitizenshipStatus = StringConstants.demographics.CitizenshipStatus;
  PatientContactDetails = StringConstants.demographics.PatientContactDetails;
  EmailVal = StringConstants.demographics.EmailVal;
  EmailMax = StringConstants.demographics.EmailMax;
  CellNumReq = StringConstants.demographics.CellNumReq;
  CellVal = StringConstants.demographics.CellVal;
  BestContact = StringConstants.demographics.BestContact;
  Patient = StringConstants.demographics.Patient;
  RelationshipWithPatient = StringConstants.demographics.RelationshipWithPatient;
  RelationReq = StringConstants.demographics.RelationReq;
  EmailReq = StringConstants.demographics.EmailReq;
  nextScreen: any;
  @Output() advocateInsuranceClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() advocateDemographicsClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() advocateGeneralQuestionClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() advocateHouseholdClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() advocateSsnClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  citizenshipOptionId: any;
  phoneCode: any;
  constructor(private common:CommonService,private datepipe: DatePipe, private toastService: ToastServiceService,
    private quickAssessmentService: QuickAssessmentService, private dataSharingService: DataSharingService, private dropdownService: DropdownService) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.validateDemographicsForm.subscribe(value => {
      if (value == true) {
        this.isValidDemographicsDetails();
      }
    });
  }
  ngOnInit(): void {
    window.scroll(0, 0);
    this.initForm();
    this.getMartialValues();
    this.getGenderValues();
    this.getRelationValues();
    this.getSelfDetails();
    this.getAssessmentDetails();
    this.getPhoneCode();
    this.dataSharingService.getAdvocateDemographicsLoaderState().subscribe(e => {
      if (e != false) {
        this.nextScreen = e;
        this.saveDemographicsDetails(this.demographicsForm.value);
      }
      else if (e == false) {
        this.nextScreen = e;
      }
    });
    this.getQuestionAndAnswer = JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!);
    if (this.getQuestionAndAnswer != null) {
      this.bindGetQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 2);
      if (this.bindGetQuestionAndAnswer.length != 0) {
        this.zipCode = this.bindGetQuestionAndAnswer[0].value;
        this.city = this.bindGetQuestionAndAnswer[1].value;
        this.state = this.bindGetQuestionAndAnswer[2].value;
      }
      else {
        this.zipCode = "";
        this.city = "";
        this.state = "";
      }
      if (this.getQuestionAndAnswer.length != 0) {
        this.citizenshipQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 3);
        if (this.citizenshipQuestionAndAnswer.length != 0) {
          this.citizenshipStatus = this.citizenshipQuestionAndAnswer[0].value;
        }
      }
      this.demographicsQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 4);
      if (this.demographicsQuestionAndAnswer.length != 0) {
        this.firstName = this.demographicsQuestionAndAnswer[0].value;
        this.middleName = this.demographicsQuestionAndAnswer[1].value;
        this.lastName = this.demographicsQuestionAndAnswer[2].value;
        this.dob = this.demographicsQuestionAndAnswer[3].value;
        this.gender = this.demographicsQuestionAndAnswer[4].value;
        this.maritalStatus = this.demographicsQuestionAndAnswer[5].value;
        this.email = this.demographicsQuestionAndAnswer[6].value;
        this.cellNumber = this.demographicsQuestionAndAnswer[7].value;
      }
      else {
        this.firstName = "";
        this.lastName = "";
        this.dob = "";
        this.gender = "";
        this.maritalStatus = "";
        this.email = "";
        this.cellNumber = "";
      }
      if (sessionStorage.getItem('contactRelationShip') != " ") {
        this.isPatient = true;
        this.getRelationValues();
        this.relation = sessionStorage.getItem('contactRelationShip');
        this.relationFirstName = sessionStorage.getItem('contactRelationFirstName');
        this.relationMiddleName = sessionStorage.getItem('contactRelationMiddleName');
        this.relationLastName = sessionStorage.getItem('contactRelationLastName');
        this.relationCellNumber = sessionStorage.getItem('contactRelationCellNumber');
        this.relationEmail = sessionStorage.getItem('contactRelationEmail');
        this.relationCountyCode = sessionStorage.getItem('contactRelationCountyCode');
        this.patientContactPerson = (/true/i).test(sessionStorage.getItem('isPatientGuarantor')!);
      }
      else {
        this.relation = " ";
        this.relationFirstName == "";
        this.relationMiddleName == "";
        this.relationLastName == "";
        this.relationCellNumber == "";
        this.relationEmail == "";
        this.relationCountyCode == "1";
        this.patientContactPerson == false;
      }
      if (this.patientContactPerson == true) {
        this.disableForm();
      }
      else {
        this.enableForm();
      }
    }
  }
  disableForm() {
    this.demographicsForm.controls['relation'].disable();
    this.demographicsForm.controls['relationFirstName'].disable();
    this.demographicsForm.controls['relationLastName'].disable();
    this.demographicsForm.controls['relationMiddleName'].disable();
    this.demographicsForm.controls['relationCellNumber'].disable();
    this.demographicsForm.controls['relationEmail'].disable();
    this.demographicsForm.controls['relationCountyCode'].disable();
  }
  enableForm() {
    this.demographicsForm.controls['relation'].enable();
    this.demographicsForm.controls['relationFirstName'].enable();
    this.demographicsForm.controls['relationMiddleName'].enable();
    this.demographicsForm.controls['relationLastName'].enable();
    this.demographicsForm.controls['relationCellNumber'].enable();
    this.demographicsForm.controls['relationEmail'].enable();
    this.demographicsForm.controls['relationCountyCode'].enable();
  }
  private initForm() {
    this.demographicsForm = new FormGroup({
      'firstName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'middleName': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'lastName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'gender': new FormControl('', Validators.required),
      'dob': new FormControl('', [Validators.required, DateValidation.validateDateFormat, DateValidation.futureDateValidation]),
      'citizenshipStatus': new FormControl('', Validators.required),
      'maritalStatus': new FormControl('', Validators.required),
      'zipCode': new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$'), Validators.minLength(5), Validators.maxLength(5)]),
      'city': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]),
      'state': new FormControl('', [Validators.required]),
      'email': new FormControl('', [Validators.required, Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.com$'), Validators.maxLength(100)]),
      'cellNumber': new FormControl('', [Validators.required, Validators.minLength(10)]),
      'countyCode': new FormControl('1', [Validators.required]),
      'patient': new FormControl('',),
      'relation': new FormControl('', [Validators.required]),
      'relationCellNumber': new FormControl('', [Validators.required, Validators.minLength(10)]),
      'relationCountyCode': new FormControl('1', [Validators.required]),
      'relationEmail': new FormControl('', [Validators.required, Validators.pattern('^[A-Za-z0-9._%-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}$'), Validators.maxLength(100)]),
      'relationFirstName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'relationMiddleName': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'relationLastName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
    });
  }
  space(e: any) {
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
  async getGenderValues() { //To get gender values
    this.genderval = await this.common.getGenderValues();
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  async getRelationValues() { // To get relatives options
    this.relationval = await this.common.getRelationValues();
  }
   async getMartialValues() {//To get martial status option values
    this.martialStatusVal = await this.common.getMartialValues();
  }
  getStateAndCity(event: any) {
    const zipCode = event;
    this.city = "";
    this.state = "";
    this.quickAssessmentService.getStateAndCity(zipCode).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        if (result.data != null) {
          this.city = result.data.city;
          this.state = result.data.state;
          this.ZipCodeInvalid = "";
        }
        else {
          this.ZipCodeInvalid = "Please enter a valid Zip Code.";
          this.city = "";
          this.state = "";
        }
      }
      else if (result.wasSuccessful == false) {
      }
    }, (error) => {
      if (error.status == '500') {
        this.ZipCodeInvalid = error[0].errors[0];
      }
      else {
        this.ZipCodeInvalid = error.error.errors[0];
      }
    });
  }
  getAssessmentDetails() {
    this.quickAssessmentService.getQuickAssessmentDetails().subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.result = result.data.screen[0].questions;
        this.zipMappingId = result.data.screen[1].questions[0].screenQuestionMappingId;
        this.zipQuestionId = result.data.screen[1].questions[0].id;
        this.cityMappingId = result.data.screen[1].questions[1].screenQuestionMappingId;
        this.cityQuestionId = result.data.screen[1].questions[1].id;
        this.stateMappingId = result.data.screen[1].questions[2].screenQuestionMappingId;
        this.stateQuestionId = result.data.screen[1].questions[2].id;
        this.citizenshipMappingId = result.data.screen[2].questions[0].screenQuestionMappingId;
        this.citizenshipQuestionId = result.data.screen[2].questions[0].id;
        this.citizenshipOptions = result.data.screen[2].questions[0].options;
        this.citizenshipOptionId = result.data.screen[2].questions[0].options[0].id;
        this.firstmappingId = result.data.screen[3].questions[1].screenQuestionMappingId;
        this.firstQuestionId = result.data.screen[3].questions[1].id;
        this.middleMappingId = result.data.screen[3].questions[8].screenQuestionMappingId;
        this.middleQuestionId = result.data.screen[3].questions[8].id;
        this.lastMappingId = result.data.screen[3].questions[2].screenQuestionMappingId;
        this.lastQuestionId = result.data.screen[3].questions[2].id;
        this.dobMappingId = result.data.screen[3].questions[3].screenQuestionMappingId;
        this.dobQuestionId = result.data.screen[3].questions[3].id;
        this.genderMappingId = result.data.screen[3].questions[4].screenQuestionMappingId;
        this.genderQuestionId = result.data.screen[3].questions[4].id;
        this.genderOptionId = result.data.screen[3].questions[4].options[0].id;
        this.martialMappingId = result.data.screen[3].questions[5].screenQuestionMappingId;
        this.martialQuestionId = result.data.screen[3].questions[5].id;
        this.martialOptionId = result.data.screen[3].questions[5].options[3].id;
        this.emailMappingId = result.data.screen[3].questions[6].screenQuestionMappingId;
        this.emailQuestionId = result.data.screen[3].questions[6].id;
        this.cellMappingId = result.data.screen[3].questions[7].screenQuestionMappingId;
        this.cellQuestionId = result.data.screen[3].questions[7].id;
      }
    }, (error) => {
      console.log(error)
    });
  }
  onChangeRelationValue(event: any) {
    this.relation = event.target.value;
    this.dataSharingService.advocateDemographicsSaveDetails = true;
  }
  getRelationFirstName() {
    this.dataSharingService.advocateDemographicsSaveDetails = true;
  }
  getSelfDetails() {
    let patientId = sessionStorage.getItem('patientId');
    this.quickAssessmentService.getPatientSelfDetails(patientId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        console.log(result.data, "hi");
        if (result.data != '') {
          this.result = result.data;
          if (sessionStorage.getItem('UpdateFirstName') != null || sessionStorage.getItem('UpdateFirstName') != undefined) {
            this.firstName = sessionStorage.getItem('UpdateFirstName');
            this.lastName = sessionStorage.getItem('UpdateLastName');
            this.middleName = sessionStorage.getItem('UpdateMiddleName');
            this.dob = sessionStorage.getItem('UpdateDateOfBirth');
            this.zipCode = sessionStorage.getItem('UpdateZipCode');
            this.city = sessionStorage.getItem('UpdateCity');
            this.state = sessionStorage.getItem('UpdateState');
          }
          else {
            this.firstName = result.data.firstName;
            this.middleName = (result.data.middleName == undefined) ? "" : result.data.middleName;
            console.log(this.middleName);
            this.lastName = result.data.lastName;
            sessionStorage.setItem("quickAssessmentPatientName", result.data.firstName + " " + result.data.lastName);
            this.dob = this.datepipe.transform(result.data.dateOfBirth, 'MM/dd/yyyy');
            this.city = result.data.city;
            this.state = result.data.state;
            this.zipCode = result.data.zipCode;
          }
          this.gender = result.data.gender;
          this.cellNumber = result.data.cell;
          this.citizenshipStatus = result.data.citizenship;
          this.email = result.data.email;
          this.maritalStatus = result.data.maritalStatus;
          this.countyCode = result.data.countyCode;
          sessionStorage.setItem('CountyCode', this.countyCode);
          sessionStorage.setItem('AssessmentStateCode', result.data.stateCode);
        }
        else {
          this.firstName = " ";
          this.lastName = " ";
          this.middleName = "";
          this.gender = " ";
          this.cellNumber = "";
          this.countyCode = "1";
          this.citizenshipStatus = " ";
          this.dob = "";
          this.email = " ";
          this.maritalStatus = " ";
          this.relation = " ";
          this.city = " ";
          this.state = " ";
          this.zipCode = " ";
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  emit() {
    this.dataSharingService.advocateDemographicsSaveDetails = true;
    this.advocateDemographicsClicked.emit(true);
    this.dataSharingService.validateDemographicsStopForm.next(false);
    this.dataSharingService.ADDemographics.next(false);
  }
  isValidDemographicsDetails() {
    if (!this.demographicsForm.valid) {
      this.emit();
    }
    else {
      this.dataSharingService.validateDemographicsForm.next(false);
      this.saveDemographicsDetails(this.demographicsForm.value);
    }
  }
  saveDemographicsDetails(patientDetails: any) {
    if (!this.demographicsForm.valid) {
      this.emit();
    } else {
      this.dataSharingService.validateDemographicsStopForm.next(true);
      if (this.relation != 'Self') {
        sessionStorage.setItem('contactRelationShip', patientDetails.relation);
        sessionStorage.setItem('contactRelationFirstName', patientDetails.relationFirstName);
        sessionStorage.setItem('contactRelationMiddleName', patientDetails.relationMiddleName);
        sessionStorage.setItem('contactRelationLastName', patientDetails.relationLastName);
        sessionStorage.setItem('contactRelationCellNumber', patientDetails.relationCellNumber);
        sessionStorage.setItem('contactRelationEmail', patientDetails.relationEmail);
        sessionStorage.setItem('contactRelationCountyCode', patientDetails.relationCountyCode);
      }
      sessionStorage.setItem('isPatientGuarantor', patientDetails.patient);
      sessionStorage.setItem('AssessmentZipCode', patientDetails.zipCode);
      sessionStorage.setItem('AssessmentState', patientDetails.state);
      sessionStorage.setItem('AssessmentCity', patientDetails.city);
      patientDetails.dob = new Date(patientDetails.dob);
      var date = patientDetails.dob.toLocaleDateString("en-US", {
        year: "numeric",
        day: "2-digit",
        month: "2-digit",
      });
      sessionStorage.setItem('UpdateFirstName', patientDetails.firstName);
      sessionStorage.setItem('UpdateLastName', patientDetails.lastName);
      sessionStorage.setItem('UpdateMiddleName', patientDetails.middleName);
      sessionStorage.setItem('UpdateDateOfBirth', date);
      sessionStorage.setItem('UpdateZipCode', patientDetails.zipCode);
      sessionStorage.setItem('UpdateCity', patientDetails.city);
      sessionStorage.setItem('UpdateState', patientDetails.state);
      const demographics: QuestionAndAnswer[] = [
        {
          screenQuestionMappingId: +(this.zipMappingId),
          questionId: +(this.zipQuestionId),
          optionId: null,
          value: patientDetails.zipCode,
          screenId: 2
        },
        {
          screenQuestionMappingId: +(this.cityMappingId),
          questionId: +(this.cityQuestionId),
          optionId: null,
          value: patientDetails.city,
          screenId: 2
        },
        {
          screenQuestionMappingId: +(this.stateMappingId),
          questionId: +(this.stateQuestionId),
          optionId: null,
          value: patientDetails.state,
          screenId: 2
        },
        {
          screenQuestionMappingId: +(this.citizenshipMappingId),
          optionId: this.citizenshipOptionId,
          questionId: +(this.citizenshipQuestionId),
          value: patientDetails.citizenship,
          screenId: 3
        },
        {
          screenQuestionMappingId: +(this.firstmappingId),
          questionId: +(this.firstQuestionId),
          optionId: null,
          value: patientDetails.firstName,
          screenId: 4
        },
        {
          screenQuestionMappingId: +(this.middleMappingId),
          questionId: +(this.middleQuestionId),
          optionId: null,
          value: patientDetails.middleName,
          screenId: 4
        },
        {
          screenQuestionMappingId: +(this.lastMappingId),
          questionId: +(this.lastQuestionId),
          optionId: null,
          value: patientDetails.lastName,
          screenId: 4
        },
        {
          screenQuestionMappingId: +(this.dobMappingId),
          questionId: +(this.dobQuestionId),
          optionId: null,
          value: date,
          screenId: 4
        },
        {
          screenQuestionMappingId: +(this.genderMappingId),
          questionId: +(this.genderQuestionId),
          optionId: this.genderOptionId,
          value: patientDetails.gender,
          screenId: 4
        },
        {
          screenQuestionMappingId: +(this.martialMappingId),
          questionId: +(this.martialQuestionId),
          optionId: this.martialOptionId,
          value: patientDetails.maritalStatus,
          screenId: 4
        },
        {
          screenQuestionMappingId: 11,
          questionId: 12,
          optionId: null,
          value: patientDetails.email,
          screenId: 4
        },
        {
          screenQuestionMappingId: 12,
          questionId: 13,
          optionId: null,
          value: patientDetails.cellNumber,
          screenId: 4
        },
      ]
      this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
      if (this.QuestionAndAnswer == null) {
        this.QuestionAndAnswer = [];
        demographics.forEach(element => {
          this.QuestionAndAnswer.push(element);
        });
        sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
        this.forWardScreen();
        this.dataSharingService.ADDemographics.next(true);
        this.dataSharingService.completeDemo.next("true");
        this.dataSharingService.setAdvocateDemographicsLoaderState(false);
      }
      else {
        this.QuestionAndAnswer = this.QuestionAndAnswer.filter(e => (e.screenId != 2 && e.screenId != 3 && e.screenId != 4))
        demographics.forEach(element => {
          this.QuestionAndAnswer.push(element);
        });
        sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
        this.forWardScreen();
        this.dataSharingService.setAdvocateDemographicsLoaderState(false);
        this.dataSharingService.ADDemographics.next(true);
        this.dataSharingService.completeDemo.next("true");
      }
    }
  }
  forWardScreen() {
    if (this.nextScreen == "insurance") {
      this.dataSharingService.callInsuranceTab.next(true);
    }
    else if (this.nextScreen == "household") {
      this.dataSharingService.callHouseholdTab.next(true);
    }
    else if (this.nextScreen == "generalQuestions") {
      this.dataSharingService.callGeneralQuestionsTab.next(true);
    }
    else if (this.nextScreen == "verification") {
      this.dataSharingService.callVerificationTab.next(true);
    }
    else if (this.nextScreen == "demographics") {
      this.dataSharingService.callDemographicsTab.next(true);
    }
    else if (this.nextScreen == false) {
      this.advocateInsuranceClicked.emit(true);
    }
    this.dataSharingService.advocateDemographicsSaveDetails = false;
  }
  selectDate(event: any) {
    if (event != undefined && event != "" && event != null) {
      var newVal = this.datepipe.transform(event, 'MM/dd/yyyy');
      this.demographicsForm.controls['dob'].setValue(newVal);
    }
  }
  closeCalendar() {
    DateValidation.closeCal();
    this.captureDateInDatepicker();
  }
  captureDateInDatepicker() {
    if (this.demographicsForm.controls.dob.errors == null) {
      var bsValueDOB = this.demographicsForm.get('dob').value;
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
    } else {
      this.bsVal = "";
    }
  }
  checkPattern() {
    var result = false;
    var dateCheck;
    this.dobTextBox = document.getElementById('dob');
    var bsValueDOB = this.demographicsForm.get('dob').value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
        dateCheck = this.datepipe.transform(bsValueDOB, 'MM/dd/yyyy');
        result = DateValidation.validateFutureDate(dateCheck != null ? dateCheck : "");
      }
    }
    if (!result) {
      this.demographicsForm.patchValue({
        dob: ""
      });
      this.dobTextBox.focus();
      this.demographicsForm.controls['dob'].setErrors({ pattern: true });
    } else {
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
      this.demographicsForm.controls['dob'].setValue(dateCheck);
    }
  }
  keyPress(event: KeyboardEvent) {
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  }
  OnClickPatient(patientvalue: boolean) {
    this.dataSharingService.advocateDemographicsSaveDetails = true;
    if (patientvalue == true) {
      this.isPatient = true;
      this.getRelationValues();
      this.patientContactPerson = true;
      this.relation = "Self";
      this.relationFirstName = this.firstName;
      this.relationMiddleName = this.middleName;
      this.relationLastName = this.lastName;
      this.relationCellNumber = this.cellNumber;
      this.relationEmail = this.email;
      this.relationCountyCode = this.countyCode;
      sessionStorage.setItem('contactRelationShip', this.relation);
      sessionStorage.setItem('contactRelationFirstName', this.relationFirstName);
      sessionStorage.setItem('contactRelationMiddleName', this.relationMiddleName);
      sessionStorage.setItem('contactRelationLastName', this.relationLastName);
      sessionStorage.setItem('contactRelationCellNumber', this.relationCellNumber);
      sessionStorage.setItem('contactRelationEmail', this.relationEmail);
      sessionStorage.setItem('contactRelationCountyCode', this.relationCountyCode);
      this.disableForm();
    }
    else if (patientvalue == false) {
      this.isPatient = false;
      this.getRelationValues();
      this.patientContactPerson = false;
      this.relation = "";
      this.relationFirstName = "";
      this.relationMiddleName = "";
      this.relationLastName = "";
      this.relationCellNumber = "";
      this.relationEmail = "";
      this.enableForm();
    }
  }
}
export interface QuestionAndAnswer {
  screenQuestionMappingId: number;
  questionId: number;
  optionId: any;
  value: any;
  screenId: any;
}
export interface QuickAssessmentdynamicData {
  assessmentPatientId: number;
  loggedInUserId: number;
  QuestionAndAnswers: QuestionAndAnswer[];
}