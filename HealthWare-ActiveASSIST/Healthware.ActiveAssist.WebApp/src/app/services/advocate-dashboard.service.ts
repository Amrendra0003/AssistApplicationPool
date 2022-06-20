import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ApiConstants } from '../../assets/constants/url'
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class AdvocateDashboardService {
  authorization: any = sessionStorage.getItem('token');
  constructor(private http: HttpClient) {
  }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': "application/json",
      'token': this.authorization,
    })
  }
  get headers(): HttpHeaders {
    return new HttpHeaders().set("token", (sessionStorage.getItem('token')!))
      .set("tenant", (sessionStorage.getItem('tenant')!));
  }
  /*get dashboard Details*/
  getAdvocateDashboardDetails(userId: any, filterDays: string, orderBy: string, searchWord: string, browserDate: string) {
    var encodedSearchWord = encodeURIComponent(searchWord);
    return this.http.get(environment.apiBaseUrl + ApiConstants.url.AdvocateDashboard + "?userId=" + userId + "&filterDays=" + filterDays + "&orderBy=" + orderBy + "&partialName=" + encodedSearchWord + "&browserDate=" + browserDate, { headers: this.headers });
  }
  /*create advocate assessment*/
  createAdvocateAssessment(patientDetails: any) {
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.CreateAssessment, patientDetails, { headers: this.headers });
  }
  /*Delete assessment*/
  deleteAssessmentDashboard(assessmentId: any) {
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.DeleteDashboard, assessmentId, { headers: this.headers });
  }
  /*add review notes*/
  addReviewNotes(reviewNotes: any) {
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.AddReviewNotes, reviewNotes, { headers: this.headers });
  }
  /*get review notes*/
  getReviewNotes(getReviewNotes: any) {
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetReviewNotes, getReviewNotes, { headers: this.headers });
  }
  /*Add more programs*/
  addMorePrograms(programIdList: any) {
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.AddMorePrograms, programIdList, { headers: this.headers });
  }
  /*Update quickAssessment result*/
  updateQuickAssessmentResult(programsList: any) {
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.UpdateQuickAssessmentPrograms, programsList, { headers: this.headers });
  }
}