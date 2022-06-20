import { Component, OnInit } from '@angular/core';
import { StringConstants } from 'src/assets/constants/string.constants';

@Component({
  selector: 'app-form-dialog',
  templateUrl: './form-dialog.component.html',
  styleUrls: ['./form-dialog.component.css']
})
export class FormDialogComponent implements OnInit {
  formDialogWorks=StringConstants.Common.formDialogWorks;
  constructor() { }
  ngOnInit(): void {
  }
}
