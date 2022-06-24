import { Component, OnInit, EventEmitter, Output } from '@angular/core';
import { BsModalService, BsModalRef } from 'ngx-bootstrap/modal';
import { StringConstants } from 'src/assets/constants/string.constants';
import { ToastServiceService } from 'src/app/services/toast-service.service';

@Component({
  selector: 'app-address-verification',
  templateUrl: './address-verification.component.html',
  styleUrls: ['./address-verification.component.css']
})
export class AddressVerificationComponent implements OnInit {
  addressSelected:any = '';
  @Output() action = new EventEmitter();
  addressData:any;
  addressSuggested:any;
  isDisable:any;
  constructor( private modalService: BsModalService, private toastService: ToastServiceService) { }
  ngOnInit(): void {
    this.isDisable = true;

  }
  addressValChange(event:any){
    this.isDisable = false;
    document.getElementById('success')?.classList.add('btn-success');
    this.addressSelected = event.target.value;
  }
  successPopup(){
    
    if(this.addressSelected == ''){
      this.toastService.showWarning(StringConstants.toast.selectRadio, StringConstants.toast.empty);
    }
    else{
      this.action.emit(this.addressSelected);
      this.modalService.hide();
    }
  }
  cancelPopup(){
    this.modalService.hide();
  }
}
