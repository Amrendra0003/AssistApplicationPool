import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { StringConstants } from 'src/assets/constants/string.constants';

@Component({
    selector: 'app-support',
    templateUrl: './support.component.html',
    styleUrls: ['./support.component.css']
})
export class SupportComponent implements OnInit {
    email: string = "";
    activateUser: string = "false";
    messageInfo: string = StringConstants.landingPage.messageInfo;
    messageTitle: string = StringConstants.landingPage.messageTitle;
    buttonLabel: string = StringConstants.landingPage.buttonLabel;
    TodayCost = StringConstants.appLanding.TodayCost;
    message1 = StringConstants.appLanding.message1;
    message2 = StringConstants.appLanding.message2;
    constructor(private dashboardService: DashboardService, private dataSharingService: DataSharingService, private router: Router) {
    }
    ngOnInit() {
        this.dataSharingService.allowLanding.next(false);
        this.email = (sessionStorage.getItem('tenantEmail')!);
        this.dataSharingService.showloginButton.next(false);
        this.activateUser = ((sessionStorage.getItem('showAccount')!) == "true" ? "true" : "false");
    }
    createNewAccount() {
        this.router.navigate(['activate-user']);
    }
}