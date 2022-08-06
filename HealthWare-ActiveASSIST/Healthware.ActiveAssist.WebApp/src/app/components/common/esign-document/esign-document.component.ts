import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FileUpload } from 'src/app/services/fileupload.service';
import { ViewSDKClient } from 'src/app/services/view-sdk.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { DataSharingService } from 'src/app/services/datasharing.service';
import {HttpClient, HttpHeaders} from '@angular/common/http';
import { EsignserviceService } from 'src/app/_services/esignservice.service';
import { DomSanitizer } from "@angular/platform-browser";
//import { getDocument} from 'pdfjs-dist';
import { PDFDocument } from 'pdf-lib';

@Component({
  selector: 'app-esign-document',
  templateUrl: './esign-document.component.html',
  styleUrls: ['./esign-document.component.css']
})
export class EsignDocumentComponent implements OnInit {
  showFinishButton: boolean = false;
  showLoader: boolean = false;
  response:any;
	transientres:any;
	apiAccessPoint:any;
	transientDocumentId='';
	Agreements:any;
	AgreementId='';
	Document:any;
  isOpen=0
  documentId: number = 0;
  result:any;
  pagenumber:any;
  tab:any;
 
  constructor(private sanitizer: DomSanitizer, private viewSDKClient: ViewSDKClient, private fileUpload: FileUpload, private route: ActivatedRoute, private toastService: ToastServiceService, private dataSharingService: DataSharingService, private _route:ActivatedRoute,
    private esignserviceObj : EsignserviceService,
    private _http:HttpClient,
    private router:Router) { 
  }
  async ngOnInit(){
    this.route.queryParams.subscribe(params => {
      this.documentId = params['documentId'];
      this.tab = params['tab'];
  });
      if(this.documentId){
        this.showFinishButton = false;
          this.showLoader = true;
          var downloadUrl = await this.fileUpload.getDocumentDownloadURL(this.documentId.toString())
        //var sampleArr = this.base64ToArrayBuffer(filePath.data);
        let blob = await fetch(downloadUrl).then(r => r.blob());
        var file = new File([blob], "myfile.pdf", {type:"application/pdf", lastModified:new Date().getTime()});
      
        //Step 2: Read the file using file reader
    //var fileReader = new FileReader();  
 
            //Step 3:Read the file as ArrayBuffer
        //this.result = fileReader.readAsArrayBuffer(file);
        //Step 4:turn array buffer into typed array
        //var typedarray = new Uint8Array(this.result);
        //Step 5:pdfjs should be able to read this
        //const loadingTask = getDocument(typedarray);
        //loadingTask.promise.then((pdf:any) => {
            
           // this.pagenumber = pdf.numPages
            // The document is loaded here...
       // });

      
      const getNumPages =async (file:any) => {
        
        var buffer1 = await this.readFile(file);
        
        const pdf = await PDFDocument.load(buffer1);
      
        return pdf.getPages();
      }
      
      this.pagenumber = await getNumPages(file);
      
         const formData = new FormData();
         formData.append("File-Name","myfile");
         formData.append("File", file);
         
         this.esignserviceObj.getBaseUri().toPromise().then(
          res=>this.response=res
         ).then(data=>{
           this.apiAccessPoint = this.response.apiAccessPoint;
           this.getTransitdocument(formData);
         })
      }
      else{
        this.toastService.showWarning(StringConstants.toast.notFoundDocument, StringConstants.toast.empty);
      }
  }
  readFile(file:any):any{

    return new Promise((resolve, reject) => {
  
      const reader = new FileReader();
  
      reader.onload = () => resolve(reader.result);
      reader.onerror = error => reject(error);
  
      reader.readAsArrayBuffer(file);
    });
  }
//   base64ToArrayBuffer(base64:any) {
//     var binaryString = window.atob(base64);
//     var binaryLen = binaryString.length;
//     var bytes = new Uint8Array(binaryLen);
//     for (var i = 0; i < binaryLen; i++) {
//        var ascii = binaryString.charCodeAt(i);
//        bytes[i] = ascii;
//     }
//     return bytes;
//  }
  async cancelDocument() {
    this.showLoader = true;
    const Body={
      "state": "CANCELLED"
    }
    this.esignserviceObj.updateDocumanetform(this.apiAccessPoint,Body,this.AgreementId).subscribe(res => {
      
      this.router.navigate(['detail-assessment'], { queryParams: { tab: this.tab } });
    })
  }
  async finishDocument(){
    this.router.navigate(['detail-assessment'], { queryParams: { tab: this.tab } });
  }
  getTransitdocument(formData:any){
    this.esignserviceObj.transientDocuments(this.apiAccessPoint,formData).subscribe((response:any) => {
      this.transientres=response;
      this.transientDocumentId=this.transientres.transientDocumentId;
      this.getAgreeMentIdBytransientId();
        }
        )

  }
  formfield:any;
  getAgreeMentIdBytransientId(){
    const Body={
      "fileInfos": [
        {
        "transientDocumentId": this.transientDocumentId
        }
         ],
         "name": "demo.pdf",
        "participantSetsInfo": [
        {
        "memberInfos": [
          {
             "email": "softwaretestuser1234@gmail.com",
          }
          ],
          "order": 1,
          "role": "SIGNER"
        }
        ],
        "signatureType": "ESIGN",
        "state": "AUTHORING"
          }
    this.esignserviceObj.getAgreeMentIdBytransientId(this.apiAccessPoint,Body).subscribe(res => {
      this.Agreements=res;
      this.AgreementId = this.Agreements.id;
        this.esignserviceObj.getMembers(this.apiAccessPoint,this.AgreementId).subscribe(res => {
          
          this.members = res;
          setTimeout(() => {
            this.esignserviceObj.getDocumanetformfields(this.apiAccessPoint,this.AgreementId).subscribe(res => {
              let trueorfalse = true;
              for(var i=0;i<res.fields.length;i++){
                if(res.fields[i].inputType == "SIGNATURE"){
                  res.fields[i].required = "true";
                  res.fields[i].assignee = this.members.participantSets[0].id;
                  res.fields[i].contentType = "SIGNATURE";
                  delete res.fields[i].conditionalAction;
                  trueorfalse = false;
                  break;
                }
              }
              if(trueorfalse){
                for(var i=0;i<res.fields.length;i++){
                  if(res.fields[i].name == "SignatureImage" || res.fields[i].name == "Signature"){
                    res.fields[i].required = "true";
                    res.fields[i].assignee = this.members.participantSets[0].id;
                    res.fields[i].contentType = "SIGNATURE";
                    delete res.fields[i].conditionalAction;
                    res.fields[i].inputType = "SIGNATURE";
                    trueorfalse = false;
                  }
                  if(res.fields[i].name == "SignatureDate"){
                    const date = new Date();
                    const month = date.getUTCMonth() + 1;
                    res.fields[i].defaultValue = date.getUTCDate() + '/' + month + '/' + date.getUTCFullYear();
                  }
                }
              }
              if(trueorfalse){
                res.fields[res.fields.length] = 
                { 
                  "locations": [ 
                       { 
                        "height": 22.694992065429688,
                        "left": 81.47219848632812,
                        "pageNumber": this.pagenumber,
                        "top": 45,
                        "width": 253.7947998046875 
                       } 
                     ], 
                     "assignee": this.members.participantSets[0].id,
                     "alignment": "LEFT",
                     "recipientIndex": 1,
                     "backgroundColor": "",
                     "borderColor": "",
                     "borderStyle": "SOLID",
                     "borderWidth": 1,
                     "calculated": false,
                     "contentType": "SIGNATURE",
                     "defaultValue": "",
                     "displayFormat": "",
                     "displayFormatType": "DEFAULT",
                     "displayLabel": "",
                     "fontColor": "#0000ff",
                     "fontName": "Helvetica",
                     "fontSize": -1,
                     "inputType": "SIGNATURE",
                     "masked": false,
                     "maskingText": "*",
                     "maxLength": -1,
                     "maxValue": -1,
                     "minLength": -1,
                     "minValue": -1,
                     "name": "Sign",
                     "origin": "IMPORTED",
                     "radioCheckType": "CIRCLE",
                     "readOnly": false,
                     "required": true,
                     "tooltip": "",
                     "urlOverridable": false,
                     "validation": "NONE",
                     "validationErrMsg": "",
                     "valueExpression": "",
                     "visible": true 
                    
              }
              }
              this.esignserviceObj.updateDocumanetformfields(this.apiAccessPoint,res,this.AgreementId).subscribe(res => {
                this.getDocumanetforSign();
              })
            });
          }, 2000);
        })
      });
  }
  members:any;
  displayIframe:any = false;
  documentfinalUrl:any;
  getDocumanetforSign()
    {
        
        this.esignserviceObj.getDocumanetforSign(this.apiAccessPoint,this.AgreementId).toPromise().then(res=>this.Document=res).then(data=>
          {
           var DocumentData = this.Document.signingUrlSetInfos
           let documentfinalUrl = DocumentData[0].signingUrls[0].esignUrl
           this.isOpen=1
           
           this.documentfinalUrl = this.sanitizer.bypassSecurityTrustResourceUrl(documentfinalUrl);
           //window.open(documentfinalUrl);
           this.displayIframe = true;
           this.showLoader = false;
           debugger
           this.fileUpload.UpdateDocumentAgreementIdById(this.documentId, this.AgreementId).subscribe(async event => {
            debugger
            if(event){
              this.showFinishButton = true;
            }
          },
            (err) => {
              console.log(StringConstants.toast.uploadError, err);
            }, () => {
            }
          )
          return data;
         })
  }   
}
