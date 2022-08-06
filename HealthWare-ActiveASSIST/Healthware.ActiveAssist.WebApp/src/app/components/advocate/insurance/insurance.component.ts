import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { DatePipe } from '@angular/common';
import DateValidation from 'src/app/components/controls/date-validation-control';
import { StringConstants } from 'src/assets/constants/string.constants';
import { ToastServiceService } from 'src/app/services/toast-service.service';
@Component({
  selector: 'app-insurance',
  templateUrl: './insurance.component.html',
  styleUrls: ['./insurance.component.css']
})
export class InsuranceComponent implements OnInit {
  insuranceForm: any;
  insurance: any = 'false';
  payerName: any;
  groupName: any;
  groupNumber: any;
  policyNumber: any;
  effectiveFrom: any = null;
  termination: any = null;
  result: any;
  insurancemappingId: any;
  insuranceQuestionId: any;
  insuranceOptionId: any;
  payerNamemappingId: any;
  payerNameQuestionId: any;
  groupNameMappingId: any;
  groupNameQuestionId: any;
  groupNoMappingId: any;
  groupNoQuestionId: any;
  policyNoMappingId: any;
  policyNoQuestionId: any;
  effectiveFromMappingId: any;
  effectiveFromQuestionId: any;
  terminationMappingId: any;
  terminationQuestionId: any;
  QuestionAndAnswer: QuestionAndAnswer[] = [];
  validatePolicyNumberErrorMessage: boolean = false;
  nextButtonDisable: boolean = true;
  insuranceDetailsMessageShow: boolean = false;
  insuranceDetailsShow: boolean = false;
  insuranceErrorMessage: string = '';
  payerNameErrorMessage: string = '';
  groupNameErrorMessage: string = '';
  groupNumberErrorMessage: string = '';
  policyNumberErrorMessage: string = '';
  effectiveFromErrorMessage: string = '';
  terminationErrorMessage: string = '';
  Last60DaysIncome = StringConstants.insurance.Last60DaysIncome;
  InsuranceMsg1 = StringConstants.insurance.InsuranceMsg1;
  InsuranceMsg2 = StringConstants.insurance.InsuranceMsg2;
  No = StringConstants.insurance.No;
  Yes = StringConstants.insurance.Yes;
  FollowingDetails = StringConstants.insurance.FollowingDetails;
  PayerNameAlp = StringConstants.insurance.PayerNameAlp;
  PaterMax = StringConstants.insurance.PaterMax;
  PayerNumOfChar = StringConstants.insurance.PayerNumOfChar;
  GroupAlp = StringConstants.insurance.GroupAlp;
  GroupNameCharMax = StringConstants.insurance.GroupNameCharMax;
  GroupNameCharMin = StringConstants.insurance.GroupNameCharMin;
  GroupNo = StringConstants.insurance.GroupNo;
  PolicyNo = StringConstants.insurance.PolicyNo;
  PolicyNumAlp = StringConstants.insurance.PolicyNumAlp;
  PolicyNumMax = StringConstants.insurance.PolicyNumMax;
  EffectiveFrom = StringConstants.insurance.EffectiveFrom;
  Termination = StringConstants.insurance.Termination;
  VisitoeInfo = StringConstants.insurance.VisitoeInfo;
  InvalidPolicyNumber = StringConstants.insurance.InvalidPolicyNumber;
  Next = StringConstants.insurance.Next;
  @Output() advocateHouseholdClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() advocateInsuranceClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  getQuestionAndAnswer: QuestionAndAnswer[] = [];
  bindGetQuestionAndAnswer: QuestionAndAnswer[] = [];
  currentTheme: any;
  bsValEffectiveFrom: any;
  bsValTermination: any;
  terminationTextBox: any;
  effectiveTextbox: any;
  nextScreen: any;
  constructor(private datepipe: DatePipe, private dataSharingService: DataSharingService, private quickAssessmentService: QuickAssessmentService, private toastService: ToastServiceService) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.validateInsuranceForm.subscribe(value => {
      if (value == true) {
        this.isValidInsuranceDetails();
      }
    });
  }
  ngOnInit(): void {
    window.scroll(0, 0);
    this.initForm();
    this.getAssessmentDetails();
    this.getQuestionAndAnswer = JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!);
    if (this.getQuestionAndAnswer != null) {
      this.bindGetQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 5);
      if (this.bindGetQuestionAndAnswer.length != 0) {
        this.insurance = this.bindGetQuestionAndAnswer[0].value;
        if (this.insurance == 'true') {
          this.insuranceDetailsShow = true;
          this.insuranceDetailsMessageShow = true;
          this.payerName = this.bindGetQuestionAndAnswer[1].value;
          this.groupName = this.bindGetQuestionAndAnswer[2].value;
          this.groupNumber = this.bindGetQuestionAndAnswer[3].value;
          this.policyNumber = this.bindGetQuestionAndAnswer[4].value;
          if (this.bindGetQuestionAndAnswer[5].value != '' && this.bindGetQuestionAndAnswer[5].value != 'Invalid Date') {
            this.effectiveFrom = this.bindGetQuestionAndAnswer[5].value;
            this.insuranceDetailsMessageShow = false;
          }
          else if (this.bindGetQuestionAndAnswer[5].value == '' && this.bindGetQuestionAndAnswer[5].value == 'Invalid Date') {
            this.effectiveFrom = '';
            this.insuranceDetailsMessageShow = false;
          }
          if (this.bindGetQuestionAndAnswer[6].value != '' && this.bindGetQuestionAndAnswer[6].value != 'Invalid Date') {
            this.termination = this.bindGetQuestionAndAnswer[6].value;
            this.insuranceDetailsMessageShow = false;
          }
          else if (this.bindGetQuestionAndAnswer[6].value == '' && this.bindGetQuestionAndAnswer[6].value == 'Invalid Date') {
            this.termination = '';
            this.insuranceDetailsMessageShow = false;
          }
        }
        else {
          this.insuranceDetailsShow = false;
          this.insuranceDetailsMessageShow = false;
          this.payerName = "";
          this.groupName = "";
          this.groupNumber = "";
          this.policyNumber = "";
          this.effectiveFrom = null;
          this.termination = null;
        }
      }
      else {
        this.insurance = "";
        this.payerName = "";
        this.groupName = "";
        this.groupNumber = "";
        this.policyNumber = "";
        this.effectiveFrom = null;
        this.termination = null;
      }
    }
    else {
      this.insurance = "";
      this.payerName = "";
      this.groupName = "";
      this.groupNumber = "";
      this.policyNumber = "";
      this.effectiveFrom = null;
      this.termination = null;
    }
    this.dataSharingService.getAdvocateInsuranceLoaderState().subscribe(e => {
      if (e != false) {
        this.nextScreen = e;
        this.saveInsuranceDetails(this.insuranceForm.value);
      }
      else if (e == false) {
        this.nextScreen = e;
      }
    });
  }
  private initForm() {
    this.insuranceForm = new FormGroup({
      'insurance': new FormControl('', [Validators.required]),
      'payerName': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'groupName': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'groupNumber': new FormControl('', [Validators.pattern('^[a-zA-Z0-9]+$'), Validators.maxLength(50)]),
      'policyNumber': new FormControl('', [Validators.pattern('^[a-zA-Z0-9]+$'), Validators.maxLength(50)]),
      'effectiveFrom': new FormControl(null, []),
      'termination': new FormControl(null, []),
    });
  }
  insuranceDetails(insuranceDetails: any) {
    this.dataSharingService.advocateInsuranceSaveDetails = true;
    if (insuranceDetails.insurance == 'true') {
      this.insuranceDetailsShow = true;
      this.insuranceErrorMessage = "";
      this.payerNameErrorMessage = "";
      this.groupNameErrorMessage = "";
      this.groupNumberErrorMessage = "";
      this.policyNumberErrorMessage = "";
      this.effectiveFromErrorMessage = "";
      this.terminationErrorMessage = "";
      this.effectiveFrom = null;
      this.termination = null;
    }
    else {
      this.insuranceDetailsMessageShow = false;
      this.insuranceDetailsShow = false;
      this.validatePolicyNumberErrorMessage = false;
      this.payerName = "";
      this.groupName = "";
      this.groupNumber = "";
      this.policyNumber = "";
      this.effectiveFrom = null;
      this.termination = null;
      this.insuranceErrorMessage = "";
      this.payerNameErrorMessage = "";
      this.groupNameErrorMessage = "";
      this.groupNumberErrorMessage = "";
      this.policyNumberErrorMessage = "";
      this.effectiveFromErrorMessage = "";
      this.terminationErrorMessage = "";
      this.nextButtonDisable = true;
    }
  }
  getAssessmentDetails() {
    this.quickAssessmentService.getQuickAssessmentDetails().subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.result = result.data.screen[4].questions;
        this.insurancemappingId = result.data.screen[4].questions[0].screenQuestionMappingId;
        this.insuranceQuestionId = result.data.screen[4].questions[0].id;
        this.insuranceOptionId = result.data.screen[4].questions[0].options[1].id;
        this.payerNamemappingId = result.data.screen[4].questions[0].subQuestion.question[1].screenQuestionMappingId;
        this.payerNameQuestionId = result.data.screen[4].questions[0].subQuestion.question[1].id;
        this.groupNameMappingId = result.data.screen[4].questions[0].subQuestion.question[2].screenQuestionMappingId;
        this.groupNameQuestionId = result.data.screen[4].questions[0].subQuestion.question[2].id;
        this.groupNoMappingId = result.data.screen[4].questions[0].subQuestion.question[3].screenQuestionMappingId;
        this.groupNoQuestionId = result.data.screen[4].questions[0].subQuestion.question[3].id;
        this.policyNoMappingId = result.data.screen[4].questions[0].subQuestion.question[4].screenQuestionMappingId;
        this.policyNoQuestionId = result.data.screen[4].questions[0].subQuestion.question[4].id;
        this.effectiveFromMappingId = result.data.screen[4].questions[0].subQuestion.question[5].screenQuestionMappingId;
        this.effectiveFromQuestionId = result.data.screen[4].questions[0].subQuestion.question[5].id;
        this.terminationMappingId = result.data.screen[4].questions[0].subQuestion.question[6].screenQuestionMappingId;
        this.terminationQuestionId = result.data.screen[4].questions[0].subQuestion.question[6].id;
      }
    }, (error) => {
      console.log(error)
    });
  }
  onKey(event: any) {
    this.dataSharingService.advocateInsuranceSaveDetails = true;
    if (this.insurance != "") {
      this.insuranceErrorMessage = "";
    }
    if (this.payerName != "") {
      this.payerNameErrorMessage = "";
    }
    if (this.groupName != '') {
      this.groupNameErrorMessage = "";
    }
    if (this.groupNumber != "") {
      this.groupNumberErrorMessage = "";
    }
    if (this.effectiveFrom != "") {
      if (this.effectiveFromErrorMessage == "") {
        this.effectiveFromErrorMessage = "";
      }
    }
    if (this.termination != "") {
      if (this.terminationErrorMessage == "") {
        this.terminationErrorMessage = "";
      }
    }
  }
  onKeyPolicyNumber(event: any) {
    if (this.policyNumber != "") {
      this.policyNumberErrorMessage = "";
      if (this.validatePolicyNumberErrorMessage) {
        this.validatePolicyNumberErrorMessage = false;
        this.nextButtonDisable = true;
      }
      if (this.insuranceDetailsMessageShow) {
        this.insuranceDetailsMessageShow = false;
        this.nextButtonDisable = true;
      }
    }
  }
  selectEffectiveFromDate() {
    if (this.bsValEffectiveFrom && this.bsValEffectiveFrom != "Invalid Date") {
      this.effectiveTextbox = document.getElementById('effectiveFrom');
      var newVal = this.datepipe.transform(this.bsValEffectiveFrom, 'MM/dd/yyyy');
      this.effectiveTextbox.value = newVal;
      this.effectiveFrom = newVal;
      this.clickEffectiveFrom();
    }
  }
  selectTerminationDate() {
    if (this.bsValTermination && this.bsValTermination != "Invalid Date") {
      this.terminationTextBox = document.getElementById('termination');
      var newVal = this.datepipe.transform(this.bsValTermination, 'MM/dd/yyyy');
      this.terminationTextBox.value = newVal;
      this.termination = newVal;
      this.clickTermination();
    }
  }
  keyPress(event: KeyboardEvent) {
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  }
  closeCalendar(fromName: string) {
    DateValidation.closeCal();
  }
  clickEffectiveFrom() {
    var result = false;
    var validMessage = true;
    var dateCheck;
    this.effectiveTextbox = document.getElementById('effectiveFrom');
    var bsValueEffective = this.effectiveTextbox.value;
    if (bsValueEffective != "Invalid Date") {
      if (bsValueEffective == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueEffective != null ? bsValueEffective : "")) {

        if (this.termination == null || this.termination == "") {
          result = true;
        }
        else {
          var startDate = new Date(this.effectiveFrom).setHours(0, 0, 0, 0);
          var endDate = new Date(this.termination).setHours(0, 0, 0, 0);
          if (endDate > startDate) {
            result = true;
          }
          else if (startDate >= endDate) {
            result = false;
            validMessage = false;
          } else {
            result = true;
          }
        }
      }
    }
    if (!result) {
      this.insuranceForm.patchValue({
        effectiveFrom: ""
      });
      this.effectiveTextbox.focus();
      this.effectiveFromErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Effective date should be lesser than termination date";
    } else {
      if (bsValueEffective != null) {
        this.bsValEffectiveFrom = new Date(bsValueEffective);
      }
      this.insuranceForm.controls['effectiveFrom'].setValue(bsValueEffective);
      this.effectiveFromErrorMessage = "";
    }
  }
  check() {
    if (this.termination == "" || this.termination == null) {
      this.terminationErrorMessage = "";
    }
  }
  clickTermination() {
    var result = false;
    var validMessage = true;
    var dateCheck;
    this.terminationTextBox = document.getElementById('termination');
    var bsValueTermination = this.terminationTextBox.value;
    if (bsValueTermination != "Invalid Date") {
      if (bsValueTermination == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueTermination != null ? bsValueTermination : "")) {
        if (this.effectiveFrom == null || this.effectiveFrom == "") {
          result = true;
        }
        else {
          var startDate = new Date(this.effectiveFrom).setHours(0, 0, 0, 0);
          var endDate = new Date(this.termination).setHours(0, 0, 0, 0);
          if (endDate > startDate) {
            result = true;
          }
          else if (startDate >= endDate) {
            result = false;
            validMessage = false;
          } else {
            result = true;
          }
        }
      }
    }
    if (!result) {
      if (bsValueTermination == "Invalid Date") {
        this.insuranceForm.patchValue({
          termination: ""
        });
      }
      this.terminationTextBox.focus();
      this.terminationErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Termination date should be greater than effective date.";
    } else {
      if (bsValueTermination != null) {
        this.bsValTermination = new Date(bsValueTermination);
      }
      this.insuranceForm.controls['termination'].setValue(bsValueTermination);
      this.terminationErrorMessage = "";
    }
  }
  isValidInsuranceDetails() {
    if (!this.insuranceForm?.valid) {
      this.emit();
      this.dataSharingService.ADInsurance.next(false);
    }
    else {
      this.saveInsuranceDetails(this.insuranceForm.value);
      this.dataSharingService.validateHouseholdForm.next(false);
    }
  }
  emit() {
    this.dataSharingService.advocateInsuranceSaveDetails = true;
    this.advocateInsuranceClicked.emit(true);
    this.dataSharingService.validateInsuranceStopForm.next(false);
  }
  saveInsuranceDetails(patientDetails: any) {
    sessionStorage.setItem('isInsuranceAvailable', patientDetails.insurance);
    if (patientDetails.insurance == '') {
      this.dataSharingService.validateInsuranceStopForm.next(false);
      this.insuranceErrorMessage = "Please select Yes/No! ";
      this.emit();
    }
    else if (patientDetails.insurance == "false") {
      this.dataSharingService.validateInsuranceStopForm.next(true);
      const second: QuestionAndAnswer[] = [
        {
          screenQuestionMappingId: +(this.insurancemappingId),
          questionId: +(this.insuranceQuestionId),
          optionId: this.insuranceOptionId,
          value: patientDetails.insurance,
          screenId: 5
        }
      ]
      if (this.QuestionAndAnswer == null) {
        this.QuestionAndAnswer = [];
        second.forEach(element => {
          this.QuestionAndAnswer.push(element);
        });
        sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
        this.forWardScreen();
      }
      else {
        patientDetails.effectiveFrom = new Date(patientDetails.effectiveFrom);
        var effectiveForm = patientDetails.effectiveFrom.toLocaleDateString("en-US", {
          year: "numeric",
          day: "2-digit",
          month: "2-digit",
        });
        var termination;
        if (patientDetails.termination != '' && patientDetails.termination != null) {
          patientDetails.termination = new Date(patientDetails.termination);
          termination = patientDetails.termination.toLocaleDateString("en-US", {
            year: "numeric",
            day: "2-digit",
            month: "2-digit",
          });
        }
        else {
          termination = null;
        }
        this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
        this.QuestionAndAnswer = this.QuestionAndAnswer.filter(e => e.screenId != 5)
        second.forEach(element => {
          this.QuestionAndAnswer.push(element);
        });
        sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
        this.forWardScreen();
      }
    }
    else if (patientDetails.insurance != '' && patientDetails.payerName != '' && patientDetails.groupName != '' && patientDetails.policyNumber != '' && patientDetails.groupNumber != '' && patientDetails.effectiveForm != ''
      && this.terminationErrorMessage == '' && this.effectiveFromErrorMessage == '') {
      this.dataSharingService.validateInsuranceStopForm.next(true);
      if (this.insuranceForm?.valid && (this.terminationErrorMessage == "" || this.terminationErrorMessage == null)) {
        this.validatePolicyNumberErrorMessage = false;
        this.insuranceDetailsMessageShow = true;
        patientDetails.effectiveFrom = new Date(patientDetails.effectiveFrom);
        var effectiveForm = patientDetails.effectiveFrom.toLocaleDateString("en-US", {
          year: "numeric",
          day: "2-digit",
          month: "2-digit",
        });
        var termination;
        if (patientDetails.termination != '' && patientDetails.termination != null) {
          patientDetails.termination = new Date(patientDetails.termination);
          var termination = patientDetails.termination.toLocaleDateString("en-US", {
            year: "numeric",
            day: "2-digit",
            month: "2-digit",
          });
        }
        else {
          termination = null;
        }
        const second: QuestionAndAnswer[] = [
          {
            screenQuestionMappingId: +(this.insurancemappingId),
            questionId: +(this.insuranceQuestionId),
            optionId: this.insuranceOptionId,
            value: patientDetails.insurance,
            screenId: 5
          },
          {
            screenQuestionMappingId: +(this.payerNamemappingId),
            questionId: +(this.payerNameQuestionId),
            optionId: null,
            value: patientDetails.payerName,
            screenId: 5
          },
          {
            screenQuestionMappingId: +(this.groupNameMappingId),
            questionId: +(this.groupNameQuestionId),
            optionId: null,
            value: patientDetails.groupName,
            screenId: 5
          },
          {
            screenQuestionMappingId: +(this.groupNoMappingId),
            questionId: +(this.groupNoQuestionId),
            optionId: null,
            value: patientDetails.groupNumber,
            screenId: 5
          },
          {
            screenQuestionMappingId: +(this.policyNoMappingId),
            questionId: +(this.policyNoQuestionId),
            optionId: null,
            value: patientDetails.policyNumber,
            screenId: 5
          },
          {
            screenQuestionMappingId: +(this.effectiveFromMappingId),
            questionId: +(this.effectiveFromQuestionId),
            optionId: null,
            value: effectiveForm,
            screenId: 5
          },
          {
            screenQuestionMappingId: +(this.terminationMappingId),
            questionId: +(this.terminationQuestionId),
            optionId: null,
            value: termination,
            screenId: 5
          }
        ]
        this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
        if (this.QuestionAndAnswer == null) {
          this.QuestionAndAnswer = [];
          this.QuestionAndAnswer = this.QuestionAndAnswer.filter(e => e.screenId != 5)
          second.forEach(element => {
            this.QuestionAndAnswer.push(element);
          });
          sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
          this.forWardScreen();
        }
        else {
          this.QuestionAndAnswer = this.QuestionAndAnswer.filter(e => e.screenId != 5)
          second.forEach(element => {
            this.QuestionAndAnswer.push(element);
          });
          sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
          this.forWardScreen();
        }
      }
    }
    else {
      if (patientDetails.payerName == '' || patientDetails.payerName == undefined) {
        this.payerNameErrorMessage = "Payer Name is required!";
        this.emit();
      }
      if (patientDetails.groupName == '' || patientDetails.groupName == undefined) {
        this.groupNameErrorMessage = "Group Name is required!";
        this.emit();
      }
      if (patientDetails.policyNumber == '' || patientDetails.policyNumber == undefined) {
        this.policyNumberErrorMessage = "Policy Number is required!";
        this.emit();
      }
      if (patientDetails.groupNumber == '' || patientDetails.groupNumber == undefined) {
        this.groupNumberErrorMessage = "Group Number is required!";
        this.emit();
      }
      if (patientDetails.effectiveFrom == '') {
        this.effectiveFromErrorMessage = "Effective From  is required!";
        this.emit();
      }
      if (patientDetails.effectiveFrom == undefined) {
        this.effectiveFromErrorMessage = "Effective From  is required!";
        this.emit();
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
      this.advocateHouseholdClicked.emit(true);
    }
    this.dataSharingService.advocateInsuranceSaveDetails = false;
    this.dataSharingService.setAdvocateInsuranceLoaderState(false);
    this.dataSharingService.ADInsurance.next(true);
    this.dataSharingService.completeInsurance.next("true");
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