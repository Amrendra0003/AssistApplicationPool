import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-quick-assessment',
  templateUrl: './quick-assessment.component.html',
  styleUrls: ['./quick-assessment.component.css']
})
export class QuickAssessmentComponent implements OnInit {
  demographicsFlag: boolean = true;
  insuranceFlag: boolean = false;
  householdFlag: boolean = false;
  generalQuestionsFlag: boolean = false;
  verificationFlag: boolean = false;
  result: any;
  patientName: any;
  currentTheme: any;
  Demographics = StringConstants.quickAssessment1.Demographics;
  GeneralQuestionsMsg = StringConstants.quickAssessment1.GeneralQuestionsMsg;
  QuickAssessment = StringConstants.quickAssessment1.QuickAssessment;
  QMB = StringConstants.quickAssessment1.QMB;
  SNF = StringConstants.quickAssessment1.SNF;
  AddBaby = StringConstants.quickAssessment1.AddBaby;
  Verification = StringConstants.quickAssessment1.Verification;
  Household = StringConstants.quickAssessment1.Household;
  Insurance = StringConstants.quickAssessment1.Insurance;
  DComplete: string = "";
  HComplete: string = "";
  IComplete: string = "";
  constructor(private quickAssessmentService: QuickAssessmentService,
    private dataSharingService: DataSharingService, private router: Router) {
      
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.callGeneralQuestionsTab.subscribe(value => {
      if (value == true) {
        this.advocateGeneralQuestionClickedEvent(true);
      }
    });
    this.dataSharingService.callHouseholdTab.subscribe(value => {
      if (value == true) {
        this.advocateHouseholdClickedEvent(true);
      }
    });
    this.dataSharingService.callVerificationTab.subscribe(value => {
      if (value == true) {
        this.advocateSsnClickedEvent(true);
      }
    });
    this.dataSharingService.callInsuranceTab.subscribe(value => {
      if (value == true) {
        this.advocateInsuranceClickedEvent(true);
      }
    });
    this.dataSharingService.callDemographicsTab.subscribe(value => {
      if (value == true) {
        this.advocateDemographicsClickedEvent(true);
      }
    });
    this.dataSharingService.completeDemo.subscribe(value => {
      this.DComplete = value;
    });
    this.dataSharingService.completeHousehold.subscribe(value => {
      this.HComplete = value;
    });
    this.dataSharingService.completeInsurance.subscribe(value => {
      this.IComplete = value;
    });
  }
  ngOnInit(): void {
    this.dataSharingService.hideVaForProfile.next(false);
    window.scroll(0, 0);
    this.patientName = sessionStorage.getItem("quickAssessmentPatientName");
    this.demographics();
    this.resetValidation();
  }
  resetValidation() {
    this.dataSharingService.completeDemo.next("");
    this.dataSharingService.completeHousehold.next("");
    this.dataSharingService.completeInsurance.next("");
  }
  demographics() {
    if (this.dataSharingService.advocateDemographicsSaveDetails == true) {
      this.demographicsFormDetailsSaved("demographics");
    }
    else if (this.dataSharingService.advocateInsuranceSaveDetails == true) {
      this.insuranceFormDetailsSaved("demographics");
    }
    else if (this.dataSharingService.advocateHouseholdSaveDetails == true) {
      this.householdFormDetailsSaved("demographics");
    }
    else if (this.dataSharingService.advocateGeneralQuestionsSaveDetails == true) {
      this.generalQuestionsFormDetailsSaved("demographics");
    }
    else {
      this.demographicsFlag = true;
      this.insuranceFlag = false;
      this.householdFlag = false;
      this.generalQuestionsFlag = false;
      this.verificationFlag = false;
    }
  }
  advocateDemographicsClickedEvent(message: boolean): void {
    this.demographicsFlag = true;
    this.insuranceFlag = false;
    this.householdFlag = false;
    this.generalQuestionsFlag = false;
    this.verificationFlag = false;
    this.dataSharingService.callDemographicsTab.next(false);
  }
  demographicsFormDetailsSaved(nextTab: any) {
    this.dataSharingService.setAdvocateDemographicsLoaderState(nextTab);
    this.dataSharingService.advocateGeneralQuestionsSaveDetails = false;
    this.dataSharingService.advocateInsuranceSaveDetails = false;
    this.dataSharingService.advocateHouseholdSaveDetails = false;
  }
  insuranceFormDetailsSaved(nextTab: any) {
    this.dataSharingService.setAdvocateInsuranceLoaderState(nextTab);
    this.dataSharingService.advocateDemographicsSaveDetails = false;
    this.dataSharingService.advocateHouseholdSaveDetails = false;
    this.dataSharingService.advocateGeneralQuestionsSaveDetails = false;
  }
  householdFormDetailsSaved(nextTab: any) {
    this.dataSharingService.setAdvocateHouseholdLoaderState(nextTab);
    this.dataSharingService.advocateDemographicsSaveDetails = false;
    this.dataSharingService.advocateInsuranceSaveDetails = false;
    this.dataSharingService.advocateGeneralQuestionsSaveDetails = false;
  }
  generalQuestionsFormDetailsSaved(nextTab: any) {
    this.dataSharingService.setAdvocateGeneralQuestionsLoaderState(nextTab);
    this.dataSharingService.advocateDemographicsSaveDetails = false;
    this.dataSharingService.advocateInsuranceSaveDetails = false;
    this.dataSharingService.advocateHouseholdSaveDetails = false;
  }
  insurance() {
    if (this.dataSharingService.advocateDemographicsSaveDetails == true) {
      this.demographicsFormDetailsSaved("insurance");
    }
    else if (this.dataSharingService.advocateInsuranceSaveDetails == true) {
      this.insuranceFormDetailsSaved("insurance");
    }
    else if (this.dataSharingService.advocateHouseholdSaveDetails == true) {
      this.householdFormDetailsSaved("insurance");
    }
    else if (this.dataSharingService.advocateGeneralQuestionsSaveDetails == true) {
      this.generalQuestionsFormDetailsSaved("insurance");
    }
    else {
      this.dataSharingService.advocateDemographicsSaveDetails = false;
      this.demographicsFlag = false;
      this.insuranceFlag = true;
      this.householdFlag = false;
      this.generalQuestionsFlag = false;
      this.verificationFlag = false;
    }
  }
  advocateInsuranceClickedEvent(message: boolean): void {
    this.demographicsFlag = false;
    this.insuranceFlag = true;
    this.householdFlag = false;
    this.generalQuestionsFlag = false;
    this.verificationFlag = false;
    this.dataSharingService.callInsuranceTab.next(false);
  }
  household() {
    if (this.dataSharingService.advocateDemographicsSaveDetails == true) {
      this.demographicsFormDetailsSaved("household");
    }
    else if (this.dataSharingService.advocateInsuranceSaveDetails == true) {
      this.insuranceFormDetailsSaved("household");
    }
    else if (this.dataSharingService.advocateHouseholdSaveDetails == true) {
      this.householdFormDetailsSaved("household");
    }
    else if (this.dataSharingService.advocateGeneralQuestionsSaveDetails == true) {
      this.generalQuestionsFormDetailsSaved("household");
    }
    else {
      this.dataSharingService.advocateInsuranceSaveDetails = false;
      this.demographicsFlag = false;
      this.insuranceFlag = false;
      this.householdFlag = true;
      this.generalQuestionsFlag = false;
      this.verificationFlag = false;
    }
  }
  advocateHouseholdClickedEvent(message: boolean): void {
    this.demographicsFlag = false;
    this.insuranceFlag = false;
    this.householdFlag = true;
    this.generalQuestionsFlag = false;
    this.verificationFlag = false;
    this.dataSharingService.callHouseholdTab.next(false);
  }
  GeneralQuestions() {
    if (this.dataSharingService.advocateDemographicsSaveDetails == true) {
      this.demographicsFormDetailsSaved("generalQuestions");
    }
    else if (this.dataSharingService.advocateInsuranceSaveDetails == true) {
      this.insuranceFormDetailsSaved("generalQuestions");
    }
    else if (this.dataSharingService.advocateHouseholdSaveDetails == true) {
      this.householdFormDetailsSaved("generalQuestions");
    }
    else if (this.dataSharingService.advocateGeneralQuestionsSaveDetails == true) {
      this.generalQuestionsFormDetailsSaved("generalQuestions");
    }
    else {
      this.dataSharingService.advocateHouseholdSaveDetails = false;
      this.demographicsFlag = false;
      this.insuranceFlag = false;
      this.householdFlag = false;
      this.generalQuestionsFlag = true;
      this.verificationFlag = false;
    }
  }
  advocateGeneralQuestionClickedEvent(message: boolean): void {
    this.demographicsFlag = false;
    this.insuranceFlag = false;
    this.householdFlag = false;
    this.generalQuestionsFlag = true;
    this.verificationFlag = false;
    this.dataSharingService.callGeneralQuestionsTab.next(false);

  }
  verification() {
    if (this.dataSharingService.advocateDemographicsSaveDetails == true) {
      this.demographicsFormDetailsSaved("verification");
    }
    else if (this.dataSharingService.advocateInsuranceSaveDetails == true) {
      this.insuranceFormDetailsSaved("verification");
    }
    else if (this.dataSharingService.advocateHouseholdSaveDetails == true) {
      this.householdFormDetailsSaved("verification");
    }
    else if (this.dataSharingService.advocateGeneralQuestionsSaveDetails == true) {
      this.generalQuestionsFormDetailsSaved("verification");
    }
    else {
      this.dataSharingService.advocateGeneralQuestionsSaveDetails = false;
      this.demographicsFlag = false;
      this.insuranceFlag = false;
      this.householdFlag = false;
      this.generalQuestionsFlag = false;
      this.verificationFlag = true;
    }
  }
  advocateSsnClickedEvent(message: boolean): void {
    this.demographicsFlag = false;
    this.insuranceFlag = false;
    this.householdFlag = false;
    this.generalQuestionsFlag = false;
    this.verificationFlag = true;
    this.dataSharingService.callVerificationTab.next(false);
  }
}
