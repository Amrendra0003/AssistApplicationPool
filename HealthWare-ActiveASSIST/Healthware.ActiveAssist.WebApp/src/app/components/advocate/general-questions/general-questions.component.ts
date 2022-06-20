import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-general-questions',
  templateUrl: './general-questions.component.html',
  styleUrls: ['./general-questions.component.css']
})
export class GeneralQuestionsComponent implements OnInit {
  generalQuestionsForm: any;
  QuestionAndAnswer: QuestionAndAnswer[] = [];
  result: any;
  form!: FormGroup;
  payLoad = '';
  optionType: any;
  leftContent: any;
  leftTitle: any;
  isButtonYes: boolean = false;
  products: any = [];
  public count = 0;
  serviceProgramMappingId: any;
  serviceProgramQuestionId: any;
  serviceProgramOptionId: any;
  healthConditionMappingId: any;
  healthConditionQuestionId: any;
  healthConditionOptionId: any;
  beenInjuredMappingId: any;
  beenInjuredQuestionId: any;
  beenInjuredOptionId: any;
  reportFiledMappingId: any;
  reportFiledQuestionId: any;
  reportFiledOptionId: any;
  getQuestionAndAnswer: QuestionAndAnswer[] = [];
  bindGetQuestionAndAnswer: QuestionAndAnswer[] = [];
  serviceProgram: any = "";
  healthCondition: any;
  beenInjured: any;
  reportFiled: any = 'false';
  toShowHealthConditions: boolean = false;
  toShowHasInjured: boolean = false;
  toShowReportFiled: boolean = false;
  toShowServiceProgramRequired: string = "";
  toShowHealthConditionRequired: string = "";
  toShowHaveBeenInjured: string = "";
  virtualAssistPadding: string = "virtual-assist-padding";
  patient: any;
  serviceProgramNextButton: boolean = true;
  healthConditionNextButton: boolean = false;
  proceedButton: boolean = false;
  currentTheme: any;
  pregnantNow: any;
  veteran: any;
  memberOfIndianTribe: any;
  formerFosterYouth: any;
  deemed: any;
  inCrime: any;
  inMotorVehicle: any;
  onTheJob: any;
  reportFiledCrime: any = 'false';
  reportFiledMotor: any = 'false';
  reportFiledJob: any = 'false';
  toShowCrimeReportFiled: boolean = false;
  toShowMotorVehicleReportFiled: boolean = false;
  toShowJobReportFiled: boolean = false;
  toggleOptionId: any;
  toggleValue: any;
  values: any = [];
  nextScreen: any;
  GeneralInfo1 = StringConstants.generalQuestion.GeneralInfo1;
  GeneralInfo2 = StringConstants.generalQuestion.GeneralInfo2;
  Next = StringConstants.common.nextLabel;
  @Output() advocateSsnClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(private quickAssessmentService: QuickAssessmentService, private router: Router, private dataSharingService: DataSharingService) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit(): void {
    window.scroll(0, 0);
    this.getAssessmentDetails();
    this.initForm();
    this.getQuestionAndAnswer = JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!);
    if (this.getQuestionAndAnswer != null) {
      this.bindGetQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 8);
      let firstScreen = this.getQuestionAndAnswer.filter(word => word.screenId == 1);
      if (firstScreen.length != 0) {
        let optionValue = firstScreen[0].value.toLowerCase();
        this.patient = optionValue;
      }
    }
    this.dataSharingService.getAdvocateGeneralQuestionsLoaderState().subscribe(e => {
      if (e != false) {
        this.nextScreen = e;
        this.nextToSSNScreen(this.generalQuestionsForm.value);
      }
      else if (e == false) {
        this.nextScreen = e;
      }
    });
  }
  private initForm() {
    this.generalQuestionsForm = new FormGroup({
      'pregnantNow': new FormControl(''),
      'veteran': new FormControl(''),
      'memberOfIndianTribe': new FormControl(''),
      'formerFosterYouth': new FormControl(''),
      'deemed': new FormControl(''),
      'you/member': new FormControl(''),
      'inCrime': new FormControl(''),
      'inMotorVehicle': new FormControl(''),
      'onTheJob': new FormControl(''),
      'reportFiledCrime': new FormControl(''),
      'reportFiledMotor': new FormControl(''),
      'reportFiledJob': new FormControl('')
    });
  }
  increment() {
    this.count += 1;
  }
  decrement() {
    this.count -= 1;
  }
  onChangeValue(event: any, subQuestion: any, optionId: any, screenQuestionMappingId: any, questionId: any, keyName: any) {
    this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
    if (event.target.checked) {
      if (this.QuestionAndAnswer == null) {
        this.QuestionAndAnswer = [];
      }
      const second: QuestionAndAnswer[] = [
        {
          screenQuestionMappingId: +(screenQuestionMappingId),
          questionId: +(questionId),
          optionId: (optionId),
          value: event.target.value,
          screenId: 8
        }
      ]
      second.forEach(element => {
        this.QuestionAndAnswer.push(element);
      });
      if (subQuestion.length > 0 && event.target.checked) {
        if (keyName == 'inCrime') {
          this.toShowCrimeReportFiled = true;
          this.reportFiledCrime = 'false';
          const subAnswer: QuestionAndAnswer[] = [
            {
              screenQuestionMappingId: +(subQuestion[0].screenQuestionMappingId),
              questionId: +(subQuestion[0].id),
              optionId: (subQuestion[0].options[0].id),
              value: 'false',
              screenId: 8
            }
          ]
          subAnswer.forEach(element => {
            this.QuestionAndAnswer.push(element);
          });
        }
        else if (keyName == 'inMotorVehicle') {
          this.toShowMotorVehicleReportFiled = true;
          this.reportFiledMotor = 'false';
          const subAnswer: QuestionAndAnswer[] = [
            {
              screenQuestionMappingId: +(subQuestion[1].screenQuestionMappingId),
              questionId: +(subQuestion[1].id),
              optionId: (subQuestion[1].options[0].id),
              value: 'false',
              screenId: 8
            }
          ]
          subAnswer.forEach(element => {
            this.QuestionAndAnswer.push(element);
          });
        }
        else if (keyName == 'onTheJob') {
          this.toShowJobReportFiled = true;
          this.reportFiledJob = 'false';
          const subAnswer: QuestionAndAnswer[] = [
            {
              screenQuestionMappingId: +(subQuestion[2].screenQuestionMappingId),
              questionId: +(subQuestion[2].id),
              optionId: (subQuestion[2].options[0].id),
              value: 'false',
              screenId: 8
            }
          ]
          subAnswer.forEach(element => {
            this.QuestionAndAnswer.push(element);
          });
        }
      }
      sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
    }
    else {
      this.QuestionAndAnswer = this.QuestionAndAnswer.filter(x => x.optionId !== optionId);
      {
        if (subQuestion.length > 0) {
          if (keyName == 'inCrime') {
            this.toShowCrimeReportFiled = false;
            this.reportFiledCrime = 'false';
            this.QuestionAndAnswer = this.QuestionAndAnswer.filter(x => x.questionId !== +(subQuestion[0].id));
          }
          else if (keyName == 'inMotorVehicle') {
            this.toShowMotorVehicleReportFiled = false;
            this.reportFiledMotor = 'false';
            this.QuestionAndAnswer = this.QuestionAndAnswer.filter(x => x.questionId !== +(subQuestion[1].id));
          }
          else if (keyName == 'onTheJob') {
            this.toShowJobReportFiled = false;
            this.reportFiledJob = 'false';
            this.QuestionAndAnswer = this.QuestionAndAnswer.filter(x => x.questionId !== +(subQuestion[2].id));
          }
        }
      }
      sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
    }
  }
  wasReportFiledChange(event: any, falseId: any, trueId: any, screenQuestionMappingId: any, questionId: any) {
    this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
    if (event.target.innerText == 'Yes') {
      this.toggleOptionId = trueId;
      this.toggleValue = "true";
    }
    else if (event.target.innerText == 'No') {
      this.toggleOptionId = falseId;
      this.toggleValue = "false";
    }
    var hasData = this.QuestionAndAnswer.filter(x => x.questionId == questionId);
    if (hasData.length > 0) {
      this.QuestionAndAnswer = this.QuestionAndAnswer.filter(x => x.questionId != questionId);
    }
    const second: QuestionAndAnswer[] = [
      {
        screenQuestionMappingId: +(screenQuestionMappingId),
        questionId: +(questionId),
        optionId: (this.toggleOptionId),
        value: this.toggleValue,
        screenId: 8
      }
    ]
    second.forEach(element => {
      this.QuestionAndAnswer.push(element);
    });
    sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
  }
  OnChangeServiceProgram(value: any) {
    this.toShowHealthConditions = true;
    this.healthConditionNextButton = true;
    this.serviceProgramNextButton = false;
    this.toShowServiceProgramRequired = "";
  }
  OnChangeHealthConditions(value: any) {
    this.toShowHealthConditions = true;
    this.toShowHasInjured = true;
    this.healthConditionNextButton = false;
    this.serviceProgramNextButton = false;
    this.proceedButton = true
    this.toShowHealthConditionRequired = "";
  }
  OnChangeHasInjured(value: any) {
    this.toShowHealthConditions = true;
    this.toShowHasInjured = true;
    let isBeenInjuredValue = value.replace(/\s/g, "");
    let val = isBeenInjuredValue.toLowerCase();
    this.toShowServiceProgramRequired = "";
    this.toShowHealthConditionRequired = "";
    this.toShowHaveBeenInjured = "";
    if (val == "inmotorvehicleaccident") {
      this.toShowReportFiled = true;
      this.reportFiled = 'false';
    }
    else {
      this.toShowReportFiled = false;
    }
  }
  getAssessmentDetails() {
    this.quickAssessmentService.getQuickAssessmentDetails().subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.result = result.data.screen[7].questions;
        this.leftContent = result.data.screen[7].leftDescription;
        this.leftTitle = result.data.screen[7].leftPanelContent;
        this.serviceProgramMappingId = result.data.screen[7].questions[0].screenQuestionMappingId;
        this.serviceProgramQuestionId = result.data.screen[7].questions[0].id;
        this.serviceProgramOptionId = result.data.screen[7].questions[0].options[1].id;
        this.healthConditionMappingId = result.data.screen[7].questions[1].screenQuestionMappingId;
        this.healthConditionQuestionId = result.data.screen[7].questions[1].id;
        this.healthConditionOptionId = result.data.screen[7].questions[1].options[1].id;
        this.beenInjuredMappingId = result.data.screen[7].questions[2].screenQuestionMappingId;
        this.beenInjuredQuestionId = result.data.screen[7].questions[2].id;
        this.beenInjuredOptionId = result.data.screen[7].questions[2].options[1].id;
        this.reportFiledMappingId = result.data.screen[7].questions[2].subQuestion.question[0].screenQuestionMappingId;
        this.reportFiledQuestionId = result.data.screen[7].questions[2].subQuestion.question[0].id;
        this.reportFiledOptionId = result.data.screen[7].questions[2].subQuestion.question[0].options[1].id;
        this.getQuestionAndAnswer = JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!);
        if (this.getQuestionAndAnswer != null) {
          for (let questionIndex in this.result) {
            for (let optionsIndex in this.result[questionIndex].options) {
              for (let selectedValue in this.bindGetQuestionAndAnswer) {
                this.values[this.result[questionIndex].options[optionsIndex].name] = false;
                if (this.result[questionIndex].options[optionsIndex].id == this.bindGetQuestionAndAnswer[selectedValue].optionId) {
                  this.values[this.result[questionIndex].options[optionsIndex].name] = true;
                  if (this.result[questionIndex].keyName === "serviceProgram") {
                    this.toShowHealthConditions = true;
                    this.healthConditionNextButton = true;
                    this.serviceProgramNextButton = false;
                    this.toShowServiceProgramRequired = "";
                  }
                  else if (this.result[questionIndex].keyName === "healthConditiion") {
                    this.toShowHealthConditions = true;
                    this.toShowHasInjured = true;
                    this.healthConditionNextButton = false;
                    this.serviceProgramNextButton = false;
                    this.proceedButton = true
                    this.toShowHealthConditionRequired = "";
                  }
                  if (this.result[questionIndex].keyName === "beenInjured") {
                    this.toShowHealthConditions = true;
                    this.toShowHasInjured = true;
                    this.toShowServiceProgramRequired = "";
                    this.toShowHealthConditionRequired = "";
                    this.toShowHaveBeenInjured = "";
                  }
                  if (this.result[questionIndex].options[optionsIndex].name == 'inCrime') {
                    this.toShowCrimeReportFiled = true;
                    var val = this.bindGetQuestionAndAnswer.filter(s => s.questionId == this.result[questionIndex].subQuestion.question[optionsIndex].id);
                    if (val.length > 0)
                      this.reportFiledCrime = val[0].value;
                  }
                  else if (this.result[questionIndex].options[optionsIndex].name == 'inMotorVehicle') {
                    this.toShowMotorVehicleReportFiled = true;
                    var val = this.bindGetQuestionAndAnswer.filter(s => s.questionId == this.result[questionIndex].subQuestion.question[optionsIndex].id);
                    if (val.length > 0)
                      this.reportFiledMotor = val[0].value;
                  }
                  else if (this.result[questionIndex].options[optionsIndex].name == 'onTheJob') {
                    this.toShowJobReportFiled = true;
                    var val = this.bindGetQuestionAndAnswer.filter(s => s.questionId == this.result[questionIndex].subQuestion.question[optionsIndex].id);
                    if (val.length > 0)
                      this.reportFiledJob = val[0].value;
                  }
                  break;
                }
              }
            }
          }
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  buttonClick(button: any) {
    if (button == 'Yes')
      this.isButtonYes = true;
    else
      this.isButtonYes = false;
  }
  backToHouseholdIncome() {
    this.router.navigate(['household-income']);
  }
  nextToSSNScreen(patientDetails: any) {
    this.forWardScreen();
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
      this.advocateSsnClicked.emit(true);
    }
    this.dataSharingService.setAdvocateGeneralQuestionsLoaderState(false);
    this.dataSharingService.advocateGeneralQuestionsSaveDetails = false;
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