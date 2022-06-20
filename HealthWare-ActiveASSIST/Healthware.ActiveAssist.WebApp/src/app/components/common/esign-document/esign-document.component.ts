import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FileUpload } from 'src/app/services/fileupload.service';
import { ViewSDKClient } from 'src/app/services/view-sdk.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { StringConstants } from 'src/assets/constants/string.constants';
import { DataSharingService } from 'src/app/services/datasharing.service';

@Component({
  selector: 'app-esign-document',
  templateUrl: './esign-document.component.html',
  styleUrls: ['./esign-document.component.css']
})
export class EsignDocumentComponent implements OnInit {
  showLoader: boolean = false;
  documentId: number = 0;
  programId: string = '';
  documentName?: string;
  currentTheme: any;
  currentblob:any;
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
  constructor(private viewSDKClient: ViewSDKClient, private fileUpload: FileUpload, private route: ActivatedRoute, private toastService: ToastServiceService, private dataSharingService: DataSharingService, private router: Router) { 
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
    this.fileUpload.uploadedDocumentId$.subscribe(response => {
          //this.toastService.showWarning(StringConstants.toast.submitEform, StringConstants.toast.empty);
          this.showLoader = false;
          this.toastService.showSuccess(StringConstants.toast.formUpload, StringConstants.toast.empty);
          window.location.reload();
          //this.router.navigate(['esign-document'], { queryParams: { documentId: this.documentId, documentName: this.documentName, programId: this.programId }});

    });
    this.dataSharingService.esignFileUpload.subscribe(async e =>{
      if(e !== null && e[0].size > 0 && this.programId !== ""){
        var saveResponse = await this.fileUpload.UploadProgramDocument(this.assessmentId, e[1], this.programId, e[0], true);
        this.showLoader = true;
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
          var url = this.fileUpload.getDocumentDownloadURL(this.documentId.toString());
          this.currentblob = url;
          if(url && this.programId)
          this.viewSDKClient.previewFile('pdf-div', url, this.documentName ?? "Pdfdocument", this.programId);
      }
      else{
        this.toastService.showWarning(StringConstants.toast.notFoundDocument, StringConstants.toast.empty);
      }
      
    });
  }
  async cancelDocument() {
    this.router.navigate(['detail-assessment'], { queryParams: { tab: 5 } });

  }
  async closeDocument() {
    this.router.navigate(['detail-assessment'], { queryParams: { tab: 5 } });

  }
  async closeSign(){
    this.closeModal.nativeElement.click()
  }
  async finishDocument(){
    // var saveResponse = await this.fileUpload.CompleteUploadedDocument(this.documentId.toString());
    // if(saveResponse)
      this.router.navigate(['detail-assessment'], { queryParams: { tab: 5 } });
    
  }
  async clearCanvas(){
    this.canvas = this.canvasapp.canvas;
    const canvasEl: HTMLCanvasElement = this.canvas.nativeElement;
    var context = canvasEl.getContext('2d');
    context?.clearRect(0, 0, canvasEl.width, canvasEl.height);
  }
  async AddSign(event:any, inputType:any){
    var imageBlob: BlobPart='';
    var signaturetext: string = '';
    if(inputType=='text')
    {
      signaturetext= this.sign;
    }
    else{
      this.canvas = this.canvasapp.canvas;
      const canvasEl: HTMLCanvasElement = this.canvas.nativeElement;
      var context = canvasEl.getContext('2d');
      var image = canvasEl.toDataURL("image/png").replace("image/png", "image/octet-stream");  // here is the most important part because if you dont replace you will get a DOM 18 exception.
      imageBlob = this.blobCreationFromURL(image);
      window.location.href=image;
    }
    var docu = await this.fileUpload.uploadSignature(new File([],""), new File([imageBlob], "Signature.png"), this.documentId.toString(), signaturetext)
    this.closeModal.nativeElement.click();

  }
  blobCreationFromURL(inputURI: any) {
  
    var binaryVal;

    // mime extension extraction
    var inputMIME = inputURI.split(',')[0].split(':')[1].split(';')[0];

    // Extract remaining part of URL and convert it to binary value
    if (inputURI.split(',')[0].indexOf('base64') >= 0)
        binaryVal = atob(inputURI.split(',')[1]);

    // Decoding of base64 encoded string
    else
        binaryVal = unescape(inputURI.split(',')[1]);

    // Computation of new string in which hexadecimal
    // escape sequences are replaced by the character 
    // it represents

    // Store the bytes of the string to a typed array
    //var blobArray = [];

     // write the bytes of the string to an ArrayBuffer
  var ab = new ArrayBuffer(binaryVal.length);

  // create a view into the buffer
  var ia = new Uint8Array(ab);
    for (var index = 0; index < binaryVal.length; index++) {
        //blobArray.push(binaryVal.charCodeAt(index));
        ia[index] = binaryVal.charCodeAt(index);
    }

    return new Blob([ab], {
        type: inputMIME
    });
}
  // async loadDocumentOpen(documentName: string, programDocumentId: string, documentId: string, programId: string) {

  //   this.CurrentProgramDocumentId = programDocumentId;
  //   var data: string;
  //   var currentDocumentId;

  //   const fileDetails: FileDetails = {
  //     AssessmentId: +(this.assessmentId),
  //     UserId: +(sessionStorage.getItem("patientId")!),
  //     HouseHoldMemberId: 0,
  //     ProgramId: programId,
  //     DocumentTitle: "programdocument",
  //     DocumentCategory: "Eforms",
  //     DocumentType: "Eforms",
  //     ProgramDocumentId: +(programDocumentId),
  //     DocumentName: documentName
  //   };
  //   this.showLoader = true;

  //   //this.getProgramDocument(this.assessmentId, programId, programDocumentId, documentName);
  //   var result = await this.http.post<any>(environment.apiBaseUrl + ApiConstants.url.GetAssessmentProgramDocument, fileDetails).toPromise();
  //   if (result) {
  //     this.formattedDocumentId = result.data;
  //     this.previousFile = result.nextAction;

  //     if (documentId == "0") {
  //       data = this.fileUpload.GetProgramDocumentDownloadURL(programDocumentId);
  //       currentDocumentId = programDocumentId;
  //       //Get call to fetch the document using ProgramDocumentId
  //       if (this.documentInstance)
  //         this.documentInstance.loadDocument('/assets/ProgramDocuments/' + documentName.replace(/\s+/g, '_') + '.pdf');
  //     }
  //     else {
  //       data = this.fileUpload.getDocumentDownloadURL(documentId);
  //       currentDocumentId = documentId;
  //       //Get call to fetch the document using documentId
  //       // if (this.documentInstance)
  //       //   this.documentInstance.loadDocument(data, { filename: documentName });
  //     }

  //     this.viewSDKClient.ready().then(() => {
  //       var url = this.fileUpload.getDocumentDownloadURL(this.formattedDocumentId);
  //       this.viewSDKClient.previewFile('pdf-div', url, documentName, programId);
  //       this.showLoader = false;
  //     });

  //     if (this.annonationInstance && documentId != "0") {
  //       //this.annonationInstance.enableReadOnlyMode();
  //       this.annonationInstance.disableFreeTextEditing();
  //       this.annonationInstance.flatten = true;
  //       //this.annonationInstance.getFieldManager
  //     }

  //     this.documentName = documentName;
  //     this.router.navigate(['esign-document']);
  //   }
  // }
}
