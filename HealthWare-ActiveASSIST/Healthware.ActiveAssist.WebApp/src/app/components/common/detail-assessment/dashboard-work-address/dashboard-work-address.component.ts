import { Component, Input, OnInit, Output, EventEmitter } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { CommonService } from 'src/app/services/common.service';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { AddressVerificationComponent } from '../../address-verification/address-verification.component';
@Component({
  selector: 'app-dashboard-work-address',
  templateUrl: './dashboard-work-address.component.html',
  styleUrls: ['./dashboard-work-address.component.css']
})
export class DashboardWorkAddressComponent implements OnInit {
  homeAddressFlag: any;
  basicInfoFlag: any;
  addressID: any;
  workAddressForm: any;
  patientId: any;
  assessmentId: any;
  employer: any;
  streetName: any;
  suite: any;
  country: any;
  city: any;
  state: any;
  zipcode: any;
  homeNo: any;
  data: any;
  isGuarantor: any;
  countyCode: string = "1";
  contactTypeId: any;
  stateCode: any;
  @Output() backToPersonalHome: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Output() backToGuarantorHome: EventEmitter<boolean> = new EventEmitter<boolean>();
  @Input() workStreetAddress: any;
  @Input() workEmployer: any;
  @Input() workSuite: any;
  @Input() workCity: any;
  @Input() workCountry: any;
  @Input() workHomeNo: any;
  @Input() workState: any;
  @Input() workPincode: any;
  @Input() workData: any;
  @Input() workEntityType: any;
  @Input() workAddressId: any;
  @Input() workGuarantor: any;
  @Input() workCountyCode: any;
  workAddressFlag: any;
  entityType: any;
  guarantorId: any;
  entityId: any;
  relation: any;
  currentTheme: any;
  isEditAllowed: any;
  GuarantorData: any;
  StateReq = StringConstants.demographics.StateReq;
  StreetAddressReg = StringConstants.profileSetting.StreetAddressReg;
  ZipReq = StringConstants.demographics.ZipReq;
  EmployerNameReq = StringConstants.DashboardWorkAddress.EmployerNameReq;
  EmployeMax = StringConstants.DashboardWorkAddress.EmployeMax;
  EmployeMin = StringConstants.DashboardWorkAddress.EmployeMin;
  StreetAddressMax = StringConstants.profileSetting.StreetAddressMax;
  CountyReq = StringConstants.profileSetting.CountyReq;
  ZipNum = StringConstants.demographics.ZipNum;
  ZipVal = StringConstants.demographics.ZipVal;
  ZipMin = StringConstants.demographics.ZipMin;
  CityReq = StringConstants.demographics.CityReq;
  ZipMax = StringConstants.DashboardHousehold.ZipMax;
  CountyAlp = StringConstants.profileSetting.CountyAlp;
  CountyMax = StringConstants.profileSetting.CountyMax;
  CityAlp = StringConstants.demographics.CityAlp;
  CityMax = StringConstants.demographics.CityMax;
  StateAlp = StringConstants.DashboardHousehold.StateAlp;
  Work = StringConstants.Common.Work;
  WorkNumVal = StringConstants.DashboardWorkAddress.WorkNumVal;
  WorkAddress = StringConstants.Common.WorkAddress;
  result: any;
  phoneCode: any;
  constructor(public modalService: BsModalService, private modalRef: BsModalRef, private dashboardService: DashboardService, private dataSharing: DataSharingService, private toastService: ToastServiceService,
    private dataSharingService: DataSharingService, private common: CommonService) {
    this.dataSharingService.changeTheme.subscribe(value => { // Theme settings
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.dataSharing.isGuarantorData.subscribe(value => { // Get guarantor data
      this.GuarantorData = value;
    })
    this.dataSharing.editable.subscribe(value => { // Assessment status
      this.isEditAllowed = value;
    })
  }
  ngOnInit() {
    
    this.initForm();
    this.patientId = sessionStorage.getItem('patientId');
    this.assessmentId = sessionStorage.getItem('assessmentId');
    this.guarantorId = sessionStorage.getItem('guarantorId');
    this.relation = sessionStorage.getItem('relation');
    this.employer = this.workEmployer;
    this.streetName = this.workStreetAddress;
    this.suite = this.workSuite;
    this.city = this.workCity;
    this.country = this.workCountry;
    this.state = this.workState;
    this.zipcode = this.workPincode;
    this.homeNo = this.workHomeNo;
    this.data = this.workData;
    this.entityType = this.workEntityType;
    this.addressID = this.workAddressId;
    this.isGuarantor = this.workGuarantor;
    this.countyCode = this.workCountyCode;
    this.getPhoneCode();
    if (this.workEntityType === StringConstants.var.guarantor && this.relation == StringConstants.var.self) {
      this.workAddressForm.get('employeer').disable();
      this.workAddressForm.get('streetName').disable();
      this.workAddressForm.get('suite').disable();
      this.workAddressForm.get('country').disable();
      this.workAddressForm.get('city').disable();
      this.workAddressForm.get('state').disable();
      this.workAddressForm.get('zipcode').disable();
      this.workAddressForm.get('homeNo').disable();
      this.workAddressForm.get('countyCode').disable();
    }
    else {
      this.workAddressForm.get('employeer').enable();
      this.workAddressForm.get('streetName').enable();
      this.workAddressForm.get('suite').enable();
      this.workAddressForm.get('country').enable();
      this.workAddressForm.get('city').enable();
      this.workAddressForm.get('state').enable();
      this.workAddressForm.get('zipcode').enable();
      this.workAddressForm.get('homeNo').enable();
      this.workAddressForm.get('countyCode').enable();
    }
  }
  private initForm() {
    
    this.workAddressForm = new FormGroup({
      'employeer': new FormControl('', [Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(250), Validators.minLength(3)]),
      'streetName': new FormControl('', [Validators.required, Validators.maxLength(250)]),
      'suite': new FormControl('', [Validators.maxLength(250)]),
      'country': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'city': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$'), Validators.maxLength(50)]),
      'state': new FormControl('', [Validators.required, Validators.pattern('^[a-zA-Z ]*$')]),
      'zipcode': new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$'), Validators.minLength(5), Validators.maxLength(50)]),
      'homeNo': new FormControl('', [Validators.minLength(10)]),
      'data': new FormControl(''),
      'countyCode': new FormControl(''),
    });
  }
  async getStateAndCity() { //Get state and city
    
    const val = this.workAddressForm.get('zipcode').value;
    if (val.length >= 5) {
      this.result = await this.common.getStateAndCity(val);
      if (this.result.wasSuccessful == true) {
        console.log(this.result.data, "work akuran da");
        if (this.result.data != null) {
          this.city = this.result.data.city;
          this.state = this.result.data.stateCode;
          this.stateCode = this.result.data.stateCode;
          this.workAddressForm.controls['zipcode'].setErrors(null);
        }
        else {
          this.city = "";
          this.state = "";
          this.workAddressForm.controls['zipcode'].setErrors({ 'invalid': true });
        }
      }
      else if (this.result.wasSuccessful == false) {
        console.log(this.result);
      }
    }
    else {
      this.city = "";
      this.state = "";
    }
  }
  async getPhoneCode(){ //To get country codes
    this.phoneCode = await this.common.getPhoneCode();
  }
  GoToHomeAddress() { // Back to home address
    if (this.entityType === StringConstants.var.patient) {
      this.backToPersonalHome.emit(true);
    }
    else if (this.entityType === StringConstants.var.guarantor) {
      this.backToGuarantorHome.emit(true);
    }
  }
  insertAddress(){ 
    this.workAddressForm.markAsPristine();
    this.homeAddressFlag = false;
    this.basicInfoFlag = false;
    this.workAddressFlag = true;
    if (this.workEntityType === StringConstants.var.patient) {
      this.dataSharingService.SavePersonalWork.next("true");
      this.dataSharingService.SavePersonal.next("true");
    }
    else if (this.workEntityType === StringConstants.var.guarantor) {
      this.dataSharingService.SaveGuarantorWork.next("true");
      this.dataSharingService.SaveGuarantor.next("true");
    }

    if (this.entityType === StringConstants.var.patient) {
      if (this.GuarantorData == 'false')
        this.dataSharing.showGuarantorTab.next("2");
      else
        this.dataSharing.showContactPreferenceTab.next("3");
    }
    else if (this.entityType === StringConstants.var.guarantor) {
      this.dataSharing.showContactPreferenceTab.next("3");
    }           
  }
  updateAddress(){
    this.workAddressForm.markAsPristine();
    this.homeAddressFlag = false;
    this.basicInfoFlag = false;
    this.workAddressFlag = true;
    if (this.workEntityType === StringConstants.var.patient) {
      this.dataSharingService.SavePersonalWork.next("true");
      this.dataSharingService.SavePersonal.next("true");
    }
    else if (this.workEntityType === StringConstants.var.guarantor) {
      this.dataSharingService.SaveGuarantorWork.next("true");
      this.dataSharingService.SaveGuarantor.next("true");
    }
    if (this.entityType === StringConstants.var.patient) {
      if (this.GuarantorData == 'false')
        this.dataSharing.showGuarantorTab.next("2");
      else
        this.dataSharing.showContactPreferenceTab.next("3");
    }
    else if (this.entityType === StringConstants.var.guarantor) {
      this.dataSharing.showHouseholdTab.next("3");
    }
  }
  workAddressNext(workAddressInfo: any) { //Save work address
    
    if (this.workAddressForm.dirty) {
      if (this.relation == StringConstants.var.self && this.workEntityType === StringConstants.var.guarantor) {
        this.dataSharing.showHouseholdTab.next("3");
      }
      else {
        if (!this.workAddressForm.valid) {
          this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
          if (this.workEntityType === StringConstants.var.patient) {
            this.dataSharingService.SavePersonalWork.next("false");
            this.dataSharingService.SavePersonal.next("false");
          }
          else if (this.workEntityType === StringConstants.var.guarantor) {
            this.dataSharingService.SaveGuarantorWork.next("false");
            this.dataSharingService.SaveGuarantor.next("false");
          }
        }
        else {
          var guarantorFlag: number = JSON.parse(this.isGuarantor);
          var patientID: number = +(this.patientId);
          var guarantorID: number = +(this.guarantorId);
          var addressId: number = +(this.addressID);
          var postalCode: number = +(workAddressInfo.zipcode);
          var assessmentId: number = +(this.assessmentId);
          if (this.workEntityType === StringConstants.var.patient) {
            this.entityId = patientID;
            this.contactTypeId = 3;
          }
          else if (this.workEntityType === StringConstants.var.guarantor) {
            this.entityId = guarantorID;
            this.contactTypeId = 6;
          }
          if (this.data === undefined || this.data === '') { // Add new work address
            const addressData = {
              name: workAddressInfo.employeer,
              entityId: this.entityId,
              entityType: this.entityType,
              addressType: StringConstants.var.workAddress,
              contactTypeId: this.contactTypeId,
              contactDetailsId: 0,
              assessmentId: assessmentId,
              streetAddress: workAddressInfo.streetName,
              suite: workAddressInfo.suite,
              city: workAddressInfo.city,
              state: workAddressInfo.state,
              stateCode: this.stateCode,
              zipCode: workAddressInfo.zipcode,
              county: workAddressInfo.country,
              cellNumber: workAddressInfo.homeNo,
              areYouGuarantor: guarantorFlag,
              countyCode: workAddressInfo.countyCode
            }
            this.dashboardService.verifyAddressDetails(addressData.streetAddress,addressData.suite,addressData.city,addressData.state,addressData.zipCode).subscribe(async (result: any) =>{
              if(result.data == null){
                this.toastService.showWarning(StringConstants.toast.MissCommunicationWithAddressApi, StringConstants.toast.empty);
              }
              else{
                const addressSuggested = result.data.cassResult;
                if(addressSuggested.status.type == 0){
                  if(addressData.suite == null){
                    addressData.suite = ''
                  }
                  if(addressSuggested.address1.toLowerCase() == addressData.streetAddress.toLowerCase().trim() && addressSuggested.city.toLowerCase() == addressData.city.toLowerCase().trim() && addressSuggested.county.toLowerCase() == addressData.county.toLowerCase().trim() && addressSuggested.state.toLowerCase() == addressData.state.toLowerCase().trim() && addressSuggested.zip.toLowerCase() == addressData.zipCode.toLowerCase().trim() && addressSuggested.address2.toLowerCase() == addressData.suite.toLowerCase().trim()){
                  this.dashboardService.addAddressInfo(addressData).subscribe(async (result: any) => {
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
          else {
            if (this.workAddressForm.get('employeer').value == "" && this.workAddressForm.get('streetName').value == "" &&
              this.workAddressForm.get('suite').value == "" && this.workAddressForm.get('zipcode').value == ""
              && this.workAddressForm.get('homeNo').value == "") {
              var addressId = +(this.addressID);
              var assessmentId = +(this.assessmentId);
              const deleteRequest: any = {
                contactDetailsId: addressId,
                assessmentId: assessmentId
              }
              this.dashboardService.DeleteWorkAddress(deleteRequest).subscribe(async (result: any) => {
                if (result.wasSuccessful) {
                  if (this.entityType === StringConstants.var.patient) {
                    if (this.GuarantorData == 'false')
                      this.dataSharing.showGuarantorTab.next("2");
                    else
                      this.dataSharing.showContactPreferenceTab.next("3");
                    this.dataSharingService.SavePersonalWork.next("");
                  }
                  else if (this.entityType === StringConstants.var.guarantor) {
                    this.dataSharing.showHouseholdTab.next("3");
                    this.dataSharingService.SaveGuarantorWork.next("");
                  }
                }
              }, (error) => {
                console.log(error)
              });
            }
            else { //Update work address
              var guarantorFlag: number = JSON.parse(this.isGuarantor);
              const addressData: any = {
                name: workAddressInfo.employeer,
                contactDetailsId: addressId,
                streetAddress: workAddressInfo.streetName,
                suite: workAddressInfo.suite,
                city: workAddressInfo.city,
                state: workAddressInfo.state,
                zipCode: workAddressInfo.zipcode,
                county: workAddressInfo.country,
                cellNumber: workAddressInfo.homeNo,
                stateCode: this.stateCode,
                areYouGuarantor: guarantorFlag,
                assessmentId: assessmentId,
                countyCode: workAddressInfo.countyCode
              }
              this.dashboardService.verifyAddressDetails(addressData.streetAddress,addressData.suite,addressData.city,addressData.state,addressData.zipCode).subscribe(async (result: any) =>{
                if(result.data == null){
                  this.toastService.showWarning(StringConstants.toast.MissCommunicationWithAddressApi, StringConstants.toast.empty);
                }
                else{
                  const addressSuggested = result.data.cassResult;
                  if(addressSuggested.status.type == 0){ 
                    if(addressData.suite == null){
                      addressData.suite = ''
                    }
                    if(addressSuggested.address1.toLowerCase() == addressData.streetAddress.toLowerCase().trim() && addressSuggested.city.toLowerCase() == addressData.city.toLowerCase().trim() && addressSuggested.county.toLowerCase() == addressData.county.toLowerCase().trim() && addressSuggested.state.toLowerCase() == addressData.state.toLowerCase().trim() && addressSuggested.zip.toLowerCase() == addressData.zipCode.toLowerCase().trim() && addressSuggested.address2.toLowerCase() == addressData.suite.toLowerCase().trim()){
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
          }
        }
      }
    }
    else if (this.entityType === StringConstants.var.patient) {
      if (!this.workAddressForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharingService.SavePersonalWork.next("false");
        this.dataSharingService.SavePersonal.next("false");
      }
      else {
        if (this.GuarantorData == 'false')
          this.dataSharing.showGuarantorTab.next("2");
        else
          this.dataSharing.showContactPreferenceTab.next("3");
      }
    }
    else if (this.entityType === StringConstants.var.guarantor) {
      if (!this.workAddressForm.valid) {
        this.toastService.showWarning(StringConstants.toast.fillRequired, StringConstants.toast.empty);
        this.dataSharingService.SaveGuarantorWork.next("false");
        this.dataSharingService.SaveGuarantor.next("false");
      }
      else {
        this.dataSharing.showContactPreferenceTab.next("3");
      }
    }
  }
}
