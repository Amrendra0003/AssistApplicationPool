import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DashboardService } from 'src/app/services/dashboard.service';
import { DataSharingService } from 'src/app/services/datasharing.service';
import { StringConstants } from 'src/assets/constants/string.constants';
@Component({
  selector: 'app-active-account',
  templateUrl: './active-account.component.html',
  styleUrls: ['./active-account.component.css']
})
export class ActiveAccountComponent implements OnInit {
  patientEmail: any;
  patientName: any;
  infoMessage: any;
  isSuccessFlag: any;
  currentTheme: any;
  Dear = StringConstants.activeAccount.Dear;
  YourEmail = StringConstants.activeAccount.YourEmail;
  Verified = StringConstants.activeAccount.Verified;
  ExpiredMsg = StringConstants.activeAccount.ExpiredMsg;
  constructor(private dashboardService: DashboardService, private dataSharingService: DataSharingService, private router: Router,) {
    this.dataSharingService.changeTheme.subscribe(value => {
      if (value == "")
        this.currentTheme = sessionStorage.getItem("themeSettings");
      else
        this.currentTheme = value;
    });
  }
  ngOnInit() {
    this.dataSharingService.hideVaForProfile.next(false);
    const token = this.router.url.split('=')[1]
    this.dashboardService.ValidateEmailToken(token).subscribe((response: any) => {
      
      if (response.wasSuccessful) {
        this.patientEmail = response.data.emailAddress,
          this.patientName = response.data.patientName
        this.isSuccessFlag = true;
        
      }
    }, (error) => {
      this.isSuccessFlag = false;
      console.log(error)
    });
  }
}
