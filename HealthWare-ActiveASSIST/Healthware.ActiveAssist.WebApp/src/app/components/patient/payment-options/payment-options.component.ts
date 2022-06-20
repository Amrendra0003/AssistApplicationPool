import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-payment-options',
  templateUrl: './payment-options.component.html',
  styleUrls: ['./payment-options.component.css']
})
export class PaymentOptionsComponent implements OnInit {
  paymentOptionsForm: any;
  virtualAssistPadding: string = "virtual-assist-padding";
  payment: any;
  paymentOptions: any;
  isEmailClickedBySelf: boolean = false;
  isTextClickedBySelf: boolean = false;
  isEmailClickedByCard: boolean = false;
  isTextClickedByCard: boolean = false;
  patientOptions: boolean = true;
  advocateOptions: boolean = false;
  toShowAlternatives: boolean = false;
  patient: any;
  isAdvocate: boolean = false;
  currentTheme: any;
  PaymentErrMsg1 = StringConstants.paymentOption.PaymentErrMsg1;
  PaymentErrMsg2 = StringConstants.paymentOption.PaymentErrMsg2;
  PaymentPlans = StringConstants.paymentOption.PaymentPlans;
  SmartCardInfo = StringConstants.paymentOption.SmartCardInfo;
  EmergencyAcuity = StringConstants.paymentOption.EmergencyAcuity;
  AlternativePaymentOptions = StringConstants.paymentOption.AlternativePaymentOptions;
  ShareViaText = StringConstants.paymentOption.ShareViaText;
  ShareViaEmail = StringConstants.paymentOption.ShareViaEmail;
  PaymentErrMsg3 = StringConstants.paymentOption.PaymentErrMsg3;
  constructor(private dataSharingService: DataSharingService, private router: Router, private authService: AuthService) {
    this.dataSharingService.alterPaddingForVA.subscribe(value => {
      this.virtualAssistPadding = value;
    });
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    if (this.router && !this.router.navigated)
      this.router.navigate(['']);
  }
  ngOnInit(): void {
    this.dataSharingService.hideVaForProfile.next(false);
    this.getPaymentOptions();
    this.initForm();
    let userHasAdvocatePermission = this.authService.checkIfUserHasPermission(StringConstants.permissionsConstants.viewComponentAssessmentSummary);
    if (userHasAdvocatePermission) {
      this.advocateOptions = true;
      this.patientOptions = false;
      this.isAdvocate = true;
    }
    else {
      this.patientOptions = true;
      this.advocateOptions = false;
      this.isAdvocate = false;
    }
  }
  private initForm() {
    this.patient = sessionStorage.getItem("isPatient");
    this.paymentOptionsForm = new FormGroup({
      'payment': new FormControl(''),
    });
  }
  OnSelectPaymentOptions(payment: any) {
    this.toShowAlternatives = true;
  }
  shareEmailBySelf() {
    this.isEmailClickedBySelf = true;
  }
  shareTextBySelf() {
    this.isTextClickedBySelf = true;
  }
  shareEmailByCard() {
    this.isEmailClickedByCard = true;
  }
  shareTextByCard() {
    this.isTextClickedByCard = true;
  }
  getPaymentOptions() {
    let data = [
      {
        "value": "Resuscitation",
        "name": "Resuscitation"
      },
      {
        "value": "Emergent",
        "name": "Emergent"
      },
      {
        "value": "Urgent",
        "name": "Urgent"
      },
      {
        "value": "Less Urgent",
        "name": "Urgent"
      },
      {
        "value": "Non Urgent",
        "name": "Urgent"
      }
    ]
    this.paymentOptions = data;
  }
}