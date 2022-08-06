import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { AdvocateDashboardService } from 'src/app/services/advocate-dashboard.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { DatePipe } from '@angular/common';
import DateValidation from 'src/app/components/controls/date-validation-control';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-start-assessment',
  templateUrl: './start-assessment.component.html',
  styleUrls: ['./start-assessment.component.css']
})
export class StartAssessmentComponent implements OnInit {
  virtualAssistPadding: string = "virtual-assist-padding";
  startAssessmentForm: any;
  today = new Date();
  patientName: any;
  dob: any;
  patientNameList: any;
  patientClick: any = "";
  isNextBtn: boolean = false;
  showWarning: any;
  currentTheme: any;
  bsVal: any;
  baseMethod: any;
  dobTextbox: any;
  dobErrorMessage: any;
  PatientInfoEnter=StringConstants.startAssessment.PatientInfoEnter;
  PatientNameReq=StringConstants.startAssessment.PatientNameReq;
  PatientNameAlp=StringConstants.startAssessment.PatientNameAlp;
  PatientNameMax=StringConstants.startAssessment.PatientNameMax;
  PatientNameMin=StringConstants.startAssessment.PatientNameMin;
  DateFormate=StringConstants.startAssessment.DateFormate;
  DateReq=StringConstants.startAssessment.DateReq;
  DateFormateFutureErr=StringConstants.startAssessment.DateFormateFutureErr;
  Locate=StringConstants.startAssessment.Locate;
  No=StringConstants.startAssessment.No;
  ConfirmPatientName=StringConstants.startAssessment.ConfirmPatientName;
  StartAssessmentInfo=StringConstants.startAssessment.StartAssessmentInfo;
  constructor(private datepipe: DatePipe, private Fb: FormBuilder, private httpClient: HttpClient, private dataSharing: DataSharingService, private router: Router, private toastService: ToastServiceService,
    private formbuilder: FormBuilder, private quickAssessmentService: QuickAssessmentService, private advocateDashboardService: AdvocateDashboardService) {
    this.dataSharing.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    this.dataSharing.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit(): void {
    
    this.dataSharing.hideVaForProfile.next(false);
    window.scroll(0, 0);
    this.initForm();
  }
  private initForm() {
    this.startAssessmentForm = new FormGroup({
      'patientName': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]),
      'dob': new FormControl('', [Validators.required, DateValidation.validateDateFormat, DateValidation.futureDateValidation]),
      'patient': new FormControl(''),
    });
  }
  clearData() {
    this.showWarning = null;
    this.isNextBtn = false;
    this.startAssessmentForm.controls['patient'].reset();
    this.captureDateInDatepicker();
  }
  keyPress(event: KeyboardEvent) {
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
      this.startAssessmentForm.controls['dob'].setValue(newVal);
    }
  }
  closeCalendarOnEnter() {
    DateValidation.closeCal();
    this.captureDateInDatepicker();
    let element: HTMLElement = document.getElementById('locate') as HTMLElement;
    element.click();
  }
  closeCalendar() {
    DateValidation.closeCal();
    this.captureDateInDatepicker();
  }
  captureDateInDatepicker() {
    if (this.startAssessmentForm.controls.dob.errors == null) {
      var bsValueDOB = this.startAssessmentForm.get('dob').value;
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
    var bsValueDOB = this.startAssessmentForm.get('dob').value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) {
        result = true;
      } else
        if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
          var date = new Date(bsValueDOB);
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
      this.startAssessmentForm.patchValue({
        dob: ""
      });
      this.bsVal = "";
      this.dobTextbox.focus();
      this.dobErrorMessage = futureValidation ? "Date of Birth can not be in future." : "Date must be in mm/dd/yyyy format.";
      this.startAssessmentForm.controls['dob'].setErrors({ pattern: true });
    } else {
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
      this.startAssessmentForm.controls['dob'].setValue(dateCheck);
      this.dobErrorMessage = "";
    }
  }
  // Date-picker JS ends here!
  searchName(patient: any) {
    if (!this.startAssessmentForm.valid) {
    } else {
      patient.dob = new Date(patient.dob);
      var dob = patient.dob.toLocaleDateString("en-US", {
        year: "numeric",
        day: "2-digit",
        month: "2-digit",
      })
      var advocateId: number = +(sessionStorage.getItem('userId')!);
      let patientDetails = {
        name: patient.patientName,
        dateOfBirth: dob,
        advocateId: advocateId
      }
      this.advocateDashboardService.createAdvocateAssessment(patientDetails).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.patientNameList = result.data.patientNames;
          if (this.patientNameList == "" || this.patientNameList == null) {
            //this.toastService.showWarning("No Records Found!","");
            this.showWarning = true;
            this.isNextBtn = false;
            this.startAssessmentForm.get('patient').reset();
          }
          else {
            this.showWarning = false;
          }
        }
      }, (error) => {
        console.log(error)
      });
    }
  }
  OnChangeOptions(value: any) {
    console.log(value);
  }
  navigateToQuickAssessment(startAssessmentForm: any) {
    this.dataSharing.ADDemographics.next(false);
    this.dataSharing.ADInsurance.next(false);
    this.dataSharing.ADHousehold.next(false);
    if (startAssessmentForm.patient != "") {
      this.patientClick = "";
      this.router.navigate(['advocate-quick-assessment']);
    }
    else {
      this.patientClick = "Please select patient name!"
    }
  }
  OnClickPatientName(patient: boolean, patientId: any, patientName: any) {
    sessionStorage.removeItem('QuestionAndAnswer');
    sessionStorage.removeItem('QuickAssessmentSSN');
    sessionStorage.removeItem('UpdateFirstName');
    sessionStorage.removeItem('UpdateLastName');
    sessionStorage.removeItem('UpdateDateOfBirth');
    sessionStorage.removeItem('UpdateZipCode');
    sessionStorage.removeItem('UpdateCity');
    sessionStorage.removeItem('UpdateState');
    sessionStorage.setItem('patientId', patientId);
    sessionStorage.setItem("quickAssessmentPatientName", patientName);
    this.isNextBtn = true;
  }
}
