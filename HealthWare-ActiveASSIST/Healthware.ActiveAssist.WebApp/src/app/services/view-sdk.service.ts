import { Injectable } from '@angular/core';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class ViewSDKClient {
  constructor(private dataSharingService: DataSharingService) {
  }
  readyPromise: Promise<any> = new Promise((resolve): void => {
    if (window.AdobeDC) {
      resolve(null);
    } else {
      /* Wait for Adobe Document Services PDF Embed API to be ready */
      document.addEventListener('adobe_dc_view_sdk.ready', () => {
        resolve(null);
      });
    }
  });
  adobeDCView: any;
  viewerFile!: File;
  programID: string = "";
  ready() {
    return this.readyPromise;
  }
  viewerConfig = {
    showAnnotationTools: true,
    enableFormFilling: true,
    showLeftHandPanel: true,
    showDownloadPDF: true,
    showPrintPDF: true,
    showPageControls: true,
    dockPageControls: true,
    defaultViewMode: 'FIT_WIDTH'
  };
  previewFile(divId: string, documentUrl: string, documentName: string, programID: string) {
    const config: any = {
      /* Pass your registered client id */
      clientId: environment.PDFSDKClientID,
    };
    if (divId) { /* Optional only for Light Box embed mode */
      /* Pass the div id in which PDF should be rendered */
      config.divId = divId;
    }
    /* Initialize the AdobeDC View object */
    this.adobeDCView = new window.AdobeDC.View(config);

    /* Invoke the file preview API on Adobe DC View object */
    const previewFilePromise = this.adobeDCView.previewFile({
      /* Pass information on how to access the file */
      content: {
        /* Location of file where it is hosted */
        location: {
          url: documentUrl,
          /*
          If the file URL requires some additional headers, then it can be passed as follows:-
          headers: [
              {
                  key: '<HEADER_KEY>',
                  value: '<HEADER_VALUE>',
              }
          ]
          */
        },
      },
      /* Pass meta data of file */
      metaData: {
        /* file name */
        fileName: documentName,
        /* file ID */
        id: '6d07d124-ac85-43b3-a867-36930f502ac6',
      }
    }, this.viewerConfig);
    this.registerSaveApiHandler();
    if (programID)
      this.programID = programID;
    return previewFilePromise;
  }
  previewFileUsingFilePromise(divId: string, filePromise: Promise<string | ArrayBuffer>, fileName: any) {
    /* Initialize the AdobeDC View object */
    this.adobeDCView = new window.AdobeDC.View({
      /* Pass your registered client id */
      clientId: environment.PDFSDKClientID,
      /* Pass the div id in which PDF should be rendered */
      divId,
    });
    /* Invoke the file preview API on Adobe DC View object */
    this.adobeDCView.previewFile({
      /* Pass information on how to access the file */
      content: {
        /* pass file promise which resolve to arrayBuffer */
        promise: filePromise,
      },
      /* Pass meta data of file */
      metaData: {
        /* file name */
        fileName
      }
    }, {});
    this.registerSaveApiHandler();
  }
  registerSaveApiHandler() {
    /* Define Save API Handler */
    const saveApiHandler = (metaData: any, content: any, options: any) => {
      return new Promise((resolve) => {
        const blob = new Blob([content], { type: 'application/pdf' });
        var myFile = new File([blob], metaData.fileName + ".pdf");
        if (myFile.size > 0) {
          this.viewerFile = myFile;
          this.dataSharingService.esignFileUpload.next([myFile, this.programID]);
        }
      });
    };
    this.adobeDCView.registerCallback(
      window.AdobeDC.View.Enum.CallbackType.SAVE_API,
      saveApiHandler, {});
  }
  registerEventsHandler() {
    /* Register the callback to receive the events */
    this.adobeDCView.registerCallback(
      /* Type of call back */
      window.AdobeDC.View.Enum.CallbackType.EVENT_LISTENER,
      /* call back function */
      (event: any) => {
        console.log(event);
      },
      /* options to control the callback execution */
      {
        /* Enable PDF analytics events on user interaction. */
        enablePDFAnalytics: true,
      }
    );
  }
}