import {ActivatedRouteSnapshot, Resolve, RouterStateSnapshot} from "@angular/router";
import {Observable} from "rxjs";
import {Injectable} from "@angular/core";
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { ApiConstants } from '../../../../assets/constants/url';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';

export interface JsonFormDat {
  screens: Screen[];
}
@Injectable({
  providedIn: "root"
})
export class SinglePostResolver implements Resolve<any>{

  constructor(
    private http: HttpClient, 
    private dataSharingService: DataSharingService,
    private quickAssessmentService: QuickAssessmentService
  ){
    this.dataSharingService.canCreate.subscribe(value => {
      this.showScreen = value;
    })
  }
  QuestionAndAnswer: any[] = [];
  showScreen:any;
  result:any;
  screenNumber:any;
  jsonFormData!: JsonFormDat;
  public formData!: JsonFormDat;
  response:any;
  headers:any;
  filterScreenDetails:any;
  async resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot) {
    this.headers = new HttpHeaders().set("token", (sessionStorage.getItem('token')!)).set("tenant", (sessionStorage.getItem('tenant')!));
      this.response =await this.http.get<any>(environment.apiBaseUrl + ApiConstants.url.GetDynamicQuestions, { headers: this.headers }).toPromise();
      if (this.response.data.isDynamic == true) {
        sessionStorage.setItem('isDynamic', this.response.data.isDynamic);
        this.formData = this.response.data;
        if (this.showScreen == false) {// Partial Assessment!
          this.result = this.getPartialAssessment();
          return this.result;
        }
        else{
          this.result = this.getScreenDetails();
          return this.result;
        }

      }

  }
  async getPartialAssessment(){
    var partialAssessmentId = +(sessionStorage.getItem('resultID')!);
    this.response =await this.http.get(environment.apiBaseUrl + ApiConstants.url.GetPartialAssessment + "?partialSaveId=" + partialAssessmentId, { headers: this.headers }).toPromise();
      if (this.response.wasSuccessful) {
        sessionStorage.setItem('QuestionAndAnswer', this.response.data);
        this.QuestionAndAnswer = JSON.parse(this.response.data)
        var TempData = JSON.parse(this.response.data);
        var DataLength = TempData.length;
        this.screenNumber = (DataLength);
        this.result = this.getPartialScreenDetails(this.screenNumber);
        return this.result;
      }
  }
  getPartialScreenDetails(screenNumber:any){
    this.filterScreenDetails = this.formData.screens.filter((e:any) => e.screenId == screenNumber)
    return this.jsonFormData = {
      screens:
        this.filterScreenDetails
    }
  }
  getScreenDetails() {// To get all screen details
    sessionStorage.setItem("resultID", "");
    this.filterScreenDetails = this.formData.screens.filter((e:any) => e.screenId == 1)
    return this.jsonFormData = {
      screens:
        this.filterScreenDetails
    }
  }
}
