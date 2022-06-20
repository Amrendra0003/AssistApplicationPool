import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiConstants } from '../../assets/constants/url'
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class QuickAssessmentService {
  authorization: any = sessionStorage.getItem('token');
  constructor(private http: HttpClient) {
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
  }
  get tokenHeader(): HttpHeaders {
    return new HttpHeaders().set("tenant", (sessionStorage.getItem('tenant')!));
  }
  getQuickAssessmentDetails() { // Quick assessment details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetDynamicAssessmentData, { headers: this.headers });
  }
  getDynamicQuestions() { // Dynamic questions
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetDynamicQuestions, { headers: this.headers });
  }
  updateAssessmentDetails(updateDetails: any) { //Update assessment details
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.updateAssessmentDetails, updateDetails, { headers: this.headers });
  }
  getStateAndCity(zipCode: any) { // Get state and city
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetStateAndCity + "?zipcode=" + zipCode, { headers: this.headers });
  }
  validatePolicyNumber(policyNumber: any) { // Validate policy number
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.ValidatePolicyNumber + "?policyNumber=" + policyNumber, { headers: this.headers });
  }
  getSelfDetails(userId: any) { //Get self details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetSelfDetails + "?userId=" + userId, { headers: this.headers });
  }
  getPatientSelfDetails(patientId: any) { //Get patient self details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetPatientSelfDetails + "?patientId=" + patientId, { headers: this.headers });
  }
  getAdvocateSummaryPanel(requestBody: any) { //Get advocate summary panel
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.AdvocateSummaryPanel, requestBody, { headers: this.headers });
  }
  userExists(emailAddress: any) { // User exists
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.UserNameExists + "?emailAddress=" + emailAddress);
  }
  UserInfo(emailAddress: any) { //User Info
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.UserInfo + "?emailAddress=" + emailAddress);
  }
  createUserProfile(userDetails: any) { // Create user profile 
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.CreateUserProfile, userDetails);
  }
  getProfileDetails(userId: any) { // Get profile details
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetProfileDetails + "?userId=" + userId, { headers: this.headers });
  }
  updateProfileDetails(updateDetails: any) { //Update profile details
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.UpdateProfileDetails, updateDetails, { headers: this.headers });
  }
  createProgramMapping(programsList: any) { // Create program mapping
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.createProgramMapping, programsList, { headers: this.headers });
  }
  savePartialAssessment(partialAssessmentJson: any) { // To save partial quick assessment
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.SavePartialAssessment, partialAssessmentJson, { headers: this.headers });
  }
  updatePartialAssessment(partialSaveResponse: any) { // Update partial quick assessment
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.UpdatePartialAssessment, partialSaveResponse, { headers: this.headers });
  }
  deletePartialAssessment(quickAssessmentResultId: any) { // Delete partial quick assessment
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DeletePartialAssessment + "?quickAssessmentResultId=" + quickAssessmentResultId, { headers: this.headers });
  }
  getPartialAssessment(partialSaveId: any) { // Get partial quick assessment
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.GetPartialAssessment + "?partialSaveId=" + partialSaveId, { headers: this.headers });
  }
  validateUserAccount(token: any) { // To validate user account
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.ValidateUserAccount + "?token=" + token, { headers: this.tokenHeader });
  }
}
