import { Component, ViewChild, OnInit, ElementRef, AfterViewInit } from '@angular/core';
import { StringConstants } from 'src/assets/constants/string.constants';
//import WebViewer from '@pdftron/pdfjs-express';
declare const WebViewer: any;


@Component({
    selector: 'web-viewer',
    templateUrl: './webviewer.component.html',
    styleUrls: ['./webviewer.component.css']
})



export class WebViewerComponent implements OnInit, AfterViewInit {
    WebViewer=StringConstants.Common.WebViewer;
    @ViewChild('viewer') viewerRef!: ElementRef;



    wvInstance: any;
    ViewInstance: any;

    ngOnInit() {
        this.wvDocumentLoadedHandler = this.wvDocumentLoadedHandler.bind(this);
    }

    wvDocumentLoadedHandler(): void {
        // // you can access docViewer object for low-level APIs
        // const docViewer = this.wvInstance;
        // const annotManager = this.wvInstance.annotManager;
        // // and access classes defined in the WebViewer iframe
        // const { Annotations } = this.wvInstance;
        // const rectangle = new Annotations.RectangleAnnotation();
        // rectangle.PageNumber = 1;
        // rectangle.X = 100;
        // rectangle.Y = 100;
        // rectangle.Width = 250;
        // rectangle.Height = 250;
        // rectangle.StrokeThickness = 5;
        // rectangle.Author = annotManager.getCurrentUser();
        // annotManager.addAnnotation(rectangle);
        // annotManager.drawAnnotations(rectangle.PageNumber);
        // // see https://pdfjs.express/api/WebViewerInstance.html for the full list of low-level APIs
    }

    ngAfterViewInit(): void {
        // The following code initiates a new instance of WebViewer.
        WebViewer({
            path: '../wv-resources/lib',
            //initialDoc: 'https://pdftron.s3.amazonaws.com/downloads/pl/webviewer-demo.pdf'
            initialDoc: 'http://localhost/ActiveAssistAPI/api/FileUpload/PreviewProgramDocument?PgrmdocId=4'
        }, this.viewerRef.nativeElement).then((instance: { openElement: (arg0: string) => void; docViewer: { on: (arg0: string, arg1: { (): void; (): void; }) => void; }; }) => {
            this.wvInstance = instance;
            this.ViewInstance = instance;
            this.ViewInstance.UI.disableElements(['toolbarGroup-Edit']);
            this.ViewInstance.UI.disableElements(['toolbarGroup-View']);
            this.ViewInstance.UI.disableElements(['toolbarGroup-Annotate']);
            this.ViewInstance.UI.disableElements(['toolbarGroup-Insert']);
            this.ViewInstance.UI.disableElements(['toolbarGroup-Shapes']);
            this.ViewInstance.UI.disableElements(['toolbarGroup-Forms']);
            this.ViewInstance.UI.disableTools(['AnnotationCreateFreeText', 'AnnotationCreateFreeText']);
            // now you can access APIs through this.webviewer.getInstance()
            // instance.openElement('notesPanel');
            // see https://pdfjs.express/api/WebViewerInstance.html
            // for the full list of APIs
            // or listen to events from the viewer element
            this.viewerRef.nativeElement.addEventListener('pageChanged', (e: { detail: [any]; }) => {
                const [pageNumber] = e.detail;
                console.log(`Current page is ${pageNumber}`);
            });
            // or from the docViewer instance
            instance.docViewer.on('annotationsLoaded', () => {
                console.log('annotations loaded');
            });
            instance.docViewer.on('documentLoaded', this.wvDocumentLoadedHandler)
        })
    }
}