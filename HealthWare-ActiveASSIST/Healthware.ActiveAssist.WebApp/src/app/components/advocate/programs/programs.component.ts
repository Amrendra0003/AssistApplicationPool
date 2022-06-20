import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
declare var $: any;
@Component({
  selector: 'app-programs',
  templateUrl: './programs.component.html',
  styleUrls: ['./programs.component.css']
})
export class ProgramsComponent implements OnInit {
  programsForm: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  programs: any;
  selectProgram: any;
  override: any;
  allPrograms: any;
  programName: any = true;
  checked: boolean = true;
  patient: any;
  currentTheme: any;
  programsTitle: string = StringConstants.programs.programsSuccessTitle;
  programsDescription: string = StringConstants.programs.programsSuccessDescription;
  programsMessageInfo: string = StringConstants.programs.programsSuccessMessageInforamtion;
  showDropdown: any;
  newprograms: any;
  addMore: any = [];
  allProgramsForm: any;
  enableSend: boolean = false;
  programList: any;
  tempArray: any = [];
  AddMorePrograms = StringConstants.DashboardHousehold.AddMorePrograms;
  NoProgramsAvailable = StringConstants.DashboardHousehold.NoProgramsAvailable;
  SelectPrograms = StringConstants.DashboardPrograms.SelectPrograms;
  Save = StringConstants.Common.Save;
  ProceedBySelf = StringConstants.Common.ProceedBySelf;
  AskForAssistance = StringConstants.Common.AskForAssistance;
  closeResult = '';
  constructor(private modalService: NgbModal, private quickAssessmentService: QuickAssessmentService, private dataSharingService: DataSharingService, private router: Router) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit(): void {
    this.dataSharingService.hideVaForProfile.next(false);
    this.initForm();
    this.createNewAssessment();
  }
  private initForm() {
    this.patient = sessionStorage.getItem("isPatient");
    this.programsForm = new FormGroup({
      'programName': new FormControl('true', [Validators.required]),
      'selectProgram': new FormControl(''),
    });

    this.allProgramsForm = new FormGroup({
      'programList': new FormControl(''),
    });
  }
  createNewAssessment() {
    var programs = sessionStorage.getItem('programNames');
    var newprograms = sessionStorage.getItem('allPrograms');
    this.override = sessionStorage.getItem('override');
    this.programs = programs?.split(',');

    if (this.override == 'true') {
      this.showDropdown = true;
      this.newprograms = newprograms?.split(',');
    }
  }
  changeProgram(val: string, index: any, event: any) {
    if (event.target.checked) {
      this.addMore[index] = val;
    }
    else {
      this.addMore[index] = null;
    }
    if (this.addMore.length == 0)
      this.showDropdown == true;
  }
  sendProgramList() {
    this.showDropdown = false;
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
  proceedBySelf() {
    this.resetTabStatus();
    let role = sessionStorage.getItem('role');
    sessionStorage.setItem('isEditable', "true");
    sessionStorage.setItem('statusDisplay', "Yet To Submit");
    this.tempArray = this.addMore;
    this.tempArray = this.addMore.filter((e: any) => e != null);
    this.checkProgram();
  }
  checkProgram() {
    if (this.tempArray == null) {
      this.router.navigate(['detail-assessment'], { queryParams: { tab: 0 } });
    }
    else {
      const reqBody: any = {
        assessmentId: +(sessionStorage.getItem('assessmentId')!),
        programNameList: this.tempArray,
        isEvaluated: false,
      }
      this.quickAssessmentService.createProgramMapping(reqBody).subscribe(async (result: any) => {
        if (result.wasSuccessful) {
          this.router.navigate(['detail-assessment'], { queryParams: { tab: 0 } });
        }
      }, (error) => {
        console.log(error)
      });
    }
  }
  askAssistance() {
    this.dataSharingService.askAssistanceHelp.next(true);
  }
}
export interface ProgramList {
  id: any;
}