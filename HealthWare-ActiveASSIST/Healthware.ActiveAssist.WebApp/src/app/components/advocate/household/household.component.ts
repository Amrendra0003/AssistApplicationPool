import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-household',
  templateUrl: './household.component.html',
  styleUrls: ['./household.component.css']
})
export class HouseholdComponent implements OnInit {
  householdForm: any;
  isHouseholdEmployed: any = 'true';
  programServices: any;
  noOfHousehold: any = '1';
  minorChildren: any = '0';
  householdIncome: any = "0";
  incomePayPeriod: any = StringConstants.common.yearly + "_" + 31;
  householdResources: any = "0";
  grossPayPeriodVal: any;
  public count = 1;
  public mcount = 0;
  programs: any;
  noOfHouseholdMappingId: any;
  noOfHouseholdQuestionId: any;
  minorChildrenMappingId: any;
  minorChildrenQuestionId: any;
  isEmpMappingId: any;
  isEmpQuestionId: any;
  isEmpOptionId: any;
  otherMemberMappingId: any;
  otherMemberQuestionId: any;
  otherMemberOptionId: any;
  programMappingId: any;
  programQuestionId: any;
  programOptionId: any;
  estimateIncomeMappingId: any;
  estimateIncomeQuestionId: any;
  estimateResoureceMappingId: any;
  estimateResoureceQuestionId: any;
  incomePayMappingId: any;
  incomePayQuestionId: any;
  incomePayOptionId: any;
  incomePayOptions: any;
  programServicesOptions: any;
  optionValues: any;
  QuestionAndAnswer: QuestionAndAnswer[] = [];
  isEmployedRequiredMessage: string = "";
  noOfHouseHoldRequiredMessage: string = "";
  minorChilrdrenRequiredMessage: string = "";
  isHouseholdEmployedRequiredMessage: string = "";
  @Output() advocateGeneralQuestionClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() advocateHouseholdClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  getQuestionAndAnswer: QuestionAndAnswer[] = [];
  bindGetQuestionAndAnswer: QuestionAndAnswer[] = [];
  householdGetQuestionAndAnswer: QuestionAndAnswer[] = [];
  householdIncomeRequiredMessage: string = "";
  householdResourcesRequiredMessage: string = "";
  householdGrossPayRequiredMessage: string = "";
  noOfHouseHoldCountRequiredMessage: string = "";
  currentTheme: any;
  calFresh: any;
  ssi: any;
  calWorks: any;
  refugeeAssisstance: any;
  allOfTheAbove: any;
  values: any = [];
  HouseholdInfo = StringConstants.household.HouseholdInfo;
  HouseholdInfoMsg1 = StringConstants.household.HouseholdInfoMsg1;
  HouseholdInfoMsg2 = StringConstants.household.HouseholdInfoMsg2;
  TotalNumLiving = StringConstants.household.TotalNumLiving;
  MinorChildren = StringConstants.household.MinorChildren;
  HouseholdEmployedQue = StringConstants.household.HouseholdEmployedQue;
  PatientCurrently = StringConstants.household.PatientCurrently;
  ProgramsReq = StringConstants.household.ProgramsReq;
  HouseholdIncomeAndResources = StringConstants.household.HouseholdIncomeAndResources;
  EstimatedHouseholdIncome = StringConstants.household.EstimatedHouseholdIncome;
  IncomeErr = StringConstants.household.IncomeErr;
  IncomeErrExceed = StringConstants.household.IncomeErrExceed;
  GrossPay = StringConstants.household.GrossPay;
  EstimatedHousehold = StringConstants.household.EstimatedHousehold;
  ResourceAcceptsNumbers = StringConstants.household.ResourceAcceptsNumbers;
  Next = StringConstants.household.Next;
  checkboxQuestionAndAnswer: QuestionAndAnswer[] = [];
  result: any;
  nextScreen: any;
  constructor(private dropdownService: DropdownService, private toastService: ToastServiceService, private dataSharingService: DataSharingService, private quickAssessmentService: QuickAssessmentService) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.validateHouseholdForm.subscribe(value => {
      if (value == true) {
        this.isValidHouseholdDetails();
      }
    });
  }
  ngOnInit(): void {
    window.scroll(0, 0);
    this.initForm();
    this.getGrossPayPeriod();
    this.getAssessmentDetails();
    this.getQuestionAndAnswer = JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!);
    if (this.getQuestionAndAnswer != null) {
      this.bindGetQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 6);
      if (this.bindGetQuestionAndAnswer.length != 0) {
        this.noOfHousehold = this.bindGetQuestionAndAnswer[0].value;
        this.minorChildren = this.bindGetQuestionAndAnswer[1].value;
        this.isHouseholdEmployed = this.bindGetQuestionAndAnswer[2].value;
        this.programServices = this.bindGetQuestionAndAnswer[3].value + "_" + this.bindGetQuestionAndAnswer[3].optionId;
      }
      this.householdGetQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 7);
      if (this.householdGetQuestionAndAnswer.length != 0) {
        this.householdIncome = this.householdGetQuestionAndAnswer[0].value;
        this.incomePayPeriod = this.householdGetQuestionAndAnswer[1].value + "_" + this.householdGetQuestionAndAnswer[1].optionId;
        this.householdResources = this.householdGetQuestionAndAnswer[2].value;
      }
    }
    else {
      this.householdIncome = "0";
      this.incomePayPeriod = StringConstants.common.yearly + "_" + 31;;
      this.householdResources = "0";
      this.noOfHousehold = 1;
      this.minorChildren = 0;
      this.isHouseholdEmployed = 'true';
      this.programServices = "";
      this.calFresh = "";
      this.ssi = "";
      this.calWorks = "";
      this.refugeeAssisstance = "";
      this.allOfTheAbove = "";
    }
    this.dataSharingService.getAdvocateHouseholdLoaderState().subscribe(e => {
      if (e != false) {
        this.nextScreen = e;
        this.navigateToGeneralQuestions(this.householdForm.value);
      }
      else if (e == false) {
        this.nextScreen = e;
      }
    });
  }
  private initForm() {
    this.householdForm = new FormGroup({
      'isHouseholdEmployed': new FormControl('true', [Validators.required]),
      'noOfHousehold': new FormControl('1', [Validators.required]),
      'programServices': new FormControl(''),
      'minorChildren': new FormControl('0', [Validators.required]),
      'householdIncome': new FormControl('0', [Validators.pattern('^[0-9]+([,.][0-9]+)?$'), Validators.max(50000)]),
      'incomePayPeriod': new FormControl(StringConstants.common.yearly + "_" + 31),
      'householdResources': new FormControl('0', [Validators.pattern('^[0-9]+([,.][0-9]+)?$'), Validators.max(50000)]),
      'calFresh': new FormControl(''),
      'ssi': new FormControl(''),
      'calWorks': new FormControl(''),
      'refugeeAssisstance': new FormControl(''),
      'allOfTheAbove': new FormControl(''),
    });
  }
  validate(type: string) {
    var val;
    if (type == 'income')
      var temp = this.householdForm.get('householdIncome').value;
    else if (type == 'resource')
      var temp = this.householdForm.get('householdResources').value;
    let testRegex = /^[0-9]+([,.][0-9]+)?$/;
    var check = testRegex.test(temp);
    if (check == true) {
      val = Math.round(Number(temp) * 100) / 100;
      val = val.toString();
      if (type == "income")
        this.householdForm.controls['householdIncome'].setValue(val);
      else if (type == "resource")
        this.householdForm.controls['householdResources'].setValue(val);
    }
    else {
      if (type == "income")
        this.householdForm.controls['householdIncome'].setValue(temp);
      else if (type == "resource")
        this.householdForm.controls['householdResources'].setValue(temp);
    }
  }
  getGrossPayPeriod() {
    this.dropdownService.GetGrossPayPeriod().subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.grossPayPeriodVal = result.data;
      }
    }, (error) => {
      console.log(error)
    });
  }
  getProgramServices() {
    let data = [
      {
        "value": "Call Works"
      },
      {
        "value": "SSI/SP"
      },
      {
        "value": "All the above"
      },
      {
        "value": "Call Fresh"
      }
    ]
    this.programs = data;
  }
  isHouseholdMemberEmployed(isEmp: any) {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    this.isEmployedRequiredMessage = "";
    this.isHouseholdEmployedRequiredMessage = "";
  }
  increment() {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    this.count += 1;
    this.noOfHousehold = this.count;
    this.noOfHouseHoldRequiredMessage = "";
  }
  decrement() {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    if (this.count > 1) this.count -= 1;
    this.noOfHousehold = this.count;
    this.noOfHouseHoldRequiredMessage = "";
  }
  mincrement() {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    this.mcount += 1;
    this.minorChildren = this.mcount;
    this.minorChilrdrenRequiredMessage = "";
  }
  mdecrement() {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    if (this.mcount > 0) this.mcount -= 1;
    this.minorChildren = this.mcount;
    this.minorChilrdrenRequiredMessage = "";
    this.noOfHouseHoldCountRequiredMessage = "";
  }
  OnChangeProgramServices(programServices: any) {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
  }
  onChangeValue(event: any, optionId: any, screenQuestionMappingId: any, questionId: any, keyName: any) {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    this.checkboxQuestionAndAnswer = (JSON.parse(sessionStorage.getItem('checkboxQuestionAndAnswer')!));
    if (this.checkboxQuestionAndAnswer == null) {
      this.checkboxQuestionAndAnswer = [];
    }
    if (event.target.checked) {
      const second: QuestionAndAnswer[] = [
        {
          screenQuestionMappingId: +(screenQuestionMappingId),
          questionId: +(questionId),
          optionId: (optionId),
          value: event.target.value,
          screenId: 6
        }
      ]
      second.forEach(element => {
        this.checkboxQuestionAndAnswer.push(element);
      });
      sessionStorage.setItem('checkboxQuestionAndAnswer', JSON.stringify(this.checkboxQuestionAndAnswer));
    }
    else {
      this.checkboxQuestionAndAnswer = this.checkboxQuestionAndAnswer.filter(x => x.optionId !== optionId);
      sessionStorage.setItem('checkboxQuestionAndAnswer', JSON.stringify(this.checkboxQuestionAndAnswer));
    }
  }
  getAssessmentDetails() {
    this.quickAssessmentService.getQuickAssessmentDetails().subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.result = result.data.screen[5].questions;
        this.noOfHouseholdMappingId = result.data.screen[5].questions[1].screenQuestionMappingId;
        this.noOfHouseholdQuestionId = result.data.screen[5].questions[1].id;
        this.minorChildrenMappingId = result.data.screen[5].questions[2].screenQuestionMappingId;
        this.minorChildrenQuestionId = result.data.screen[5].questions[2].id;
        this.isEmpMappingId = result.data.screen[5].questions[3].screenQuestionMappingId;
        this.isEmpQuestionId = result.data.screen[5].questions[3].id;
        this.isEmpOptionId = result.data.screen[5].questions[3].options[1].id;
        this.otherMemberMappingId = result.data.screen[5].questions[3].subQuestion.question[0].screenQuestionMappingId;
        this.otherMemberQuestionId = result.data.screen[5].questions[3].subQuestion.question[0].id;
        this.otherMemberOptionId = result.data.screen[5].questions[3].subQuestion.question[0].options[1].id;
        this.programMappingId = result.data.screen[5].questions[3].subQuestion.question[0].subQuestion.question[0].screenQuestionMappingId;
        this.programQuestionId = result.data.screen[5].questions[3].subQuestion.question[0].subQuestion.question[0].id;
        this.programOptionId = result.data.screen[5].questions[3].subQuestion.question[0].subQuestion.question[0].options[0].id;
        this.programServicesOptions = result.data.screen[5].questions[3].subQuestion.question[0].subQuestion.question[0].options;
        this.estimateIncomeMappingId = result.data.screen[6].questions[1].screenQuestionMappingId;
        this.estimateIncomeQuestionId = result.data.screen[6].questions[1].id;
        this.estimateResoureceMappingId = result.data.screen[6].questions[3].screenQuestionMappingId;
        this.estimateResoureceQuestionId = result.data.screen[6].questions[3].id;
        this.incomePayMappingId = result.data.screen[6].questions[2].screenQuestionMappingId;
        this.incomePayQuestionId = result.data.screen[6].questions[2].id;
        this.incomePayOptions = result.data.screen[6].questions[2].options;
        this.bindGetQuestionAndAnswer = this.getQuestionAndAnswer.filter(word => word.screenId == 6);
        if (this.bindGetQuestionAndAnswer.length != 0) {
          for (let questionIndex in this.result) {
            for (let subQuestions in this.result[questionIndex].subQuestion?.question) {
              for (let nestedIndex of this.result[questionIndex].subQuestion?.question[subQuestions].subQuestion?.question) {
                for (let selectedValue in this.bindGetQuestionAndAnswer) {
                  for (let optionsIndex of nestedIndex.options) {
                    if (optionsIndex.id == this.bindGetQuestionAndAnswer[selectedValue].optionId) {
                      if (optionsIndex.name == "calFresh") {
                        this.values[optionsIndex.name] = "calFresh";
                      }
                      else if (optionsIndex.name == "calWorks") {
                        this.values[optionsIndex.name] = "calWorks";
                      }
                      else if (optionsIndex.name == "ssi") {
                        this.values[optionsIndex.name] = "ssi";
                      }
                      else if (optionsIndex.name == "refugeeAssisstance") {
                        this.values[optionsIndex.name] = "Refugee Assistance"
                      }
                      else if (optionsIndex.name == "allOfTheAbove") {
                        this.values[optionsIndex.name] = "All of the above";
                      }
                      break;
                    }
                  }
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
  onKey(event: any) {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    if (this.householdIncome != '')
      this.householdIncomeRequiredMessage = "";
    if (this.incomePayPeriod != '')
      this.householdGrossPayRequiredMessage = "";
    if (this.householdResources != '')
      this.householdResourcesRequiredMessage = "";
  }
  isValidHouseholdDetails() {
    if (!this.householdForm.valid) {
      this.emit();
      this.dataSharingService.ADHousehold.next(false);
    }
    else {
      this.navigateToGeneralQuestions(this.householdForm.value);
      this.dataSharingService.validateInsuranceForm.next(false);
    }
  }
  emit() {
    this.dataSharingService.advocateHouseholdSaveDetails = true;
    this.advocateHouseholdClicked.emit(true);
    this.dataSharingService.validateHouseholdStopForm.next(false);
  }
  navigateToGeneralQuestions(patientDetails: any) {
    if (patientDetails.householdIncome != "" && (this.noOfHousehold >= this.minorChildren) && patientDetails.householdResources != "" && patientDetails.incomePayPeriod != "" && patientDetails.isHouseholdEmployed != "" && (this.programServices == undefined || this.programServices == "" || this.programServices != "")) {
      this.dataSharingService.validateHouseholdStopForm.next(true);
      if (patientDetails.programServices == undefined) {
      }
      else {
        const programs = patientDetails.programServices;
        var programsArray = programs.split('_');
        if (programsArray) {
          this.programOptionId = programsArray[1];
          patientDetails.serviceProgram = programsArray[0];
        }
      }
      const grossPayPeriod = patientDetails.incomePayPeriod;
      var grossPayPeriodArray = grossPayPeriod.split('_');
      const household: QuestionAndAnswer[] = [
        {
          screenQuestionMappingId: +(this.noOfHouseholdMappingId),
          questionId: +(this.noOfHouseholdQuestionId),
          optionId: null,
          value: this.noOfHousehold.toString(),
          screenId: 6
        },
        {
          screenQuestionMappingId: +(this.minorChildrenMappingId),
          questionId: +(this.minorChildrenQuestionId),
          optionId: null,
          value: this.minorChildren.toString(),
          screenId: 6
        },
        {
          screenQuestionMappingId: +(this.otherMemberMappingId),
          questionId: +(this.otherMemberQuestionId),
          optionId: (this.otherMemberOptionId),
          value: patientDetails.isHouseholdEmployed,
          screenId: 6
        },
        {
          screenQuestionMappingId: +(this.estimateIncomeMappingId),
          questionId: +(this.estimateIncomeQuestionId),
          optionId: null,
          value: patientDetails.householdIncome,
          screenId: 7
        },
        {
          screenQuestionMappingId: +(this.incomePayMappingId),
          questionId: +(this.incomePayQuestionId),
          optionId: grossPayPeriodArray[1],
          value: grossPayPeriodArray[0],
          screenId: 7
        },
        {
          screenQuestionMappingId: +(this.estimateResoureceMappingId),
          questionId: +(this.estimateResoureceQuestionId),
          optionId: null,
          value: patientDetails.householdResources,
          screenId: 7
        },
      ]
      this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
      if (this.QuestionAndAnswer == null) {
        this.QuestionAndAnswer = [];
        household.forEach(element => {
          this.QuestionAndAnswer.push(element);
        });
        this.checkboxQuestionAndAnswer = (JSON.parse(sessionStorage.getItem('checkboxQuestionAndAnswer')!));
        if (this.checkboxQuestionAndAnswer != null) {
          this.checkboxQuestionAndAnswer.forEach(checkbox => {
            this.QuestionAndAnswer.push(checkbox);
          })
        }
        sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
        this.forWardScreen();
      }
      else {
        this.QuestionAndAnswer = this.QuestionAndAnswer.filter((e) => (e.screenId != 6 && e.screenId != 7));
        household.forEach(element => {
          this.QuestionAndAnswer.push(element);
        });
        this.checkboxQuestionAndAnswer = (JSON.parse(sessionStorage.getItem('checkboxQuestionAndAnswer')!));
        if (this.checkboxQuestionAndAnswer != null) {
          this.checkboxQuestionAndAnswer.forEach(checkbox => {
            this.QuestionAndAnswer.push(checkbox);
          })
        }
        sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
        this.forWardScreen();
      }
    }
    else {
      if (this.minorChildren.toString() == '') {
        this.minorChilrdrenRequiredMessage = "Children count required!";
        this.emit();
      }
      if (this.noOfHousehold.toString() == '' && this.noOfHousehold > 1) {
        this.noOfHouseHoldRequiredMessage = "Household Member count required!";
        this.emit();
      }
      if (patientDetails.isEmployed == '') {
        this.isEmployedRequiredMessage = "Employed status required!";
        this.emit();
      }
      if (this.isHouseholdEmployed == true && patientDetails.isHouseholdEmployed == '') {
        this.isHouseholdEmployedRequiredMessage = "Household members employed status required!";
        this.emit();
      }
      if (patientDetails.householdIncome == '' || patientDetails.householdIncome == undefined) {
        this.householdIncomeRequiredMessage = "Income  is required!";
        this.emit();
      }
      if (patientDetails.householdResources == '' || patientDetails.householdResources == undefined) {
        this.householdResourcesRequiredMessage = "Resource is required!";
        this.emit();
      }
      if (patientDetails.incomePayPeriod == "") {
        this.householdGrossPayRequiredMessage = "Gross Pay is required!";
        this.emit();
      }
      if (this.noOfHousehold < this.minorChildren) {
        this.noOfHouseHoldCountRequiredMessage = "Minor's count can't exceed household count";
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
      this.advocateGeneralQuestionClicked.emit(true);
    }
    this.dataSharingService.advocateHouseholdSaveDetails = false;
    this.dataSharingService.setAdvocateHouseholdLoaderState(false);
    this.dataSharingService.ADHousehold.next(true);
    this.dataSharingService.completeHousehold.next("true");
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