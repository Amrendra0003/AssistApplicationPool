import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AdvocateDashboardService } from 'src/app/services/advocate-dashboard.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
declare var $: any;
@Component({
  selector: 'app-dashboard-programs',
  templateUrl: './dashboard-programs.component.html',
  styleUrls: ['./dashboard-programs.component.css']
})
export class DashboardProgramsComponent implements OnInit {
  panelOpenStateVeterans = true;
  panelOpenStateMemorial = false;
  panelOpenStateCrime = false;
  patientId: any;
  assessmentId: any;
  result: ActiveProgramsResponse[] = {} as ActiveProgramsResponse[];
  activeReviewProgramDetails: ActiveProgramsResponse[] = {} as ActiveProgramsResponse[];
  quickAssessmentForm: any;
  programData: any = {};
  programs = new Map<any, any>();
  allprogramsIdList: number[] = [];
  allprogramsIsActiveList: ProgramsUpdateDto[] = [];
  selectedprogramsIdList: number[] = [];
  ProgramsUpdateDetails: ProgramsUpdateDto[] = [];
  isEditAllowed: any;
  assessmentStatus: any;
  isProgramSaved: string = "";
  showLoader: boolean = false;
  isAdvocate: boolean = false;
  programsInfoFlag: boolean = true;
  reviewNotesFlag: boolean = false;
  programsForm: any;
  reviewNotesForm: any;
  reviewNotes: any = "";
  showBenefits: boolean = false;
  programOptions: any = {};
  programsId: any = [];
  appliedPrograms: any;
  reviewNote: any;
  currentTheme: any;
  showReviewNotes: string = "";
  morePrograms: any;
  addMore: any = [];
  addMoreProgramForm: any;
  programForm: any;
  toShowEmptyRecords: boolean = false;
  enableAddProgram: boolean = false;
  DashboardProgramsInfo1 = StringConstants.DashboardPrograms.DashboardProgramsInfo1;
  DashboardProgramsInfo2 = StringConstants.DashboardPrograms.DashboardProgramsInfo2;
  Programs = StringConstants.DashboardPrograms.Programs;
  ReviewNotes1 = StringConstants.DashboardPrograms.ReviewNotes;
  ApplicationSubmitted = StringConstants.var.ApplicationSubmitted;
  AddMorePrograms = StringConstants.DashboardHousehold.AddMorePrograms;
  SelectPrograms = StringConstants.DashboardPrograms.SelectPrograms;
  NoProgramsAvailable = StringConstants.DashboardHousehold.NoProgramsAvailable;
  Cancel = StringConstants.Common.Cancel;
  Next = StringConstants.common.nextLabel;
  proStatus: any = [];
  flagval: boolean = false;
  @Input() set currentTabUpdate(value: boolean) { //Get current tab status
    this.allprogramsIdList = [];
    this.selectedprogramsIdList = [];
    this.ProgramsUpdateDetails = [];
    this.programs.clear;
    this.dataSharing.ShowProgramsTab.next("5");
    this.programsInfo();
    this.getMorePrograms();
    this.getTabStatus();
  }
  constructor(private toastService: ToastServiceService, private dataSharingService: DataSharingService, private advocateService: AdvocateDashboardService,
    private dashboardService: DashboardService, private router: Router, private formbuilder: FormBuilder, private dataSharing: DataSharingService) {
    this.dataSharingService.changeTheme.subscribe(value => { // Theme settings
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharing.editable.subscribe(value => { //Assessment status
      this.isEditAllowed = value;
    });
  }
  ngOnInit() {
    this.patientId = sessionStorage.getItem('patientId');
    this.assessmentId = +(sessionStorage.getItem('assessmentId')!);
    let role = sessionStorage.getItem('role');
    switch (role) {
      case StringConstants.var.PATIENT:
        this.isAdvocate = false;
        break;
      case StringConstants.var.ADVOCATE:
        this.isAdvocate = true;
        break;
      default: {
        break;
      }
    }
    this.initForm();
  }
  private initForm() {
    this.reviewNotesForm = new FormGroup({
      'reviewNotes': new FormControl('', [Validators.minLength(1), Validators.maxLength(150)]),
    });
    this.addMoreProgramForm = new FormGroup({
      'programList': new FormControl('')
    });
    this.programForm = new FormGroup({
      'programStatus': new FormControl('')
    })
  }
  programsInfo() { //Programs tab
    window.scroll(0, 0);
    this.programsInfoFlag = true;
    this.reviewNotesFlag = false;
    this.UpdateFields();
    this.showReviewNotes = "false";
  }
  ReviewNotes() { // Review tab
    window.scroll(0, 0);
    this.programsInfoFlag = false;
    this.reviewNotesFlag = true;
    this.showReviewNotes = "";
    this.reviewNotes = "";
    this.getReviewNotes();
  }
  async getAllReviewPrograms() { //Get all review programs
    console.log("hello");
    this.showLoader = true;
    var patientID: number = +(sessionStorage.getItem('patientId')!);
    var assessmentId: number = +(sessionStorage.getItem('assessmentId')!);
    const reviewRequest: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.GetAllReviewPrograms(reviewRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.result = result.data.reviewPrograms;
        for (var val of this.result) {
          this.allprogramsIdList.push(val.programId);
        }
        this.UpdateFields();
        this.getMorePrograms();
        this.showLoader = false;
      }
    }, (error) => {
      console.log(error)
    });
  }
  getMorePrograms() { // Get more programs
    
    var val: ProgramIdList[] = [];
    var count = 0;
    for (var value of this.allprogramsIdList) {
      let data: ProgramIdList = {
        id: value,
      };
      val.push(data);
    }
    let currentProgramList: currentProgramList = {
      programIdList: val
    };
    
    this.advocateService.addMorePrograms(currentProgramList)
      .subscribe(async (result: any) => {
        this.morePrograms = result.data;
        for (let data in this.morePrograms) {
          count++;
        }
        if (count == 0) {
          this.toShowEmptyRecords = true;
        }
        else {
          this.toShowEmptyRecords = false;
        }
      }, (error) => {
        console.log(error)
      });
  }
  onCheckboxChange(e: any) { // Checkbox event
    if (e.target.checked) {
      let data: ProgramIdList = {
        id: +(e.target.id),
      };
      this.addMore.push(data);
    } else {
      const index = this.addMore.findIndex((x: { id: number; }) => x.id === parseInt(e.target.id));
      this.addMore.splice(index, 1);
    }
    if (this.addMore.length > 0)
      this.enableAddProgram = true;
    else
      this.enableAddProgram = false;
  }
  applyPrograms(event: any, id: any) { // Apply programs
    this.programData[id] = event.value;
  }
  goToReviewNotes() { //  Save applied programs
    sessionStorage.removeItem('appliedProgrmas');
    var count: number = 0;
    this.programs.clear;
    for (var val of this.result) {
      this.programs.set(val.programId, this.programData[val.programId]);
    }
    this.assessmentId = +(sessionStorage.getItem('assessmentId')!);
    this.patientId = +(sessionStorage.getItem('patientId')!);
    this.programs.forEach((value: string, key: number) => {
      var programInfo = this.result.find(program => program.programId == key);
      var applicationStatus
      if (programInfo)
        applicationStatus = programInfo.status;
      var data: ProgramsUpdateDto = {
        patientId: this.patientId,
        assessmentId: this.assessmentId,
        programId: key,
        isActive: value.toLowerCase() == 'true',
        isEvaluated: true
      }
      if (value == 'true' && applicationStatus == null) {
        count++;
        this.ProgramsUpdateDetails.push(data);
      }
    });
    sessionStorage.setItem('appliedProgrmas', JSON.stringify(this.ProgramsUpdateDetails));
    if (count == 0 && this.result.filter(e => e.status == StringConstants.var.ApplicationSubmitted).length <= 0) {
      this.toastService.showWarning(StringConstants.toast.applyPrograms, StringConstants.toast.empty);
    }
    else {
      this.ReviewNotes();
    }
  }
  async UpdateFields() { //Update review programs
    var patientID: number = +(sessionStorage.getItem('patientId')!);
    var assessmentId: number = +(sessionStorage.getItem('assessmentId')!);
    const request: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.GetEvaluatedReviewPrograms(request).subscribe(async (result: any) => {
      
      console.log(result.data);
      if (result.wasSuccessful) {
        this.selectedprogramsIdList = [];
        this.result = result.data.reviewPrograms;
        if (this.result.length > 0) {
          this.flagval = true;
        }
        for (var val of this.result) {
          this.allprogramsIdList.push(val.programId);
          this.programData[val.programId] = (val.isActive).toString();
        }
        this.getMorePrograms();
        this.showLoader = false;
        for (var val of this.result) {
          this.selectedprogramsIdList.push(val.programId);
        }
        for (var i of this.allprogramsIdList) {
          var count: number = 0;
          for (var k of this.selectedprogramsIdList) {
            if (i == k) count++;
            this.programData[i] = this.allprogramsIsActiveList[i].toString();
          }
        }
      }
    },
      (err) => {
        console.log(StringConstants.toast.error, err);
      }, () => {
      })
  }
  clearPrograms() { // Clear programs
    this.addMore.length = 0;
    this.addMoreProgramForm.reset();
  }
  toShowBenefits(programId: any) { // Show benefits
    this.programOptions[programId] = !this.programOptions[programId];
  }
  toShowForms(programId: any) { //Show forms
    this.dataSharingService.sendProgramID.next(programId);
    this.dataSharingService.ShowFormsTab.next("6");
  }
  toShowVerification() { //go to verification tab
    this.dataSharingService.ShowVerificationTab.next("7");
  }
  getTabStatus() { //get current tab status
    var assessmentId: number = +(sessionStorage.getItem('assessmentId')!);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        if (result.data.isProgramsComplete)
          this.dataSharing.SavePrograms.next('true');
      }
    }, (error) => {
      console.log(error)
    });
  }
  backToDashboard() { // Back to dashboard
    this.router.navigate(['dashboard']);
  }
  submitAssessment(notes: any) { // Submit review notes
    var updateCount: number = 0;
    var assessmentId: number = +(this.assessmentId);
    var userId: number = +(sessionStorage.getItem('userId')!);
    sessionStorage.getItem('appliedProgrmas');
    this.programs.clear;
    this.ProgramsUpdateDetails = [];
    for (var value1 of this.result) {
      this.programs.set(value1.programId, this.programData[value1.programId]);
      this.proStatus[value1.programId] = value1.status;
    }
    this.programs.forEach((value: string, key: number) => {
      var data: ProgramsUpdateDto = {
        patientId: +(this.patientId),
        assessmentId: +(this.assessmentId),
        programId: key,
        isActive: value.toLowerCase() == 'true',
        isEvaluated: true
      }
      if (value == 'true') {
        updateCount++;
      }
      this.ProgramsUpdateDetails.push(data);
    });
    this.appliedPrograms = (JSON.parse(sessionStorage.getItem('appliedProgrmas')!));
    this.programsId = [];
    for (var val of this.appliedPrograms) {
      if (val.isActive == true && this.proStatus[val.programId] == null) {
        const data: any = {
          id: val.programId
        }
        this.programsId.push(data);
      }
    }
    const reviewNotes = {
      reviewNotes: [
        notes.reviewNotes
      ],
      userId: userId,
      assessmentId: assessmentId,
      programIdList: this.programsId,
      updateReviewProgramRequest: this.ProgramsUpdateDetails
    }
    this.advocateService.addReviewNotes(reviewNotes).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.allprogramsIdList = [];
        this.selectedprogramsIdList = [];
        this.ProgramsUpdateDetails = [];
        this.savePrograms();
        this.programsInfo();
        this.getTabStatus();
      }
    })
  }
  reviewNotesArea() { //Review notes field
    this.showReviewNotes = "true";
  }
  getReviewNotes() { //Get review notes
    this.showLoader = true;
    var assessmentId: number = +(this.assessmentId);
    var userId: number = +(sessionStorage.getItem('userId')!);
    const reviewNotes: any = {
      userId: userId,
      assessmentId: assessmentId
    }
    this.advocateService.getReviewNotes(reviewNotes).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        if (result.data.length > 0) {
          this.showReviewNotes = "false";
          this.reviewNote = result.data;
        }
        else if (result.data.length == 0) {
          this.showReviewNotes = "true";
        }
        this.showLoader = false;
      }
    }, (error) => {
      console.log(error)
    });
  }
  savePrograms() { // To save and update programs
    var count: number = 0;
    this.programs.clear;
    for (var val of this.result) {
      this.programs.set(val.programId, this.programData[val.programId]);
    }
    this.assessmentId = +(sessionStorage.getItem('assessmentId')!);
    this.patientId = +(sessionStorage.getItem('patientId')!);
    this.ProgramsUpdateDetails.length = 0;
    this.programs.forEach((value: string, key: number) => {
      var data: ProgramsUpdateDto = {
        patientId: this.patientId,
        assessmentId: this.assessmentId,
        programId: key,
        isActive: value.toLowerCase() == 'true',
        isEvaluated: true
      }
      if (value == 'true') {
        count++;
      }
      this.ProgramsUpdateDetails.push(data);
    });
    this.dashboardService.UpdatePatientReviewPrograms(this.ProgramsUpdateDetails)
      .subscribe(async (result: any) => {
      }, (error) => {
        console.log(error)
      });
  }
  applyMorePrograms() { // Apply more programs
    var updateCount: number = 0;
    var patientID: number = +(sessionStorage.getItem('patientId')!);
    var assessmentId: number = +(sessionStorage.getItem('assessmentId')!);
    this.programs.clear;
    this.ProgramsUpdateDetails = [];
    for (var val of this.result) {
      this.programs.set(val.programId, this.programData[val.programId]);
    }
    this.programs.forEach((value: string, key: number) => {
      var data: ProgramsUpdateDto = {
        patientId: +(this.patientId),
        assessmentId: +(this.assessmentId),
        programId: key,
        isActive: value.toLowerCase() == 'true',
        isEvaluated: true
      }
      if (value == 'true') {
        updateCount++;
      }
      this.ProgramsUpdateDetails.push(data);
    });
    const updatePrograms: any = {
      patientId: patientID,
      assessmentId: assessmentId,
      programIdList: this.addMore,
      updateReviewProgramRequest: this.ProgramsUpdateDetails,
      isEvaluated: true
    }
    this.advocateService.updateQuickAssessmentResult(updatePrograms).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        $("#openMorePrograms").modal("hide");
        this.UpdateFields();
        this.allprogramsIdList = [];
        this.selectedprogramsIdList = [];
        this.ProgramsUpdateDetails = [];
      }
    }, (error) => {
      console.log(error)
    });
  }
}
export interface ActiveProgramsResponse {
  programId: number;
  programName: string;
  benefits: string;
  status: string;
  isActive: any;
}
export interface ProgramsUpdateDto {
  patientId: number;
  assessmentId: number;
  programId: number;
  isActive: any;
  isEvaluated: boolean;
}
export interface ProgramIdList {
  id: any;
}
export interface currentProgramList {
  programIdList: ProgramIdList[];
}
