import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiConstants } from '../../assets/constants/url'
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class DashboardService {
  authorization: any = sessionStorage.getItem('token');
  constructor(private http: HttpClient) {
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set("token", (sessionStorage.getItem('token')!))
      .set("tenant", (sessionStorage.getItem('tenant')!));
  }
  getDashboardDetails(userId: any, searchWord: string) { // Get Dashboard details
    var encodedSearchWord = encodeURIComponent(searchWord);
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.Dashboard + "?userId=" + userId + "&partialName=" + encodedSearchWord, { headers: this.headers });
  }
  deleteAssessmentDashboard(assessmentId: any) { // Delete assessment by id
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DeleteDashboard, assessmentId, { headers: this.headers });
  }
  getDashboardPersonalBasicInfo(basicRequest: any) { // Get basic personal details 
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardBasicInfo, basicRequest, { headers: this.headers });
  }
  getDashboardPersonalAddressInfo(addressData: any) { // Get persoanl home address
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardAddressInfo, addressData, { headers: this.headers });
  }
  updateDashboardPersonalBasicInfo(updateBasicData: any) { //Update personal basic info
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardUpdatePersonalDetail, updateBasicData, { headers: this.headers });
  }
  addAddressInfo(addressData: any) { // Add new address
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardAddAddress, addressData, { headers: this.headers });
  }
  updateAddressInfo(addressData: any) { // Update address Details
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardUpdateAddress, addressData, { headers: this.headers });
  }
  verifyAddressDetails(addressLine1: string, addressLine2: string, city: string, state: string, zip: string){
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardVerifyAddress + "?addressLine1=" + addressLine1 + "&addressLine2=" + addressLine2 + "&city=" + city + "&state=" + state + "&zip=" + zip, { headers: this.headers });
  }
  addGuarantorBasicInfo(guarantorInfo: any) { // Save guarantor details
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardAddGuarantorInfo, guarantorInfo, { headers: this.headers });
  }
  updateGuarantorBasicInfo(guarantorInfo: any) { // Update guarantor info
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardUpdateGuarantorInfo, guarantorInfo, { headers: this.headers });
  }
  getGuarantorBasicInfo(assessmentId: any) { // Get guarantor info
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardGetGuarantorInfo + "?assessmentId=" + assessmentId, { headers: this.headers });
  }
  getHouseholdMemberListInfo(assessmentId: any) { // Get gousehold member list
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardGetHouseholdInfo + "?assessmentId=" + assessmentId, { headers: this.headers });
  }
  getIncomeResourceAmount(assessmentId: any) { // Get income and resource amount
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetIncomeResourceAmount + "?assessmentId=" + assessmentId, { headers: this.headers });
  }
  getHouseHoldMemberDetails(houseHoldMemberId: any) { // Get household member details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardGetHouseHoldMemberDetails + "?houseHoldMemberId=" + houseHoldMemberId, { headers: this.headers });
  }
  getHouseHoldMemberIncomeDetails(houseHoldMemberIncomeId: any) { // Get household member income details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardGetHouseHoldMemberIncomeDetails + "?houseHoldIncomeId=" + houseHoldMemberIncomeId, { headers: this.headers });
  }
  getHouseHoldResourceDetails(houseHoldMemberResourceId: any) { // Get household resource details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardGetHouseHoldResourceDetails + "?houseHoldResourceId=" + houseHoldMemberResourceId, { headers: this.headers });
  }
  CreateHouseholdMember(householdInfo: any) { // To Create new household member
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardCreateHouseHoldMember, householdInfo, { headers: this.headers });
  }
  UpdateHouseholdMemberBasicInfo(updateData: any) { // Update household member Basic
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardUpdateHouseHoldMemberBasicInfo, updateData, { headers: this.headers });
  }
  UpdateHouseHoldMemberIncomeInfo(householdIncomeInfo: any) { //Update household member Income
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardUpdateHouseHoldMemberIncomeInfo, householdIncomeInfo, { headers: this.headers });
  }
  UpdateHouseHoldMemberResourceInfo(householdResourceInfo: any) { //Updatehousehold member Resource
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardUpdateHouseHoldMemberResourceInfo, householdResourceInfo, { headers: this.headers });
  }
  CreateHouseHoldIncome(householdIncomeInfo: any) { //Create new household income
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardCreateHouseHoldIncome, householdIncomeInfo, { headers: this.headers });
  }
  CreateHouseHoldResource(householdResourceInfo: any) { // Create new household resource
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DashboardCreateHouseHoldResource, householdResourceInfo, { headers: this.headers });
  }
  DeleteHouseHoldIncome(houseHoldIncomeId: any) { // Delete household Income
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardDeleteIncome + "?houseHoldIncomeId=" + houseHoldIncomeId, { headers: this.headers });
  }
  DeleteHouseHoldResource(houseHoldMemberId: any) { //Delete household Resource
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardDeleteResource + "?houseHoldResourceId=" + houseHoldMemberId, { headers: this.headers });
  }
  DeleteHouseHoldMember(houseHoldResourceId: any) { //Delete household member
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.DashboardDeleteHouseholdMember + "?householdMemberId=" + houseHoldResourceId, { headers: this.headers });
  }
  CheckEmailStatus(emailAddress: any) { /*Check email existance*/
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.CheckEmailStatus + "?emailAddress=" + emailAddress, { headers: this.headers });
  }
  EmailVerification(emailVerification: any) {  /* Verification  */
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.EmailVerification, emailVerification, { headers: this.headers });
  }
  ValidateEmailToken(token: any) { // TO validate email token
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.ValidateEmailToken + "?token=" + token, { headers: this.headers });
  }
  CellVerification(otpRequest: any) { // Cell verification
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.CellVerification, otpRequest, { headers: this.headers });
  }
  ValidateCellVerification(otpResponse: any) { //To validate cell verification
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.ValidateCellVerification, otpResponse, { headers: this.headers });
  }
  GetVerificationStatus(request: any) { // Get verification status
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetVerificationStatus, request, { headers: this.headers });
  }
  SubmitApplication(statusUpdateRequest: any) { /*Submit Application*/
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.SubmitApplication, statusUpdateRequest, { headers: this.headers });
  }
  GetHouseHoldMemberNames(memberRequest: any) { /*Quick Assessment*/
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetHouseHoldMemberNames, memberRequest, { headers: this.headers });
  }
  UpdatePatientReviewPrograms(updateReview: any) { // Update Review Programs
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.UpdatePatientReviewPrograms, updateReview, { headers: this.headers });
  }
  GetActiveReviewPrograms(activeReviewReq: any) { // Get active programs
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetActiveReviewPrograms, activeReviewReq, { headers: this.headers });
  }
  GetNotEvaluatedActiveReviewPrograms(activeReviewReq: any) { //Before evalute Programs
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetNotEvaluatedActiveReviewPrograms, activeReviewReq, { headers: this.headers });
  }
  GetEvaluatedReviewPrograms(activeReviewReq: any) { // After evalute programs
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetEvaluatedReviewPrograms, activeReviewReq, { headers: this.headers });
  }
  EvaluateAssessment(activeReviewReq: any) { // Evaluate assessment
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.EvaluateAssessment, activeReviewReq, { headers: this.headers });
  }
  GetAllReviewPrograms(reviewRequest: any) { // Get all review programs
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetAllReviewPrograms, reviewRequest, { headers: this.headers });
  }
  HouseHoldMemberNames(request: any) { // Get household member names
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetHouseHoldMemberNames, request, { headers: this.headers });
  }
  GetContactPreference(contactRequest: any) { /* Get Contact Preference*/
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetContactPreference, contactRequest, { headers: this.headers });
  }
  SaveContactPreference(contactData: any) {  // To save contact preference
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.SaveContactPreference, contactData, { headers: this.headers });
  }
  UpdateContactPreference(contactData: any) { //Update contact preference
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.UpdateContactPreference, contactData, { headers: this.headers });
  }
  GetEFormData(eformRequest: any) { // Get eform Data
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetEFormData, eformRequest, { headers: this.headers });
  }
  DeleteWorkAddress(deleteRequest: any) { //DeleteworkAddress
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DeleteWorkAddress, deleteRequest, { headers: this.headers });
  }
  TabStatus(tabRequest: any) { //Tab Status
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.TabStatus, tabRequest, { headers: this.headers });
  }
}