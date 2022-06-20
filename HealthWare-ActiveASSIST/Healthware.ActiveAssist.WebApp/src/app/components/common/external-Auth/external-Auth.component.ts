import { DatePipe } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { Router } from '@angular/router';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { LoginService } from 'src/app/services/login.service';
import { TenantService } from 'src/app/services/tenant.service';
import { ToastServiceService } from 'src/app/services/toast-service.service';
import { QuickAssessmentService } from 'src/app/services/quick-assessment.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
    selector: 'app-external-Auth',
    templateUrl: './external-Auth.component.html',
    styleUrls: ['./external-Auth.component.css']
})
export class ExternalAuthComponent implements OnInit {
    show: any = true;
    tenantId: any;
    pleasewait = StringConstants.common.pleasewait;
    linkExpireMsg = StringConstants.common.linkExpiredMsg;
    constructor(private quickAssessmentService: QuickAssessmentService, private loginService: LoginService, private formbuilder: FormBuilder, private toastService: ToastServiceService, private tenentService: TenantService, private router: Router, private datepipe: DatePipe,
        private dataSharingService: DataSharingService) {
    }
    ngOnInit() {
        this.dataSharingService.allowLanding.next(false);
        if ((sessionStorage.getItem('isLoggedIn')!) == 'true') {
            this.clearsessionStorageAndNavigateLoginPage();
        }
        this.loginService.getTenantBySubDomain(window.location.host).subscribe(async (result: any) => {
            this.tenantId = result.data;
            sessionStorage.setItem('tenant', this.tenantId);
            console.log('External Auth');
            this.navigateUser();
        });
    }
    clearsessionStorageAndNavigateLoginPage() {
        var userId = (sessionStorage.getItem('userId')!);
        this.loginService.Logout(userId).subscribe(async (result: any) => {
          if (result.wasSuccessful) {
            sessionStorage.clear();
            this.dataSharingService.showUserNameInHeader.next(false);
            this.dataSharingService.beginFlag.next(false);
            this.dataSharingService.logoutTriggered.next(true);
            this.dataSharingService.showloginButton.next(false);
          }
        }, (error) => {
          console.log(error);
          if (error.error.errors[0] == StringConstants.toast.activeUser) {
            sessionStorage.clear();
            this.dataSharingService.showUserNameInHeader.next(false);
            this.dataSharingService.beginFlag.next(false);
            this.dataSharingService.logoutTriggered.next(true);
          }
        });
      }
    navigateUser() {
        var urlText = this.router.url.split('=')[1];
        var token = decodeURIComponent(urlText);
        console.log(token);
        this.quickAssessmentService.validateUserAccount(token).subscribe((result: any) => {
            if (result.wasSuccessful) {
                this.show = true;
                console.log(result);
                var path = result.data.landingId;
                var email = result.data.email;
                switch (path) {
                    case 'P1': {
                        sessionStorage.setItem('tenantEmail', email);
                        sessionStorage.setItem('showText', 'true');
                        this.router.navigate(['support']);
                    } break;

                    case 'P2': {
                        sessionStorage.setItem('emailAuth', email);
                        sessionStorage.setItem('showAccount', "true");
                        this.router.navigate(['support']);
                    } break;

                    case 'P3': {
                        this.router.navigate(['login']);
                    } break;

                    case 'P4': {
                        this.router.navigate(['']);
                    } break;

                    case 'P5': {
                        this.router.navigate(['login']);
                    } break;
                }
            }
            else {
                this.show = false;
            }
        }, (error) => {
            console.log(error);
            this.show = false;
        });
    }
}