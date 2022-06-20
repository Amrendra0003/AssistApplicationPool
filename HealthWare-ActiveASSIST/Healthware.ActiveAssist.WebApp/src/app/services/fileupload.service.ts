import { HttpClient, HttpEvent, HttpParams, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { ApiConstants } from 'src/assets/constants/url';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: "root"
})
export class FileUpload {
  constructor(private http: HttpClient) { }
  fileToUpload: any;
  UserId: any = sessionStorage.getItem("patientId");
  Token: any = sessionStorage.getItem("token");
  public idDocumentUploadStatus$: Subject<boolean> = new Subject<boolean>();
  public otherDocumentUploadStatus$: Subject<boolean> = new Subject<boolean>();
  public incomeDocumentUploadStatus$: Subject<boolean> = new Subject<boolean>();
  public addressDocumentUploadStatus$: Subject<boolean> = new Subject<boolean>();
  public uploadedDocumentId$: Subject<ProgramDocumentDetails> = new Subject<ProgramDocumentDetails>();
  UploadVerificationDocument(assessmentId: string, documentType: string, DocumentCategory: string, file: File) { // Upload verification document
    const fileDetails: FileDetails = {
      AssessmentId: assessmentId,
      UserId: sessionStorage.getItem("patientId"),
      HouseHoldMemberId: "0",
      ProgramId: "0",
      DocumentTitle: "verificationdocument",
      DocumentCategory: DocumentCategory,
      DocumentType: documentType,
      ProgramDocumentId: "0",
      Esigned: false,
    };
    return this.uploadDocument(fileDetails, file, this.Token).subscribe(async (result: any) => {
      if (result.body.wasSuccessful)
        this.updateStatus(DocumentCategory, true);
      else
        this.updateStatus(DocumentCategory, false);
    }, (error => {
      this.updateStatus(DocumentCategory, false);
    })
    );
  }
  updateStatus(type: string, status: boolean) { // Update document status
    switch (type) {
      case "Identification": {
        if (status)
          this.idDocumentUploadStatus$.next(true);
        else
          this.idDocumentUploadStatus$.next(false);
        break;
      }
      case "Address": {
        if (status)
          this.addressDocumentUploadStatus$.next(true);
        else
          this.addressDocumentUploadStatus$.next(false);
        break;
      }
      case "income": {
        if (status)
          this.incomeDocumentUploadStatus$.next(true);
        else
          this.incomeDocumentUploadStatus$.next(false);
        break;
      }
      case "Other": {
        if (status)
          this.otherDocumentUploadStatus$.next(true);
        else
          this.otherDocumentUploadStatus$.next(false);
      }
    }
  }
  UploadProgramDocument(AssessmentId: string, ProgramId: string, ProgramDocumentId: string, file: File, eSign: boolean = false) { // Upload program document
    const fileDetails: FileDetails = {
      AssessmentId: AssessmentId,
      UserId: sessionStorage.getItem("patientId"),
      HouseHoldMemberId: "0",
      ProgramId: ProgramId,
      DocumentTitle: "programdocument",
      DocumentCategory: "Eforms",
      DocumentType: "Eforms",
      ProgramDocumentId: ProgramDocumentId,
      Esigned: eSign,
    };
    this.uploadDocument(fileDetails, file, this.Token).subscribe(async (result: any) => {
      if (result.body.wasSuccessful) {
        this.uploadedDocumentId$.next(new ProgramDocumentDetails(ProgramDocumentId, result.body.data));
      }
      else {
        this.uploadedDocumentId$.next(new ProgramDocumentDetails(ProgramDocumentId, "0"));
      }
    }, (error => {
      this.uploadedDocumentId$.next(new ProgramDocumentDetails(ProgramDocumentId, "0"));
    })
    );
  }
  UploadIncomeVerificationDocument(assessmentId: string, documentType: string, HouseHoldMemberId: string, file: File) { // Upload income document
    const fileDetails: FileDetails = {
      AssessmentId: assessmentId,
      UserId: sessionStorage.getItem("patientId"),
      HouseHoldMemberId: HouseHoldMemberId,
      ProgramId: "0",
      DocumentTitle: "verificationdocument",
      DocumentCategory: "Income",
      DocumentType: documentType,
      ProgramDocumentId: "0",
      Esigned: false,
    };
    return this.uploadDocument(fileDetails, file, this.Token).subscribe(async (result: any) => {
      if (result.body.wasSuccessful)
        this.updateStatus("income", true);
      else
        this.updateStatus("income", false);
    }, (error => {
      this.updateStatus("income", false);
    })
    );
  }
  uploadDocument(fileDetails: FileDetails, file: File, token: string): Observable<HttpEvent<any>> { //Upload document
    let formData = new FormData();
    formData.append('file', file);
    formData.append('UserId', fileDetails.UserId);
    formData.append("AssessmentId", fileDetails.AssessmentId);
    formData.append('HouseHoldMemberId', fileDetails.HouseHoldMemberId);
    formData.append('ProgramId', fileDetails.ProgramId);
    formData.append('DocumentTitle', fileDetails.DocumentTitle);
    formData.append('DocumentCategory', fileDetails.DocumentCategory);
    formData.append('DocumentType', fileDetails.DocumentType);
    formData.append('ProgramDocumentId', fileDetails.ProgramDocumentId);
    formData.append('Esigned', fileDetails.Esigned.toString());
    formData.append('Token', token);
    let params = new HttpParams()
    const options = {
      params: params,
      reportProgress: true,
    };
    var url = environment.apiBaseUrl + ApiConstants.url.UploadFile;
    const req = new HttpRequest('POST', url, formData, options);
    return this.http.request(req);
  }
  uploadSignature(file: File, canvas: File, documentId: string, signatureText: string): Observable<HttpEvent<any>> { //Upload signature
    let formData = new FormData();
    formData.append('file', file);
    formData.append('SignatureCanvas', canvas);
    formData.append("DocumentId", documentId);
    formData.append('SignatureText', signatureText);
    let params = new HttpParams()
    const options = {
      params: params,
      reportProgress: true,
    };
    var url = environment.apiBaseUrl + ApiConstants.url.UploadSignature;
    const req = new HttpRequest('POST', url, formData, options);
    return this.http.request(req);
  }
  CompleteUploadedDocument(documentId: string) { //Uploaded document status
    let formData = new FormData();
    formData.append("DocumentId", documentId);
    let params = new HttpParams()
    const options = {
      params: params,
      reportProgress: true,
    };
    var url = environment.apiBaseUrl + ApiConstants.url.CompleteUploadedDocument;
    const req = new HttpRequest('POST', url, formData, options);
    return this.http.request(req);
  }
  uploadImage(assessmentId: string, file: File): Observable<HttpEvent<any>> { //Upload image
    let formData = new FormData();
    formData.append('upload', file);
    let params = new HttpParams()
    const options = {
      params: params,
      reportProgress: true,
    };
    var url = environment.apiBaseUrl + ApiConstants.url.AssessmentProfileImageUpload + assessmentId;
    const req = new HttpRequest('POST', url, formData, options);
    return this.http.request(req);
  }
  UpdateVerificationDocument(updateVerificationRequest: any) { // update verification document
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.UpdateVerificationDocument, updateVerificationRequest);
  }
  uploadUserProfileImage(userId: string, file: File): Observable<HttpEvent<any>> { //Upload user profile image
    let formData = new FormData();
    formData.append('upload', file);
    let params = new HttpParams()
    const options = {
      params: params,
      reportProgress: true,
    };
    var url = environment.apiBaseUrl + ApiConstants.url.UserProfileImageUpload + userId;
    const req = new HttpRequest('POST', url, formData, options);
    return this.http.request(req);
  }
  UserProfileImageDownload(userId: string) {  //To download user profile image
    return this.httpgetRequestimage(environment.apiBaseUrl + ApiConstants.url.UserProfileImageDownload + userId);
  }
  GetAssessmentProfileImage(AssessmentId: string) { // Assessment profile image
    return this.httpgetRequestimage(environment.apiBaseUrl + ApiConstants.url.AssessmentProfileImageDownload + AssessmentId);
  }
  GetIdVerificationDocumentDetail(AssessmentId: string) { // verification document details
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.GetIDVerificationFileDetail + AssessmentId);
  }
  GetOtherVerificationDocumentDetail(AssessmentId: string) { // Other document verification details
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.GetOtherVerificationFileDetail + AssessmentId);
  }
  GetAddressVerificationDocumentDetail(AssessmentId: string) { // Address document verification details
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.GetAddressVerificationFileDetail + AssessmentId);
  }
  GetIncomeVerificationDocumentDetail(AssessmentId: string) { //Income document  verification details 
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.GetIncomeVerificationFileDetail + AssessmentId);
  }
  GetDocumentByAssessmentIdTypeName(AssessmentId: any, DocumentTypeName: string) { //  Get document by assessment
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.GetDocumentByAssessmentIdTypeName + "?assessmentId=" + AssessmentId + "&documentTypeName=" + DocumentTypeName);
  }
  DeleteDocument(DocumentId: string, householdMemberId: string) { // To delete document
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.DeleteDocument + "?DocId=" + DocumentId + "&householdMemberId=" + householdMemberId);
  }
  GetProgramDocumentDownloadURL(programDocumentId: string) { // Program document download
    return environment.apiBaseUrl + ApiConstants.url.GetProgramDocumentDownloadUrl + programDocumentId;
  }
  GetProgramDocumentDetails(ProgramId: string, AssessmentId: string, IsEvaluated: boolean) { // Get program details
    return this.httpgetRequest(environment.apiBaseUrl + ApiConstants.url.GetProgramDocumentDetails + "?PrgmId=" + ProgramId + "&AssessmentId=" + AssessmentId + "&isEvaluated=" + IsEvaluated);
  }
  httpgetRequest(url: string) {
    return this.http.get(url);
  }
  UpdateDocumentPathById(DocumentId: number, DocumentPath: string): Observable<HttpEvent<any>> { //UPdate document path
    var url = environment.apiBaseUrl + ApiConstants.url.UpdateDocumentPathByID + "?docId=" + DocumentId + "&filePath=" + DocumentPath;
    const req = new HttpRequest('POST', url, {});
    return this.http.request(req);
  }
  httpgetRequestimage(url: string) { // Request image
    return this.http.get(url, { responseType: 'text' });
  }
  getDocumentDownloadURL(documentId: string) { // Document download url
    return environment.apiBaseUrl + ApiConstants.url.PreviewDocument + documentId;
  }
  getProgramDocumentURL(programDocumentId: string) { //Program document download
    return environment.apiBaseUrl + ApiConstants.url.GetProgramDocumentDownloadUrl + programDocumentId;
  }
  createProgramDocument(fileDetails: any) { // To create program document
    return this.http.post(environment.apiBaseUrl + ApiConstants.url.GetAssessmentProgramDocument, fileDetails);
  }
}
export interface FileDetails {
  AssessmentId: any
  UserId: any
  HouseHoldMemberId: any
  ProgramId: string
  DocumentTitle: string
  DocumentCategory: string
  DocumentType: string
  ProgramDocumentId: any
  DocumentName?: string
  Esigned: boolean
}
export class ProgramDocumentDetails {
  constructor(ProgramDocumentId: string, DocumentId: string) {
    this.ProgramDocumentId = ProgramDocumentId;
    this.DocumentId = DocumentId;
  }
  public ProgramDocumentId: string = "";
  public DocumentId: string = "";
}