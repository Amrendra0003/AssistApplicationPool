import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AdvocateDashboardService } from 'src/app/services/advocate-dashboard.service';
import { AuthService } from 'src/app/services/auth.service';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
declare var $: any;
@Component({
  selector: 'app-dashboard-quick-assessment',
  templateUrl: './dashboard-quick-assessment.component.html',
  styleUrls: ['./dashboard-quick-assessment.component.css']
})
export class DashboardQuickAssessmentComponent implements OnInit {
  panelOpenStateVeterans = true;
  panelOpenStateMemorial = false;
  panelOpenStateCrime = false;
  patientId: any;
  assessmentId: any;
  result: ActiveProgramsResponse[] = [] as ActiveProgramsResponse[];
  activeReviewProgramDetails: ActiveProgramsResponse[] = {} as ActiveProgramsResponse[];
  quickAssessmentForm: any;
  programData: any = {};
  programs = new Map<number, string>();
  allprogramsIdList: number[] = [];
  unappliedprogramsIdList: number[] = [];
  selectedprogramsIdList: number[] = [];
  ProgramsUpdateDetails: ProgramsUpdateDto[] = [];
  isEditAllowed: any;
  isQuickSaved: string = "";
  showLoader: boolean = false;
  isAdvocate: boolean = false;
  addMoreProgramsDetails: any = [];
  morePrograms: any;
  enableAddProgram: boolean = false;
  applicationSubmissionStatus = StringConstants.var.ApplicationSubmitted;
  formsEnabled: boolean = false;
  DashboardQuickAssessmentinfo1 = StringConstants.DashboardQuickAssessment.DashboardQuickAssessmentinfo1;
  DashboardQuickAssessmentinfo2 = StringConstants.DashboardQuickAssessment.DashboardQuickAssessmentinfo2;
  DashboardQuickAssessmentinfo3 = StringConstants.DashboardQuickAssessment.DashboardQuickAssessmentinfo3;
  DashboardQuickAssessmentinfo4 = StringConstants.DashboardQuickAssessment.DashboardQuickAssessmentinfo4;
  ReviewProgram = StringConstants.DashboardQuickAssessment.ReviewProgram;
  No = StringConstants.Common.No;
  Apply = StringConstants.common.apply;
  Benefits = StringConstants.Common.Benefits;
  AddMorePrograms = StringConstants.DashboardHousehold.AddMorePrograms;
  SelectPrograms = StringConstants.DashboardPrograms.SelectPrograms;
  NoProgramsAvailable = StringConstants.DashboardHousehold.NoProgramsAvailable;
  Next = StringConstants.common.nextLabel;
  @Input() set currentTabUpdate(value: boolean) {
    this.getAllReviewPrograms();
    this.allprogramsIdList = [];
    this.selectedprogramsIdList = [];
    this.ProgramsUpdateDetails = [];
    this.programs.clear;
    this.dataSharing.showQuickAssessmentResultsTab.next("0");
    this.getTabStatus();
  }
  currentTheme: any;
  addMoreProgramForm: any;
  addMore: any = [];
  toShowEmptyRecords: boolean = false;
  constructor(private toastService: ToastServiceService, private formBuilder: FormBuilder, private dashboardService: DashboardService,
    private advocateService: AdvocateDashboardService, private router: Router, private formbuilder: FormBuilder, private dataSharing: DataSharingService,
    private authService: AuthService) {
      
    this.dataSharing.changeTheme.subscribe((value:any) => { //Theme setting
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharing.editable.subscribe((value:any) => { // Assessment status
      this.isEditAllowed = value;
    })
  }
  ngOnInit() {
    this.initForm();
    this.patientId = +(sessionStorage.getItem('patientId')!);
    this.assessmentId = +(sessionStorage.getItem('assessmentId')!);
    this.isAdvocate = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
    this.getTabStatus();
  }
  private initForm() {
    this.addMoreProgramForm = new FormGroup({
      'programList': new FormControl(''),
    });
  }
  getAllReviewPrograms() { // Get all review programs
    this.showLoader = true;
    var patientID: number = +(sessionStorage.getItem('patientId')!);
    var assessmentId: number = +(sessionStorage.getItem('assessmentId')!);
    const reviewRequest: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.GetAllReviewPrograms(reviewRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.showLoader = false;
        this.result = result.data.reviewPrograms;
        if (this.isAdvocate == true) {
          let unappliedprograms = this.result.filter(e => e.status == null || e.status == this.applicationSubmissionStatus)
          
          this.result = this.result.filter(e => e.status == null);
          for (var val of unappliedprograms) {
            this.unappliedprogramsIdList.push(val.programId);
          }
        }
        for (var val of this.result) {
          this.allprogramsIdList.push(val.programId);
        }
        this.UpdateFields();
        if (this.isAdvocate == true) {
          this.getMorePrograms();
        }
      }
    }, (error) => {
      console.log(error)
    });
  }
  getTabStatus() { //Get current tab status
    var assessmentId = +(sessionStorage.getItem('assessmentId')!);
    const tabRequest = {
      assessmentID: assessmentId,
      tabStatus: false
    }
    this.dashboardService.TabStatus(tabRequest).subscribe(async (result: any) => {
      if (result.wasSuccessful == true) {
        this.formsEnabled = result.data.isApplicationFormEnabled;
      }
    }, (error) => {
      console.log(error)
    });
  }
  getMorePrograms() { //Get more programs
    
    var count = 0;
    var val: ProgramIdList[] = [];
    for (var value of this.result) {
      let data: ProgramIdList = {
        id: value.programId,
      };
      val.push(data);
    }
    let currentProgramList: currentProgramList = {
      programIdList: val
    };
    this.advocateService.addMorePrograms(currentProgramList)
      .subscribe(async (result: any) => {
        
        this.morePrograms = result.data;
        for (let data in this.morePrograms?.length) {
          count++;
          if (count == 0)
            this.toShowEmptyRecords = true;
          else
            this.toShowEmptyRecords = false;
        }
      }, (error) => {
        console.log(error)
      });
  }
  onCheckboxChange(e: any) { //Checkbox onChange event
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
  clearPrograms() { // Clear program list
    this.addMore.length = 0;
    this.addMoreProgramForm.reset();
  }
  applyMorePrograms() { //Apply more programs
    var updateCount: number = 0;
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
      }
      if (value == 'true') {
        updateCount++;
      }
      this.ProgramsUpdateDetails.push(data);
    });
    const updatePrograms: any = {
      assessmentId: assessmentId,
      programIdList: this.addMore,
      updateReviewProgramRequest: this.ProgramsUpdateDetails
    }
    this.advocateService.updateQuickAssessmentResult(updatePrograms).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        $("#openMorePrograms").modal("hide");
        this.getAllReviewPrograms();
        this.allprogramsIdList = [];
        this.selectedprogramsIdList = [];
        this.ProgramsUpdateDetails = [];
      }
    }, (error) => {
      console.log(error)
    });
  }
  UpdateFields() { //Update program list
    var patientID: number = +(sessionStorage.getItem('patientId')!);
    var assessmentId: number = +(sessionStorage.getItem('assessmentId')!);
    const request: any = {
      patientId: patientID,
      assessmentId: assessmentId
    }
    this.dashboardService.GetNotEvaluatedActiveReviewPrograms(request).subscribe(async (result: any) => {
      if (result.wasSuccessful) {
        this.activeReviewProgramDetails = result.data.reviewPrograms;
        for (var val of this.activeReviewProgramDetails) {
          this.selectedprogramsIdList.push(val.programId);
        }
        for (var i of this.allprogramsIdList) {
          var count: number = 0;
          for (var k of this.selectedprogramsIdList) {
            if (i == k) count++;
          }
          if (count == 0)
            this.programData[i] = "false";
          else
            this.programData[i] = "true";
        }
      }
    },
      (err) => {
        console.log(StringConstants.toast.error, err);
      }, () => {
      })
  }
  backToDashboard() { //Back to dashboard
    if (this.isAdvocate) {
      this.router.navigate(['dashboard-advocate']);
    }
    else {
      this.router.navigate(['dashboard']);
    }
  }
  savePrograms() { //Update programs
    var count: number = 0;
    this.programs.clear;
    for (var val of this.result) {
      this.programs.set(val.programId, this.programData[val.programId]);
    }
    this.assessmentId = +(sessionStorage.getItem('assessmentId')!);
    this.patientId = +(sessionStorage.getItem('patientId')!);
    this.programs.forEach((value: string, key: number) => {
      var data: ProgramsUpdateDto = {
        patientId: this.patientId,
        assessmentId: this.assessmentId,
        programId: key,
        isActive: value.toLowerCase() == 'true',
      }
      if (value == 'true') {
        count++;
      }
      this.ProgramsUpdateDetails.push(data);
    });
    if (count == 0) {
      this.toastService.showWarning(StringConstants.toast.applyPrograms, StringConstants.toast.empty);
      this.dataSharing.SaveQuickAssessment.next("false");
    }
    else {
      this.dashboardService.UpdatePatientReviewPrograms(this.ProgramsUpdateDetails)
        .subscribe(async (result: any) => {
          this.dataSharing.showPersonalTab.next("1");
          this.dataSharing.SaveQuickAssessment.next("true");
        }, (error) => {
          console.log(error)
        });
    }
  }
}
export interface ActiveProgramsResponse {
  programId: number;
  programName: string;
  benefits: string;
  status: string;
}
export interface ProgramsUpdateDto {
  patientId: number;
  assessmentId: number;
  programId: number;
  isActive: boolean;
}
export interface ProgramIdList {
  id: any;
}
export interface currentProgramList {
  programIdList: ProgramIdList[];
}
