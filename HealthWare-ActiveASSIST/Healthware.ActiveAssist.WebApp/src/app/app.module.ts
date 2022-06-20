import { NgModule, CUSTOM_ELEMENTS_SCHEMA } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTabsModule } from '@angular/material/tabs';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatCardModule } from '@angular/material/card';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';
import { MatGridListModule } from '@angular/material/grid-List';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatMenuModule } from '@angular/material/menu';
import { MatDialogModule } from '@angular/material/dialog';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HeaderComponent } from './components/common/header/header.component';
import { LoginComponent } from './components/common/login/login.component';
import { DashboardDetailsComponent } from './components/patient/patient-dashboard/patient-dashboard.component';
import { DashboardQuickAssessmentComponent } from './components/common/detail-assessment/dashboard-quick-assessment/dashboard-quick-assessment.component';
import { DashboardGuarantorComponent } from './components/common/detail-assessment/dashboard-guarantor/dashboard-guarantor.component';
import { OtpScreenComponent } from './components/common/otp-screen/otp-screen.component';
import { ResetPasswordComponent } from './components/common/reset-password/reset-password.component';
import { AppLandingComponent } from './components/common/app-landing/app-landing.component';
import { CreateAccountComponent } from './components/common/create-account/create-account.component';
import { DashboardHomeAddressComponent } from './components/common/detail-assessment/dashboard-home-address/dashboard-home-address.component';
import { DashboardWorkAddressComponent } from './components/common/detail-assessment/dashboard-work-address/dashboard-work-address.component';
import { DashboardPersonalComponent } from './components/common/detail-assessment/dashboard-personal/dashboard-personal.component';
import { DashboardHouseholdComponent } from './components/common/detail-assessment/dashboard-household/dashboard-household.component';
import { DetailAssessmentComponent } from './components/common/detail-assessment/detail-assessment.component';
import { ToastrModule } from 'ngx-toastr';
import { MatExpansionModule } from '@angular/material/expansion';
import { NgxMaskModule } from 'ngx-mask';
import { OverlayModule } from '@angular/cdk/overlay';
import { ShowMonthlyIncomePipe } from './components/common/detail-assessment/dashboard-household/show-monthly-income.pipe';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { DashboardApplicationFormsComponent } from './components/common/detail-assessment/dashboard-application-forms/dashboard-application-forms.component';
import { FormDialogComponent } from './components/common/form-dialog/form-dialog.component';
import { ShowResourceValuePipe } from './components/common/detail-assessment/dashboard-household/show-resource-value.pipe';
import { MatTooltipModule } from '@angular/material/tooltip';
import { DashboardVerificationComponent } from './components/common/detail-assessment/dashboard-verification/dashboard-verification.component';
import { ActiveAccountComponent } from './components/common/active-account/active-account.component';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { FormatDocumentType } from './components/common/detail-assessment/dashboard-verification/dashboard-verification.pipe';
import { CountdownModule } from 'ngx-countdown';
import { MatRadioModule } from '@angular/material/radio';
import { DashboardContactPreferenceComponent } from './components/common/detail-assessment/dashboard-contact-preference/dashboard-contact-preference.component';
import { NumberPickerModule } from 'ng-number-picker';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { DashboardAdvocateComponent } from './components/advocate/dashboard-advocate/dashboard-advocate.component';
import { StartAssessmentComponent } from './components/advocate/start-assessment/start-assessment.component';
import { InsuranceComponent } from './components/advocate/insurance/insurance.component';
import { HouseholdComponent } from './components/advocate/household/household.component';
import { GeneralQuestionsComponent } from './components/advocate/general-questions/general-questions.component';
import { VerificationComponent } from './components/advocate/verification/verification.component';
import { DemographicsComponent } from './components/advocate/demographics/demographics.component';
import { PaymentOptionsComponent } from './components/patient/payment-options/payment-options.component';
import { ProgramsComponent } from './components/advocate/programs/programs.component';
import { ChangePasswordComponent } from './components/common/profile/change-password/change-password.component';
import { QuickAssessmentComponent } from './components/advocate/quick-assessment/quick-assessment.component';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { SpinnerOverlayComponent } from './components/common/spinner-overlay/spinner-overlay.component';
import { ProfileComponent } from './components/common/profile/profile.component';
import { ProfileSettingComponent } from './components/common/profile/profile-setting/profile-setting.component';
import { BackButtonDisableModule } from 'angular-disable-browser-back-button';
import { AdvocateSummaryPanelComponent } from './components/advocate/advocate-summary-panel/advocate-summary-panel.component';
import { DashboardProgramsComponent } from './components/common/detail-assessment/dashboard-programs/dashboard-programs.component';
import { DashboardFormsComponent } from './components/common/detail-assessment/dashboard-forms/dashboard-forms.component';
import { AccountComponent } from './components/common/account/account.component';
import { WebViewerComponent } from './webviewer/webviewer.component';
import { PagenotfoundComponent } from './components/common/pagenotfound/pagenotfound.component';
import { SignaturePadModule } from 'angular2-signaturepad';
import { DocumentViewerModule } from '@txtextcontrol/tx-ng-document-viewer';
import { DynamicQuestionsComponent } from './components/patient/dynamic-questions/dynamic-questions.component';
import { DatePipe } from '@angular/common';
import { GlobalHttpInterceptorService } from './services/global-http-interceptor.service';
import { NgxPermissionsModule } from 'ngx-permissions';
import { SetPasswordComponent } from './components/common/set-password/set-password.component';
import { EsignDocumentComponent } from './components/common/esign-document/esign-document.component';
import { CanvasComponent } from './components/common/canvas/canvas.component';
import { CommonService } from './services/common.service';
import { ExternalAuthComponent } from './components/common/external-Auth/external-Auth.component';
import { ActivateUserComponent } from './components/common/activate-user/activate-user.component';
import { SupportComponent } from './components/common/support/support.component';
import { UserIdleModule } from 'angular-user-idle';
import { AddressVerificationComponent } from './components/common/address-verification/address-verification.component';
import { ModalModule, BsModalRef } from 'ngx-bootstrap/modal';
@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    LoginComponent,
    DashboardDetailsComponent,
    DashboardQuickAssessmentComponent,
    DashboardGuarantorComponent,
    OtpScreenComponent,
    ResetPasswordComponent,
    AppLandingComponent,
    CreateAccountComponent,
    DashboardHomeAddressComponent,
    DashboardWorkAddressComponent,
    DashboardPersonalComponent,
    DashboardHouseholdComponent,
    DetailAssessmentComponent,
    ShowMonthlyIncomePipe,
    ShowResourceValuePipe,
    DashboardApplicationFormsComponent,
    DashboardVerificationComponent,
    ActiveAccountComponent,
    FormatDocumentType,
    DashboardContactPreferenceComponent,
    DashboardAdvocateComponent,
    StartAssessmentComponent,
    InsuranceComponent,
    HouseholdComponent,
    GeneralQuestionsComponent,
    VerificationComponent,
    DemographicsComponent,
    PaymentOptionsComponent,
    ProgramsComponent,
    ChangePasswordComponent,
    QuickAssessmentComponent,
    SpinnerOverlayComponent,
    ProfileComponent,
    ProfileSettingComponent,
    AdvocateSummaryPanelComponent,
    DashboardProgramsComponent,
    DashboardFormsComponent,
    AccountComponent,
    WebViewerComponent,
    PagenotfoundComponent,
    DynamicQuestionsComponent,
    SetPasswordComponent,
    EsignDocumentComponent,
    CanvasComponent,
    ExternalAuthComponent,
    ActivateUserComponent,
    SupportComponent,
    AddressVerificationComponent,
  ],
  entryComponents: [
    FormDialogComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatTabsModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatCheckboxModule,
    MatExpansionModule,
    MatMenuModule,
    MatRadioModule,
    MatDialogModule,
    OverlayModule,
    MatButtonToggleModule,
    MatGridListModule,
    AppRoutingModule,
    ReactiveFormsModule,
    HttpClientModule,
    FormsModule,
    NumberPickerModule,
    MatTooltipModule,
    MatProgressSpinnerModule,
    ModalModule.forRoot(),
    BackButtonDisableModule.forRoot({
      preserveScrollPosition: true
    }),
    ToastrModule.forRoot({
      timeOut: 1000,
      preventDuplicates: true,
      positionClass: "toast-top-center",
      maxOpened: 1
    }),
    NgxMaskModule.forRoot(),
    BsDatepickerModule.forRoot(),
    TooltipModule.forRoot(),
    CountdownModule,
    SignaturePadModule,
    NgbModule,
    DocumentViewerModule,
    NgxPermissionsModule.forRoot(),
    UserIdleModule.forRoot({idle: 600, timeout: 2}),
  ],
  providers: [
    CommonService,
    DatePipe,
    { provide: HTTP_INTERCEPTORS, useClass: GlobalHttpInterceptorService, multi: true },
    BsModalRef
  ],
  bootstrap: [AppComponent],
  schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class AppModule {}