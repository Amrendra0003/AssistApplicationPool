import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {HttpClient, HttpHeaders} from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EsignserviceService {
  constructor(private _http:HttpClient) { }
   token ="Bearer 3AAABLblqZhBQVKfASPxFqDTKPQG40NlIxK1JR81T-GtWKVLgKZWaBzboxoo-wedoGjfejOLDXr9hml1RLcTb0Uxtl_hSYD-k"
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
  updateDocumanetformfields(uriapipoint:any,data:any,agreementId:any){
    const transientUrl = uriapipoint+ 'api/rest/v6/agreements/'+agreementId +'/formFields';
    let httpheaders = new HttpHeaders()
    .set('Authorization',this.token);
    return this._http.put(transientUrl,data,{headers:httpheaders})
  }
  updateDocumanetform(uriapipoint:any,data:any,agreementId:any){
    const transientUrl = uriapipoint+ 'api/rest/v6/agreements/'+agreementId + '/state';
    let httpheaders = new HttpHeaders()
    .set('Authorization',this.token);
    return this._http.put(transientUrl,data,{headers:httpheaders})
  }
  getDocumanetforSign(uriapipoint:any,agreementId:any):Observable<any>{
    const uriUrl = uriapipoint+'api/rest/v6/agreements/'+agreementId +'/signingUrls';
    let httpHeaders = new HttpHeaders()
    .set('Authorization',this.token);
     return this._http.get(uriUrl,{headers:httpHeaders,responseType:'json'});
  }
  getDocumanetformfields(uriapipoint:any,agreementId:any):Observable<any>{
    const uriUrl = uriapipoint+'api/rest/v6/agreements/'+agreementId +'/formFields';
    let httpHeaders = new HttpHeaders()
    .set('Authorization',this.token);
     return this._http.get(uriUrl,{headers:httpHeaders,responseType:'json'});
  }
  getMembers(uriapipoint:any,agreementId:any):Observable<any>{
    const uriUrl = uriapipoint+'api/rest/v6/agreements/'+agreementId +'/members';
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
