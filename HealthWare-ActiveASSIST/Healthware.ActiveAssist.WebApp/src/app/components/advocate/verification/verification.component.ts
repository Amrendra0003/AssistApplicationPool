import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { DropdownService } from 'src/app/services/dropdown.service';
import { CommonService } from 'src/app/services/common.service';
@Component({
  selector: 'app-verification',
  templateUrl: './verification.component.html',
  styleUrls: ['./verification.component.css']
})
export class VerificationComponent implements OnInit {
  verificationForm: any;
  ssn: any;
  reasonNoSSN: any;
  isCheck: boolean = false;
  fieldType: string = 'password';
  QuestionAndAnswer: QuestionAndAnswer[] = [];
  checkValue: boolean = false;
  currentTheme: any;
  showLoader: boolean = false;
  demographicsValue: boolean = false;
  insuranceValue: boolean = false;
  householdValue: boolean = false;
  provideSSN = StringConstants.verification.provideSSN;
  VerificationMsg1 = StringConstants.verification.VerificationMsg1;
  VerificationMsg2 = StringConstants.verification.VerificationMsg2;
  SSNReq = StringConstants.verification.SSNReq;
  SSNPatientId = StringConstants.verification.SSNPatientId;
  AcceptPrivacyStatement = StringConstants.verification.AcceptPrivacyStatement;
  @Output() demographicsSaveDetailsClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  DDone: any;
  IDone: any;
  HDone: any;
  click: any;
  ssnValid: boolean = false;
  buttonLabel: string = StringConstants.ssn.buttonLabel;
  closeResult = '';
  clickVTab: any = null;
  reasons: any;
  constructor(private common:CommonService, private dropdownService: DropdownService, private quickAssessmentService: QuickAssessmentService, private modalService: NgbModal, private dataSharingService: DataSharingService, private router: Router, private toastService: ToastServiceService) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.validateDemographicsStopForm.subscribe(value => {
      this.demographicsValue = value;
    });
    this.dataSharingService.validateInsuranceStopForm.subscribe(value => {
      this.insuranceValue = value;
    });
    this.dataSharingService.validateHouseholdStopForm.subscribe(value => {
      this.householdValue = value;
    });
    this.dataSharingService.callVerificationTab.subscribe(value => {
      this.clickVTab = value;
      if (value)
        this.dataSharingService.callVerificationTab.next(false);
    });
    this.dataSharingService.ADDemographics.subscribe(value => {
      this.DDone = value;
      if (this.clickVTab == false && this.DDone == false) {
        this.dataSharingService.completeDemo.next("false");
      }
    });
    this.dataSharingService.ADInsurance.subscribe(value => {
      this.IDone = value;
      if (this.clickVTab == false && this.IDone == false) {
        this.dataSharingService.completeInsurance.next("false");
      }
    });
    this.dataSharingService.ADHousehold.subscribe(value => {
      this.HDone = value;
      if (this.clickVTab == false && this.HDone == false) {
        this.dataSharingService.completeHousehold.next("false");
      }
    });
  }
  ngOnInit(): void {
    window.scroll(0, 0);
    this.initForm();
    this.getReasonNoSSN();
    this.ssn = sessionStorage.getItem('QuickAssessmentSSN');
    this.reasonNoSSN = sessionStorage.getItem('QuickAssessmentNoSSN');
    this.fieldType == 'password';
    if (this.ssn == null || this.ssn == "") {
      this.verificationForm.get('ssn').clearValidators();
      this.verificationForm.get('ssn').updateValueAndValidity();
      this.verificationForm.get('reasonNoSSN').setValidators([Validators.required]);
      this.verificationForm.get('reasonNoSSN').updateValueAndValidity();
    }
    else {
      this.verificationForm.get('reasonNoSSN').clearValidators();
      this.verificationForm.get('reasonNoSSN').updateValueAndValidity();
      this.verificationForm.get('ssn').setValidators([Validators.required]);
      this.verificationForm.get('ssn').updateValueAndValidity();
    }
  }
  private initForm() {
    this.verificationForm = new FormGroup({
      'ssn': new FormControl(''),
      'checkValue': new FormControl('', [Validators.required]),
      'reasonNoSSN': new FormControl(''),
    });
  }
  ssnChange(event: any) {
    this.verificationForm.get('reasonNoSSN').clearValidators();
    this.verificationForm.get('reasonNoSSN').updateValueAndValidity();
    this.verificationForm.get('ssn').setValidators([Validators.required, Validators.minLength(9)]);
    this.verificationForm.get('ssn').updateValueAndValidity();
    this.reasonNoSSN = "";
    if (event.target.value.length == 9) {
      this.ssn = event.target.value;
      sessionStorage.setItem('QuickAssessmentSSN', this.ssn);
      sessionStorage.setItem('QuickAssessmentNoSSN', this.reasonNoSSN);
    }
  }
  noSSNChange() {
    this.verificationForm.get('ssn').clearValidators();
    this.verificationForm.get('ssn').updateValueAndValidity();
    this.verificationForm.get('reasonNoSSN').setValidators([Validators.required]);
    this.verificationForm.get('reasonNoSSN').updateValueAndValidity();
    this.ssn = "";
  }
  async getReasonNoSSN() { //To get reasonNoSSN values
    this.reasons = await this.common.getReasonNoSSN();
  }
  toggleField() {
    if (this.fieldType == 'text') this.fieldType = 'password';
    else this.fieldType = 'text';
  }
  CheckBoxvalue(event: any) {
    if (event.target.checked) {
      this.checkValue = true;
    }
    else {
      this.checkValue = false;
    }
  }
  resetTabStatus() {
    this.dataSharingService.SaveQuickAssessment.next("");
    this.dataSharingService.SavePersonal.next("");
    this.dataSharingService.SavePersonalHome.next("");
    this.dataSharingService.SaveGuarantor.next("");
    this.dataSharingService.SaveGuarantorHome.next("");
    this.dataSharingService.SaveHousehold.next("");
    this.dataSharingService.SaveContactPreference.next("");
    this.dataSharingService.SaveHousehold.next("");
    this.dataSharingService.SaveApplicationForms.next("");
    this.dataSharingService.SavePrograms.next("");
    this.dataSharingService.SaveVerification.next("");
  }
  open(content: any) {
    this.modalService.open(content,
      { ariaLabelledBy: 'modal-basic-title' }).result.then((result) => {
        this.closeResult = `Closed with: ${result}`;
      }, (reason) => {
        this.closeResult =
          `Dismissed ${this.getDismissReason(reason)}`;
      });
  }
  private getDismissReason(reason: any): string {
    if (reason === ModalDismissReasons.ESC) {
      return 'by pressing ESC';
    } else if (reason === ModalDismissReasons.BACKDROP_CLICK) {
      return 'by clicking on a backdrop';
    } else {
      return `with: ${reason}`;
    }
  }
  saveDetails(patientDetails: any) {
    let isGuarantor = (/true/i).test(sessionStorage.getItem('isPatientGuarantor')!)
    if (!this.verificationForm.valid && !(this.verificationForm.disabled)) {
    } else {
      this.showLoader = true;
      this.QuestionAndAnswer = (JSON.parse(sessionStorage.getItem('QuestionAndAnswer')!));
      sessionStorage.setItem('QuestionAndAnswer', JSON.stringify(this.QuestionAndAnswer));
      const assessmentData: any = {
        basicInfoId: +(sessionStorage.getItem('patientId')!),
        loggedInUserId: +(sessionStorage.getItem('userId')!),
        ssn: patientDetails.ssn.replace(/-/g, ""),
        reasonNoSsn: patientDetails.reasonNoSSN,
        UserTime: new Date().toISOString(),
        isInsuranceAvailable: (/true/i).test(sessionStorage.getItem('isInsuranceAvailable')!),
        QuestionAndAnswers: this.QuestionAndAnswer,
        assessmentContactDetails: {
          ZipCode: sessionStorage.getItem('AssessmentZipCode'),
          City: sessionStorage.getItem('AssessmentCity'),
          State: sessionStorage.getItem('AssessmentState'),
          StateCode: sessionStorage.getItem('AssessmentStateCode'),
          county: "United States",
          countyCode: sessionStorage.getItem('CountyCode')
        },
        guarantorInfo: {
          relationshipWithPatient: sessionStorage.getItem('contactRelationShip'),
          firstName: sessionStorage.getItem('contactRelationFirstName'),
          middleName: sessionStorage.getItem('contactRelationMiddleName'),
          lastName: sessionStorage.getItem('contactRelationLastName'),
          email: sessionStorage.getItem('contactRelationEmail'),
          countyCode: sessionStorage.getItem('contactRelationCountyCode'),
          cellNumber: sessionStorage.getItem('contactRelationCellNumber'),
          isGuarantor: isGuarantor
        }
      }
      this.quickAssessmentService.updateAssessmentDetails(assessmentData).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.showLoader = false;
          this.dataSharingService.ADDemographics.next(false);
          this.dataSharingService.ADInsurance.next(false);
          this.dataSharingService.ADHousehold.next(false);
          this.resetTabStatus();
          sessionStorage.setItem("assessmentId", result.data.assessmentId);
          sessionStorage.setItem('gender', result.data.gender);
          sessionStorage.setItem('patientId', result.data.basicInfoId);
          sessionStorage.setItem('age', result.data.age);
          sessionStorage.setItem('assessmentStatus', result.data.assessmentStatus);
          sessionStorage.setItem('assessmentPatientFullName', result.data.fullName);
          sessionStorage.setItem('assessmentUserId', result.data.assessmentUserId);
          sessionStorage.setItem('submittedOn', result.data.submittedOn);
          sessionStorage.setItem('isEditable', "true");
          sessionStorage.setItem('statusDisplay', "Yet To Submit");
          this.router.navigate(['detail-assessment'], { queryParams: { tab: 0 } });
        }
      }, (error) => {
        if (error.status = '500') {
          this.showLoader = false;
          if (error.error.errors[0] == StringConstants.toast.failToEvaluate) {
            this.router.navigate(['payment-options']);
          }
          else if (error.error.errors[0] == StringConstants.toast.patientWarning) {
            this.toastService.showError(StringConstants.toast.patientWarning, StringConstants.toast.empty);
          }
          else if (error.error.errors[0] == StringConstants.toast.userWarning) {
            this.toastService.showError(StringConstants.toast.userWarning, StringConstants.toast.empty);
          }
        }
        console.log(error)
      });
    }
  }
  async createAssessment(patientDetails: any) {
    this.dataSharingService.validateDemographicsForm.next(true);
    this.dataSharingService.validateHouseholdForm.next(true);
    this.dataSharingService.validateInsuranceForm.next(true);
    if (this.checkValue == false) {
      this.toastService.showWarning(StringConstants.toast.termsAndConditions, StringConstants.toast.empty);
    }
    else if (this.demographicsValue == true && this.insuranceValue == true && this.householdValue == true) {
      this.saveDetails(patientDetails);
    }
  }
}
export interface QuestionAndAnswer {
  ScreenQuestionMappingId: number;
  AnswerOptionId: number;
  questionId: number;
  Description: string;
  value: any;
  screenId: any;
}
export interface QuickAssessmentdynamicData {
  assessmentPatientId: number;
  loggedInUserId: number;
  QuestionAndAnswers: QuestionAndAnswer[];
}