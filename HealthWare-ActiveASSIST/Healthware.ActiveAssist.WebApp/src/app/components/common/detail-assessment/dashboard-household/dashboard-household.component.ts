import { Component, EventEmitter, Input, OnInit, Output, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { DropdownService } from 'src/app/services/dropdown.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { DatePipe } from '@angular/common';
import DateValidation from 'src/app/components/controls/date-validation-control';
import { StringConstants } from 'src/assets/constants/string.constants';
import { AuthService } from 'src/app/services/auth.service';
import { CommonService } from 'src/app/services/common.service';
declare var $: any;
@Component({
  selector: 'app-dashboard-household',
  templateUrl: './dashboard-household.component.html',
  styleUrls: ['./dashboard-household.component.css']
})
export class DashboardHouseholdComponent implements OnInit {
  today = new Date();
  panelOpenStateDemographic: boolean = true;
  panelOpenStateAddNewMember: boolean = true;
  memberListFlag: boolean = true;
  addMemberFlag: boolean = false;
  result: any;
  incomeResult: any;
  householdMemberId: any;
  canDelete: any;
  createFlag: boolean = true;
  addMemberForm: any;
  householdIncomeForm: any;
  householdResourceForm: any;
  IncomeForm: any;
  householdDemographicForm: any;
  CalculatedValue: any;
  DateOfBirth: any;
  firstName: any;
  lastName: any;
  middleName: any;
  suffix: any;
  relation: any = "";
  isSelfRelationChanged: boolean = false;
  isSelfRelationReadOnly: boolean = false;
  dateOfBirth: any;
  gender: any = "";
  maritalStatus: any = "";
  ssn: any;
  sssn: any;
  reasonNoSSN: any;
  ssnNumberValue: any;
  isInsurance: any;
  isMedicalAid: any;
  incomeType: string = "";
  currentStatus: string = StringConstants.dashboardHouseholdMember.current;
  acceptStatus: string = "";
  grossPay: any;
  grossPayPeriod: string = StringConstants.dashboardHouseholdMember.monthly;
  contactName: any;
  companyName: any;
  streetAddress: any;
  city: any;
  state: string = "";
  zipCode: any;
  cellNumber: any;
  faxNumber: any;
  resourceType: string = "";
  resourceStatus: string = StringConstants.dashboardHouseholdMember.currentlyOwned;
  resourceAcceptStatus: string = "";
  resourceIncomeAmt: any;
  ownership: any;
  locationName: any;
  isInsuranceAvailable: any;
  isDependent: any;
  isMedicAidAvailable: any;
  GrossPay: any;
  IncomeType: any;
  LastName: any;
  MiddleName: any;
  Relationship: any;
  ResourceType: any;
  totalMembers: any;
  minors: any;
  totalMonthlyIncome: any;
  totalResource: any;
  patientId: any;
  incomeId: any;
  resourceResult: any;
  incomeFlag: any;
  resourceFlag: any;
  contactDetailsId: any;
  resourceId: any;
  resourcecalculatedValue: any;
  resourceTotalcalculatedValue: any;
  incomecalculatedValue: any;
  memberListEmptyFlag: boolean = false;
  countryCode: string = "1";
  monthlyIncome: any;
  resourceValue: any;
  loginUserMail: any;
  relationval: any;
  martialStatusVal: any;
  genderval: any;
  incomeval: any;
  incomeCurrentStatusVal: any;
  verificationVal: any;
  grossPayPeriodVal: any;
  resourceCurrentVal: any;
  resourceVal: any;
  incomeTableFlag: boolean = false;
  resourceTableFlag: boolean = false;
  resourceTotalIncomeAmt: any;
  householdmemberIncomeDetailsTemp: any;
  addIncomeOptionFlag: boolean = true;
  addResourceOptionFlag: boolean = true;
  incomebuttonFlag: boolean = true;
  resourcebuttonFlag: boolean = true;
  newDetailFlag: boolean = true;
  IncomeDetails: IncomeDetails[] = [];
  ResourceDetails: ResourceDetails[] = [];
  incomeMap = new Map<number, IncomeDetails>();
  _incomeMap = new Map<number, IncomeDetails>();
  resourceMap = new Map<number, ResourceDetails>();
  _resourceMap = new Map<number, ResourceDetails>();
  editIncomeDetails: any;
  editResourceDetails: any;
  internalresourceId: any;
  internalIncomeId: any;
  deletedresourceId: any;
  deletedincomeId: any;
  resourcebuttonText: string = "Add Resource";
  isResourceClicked: boolean = false;
  isIncomeClicked: boolean = false;
  _panelOpenStateIncome: boolean = false;
  _panelOpenStateResource: boolean = false;
  isEditAllowed: boolean = true;
  assessmentStatus: any;
  editToolTip: string = "Edit";
  deleteToolTip: string = "Delete";
  householdMoreOptions: any = {};
  isMenuOn = false;
  showLoader: boolean = false;
  isHouseholdAdded: any;
  isQuickSaved: any;
  isPersonalSaved: any;
  isGuarantorSaved: any;
  isContactSaved: any;
  isPersonalHome: any;
  isGuarantorInfo: any;
  isGuarantorHome: any;
  isDetailsDone: boolean = false;
  virtualAssistPadding: string = "virtual-assist-padding";
  validZip: any;
  currentTheme: any;
  deleteHouseholdMemberId: any;
  maskEnabled: boolean = true;
  stateCode: any;
  bsVal: any = "";
  dobTextbox: any;
  showAdvocatePanel: any;
  verificationLabel: any = StringConstants.dashboardHouseholdMember.verification;
  incomeStatus: any = StringConstants.dashboardHouseholdMember.incomeStatus;
  payerName: any = "";
  groupName: any = "";
  groupNumber: any = "";
  policyNumber: any = "";
  effectiveFrom: any = "";
  termination: any = "";
  medicalId: any = "";
  medicalState: any = "";
  medicalEffectiveFrom: any = "";
  medicalTermination: any = "";
  bsValEffectiveFrom: any;
  bsValTermination: any;
  bsValMedicalEffectiveFrom: any;
  bsValMedicalTermination: any;
  terminationTextBox: any;
  effectiveTextbox: any;
  medicalTerminationTextBox: any;
  medicalEffectiveTextbox: any;
  effectiveFromErrorMessage: string = '';
  terminationErrorMessage: string = '';
  medicalEffectiveFromErrorMessage: string = '';
  medicalTerminationErrorMessage: string = '';
  showMedicalAidFields: boolean = false;
  showPriorCoverageFields: boolean = false;
  tempMsg: any;
  isInsuranceRequiredMessage: string = "";
  isMedicalAidRequiredMessage: string = "";
  isDependentRequiredMessage: string = "";
  medicaidIdReqquiredMessage: string = "";
  medicaidStateRequiredMessage: string = "";
  payerNameRequiredMessage: string = "";
  groupNumberRequiredMessage: string = "";
  policyNumberRequiredMessage: string = "";
  override: any;
  allPrograms: any = [];
  tempArray: any = [];
  addMore: any = [];
  allProgramsForm: any = [];
  display: string = "";
  programList: any
  programsOpted: any = [];
  totalCount: any;
  tempIncome: any;
  tempPeriod: any;
  household = StringConstants.DashboardHousehold.household;
  DateofBirth = StringConstants.DashboardHousehold.DateofBirth;
  IncomeResources = StringConstants.DashboardHousehold.IncomeResources;
  Amount = StringConstants.DashboardHousehold.Amount;
  NoMembersFound = StringConstants.DashboardHousehold.NoMembersFound;
  Patient = StringConstants.demographics.Patient;
  NoIncomeResources = StringConstants.DashboardHousehold.NoIncomeResources;
  DelHouseHoldMember = StringConstants.DashboardHousehold.DelHouseHoldMember;
  Yes = StringConstants.Common.Yes;
  No = StringConstants.Common.No;
  HouseholdSize = StringConstants.DashboardHousehold.HouseholdSize;
  MonthlyIncome = StringConstants.DashboardHousehold.MonthlyIncome;
  Resources = StringConstants.DashboardHousehold.Resources;
  HouseholdSize1 = StringConstants.DashboardHousehold.HouseholdSize1;
  MonthlyIncome1 = StringConstants.DashboardHousehold.MonthlyIncome1;
  Resources1 = StringConstants.DashboardHousehold.Resources1;
  Evaluate = StringConstants.DashboardHousehold.Evaluate;
  NoProgramsAvailable = StringConstants.DashboardHousehold.NoProgramsAvailable;
  Close = StringConstants.Common.Close;
  EvaluatedPrograms = StringConstants.DashboardHousehold.EvaluatedPrograms;
  AddMorePrograms = StringConstants.DashboardHousehold.AddMorePrograms;
  Next = StringConstants.common.nextLabel;
  AddNewMember = StringConstants.DashboardHousehold.AddNewMember;
  EditMember = StringConstants.DashboardHousehold.EditMember;
  NameReq = StringConstants.demographics.NameReq;
  NameAlp = StringConstants.demographics.NameAlp;
  NameChar = StringConstants.demographics.NameChar;
  NameMax = StringConstants.demographics.NameMax;
  MidNameAlp = StringConstants.profileSetting.MidNameAlp;
  MidNameMax = StringConstants.profileSetting.MidNameMax;
  LastNamereq = StringConstants.demographics.LastNamereq;
  LastNameAlp = StringConstants.demographics.LastNameAlp;
  LastNameMax = StringConstants.demographics.LastNameMax;
  SuffixAlp = StringConstants.DashboardHousehold.SuffixAlp;
  SuffixMax = StringConstants.DashboardHousehold.SuffixMax;
  RelationshipRole = StringConstants.DashboardHousehold.RelationshipRole;
  RelationshipReq = StringConstants.DashboardHousehold.RelationshipReq;
  Demographics = StringConstants.advocateSummaryPanel.Demographics;
  DateReq = StringConstants.demographics.DateReq;
  DateFormate = StringConstants.demographics.DateFormate;
  DateFut = StringConstants.demographics.DateFut;
  Gender = StringConstants.dashboardAdvocate.Gender;
  GenderReq = StringConstants.demographics.GenderReq;
  MaritalStatus = StringConstants.DashboardHousehold.MaritalStatus;
  MartialReq = StringConstants.demographics.MartialReq;
  SSN = StringConstants.DashboardHousehold.SSN;
  SSNReq = StringConstants.DashboardHousehold.SSNReq;
  SSNVal = StringConstants.DashboardHousehold.SSNVal;
  PatientGuarantor = StringConstants.DashboardHousehold.PatientGuarantor;
  YesOrNo = StringConstants.DashboardHousehold.YesOrNo;
  Medicaid = StringConstants.DashboardHousehold.Medicaid;
  MedicaidErr = StringConstants.DashboardHousehold.MedicaidErr;
  MedicaidMax = StringConstants.DashboardHousehold.MedicaidMax;
  StateAlp = StringConstants.DashboardHousehold.StateAlp;
  StateMax = StringConstants.DashboardHousehold.StateMax;
  EffectiveFrom = StringConstants.DashboardHousehold.EffectiveFrom;
  Termination = StringConstants.DashboardHousehold.Termination;
  MemberCoverage = StringConstants.DashboardHousehold.MemberCoverage;
  PayerNameAlp = StringConstants.insurance.PayerNameAlp;
  PaterMax = StringConstants.insurance.PaterMax;
  PayerNumOfChar = StringConstants.insurance.PayerNumOfChar;
  GroupAlp = StringConstants.insurance.GroupAlp;
  GroupNameCharMax = StringConstants.insurance.GroupNameCharMax;
  GroupNameCharMin = StringConstants.insurance.GroupNameCharMin;
  GroupNo = StringConstants.insurance.GroupNo;
  SpaceSpecial = StringConstants.DashboardHousehold.SpaceSpecial;
  GroupNumMax = StringConstants.DashboardHousehold.GroupNumMax;
  PolicyNo = StringConstants.insurance.PolicyNo;
  PolicyNumAlp = StringConstants.insurance.PolicyNumAlp;
  PolicyNumMax = StringConstants.insurance.PolicyNumMax;
  Income = StringConstants.Common.Income;
  IncomeType1 = StringConstants.DashboardHousehold.IncomeType;
  MonthlyGrossPay = StringConstants.DashboardHousehold.MonthlyGrossPay;
  EditIncome = StringConstants.DashboardHousehold.EditIncome;
  IncomeTypeReq = StringConstants.DashboardHousehold.IncomeTypeReq;
  IncomeStatus = StringConstants.DashboardHousehold.IncomeStatus;
  VerificationReq = StringConstants.DashboardHousehold.VerificationReq;
  GrossPay1 = StringConstants.household.GrossPay;
  IncomeReq = StringConstants.DashboardHousehold.IncomeReq;
  IncomeNum = StringConstants.DashboardHousehold.IncomeNum;
  IncomeExceed = StringConstants.DashboardHousehold.IncomeExceed;
  CalMonthlyIncome = StringConstants.DashboardHousehold.CalMonthlyIncome;
  ConfirmationContact = StringConstants.DashboardHousehold.ConfirmationContact;
  CompanyNameReq = StringConstants.DashboardHousehold.CompanyNameReq;
  CompanyNameAlp = StringConstants.DashboardHousehold.CompanyNameAlp;
  CompanyNameMin = StringConstants.DashboardHousehold.CompanyNameMin;
  CompanyNameMax = StringConstants.DashboardHousehold.CompanyNameMax;
  ContactNumAlp = StringConstants.DashboardHousehold.ContactNumAlp;
  ContactNameMax = StringConstants.DashboardHousehold.ContactNameMax;
  ContactNameMin = StringConstants.DashboardHousehold.ContactNameMin;
  AddressMax = StringConstants.DashboardHousehold.AddressMax;
  ZipNum = StringConstants.demographics.ZipNum;
  ZipMin = StringConstants.demographics.ZipMin;
  ZipMax = StringConstants.DashboardHousehold.ZipMax;
  CityAlp = StringConstants.demographics.CityAlp;
  CellVal = StringConstants.demographics.CellVal;
  CityMax = StringConstants.demographics.CityMax;
  FaxNumVal = StringConstants.DashboardHousehold.FaxNumVal;
  UpdateIncome = StringConstants.Common.UpdateIncome;
  Resource = StringConstants.Common.Resource;
  ResourceType1 = StringConstants.DashboardHousehold.ResourceType;
  ResourceValue = StringConstants.DashboardHousehold.ResourceValue;
  EditResource = StringConstants.DashboardHousehold.EditResource;
  ResourceReq = StringConstants.DashboardHousehold.ResourceReq;
  ResourceStatus = StringConstants.DashboardHousehold.ResourceStatus;
  ResourcestatusReq = StringConstants.DashboardHousehold.ResourcestatusReq;
  MarketValue = StringConstants.DashboardHousehold.MarketValue;
  PercentageReq = StringConstants.DashboardHousehold.PercentageReq;
  Percentagedeci = StringConstants.DashboardHousehold.Percentagedeci;
  ResourceVal = StringConstants.DashboardHousehold.ResourceVal;
  IncomeErr = StringConstants.household.IncomeErr;
  LocationRealProperty = StringConstants.DashboardHousehold.LocationRealProperty;
  LocationReq = StringConstants.DashboardHousehold.LocationReq;
  LocationMax = StringConstants.DashboardHousehold.LocationMax;
  Cancel = StringConstants.Common.Cancel;
  Save = StringConstants.Common.Save;
  PercentageMax = StringConstants.DashboardHousehold.PercentageMax;
  tempResource: any;
  selfDisable: any;
  reasons: any;
  EditHouseholdMember: boolean = false;
  names: string = "";
  phoneCode: any;
  get panelOpenStateResource(): boolean {
    if (this._panelOpenStateResource == false) {
      this.ClearResourceValidations();
    }
    return this._panelOpenStateResource;
  }
  set panelOpenStateResource(value: boolean) {
    this._panelOpenStateResource = value;
    if (value) {
      this.resourceFlag = false;
      this.ResetResourceDetail();
    }
  }
  get panelOpenStateIncome(): boolean {
    if (this._panelOpenStateIncome == false) {
      this.ClearIncomeValidations();
    }
    return this._panelOpenStateIncome;
  }
  set panelOpenStateIncome(value: boolean) {
    this._panelOpenStateIncome = value;
    if (value) {
      this.incomeFlag = false;
      this.addIncomeOptionFlag = true;
      this.ResetIncomeDetail();
    }
  }
  get addresourceContent(): string {
    if (this.resourceMap.size > 0) return StringConstants.var.addResource;
    else return StringConstants.var.ResourceMember;
  }
  get addincomeContent(): string {
    if (this.incomeMap.size > 0) return StringConstants.var.addIncome;
    else return StringConstants.var.IncomeMember;
  }
  get resourceAddFlag(): boolean {
    return !this.resourceFlag;
  }
  get showIncomeTables(): boolean {
    try {
      if (this.incomeResult.length > 0) return true;
      else return false;
    }
    catch {
      return false;
    }
  }
  get showResourceTables(): boolean {
    try {
      if (this.resourceResult.length > 0) return true;
      else return false;
    }
    catch {
      return false;
    }
  }
  get assessmentId(): any {
    return +(sessionStorage.getItem('assessmentId')!);
  }
  @ViewChild('myform') HForm: any;
  @Output() nextApplicationFormClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  constructor(private datepipe: DatePipe, private quickAssessmentService: QuickAssessmentService, private Fb: FormBuilder, private dashboardService: DashboardService, private toastService: ToastServiceService,
    private router: Router, private formbuilder: FormBuilder, private dropdownService: DropdownService, private dataSharing: DataSharingService, private authService: AuthService, private common: CommonService) {
    this.dataSharing.alterPaddingForVA.subscribe(value => {//Virtual assist panel
      this.virtualAssistPadding = value;
    });
    this.dataSharing.changeTheme.subscribe(value => { // Theme Settings
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharing.editable.subscribe(value => { //Assessment status
      this.isEditAllowed = value;
    });
  }
  @Input() set currentTabUpdate(value: boolean) { //Current tab details
    if (value != undefined) {
      this.patientId = sessionStorage.getItem('patientId');
      this.memberListFlag = true;
      this.addMemberFlag = false;
      this.addMemberForm.reset();
      this.getReasonNoSSN();
      this.getRelationValues();
      this.getMartialValues();
      this.getIncomeValues();
      this.getGenderValues();
      this.getPhoneCode();
      this.getIncomeCurrentStatus();
      this.getVerification();
      this.getGrossPayPeriod();
      this.getResourceCurrentStatus();
      this.getResource();
      this.getDashboardHouseholdInfo();
      this.dataSharing.showHouseholdTab.next("4");
      this.getTabStatus();
    }
  }
  async getGenderValues() { //Get gender values
    this.genderval = await this.common.getGenderValues();
    console.log(this.genderval.wasSuccessful)
  }
  async getMartialValues() { //Get martial status
    this.martialStatusVal = await this.common.getMartialValues();
  }
  async getRelationValues() { //Get relationship values
    this.relationval = await this.common.getRelationValues();
    if (this.relation != 'Self') {
      delete this.relationval.SEL;
    }
  }
  ngOnInit() {
    this.initForm();
    this.addMemberForm.reset();
    this.showAdvocatePanel = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
    this.patientId = sessionStorage.getItem('patientId');
    this.loginUserMail = sessionStorage.getItem('userEmail');
    this.createFlag = true;
    this.incomebuttonFlag = true;
    this.resourcebuttonFlag = true;
    this.incomeFlag = false;
    this.resourceFlag = false;
    this.isSelfRelationChanged = false;
  }
  initForm() {
    this.addMemberForm = this.Fb.group({
      firstName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]],
      middleName: ['', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]],
      lastName: ['', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]],
      suffix: ['', [Validators.pattern('^[a-zA-Z., ]*$'), Validators.maxLength(50)]],
      relation: ['', [Validators.required]],
      householdDemographicForm: this.Fb.group({
        dateOfBirth: ['', [Validators.required, DateValidation.validateDateFormat, DateValidation.futureDateValidation]],
        gender: ['', [Validators.required]],
        maritalStatus: ['', [Validators.required]],
        ssn: ['', [Validators.required]],
        sssn: new FormControl(''),
        reasonNoSSN: [''],
        isDependent: ['', [Validators.required]],
        isMedicalAid: ['', [Validators.required]],
        isInsurance: ['', [Validators.required]],
        payerName: [''],
        groupName: [''],
        groupNumber: [''],
        policyNumber: [''],
        effectiveFrom: [''],
        termination: [''],
        medicalId: [''],
        medicalState: [''],
        medicalEffectiveFrom: [''],
        medicalTermination: [''],
      }),
      householdResourceForm: this.Fb.group({
        resourceType: [''],
        resourceStatus: [StringConstants.dashboardHouseholdMember.currentlyOwned],
        resourceAcceptStatus: [''],
        resourceIncomeAmt: [''],
        ownership: [''],
        locationName: [''],
        resourcecalculatedValue: [''],
      }),
      householdIncomeForm: this.Fb.group({
        incomeType: [''],
        currentStatus: [StringConstants.dashboardHouseholdMember.current],
        acceptStatus: [''],
        grossPay: [''],
        grossPayPeriod: [StringConstants.dashboardHouseholdMember.monthly],
        incomecalculatedValue: [''],
      }),
      IncomeForm: this.Fb.group({
        companyName: [''],
        contactName: [''],
        streetAddress: [''],
        city: ['',],
        state: [''],
        zipCode: [''],
        cellNumber: [''],
        faxNumber: [''],
        countryCode: [''],
      }),
    });
    this.allProgramsForm = new FormGroup({
      'programList': new FormControl(''),
    });
  }
  keyPress(event: KeyboardEvent) { //SSN key event
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) {
      event.preventDefault();
    }
  }
  selectDate(event: any) {// Date-picker JS starts here!
    if (event != undefined && event != "" && event != null) {
      var newVal = this.datepipe.transform(event, 'MM/dd/yyyy');
      var oldVal = this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).value;
      if (newVal !== oldVal) {
        this.addMemberForm.controls['householdDemographicForm'].controls['dateOfBirth'].setValue(newVal);
        this.addMemberForm.markAsDirty();
      }
    }
  }
  closeCalendar() { //To close calendar
    DateValidation.closeCal();
    this.captureDateInDatepicker();
  }
  captureDateInDatepicker() { //To get DOB vlue
    if (this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).errors == null) {
      var bsValueDOB = this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).value;
      if (bsValueDOB != null) { this.bsVal = new Date(bsValueDOB); }
    } else { this.bsVal = ""; }
  }
  checkpattern() { //Check dOB pattern
    var result = false;
    var dateCheck;
    this.dobTextbox = document.getElementById('dateOfBirth');
    var bsValueDOB = this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).value;
    if (bsValueDOB != "Invalid Date") {
      if (bsValueDOB == null) { result = true; }
      else if (DateValidation.validateDate(bsValueDOB != null ? bsValueDOB : "")) {
        dateCheck = this.datepipe.transform(bsValueDOB, 'MM/dd/yyyy');
        result = DateValidation.validateFutureDate(dateCheck != null ? dateCheck : "");
      }
    }
    if (!result) {
      this.addMemberForm.controls['householdDemographicForm'].patchValue({
        dateOfBirth: ""
      });
      this.dobTextbox.focus();
      this.addMemberForm.controls['householdDemographicForm'].controls['dateOfBirth'].setErrors({ pattern: true });
    } else {
      if (bsValueDOB != null) {
        this.bsVal = new Date(bsValueDOB);
      }
      this.addMemberForm.controls['householdDemographicForm'].controls['dateOfBirth'].setValue(dateCheck);
    }
  }
  moreOptions(houseHoldMemberId: string) {// Date-picker JS ends here!
    this.householdMoreOptions[houseHoldMemberId] = !this.householdMoreOptions[houseHoldMemberId];
  }
  async getReasonNoSSN() { //To get reasonNoSSN values
    this.reasons = await this.common.getReasonNoSSN();
  }
  ssnChange(event: any) { //SSN change event
    this.addMemberForm.get(['householdDemographicForm', 'ssn']).setValidators([Validators.required]);
    this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
    this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).clearValidators();
    this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
    this.reasonNoSSN = null;
  }
  noSSNChange() { // SSN change event
    this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).setValidators([Validators.required]);
    this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
    this.addMemberForm.get(['householdDemographicForm', 'ssn']).clearValidators();
    this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
    this.ssn = null;
  }
  getIncomeValues() { //Get income option values
    this.dropdownService.GetIncome().subscribe(async (result: any) => {
      if (result.wasSuccessful) { this.incomeval = result.data; }
    }, (error) => { console.log(error); });
  }
  getIncomeCurrentStatus() { //Get current status option values
    this.dropdownService.GetIcomeCurrentStatus().subscribe(async (result: any) => {
      if (result.wasSuccessful) { this.incomeCurrentStatusVal = result.data; }
    }, (error) => { console.log(error) });
  }
  getVerification() { //Get verification option values
    this.dropdownService.GetVerification().subscribe(async (result: any) => {
      if (result.wasSuccessful) { this.verificationVal = result.data; }
    }, (error) => { console.log(error) });
  }
  getGrossPayPeriod() { //Get gross pay option values
    this.dropdownService.GetGrossPayPeriod().subscribe(async (result: any) => {
      if (result.wasSuccessful) { this.grossPayPeriodVal = result.data; }
    }, (error) => { console.log(error) });
  }
  getResource() { //Get resource option values
    this.dropdownService.GetResource().subscribe(async (result: any) => {
      if (result.wasSuccessful) { this.resourceVal = result.data; }
    }, (error) => { console.log(error) });
  }
  getResourceCurrentStatus() { //Get resource current status options
    this.dropdownService.GetResourceCurrentStatus().subscribe(async (result: any) => {
      if (result.wasSuccessful) { this.resourceCurrentVal = result.data; }
    }, (error) => { console.log(error) });
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  getDashboardHouseholdInfo() { //Get dashboard details
    this.showLoader = true;
    var assessment: any = sessionStorage.getItem('assessmentId');
    var assessmentId: number = +(assessment);
    this.dashboardService.getHouseholdMemberListInfo(assessmentId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        this.result = result.data.memberLists;
        if (result.data.memberLists.length == 0) {
          this.memberListEmptyFlag = true;
        }
        else {
          this.names = "";
          var incompleteList = [];
          for (var data of result.data.memberLists) {
            if (data.isRequiredDetailsCompleted == false)
            incompleteList.push(data.name);
          }
          this.names = incompleteList.join(',');
          this.householdMemberId = result.data.memberLists.houseHoldMemberId;
          this.canDelete = result.data.memberLists.canDeleteHouseHold;
          this.totalMembers = result.data.totalMembers;
          this.minors = result.data.minors;
          this.totalMonthlyIncome = result.data.totalMonthlyIncome;
          this.totalResource = result.data.totalResource;
          this.totalCount = result.data.totalHouseholdCount;
          if (this.totalCount == "1") {
            this.getIncomeResourceAmount();
          }
        }
      }
    }, (error) => { console.log(error) });
  }
  getIncomeResourceAmount() { //Get income and resource amount
    var assessment: any = sessionStorage.getItem('assessmentId');
    var assessmentId: number = +(assessment);
    this.dashboardService.getIncomeResourceAmount(assessmentId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.tempIncome = result.data.incomeAmount;
        this.tempPeriod = result.data.grossPay;
        this.tempResource = result.data.resourceAmount;
      }
    }, (error) => { this.showLoader = false; });
  }
  SetData(type: string) { //Set income and resource Data
    if (type == 'Income') {
      this.ResetIncomeDetail();
      this.incomeFlag = true;
      this.incomebuttonFlag = true;
      this.ClearIncomeValidations();
      this.addMemberForm.get(['IncomeForm']).markAsPristine();
      this.addMemberForm.get(['householdIncomeForm']).markAsPristine();
      this.grossPay = this.tempIncome;
      this.grossPayPeriod = this.tempPeriod;
    }
    if (type == 'Resource') {
      this.resourcebuttonText = "Add Resource";
      this.ResetResourceDetail();
      this.resourceFlag = true;
      this.resourcebuttonFlag = true;
      this.ClearResourceValidations();
      this.addMemberForm.get(['householdResourceForm']).markAsPristine();
      this.resourceIncomeAmt = this.tempResource;
      this.showLoader = false;
    }
  }
  memberList() { // Switch to member list tab
    window.scroll(0, 0);
    this.cancelAddmemberForm();
    this.memberListFlag = true;
    this.addMemberFlag = false;
    this.getDashboardHouseholdInfo();
    this.isInsuranceRequiredMessage = "";
    this.isMedicalAidRequiredMessage = "";
    this.isDependentRequiredMessage = "";
  }
  hideModal() { $("#deletehouseholdMember").modal("hide"); }
  addMember() { //Switch to add/update member list
    window.scroll(0, 0);
    this.addMemberForm.reset();
    this.addMemberForm.enable();
    this.memberListFlag = false;
    this.addMemberFlag = true;
    this.createFlag = true;
    this.newDetailFlag = true;
    this.addIncomeOptionFlag = true;
    this.resourceFlag = false;
    this.incomeFlag = false;
    this.panelOpenStateAddNewMember = true;
    this.panelOpenStateDemographic = true;
    this.panelOpenStateIncome = false;
    this.panelOpenStateResource = false;
    this.maritalStatus = "";
    this.relation = "";
    this.gender = "";
    this.incomeType = "";
    this.payerName = "";
    this.groupName = "";
    this.groupNumber = "";
    this.policyNumber = "";
    this.effectiveFrom = "";
    this.termination = "";
    this.medicalId = "";
    this.medicalState = "";
    this.medicalEffectiveFrom = "";
    this.medicalTermination = "";
    this.currentStatus = StringConstants.dashboardHouseholdMember.current;
    this.acceptStatus = "";
    this.grossPayPeriod = StringConstants.dashboardHouseholdMember.monthly;
    this.state = "";
    this.resourceType = "";
    this.resourceStatus = StringConstants.dashboardHouseholdMember.currentlyOwned;
    this.resourceAcceptStatus = "";
    this.incomeResult = [];
    this.resourceResult = [];
    this.incomeMap.clear();
    this.resourceMap.clear();
    this.deletedresourceId = [];
    this.deletedincomeId = [];
    this.householdMemberId = 0;
    this.isSelfRelationReadOnly = false;
    this.selfDisable = false;
    this.ssn = null;
    this.sssn = null;
    this.ssnNumberValue = null;
    this.bsVal = '';
    this.reasonNoSSN = null;
    this.bsValEffectiveFrom = '';
    this.bsValTermination = '';
    this.bsValMedicalEffectiveFrom = '';
    this.bsValMedicalTermination = '';
    this.effectiveFromErrorMessage = '';
    this.terminationErrorMessage = '';
    this.medicalEffectiveFromErrorMessage = '';
    this.medicalTerminationErrorMessage = '';
    this.showPriorCoverageFields = false;
    this.showMedicalAidFields = false;
    this.isInsuranceRequiredMessage = "";
    this.isMedicalAidRequiredMessage = "";
    this.isDependentRequiredMessage = "";
    this.EditHouseholdMember = false;
    this.noSSNChange();
  }
  testbutton() {
    alert(this.dateOfBirth.toLocaleDateString("en-US", { // you can use undefined as first argument
      year: "numeric",
      day: "2-digit",
      month: "2-digit",
    }));
  }
  addNewMemberTabs(hoseholdMemberId: any, canDelete: any) {
    this.incomeFlag = false;
    this.resourceFlag = false;
    this.newDetailFlag = false;
    this.panelOpenStateAddNewMember = true;
    this.panelOpenStateDemographic = true;
    this.panelOpenStateIncome = false;
    this.panelOpenStateResource = false;
    this.householdMemberId = hoseholdMemberId;
    this.memberListFlag = false;
    this.addMemberFlag = true;
    this.createFlag = false;
    this.addIncomeOptionFlag = true;
    this.incomeTableFlag = false;
    this.incomeTableFlag = false;
    this.deletedresourceId = [];
    this.deletedincomeId = [];
    this.EditHouseholdMember = true;
    this.canDelete = canDelete;
    this.getHouseHoldMemberDetailsById();
  }
  deleteMemberData(householdMemberId: any) { // Delete member details from household
    if (this.deleteHouseholdMemberId)
      householdMemberId = this.deleteHouseholdMemberId;
    this.dashboardService.DeleteHouseHoldMember(householdMemberId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.dataSharing.evaluateHousehold.next(true);
        this.getDashboardHouseholdInfo();
        this.getTabStatus();
      }
    }, (error) => { console.log(error) });
  }
  toShowMedicalformValues(event: any) { //Follow up questions for medical aid
    if (event.target.innerText == "Yes") {
      this.followupMedicaidRequiredMessage();
      this.AddMedicalAidValidations();
      this.showMedicalAidFields = true;
    }
    else if (event.target.innerText == "No") {
      this.RemoveMedicalAidValidators();
      this.showMedicalAidFields = false;
      this.medicaidFollowUpErrorMessage();
      this.followupMedicaidRequiredMessage();
    }
  }
  medicaidFollowUpErrorMessage() { //Error message handled for followup questions
    this.medicalId = '';
    this.medicalState = '';
    this.medicalEffectiveFrom = '';
    this.medicalTermination = '';
    this.medicalEffectiveFromErrorMessage = '';
    this.medicalTerminationErrorMessage = '';
  }
  private AddMedicalAidValidations() { //Add medical aid form controls
    this.addMemberForm.get('householdDemographicForm').controls['medicalId'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z0-9]+$'), Validators.maxLength(50)]);
    this.addMemberForm.get('householdDemographicForm').controls['medicalId'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['medicalState'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]);
    this.addMemberForm.get('householdDemographicForm').controls['medicalState'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['medicalEffectiveFrom'].setValidators('');
    this.addMemberForm.get('householdDemographicForm').controls['medicalEffectiveFrom'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['medicalTermination'].setValidators('');
    this.addMemberForm.get('householdDemographicForm').controls['medicalTermination'].updateValueAndValidity();
  }
  private RemoveMedicalAidValidators() { //Remove medical aid form controls
    this.addMemberForm.get('householdDemographicForm').controls['medicalId'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['medicalId'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['medicalState'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['medicalState'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['medicalEffectiveFrom'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['medicalEffectiveFrom'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['medicalTermination'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['medicalTermination'].updateValueAndValidity();
  }
  toShowPriorCoverage(event: any) {  //Follow up questions for prior Coverage
    if (event.target.innerText == "Yes") {
      this.followuppriorCoverageMessage();
      this.AddPriorCoverageValidations();
      this.showPriorCoverageFields = true;
      this.isInsuranceRequiredMessage = "";
    }
    else if (event.target.innerText == "No") {
      this.RemovePriorCoverageValidators();
      this.showPriorCoverageFields = false;
      this.payerName = '';
      this.groupName = '';
      this.groupNumber = '';
      this.policyNumber = '';
      this.effectiveFrom = '';
      this.termination = '';
      this.effectiveFromErrorMessage = '';
      this.terminationErrorMessage = '';
      this.followuppriorCoverageMessage();
    }
  }
  onChangeValue(value: any) { //onChange options
    if (value == 'isMedicalAid')
      this.isMedicalAidRequiredMessage = "";
    else if (value == 'isDependent')
      this.isDependentRequiredMessage = "";
  }
  private AddPriorCoverageValidations() {//Add prior coverage form controls
    this.addMemberForm.get('householdDemographicForm').controls['payerName'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]);
    this.addMemberForm.get('householdDemographicForm').controls['payerName'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['groupName'].setValidators([Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(2), Validators.maxLength(50)]);
    this.addMemberForm.get('householdDemographicForm').controls['groupName'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['groupNumber'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z0-9]+$'), Validators.maxLength(50)]);
    this.addMemberForm.get('householdDemographicForm').controls['groupNumber'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['policyNumber'].setValidators([Validators.required, Validators.pattern('^[a-zA-Z0-9]+$'), Validators.maxLength(50)]);
    this.addMemberForm.get('householdDemographicForm').controls['policyNumber'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['effectiveFrom'].setValidators('');
    this.addMemberForm.get('householdDemographicForm').controls['effectiveFrom'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['termination'].setValidators('');
    this.addMemberForm.get('householdDemographicForm').controls['termination'].updateValueAndValidity();
  }
  private RemovePriorCoverageValidators() {  //Remove prior coverage form controls
    this.addMemberForm.get('householdDemographicForm').controls['payerName'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['payerName'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['groupName'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['groupName'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['groupNumber'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['groupNumber'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['policyNumber'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['policyNumber'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['effectiveFrom'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['effectiveFrom'].updateValueAndValidity();
    this.addMemberForm.get('householdDemographicForm').controls['termination'].clearValidators();
    this.addMemberForm.get('householdDemographicForm').controls['termination'].updateValueAndValidity();
  }
  selectEffectiveFromDate(elementName: any) { // To select date for effective from
    if (elementName == 'effectiveFrom') {
      if (this.bsValEffectiveFrom && this.bsValEffectiveFrom != "Invalid Date" && this.bsValEffectiveFrom != " ") {
        this.effectiveTextbox = document.getElementById('effectiveFrom');
        var newVal = this.datepipe.transform(this.bsValEffectiveFrom, 'MM/dd/yyyy');
        this.effectiveTextbox.value = newVal;
        this.effectiveFrom = newVal;
        this.clickEffectiveFrom('effectiveFrom');
      }
    }
    else if (elementName == 'medicalEffectiveFrom') {
      if (this.bsValMedicalEffectiveFrom && this.bsValMedicalEffectiveFrom != "Invalid Date" && this.bsValMedicalEffectiveFrom != " ") {
        this.medicalEffectiveTextbox = document.getElementById('medicalEffectiveFrom');
        var newVal = this.datepipe.transform(this.bsValMedicalEffectiveFrom, 'MM/dd/yyyy');
        this.medicalEffectiveTextbox.value = newVal;
        this.medicalEffectiveFrom = newVal;
        this.clickEffectiveFrom('medicalEffectiveFrom');
      }
    }
  }
  selectTerminationDate(elementName: any) { //To select termination date
    if (elementName == 'termination') {
      if (this.bsValTermination && this.bsValTermination != "Invalid Date" && this.bsValTermination != "" && this.bsValTermination != "Invalid date") {
        this.terminationTextBox = document.getElementById('termination');
        var newVal = this.datepipe.transform(this.bsValTermination, 'MM/dd/yyyy');
        this.terminationTextBox.value = newVal;
        this.termination = newVal;
        this.clickTermination('termination');
      }
    }
    else if (elementName == 'medicalTermination') {
      if (this.bsValMedicalTermination && this.bsValMedicalTermination != "Invalid Date" && this.bsValMedicalTermination != "" && this.bsValMedicalTermination != "Invalid date") {
        this.medicalTerminationTextBox = document.getElementById('medicalTermination');
        var newVal = this.datepipe.transform(this.bsValMedicalTermination, 'MM/dd/yyyy');
        this.medicalTerminationTextBox.value = newVal;
        this.medicalTermination = newVal;
        this.clickTermination('medicalTermination');
      }
    }
  }
  keyPressTermination(event: KeyboardEvent) { //Key press event
    var key = event.key;
    const pattern = /[0-9/]/;
    if (!pattern.test(key)) { event.preventDefault(); }
  }
  closeCalendarMedical(fromName: string) { //To close calendar
    if (fromName == "effectiveFrom" || fromName == "medicalEffectiveFrom") {
      this.clickEffectiveFrom(fromName);
    } else if (fromName == "termination" || fromName == "medicalTermination") {
      this.clickTermination(fromName);
    }
  }
  clickEffectiveFrom(effectiveFrom: any) { //Effective from date's click event
    var result = false;
    var validMessage = true;
    var dateCheck;
    if (effectiveFrom == 'effectiveFrom') {
      this.effectiveTextbox = document.getElementById('effectiveFrom');
      var bsValueEffective = this.effectiveTextbox.value;
      if (bsValueEffective != "Invalid Date" && bsValueEffective != "") {
        if (bsValueEffective == null) {
          result = true;
        } else if (DateValidation.validateDate(bsValueEffective != null ? bsValueEffective : "")) {
          if (this.termination == null || this.termination == "") {
            result = true;
            this.effectiveFromErrorMessage = "";
          }
          else {
            var startDate = new Date(this.effectiveFrom).setHours(0, 0, 0, 0);
            var endDate = new Date(this.termination).setHours(0, 0, 0, 0);
            if (endDate > startDate) { result = true; }
            else if (startDate >= endDate) {
              result = false;
              validMessage = false;
            } else { result = true; }
          }
          if (!result) {
            this.addMemberForm.controls['householdDemographicForm'].patchValue({
              effectiveFrom: ""
            });
            this.effectiveTextbox.focus();
            this.addMemberForm.controls['householdDemographicForm'].controls['effectiveFrom'].setErrors({ pattern: true });
            this.effectiveFromErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Effective date should be lesser than termination date";
          } else {
            if (bsValueEffective != null) {
              this.bsValEffectiveFrom = new Date(bsValueEffective);
            }
            this.addMemberForm.controls['householdDemographicForm'].controls['effectiveFrom'].setValue(bsValueEffective);
            this.effectiveFromErrorMessage = "";
            this.terminationErrorMessage='';
          }
        }
      }
      else if (bsValueEffective == "Invalid Date" || bsValueEffective == "Invalid date") {
        this.addMemberForm.controls['householdDemographicForm'].patchValue({
          effectiveFrom: ""
        });
        this.addMemberForm.controls['householdDemographicForm'].controls['effectiveFrom'].setErrors({ pattern: true });
        this.effectiveFromErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Effective date should be lesser than termination date";
      }
      else if (bsValueEffective == "") {
        this.effectiveFromErrorMessage = "";
      }
    }
    else if (effectiveFrom == 'medicalEffectiveFrom') {
      this.medicalEffectiveTextbox = document.getElementById('medicalEffectiveFrom');
      var bsValueEffective = this.medicalEffectiveTextbox.value;
      if (bsValueEffective != "Invalid Date" && bsValueEffective != "" && bsValueEffective != "Invalid date") {
        if (bsValueEffective == null) {
          result = true;
        } else if (DateValidation.validateDate(bsValueEffective != null ? bsValueEffective : "")) {
          if (this.medicalTermination == null || this.medicalTermination == "") {
            result = true;
          }
          else {
            var startDate = new Date(this.medicalEffectiveFrom).setHours(0, 0, 0, 0);
            var endDate = new Date(this.medicalTermination).setHours(0, 0, 0, 0);
            if (endDate > startDate) {
              result = true;
            }
            else if (startDate >= endDate) {
              result = false;
              validMessage = false;
            } else { result = true; }
          }
          if (!result) {
            this.addMemberForm.controls['householdDemographicForm'].patchValue({
              medicalEffectiveFrom: ""
            });
            this.medicalEffectiveTextbox.focus();
            this.addMemberForm.controls['householdDemographicForm'].controls['medicalEffectiveFrom'].setErrors({ pattern: true });
            this.medicalEffectiveFromErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Effective date should be lesser than termination date";
          } else {
            if (bsValueEffective != null) {
              this.bsValMedicalEffectiveFrom = new Date(bsValueEffective);
            }
            this.addMemberForm.controls['householdDemographicForm'].controls['medicalEffectiveFrom'].setValue(bsValueEffective);
            this.medicalEffectiveFromErrorMessage = "";
          }
        }
      }
      else if (bsValueEffective == "Invalid Date" || bsValueEffective == "Invalid date") {
        this.addMemberForm.controls['householdDemographicForm'].patchValue({
          medicalEffectiveFrom: ""
        });
        this.addMemberForm.controls['householdDemographicForm'].controls['medicalEffectiveFrom'].setErrors({ pattern: true });
        this.medicalEffectiveFromErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Effective date should be lesser than termination date";
      }
      else if (bsValueEffective == "") {
        this.medicalEffectiveFromErrorMessage = "";
      }
    }
  }
  clickTermination(element: any) { //Click event for termination
    var result = false;
    var validMessage = true;
    this.tempMsg = validMessage;
    if (element == 'termination') {
      this.terminationTextBox = document.getElementById('termination');
      var bsValueTermination = this.terminationTextBox.value;
      if (bsValueTermination != "Invalid Date" && bsValueTermination != '' && bsValueTermination != "Invalid date") {
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
              this.tempMsg = validMessage;
            } else { result = true; }
          }
        }
        if (!result) {
          this.addMemberForm.controls['householdDemographicForm'].patchValue({
            termination: ""
          });
          this.terminationTextBox.focus();
          this.terminationErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Termination date should be greater than effective date.";
        } else {
          if (bsValueTermination != null) {
            this.bsValTermination = new Date(bsValueTermination);
          }
          this.addMemberForm.controls['householdDemographicForm'].controls['termination'].setValue(bsValueTermination);
          this.terminationErrorMessage = "";
          this.effectiveFromErrorMessage = '';
        }
      }
      else if (bsValueTermination == "Invalid Date" || bsValueTermination == "Invalid date") {
        this.addMemberForm.controls['householdDemographicForm'].patchValue({
          termination: ""
        });
        this.addMemberForm.controls['householdDemographicForm'].controls['termination'].setErrors({ pattern: true });
        this.terminationErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Termination date should be greater than effective date.";
      }
      else if (bsValueTermination == "") {
        this.terminationErrorMessage = "";
      }
    }
    else if (element == 'medicalTermination') {
      this.medicalTerminationTextBox = document.getElementById('medicalTermination');
      var bsValueTermination = this.medicalTerminationTextBox.value;
      if (bsValueTermination != "Invalid Date" && bsValueTermination != "" && bsValueTermination != "Invalid date") {
        if (bsValueTermination == null) {
          result = true;
        } else if (DateValidation.validateDate(bsValueTermination != null ? bsValueTermination : "")) {
          if (this.medicalEffectiveFrom == null || this.medicalEffectiveFrom == "") {
            result = true;
          }
          else {
            var startDate = new Date(this.medicalEffectiveFrom).setHours(0, 0, 0, 0);
            var endDate = new Date(this.medicalTermination).setHours(0, 0, 0, 0);
            if (endDate > startDate) {
              result = true;
            }
            else if (startDate >= endDate) {
              result = false;
              validMessage = false;
              this.tempMsg = validMessage;
            } else {
              result = true;
            }
          }
          if (!result) {
            this.addMemberForm.controls['householdDemographicForm'].patchValue({
              medicalTermination: ""
            });
            this.medicalTerminationTextBox.focus();
            this.medicalTerminationErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Termination date should be greater than effective date.";
          } else {
            if (bsValueTermination != null) {
              this.bsValMedicalTermination = new Date(bsValueTermination);
            }
            this.addMemberForm.controls['householdDemographicForm'].controls['medicalTermination'].setValue(bsValueTermination);
            this.medicalTerminationErrorMessage = "";
          }
        }
      }
      else if (bsValueTermination == "Invalid Date" || bsValueTermination == "Invalid date") {
        this.addMemberForm.controls['householdDemographicForm'].patchValue({
          medicalTermination: ""
        });
        this.addMemberForm.controls['householdDemographicForm'].controls['medicalTermination'].setErrors({ pattern: true });
        this.medicalTerminationErrorMessage = validMessage ? "Date must be in mm/dd/yyyy format." : "Termination date should be greater than effective date.";
      }
      else if (bsValueTermination == "") {
        this.medicalTerminationErrorMessage = "";
      }
    }
  }
  getTabStatus() { // Get current tab status
    var assessmentId: number = +(this.assessmentId);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        this.isHouseholdAdded = result.data.isHouseholdComplete;
        this.isQuickSaved = result.data.isQuickAssessmentComplete;
        this.isPersonalSaved = result.data.isPersonalInfoComplete;
        this.isPersonalHome = result.data.isPersonalHomeComplete;
        this.isGuarantorSaved = result.data.isGuarantorInfoComplete;
        this.isGuarantorInfo = result.data.isGuarantorBasicInfoComplete;
        this.isGuarantorHome = result.data.isGuarantorHomeComplete;
        this.isContactSaved = result.data.isContactPreferenceComplete;
        this.isDetailsDone = result.data.canEvaluate;
        if (result.data.isHouseholdComplete == true) { this.dataSharing.SaveHousehold.next('true'); }
        else if (result.data.isHouseholdComplete == false) { this.dataSharing.SaveHousehold.next('false'); }
        else
          this.dataSharing.SaveHousehold.next('');
      }
    }, (error) => { console.log(error) });
  }
  nextToApplicationForms() { // Move to next tab
    this.allProgramsForm.reset();
    this.addMore = [];
    this.getTabStatus();
    if (this.showAdvocatePanel == true) {
      this.dataSharing.evaluateHousehold.next(true);
    }
    if (this.memberListEmptyFlag == true) { // checks when household memberlist with no records! 
      if (this.showAdvocatePanel == true) { this.dataSharing.ShowProgramsTab.next("5"); }
      this.toastService.showWarning(StringConstants.toast.addhousehold, StringConstants.toast.empty);
      this.dataSharing.SaveHousehold.next("false");
      if (this.isQuickSaved == null || this.isQuickSaved == false)
        this.dataSharing.SaveQuickAssessment.next("false");
      if (this.isPersonalSaved == null || this.isPersonalSaved == false) {
        this.dataSharing.SavePersonal.next("false");
        if (this.isPersonalHome == null || this.isPersonalHome == false)
          this.dataSharing.SavePersonalHome.next("false");
      }
      if (this.isGuarantorSaved == false || this.isGuarantorSaved == null) {
        this.dataSharing.SaveGuarantor.next("false");
        if (this.isGuarantorInfo == null || this.isGuarantorInfo == false)
          this.dataSharing.SaveGuarantorInfo.next("false");
        if (this.isGuarantorHome == null || this.isGuarantorHome == false)
          this.dataSharing.SaveGuarantorHome.next("false");
      }
      if (this.isContactSaved == null || this.isContactSaved == false)
        this.dataSharing.SaveContactPreference.next("false");
    }
    else { // checks when household memberList with records!
      if (this.isDetailsDone == true && this.showAdvocatePanel == false) { // checks when quickassessmentresults, personal, guarantor and contact preference are completed!
        this.updateNewPrograms();
      }
      else {  // checks when quickassessmentresults, personal, guarantor and contact preference are not completed!
        this.dataSharing.EnableDocumentation.next('false');
        if (this.showAdvocatePanel == true) { // For advocate flow!
          this.updateNewPrograms()
        }
        else { // For patient flow!
          var count = 0;
          if (this.isQuickSaved == null || this.isQuickSaved == false) {
            this.dataSharing.SaveQuickAssessment.next("false");
            count++;
          }
          if (this.isPersonalSaved == null || this.isPersonalSaved == false) {
            this.dataSharing.SavePersonal.next("false");
            count++;
          }
          if (this.isGuarantorSaved == false || this.isGuarantorSaved == null) {
            this.dataSharing.SaveGuarantor.next("false");
            count++;
          }
          if (this.isContactSaved == null || this.isContactSaved == false) {
            this.dataSharing.SaveContactPreference.next("false");
            count++;
          }
          if (count > 0) {
            this.toastService.showWarning('Kindly complete the incomplete tabs to proceed.', '');
          }
          if (this.isHouseholdAdded == null || this.isHouseholdAdded == false && count == 0) {
            this.dataSharing.SaveHousehold.next("false");
            this.toastService.showWarning(this.names, 'Kindly complete the details for the household member');
          }
        }
      }
    }
  }
  updateNewPrograms() { // Update new programs after evalute houshold members 
    this.showLoader = true;
    var patientID: number = +(this.patientId);
    var assessmentId: number = +(this.assessmentId);
    const request: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.EvaluateAssessment(request)
      .subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          await this.getTabStatus();
          this.showLoader = false;
          this.override = result.data.override;
          this.allPrograms = result.data.allPrograms;
          this.programsOpted = result.data.programsOpted;
          this.navigate();
        }
      },
        (err) => { console.log(StringConstants.toast.error, err); }, () => { })
  }
  changeProgram(val: string, index: any, event: any) { // To add more programs
    if (event.target.checked) { this.addMore[index] = val; }
    else { this.addMore[index] = null; }
  }
  navigate() {
    if (this.override == false && this.showAdvocatePanel == false) {
      this.dataSharing.EnableDocumentation.next('true');
      this.dataSharing.showApplicationFormNext.next('5');
    }
    if (this.showAdvocatePanel == true) { this.dataSharing.ShowProgramsTab.next("5"); }
  }
  nextTab() { // Go to next tab
    this.showLoader = true;
    this.tempArray = this.addMore;
    this.tempArray = this.addMore.filter((e: any) => e != null);
    const reqBody: any = {
      assessmentId: +(sessionStorage.getItem('assessmentId')!),
      programNameList: this.tempArray,
      isEvaluated: true,
    }
    this.quickAssessmentService.createProgramMapping(reqBody).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.dataSharing.EnableDocumentation.next('true');
        this.dataSharing.showApplicationFormNext.next('5');
        this.showLoader = false;
      }
    }, (error) => { console.log(error) });
  }
  resourceFields() { // To show resource fields
    this.resourcebuttonText = "Add Resource";
    this.ResetResourceDetail();
    this.resourceFlag = true;
    this.resourcebuttonFlag = true;
    this.ClearResourceValidations();
    this.addMemberForm.get(['householdResourceForm']).markAsPristine();
  }
  incomeFields() { // To show income fields
    this.ResetIncomeDetail();
    this.incomeFlag = true;
    this.addIncomeOptionFlag = false;
    this.incomebuttonFlag = true;
    this.ClearIncomeValidations();
    this.addMemberForm.get(['IncomeForm']).markAsPristine();
    this.addMemberForm.get(['householdIncomeForm']).markAsPristine();
  }
  getHouseHoldMemberDetailsById() { //Get household member details
    var resourcedetail: ResourceDetails[] = [];
    var incomedetail: IncomeDetails[] = [];
    this.dashboardService.getHouseHoldMemberDetails(this.householdMemberId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.firstName = result.data.firstName;
        this.middleName = result.data.middleName;
        this.lastName = result.data.lastName;
        this.suffix = result.data.suffix;
        this.relation = result.data.relationship;
        this.dateOfBirth = result.data.dateOfBirth;
        this.bsVal = new Date(this.dateOfBirth);
        this.gender = result.data.gender;
        this.maritalStatus = result.data.maritalStatus;
        this.ssn = result.data.ssnNumber;
        this.reasonNoSSN = result.data.reasonNoSsn;
        this.isDependent = String(result.data.isDependent);
        this.isMedicalAid = String(result.data.isMedicAidAvailable);
        if (this.isMedicalAid == "true") { this.showMedicalAidFields = true; }
        else { this.showMedicalAidFields = false; }
        this.isInsurance = String(result.data.isInsuranceAvailable);
        if (this.isInsurance == "true") { this.showPriorCoverageFields = true; }
        else { this.showPriorCoverageFields = false; }
        this.payerName = result.data.payerName;
        this.groupName = result.data.groupName;
        this.groupNumber = result.data.groupNumber;
        this.policyNumber = result.data.policyNumber;
        this.effectiveFrom = result.data.priorCoverageEffectiveFrom;
        this.termination = result.data.priorCoverageTerminationDate;
        this.medicalId = result.data.medicAidId;
        this.medicalState = result.data.state;
        this.medicalEffectiveFrom = result.data.medicAidEffectiveFrom;
        this.medicalTermination = result.data.medicAidTerminationDate;
        if (this.relation == 'Self') {
          this.isSelfRelationChanged = true;
          this.isSelfRelationReadOnly = true;
          this.selfDisable = true;
          this.addMemberForm.get(['householdDemographicForm', 'maritalStatus']).disable();
          this.addMemberForm.get(['householdDemographicForm', 'gender']).disable();
          this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).disable();
          this.addMemberForm.get(['householdDemographicForm', 'ssn']).clearValidators();
          this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
          this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).clearValidators();
          this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
          this.sssn = result.data.ssnNumberMasked;
          this.ssnNumberValue = result.data.ssnNumber;
          this.ssn = result.data.ssnNumber;
          this.reasonNoSSN = result.data.reasonNoSsn;
        }
        else {
          this.isSelfRelationChanged = false;
          if (this.canDelete == false && this.relation != null) {
            this.isSelfRelationReadOnly = true;
            this.selfDisable = true;
            this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).disable();
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).disable();
            this.addMemberForm.get(['householdDemographicForm', 'maritalStatus']).enable();
            this.addMemberForm.get(['householdDemographicForm', 'gender']).enable();
          }
          else {
            this.isSelfRelationReadOnly = false;
            this.selfDisable = false;
            this.addMemberForm.get(['householdDemographicForm', 'maritalStatus']).enable();
            this.addMemberForm.get(['householdDemographicForm', 'gender']).enable();
            this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).enable();
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).enable();
          }
          if (this.ssn != null && this.reasonNoSSN == null) {
            this.addMemberForm.get(['householdDemographicForm', 'ssn']).setValidators([Validators.required]);
            this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).clearValidators();
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
          }
          else if (this.ssn == null) {
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).setValidators([Validators.required]);
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
            this.addMemberForm.get(['householdDemographicForm', 'ssn']).clearValidators();
            this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
          }
          this.sssn = result.data.ssnNumberMasked;
          this.ssnNumberValue = result.data.ssnNumber;
          this.ssn = result.data.ssnNumber;
          this.reasonNoSSN = result.data.reasonNoSsn;
        }
        this.incomeResult = result.data.houseHoldIncomeDtos;
        var n = 0;
        var memberId = this.householdMemberId;
        result.data.houseHoldResourceDtos.forEach(function (value: ResourceDetails) {
          resourcedetail[n] = value;
          resourcedetail[n].Id = n + 1;
          resourcedetail[n].HouseHoldMemberId = +(memberId);
          resourcedetail[n].AssessmentId = +(sessionStorage.getItem('assessmentId')!);
          n++;
        });
        this.resourceMap.clear();
        for (let i = 0; i < resourcedetail.length; i++) {
          this.resourceMap.set(i + 1, resourcedetail[i]);
        }
        this.resourceResult = resourcedetail;
        var n = 0;
        var memberId = this.householdMemberId;
        result.data.houseHoldIncomeDtos.forEach(function (value: IncomeDetails) {
          incomedetail[n] = value;
          incomedetail[n].Id = n + 1;
          incomedetail[n].houseHoldMemberId = +(memberId);
          incomedetail[n].assessmentId = +(sessionStorage.getItem('assessmentId')!);
          n++;
        });
        this.incomeMap.clear();
        for (let i = 0; i < incomedetail.length; i++) {
          this.incomeMap.set(i + 1, incomedetail[i]);
        }
        this.incomeResult = incomedetail;
      }
    }, (error) => { console.log(error) });
  }
  editResourceValues(InternalResourceId: any) { //To edit resource values
    this.resourcebuttonFlag = false;
    this.resourcebuttonText = "Update Resource";
    this.EditResourceDetail_Internal(InternalResourceId);
  }
  updateHouseHoldResourceDetails(resourceDetails: any) { //Update household resource details
    this.isResourceClicked = true;
    this.AddResourceValidations();
    if (this.addMemberForm.get('householdResourceForm').valid) {
      this.isResourceClicked = false;
      this.ClearResourceValidations();
      var currentMarketValue: number = +(resourceDetails.householdResourceForm.resourceIncomeAmt);
      var calculatedValue: number = +(resourceDetails.householdResourceForm.resourcecalculatedValue);
      var resourceIncomeAmt: number = +(resourceDetails.householdResourceForm.resourceIncomeAmt);
      var ownership: number = +(resourceDetails.householdResourceForm.ownership);
      let resVal = Math.round(((Number(resourceIncomeAmt) * (Number(ownership) / 100)) + Number.EPSILON) * 100) / 100;
      this.resourceValue == resVal;
      var householdMemberId = +(this.householdMemberId);
      var marketValue = resourceDetails.householdResourceForm.resourceIncomeAmt.toString();
      const resourceData: any = {
        houseHoldMemberId: householdMemberId,
        emailAddress: this.loginUserMail,
        assessmentId: this.assessmentId,
        resourceId: this.resourceId,
        resourceType: resourceDetails.householdResourceForm.resourceType,
        currentStatus: resourceDetails.householdResourceForm.resourceStatus,
        verification: resourceDetails.householdResourceForm.resourceAcceptStatus,
        currentMarketValue: marketValue,
        ownership: resourceDetails.householdResourceForm.ownership,
        calculatedValue: resVal.toString(),
        propertyLocation: resourceDetails.householdResourceForm.locationName,
      }
      this.UpdateHouseHoldResourceDetails_Internal(resourceData, this.internalresourceId);
    }
    this.addMemberForm.get(['householdResourceForm']).markAsPristine();
  }
  deleteResourceValues(internalresourceId: any) { //Delete resource value
    this.DeleteResourceDetail_Internal(internalresourceId);
  }
  editIncomeValues(internalIncomeId: any) { //Edit income Details
    this.incomebuttonFlag = false;
    this.addIncomeOptionFlag = false;
    this.EditIncomeDetail_Internal(internalIncomeId);
  }
  updateHouseHoldIncomeDetails(addMemberFormIncome: any) { //Update household income details
    this.isIncomeClicked = true;
    this.AddIncomeValidations();
    if (this.addMemberForm.get(['IncomeForm', 'zipCode']).value == null || this.addMemberForm.get(['IncomeForm', 'zipCode']).value == "") {
      this.validZip = true;
    }
    if (this.addMemberForm.get('householdIncomeForm').valid && this.addMemberForm.get('IncomeForm').valid && this.validZip == true) {
      this.isIncomeClicked = false;
      this.ClearIncomeValidations();
      let income: number = +(addMemberFormIncome.householdIncomeForm.grossPay);
      if (addMemberFormIncome.householdIncomeForm.grossPayPeriod == 'Biweekly') {
        let incomevalue = Math.round(((Number(income) * 2) + Number.EPSILON) * 100) / 100;
        let monIncome = incomevalue.toString();
        this.monthlyIncome = monIncome;
      }
      else if (addMemberFormIncome.householdIncomeForm.grossPayPeriod == 'Weekly') {
        let incomevalue = Math.round(((Number(income) * 4) + Number.EPSILON) * 100) / 100;
        let monIncome = incomevalue.toString();
        this.monthlyIncome = monIncome;
      }
      else if (addMemberFormIncome.householdIncomeForm.grossPayPeriod == "Monthly") {
        let incomevalue = Math.round(((Number(income) * 1) + Number.EPSILON) * 100) / 100;
        let monIncome = incomevalue.toString();
        this.monthlyIncome = monIncome;
      }
      else if (addMemberFormIncome.householdIncomeForm.grossPayPeriod == "Bimonthly") {
        let incomevalue = Math.round(((Number(income) / 2) + Number.EPSILON) * 100) / 100;
        let monIncome = incomevalue.toString();
        this.monthlyIncome = monIncome;
      }
      else if (addMemberFormIncome.householdIncomeForm.grossPayPeriod == "Yearly") {
        let incomevalue = Math.round(((Number(income) / 12) + Number.EPSILON) * 100) / 100;
        let monIncome = incomevalue.toString();
        this.monthlyIncome = monIncome;
      }
      var zipcode: number = +(addMemberFormIncome.IncomeForm.zipCode);
      const incomeData: any = {
        incomeId: this.incomeId,
        householdMemberId: this.householdMemberId,
        assessmentId: this.assessmentId,
        incomeType: addMemberFormIncome.householdIncomeForm.incomeType,
        currentStatus: addMemberFormIncome.householdIncomeForm.currentStatus,
        verification: addMemberFormIncome.householdIncomeForm.acceptStatus,
        grossPay: addMemberFormIncome.householdIncomeForm.grossPay,
        grossPayPeriod: addMemberFormIncome.householdIncomeForm.grossPayPeriod,
        calculatedMonthlyIncome: this.monthlyIncome,
        contactName: addMemberFormIncome.IncomeForm.contactName,
        addressOperationFlag: "UPDATE",
        emailAddress: this.loginUserMail,
        updateAddressDto: {
          name: addMemberFormIncome.IncomeForm.companyName,
          contactDetailsId: this.contactDetailsId,
          streetAddress: addMemberFormIncome.IncomeForm.streetAddress,
          city: addMemberFormIncome.IncomeForm.city,
          state: addMemberFormIncome.IncomeForm.state,
          stateCode: this.state,
          zipCode: addMemberFormIncome.IncomeForm.zipCode,
          cellNumber: addMemberFormIncome.IncomeForm.cellNumber,
          countyCode: addMemberFormIncome.IncomeForm.countryCode,
          fax: addMemberFormIncome.IncomeForm.faxNumber,
        }
      }
      this.UpdateHouseHoldIncomeDetails_Internal(incomeData, this.internalIncomeId);
    }
    else {
      if (this.validZip == false) {
        this.addMemberForm.controls['IncomeForm'].controls['zipCode'].setErrors({ 'invalid': true });
      }
    }
    this.addMemberForm.get(['IncomeForm']).markAsPristine();
    this.addMemberForm.get(['householdIncomeForm']).markAsPristine();
  }
  deleteIncomeValues(internalIncomeId: any) { //Delete Income data from houshold member
    this.DeleteIncomeDetail_Internal(internalIncomeId);
  }
  check(event: { keyCode: number, key: string }) {
    if (event.keyCode == 8 || event.key == 'Backspace') {
      const val = this.addMemberForm.get(['IncomeForm', 'zipCode']).value;
      if (val == null || val == "") {
        this.addMemberForm.controls['IncomeForm'].controls['zipCode'].setErrors(null);
      }
    }
  }
  async getStateAndCity() { //Get state and city
    const val = this.addMemberForm.get(['IncomeForm', 'zipCode']).value;
    if (val.length >= 5) {
      this.result = await this.common.getStateAndCity(val);
      if (this.result.wasSuccessful == true) {
        if (this.result.data != null) {
          this.city = this.result.data.city;
          this.state = this.result.data.state;
          this.stateCode = this.result.data.stateCode;
          this.validZip = true;
          this.addMemberForm.controls['IncomeForm'].controls['zipCode'].setErrors(null);
        }
        else {
          this.city = "";
          this.state = "";
          this.validZip = false;
          this.addMemberForm.controls['IncomeForm'].controls['zipCode'].setErrors({ 'invalid': true });
        }
      }
      else if (this.result.wasSuccessful == false) {
      }
    }
    else {
      this.city = "";
      this.state = "";
    }
  }
  dependencyRequiredMessage() {  //Handle error message
    this.isInsuranceRequiredMessage = "";
    this.isMedicalAidRequiredMessage = "";
    this.isDependentRequiredMessage = "";
  }
  followupMedicaidRequiredMessage() {  //Handle error message
    this.medicaidIdReqquiredMessage = "";
    this.medicaidStateRequiredMessage = "";
  }
  followuppriorCoverageMessage() {  //Handle error message
    this.payerNameRequiredMessage = "";
    this.groupNumberRequiredMessage = "";
    this.policyNumberRequiredMessage = "";
  }
  CreateNewMember(addNewMemberInfo: any) { //Create new household members
    this.panelOpenStateDemographic = true;
    if (!this.addMemberForm.valid || this.tempMsg == false) {
      this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
      this.dependencyRequiredMessage();
      if (this.medicalId == null || this.medicalId == '') { this.medicaidIdReqquiredMessage = "Medicaid ID is required!"; }
      if (this.medicalState == null || this.medicalState == '') { this.medicaidStateRequiredMessage = "State is required!"; }
      if (this.payerName == null || this.payerName == '') { this.payerNameRequiredMessage = "Payer Name is required!"; }
      if (this.groupNumber == null || this.groupNumber == '') { this.groupNumberRequiredMessage = "Group Number is required!"; }
      if (this.policyNumber == null || this.policyNumber == '') { this.policyNumberRequiredMessage = "Policy Number is required!"; }
    }
    else if (addNewMemberInfo.householdDemographicForm.isDependent == "null" || addNewMemberInfo.householdDemographicForm.isMedicalAid == "null" || addNewMemberInfo.householdDemographicForm.isInsurance == "null") {
      this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
      if (addNewMemberInfo.householdDemographicForm.isDependent == "null") { this.isDependentRequiredMessage = "Please select Yes/No"; }
      if (addNewMemberInfo.householdDemographicForm.isMedicalAid == "null") { this.isMedicalAidRequiredMessage = "Please select Yes/No"; }
      if (addNewMemberInfo.householdDemographicForm.isInsurance == "null") { this.isInsuranceRequiredMessage = "Please select Yes/No"; }
    }
    else if (addNewMemberInfo.householdDemographicForm.isDependent != "null" && addNewMemberInfo.householdDemographicForm.isMedicalAid != "null" && addNewMemberInfo.householdDemographicForm.isInsurance != "null") {
      if ((this.addMemberForm.get(['IncomeForm']).dirty || this.addMemberForm.get(['householdIncomeForm']).dirty) &&
        this.panelOpenStateIncome == true) {
        this.toastService.showWarning(StringConstants.toast.clickIncome, StringConstants.toast.addIncome);
      }
      else if (this.addMemberForm.get(['householdResourceForm']).dirty && this.panelOpenStateResource == true) {
        this.toastService.showWarning(StringConstants.toast.clickResource, StringConstants.toast.addResource);
      }
      else {
        this.showLoader = true;
        this.ClearResourceValidations();
        this.ClearIncomeValidations();
        this.followupMedicaidRequiredMessage();
        this.followuppriorCoverageMessage();
        this.dependencyRequiredMessage();
        var assessment: any = sessionStorage.getItem('assessmentId');
        var assessmentId: number = +(assessment);
        var isDependent = JSON.parse(addNewMemberInfo.householdDemographicForm.isDependent);
        var isMedicalAid = JSON.parse(addNewMemberInfo.householdDemographicForm.isMedicalAid);
        var isInsurance = JSON.parse(addNewMemberInfo.householdDemographicForm.isInsurance);
        let income: number = +(addNewMemberInfo.householdIncomeForm.grossPay);
        var resourceIncomeAmt: number = +(addNewMemberInfo.householdResourceForm.resourceIncomeAmt);
        var ownership: number = +(addNewMemberInfo.householdResourceForm.ownership);
        if (resourceIncomeAmt != 0 && ownership != 0) {
          let resVal = Math.round(((Number(resourceIncomeAmt) * (Number(ownership) / 100)) + Number.EPSILON) * 100) / 100
          this.resourceValue == resVal.toString();
        }
        else {
          let resourcecal = resourceIncomeAmt * ownership;
          this.resourceValue == resourcecal.toString();
        }
        if (addNewMemberInfo.householdIncomeForm.grossPayPeriod == 'Biweekly') {
          let incomevalue = Math.round(((Number(income) * 2) + Number.EPSILON) * 100) / 100;
          let monIncome = incomevalue.toString();
          this.monthlyIncome = monIncome;
        }
        else if (addNewMemberInfo.householdIncomeForm.grossPayPeriod == 'Weekly') {
          let incomevalue = Math.round(((Number(income) * 4) + Number.EPSILON) * 100) / 100;
          let monIncome = incomevalue.toString();
          this.monthlyIncome = monIncome;
        }
        else if (addNewMemberInfo.householdIncomeForm.grossPayPeriod == "Monthly") {
          let incomevalue = Math.round(((Number(income) * 1) + Number.EPSILON) * 100) / 100;
          let monIncome = incomevalue.toString();
          this.monthlyIncome = monIncome;
        }
        else if (addNewMemberInfo.householdIncomeForm.grossPayPeriod == "Bimonthly") {
          let incomevalue = Math.round(((Number(income) / 2) + Number.EPSILON) * 100) / 100;
          let monIncome = incomevalue.toString();
          this.monthlyIncome = monIncome;
        }
        else if (addNewMemberInfo.householdIncomeForm.grossPayPeriod == "Yearly") {
          let incomevalue = Math.round(((Number(income) / 12) + Number.EPSILON) * 100) / 100;
          let monIncome = incomevalue.toString();
          this.monthlyIncome = monIncome;
        }
        this.IncomeDetails = [];
        this.incomeMap.forEach((value: IncomeDetails, key: Number) => {
          this.IncomeDetails.push(value);
        });
        addNewMemberInfo.householdDemographicForm.dateOfBirth = new Date(addNewMemberInfo.householdDemographicForm.dateOfBirth);
        addNewMemberInfo.householdDemographicForm.dateOfBirth = addNewMemberInfo.householdDemographicForm.dateOfBirth.toLocaleDateString("en-US", {
          year: "numeric",
          day: "2-digit",
          month: "2-digit",
        });
        this.getDateFormatDetails();
        let patientId: number = +(sessionStorage.getItem("patientId")!);
        const householdMember = {
          id: this.householdMemberId,
          patientId: patientId,
          assessmentId: assessmentId,
          firstName: addNewMemberInfo.firstName,
          middleName: addNewMemberInfo.middleName,
          lastName: addNewMemberInfo.lastName,
          suffix: addNewMemberInfo.suffix,
          relationship: addNewMemberInfo.relation,
          dateOfBirth: this.dateOfBirth,
          gender: this.gender,
          MaritalStatus: this.maritalStatus,
          ssnNumber: this.ssn,
          reasonNoSsn: this.reasonNoSSN,
          isDependent: isDependent,
          isMedicAidAvailable: isMedicalAid,
          isInsuranceAvailable: isInsurance,
          payerName: this.payerName,
          groupName: this.groupName,
          groupNumber: this.groupNumber,
          policyNumber: this.policyNumber,
          priorCoverageEffectiveFrom: this.effectiveFrom,
          priorCoverageTerminationDate: this.termination,
          state: this.medicalState,
          medicAidId: this.medicalId,
          medicAidEffectiveFrom: this.medicalEffectiveFrom,
          medicAidTerminationDate: this.medicalTermination,
          operationFlag: "true",
          houseHoldIncomeDtos: this.IncomeDetails,
          houseHoldResourceDtos: this.resourceResult,
          DeletedIncomeIds: this.deletedincomeId,
          DeletedResourceIds: this.deletedresourceId,
        }
        this.dashboardService.CreateHouseholdMember(householdMember).subscribe(async (result: any) => {
          if (result.wasSuccessful) {
            this.showLoader = false;
            this.getTabStatus();
            this.cancelAddmemberForm();
            this.memberList();
          }
        }, (error) => {
          this.toastService.showWarning(error.error.errors, StringConstants.toast.empty);
          this.showLoader = false;
        });
        this.memberListEmptyFlag = false;
      }
    }
  }
  getDateFormatDetails() { //Get form details
    if (this.effectiveFrom != null && this.effectiveFrom != 'Invalid Date' && this.effectiveFrom != '') {
      this.effectiveFrom = new Date(this.effectiveFrom);
      this.effectiveFrom = this.effectiveFrom.toLocaleDateString("en-US", {
        year: "numeric",
        day: "2-digit",
        month: "2-digit",
      });
    }
    else if (this.effectiveFrom == 'Invalid Date') {
      this.effectiveFrom = null;
    }
    if (this.termination != null && this.termination != 'Invalid Date' && this.termination != "") {
      this.termination = new Date(this.termination);
      this.termination = this.termination.toLocaleDateString("en-US", {
        year: "numeric",
        day: "2-digit",
        month: "2-digit",
      });
    }
    else if (this.termination == 'Invalid Date') {
      this.termination = null;
    }
    if (this.medicalEffectiveFrom != null && this.medicalEffectiveFrom != 'Invalid Date' && this.medicalEffectiveFrom != '') {
      this.medicalEffectiveFrom = new Date(this.medicalEffectiveFrom);
      this.medicalEffectiveFrom = this.medicalEffectiveFrom.toLocaleDateString("en-US", {
        year: "numeric",
        day: "2-digit",
        month: "2-digit",
      });
    }
    else if (this.medicalEffectiveFrom == 'Invalid Date') {
      this.medicalEffectiveFrom = null;
    }
    if (this.medicalTermination != null && this.medicalTermination != 'Invalid Date' && this.medicalTermination != '') {
      this.medicalTermination = new Date(this.medicalTermination);
      this.medicalTermination = this.medicalTermination.toLocaleDateString("en-US", {
        year: "numeric",
        day: "2-digit",
        month: "2-digit",
      });
    }
    else if (this.medicalTermination == 'Invalid Date') {
      this.medicalTermination = null;
    }
  }
  cancelAddmemberForm() {
    this.addMemberForm.reset();
  }
  clearhouseholdResourceForm() {
    this.addMemberForm.get(['householdResourceForm']).markAsPristine();
    this.isResourceClicked = false;
    this.ResetResourceDetail();
    this.resourceFlag = false;
    this.ClearResourceValidations();
  }
  clearhouseholdIncomeForm() {
    this.addMemberForm.get(['IncomeForm']).markAsPristine();
    this.addMemberForm.get(['householdIncomeForm']).markAsPristine();
    this.ResetIncomeDetail();
    this.isIncomeClicked = false;
    this.incomeFlag = false;
    this.addIncomeOptionFlag = true;
    this.ClearIncomeValidations();
  }
  DeleteIncomeDetail_Internal(InternalincomeId: any) {
    this.deletedincomeId.push(this.incomeMap.get(InternalincomeId)?.incomeId);
    this.incomeMap.delete(InternalincomeId);
    this.RefreshIncomeTableData_internal();
    this.clearhouseholdIncomeForm();
  }
  DeleteResourceDetail_Internal(internalresourceId: any) {
    this.deletedresourceId.push(this.resourceMap.get(internalresourceId)?.resourceId);
    this.resourceMap.delete(internalresourceId);
    this.RefreshResourceTableData_internal();
    this.clearhouseholdResourceForm();
  }
  EditIncomeDetail_Internal(internalIncomeId: any) {
    this.editIncomeDetails = this.incomeMap.get(internalIncomeId);
    this.incomeFlag = true;
    this.incomeType = this.editIncomeDetails.incomeType;
    this.currentStatus = this.editIncomeDetails.currentStatus;
    this.acceptStatus = this.editIncomeDetails.verification
    this.grossPay = this.editIncomeDetails.grossPay;
    this.grossPayPeriod = this.editIncomeDetails.grossPayPeriod;
    this.companyName = this.editIncomeDetails.companyName;
    this.contactName = this.editIncomeDetails.contactName;
    this.streetAddress = this.editIncomeDetails.streetAddress;
    this.city = this.editIncomeDetails.city;
    this.state = this.editIncomeDetails.state;
    this.stateCode = this.stateCode,
    this.zipCode = this.editIncomeDetails.zipCode;
    this.cellNumber = this.editIncomeDetails.cellNumber;
    this.faxNumber = this.editIncomeDetails.fax;
    this.contactDetailsId = this.editIncomeDetails.contactDetailsId;
    this.incomeId = this.editIncomeDetails.incomeId;
    this.incomecalculatedValue = this.editIncomeDetails.calculatedMonthlyIncome;
    this.countryCode = this.editIncomeDetails.countyCode;
    this.internalIncomeId = internalIncomeId;
  }
  EditResourceDetail_Internal(internalresourceId: any) {
    this.editResourceDetails = this.resourceMap.get(internalresourceId);
    this.resourceFlag = true;
    this.resourceType = this.editResourceDetails.resourceType;
    this.resourceStatus = this.editResourceDetails.currentStatus;
    this.resourceAcceptStatus = this.editResourceDetails.verification
    this.locationName = this.editResourceDetails.propertyLocation;
    this.resourceIncomeAmt = this.editResourceDetails.currentMarketValue;
    this.ownership = this.editResourceDetails.ownership;
    this.resourceId = this.editResourceDetails.resourceId;
    this.resourcecalculatedValue = this.editResourceDetails.calculatedValue;
    this.internalresourceId = internalresourceId;
  }
  UpdateHouseHoldIncomeDetails_Internal(incomeDetails: any, internalIncomeId: any) { //Update income details
    var Id;
    if (internalIncomeId == undefined) Id = this.incomeMap.size + 1;
    else Id = internalIncomeId;
    let detail: IncomeDetails = {
      Id: Id,
      incomeId: incomeDetails.incomeId,
      incomeType: incomeDetails.incomeType,
      currentStatus: incomeDetails.currentStatus,
      verification: incomeDetails.verification,
      grossPay: incomeDetails.grossPay,
      grossPayPeriod: incomeDetails.grossPayPeriod,
      calculatedMonthlyIncome: incomeDetails.calculatedMonthlyIncome,
      companyName: incomeDetails.updateAddressDto.name,
      contactDetailsId: incomeDetails.updateAddressDto.contactDetailsId,
      contactName: incomeDetails.contactName,
      streetAddress: incomeDetails.updateAddressDto.streetAddress,
      city: incomeDetails.updateAddressDto.city,
      state: incomeDetails.updateAddressDto.state,
      stateCode: this.stateCode,
      zipCode: incomeDetails.updateAddressDto.zipCode,
      cellNumber: incomeDetails.updateAddressDto.cellNumber,
      fax: incomeDetails.updateAddressDto.fax,
      countyCode: incomeDetails.updateAddressDto.countyCode,
      houseHoldMemberId: incomeDetails.householdMemberId,
      emailAddress: incomeDetails.emailAddress,
      assessmentId: incomeDetails.assessmentId
    }
    this.incomeMap.set(Id, detail);
    this.RefreshIncomeTableData_internal();
    this.incomeResult = this.IncomeDetails;
    this.incomeFlag = false;
    this.addIncomeOptionFlag = true;
  }
  UpdateHouseHoldResourceDetails_Internal(resourceDetails: any, internalresourceId: any) {
    var Id;
    if (internalresourceId == undefined) Id = this.resourceMap.size + 1;
    else Id = internalresourceId;
    let detail: ResourceDetails = {
      Id: Id,
      resourceId: resourceDetails.resourceId,
      operationFlag: "true",
      resourceType: resourceDetails.resourceType,
      currentStatus: resourceDetails.currentStatus,
      verification: resourceDetails.verification,
      currentMarketValue: resourceDetails.currentMarketValue,
      ownership: resourceDetails.ownership,
      calculatedValue: resourceDetails.calculatedValue,
      propertyLocation: resourceDetails.propertyLocation,
      HouseHoldMemberId: resourceDetails.houseHoldMemberId,
      AssessmentId: this.assessmentId,
    }
    this.resourceMap.set(Id, detail);
    this.RefreshResourceTableData_internal();
    this.resourceFlag = false;
    this.addResourceOptionFlag = true;
  }
  UpdateIncomeTable() { //Update income table
    this.dashboardService.getHouseHoldMemberDetails(this.householdMemberId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.incomeResult = result.data.houseHoldIncomeDtos;
        this.incomeFlag = false;
        this.addIncomeOptionFlag = true;
      }
    }, (error) => { console.log(error) });
  }
  UpdateResourceTable() { //Update resource table
    this.dashboardService.getHouseHoldMemberDetails(this.householdMemberId).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.resourceResult = result.data.houseHoldResourceDtos;
        this.resourceFlag = false;
      }
    }, (error) => { console.log(error) });
  }
  ResetIncomeDetail() { //Reset income details
    this.incomeType = "";
    this.currentStatus = StringConstants.dashboardHouseholdMember.current;
    if (this.showAdvocatePanel == true) { this.acceptStatus = " "; }
    else { this.acceptStatus = StringConstants.var.AcceptedNotverified; }
    this.grossPay = "";
    this.grossPayPeriod = StringConstants.dashboardHouseholdMember.monthly;
    this.companyName = "";
    this.contactName = "";
    this.streetAddress = "";
    this.city = "";
    this.state = "";
    this.zipCode = "";
    this.cellNumber = "";
    this.faxNumber = "";
    this.patientId = "";
    this.contactDetailsId = 0;
    this.incomeId = 0;
    this.incomecalculatedValue = "";
    this.countryCode = "1";
    this.internalIncomeId = undefined;
  }
  ResetResourceDetail() { //Reset resource details
    this.resourceType = "";
    this.resourceStatus = StringConstants.dashboardHouseholdMember.currentlyOwned;
    if (this.showAdvocatePanel == true) { this.resourceAcceptStatus = " "; }
    else { this.resourceAcceptStatus = StringConstants.var.AcceptedNotverified; }
    this.locationName = "";
    this.resourceIncomeAmt = "";
    this.resourcecalculatedValue = "";
    this.ownership = "100";
    this.internalresourceId = undefined;
    this.resourceId = 0;
    this.resourcecalculatedValue = "";
  }
  RefreshIncomeTableData_internal() {
    this.IncomeDetails = [];
    this.incomeMap.forEach((value: IncomeDetails, key: Number) => {
      this.IncomeDetails.push(value);
    });
    this.incomeResult = this.IncomeDetails;
    this.IncomeDetails = [];
    this._incomeMap = new Map(this.incomeMap);
    this.incomeMap.clear();
    var n = 1;
    this._incomeMap.forEach((value: IncomeDetails, key: Number) => {
      value.Id = n;
      this.incomeMap.set(n, value);
      n++;
    });
    this.incomeMap.forEach((value: IncomeDetails, key: Number) => {
      this.IncomeDetails.push(value);
    });
    this.incomeResult = this.IncomeDetails;
  }
  RefreshResourceTableData_internal() {
    this.ResourceDetails = [];
    this._resourceMap = new Map(this.resourceMap);
    this.resourceMap.clear();
    var n = 1;
    this._resourceMap.forEach((value: ResourceDetails, key: Number) => {
      value.Id = n;
      this.resourceMap.set(n, value);
      n++;
    });
    this.resourceMap.forEach((value: ResourceDetails, key: Number) => {
      this.ResourceDetails.push(value);
    });
    this.resourceResult = this.ResourceDetails;
  }
  onChangeRelation($event: any) { //Onchange event for relation ship
    this.HForm.submitted = false;
    this.panelOpenStateResource = false;
    this.panelOpenStateIncome = false;
    this.relation = this.addMemberForm.get('relation').value;
    if (this.relation == 'Self') {
      if (this.incomeMap.size > 0 || this.resourceMap.size > 0) {
        this.toastService.showWarning(StringConstants.toast.changeSelf, StringConstants.toast.empty);
      }
      this.isSelfRelationChanged = true;
      this.patientId = sessionStorage.getItem('patientId');
      var patientID: number = +(this.patientId);
      var assessmentId: number = +(this.assessmentId);
      const basicRequest: any = {
        patientId: patientID,
        assessmentId: assessmentId
      }
      this.dashboardService.getDashboardPersonalBasicInfo(basicRequest).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          if (result.data != null) {
            this.isSelfRelationReadOnly = true;
            this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).disable();
            this.addMemberForm.get(['householdDemographicForm', 'maritalStatus']).disable();
            this.addMemberForm.get(['householdDemographicForm', 'gender']).disable();
            this.addMemberForm.get(['householdDemographicForm', 'ssn']).clearValidators();
            this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).clearValidators();
            this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
            this.ResetFormsOnChangingRelation();
            this.firstName = result.data.firstName;
            this.middleName = result.data.middleName;
            this.lastName = result.data.lastName;
            this.suffix = result.data.suffix;
            this.dateOfBirth = result.data.dateOfBirth;
            this.bsVal = new Date(this.dateOfBirth);
            this.maritalStatus = result.data.maritalStatus;
            this.gender = result.data.gender;
            this.ssn = result.data.ssnNumber;
            this.sssn = result.data.ssnNumber;
            this.ssnNumberValue = result.data.ssnNumberUnMasked;
            this.reasonNoSSN = result.data.reasonNoSsn;
          }
        }
      }, (error) => { console.log(error) });
    }
    else {
      if (this.isSelfRelationChanged == true) {
        if (this.incomeMap.size > 0 || this.resourceMap.size > 0) {
          this.toastService.showWarning(StringConstants.toast.changeSelf, StringConstants.toast.empty);
        }
        this.isSelfRelationChanged = false;
        this.isSelfRelationReadOnly = false;
        if (this.ssn != null && this.reasonNoSSN == null) {
          this.addMemberForm.get(['householdDemographicForm', 'ssn']).setValidators([Validators.required]);
          this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
          this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).clearValidators();
          this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
        }
        else if (this.ssn == null) {
          this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).setValidators([Validators.required]);
          this.addMemberForm.get(['householdDemographicForm', 'reasonNoSSN']).updateValueAndValidity();
          this.addMemberForm.get(['householdDemographicForm', 'ssn']).clearValidators();
          this.addMemberForm.get(['householdDemographicForm', 'ssn']).updateValueAndValidity();
        }
        this.ResetFormsOnChangingRelation();
        this.addMemberForm.get(['householdDemographicForm', 'maritalStatus']).enable();
        this.addMemberForm.get(['householdDemographicForm', 'gender']).enable();
        this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).enable();
        this.ssn = null;
        this.sssn = null;
        this.ssnNumberValue = null;
        this.gender = "";
        this.maritalStatus = "";
        this.reasonNoSSN = null;
      }
    }
  }
  ResetFormsOnChangingRelation() { // To reset form
    if (this.relation != 'Self') {
      this.addMemberForm.get('firstName').reset();
      this.addMemberForm.get('middleName').reset();
      this.addMemberForm.get('lastName').reset();
      this.addMemberForm.get('suffix').reset();
      this.addMemberForm.get(['householdDemographicForm', 'dateOfBirth']).reset();
      this.addMemberForm.get(['householdDemographicForm', 'maritalStatus']).reset();
      this.addMemberForm.get(['householdDemographicForm', 'gender']).reset();
    }
    this.addMemberForm.get('householdDemographicForm').controls['isDependent'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['isMedicalAid'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['isInsurance'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['payerName'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['groupName'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['groupNumber'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['policyNumber'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['effectiveFrom'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['termination'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['medicalId'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['medicalState'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['medicalEffectiveFrom'].reset();
    this.addMemberForm.get('householdDemographicForm').controls['medicalTermination'].reset();
    if (this.incomeMap.size > 0) {
      this.incomeResult = [];
      this.deletedincomeId = [];
      this.incomeMap.forEach((value: IncomeDetails, key: Number) => {
        this.deletedincomeId.push(value.incomeId);
      });
      this.incomeMap.clear();
    }
    if (this.resourceMap.size > 0) {
      this.resourceResult = [];
      this.deletedresourceId = [];
      this.resourceMap.forEach((value: ResourceDetails, key: Number) => {
        this.deletedresourceId.push(value.resourceId);
      });
      this.resourceMap.clear();
    }
  }
  openModel(householdMemberId: any) { //To open options in modal popup
    this.deleteHouseholdMemberId = householdMemberId;
  }
  validate(type: string) {
    var val;
    if (type == 'income')
      var temp = this.addMemberForm.get(['householdIncomeForm', 'grossPay']).value;
    else if (type == 'resource')
      var temp = this.addMemberForm.get(['householdResourceForm', 'resourceIncomeAmt']).value;
    let testRegex = /^[0-9]+([,.][0-9]+)?$/;
    var check = testRegex.test(temp);
    if (check == true) {
      val = Math.round(Number(temp) * 100) / 100;
      val = val.toString();
      if (type == "income")
        this.addMemberForm.controls["householdIncomeForm"].controls['grossPay'].setValue(val);
      else if (type == "resource")
        this.addMemberForm.controls["householdResourceForm"].controls['resourceIncomeAmt'].setValue(val);
    }
    else {
      if (type == "income")
        this.addMemberForm.controls["householdIncomeForm"].controls['grossPay'].setValue(temp);
      else if (type == "resource")
        this.addMemberForm.controls["householdResourceForm"].controls['resourceIncomeAmt'].setValue(temp);
    }
  }
  private ClearResourceValidations() {
    this.addMemberForm.get('householdResourceForm').controls['resourceType'].clearValidators();
    this.addMemberForm.get('householdResourceForm').controls['resourceType'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['resourceStatus'].clearValidators();
    this.addMemberForm.get('householdResourceForm').controls['resourceStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['resourceAcceptStatus'].clearValidators();
    this.addMemberForm.get('householdResourceForm').controls['resourceAcceptStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['resourceIncomeAmt'].clearValidators();
    this.addMemberForm.get('householdResourceForm').controls['resourceIncomeAmt'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['ownership'].clearValidators();
    this.addMemberForm.get('householdResourceForm').controls['ownership'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['locationName'].clearValidators();
    this.addMemberForm.get('householdResourceForm').controls['locationName'].updateValueAndValidity();
  }
  private ClearIncomeValidations() {
    this.addMemberForm.get('IncomeForm').controls['companyName'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['companyName'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['contactName'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['contactName'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['streetAddress'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['streetAddress'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['city'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['city'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['state'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['state'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['zipCode'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['zipCode'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['cellNumber'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['cellNumber'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['faxNumber'].clearValidators();
    this.addMemberForm.get('IncomeForm').controls['faxNumber'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['incomeType'].clearValidators();
    this.addMemberForm.get('householdIncomeForm').controls['incomeType'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['currentStatus'].clearValidators();
    this.addMemberForm.get('householdIncomeForm').controls['currentStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['acceptStatus'].clearValidators();
    this.addMemberForm.get('householdIncomeForm').controls['acceptStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['grossPay'].clearValidators();
    this.addMemberForm.get('householdIncomeForm').controls['grossPay'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['grossPayPeriod'].clearValidators();
    this.addMemberForm.get('householdIncomeForm').controls['grossPayPeriod'].updateValueAndValidity();
  }
  private AddResourceValidations() {
    this.addMemberForm.get('householdResourceForm').controls['resourceType'].setValidators([Validators.required]);
    this.addMemberForm.get('householdResourceForm').controls['resourceType'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['resourceStatus'].setValidators([Validators.required]);
    this.addMemberForm.get('householdResourceForm').controls['resourceStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['resourceAcceptStatus'].setValidators([Validators.required]);
    this.addMemberForm.get('householdResourceForm').controls['resourceAcceptStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['resourceIncomeAmt'].setValidators([Validators.required, Validators.pattern('^[0-9]+([,.][0-9]+)?$'), Validators.max(50000)]);
    this.addMemberForm.get('householdResourceForm').controls['resourceIncomeAmt'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['ownership'].setValidators([Validators.required, Validators.pattern('[0-9]{1,3}(\\.[0-9]{2})?'), Validators.max(100)]);
    this.addMemberForm.get('householdResourceForm').controls['ownership'].updateValueAndValidity();
    this.addMemberForm.get('householdResourceForm').controls['locationName'].setValidators([Validators.maxLength(50)]);
    this.addMemberForm.get('householdResourceForm').controls['locationName'].updateValueAndValidity();
  }
  private AddIncomeValidations() {
    this.addMemberForm.get('IncomeForm').controls['companyName'].setValidators([Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(3), Validators.maxLength(50)]);
    this.addMemberForm.get('IncomeForm').controls['companyName'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['contactName'].setValidators([Validators.pattern('^[a-zA-Z ]*$'), Validators.minLength(3), Validators.maxLength(50)]);
    this.addMemberForm.get('IncomeForm').controls['contactName'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['streetAddress'].setValidators([Validators.maxLength(250)]);
    this.addMemberForm.get('IncomeForm').controls['streetAddress'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['city'].setValidators([Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]);
    this.addMemberForm.get('IncomeForm').controls['city'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['state'].setValidators();
    this.addMemberForm.get('IncomeForm').controls['state'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['zipCode'].setValidators([Validators.pattern('^[0-9]+$'), Validators.minLength(5), Validators.maxLength(50)]);
    this.addMemberForm.get('IncomeForm').controls['zipCode'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['cellNumber'].setValidators([Validators.minLength(10)]);
    this.addMemberForm.get('IncomeForm').controls['cellNumber'].updateValueAndValidity();
    this.addMemberForm.get('IncomeForm').controls['faxNumber'].setValidators([Validators.minLength(10)]);
    this.addMemberForm.get('IncomeForm').controls['faxNumber'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['incomeType'].setValidators([Validators.required]);
    this.addMemberForm.get('householdIncomeForm').controls['incomeType'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['currentStatus'].setValidators([Validators.required]);
    this.addMemberForm.get('householdIncomeForm').controls['currentStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['acceptStatus'].setValidators([Validators.required]);
    this.addMemberForm.get('householdIncomeForm').controls['acceptStatus'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['grossPay'].setValidators([Validators.required, Validators.pattern('^[0-9]+([,.][0-9]+)?$'), Validators.max(50000)]);
    this.addMemberForm.get('householdIncomeForm').controls['grossPay'].updateValueAndValidity();
    this.addMemberForm.get('householdIncomeForm').controls['grossPayPeriod'].setValidators([Validators.required]);
    this.addMemberForm.get('householdIncomeForm').controls['grossPayPeriod'].updateValueAndValidity();
  }
  focusIn() { this.maskEnabled = false; }
  focusOut() { this.maskEnabled = true; }
}
export interface IncomeDetails {
  Id: any,
  incomeId: any,
  incomeType: any,
  currentStatus: any,
  verification: any,
  grossPay: any,
  grossPayPeriod: any,
  calculatedMonthlyIncome: any,
  companyName: any,
  contactName: any,
  streetAddress: any,
  city: any,
  state: any,
  stateCode: any,
  zipCode: any,
  cellNumber: any,
  fax: any,
  countyCode: any,
  houseHoldMemberId: any,
  emailAddress: any,
  assessmentId: any,
  contactDetailsId: any
}
export interface ResourceDetails {
  Id: any;
  resourceId: any;
  operationFlag: "true",
  resourceType: any;
  currentStatus: any;
  verification: any;
  currentMarketValue: any;
  ownership: any;
  calculatedValue: any;
  propertyLocation: any;
  HouseHoldMemberId: any;
  AssessmentId: any;
}



