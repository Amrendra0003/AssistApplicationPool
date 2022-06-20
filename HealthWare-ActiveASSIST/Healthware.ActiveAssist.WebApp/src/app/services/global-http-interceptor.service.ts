import { Injectable } from "@angular/core";
import { HttpEvent, HttpHandler, HttpRequest } from '@angular/common/http';
import { Observable, of, throwError } from "rxjs";
import { catchError } from 'rxjs/operators';
import { Router } from "@angular/router";
import { DataSharingService } from "./datasharing.service";
import { ToastrService } from "ngx-toastr";
import { StringConstants } from 'src/assets/constants/string.constants';
@Injectable({
  providedIn: 'root'
})
export class GlobalHttpInterceptorService {
  constructor(public router: Router, private dataSharingService: DataSharingService, private toastr: ToastrService) {
  }
  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(req).pipe(
      catchError((error) => {
        if (error && error.status == 401) {
          sessionStorage.clear();
          this.dataSharingService.showUserNameInHeader.next(false);
          this.dataSharingService.beginFlag.next(false);
          this.dataSharingService.logoutTriggered.next(true);
          this.router.navigate(['login']);
          return of(error);
        }
        else if (error && error.status == 500) {
          this.toastr.error(StringConstants.exceptionMessages.serviceErrorMessage);
          return of(error);
        }
        else if (error && error.status == 504) {
          this.toastr.error(StringConstants.exceptionMessages.HWSServiceErrorMessage);
          return of(error);
        }
        else if (error && error.status == 403) {
          this.toastr.error(StringConstants.exceptionMessages.NotAuthorizedErrorMessage);
          return of(error);
        }
        else
          return throwError(error);
      })
    )
  }
}