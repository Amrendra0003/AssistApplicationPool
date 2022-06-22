import { Component, Input, OnInit, ViewChild, AfterViewInit, Output, EventEmitter } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { CommonService } from 'src/app/services/common.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AddressVerificationComponent } from '../../address-verification/address-verification.component';
@Component({
  selector: 'app-dashboard-home-address',
  templateUrl: './dashboard-home-address.component.html',
  styleUrls: ['./dashboard-home-address.component.css']
})
export class DashboardHomeAddressComponent implements OnInit {
  addressID: any;
  homeAddressFlag: any;
  basicInfoFlag: any;
  homeAddressForm: any;
  workAddressFlag: any;
  patientId: any;
  assessmentId: any;
  guarantorId: any;
  relation: any;
  homeSuite: any;
  homeCity: any;
  homeState: string = "";
  homePincode: any;
  homeCellNumber: any;
  homeStreetName: any;
  hometown: any;
  data: any;
  entityType: any;
  entityId: any;
  addressId: any;
  isGuarantor: any;
  countyCode: any;
  isEditAllowed: any;
  assessmentStatus: any;
  currentTheme: any;
  contactTypeId: any;
  homeStateCode: any;
  HomeAddress = StringConstants.profileSetting.HomeAddress;
  StreetAddressReg = StringConstants.profileSetting.StreetAddressReg;
  StreetAddressMax = StringConstants.profileSetting.StreetAddressMax;
  SuiteReq = StringConstants.profileSetting.SuiteReq;
  SuiteMax = StringConstants.profileSetting.SuiteMax;
  ZipReq = StringConstants.demographics.ZipReq;
  ZipNum = StringConstants.demographics.ZipNum;
  ZipVal = StringConstants.demographics.ZipVal;
  ZipMin = StringConstants.demographics.ZipMin;
  ZipMax = StringConstants.demographics.ZipMax;
  CountyReq = StringConstants.profileSetting.CountyReq;
  CountyAlp = StringConstants.profileSetting.CountyAlp;
  CountyMax = StringConstants.profileSetting.CountyMax;
  CityReq = StringConstants.demographics.CityReq;
  CityAlp = StringConstants.demographics.CityAlp;
  CityMax = StringConstants.demographics.CityMax;
  StateAlp = StringConstants.profileSetting.StateAlp;
  StateReq = StringConstants.demographics.StateReq;
  home = StringConstants.common.home;
  ValidHomeNum = StringConstants.profileSetting.ValidHomeNum;
  @Output() nextButtonClicked: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() backToPersonal: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() backToGuarantor: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Input() homeStreetAddress: any;
  @Input() suite: any;
  @Input() city: any;
  @Input() country: any;
  @Input() homeNo: any;
  @Input() state: any;
  @Input() pincode: any;
  @Input() homedata: any;
  @Input() homeEntityType: any;
  @Input() homeTown: any;
  @Input() homeAddressId: any;
  @Input() homeGuarantor: any;
  @Input() homeCountyCode: any;
  @Input() stateCode: any;
  guarantorVal: any;
  result: any;
  phoneCode: any;
  constructor(public modalService: BsModalService, private modalRef: BsModalRef, private quickAssessmentService: QuickAssessmentService, private dashboardService: DashboardService, private router: Router, private toastService: ToastServiceService,
    private route: ActivatedRoute, private dataSharingService: DataSharingService, private formbuilder: FormBuilder, private common: CommonService) {
    this.dataSharingService.changeTheme.subscribe(value => { // Theme Settings
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharingService.editable.subscribe(value => { // Check assessment status
      this.isEditAllowed = value;
    });
    this.dataSharingService.isGuarantorData.subscribe(value => { //Check guarantor details
      this.guarantorVal = value;
    })
  }
  ngOnInit() {
    var countyCodeData = ""
    if (this.homeCountyCode == null) countyCodeData = "1";
    else countyCodeData = this.homeCountyCode;
    this.initForm();
    this.patientId = sessionStorage.getItem('patientId');
    this.assessmentId = sessionStorage.getItem('assessmentId');
    this.guarantorId = sessionStorage.getItem('guarantorId');
    this.relation = sessionStorage.getItem('relation');
    this.homeStreetName = this.homeStreetAddress;
    this.homeSuite = this.suite;
    this.homeCity = this.city;
    this.homeState = this.state;
    this.homeStateCode = this.stateCode;
    this.homePincode = this.pincode;
    this.homeCellNumber = this.homeNo;
    this.data = this.homedata;
    this.entityType = this.homeEntityType;
    this.hometown = this.homeTown;
    this.addressId = this.homeAddressId;
    this.isGuarantor = this.homeGuarantor;
    this.countyCode = countyCodeData;
    this.getPhoneCode();
    let isguarantor = (/true/i).test(sessionStorage.getItem('isGuarantor')!)
    if (this.homeEntityType === StringConstants.var.guarantor && this.relation == StringConstants.var.self) { // Check Address type 
      this.homeAddressForm.get('homeSuite').disable();
      this.homeAddressForm.get('hometown').disable();
      this.homeAddressForm.get('homeCity').disable();
      this.homeAddressForm.get('homeState').disable();
      this.homeAddressForm.get('homePincode').disable();
      this.homeAddressForm.get('homeStreetName').disable();
      this.homeAddressForm.get('homeCellNumber').disable();
      this.homeAddressForm.get('countyCode').disable();
    }
    else if (this.homeEntityType === StringConstants.var.guarantor && this.relation != StringConstants.var.self) {// Check Address type
      this.homeAddressForm.get('homeSuite').enable();
      this.homeAddressForm.get('hometown').enable();
      this.homeAddressForm.get('homeCity').enable();
      this.homeAddressForm.get('homeState').enable();
      this.homeAddressForm.get('homePincode').enable();
      this.homeAddressForm.get('homeStreetName').enable();
      this.homeAddressForm.get('homeCellNumber').enable();
      this.homeAddressForm.get('countyCode').enable();
    }
  }
  private initForm() {
    this.homeAddressForm = new FormGroup({
      'homeSuite': new FormControl('', [Validators.maxLength(250)]),
      'hometown': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'homeCity': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'homeState': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]),
      'homePincode': new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$'), Validators.minLength(5), Validators.maxLength(50)]),
      'homeCellNumber': new FormControl('', [Validators.minLength(10), Validators.maxLength(25)]),
      'homeStreetName': new FormControl('', [Validators.required, Validators.maxLength(250)]),
      'countyCode': new FormControl('',),
      'homeStateCode': new FormControl('',),
      'data': new FormControl(''),
    });
  }
  async getStateAndCity() { // To get state and city details from api
    
    const val = this.homeAddressForm.get('homePincode').value;
    if (val.length >= 5) {
      this.result = await this.common.getStateAndCity(val);
      if (this.result.wasSuccessful == true) {
        if (this.result.data != null) {
          this.homeCity = this.result.data.city;
          this.homeState = this.result.data.stateCode;
          this.homeStateCode = this.result.data.stateCode;
          this.homeAddressForm.controls['homePincode'].setErrors(null);
        }
        else {
          this.homeCity = "";
          this.homeState = "";
          this.homeStateCode = "";
          this.homeAddressForm.controls['homePincode'].setErrors({ 'invalid': true });
        }
      }
      else if (this.result.wasSuccessful == false) {
      }
    }
    else {
      this.homeCity = "";
      this.homeState = "";
      this.hometown = "";
      this.homeStateCode = "";
    }
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  GoToInfo() { // To go back personal or guarantor tab
    if (this.homeEntityType === StringConstants.var.patient) {
      this.backToPersonal.emit(true);
    }
    else if (this.homeEntityType === StringConstants.var.guarantor) {
      this.backToGuarantor.emit(true);
    }
  }
  updateAddress(){
    this.homeAddressForm.markAsPristine();
    this.homeAddressFlag = false;
    this.basicInfoFlag = false;
    this.workAddressFlag = true;
    if (this.homeEntityType === StringConstants.var.patient) {
      this.dataSharingService.SavePersonalHome.next("true");
      this.dataSharingService.SavePersonal.next("true");
    }
    else if (this.homeEntityType === StringConstants.var.guarantor) {
      this.dataSharingService.SaveGuarantorHome.next("true");
      this.dataSharingService.SaveGuarantor.next("true");
    }
    if (this.guarantorVal == 'true') {
      this.dataSharingService.SaveGuarantor.next('true');
    }
    this.nextButtonClicked.emit(true);
  }
  insertAddress(){
    this.homeAddressForm.markAsPristine();
    this.homeAddressFlag = false;
    this.basicInfoFlag = false;
    this.workAddressFlag = true;
    if (this.homeEntityType === StringConstants.var.patient) {
      this.dataSharingService.SavePersonalHome.next("true");
      this.dataSharingService.SavePersonal.next("true");
    }
    else if (this.homeEntityType === StringConstants.var.guarantor) {
      this.dataSharingService.SaveGuarantorHome.next("true");
      this.dataSharingService.SaveGuarantor.next("true");
    }
    this.nextButtonClicked.emit(true);
  }
  homeAddressNext(homeAddressInfo: any) { // Save home address details
    
    if (this.homeAddressForm.dirty) {
      if (this.relation == StringConstants.var.self && this.homeEntityType === StringConstants.var.guarantor) {
        this.nextButtonClicked.emit(true);
      }
      else {
        if (!this.homeAddressForm.valid) {
          this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
          if (this.homeEntityType === StringConstants.var.patient) {
            this.dataSharingService.SavePersonalHome.next("false");
            this.dataSharingService.SavePersonal.next("false");
          }
          else if (this.homeEntityType === StringConstants.var.guarantor) {
            this.dataSharingService.SaveGuarantorHome.next("false");
            this.dataSharingService.SaveGuarantor.next("false");
          }
        }
        else {
          var patientID: number = +(this.patientId);
          var guarantorID: number = +(this.guarantorId);
          var addressId: number = +(this.addressId);
          var postalCode: number = +(homeAddressInfo.homePincode);
          var assessmentId: number = +(this.assessmentId);
          if (this.homeEntityType === StringConstants.var.patient) {
            this.entityId = patientID;
            this.addressID = sessionStorage.getItem('addressID');
            this.contactTypeId = 2;
          }
          else if (this.homeEntityType === StringConstants.var.guarantor) {
            this.entityId = guarantorID;
            this.addressID = sessionStorage.getItem('guarantorAddressID');
            this.contactTypeId = 5;
          }
          if ((this.data === undefined || this.data === '') && this.homeEntityType === StringConstants.var.guarantor) {
            //Add new address details
            var guarantorFlag: number = JSON.parse(this.homeGuarantor);
            const addressData = {
              name: "",
              entityId: this.entityId,
              entityType: this.homeEntityType,
              addressType: StringConstants.var.homeAddress,
              contactTypeId: this.contactTypeId,
              contactDetailsId: 0,
              assessmentId: assessmentId,
              streetAddress: homeAddressInfo.homeStreetName,
              suite: homeAddressInfo.homeSuite,
              city: homeAddressInfo.homeCity,
              state: homeAddressInfo.homeState,
              stateCode: this.homeStateCode,
              zipCode: homeAddressInfo.homePincode,
              county: homeAddressInfo.hometown,
              cellNumber: homeAddressInfo.homeCellNumber,
              areYouGuarantor: guarantorFlag,
              countyCode: homeAddressInfo.countyCode
            }
            this.dashboardService.verifyAddressDetails(addressData.streetAddress,addressData.suite,addressData.city,addressData.state,addressData.zipCode).subscribe(async (result: any) =>{
              if(result.data == null){
                this.toastService.showWarning(StringConstants.toast.MissCommunicationWithAddressApi, StringConstants.toast.empty);
              }
              else{
                const addressSuggested = result.data.cassResult;
                if(addressSuggested.status.type == 0){
                  if(addressSuggested.address1.toLowerCase() == addressData.streetAddress.toLowerCase() && addressSuggested.city.toLowerCase() == addressData.city.toLowerCase() && addressSuggested.county.toLowerCase() == addressData.county.toLowerCase() && addressSuggested.state.toLowerCase() == addressData.state.toLowerCase() && addressSuggested.zip.toLowerCase() == addressData.zipCode.toLowerCase() && addressSuggested.address2.toLowerCase() == addressData.suite.toLowerCase()){
                    this.dashboardService.addAddressInfo(addressData).subscribe(async (result: any) => {
                      this.nextButtonClicked.emit(true);
                      if (result.wasSuccessful) {
                      this.insertAddress();
                      }
                    }, (error) => {
                      console.log(error)
                    });
                  }
                  else{
                    this.modalRef = this.modalService.show(AddressVerificationComponent, {
                      initialState: { addressData, addressSuggested  },
                      animated: true,
                      keyboard: false,
                      backdrop : 'static',
                      class: 'modal-lg'
                    });
                    
                    this.modalRef.content.action.subscribe((value:any) => {
                      
                      if(value == "radioActualAddress"){
                        this.dashboardService.addAddressInfo(addressData).subscribe(async (result: any) => {
                          this.nextButtonClicked.emit(true);
                          if (result.wasSuccessful) {
                          this.insertAddress();
                          }
                        }, (error) => {
                          console.log(error)
                        });
                      }
                      else{
                        addressData.streetAddress = addressSuggested.address1;
                        addressData.city = addressSuggested.city;
                        addressData.county = addressSuggested.county;
                        addressData.state = addressSuggested.state;
                        addressData.zipCode = addressSuggested.zip;
                        addressData.suite = addressSuggested.address2;
                        this.dashboardService.addAddressInfo(addressData).subscribe(async (result: any) => {
                          this.nextButtonClicked.emit(true);
                          if (result.wasSuccessful) {
                          this.insertAddress();
                          }
                        }, (error) => {
                          console.log(error)
                        });
                      }
                  })
                }
                }
                else{
                  this.toastService.showWarning(StringConstants.toast.AddressNotFound, StringConstants.toast.empty);
                }
              }
        }, (error) => {
          
          console.log(error)
        });
          }
          else { // Update address details
            var guarantorFlag: number = JSON.parse(this.homeGuarantor);
            const addressData: any = {
              contactDetailsId: addressId,
              streetAddress: homeAddressInfo.homeStreetName,
              suite: homeAddressInfo.homeSuite,
              city: homeAddressInfo.homeCity,
              state: homeAddressInfo.homeState,
              zipCode: homeAddressInfo.homePincode,
              stateCode: this.homeStateCode,
              county: homeAddressInfo.hometown,
              cellNumber: homeAddressInfo.homeCellNumber,
              areYouGuarantor: guarantorFlag,
              assessmentId: assessmentId,
              countyCode: homeAddressInfo.countyCode
            }
            
            this.dashboardService.verifyAddressDetails(addressData.streetAddress,addressData.suite,addressData.city,addressData.state,addressData.zipCode).subscribe(async (result: any) =>{
              
              if(result.data == null){
                this.toastService.showWarning(StringConstants.toast.MissCommunicationWithAddressApi, StringConstants.toast.empty);
              }
              else{
                const addressSuggested = result.data.cassResult;
                if(addressSuggested.status.type == 0){
                  if(addressSuggested.address1.toLowerCase() == addressData.streetAddress.toLowerCase() && addressSuggested.city.toLowerCase() == addressData.city.toLowerCase() && addressSuggested.county.toLowerCase() == addressData.county.toLowerCase() && addressSuggested.state.toLowerCase() == addressData.state.toLowerCase() && addressSuggested.zip.toLowerCase() == addressData.zipCode.toLowerCase() && addressSuggested.address2.toLowerCase() == addressData.suite.toLowerCase()){
                    this.dashboardService.updateAddressInfo(addressData).subscribe(async (result: any) => {
                      if (result.wasSuccessful) {
                        this.updateAddress();
                      }
                    }, (error) => {
                      console.log(error)
                    });
                  }
                  else{
                    this.modalRef = this.modalService.show(AddressVerificationComponent, {
                      initialState: { addressData, addressSuggested  },
                      animated: true,
                      keyboard: false,
                      backdrop : 'static',
                      class: 'modal-lg'
                    });
                    
                    this.modalRef.content.action.subscribe((value:any) => {
                      
                      if(value == "radioActualAddress"){
                        this.dashboardService.updateAddressInfo(addressData).subscribe(async (result: any) => {
                          if (result.wasSuccessful) {
                            this.updateAddress();
                          }
                        }, (error) => {
                          console.log(error)
                        });
                      }
                      else{
                        addressData.streetAddress = addressSuggested.address1;
                        addressData.city = addressSuggested.city;
                        addressData.county = addressSuggested.county;
                        addressData.state = addressSuggested.state;
                        addressData.zipCode = addressSuggested.zip;
                        addressData.suite = addressSuggested.address2;
                        this.dashboardService.updateAddressInfo(addressData).subscribe(async (result: any) => {
                          if (result.wasSuccessful) {
                            this.updateAddress(); 
                          }
                        }, (error) => {
                          
                          console.log(error)
                        });
                      }
                      });
                  }
                }
                else{
                  this.toastService.showWarning(StringConstants.toast.AddressNotFound, StringConstants.toast.empty);
                }
              
              }
            }, (error) => {
              
              console.log(error)
            });

          }
        }
      }
    }
    else {
      if (!this.homeAddressForm.valid) {
        if (this.homeEntityType === StringConstants.var.patient) {
          this.dataSharingService.SavePersonalHome.next("false");
          this.dataSharingService.SavePersonal.next("false");
        }
        else if (this.homeEntityType === StringConstants.var.guarantor) {
          this.dataSharingService.SaveGuarantorHome.next("false");
          this.dataSharingService.SaveGuarantor.next("false");
        }
      }
      else {
        if (this.homeEntityType === StringConstants.var.patient) {
          this.dataSharingService.SavePersonal.next("true");
          this.dataSharingService.SavePersonalHome.next("true");
        }
        else if (this.homeEntityType === StringConstants.var.guarantor) {
          this.dataSharingService.SaveGuarantor.next("true");
          this.dataSharingService.SaveGuarantorHome.next("true");
        }
        this.homeAddressFlag = false;
        this.basicInfoFlag = false;
        this.workAddressFlag = true;
        this.nextButtonClicked.emit(true);
      }
    }
  }
}
