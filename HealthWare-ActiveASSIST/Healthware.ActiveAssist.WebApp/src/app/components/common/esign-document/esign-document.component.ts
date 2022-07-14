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

@Component({
  selector: 'app-esign-document',
  templateUrl: './esign-document.component.html',
  styleUrls: ['./esign-document.component.css']
})
export class EsignDocumentComponent implements OnInit {
  response:any;
	transientres:any;
	apiAccessPoint:any;
	filename='';
  file:any;
	transientDocumentId='';
	Agreements:any;
	AgreementId='';
	Document:any;
  isOpen=0
  documentId: number = 0;
  programId: string = '';
  documentName?: string;
  currentTheme: any;
  assessmentId: any;
  @ViewChild('closeSignModal') 
  closeModal: ElementRef | any;
  formValues = [
    {
      value: 'aaa'
    },
    {
      value: 'bbb'
    },
    {
      value: 'ccc'
    }
  ];
  sign = "sign";
  @ViewChild('canvas')
  public canvasapp: any;
  public canvas!: ElementRef;
  log = (value: any) => console.log(value.value);
  constructor(private sanitizer: DomSanitizer, private viewSDKClient: ViewSDKClient, private fileUpload: FileUpload, private route: ActivatedRoute, private toastService: ToastServiceService, private dataSharingService: DataSharingService, private _route:ActivatedRoute,
    private esignserviceObj : EsignserviceService,
    private _http:HttpClient,
    private router:Router) { 
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.fileUpload.uploadedDocumentId$.subscribe(response => {
          //this.toastService.showWarning(StringConstants.toast.submitEform, StringConstants.toast.empty);
          this.toastService.showSuccess(StringConstants.toast.formUpload, StringConstants.toast.empty);
          window.location.reload();
          //this.router.navigate(['esign-document'], { queryParams: { documentId: this.documentId, documentName: this.documentName, programId: this.programId }});

    });
    this.dataSharingService.esignFileUpload.subscribe(async e =>{
      if(e !== null && e[0].size > 0 && this.programId !== ""){
        var saveResponse = await this.fileUpload.UploadProgramDocument(this.assessmentId, e[1], this.programId, e[0], true);
        
        this.dataSharingService.esignFileUpload.next([(new File([],"")),""]);
      }
      else{
        console.log('File is empty');
      }
    },(error) => {console.log("error"+error); });
  }

  ngOnInit(): void {
    this.route.queryParams.subscribe(params => {
      this.documentId = params['documentId'];
      this.documentName = params['documentName'];
      this.programId = params['programId'];
      this.assessmentId = sessionStorage.getItem("assessmentId");
  });
    this.viewSDKClient.ready().then(() => {
      if(this.documentId){
        
          this.fileUpload.getFileDownloadURL(this.documentId.toString()).subscribe(async (filePath: any) => {
            
            if (filePath.data!=null) {
        
        var sampleArr = this.base64ToArrayBuffer(filePath.data);
        var blob = new Blob([sampleArr], {type: "application/pdf"});
        var file = new File([blob], "myfile.pdf", {type:"application/pdf", lastModified:new Date().getTime()});
         const formData = new FormData();
         formData.append("File-Name","myfile");
         formData.append("File", file);
         
         this.esignserviceObj.getBaseUri().toPromise().then(
          res=>this.response=res
         ).then(data=>{
           this.apiAccessPoint = this.response.apiAccessPoint;
           this.getTransitdocument(formData);
         })


         console.log(file);
          }
          }, (error) => {
            console.log(error)
          }); 

      }
      else{
        this.toastService.showWarning(StringConstants.toast.notFoundDocument, StringConstants.toast.empty);
      }
      
    });
  }
  base64ToArrayBuffer(base64:any) {
    var binaryString = window.atob(base64);
    var binaryLen = binaryString.length;
    var bytes = new Uint8Array(binaryLen);
    for (var i = 0; i < binaryLen; i++) {
       var ascii = binaryString.charCodeAt(i);
       bytes[i] = ascii;
    }
    return bytes;
 }
  async cancelDocument() {
    this.router.navigate(['detail-assessment'], { queryParams: { tab: 5 } });
  }
  async closeDocument() {
    this.router.navigate(['detail-assessment'], { queryParams: { tab: 5 } });

  }
  async finishDocument(){
    
    this.router.navigate(['detail-assessment'], { queryParams: { tab: 5 } });
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
          "email": "softwaretestuser1234@gmail.com"
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
      setTimeout(() => {
      this.esignserviceObj.getDocumanetformfields(this.apiAccessPoint,this.AgreementId).subscribe(res => {
        res.fields[50].inputType = "SIGNATURE";
        res.fields[50].required = "true";
        delete res.fields[50].conditionalAction;
        res.fields[52] = 
          { 
            "locations": [ 
                 { 
                  "height": 22.694992065429688,
                  "left": 81.47219848632812,
                  "pageNumber": 2,
                  "top": 45,
                  "width": 253.7947998046875 
                 } 
               ], 
               "alignment": "LEFT",
               "backgroundColor": "",
               "borderColor": "",
               "borderStyle": "SOLID",
               "borderWidth": 1,
               "calculated": false,
               "contentType": "DATA",
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
        res.fields[53] = 
          { 
            "locations": [ 
                 { 
                  "height": 22.694992065429688,
                  "left": 81.47219848632812,
                  "pageNumber": 1,
                  "top": 45,
                  "width": 253.7947998046875 
                 } 
               ], 
               "alignment": "LEFT",
               "backgroundColor": "",
               "borderColor": "",
               "borderStyle": "SOLID",
               "borderWidth": 1,
               "calculated": false,
               "contentType": "DATA",
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
               "name": "Signature",
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
        const date = new Date();
        const month = date.getUTCMonth() + 1;
        res.fields[51].defaultValue = date.getUTCDate() + '/' + month + '/' + date.getUTCFullYear();
        this.esignserviceObj.updateDocumanetformfields(this.apiAccessPoint,res,this.AgreementId).subscribe(res => {
          this.getDocumanetforSign();
        })
      });

      }, 6000)
      });
  }
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
           this.fileUpload.UpdateDocumentAgreementIdById(this.documentId, this.AgreementId).subscribe(async event => {
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
