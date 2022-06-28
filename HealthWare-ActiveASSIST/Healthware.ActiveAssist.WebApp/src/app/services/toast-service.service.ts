import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
@Injectable({
  providedIn: 'root'
})
export class ToastServiceService {
  constructor(private toastr: ToastrService) { }
  showSuccess(message: string | undefined, title: string | undefined) {
    this.toastr.success(message, title)
  }
  showSuccessWithTime(message: string | undefined, title: string | undefined){
    this.toastr.success(message, title, { timeOut: 3000 })
  }
  showError(message: string | undefined, title: string | undefined) {
    this.toastr.error(message, title, { timeOut: 3000 })
  }
  showInfo(message: string | undefined, title: string | undefined) {
    this.toastr.info(message, title)
  }
  showWarning(message: string | undefined, title: string | undefined) {
    this.toastr.warning(message, title, { timeOut: 2500 })
  }
}