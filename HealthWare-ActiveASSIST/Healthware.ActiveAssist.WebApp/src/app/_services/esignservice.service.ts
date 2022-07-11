import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EsignserviceService {
  constructor(private _http:HttpClient) { }
   token ="Bearer 3AAABLblqZhBM3SBjRfXEymJcB8NBtKCrg7BI_wgo2YG6bdKnyhDgbWZ-QUjidhCV8xRCmDO2tTVaaZS7HXcACpHopv0am74_"
  getBaseUri():Observable<any>{
   const uriUrl = "https://api.adobesign.com/api/rest/v6/baseUris";
   let httpHeaders = new HttpHeaders()
   .set('Authorization',this.token);
    return this._http.get(uriUrl,{headers:httpHeaders,responseType:'json'});
  }
  transientDocuments (uriapipoint:string,data:any):Observable<any>{
    const transientUrl = uriapipoint+ 'api/rest/v6/transientDocuments';
    let httpheaders = new HttpHeaders()
    .set('Authorization',this.token);
    return this._http.post(transientUrl,data,{headers:httpheaders})
  }
  getAgreeMentIdBytransientId(uriapipoint:any,data:any){
    const transientUrl = uriapipoint+ 'api/rest/v6/agreements';
    let httpheaders = new HttpHeaders()
    .set('Authorization',this.token);
    return this._http.post(transientUrl,data,{headers:httpheaders})
  }
  getDocumanetforSign(uriapipoint:any,agreementId:any):Observable<any>{
    const uriUrl = uriapipoint+'api/rest/v6/agreements/'+agreementId +'/signingUrls';
    let httpHeaders = new HttpHeaders()
    .set('Authorization',this.token);
     return this._http.get(uriUrl,{headers:httpHeaders,responseType:'json'});
  }
   getDocumentforDownload(uriapipoint:any,agreementId:any):Observable<any>{
     const uriUrl = uriapipoint+'api/rest/v6/agreements/'+agreementId+'/combinedDocument';
     let httpHeaders = new HttpHeaders()
    .set('Authorization', this.token);
     return this._http.get(uriUrl,{headers:httpHeaders,responseType:'json'});

  }


}
