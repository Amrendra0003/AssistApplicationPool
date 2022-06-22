import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppLandingComponent } from './components/common/app-landing/app-landing.component';
import { CreateAccountComponent } from './components/common/create-account/create-account.component';
import { DashboardDetailsComponent } from './components/patient/patient-dashboard/patient-dashboard.component';
import { DetailAssessmentComponent } from './components/common/detail-assessment/detail-assessment.component';
import { DashboardQuickAssessmentComponent } from './components/common/detail-assessment/dashboard-quick-assessment/dashboard-quick-assessment.component';
import { LoginComponent } from './components/common/login/login.component';
import { OtpScreenComponent } from './components/common/otp-screen/otp-screen.component';
import { ResetPasswordComponent } from './components/common/reset-password/reset-password.component';
import { ActiveAccountComponent } from './components/common/active-account/active-account.component';
import { AuthGuard } from './auth/auth.guard';
import { StartAssessmentComponent } from './components/advocate/start-assessment/start-assessment.component';
import { PaymentOptionsComponent } from './components/patient/payment-options/payment-options.component';
import { ProgramsComponent } from './components/advocate/programs/programs.component';
import { QuickAssessmentComponent } from './components/advocate/quick-assessment/quick-assessment.component';
import { ProfileComponent } from './components/common/profile/profile.component';
import { AccountComponent } from './components/common/account/account.component';
import { DashboardAdvocateComponent } from './components/advocate/dashboard-advocate/dashboard-advocate.component';
import { PagenotfoundComponent } from './components/common/pagenotfound/pagenotfound.component';
import { DynamicQuestionsComponent } from './components/patient/dynamic-questions/dynamic-questions.component';
import { SetPasswordComponent } from './components/common/set-password/set-password.component';
import { EsignDocumentComponent } from './components/common/esign-document/esign-document.component';
import { ExternalAuthComponent } from './components/common/external-Auth/external-Auth.component';
import { ActivateUserComponent } from './components/common/activate-user/activate-user.component';
import { SupportComponent } from './components/common/support/support.component';
import { SinglePostResolver } from './components/patient/dynamic-questions/single.post.resolver';
const routes: Routes = [
  { path: '', component: AppLandingComponent, pathMatch: 'full' },
  { path: "create-account", component: CreateAccountComponent, canActivate: [AuthGuard], data: { permissions: { only: ['CreatePatientAccount'] } } },
  { path: "account", component: AccountComponent, canActivate: [AuthGuard], data: { permissions: { only: ['CreatePatientAccount'] } } },
  { path: "login", component: LoginComponent },
  { path: "reset-password", component: ResetPasswordComponent },
  { path: "dashboard-quick-assessment", component: DashboardQuickAssessmentComponent },
  { path: "otp", component: OtpScreenComponent },
  { path: "dashboard", component: DashboardDetailsComponent, canActivate: [AuthGuard], data: { permissions: { only: ['ViewPatientDashboard'] } } },
  { path: "detail-assessment/:tab", component: DetailAssessmentComponent, canActivate: [AuthGuard], data: { permissions: { only: ['ViewDashboardInfo'] } } },
  { path: "detail-assessment", component: DetailAssessmentComponent, canActivate: [AuthGuard], data: { permissions: { only: ['ViewDashboardInfo'] } } },
  { path: "activate-account", component: ActiveAccountComponent },
  { path: "dashboard-advocate", component: DashboardAdvocateComponent, canActivate: [AuthGuard], data: { permissions: { only: ['ViewAdvocateDashboard'] } } },
  { path: 'create-assessment', component: StartAssessmentComponent, canActivate: [AuthGuard], data: { permissions: { only: ['CreateAssessmentByAdvocate'] } } },
  { path: 'payment-options', component: PaymentOptionsComponent, canActivate: [AuthGuard], data: { permissions: { only: ['ViewPaymentOptions'] } } },
  { path: 'preliminary-results', component: ProgramsComponent, canActivate: [AuthGuard], data: { permissions: { only: ['ViewProgram'] } } },
  { path: "profile", component: ProfileComponent, canActivate: [AuthGuard], data: { permissions: { only: ['ViewProfile'] } } },
  { path: 'advocate-quick-assessment', component: QuickAssessmentComponent, canActivate: [AuthGuard], data: { permissions: { only: ['AdvocateQuickAssessment'] } } },
  { path: "esign-document", component: EsignDocumentComponent },
  { path: "pagenotfound", component: PagenotfoundComponent },
  { path: "dynamic-questions", component: DynamicQuestionsComponent, resolve:{singlePost: SinglePostResolver}, canActivate: [AuthGuard], data: { permissions: { only: ['CreateDynamicAssessment'] } } },
  { path: "create-user", component: SetPasswordComponent },
  { path: "external-auth", component: ExternalAuthComponent },
  { path: "activate-user", component: ActivateUserComponent },
  { path: "support", component: SupportComponent }
];
@NgModule({
  imports: [RouterModule.forRoot(routes, { scrollPositionRestoration: 'enabled' })],
  exports: [RouterModule]
})
export class AppRoutingModule { }
