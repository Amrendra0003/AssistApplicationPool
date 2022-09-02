import { DatePipe } from '@angular/common';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ChangeDetectionStrategy, Component, ElementRef, Input, OnInit } from '@angular/core';
import { AbstractControlOptions, FormArray, FormBuilder, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { ApiConstants } from '../../../../assets/constants/url'
import { environment } from 'src/environments/environment';
import { DashboardService } from 'src/app/services/dashboard.service';
import 'lodash';
import { StringConstants } from 'src/assets/constants/string.constants';
import DateValidation from '../../controls/date-validation-control';
import { MatDialog } from '@angular/material/dialog';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { Subject } from 'rxjs';
import { CommonService } from 'src/app/services/common.service';

export interface CountyOption {
  id: string;
  name: string;
  order: number;
  value: string;
}
export interface NestedSubQuestioncountyOption {
  id: string;
  name: string;
  order: number;
  value: string;
}
export interface NestedSubQuestionoption {
  id: string;
  name: string;
  order: number;
  value: string;
}
export interface NestedSubQuestionvalidators {
  required: boolean;
  minLength: number;
  maxLength: number;
  pattern: string;
}
export interface SubNestedSubQuestion {
  type: string;
  screenHeaderPatientLabel: string,
  screenHeaderOthersLabel: string,
  patientLabel: string;
  othersLabel: string;
  textboxSubLabel: string;
  uniqueKey: string;
  value: string;
  class: string;
  screenId: string;
  orderId: string;
  placeholder: string;
  screenMappingId: string;
  questionId: string;
  required: boolean;
  customValidation: string;
  alertInfo: string;
  messageInfo: string;
  errorMessageInfo: string;
  maximumDate: string;
  isInlineLabel: boolean;
  inlineLabel: string;
  countyOptions: SubQuestioncountyOption[];
  options: SubQuestionoption[];
  validators: QuestionValidators;
}
export interface NestedSubQuestion {
  type: string;
  screenHeaderPatientLabel: string,
  screenHeaderOthersLabel: string,
  patientLabel: string;
  othersLabel: string;
  textboxSubLabel: string;
  uniqueKey: string;
  value: string;
  class: string;
  screenId: string;
  orderId: string;
  placeholder: string;
  screenMappingId: string;
  questionId: string;
  required: boolean;
  customValidation: string;
  alertInfo: string;
  messageInfo: string;
  errorMessageInfo: string;
  maximumDate: string;
  isInlineLabel: boolean;
  inlineLabel: string;
  fieldName: string;
  subQuestion: SubNestedSubQuestion[];
  nestedSubQuestioncountyOptions: NestedSubQuestioncountyOption[];
  options: NestedSubQuestionoption[];
  validators: NestedSubQuestionvalidators;
}
export interface SubQuestioncountyOption {
  id: string;
  name: string;
  order: number;
  value: string;
}
export interface SubQuestionoption {
  id: string;
  name: string;
  order: number;
  value: string;
}
export interface SubQuestionValidators {
  required: boolean;
  minLength: number;
  maxLength: number;
  max: any;
  min: any;
  pattern: string;
}
export interface SubQuestion {
  type: string;
  screenHeaderPatientLabel: string,
  screenHeaderOthersLabel: string,
  patientLabel: string;
  othersLabel: string;
  textboxSubLabel: string;
  uniqueKey: string;
  value: string;
  class: string;
  screenId: string;
  orderId: string;
  placeholder: string;
  screenMappingId: string;
  questionId: string;
  required: boolean;
  customValidation: string;
  alertInfo: string;
  messageInfo: string;
  errorMessageInfo: string;
  maximumDate: string;
  isInlineLabel: boolean;
  inlineLabel: string;
  fieldName: string;
  subQuestion: NestedSubQuestion[];
  countyOptions: SubQuestioncountyOption[];
  options: SubQuestionoption[];
  validators: QuestionValidators;
}
export interface Option {
  id: string;
  name: string;
  order: number;
  value: string;
}
export interface QuestionValidators {
  required: boolean;
  minLength: number;
  maxLength: number;
  max: any;
  min: any;
  pattern: string;
}
export interface JsonFormControls {
  type: string;
  screenHeaderPatientLabel: string;
  screenHeaderOthersLabel: string,
  patientLabel: string;
  othersLabel: string;
  textBoxSubLabel: string;
  uniqueKey: string;
  value: string;
  class: string;
  screenId: string;
  orderId: string;
  placeholder: string;
  screenMappingId: string;
  questionId: string;
  required: boolean;
  customValidation: string;
  alertInfo: string;
  messageInfo: string;
  errorMessageInfo: string;
  maximumDate: string;
  isInlineLabel: boolean;
  inlineLabel: string;
  householdMembersValidationMessage: string;
  minorsMembersValidationMessage: string;
  termAndConditionsMessageLabel: string;
  termAndConditionPopupMessage: string;
  fieldName: string;
  countyOptions: CountyOption[];
  subQuestion: SubQuestion[];
  options: Option[];
  validators: QuestionValidators;
}
export interface Screen {
  screenId: string;
  leftHeader: string;
  leftContent: string;
  nextScreenId: any;
  previousScreenId: any;
  controls: JsonFormControls[];
}
export interface JsonFormDat {
  screens: Screen[];
}
@Component({
  selector: 'app-dynamic-questions',
  templateUrl: './dynamic-questions.component.html',
  styleUrls: ['./dynamic-questions.component.css'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DynamicQuestionsComponent implements OnInit {
  @Input()

  jsonFormData!: JsonFormDat;
  public formData!: JsonFormDat;
  public myForm: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  currentTheme: any;
  QuestionAndAnswer: any[] = [];
  getAnswerJson: any[] = [];
  currentScreenDetails: any[] = [];
  controlVal: any;
  controlType: any;
  patient: any;
  toShowWarningMessage: boolean = false;
  toShowMessageInfo: boolean = false;
  buttonHidden: boolean = false;
  evaluateButton: boolean = false;
  today = new Date();
  toShowSubQuestions: boolean = false;
  toShowNestedSubQuestions: boolean = false;
  toShowSubNestedSubQuestions: boolean = false;
  isPolicyNumber: any = "";
  headers: any;
  response: any;
  toShowSubQuestionWarningMessage: boolean = false;
  toShowSubQuestionMessageInfo: boolean = false;
  nextButtonDisable: boolean = true;
  screenNumber: any;
  filterScreenDetails: any;
  public count: any;
  dynamicForm: any;
  answerJson: any = [];
  bindCurrentScreenAnswerJson: any[] = [];
  screenId: any = "";
  screenDirection: string = "";
  fieldType: string = 'password';
  showLoader: boolean = false;
  ssn: any;
  buttonLabel: string = StringConstants.ssn.buttonLabel;
  NextLabel: string = StringConstants.common.nextLabel;
  bsVal: any;
  dobTextBox: any;
  toshowrequiredMessage: boolean = false;
  checkboxFormArray: any = [];
  nextScreenId: any;
  previousScreenId: any;
  bsValEffectiveFrom: any;
  bsValTermination: any;
  terminationTextBox: any;
  effectiveTextbox: any;
  effectiveFrom: any = "";
  termination: any = "";
  effectiveFromErrorMessage: string = '';
  dobErrorMessage: string = "";
  terminationErrorMessage: string = '';
  values: any = [];
  toShowCheckboxCrimeSubQuestions: boolean = false;
  toShowCheckboxMotorSubQuestions: boolean = false;
  toShowCheckboxJobSubQuestions: boolean = false;
  crimeReportFiled: any = 'No';
  motorReportFiled: any = 'No';
  jobReportFiled: any = 'No';
  private documentLoaded$: Subject<void>;
  closeResult = '';
  oldScreenValues: any;
  newScreenValue: any;
  countyCode: any;
  checked: boolean = true;
  reasonNoSSN: any;
  quickAssessmentResultId: any;
  showScreen: any;
  householdIncomeMaxErrorMessage: boolean = false;
  maximumValue: any;
  canCreateAssessment: any;
  Optionval: any;
  phoneCode: any;
  constructor(private common:CommonService,private datepipe: DatePipe, private modalService: NgbModal, private dialog: MatDialog, private dashboardService: DashboardService, private fb: FormBuilder, private http: HttpClient, private dataSharingService: DataSharingService, private router: Router, private toastService: ToastServiceService,
    private route: ActivatedRoute, private quickAssessmentService: QuickAssessmentService, private formbuilder: FormBuilder, private elementRef: ElementRef) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    
    
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.canCreate.subscribe(value => {
      this.showScreen = value;
    })
    this.documentLoaded$ = new Subject<void>();   

  }
  ngOnInit() {
    
    this.route.data.subscribe( (data) => { 
      this.jsonFormData = data.singlePost;
    });
    if(this.jsonFormData.screens[0].screenId != "1"){
    var hasValue = JSON.parse(sessionStorage.getItem('QuestionAndAnswer') ?? "")?.filter((word: { screenId: any; }) => word.screenId == "1");
    this.patient = hasValue[0].patient == 'Myself' ? sessionStorage.setItem("isPatient", "Myself") : sessionStorage.setItem("isPatient", "Relative/Friend/Other");
    this.patient = hasValue[0].patient;
    }
    this.initForm();
    for(const control of this.jsonFormData.screens[0].controls)
    {
      const validatorsToAdd = [];
      for (const [key, value] of Object.entries(control.validators)) {
        switch (key) {
          case 'min':
            validatorsToAdd.push(Validators.min(value));
            break;
          case 'max':
            validatorsToAdd.push(Validators.max(value));
            break;
          case 'required':
            if (value) {
              validatorsToAdd.push(Validators.required);
            }
            break;
          case 'requiredTrue':
            if (value) {
              validatorsToAdd.push(Validators.requiredTrue);
            }
            break;
          case 'email':
            if (value) {
              validatorsToAdd.push(Validators.email);
            }
            break;
          case 'minLength':
            validatorsToAdd.push(Validators.minLength(value));
            break;
          case 'maxLength':
            validatorsToAdd.push(Validators.maxLength(value));
            break;
          case 'pattern':
            validatorsToAdd.push(Validators.pattern(value));
            break;
          case 'nullValidator':
            if (value) {
              validatorsToAdd.push(Validators.nullValidator);
            }
            break;
          default:
            break;
        }
      }
      if (control.type == 'checkbox') {
        this.myForm.addControl(
          control.uniqueKey,
          this.fb.array([this.fb.group(validatorsToAdd)])
        );
        if (control.uniqueKey == 'agreementCheckBox') {
          this.checked = true;
        }
        if (control.uniqueKey == 'programServices') {
          this.Optionval = control.options;
        }
      }
      else {
        this.myForm.addControl(
          control.uniqueKey,
          this.fb.control(control.value, validatorsToAdd)
        );
      }
      if (control.type == 'dropdown' && control.uniqueKey == 'reasonNoSSN') {
        if (sessionStorage.getItem('QuickAssessmentSSN') == null || undefined || '') {
          this.myForm.get('reasonNoSSN').setValidators([Validators.required]);
          this.myForm.get('reasonNoSSN').updateValueAndValidity();
        }
      }
    }
    this.getDashboardDetails();

    this.screenDirection = "forward"; 
    this.getPhoneCode();
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  getDashboardDetails() {
    var userId: number = +(sessionStorage.getItem('userId')!);
    this.dashboardService.getDashboardDetails(userId, '').subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        if (result.data.partialAssessment == null) {
          this.dataSharingService.canCreate.next(true);
          this.canCreateAssessment = true;
          sessionStorage.setItem('resultID', '');
        }
        else {
          this.dataSharingService.canCreate.next(false);
          sessionStorage.setItem('resultID', result.data.partialAssessment.partialAssessmentId);
        }
        this.getQuickAssessmentDetails(this.screenDirection);
      }
    }, (error) => {
      console.log(error)
    });
  }
  async getPartialAssessment() {
    var partialAssessmentId = +(sessionStorage.getItem('resultID')!);
    this.quickAssessmentService.getPartialAssessment(partialAssessmentId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        sessionStorage.setItem('QuestionAndAnswer', result.data);
        this.QuestionAndAnswer = JSON.parse(result.data)
        var TempData = JSON.parse(result.data);
        var DataLength = TempData.length;
        this.screenNumber = (DataLength);
        var hasValue = JSON.parse(sessionStorage.getItem('QuestionAndAnswer') ?? "")?.filter((word: { screenId: any; }) => word.screenId == "1");
        this.patient = hasValue[0].patient == 'Myself' ? sessionStorage.setItem("isPatient", "Myself") : sessionStorage.setItem("isPatient", "Relative/Friend/Other");
        this.getScreenDetails(this.screenNumber);
      }
    }, (error) => {
      console.log(error);
    });
  }
  async getQuickAssessmentDetails(screenDirection: any) {
    try {
      
      this.headers = new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
      this.response = await this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.GetDynamicQuestions, { headers: this.headers }).toPromise();
      if (this.response.data.isDynamic == true) {
        this.formData = this.response.data;
        console.log(this.formData);
        sessionStorage.setItem('isDynamic', this.response.data.isDynamic);
        if (this.showScreen == false) {// Partial Assessment!
          this.getPartialAssessment();
        }
        else {// Default Assessment!
          this.screenNumber = (this.response.data.screens[0].screenId);
          if (this.screenNumber == "1") {
            sessionStorage.setItem("resultID", "");
          }
          this.getScreenDetails(this.screenNumber);
          
        }
        if (screenDirection == 'backward') {
          this.backToPreviousScreen();
        }
      }
      else if (this.response.data.isDynamic == false) {
        sessionStorage.setItem('isDynamic', this.response.data.isDynamic);
        this.router.navigate(['patient']);
      }
    }
    catch (error) {
      console.log("Failed to fetch the Quick assessemnt Details");
      
    }
  }
  private initForm() {
    this.myForm = new FormGroup({
      'screenId': new FormControl([])
    });
  }
  getScreenDetails(currentScreen: any) {// To get all screen details
    
    this.filterScreenDetails = this.formData.screens.filter((e: { screenId: any; }) => e.screenId == currentScreen)
    this.jsonFormData = {
      screens:  
        this.filterScreenDetails
    }
    this.nextScreenId = this.jsonFormData.screens[0].nextScreenId;
    this.previousScreenId = this.jsonFormData.screens[0].previousScreenId;
    this.screenId = this.jsonFormData.screens[0].screenId;
    this.screenNumber = this.jsonFormData.screens[0].screenId;
    this.createForm(this.jsonFormData.screens[0]?.controls);
  }
  filterScreens(currentScreen: any) {//To filter current screen details
    this.filterScreenDetails = this.formData.screens.filter((e: { screenId: any; }) => e.screenId == currentScreen)
    this.jsonFormData = {
      screens: this.filterScreenDetails
    }
    this.nextScreenId = this.jsonFormData.screens[0].nextScreenId;
    this.previousScreenId = this.jsonFormData.screens[0].previousScreenId;
    this.screenId = this.jsonFormData.screens[0].screenId;
    this.screenNumber = this.jsonFormData.screens[0].screenId;
  }
  checkCustomValidation() {//To Check if Question has any subquestion based on custom validation
    this.jsonFormData.screens[0]?.controls.forEach(question => {
      if (question.customValidation == "Yes") {
        this.createSubQuestionsForm(this.jsonFormData.screens[0].controls, "Yes");
        this.toShowSubQuestions = true;
      }
      if (question.customValidation == "Yes/No") {
        this.createSubQuestionsForm(this.jsonFormData.screens[0].controls, "Yes");
        this.toShowSubQuestions = true;
      }
    });
  }
  getSelfDetails() { //To get patient self details if assessment created for Myself
    var userId: number = +(sessionStorage.getItem('userId')!);
    this.quickAssessmentService.getSelfDetails(userId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        console.log(result);
        if (result.data != null) {
          this.myForm.controls['firstName'].setValue(result.data.firstName);
          this.myForm.controls['lastName'].setValue(result.data.lastName);
          this.myForm.controls['dateOfBirth'].setValue(result.data.dateOfBirth);
          this.myForm.controls['gender'].setValue(result.data.gender);
          this.myForm.controls['maritalStatus'].setValue(result.data.maritalStatus);
          this.myForm.controls['email'].setValue(result.data.email);
          this.myForm.controls['cellNumber'].setValue(result.data.cell);
          this.myForm.controls['middleName'].setValue(result.data.middleName);
        }
      }
    }, (error) => {
      if (error.status = '500') {
        console.log(error)
      }
      else {
        console.log(error)
      }
    });
  }
  backToLastStep(test: any, screenDirection: any) {// To Save screen details when user click on back button
    if (this.myForm.touched) {
      this.onSubmit(test, screenDirection);
    }
    else {
      this.toRemoveControls();
      this.backToPreviousScreen();
    }
  }
  backToPreviousScreen() {//Go to pervious screen
    this.getScreenDetails(this.previousScreenId);
    this.fetchScreenDetailsValues();
  }
  fetchScreenDetailsValues() {//To fetch saved details
    this.getAnswerJson = JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!);
    this.bindCurrentScreenAnswerJson = this.getAnswerJson.filter(word => word.screenId == this.screenId);
    
    
    if (this.bindCurrentScreenAnswerJson?.length) {
      
      this.jsonFormData.screens[0].controls.forEach(control => {
        control.subQuestion?.forEach(subQuestion => {
          this.checkCustomValidation();
          subQuestion.subQuestion?.forEach(nestedQuestions => {
            nestedQuestions.subQuestion?.forEach(subNested => {
              this.bindCurrentScreenAnswerJson.forEach(controlAns => {
                if (this.myForm.controls[subNested.uniqueKey] !== undefined && Object.keys(controlAns).includes(subNested.uniqueKey))
                  this.myForm.controls[subNested.uniqueKey].setValue(controlAns[subNested.uniqueKey]);
                if (controlAns[subNested.uniqueKey]?.length) {
                  for (let i = 1; i < controlAns[subNested.uniqueKey].length; i++) {
                    if (controlAns[subNested.uniqueKey][i])
                      this.values[controlAns[subNested.uniqueKey][i]] = true;
                  }
                }
              });
            });
            this.bindCurrentScreenAnswerJson.forEach(controlAns => {
              if (this.myForm.controls[nestedQuestions.uniqueKey] !== undefined && Object.keys(controlAns).includes(nestedQuestions.uniqueKey))
                this.myForm.controls[nestedQuestions.uniqueKey].setValue(controlAns[nestedQuestions.uniqueKey]);
              if (controlAns[nestedQuestions.uniqueKey]?.length) {
                for (let i = 1; i < controlAns[nestedQuestions.uniqueKey].length; i++) {
                  if (controlAns[nestedQuestions.uniqueKey][i])
                    this.values[controlAns[nestedQuestions.uniqueKey][i]] = true;
                }
              }
            });
          });
          this.bindCurrentScreenAnswerJson.forEach(controlAns => {
            if (this.myForm.controls[subQuestion.uniqueKey] !== undefined && Object.keys(controlAns).includes(subQuestion.uniqueKey))
              this.myForm.controls[subQuestion.uniqueKey].setValue(controlAns[subQuestion.uniqueKey]);
            if (controlAns[subQuestion.uniqueKey] == 'Yes' || controlAns[subQuestion.uniqueKey] == 'No')
              this.subQuestiontoggleOnChange(controlAns[subQuestion.uniqueKey], subQuestion.uniqueKey, controlAns[subQuestion.uniqueKey]);
            if (controlAns[subQuestion.uniqueKey]?.length) {
              for (let i = 1; i < controlAns[subQuestion.uniqueKey].length; i++) {
                if (controlAns[subQuestion.uniqueKey][i])
                  this.values[controlAns[subQuestion.uniqueKey][i]] = true;
                this.createSubQuestionFormControls();
              }
            }
            if (controlAns[subQuestion.uniqueKey] == 'crimeReportFiled') {
              this.toShowCheckboxCrimeSubQuestions = true;
              this.myForm.controls[subQuestion.uniqueKey].setValue(controlAns[subQuestion.uniqueKey]);
            }
            if (controlAns[subQuestion.uniqueKey] == 'motorReportFiled') {
              this.toShowCheckboxMotorSubQuestions = true;
              this.myForm.controls[subQuestion.uniqueKey].setValue(controlAns[subQuestion.uniqueKey]);
            }
            if (controlAns[subQuestion.uniqueKey] == 'jobReportFiled') {
              this.toShowCheckboxJobSubQuestions = true;
              this.myForm.controls[subQuestion.uniqueKey].setValue(controlAns[subQuestion.uniqueKey]);
            }
          });
        });
        
        this.bindCurrentScreenAnswerJson.forEach(controlAns => {          
          if (controlAns[control.uniqueKey] == 'Yes' || controlAns[control.uniqueKey] == 'No') {
            if (this.myForm.controls['isEmployed']) {
              this.toggleOnChange('Yes/No', control.uniqueKey, controlAns[control.uniqueKey])
            }
            else {
              this.toggleOnChange(controlAns[control.uniqueKey], control.uniqueKey, controlAns[control.uniqueKey])
            }
          }
          if (controlAns[control.uniqueKey]?.length) {
            for (let i = 1; i < controlAns[control.uniqueKey].length; i++) {
              if (controlAns[control.uniqueKey][i])
                this.values[controlAns[control.uniqueKey][i]] = true;
              if (this.myForm.controls["totalHouseholdMembers"]) {
                this.myForm.controls["totalHouseholdMembers"].setValue(controlAns['totalHouseholdMembers'])
              }
              if (this.myForm.controls["totalMinors"]) {
                this.myForm.controls["totalMinors"].setValue(controlAns['totalMinors'])
              }
            }
          }
          else {
            
              if(controlAns[control.uniqueKey]?.length == 1)
                this.myForm.controls[control.uniqueKey].setValue(controlAns[control.uniqueKey]); 
          }
          for (let i = 0; i < this.filterScreenDetails[0].controls?.length; i++) {
            if (controlAns[this.filterScreenDetails[0].controls[i]?.uniqueKey]) {//bind values to question of all the types
              this.filterScreenDetails[0].controls[i].value = controlAns[this.filterScreenDetails[0].controls[i].uniqueKey];
              if (this.filterScreenDetails[0].controls[i].uniqueKey == 'dateOfBirth') {//bind values to question of date control type
                this.bsVal = new Date(controlAns[this.filterScreenDetails[0].controls[i].uniqueKey]);
              }
            }
            //bind values to question of checkbox control type and check if it has selected value saved in the session 
            if (this.filterScreenDetails[0].controls[i].type == 'checkbox' && controlAns[this.filterScreenDetails[0].controls[i]?.uniqueKey]) { //iterate the options to check if it is selected
              for (var val in controlAns[this.filterScreenDetails[0].controls[i]?.uniqueKey]) {
                if (controlAns[this.filterScreenDetails[0].controls[i]?.uniqueKey][val] != null) {
                  this.values[this.filterScreenDetails[0].screenId + "_" + controlAns[this.filterScreenDetails[0].controls[i]?.uniqueKey][val]] = true;
                }
              };
            }
            for (let j = 0; j < this.filterScreenDetails[0].controls[i]?.subQuestion?.length; j++) { //started to check the sub question controls
              if (controlAns[this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.uniqueKey]) {//bind values to sub question of all control type
                this.filterScreenDetails[0].controls[i].subQuestion[j].value = controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].uniqueKey];
              }
              if (this.filterScreenDetails[0].controls[i].subQuestion[j].type == 'checkbox' && controlAns[this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.uniqueKey]) { //bind values to sub question of checkbox control type and check if it has selected value saved in the session 
                for (var val in controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].uniqueKey]) {
                  if (controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].uniqueKey][val] != null) {
                    this.values[this.filterScreenDetails[0].screenId + "_" + controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].uniqueKey][val]] = true;
                  }
                };
              }
              if (this.values[this.filterScreenDetails[0].screenId + "_" + this.filterScreenDetails[0].controls[i]?.options[0]?.value] && this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.uniqueKey == 'crimeReportFiled') {//nested question controls display based on sub question value
                this.createSubQuestionFormControls();
                this.toShowCheckboxCrimeSubQuestions = true;
              }
              if (this.values[this.filterScreenDetails[0].screenId + "_" + this.filterScreenDetails[0].controls[i]?.options[1]?.value] && this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.uniqueKey == 'motorReportFiled') {
                this.createSubQuestionFormControls();
                this.toShowCheckboxMotorSubQuestions = true;
              }
              if (this.values[this.filterScreenDetails[0].screenId + "_" + this.filterScreenDetails[0].controls[i]?.options[2]?.value] && this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.uniqueKey == 'jobReportFiled') {
                this.createSubQuestionFormControls();
                this.toShowCheckboxJobSubQuestions = true;
              }
              for (let k = 0; k < this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.subQuestion?.length; k++) {//started to check the nested sub question controls
                if (controlAns[this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.subQuestion[k]?.uniqueKey]) {//bind values to nested sub question of all control type
                  this.filterScreenDetails[0].controls[i].subQuestion[j].subQuestion[k].value = controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].subQuestion[k].uniqueKey];
                }
                if (this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.subQuestion[k]?.type == 'checkbox' && controlAns[this.filterScreenDetails[0].controls[i]?.subQuestion[j]?.subQuestion[k]?.uniqueKey]) {//bind values to nested sub question of checkbox control type and check if it has selected value saved in the session
                  this.values[this.filterScreenDetails[0].screenId + "_" + controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].subQuestion[k].uniqueKey]] = true;
                  for (var val in controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].subQuestion[k].uniqueKey]) {
                    if (controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].subQuestion[k].uniqueKey][val] != null) {
                      this.values[this.filterScreenDetails[0].screenId + "_" + controlAns[this.filterScreenDetails[0].controls[i].subQuestion[j].subQuestion[k].uniqueKey][val]] = true;
                    }
                  };
                }
              }
            }
          }
        });
      });
    }
  }
  toRemoveControls() {//To Remove previous screen controls
    this.jsonFormData.screens[0].controls.forEach(control => {
      control.subQuestion?.forEach(subquestion => {
        subquestion.subQuestion?.forEach(nestedSubQuestion => {
          nestedSubQuestion.subQuestion?.forEach(subNestedQuestions => {
            this.myForm.removeControl(subNestedQuestions.uniqueKey);
          });
          this.myForm.removeControl(nestedSubQuestion.uniqueKey);
        });
        this.myForm.removeControl(subquestion.uniqueKey);
      });
      this.myForm.removeControl(control.uniqueKey);
    });
  }
  wasReportFiledChange(controlName: any, event: any) { //Report Filed toggle button onChange
    if (event.target.innerText == 'Yes') {
      if (controlName == 'crimeReportFiled')
        this.crimeReportFiled = 'Yes';
      else if (controlName == 'motorReportFiled')
        this.motorReportFiled = 'Yes';
      else if (controlName == 'jobReportFiled')
        this.jobReportFiled = 'Yes';
    }
    else if (event.target.innerText == 'No') {
      if (controlName == 'crimeReportFiled')
        this.crimeReportFiled = 'No';
      else if (controlName == 'motorReportFiled')
        this.motorReportFiled = 'No';
      else if (controlName == 'jobReportFiled')
        this.jobReportFiled = 'No';
    }
  }
  onChangeCheckboxOptions(formcontrolName: any, checkOptions: any, event: any, subQuestions: any) {//checkbox onChange event
    if (event) {
      if (event.keyCode == "13") { //Key press event
        let check = event.target.checked;
        switch (check) {
          case true:
            var checked: any = false;
            this.values[this.filterScreenDetails[0].screenId + "_" + checkOptions] = false;
            break;
          case false:
            var checked: any = true;
            this.values[this.filterScreenDetails[0].screenId + "_" + checkOptions] = true;
            break;
        }
      }
      else {
        var checked: any = event.target.checked;
      }
    }
    
    const control = <FormArray>this.myForm.get(formcontrolName) as FormArray;
    if (checked == true) {
      control.push(this.fb.control(checkOptions));
      if (subQuestions != null || subQuestions != '')
        this.createCheckboxSubquestions(checkOptions);
      if (checkOptions == 'All of the above') {//All of the above option functionality - Starts here...
        for (let data of this.Optionval) {
          if (data.value != 'All of the above') {
            var index: number = control.controls.findIndex((x: { value: any; }) => x.value == data.value)
            control.removeAt(index);
            this.values[this.filterScreenDetails[0].screenId + "_" + data.value] = false;
          }
        }
      }
      else {
        const index = control.controls.findIndex((x: { value: any; }) => x.value == 'All of the above')
        control.removeAt(index);
        this.values[this.filterScreenDetails[0].screenId + "_" + 'All of the above'] = false;
      }//Ends here...
    } else {
      const index = control.controls.findIndex((x: { value: any; }) => x.value == checkOptions)
      control.removeAt(index);
      this.removeCheckboxSubquestions(checkOptions);
    }
    event.preventDefault();
  }
  onAgreeChange(formcontrolName: any, checkOptions: any, event: any, subQuestions: any) {// To check terms and conditions checkbox
    if (event.target.checked)
      this.checked = true;
    else
      this.checked = false;
  }
  OnChangeOptions(screenId: any, event: any, customValidation: any, controls: any) {// To check Radio button onchange event
    this.householdIncomeMaxErrorMessage = false;
    if (screenId == "1") {
      let patient = this.myForm.value.patient;
      var val = patient.split('_');
      sessionStorage.setItem("isPatient", val[0]);
    }
    else if (this.myForm.value.citizenship) {
      var array = this.myForm.value.citizenship.split('_');
      if (array[0] == customValidation) {
        this.toShowWarningMessage = true;
        this.toShowMessageInfo = true;
        this.buttonHidden = true;
      }
      else {
        this.toShowWarningMessage = false;
        this.toShowMessageInfo = false;
        this.buttonHidden = false;
      }
    }
    else if (controls == 'subquestions') {
      console.log("message")
    }
    else if (event.target.value == 'Yearly' || event.target.value == 'Monthly' || event.target.value == 'Bimonthly' || event.target.value == 'Biweekly' || event.target.value == 'Weekly') {
      var income = this.myForm.controls['householdIncome'].value;
      this.incomeMaxValidation(income, event.target.value);
    }
  }
  incomeErrorMessage(incomeAmount: any, max: any) {//To show household income error message
    if (incomeAmount > max) {
      this.householdIncomeMaxErrorMessage = true;
    }
  }
  incomeMaxValidation(val: any, incomePayPeriod: any) {// To evaluate income amount based on grosspay
    let max: any = this.maximumValue;
    if (incomePayPeriod == 'Yearly') {
      let income: any = (Math.round(((Number(val) * 1) + Number.EPSILON) * 100) / 100).toFixed(2);
      this.incomeErrorMessage(income, max);
    }
    else if (incomePayPeriod == 'Monthly') {
      let income: any = (Math.round(((Number(val) * 12) + Number.EPSILON) * 100) / 100).toFixed(2);
      this.incomeErrorMessage(income, max);
    }
    else if (incomePayPeriod == 'Bimonthly') {
      let income: any = (Math.round(((Number(val) * 6) + Number.EPSILON) * 100) / 100).toFixed(2);
      this.incomeErrorMessage(income, max);
    }
    else if (incomePayPeriod == 'Biweekly') {
      let income: any = (Math.round(((Number(val) * 26) + Number.EPSILON) * 100) / 100).toFixed(2);
      this.incomeErrorMessage(income, max);
    }
    else if (incomePayPeriod == 'Weekly') {
      let income: any = (Math.round(((Number(val) * 52) + Number.EPSILON) * 100) / 100).toFixed(2);
      this.incomeErrorMessage(income, max);
    }
  }
  createCheckboxSubquestions(optionValues: any) {  //To show checkbox subquestion
    this.createSubQuestionFormControls();
    if (optionValues == 'In crime related violence (as a victim)') {
      this.toShowCheckboxCrimeSubQuestions = true;
      this.filterScreenDetails[0].controls[0].subQuestion[0].value = null;
    }
    else if (optionValues == 'In motor vehicle accident') {
      this.toShowCheckboxMotorSubQuestions = true;
      this.filterScreenDetails[0].controls[0].subQuestion[1].value = null;
    }
    else if (optionValues == 'On the job') {
      this.toShowCheckboxJobSubQuestions = true;
      this.filterScreenDetails[0].controls[0].subQuestion[2].value = null;
    }
  }
  removeCheckboxSubquestions(optionValues: any) {//To remove checkbox subquestion
    if (optionValues == 'In crime related violence (as a victim)') {
      this.toShowCheckboxCrimeSubQuestions = false;
      this.filterScreenDetails[0].controls[0].subQuestion[0].value = null;
    }
    else if (optionValues == 'In motor vehicle accident') {
      this.toShowCheckboxMotorSubQuestions = false;
      this.filterScreenDetails[0].controls[0].subQuestion[1].value = null;
    }
    else if (optionValues == 'On the job') {
      this.toShowCheckboxJobSubQuestions = false;
      this.filterScreenDetails[0].controls[0].subQuestion[2].value = null;
    }
  }
  createSubQuestionFormControls() {  //To create subquestion form controls
    this.createSubQuestionsForm(this.jsonFormData.screens[0].controls, 'Yes');
    this.toShowSubQuestions = true;
  }
  removeSubQuestionFormControls() {//To remove subquestion form controls
    this.createSubQuestionsForm(this.jsonFormData.screens[0].controls, 'No');
    this.toShowSubQuestions = false;
    this.toShowWarningMessage = false;
    this.toShowMessageInfo = false;
    this.buttonHidden = false;
    this.isPolicyNumber = "";
    this.bsValEffectiveFrom = "";
    this.bsValTermination = "";
  }
  paste(e: any) {
    e.preventDefault();
  }
  increment(controlName: any, formValues: any, event: any) { // To evaluate household memebers count both minors and majors
    let newVal = formValues[controlName];
    let memberVal = this.myForm.get('totalHouseholdMembers').value;
    if (controlName == "totalMinors" && newVal >= memberVal) {
      this.myForm.controls[controlName].setValue("0");
      this.toastService.showWarning("Minor count should not exceed total household members.", "");
    }
    else {
      this.myForm.controls[controlName].setValue((+(newVal) + 1).toString());
    }
  }
  decrement(controlName: any, formValues: any, event: any) {// To evaluate household memebers count both minors and majors
    let newVal = formValues[controlName];
    let memberVal = this.myForm.get('totalMinors').value;
    if (controlName == "totalHouseholdMembers" && newVal <= memberVal) {
      newVal = +newVal;
      this.toastService.showWarning("Minor count should not exceed total household members.", "");
    }
    else if (+(newVal) > 1 && controlName == "totalHouseholdMembers") {
      newVal = (+(newVal) - 1);
    }
    else if (+(newVal) <= 1 && controlName == "totalHouseholdMembers")
      newVal = 1;
    else if (+(newVal) > 0 && controlName == "totalMinors")
      newVal = (+(newVal) - 1);
    else if (+(newVal) == 0 && controlName == "totalMinors")
      newVal = 0;
    else
      newVal = +newVal;
    newVal = newVal.toString();
    this.myForm.controls[controlName].setValue(newVal);
  }
  HouseholdMemberValidator(controlName: any, formValues: any, event: any) {//Validation for houshold members count
    let totalMinors = Number(this.myForm.controls["totalMinors"].value);
    let totalHouseholdMembers = Number(this.myForm.controls["totalHouseholdMembers"].value);
    if (totalMinors > totalHouseholdMembers || isNaN(formValues[controlName]) || (totalMinors == 0 && totalHouseholdMembers == 0)) {
      this.myForm.controls["totalHouseholdMembers"].setValue("1");
      this.myForm.controls["totalMinors"].setValue("0");
      if (event.data == ".") {
        this.myForm.controls[controlName].setValue(Number(this.myForm.controls[controlName].value))
      }
    }
  }
  getTextFieldValidation(customValidation: any, event: any, max: any) {  // Textfield Custom Validation
    if (customValidation != "") {
      let val = event.target.value;
      switch (customValidation) {
        case "Zipcode":
          this.getStateAndCity(val);
          break;
        case "Unknown":
          break;
        case "PolicyNumber":
          this.isPolicyNumber = val;
          break;
        case "Income":
          this.maximumValue = max;
          this.householdIncomeMaxErrorMessage = false;
          var incomePayPeriod = this.myForm.controls['incomePayPeriod'].value;
          this.incomeMaxValidation(val, incomePayPeriod);
          break;
        default: {
          break;
        }
      }
    }
  }
  getStateAndCity(value: any) {//To get City and state value
    const val = value;
    if (val.length >= 5) {
      this.quickAssessmentService.getStateAndCity(val).subscribe(async (result: any) => {
        if (result.wasSuccessful == true) {
          console.log(result);
          if (result.data != null) {
            let group: any = {}
            this.jsonFormData.screens[0].controls.forEach(control => {
              group[control.uniqueKey] = new FormControl('');
              this.myForm.controls['city'].setValue(result.data.city);
              this.myForm.controls['state'].setValue(result.data.state);
              sessionStorage.setItem('AssessmentZipCode', val);
              sessionStorage.setItem('AssessmentState', result.data.state);
              sessionStorage.setItem('AssessmentCity', result.data.city);
              sessionStorage.setItem('AssessmentStateCode', result.data.stateCode);
            });
          }
          else {
          }
        }
        else if (result.wasSuccessful == false) {
          console.log(result);
        }
      }, (error) => {
        console.log(error)
      });
    }
  }
  subQuestiontoggleOnChange(customValidation: any, controlName: any, event: any) { // To check subquestion toggle button event
    if (customValidation != "") {
      if (event.target?.innerText)
        var val = event.target.innerText;
      else
        var val = event;
      if (customValidation == val) {
        switch (customValidation) {
          case "Yes":
            this.toShowNestedSubQuestions = true;
            this.createNestedSubQuestionsForm(this.jsonFormData.screens[0].controls, 'Yes');
            break;
          case "No":
            this.toShowNestedSubQuestions = false;
            this.createNestedSubQuestionsForm(this.jsonFormData.screens[0].controls, 'No');
            break;
          case "Yes/No":
            this.toShowSubQuestions = true;
            this.createNestedSubQuestionsForm(this.jsonFormData.screens[0].controls, 'Yes');
            break;
          case "":
            break;
          default: {
            break;
          }
        }
      }
      else {
        this.createNestedSubQuestionsForm(this.jsonFormData.screens[0].controls, event.target.innerText);
        this.toShowNestedSubQuestions = false;
      }
    }
  }
  toggleOnChange(customValidation: any, controlName: any, event: any) {//Toggle change
    if (customValidation != "") {
      if (event.target?.innerText)
        var val = event.target.innerText;
      else
        var val = event;
      this.myForm.controls[controlName].setValue(val);
      if (customValidation == val) {
        switch (customValidation) {
          case "Yes":
            this.createSubQuestionFormControls();
            break;
          case "No":
            this.removeSubQuestionFormControls();
            break;
          case "Yes/No":
            this.createSubQuestionFormControls();
            break;
          default: {
            break;
          }
        }
      }
      else if (customValidation == "Yes/No") {
        this.createSubQuestionFormControls();
      }
      else {
        this.removeSubQuestionFormControls();
      }
    }
  }
  selectDate(controlName: any) {// Date-picker JS starts here!
    if (this.bsVal && this.bsVal != "Invalid Date") {
      this.dobTextBox = document.getElementsByName('controlName');
      var newVal = this.datepipe.transform(this.bsVal, 'MM/dd/yyyy');
      this.dobTextBox.value = newVal;
      this.myForm.controls[controlName].setValue(newVal);
      this.checkPattern(controlName);
    }
  }
  closeCalendar(controlName: any) {// To close calendar
    DateValidation.closeCal();
  }
  checkPattern(controlName: any) {//To check date of birth controls date validation
    var result = false;
    var dateCheck;
    this.dobTextBox = document.getElementsByName('controlName');
    var bsValueDOB = this.dobTextBox.value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
        dateCheck = this.datepipe.transform(bsValueDOB, 'MM/dd/yyyy');
        result = DateValidation.validateFutureDate(dateCheck != null ? dateCheck : "");
      }
    }
    if (!result) {
      this.myForm.patchValue({
        dateOfBirth: ""
      });
      this.dobTextBox.focus();
      this.dobErrorMessage = "Date must be in mm/dd/yyyy format.";
    } else {
      if (bsValueDOB != null && bsValueDOB != "") {
        this.bsVal = new Date(bsValueDOB);
      }
      this.myForm.controls[controlName].setValue(bsValueDOB);
      this.dobErrorMessage = "";
    }
  }
  keyPress(event: KeyboardEvent) {// To check text field click event
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  }
  selectEffectiveFromDate(event: any) {// To select effective from date
    
    if (this.bsValEffectiveFrom != undefined && this.bsValEffectiveFrom != null && this.bsValEffectiveFrom != "Invalid Date" && this.bsValEffectiveFrom != "") {
      var newVal = this.datepipe.transform(this.bsValEffectiveFrom, 'MM/dd/yyyy');
      this.myForm.controls['effectiveFrom'].setValue(newVal);
      this.effectiveFrom = newVal;
      this.effectiveTextbox = this.myForm.controls['effectiveFrom'].value;
      this.clickEffectiveFrom();
    }
    else if (this.bsValEffectiveFrom == "Invalid Date") {
      this.effectiveFrom = null;
      this.effectiveFromErrorMessage = "Date must be in mm/dd/yyyy format.";
    }
    else if (this.bsValEffectiveFrom == "" || this.bsValEffectiveFrom == undefined || this.bsValEffectiveFrom == null) {
      this.bsValEffectiveFrom = null;
      this.effectiveFrom = null;
    }
  }
  selectTerminationDate(event: any) {// To select termination date
    
    if (this.bsValTermination != undefined && this.bsValTermination != "Invalid Date" && this.bsValTermination != null && this.bsValTermination != "") {
      var newVal = this.datepipe.transform(this.bsValTermination, 'MM/dd/yyyy');
      this.myForm.controls['termination'].setValue(newVal);
      this.termination = newVal;
      this.terminationTextBox = this.myForm.controls['termination'].value;
      this.clickTermination();
    }
    else if (this.bsValTermination == "Invalid Date") {
      this.bsValTermination = null;
      this.termination = "";
      this.terminationErrorMessage = "Date must be in mm/dd/yyyy format!";
    }
    else if (this.bsValTermination == "" || this.bsValTermination == undefined || this.bsValTermination == null) {
      this.bsValTermination = null;
      this.termination = "";
    }
  }
  clickEffectiveFrom() {//Effective from date click event
    
    this.effectiveFromErrorMessage = "";
    var result = false;
    var validMessage = true;
    this.effectiveTextbox = this.myForm.controls['effectiveFrom'].value;
    var bsValueEffective = this.effectiveTextbox;
    bsValueEffective = this.datepipe.transform(this.bsValEffectiveFrom, 'MM/dd/yyyy');
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
      if (bsValueEffective == "Invalid Date") {
        this.myForm.patchValue({
          effectiveFrom: "",
        });
        this.bsValEffectiveFrom = null;
        this.effectiveFromErrorMessage = "Date must be in mm/dd/yyyy format!";
      }
      else {
        if (bsValueEffective != null) {
          this.bsValEffectiveFrom = new Date(bsValueEffective);
        }
        this.myForm.controls['effectiveFrom'].setValue(bsValueEffective);
        this.effectiveFromErrorMessage = validMessage ? "" : "Effective From should be lesser than termination!";
        
      }
    }
    this.terminationErrorMessage = "";
  }
  clickTermination() {//Termination date click event
    
    this.terminationErrorMessage = '';
    var result = false;
    var validMessage = true;
    var dateCheck;
    this.terminationTextBox = this.myForm.controls['termination'].value;
    var bsValueTermination = this.terminationTextBox;
    bsValueTermination = this.datepipe.transform(this.bsValTermination, 'MM/dd/yyyy');
    if (bsValueTermination != "Invalid Date") {
      if (bsValueTermination == null) {
        result = true;
      } else if (DateValidation.validateDate(bsValueTermination != null ? bsValueTermination : "")) {
        this.effectiveFrom = this.myForm.controls['effectiveFrom'].value;
        if (this.effectiveFrom == null || this.effectiveFrom == "") {
          result = true;
        }
        else {
          var startDate = new Date(this.effectiveFrom).setHours(0, 0, 0, 0);
          var endDate = new Date(this.termination).setHours(0, 0, 0, 0);
          if (endDate <= startDate) {
            result = false;
            validMessage = false;
          }
          else if (startDate < endDate) {
            result = true;
          } else {
            result = true;
          }
        }
      }
    }
    if (!result) {
      if (bsValueTermination == "Invalid Date") {
        this.myForm.patchValue({
          termination: ""
        });
        this.bsValTermination = "";
        this.terminationTextBox.focus();
      }
      else if (bsValueTermination == "") {
        this.terminationErrorMessage = "Date must be in mm/dd/yyyy format!";
      }
      this.terminationErrorMessage = validMessage ? "" : "Termination should be greater than effective from!";
      
    } else {
      if (bsValueTermination != null) {
        this.bsValTermination = new Date(bsValueTermination);
      }
      this.myForm.controls['termination'].setValue(bsValueTermination);
      this.terminationErrorMessage = '';
      
    }
    this.effectiveFromErrorMessage = "";
  }
  open(content: any) { /** To  Open terms and conditions Module*/
    this.modalService.open(content,
      { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult =
          `Dismissed ${this.getDismissReason(reason)}`;
      });
  }
  private getDismissReason(reason: any): string {//To dismiss modal module
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  createForm(controls: JsonFormControls[]) { // To create form controls
    this.patient = sessionStorage.getItem("isPatient");
    this.buttonHidden = false;
    for (const control of controls) {
      const validatorsToAdd = [];
      for (const [key, value] of Object.entries(control.validators)) {
        switch (key) {
          case 'min':
            validatorsToAdd.push(Validators.min(value));
            break;
          case 'max':
            validatorsToAdd.push(Validators.max(value));
            break;
          case 'required':
            if (value) {
              validatorsToAdd.push(Validators.required);
            }
            break;
          case 'requiredTrue':
            if (value) {
              validatorsToAdd.push(Validators.requiredTrue);
            }
            break;
          case 'email':
            if (value) {
              validatorsToAdd.push(Validators.email);
            }
            break;
          case 'minLength':
            validatorsToAdd.push(Validators.minLength(value));
            break;
          case 'maxLength':
            validatorsToAdd.push(Validators.maxLength(value));
            break;
          case 'pattern':
            validatorsToAdd.push(Validators.pattern(value));
            break;
          case 'nullValidator':
            if (value) {
              validatorsToAdd.push(Validators.nullValidator);
            }
            break;
          default:
            break;
        }
      }
      if (control.type == 'checkbox') {
        this.myForm.addControl(
          control.uniqueKey,
          this.fb.array([this.fb.group(validatorsToAdd)])
        );
        if (control.uniqueKey == 'agreementCheckBox') {
          this.checked = true;
        }
        if (control.uniqueKey == 'programServices') {
          this.Optionval = control.options;
        }
      }
      else {
        this.myForm.addControl(
          control.uniqueKey,
          this.fb.control(control.value, validatorsToAdd)
        );
      }
      if (control.type == 'dropdown' && control.uniqueKey == 'reasonNoSSN') {
        if (sessionStorage.getItem('QuickAssessmentSSN') == null || undefined || '') {
          this.myForm.get('reasonNoSSN').setValidators([Validators.required]);
          this.myForm.get('reasonNoSSN').updateValueAndValidity();
        }
      }
    }
    if (this.myForm.controls['email']) {
      var isDetailsSaved = this.QuestionAndAnswer.filter(word => word.screenId == this.screenId);
      if (this.patient == 'Myself' && isDetailsSaved.length == 0) {
        this.getSelfDetails();
      }
      else
        this.myForm.controls['email']?.enable();
    }
    else if (this.myForm.controls['ssnNumber']) {
      this.buttonHidden = true;
      this.evaluateButton = true;
    }
    if (this.myForm.controls['city']) {
      this.myForm.controls['city'].disable();
      this.myForm.controls['state'].disable();
    }
    
    this.fetchScreenDetailsValues();
  }
  createSubQuestionsForm(controls: JsonFormControls[], customValidation: any) {//To create form controls for subquestions
    switch (customValidation) {
      case "Yes":
        for (const control of controls) {
          if (control.subQuestion != undefined) {
            for (const ctrl of control.subQuestion) {
              const subQuestionValidatorsToAdd = [];
              for (const [key, value] of Object.entries(ctrl.validators)) {
                switch (key) {
                  case 'min':
                    subQuestionValidatorsToAdd.push(Validators.min(value));
                    break;
                  case 'max':
                    subQuestionValidatorsToAdd.push(Validators.max(value));
                    break;
                  case 'required':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.required);
                    }
                    break;
                  case 'requiredTrue':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.requiredTrue);
                    }
                    break;
                  case 'email':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.email);
                    }
                    break;
                  case 'minLength':
                    subQuestionValidatorsToAdd.push(Validators.minLength(value));
                    break;
                  case 'maxLength':
                    subQuestionValidatorsToAdd.push(Validators.maxLength(value));
                    break;
                  case 'pattern':
                    subQuestionValidatorsToAdd.push(Validators.pattern(value));
                    break;
                  case 'nullValidator':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.nullValidator);
                    }
                    break;
                  default:
                    break;
                }
              }
              if (ctrl.type == 'checkbox') {
                this.myForm.addControl(
                  ctrl.uniqueKey,
                  this.fb.array([this.fb.group(subQuestionValidatorsToAdd)])
                );
              }
              else {
                this.myForm.addControl(
                  ctrl.uniqueKey,
                  this.fb.control(ctrl.value, subQuestionValidatorsToAdd)
                );
              }
            }
          }
        }
        break;
      case "No":
        for (const control of controls) {
          if (control.subQuestion != undefined) {
            for (const ctrl of control.subQuestion) {
              const subQuestionValidatorsToAdd = [];
              for (const [key, value] of Object.entries(ctrl.validators)) {
                switch (key) {
                  case 'min':
                    subQuestionValidatorsToAdd.push(Validators.min(value));
                    break;
                  case 'max':
                    subQuestionValidatorsToAdd.push(Validators.max(value));
                    break;
                  case 'required':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.required);
                    }
                    break;
                  case 'requiredTrue':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.requiredTrue);
                    }
                    break;
                  case 'email':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.email);
                    }
                    break;
                  case 'minLength':
                    subQuestionValidatorsToAdd.push(Validators.minLength(value));
                    break;
                  case 'maxLength':
                    subQuestionValidatorsToAdd.push(Validators.maxLength(value));
                    break;
                  case 'pattern':
                    subQuestionValidatorsToAdd.push(Validators.pattern(value));
                    break;
                  case 'nullValidator':
                    if (value) {
                      subQuestionValidatorsToAdd.push(Validators.nullValidator);
                    }
                    break;
                  default:
                    break;
                }
              }
              this.myForm.removeControl(ctrl.uniqueKey);
            }
          }
        }
        break;
      default: {
        break;
      }
    }
  }
  createNestedSubQuestionsForm(controls: JsonFormControls[], customValidation: any) {// To create form controls for nested subquestions
    switch (customValidation) {
      case "Yes":
        for (const control of controls) {
          if (control.subQuestion != undefined) {
            for (const ctrl of control.subQuestion) {
              if (ctrl.subQuestion != undefined) {
                for (const nested of ctrl.subQuestion) {
                  const nestedSubQuestionValidatorsToAdd = [];
                  for (const [key, value] of Object.entries(nested.validators)) {
                    switch (key) {
                      case 'min':
                        nestedSubQuestionValidatorsToAdd.push(Validators.min(value));
                        break;
                      case 'max':
                        nestedSubQuestionValidatorsToAdd.push(Validators.max(value));
                        break;
                      case 'required':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.required);
                        }
                        break;
                      case 'requiredTrue':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.requiredTrue);
                        }
                        break;
                      case 'email':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.email);
                        }
                        break;
                      case 'minLength':
                        nestedSubQuestionValidatorsToAdd.push(Validators.minLength(value));
                        break;
                      case 'maxLength':
                        nestedSubQuestionValidatorsToAdd.push(Validators.maxLength(value));
                        break;
                      case 'pattern':
                        nestedSubQuestionValidatorsToAdd.push(Validators.pattern(value));
                        break;
                      case 'nullValidator':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.nullValidator);
                        }
                        break;
                      default:
                        break;
                    }
                  }
                  if (nested.type == 'checkbox') {
                    this.myForm.addControl(
                      nested.uniqueKey,
                      this.fb.array([this.fb.group(nestedSubQuestionValidatorsToAdd)])
                    );
                  }
                  else {
                    this.myForm.addControl(
                      nested.uniqueKey,
                      this.fb.control(nested.value, nestedSubQuestionValidatorsToAdd)
                    );
                  }
                }
              }
            }
          }
        }
        break;
      case "No":
        for (const control of controls) {
          if (control.subQuestion != undefined) {
            for (const ctrl of control.subQuestion) {
              if (ctrl.subQuestion != undefined) {
                for (const nested of ctrl.subQuestion) {
                  const nestedSubQuestionValidatorsToAdd: ValidatorFn | ValidatorFn[] | AbstractControlOptions | null | undefined = [];
                  for (const [key, value] of Object.entries(nested.validators)) {
                    switch (key) {
                      case 'min':
                        nestedSubQuestionValidatorsToAdd.push(Validators.min(value));
                        break;
                      case 'max':
                        nestedSubQuestionValidatorsToAdd.push(Validators.max(value));
                        break;
                      case 'required':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.required);
                        }
                        break;
                      case 'requiredTrue':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.requiredTrue);
                        }
                        break;
                      case 'email':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.email);
                        }
                        break;
                      case 'minLength':
                        nestedSubQuestionValidatorsToAdd.push(Validators.minLength(value));
                        break;
                      case 'maxLength':
                        nestedSubQuestionValidatorsToAdd.push(Validators.maxLength(value));
                        break;
                      case 'pattern':
                        nestedSubQuestionValidatorsToAdd.push(Validators.pattern(value));
                        break;
                      case 'nullValidator':
                        if (value) {
                          nestedSubQuestionValidatorsToAdd.push(Validators.nullValidator);
                        }
                        break;
                      default:
                        break;
                    }
                  }
                  this.myForm.addControl(
                    nested.uniqueKey,
                    this.fb.control(nested.value, nestedSubQuestionValidatorsToAdd)
                  );
                  this.myForm.removeControl(nested.uniqueKey);
                }
              }
            }
          }
        }
        break;
      default: {
        break;
      }
    }
  }
  createSubNestedSubQuestionsForm(controls: JsonFormControls[], customValidation: any) {// To create formcontrols for subnested questions
    switch (customValidation) {
      case "Yes":
        for (const control of controls) {
          if (control.subQuestion != undefined) {
            for (const ctrl of control.subQuestion) {
              if (ctrl.subQuestion != undefined) {
                for (const nested of ctrl.subQuestion) {
                  for (const subNested of nested?.subQuestion) {
                    const subnNestedSubQuestionValidatorsToAdd = [];;
                    for (const [key, value] of Object.entries(subNested.validators)) {
                      switch (key) {
                        case 'min':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.min(value));
                          break;
                        case 'max':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.max(value));
                          break;
                        case 'required':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.required);
                          }
                          break;
                        case 'requiredTrue':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.requiredTrue);
                          }
                          break;
                        case 'email':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.email);
                          }
                          break;
                        case 'minLength':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.minLength(value));
                          break;
                        case 'maxLength':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.maxLength(value));
                          break;
                        case 'pattern':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.pattern(value));
                          break;
                        case 'nullValidator':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.nullValidator);
                          }
                          break;
                        default:
                          break;
                      }
                    }
                    if (subNested.type == 'checkbox') {
                      this.myForm.addControl(
                        subNested.uniqueKey,
                        this.fb.array([this.fb.group(subnNestedSubQuestionValidatorsToAdd)])
                      );
                    }
                    else {
                      this.myForm.addControl(
                        subNested.uniqueKey,
                        this.fb.control(subNested.value, subnNestedSubQuestionValidatorsToAdd)
                      );
                    }
                  }
                }
              }
            }
          }
        }
        break;
      case "No":
        for (const control of controls) {
          if (control.subQuestion != undefined) {
            for (const ctrl of control.subQuestion) {
              if (ctrl.subQuestion != undefined) {
                for (const nested of ctrl.subQuestion) {
                  for (const subNested of nested?.subQuestion) {
                    const subnNestedSubQuestionValidatorsToAdd = [];
                    for (const [key, value] of Object.entries(subNested.validators)) {
                      switch (key) {
                        case 'min':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.min(value));
                          break;
                        case 'max':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.max(value));
                          break;
                        case 'required':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.required);
                          }
                          break;
                        case 'requiredTrue':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.requiredTrue);
                          }
                          break;
                        case 'email':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.email);
                          }
                          break;
                        case 'minLength':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.minLength(value));
                          break;
                        case 'maxLength':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.maxLength(value));
                          break;
                        case 'pattern':
                          subnNestedSubQuestionValidatorsToAdd.push(Validators.pattern(value));
                          break;
                        case 'nullValidator':
                          if (value) {
                            subnNestedSubQuestionValidatorsToAdd.push(Validators.nullValidator);
                          }
                          break;
                        default:
                          break;
                      }
                    }
                    this.myForm.addControl(
                      subNested.uniqueKey,
                      this.fb.control(subNested.value, subnNestedSubQuestionValidatorsToAdd)
                    );
                    this.myForm.removeControl(subNested.uniqueKey);
                  }
                }
              }
            }
          }
        }
        break;
      default: {
        break;
      }
    }
  }
  onKey(event: any) {//To save ssn number without special characters
    this.ssn = event.target.value.replace(/-/g, "");
    sessionStorage.setItem('QuickAssessmentSSN', this.ssn);
  }
  ssnChange(controlName: any, formValues: any, event: any) { // SSN and Reason No SSN validation
    this.myForm.get('reasonNoSSN').clearValidators();
    this.myForm.get('reasonNoSSN').updateValueAndValidity();
    this.myForm.get('ssnNumber').setValidators([Validators.required, Validators.minLength(9)]);
    this.myForm.get('ssnNumber').updateValueAndValidity();
    this.myForm.controls['reasonNoSSN'].setValue(null);
    this.reasonNoSSN = null;
    if (event.target.value.length >= 9) {
      this.ssn = formValues[controlName];
      sessionStorage.setItem('QuickAssessmentSSN', this.ssn);
      sessionStorage.setItem('QuickAssessmentNoSSN', this.reasonNoSSN);
    }
  }
  noSSNChange(controlName: any, formValues: any, event: any) {
    this.myForm.get('ssnNumber').clearValidators();
    this.myForm.get('ssnNumber').updateValueAndValidity();
    this.myForm.get('reasonNoSSN').setValidators([Validators.required]);
    this.myForm.get('reasonNoSSN').updateValueAndValidity();
    this.myForm.controls['ssnNumber'].setValue(null);
    this.ssn = null;
    this.reasonNoSSN = formValues[controlName];
    sessionStorage.setItem('QuickAssessmentSSN', this.ssn);
    sessionStorage.setItem('QuickAssessmentNoSSN', this.reasonNoSSN);
  }
  toggleField() {// To show ssn number as password
    if (this.fieldType == 'text') this.fieldType = 'password';
    else this.fieldType = 'text';
  }
  handleKeyUp(event: any) {// Ssn validation
    if (event.keyCode === 13) {
      event.target.blur();
    }
  }
  inValidMessage() {
    console.log("Invalid");
  }
  async onSubmit(test: any, screenDirection: any) { // To submit form details
    
    if (this.myForm.controls['effectiveFrom']) {
      var newVal = this.datepipe.transform(this.bsValEffectiveFrom, 'MM/dd/yyyy');
      this.myForm.controls['effectiveFrom'].setValue(newVal);
      this.effectiveFrom = this.myForm.controls['effectiveFrom'].setValue(newVal);
      if (this.bsValTermination == 'Invalid Date' || this.bsValTermination == null || this.bsValTermination == undefined) {
        this.termination = "";
        this.myForm.controls['termination'].setValue(this.termination);
      }
      else if (this.terminationErrorMessage == '') {
        var terminationDate = this.datepipe.transform(this.bsValTermination, 'MM/dd/yyyy');
        this.termination = terminationDate;
        this.myForm.controls['termination'].setValue(terminationDate);
      }
    }
    
    if (!this.myForm.valid) {
      if (this.dynamicForm == undefined) {
        this.toshowrequiredMessage = true;
      }
      this.inValidMessage();
    }
    else if (this.terminationErrorMessage != '') {
      this.inValidMessage();
    }
    else {
      this.toshowrequiredMessage = false;
      this.screenId = this.jsonFormData.screens[0].screenId;
      this.saveFormDetails(test, screenDirection);
    }
  }
  saveFormDetails(test: any, screenDirection: any) {//To save form details
    for (let val of test.directives) {
      if (val.valueAccessor._elementRef == undefined) {
        if (val.valueAccessor._elRef?.nativeElement.attributes.fieldType.value == 'date') {
          var dobValue: any;
          if (val.viewModel != '') {
            let dob = new Date(val.viewModel);
            dobValue = dob.toLocaleDateString("en-US", {
              year: "numeric",
              day: "2-digit",
              month: "2-digit",
            });
          }
          else {
            dobValue = "";
          }
          this.myForm.controls[val.name].setValue(dobValue);
        }
      }
      if (val.name == 'email') {
        let email = val.viewModel.toLowerCase();
        this.myForm.controls[val.name].setValue(email);
      }
      if (val.name == 'cellNumber') {
        let cellNumber = val.viewModel.replace(/[- )(]/g, '');
        this.myForm.controls[val.name].setValue(cellNumber);
        this.countyCode = document.getElementById('countyCode');
        sessionStorage.setItem('CountyCode', this.countyCode.value);
      }
    }
    if (this.QuestionAndAnswer != null) {
      if (this.screenId == 1) {
        var patientSaved = this.QuestionAndAnswer.filter(e => e.screenId == 1)
        let patient = this.myForm.value.patient;
        if (patientSaved[0]?.patient != patient) {
          this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.GetDynamicQuestions, { headers: this.headers }).subscribe(async (response: any) => {
            if (response.wasSuccessful) {
              for (let screen = this.screenId; screen < response?.data?.screens?.length; screen++) {
                for (let controlArray = 0; controlArray < response?.data?.screens[screen]?.controls?.length; controlArray++) {
                  this.formData.screens[screen].controls[controlArray].value = response?.data?.screens[screen]?.controls[controlArray].value;
                  for (let subcontrolArray = 0; subcontrolArray < response?.data?.screens[screen]?.controls[controlArray]?.subQuestion?.length; subcontrolArray++) {
                    this.formData.screens[screen].controls[controlArray].subQuestion[subcontrolArray].value = response?.data?.screens[screen]?.controls[controlArray].subQuestion[subcontrolArray].value;
                  }
                }
              }
            }
          }, (error) => {
            console.log(error)
          });
          for (let screen = 0; screen <= this.screenId; screen++) {
            for (let controlArray = 0; controlArray < this.formData.screens[screen]?.controls?.length; controlArray++) {
              this.formData.screens[screen].controls[controlArray].value = '';
            }
          }
          this.values = [];
          this.QuestionAndAnswer = [];
        }
      }
      this.QuestionAndAnswer = this.QuestionAndAnswer.filter(e => e.screenId != this.screenId)
      var hasCheckboxControl = false;
      for (let i = 0; i < this.filterScreenDetails[0].controls.length; i++) {
        var checkedvalues = [];
        if (this.filterScreenDetails[0].controls[i].type == "checkbox") {
          this.myForm.controls[this.filterScreenDetails[0].controls[i].uniqueKey].value = [];
          for (let k = 0; k < this.filterScreenDetails[0].controls[i].options?.length; k++) {
            if (this.values[this.screenId + "_" + this.filterScreenDetails[0].controls[i].options[k]?.value]) {
              checkedvalues.push(this.filterScreenDetails[0].controls[i].options[k]?.value);
            }
          }
          this.myForm.controls[this.filterScreenDetails[0].controls[i].uniqueKey].value = checkedvalues;
          this.myForm.value[this.filterScreenDetails[0].controls[i].uniqueKey] = checkedvalues;
          hasCheckboxControl = true;
        }
      };
      if (hasCheckboxControl) {
        this.QuestionAndAnswer.push(this.myForm.value);
      }
      else {
        this.QuestionAndAnswer.push(this.myForm.getRawValue());
      }

    }
    sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer.sort(function (a, b) { return a.screenId - b.screenId; })));
    this.toRemoveControls();
    const partialAssessmentJson: any = {
      questionAnswerJson: sessionStorage.getItem('QuestionAndAnswer')
    }
    const partialAssessmentJson1: any = {
      quickAssessmentResultId: +(sessionStorage.getItem('resultID')!),
      questionAnswerJson: sessionStorage.getItem('QuestionAndAnswer')
    }
    if (sessionStorage.getItem('resultID') == "") {
      this.quickAssessmentService.savePartialAssessment(partialAssessmentJson).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.quickAssessmentResultId = result.data.quickAssessmentResultId;
          sessionStorage.setItem('resultID', result.data.quickAssessmentResultId);
        }
      }, (error) => {
        console.log(error)
      });
    }
    else {
      this.quickAssessmentService.updatePartialAssessment(partialAssessmentJson1).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
        }
      }, (error) => {
        console.log(error)
      });
    }
    if (screenDirection == 'forward')
      this.ForwardScreen();
    else if (screenDirection == 'backward')
      this.backToPreviousScreen();
  }
  ForwardScreen() {// To move to next screen
    
    this.toChangeFormSubmittedStatus();
    this.getScreenDetails(this.nextScreenId);
  }
  toChangeFormSubmittedStatus() {//To change form submitted status after submit form
    this.myForm.markAsPristine();
    this.myForm.markAsUntouched();
    this.toShowSubQuestions = false;
    this.toShowNestedSubQuestions = false;
    this.toShowSubNestedSubQuestions = false;
    this.myForm.reset();
  }
  redirection() {// To redirect
    window.location.href = "/"
  }
  async createNewAssessment() { //To create new assessment
    
    if (!this.myForm.valid) {
      console.log("Form is Invalid");
    }
    else {
      this.showLoader = true;
      this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
      var Data = JSON.parse(sessionStorage.getItem('QuestionAndAnswer') ?? "")?.filter((word: { screenId: any; }) => word.screenId == "2");
      sessionStorage.setItem('AssessmentCity',Data[0].city);
      sessionStorage.setItem('AssessmentState',Data[0].state);
      sessionStorage.setItem('AssessmentZipCode',Data[0].zipCode);
      
      const assessmentData: any = {
        loggedInUserId: +(sessionStorage.getItem('userId')!),
        ssn: this.ssn,
        reasonNoSsn: this.reasonNoSSN,
        isDynamic: (/true/i).test(sessionStorage.getItem('isDynamic')!),
        UserTime: new Date().toISOString(),
        QuestionAndAnswers: this.QuestionAndAnswer,
        QuestionAndAnswersJson: JSON.stringify(this.QuestionAndAnswer),
        quickAssessmentResultId: +(sessionStorage.getItem('resultID')!),
        assessmentContactDetails: {
          ZipCode: sessionStorage.getItem('AssessmentZipCode'),
          City: sessionStorage.getItem('AssessmentCity'),
          State: sessionStorage.getItem('AssessmentState'),
          county: "United States",
          countyCode: "1"
        }
      }
      this.quickAssessmentService.updateAssessmentDetails(assessmentData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          
          this.showLoader = false;
          this.router.navigate(['preliminary-results']);
          sessionStorage.setItem("assessmentId", result.data.assessmentId);
          sessionStorage.setItem('gender', result.data.gender);
          sessionStorage.setItem('patientId', result.data.basicInfoId);
          sessionStorage.setItem('age', result.data.age);
          sessionStorage.setItem('assessmentStatus', result.data.assessmentStatus);
          sessionStorage.setItem('assessmentPatientFullName', result.data.fullName);
          sessionStorage.setItem('assessmentUserId', result.data.assessmentUserId);
          sessionStorage.setItem('programNames', result.data.programNames);
          sessionStorage.setItem('override', result.data.override);
          sessionStorage.setItem('allPrograms', result.data.allPrograms);
        }
      }, (error) => {
        if (error.status == '500') {
          this.showLoader = false;
          if (error.error.errors[0] == StringConstants.toast.failToEvaluate) {
            this.router.navigate(['payment-options']);
          }
        }
        else if (error.status == '400') {
          this.showLoader = false;
          if (error.error.errors[0] == StringConstants.toast.patientWarning) {
            this.toastService.showError(StringConstants.toast.patientWarning, StringConstants.toast.empty);
          }
          else if (error.error.errors[0] == StringConstants.toast.userWarning) {
            this.toastService.showError(StringConstants.toast.userWarning, StringConstants.toast.empty);
          }
          else if (error.error.errors[0] == StringConstants.toast.failToEvaluate) {
            this.router.navigate(['payment-options']);
          }
        }
        else {
          console.log(error);
        }
      });
    }
  }
  space(e: any) {
    if (e.keyCode == 32) {
      e.preventDefault();
    }
  }
}
export interface QuestionAndAnswer {
  questionId: number;
  value: any;
  screenId: any;
}
export interface QuickAssessmentdynamicData {
  assessmentPatientId: number;
  loggedInUserId: number;
  QuestionAndAnswers: any[];
}
