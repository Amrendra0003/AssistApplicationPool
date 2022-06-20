import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: "root"
})
export class DataSharingService {
  /*Advocate Demographics save details*/
  public advocateDemographicsSaveDetails: boolean = false;
  private advocateDemographics = new BehaviorSubject(false);
  advocateDemographicsLoaderState = this.advocateDemographics.asObservable();
  getAdvocateDemographicsLoaderState() {
    return this.advocateDemographicsLoaderState;
  }
  setAdvocateDemographicsLoaderState(value: any) {
    this.advocateDemographics.next(value);
  }
  /*Advocate Insurance save details*/
  public advocateInsuranceSaveDetails: boolean = false;
  private advocateInsurance = new BehaviorSubject(false);
  advocateInsuranceLoaderState = this.advocateInsurance.asObservable();
  getAdvocateInsuranceLoaderState() {
    return this.advocateInsuranceLoaderState;
  }
  setAdvocateInsuranceLoaderState(value: any) {
    this.advocateInsurance.next(value);
  }
  /*Advocate Household save details*/
  public advocateHouseholdSaveDetails: boolean = false;
  private advocateHousehold = new BehaviorSubject(false);
  advocateHouseholdLoaderState = this.advocateHousehold.asObservable();
  getAdvocateHouseholdLoaderState() {
    return this.advocateHouseholdLoaderState;
  }
  setAdvocateHouseholdLoaderState(value: any) {
    this.advocateHousehold.next(value);
  }
  /*Advocate General Questions save details*/
  public advocateGeneralQuestionsSaveDetails: boolean = false;
  private advocateGeneralQuestions = new BehaviorSubject(false);
  advocateGeneralQuestionsLoaderState = this.advocateGeneralQuestions.asObservable();
  getAdvocateGeneralQuestionsLoaderState() {
    return this.advocateGeneralQuestionsLoaderState;
  }
  setAdvocateGeneralQuestionsLoaderState(value: any) {
    this.advocateGeneralQuestions.next(value);
  }
  public callGeneralQuestionsTab: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public callVerificationTab: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public callHouseholdTab: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public callInsuranceTab: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public callDemographicsTab: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  /*Advocate create assessment validation*/
  public validateDemographicsForm: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public validateInsuranceForm: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public validateHouseholdForm: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public validateDemographicsStopForm: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public validateInsuranceStopForm: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public validateHouseholdStopForm: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public allowLanding: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
  public showloginButton: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public showUserNameInHeader: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public showApplicationFormNext: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public showPersonalTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public showGuarantorTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public showHouseholdTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public showContactPreferenceTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public showQuickAssessmentResultsTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public ShowVerificationTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public ShowProgramsTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public ShowFormsTab: BehaviorSubject<string> = new BehaviorSubject<string>("0");
  public LoadProfileImage: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public LoadUserImage: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public isGuarantorData: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public changeFullName: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public changeFirstName: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public alterPaddingForVA: BehaviorSubject<string> = new BehaviorSubject<string>("virtual-assist-padding");
  public beginFlag: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  /* To open virtual assistance*/
  /* Navigation*/
  public MoveToGWork: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public MoveToPWork: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public MoveToForms: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  /* Validation Summary*/
  // Final Check
  public EnableSubmit: BehaviorSubject<string> = new BehaviorSubject<string>("false");
  // Check Details
  public EnableDocumentation: BehaviorSubject<string> = new BehaviorSubject<string>("false");
  //Personal
  public SavePersonal: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public SavePersonalInfo: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public SavePersonalHome: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public SavePersonalWork: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Guarantor
  public SaveGuarantor: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public SaveGuarantorInfo: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public SaveGuarantorHome: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public SaveGuarantorWork: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Quick Assessment
  public SaveQuickAssessment: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Contact Preference
  public SaveContactPreference: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Household
  public SaveHousehold: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Verification
  public SaveVerification: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Application Forms
  public SaveApplicationForms: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Programs
  public SavePrograms: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Ask Assistane help
  public askAssistanceHelp: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  //To change status
  public changeAssessmentStatus: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Profile Settings
  public navigateToChangePassword: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //logout
  public logoutTriggered: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  //Themes Changed
  public changeTheme: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //Evaluate Household!
  public evaluateHousehold: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  //Tab Selected!
  public Tab: BehaviorSubject<number> = new BehaviorSubject<number>(0);
  //To hide VA
  public hideVaForProfile: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  //Send ProgramID
  public sendProgramID: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //update Summary panel
  public updatepersonalAdvocateUpdateSummary: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public updateguarantorAdvocateUpdateSummary: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public updateContactPreferenceAdvocateUpdateSummary: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public toCallDynamicQuestionsNewScreen: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public toCallDynamicQuestionsBackScreen: BehaviorSubject<any> = new BehaviorSubject<any>("");
  public toShowSubQuestions: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public toShowCityAndState: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public toShowScreen: BehaviorSubject<any> = new BehaviorSubject<string>("");
  //Assessmentstatus - Edit
  public editable: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
  //FileUpload
  public esignFileUpload: BehaviorSubject<[File, string]> = new BehaviorSubject<[File, string]>([(new File([], "")), ""]);
  //Advocate - Quick Assessment Validation!
  public ADDemographics: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public ADInsurance: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  public ADHousehold: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
  //Advocate Validation!
  public completeDemo: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public completeHousehold: BehaviorSubject<string> = new BehaviorSubject<string>("");
  public completeInsurance: BehaviorSubject<string> = new BehaviorSubject<string>("");
  //canCreateAssessment!
  public canCreate: BehaviorSubject<boolean> = new BehaviorSubject<boolean>(true);
  //check login!
  public isLoggedIn:BehaviorSubject<boolean> = new BehaviorSubject<boolean>(false);
}