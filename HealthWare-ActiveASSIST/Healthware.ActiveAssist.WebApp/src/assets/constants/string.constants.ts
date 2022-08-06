import { environment } from 'src/environments/environment';
// config all the rest api url required
export class StringConstants {

  public static var = {
    PATIENT: 'PATIENT',
    ADVOCATE: 'ADVOCATE',
    yetToSubmit: 'Yet To Submit',
    underReview: 'Under Review',
    cell: 'Cell',
    call: 'Call',
    mail: 'Mail',
    text: 'Text',
    email: 'Email',
    cellNumber: 'Cell Number',
    landlineNumber: 'Landline Number',
    landline: 'Landline',
    other: 'Other',
    self: 'Self',
    guarantor: 'Guarantor',
    patient: 'Patient',
    dataAvailable: 'Data Available',
    homeAddress: 'HomeAddress',
    workAddress: 'WorkAddress',
    addResource: 'Add Another Resource for this member',
    addIncome: 'Add Another Income for this member',
    ResourceMember: 'Add Resource for this member',
    IncomeMember: 'Add Income for this member',
    AcceptedNotverified: 'Accepted, Not Verified',
    ApplicationSubmitted: 'Application Submitted',
    Address: 'Address',
    Identification: 'Identification',
    Other: 'Other',
    documentIncomplete: 'Documentation Incomplete',
    incomplete: 'Incomplete',
    typeText: 'text',
    typePassword: 'password',
  }

  public static toast = {
    empty: '',
    //Warning!
    selectRadio: 'Kindly select any address.',
    MissCommunicationWithAddressApi: 'This time, the process cannot be completed due to a lack of network communication. Report this to the site administrator and try again later.',
    AddressNotFound: 'Address not found.',
    enterEmail: 'Kindly enter your email.',
    emailRequired: 'Email is required.',
    termsAndConditions: 'Kindly agree to the terms and conditions to proceed.',
    fileFormat: 'File Format not supported,file formats such as jpeg and png are only allowed.',
    enterPassword: 'Kindly enter a valid password.',
    fillRequired: 'Kindly fill all the required fields.',
    submitEform: 'Cannot submit the E-form.',
    submitOrUploadForm: 'kindly e-sign or upload signed documents.',
    notFoundDocument: 'Unable to find the document',
    addhousehold: 'Kindly add household members.',
    changeSelf: 'Changing to Self will clear the income & resource records.',
    applyPrograms: 'Kindly apply for any one of the programs.',
    attachDocs: 'Kindly do attach documents for verification.',
    verifyEmail: 'Kindly verify your Email.',
    completeVerify: 'kindly do complete email and income verification.',
    notUpload: 'You have selected the document type but not uploaded.',
    patientWarning: 'This patient already has an assessment in progress.  Please submit before creating a new assessment.',
    userWarning: 'You already have an assessment in progress status. Please submit before creating a new assessment.',
    enterOtp: 'Kindly enter the OTP sent.',
    completeEsign: 'Kindly complete the assessment to view the e-forms.',
    completeDocs: 'Kindly complete the assessment to view the documents.',
    cannotUpload: 'Cannot upload the document',
    fileType: 'PNG,JPEG,JPG,DOC,DOCX,PDF are allowed.',
    fileSupport: 'File format is not supported.',
    themeChange: "Can't change theme.",
    jsonChange: "Can't change json.",
    clickIncome: "Kindly click on add income button.",
    clickResource: "Kindly click on add resource button.",
    addIncome: "Income not added.",
    addResource: "Resource not added.",

    //Success!
    deleteAssessment: 'Assessment deleted sucessfully.',
    passwordUpdated: 'Password updated successfully.',
    updateProfile: 'Profile settings updated successfully.',
    formSaved: 'Form saved successfully.',
    formUpload: 'Form uploaded successfully.',
    contactUpdated: 'Contact preference updated successfully.',
    contactSaved: 'Contact preference saved successfully.',
    guarantorSaved: 'Guarantor saved successfully.',
    guarantorUpdated: 'Guarantor updated successfully.',
    personalUpdated: 'Basic info has been updated successfully.',
    homeAddressUpdated: 'Home address updated successfully.',
    homeAddressSaved: 'Home address saved successfully.',
    workAddressUpdated: 'Work address updated successfully.',
    workAddressSaved: 'Work address saved successfully.',
    householdDeleted: 'Household member deleted sucessfully.',
    newMemberCreated: 'New Household member Created successfully.',
    householdUpdated: 'Household member updated successfully.',
    profileImgUpdated: 'Profile image updated.',
    submitAssessment: 'Assessment has been submitted successfully.',
    fileUploaded: 'File is completely loaded.',
    uploadDone: 'Upload done.',
    profileUpload: 'Profile image updated.',
    checkMail: 'Kindly check your mail.',
    otpSent: 'OTP sent successfully.',
    otpResent: 'OTP re-sent successfully.',
    assessmentDelete: 'Assessment deleted sucessfully.',
    cellNumberVerify: 'Cell Number verified successfully.',
    documentUploaded: 'Document uploaded successfully.',
    documentDeleted: 'Document deleted successfully.',
    emailSent: 'Email sent successfully.',

    //Error!
    incorrectPassword: 'Incorrect Username or Password.',
    loginFailed: 'Login Failed.',
    httpError: 'HTTP 500 error occurred.',
    serverError: 'Internal Server Error.',
    tryAgain: 'Try Again.',
    samePassword: 'Password should not be same as the old password.',
    statusUpdateFailed: 'Status Update Failed.',
    fetchError: 'Error in Image Fetch.',
    failToEvaluate: 'Failed to evaluate the assessment details.',
    uploadError: 'Upload Error:',
    enterValidOtp: 'Kindly enter valid OTP.',
    invalidOtp: 'Invalid OTP.',
    errordelete: 'Error in Delete',
    error: 'Error:',
    errorFetch: 'Error in Fetch',
    activeUser: 'Could not find the active user.',
  };

  public static programs = {
    programsSuccessTitle: "You’re a Candidate for Benefits!",
    programsSuccessDescription: "From your preliminary responses, it appears that the patient may be a candidate for one or more of the following financial programs:",
    programsSuccessMessageInforamtion: "You can continue the process yourself or work directly with a Patient Advocate.  In either case, this portal will be used to facilitate the completion of applications and gathering of supporting documentation."
  }

  public static quick = {
    accountCheck: 'You have an advocate account with us, Kindly login to proceed to your account.',
    emailExist: 'Email already exists.',
    provideEmail: 'Kindly provide another Email.'
  };
  public static ssn = {
    ssnMessageInfo: 'Your SSN is secure with us. We ask for this information as most government agencies require this number when submitting an application for benefits.',
    ssnLinkInfo: 'By clicking this box you acknowledge that you have received, reviewed and agree to the Terms of Use, Privacy Statement, E-Signature Disclosure disclosure and consent.',
    buttonLabel: 'Check Eligibility',
  }
  public static common = {
    nextLabel: 'Next',
    loginLabel: 'Login',
    cell: 'Cell',
    home: 'Home',
    save: 'Save',
    apply: 'Apply',
    no: 'No',
    scheduleAppointment: 'Schedule an Appointment',
    deleteWarning: 'Are you sure you want to delete?',
    landline: 'Landline',
    text: 'Text',
    call: 'Call',
    email: 'Email',
    mail: 'Mail',
    ssn: 'SSN',
    formsTitle: 'Application Form and Required Documents',
    yearly:'Yearly',
    pleasewait:'Please Wait...',
    linkExpiredMsg: 'The link that you have entered has expired. Please contact us at XXX-XXX-XXXX to obtain an updated link.',
  }
  public static landingPage = {
    messageInfo: 'This service is provided to you at no cost by your healthcare provider(s). We will work on your behalf to find benefits to help cover your medical expenses.  This portal will be used to complete paperwork, share information, and expedite the process towards a potential approval of benefits.',
    messageTitle: 'Take this quick assessment to know whether you are eligible for financial assistance.',
    buttonLabel: 'Begin'
  }
  public static account = {
    title: 'Create Your Secure Account',
    passwordMessageInfo: 'Your password must contain at least 8 characters including an upper case, a lower case, a number and a special character.',
    messageInfo: 'Alternatively, you may call a Patient Advocate at (888) 234-4343 to arrange a phone interview or schedule an onsite appointment.',
    CreatedAccountTitle: 'We have detected you have an account with us.',
    PassReq:"Enter a valid email!",
    PassReq1:"Password is required!",
    PassMin:"Password should contain aleast 8 characters!",
    PassMax:"Password must not exceed 20 charaters!"
  }
  public static patientDashboard = {
    hospitalName: 'Re: Memorial Hospital, Dallas',
    PriorSubmissions:"Prior Submissions",
    SubmittedBy:"Submitted by",
    NeedAssistance:"Do you need assistance?",
    ChatWithExpert:"Chat with expert",
    PhoneCall:"Phone Call",
    VideoCall:"Video Call",
    
  }
  public static applicationForms = {
    benefitsTitle: 'Benefits',
    eSign: 'e-Sign',
    eSignComplete: 'e-Sign Completed',
    eSignDelete: 'Delete',
    share: 'Share',
    download: 'Download',
    uploadForms: 'Upload Completed Form',
    close: 'Close',
    saveClose: 'Save & Close',
    programsNotApplied: 'Please apply for any of the Review Programs in Quick Assessment Results tab!',
    topHeader: 'Good news! You continue to be a candidate for the programs below.',
    topTilte: ' Please complete and sign the forms for each program and complete the verification process. Once complete, you can submit your application for review.',
    messageInfo: 'If you need any assistance with the application, please reach out to our eligibility experts.',
    moreInformation: 'Click for more information',
    Uploaded:"Uploaded",
    NotUploaded:"Not Uploaded!",

  }
  public static dashboardHouseholdMember = {
    currentlyOwned: 'Currently Owned',
    verification: 'Verification',
    incomeStatus: 'Income Status',
    current: 'Current',
    monthly: 'Monthly'
  }
  public static dashboardVerification = {
    nameRelation: 'Name/Relation',
    documentType: 'Document Type',
    documentName: 'Document Name',
    title: 'To verify your income please upload your most recent documents.',
    moreDocumnets: 'Add more documents'
  }
  public static contactPreference = {
    title: 'Contact Preferences',
    preferredCell: 'Preferred Cell',
    callingTime: 'Preferred time of calling',
    preferredEmailAddress: 'Preferred Email Address',
    preferredMailingAddress: 'Preferred Mailing Address',
    preferredModeofCommunication: 'Preferred Mode of Communication',
    Time1:"9:00 AM",
    Time2:"11:00 AM",
    Time3:"4:00 PM",
    Time4:"6:00 PM",
    PreferredNumReq:"Preferred cell number is required!",
    TimeReq:"Time of calling is required!",
    NumReq:"number is required!",
    NumVal1:"Enter a valid ",
    NumVal2:"number!",
    PreferredEmail:"Preferred email is required!",
    MailingReq:"Preferred mailing address is required",
    NickNameReq:"Nick name is required!",
    NickNameAlp:"Nick name should contain only alphabets!",
    NickNameMax:"Nick name should not exceed 50 characters!",
    NickNameMin:"Nick name must contain atleast 2 characters!",
    StreetAddressMinCharacters:"Street address must contain atleast 3 characters!",
    ModeOfCommunication:"Please choose the mode of communication!",


      }
  public static guarantor = {
    relationTitle: 'Relationship with patient',
    guarantor: 'Guarantor - Basic Info'
  }
  public static IdleTimeOutSeconds = environment.IdleTimeOutSeconds;
  public static AllMonths = [

    'January',
    'February',
    'March',
    'April',
    'May',
    'June',
    'July',
    'August',
    'September',
    'October',
    'November',
    'December',
  ];
  public static chartColorPalette = ['#D5EAD7', '#D6ECFA', ' #D4D9ED', ' #D4CAE3', ' #FBDCE4', ' #FED9C6', ' #FEEAD1', ' #FFFCD9',
    '#BCDEC5', ' #BEE0F9 ', '#C0C9E8', ' #BFAFD3', ' #FAC7D8', ' #FAC4AA', ' #FCE0B8', ' #FFFBB2',
    '#A2D4AF', ' #A5D8F7', ' #AAB8DD', ' #A998C5', ' #F9B5CA ', '#F7B090', ' #FCD7A2', ' #FEF89A',
    '#86C99E', ' #8CCDF3', ' #92A9D5', ' #977EB5', ' #F6A0BD', ' #F49C76', ' #FCCD89', ' #FEF888',
    '#66BF89', ' #6CC4F2', ' #7C9AD0', ' #8369A8', ' #F288B0', ' #F0865F', ' #F8C373', ' #FDF76D',
    '#2FB775', ' #41BDF1', ' #638BC9', ' #6E529C', ' #F06FA5', ' #EC6F4F', ' #F6B95C', ' #FDF548',
    '#ACACA5', ' #BFBFBF', ' #D1D1D1', ' #E0E0E0', ' #EBEBEB ', '#F5F5F5',
    '#ECF6FF', ' #ECECF8', ' #E8DAEB', ' #FDEDF0'];

  public static permissionsConstants = {
    viewAdvocateDashboard: 'ViewAdvocateDashboard',
    createAssessment: 'CreateAssessment',
    viewComponentAssessmentSummary: 'ViewComponentAssessmentSummary',
    viewComponentQuickAssessment: 'ViewComponentQuickAssessment',
    viewComponentPersonal: 'ViewComponentPersonal',
    viewComponentGuarantor: 'ViewComponentGuarantor',
    viewComponentContactPreference: 'ViewComponentContactPreference',
    viewComponentHouseHold: 'ViewComponentHouseHold',
    viewComponentPrograms: 'ViewComponentPrograms',
    viewComponentForms: 'ViewComponentForms',
    viewComponentVerification: 'ViewComponentVerification',
    viewComponentApplicationForms: 'ViewComponentApplicationForms',
    createAssessmentByAdvocate: 'CreateAssessmentByAdvocate',
  }
  public static exceptionMessages = {
    serviceErrorMessage: 'Error occured while calling service. Kindly contact admin.',
    HWSServiceErrorMessage: 'Error occured while calling HealthWare service. Kindly contact admin.',
    NotAuthorizedErrorMessage: 'You dont have sufficient privileges to do this action.'
  }
  public static createUser ={
    ErrorMessage :"Please fill all the required fields"
  }
  public static header={
    InstruMessage: "Instructions/information goes here.",
    InstruMessageBody1:"Lorem ipsum dolor sit amet, consec tetur adipiscing elit sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
    InstruMessageBody2:"Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
    InstruMessageBody3:"De Finibus Bonorum et Malorum\", written by Cicero in 45 BC Sed ut perspiciatis unde omnis iste natus error sit voluptatem accusantium doloremque laudantium",
    BtoDash:"Back to Dashboard",
    Hello:"Hello",
    PSet:"Profile Settings",
    LogOut:"Log out",
    LogQues:"Are you sure you want to log out?",
    No:"No",
    Yes:"Yes",
    Appointment:"Schedule an Appointment",
    VirtualAssist:"Virtual Assist",
    Login:"Login"
  }
  public static appLanding={
    TodayCost:"Hello,the estimated cost of your visit today is $230.",
    message1:" We are unable to locate a user with the supplied URL. If the link does not work, please copy and paste the complete URL into your web browser. You may also email ",
    message2:"from the email used to request assistance.",
  }
  public static login={
    welcome:"Welcome Back!",
    LoginInfo:"Please login to access your account",
    Emailreq:"Email is required!",
    EmailVal:"Enter a valid email!",
    Emailmax:"Email must not exceed 50 characters!",
    RememberMe:"Remember me",
    ForgotPassword:"Forgot Password?",
    Next:"Next",
    NewUserInfo:"New User? Start your Assessment Here!",
    
  }
  public static advocateSummaryPanel={
    AssessmentIncomplete:"Assessment Incomplete",
    DocumentationIncomplete:"Documentation Incomplete",
    years:"years",
    QuickAssessment:"Quick Assessment",
    panelInfo:"From the preliminary responses provided, it appears that the Patient may be a candidate for one or more programs.",
    Demographics:"Demographics",
    ResidentialZipCode:"Residential Zip Code",
    Insurance:"Insurance / COBRA",
    InsuranceInfo:"Health insurance in last 6 months",
    Household:"Household",
    NumberOfMembers:"Number of members",
    NumberOfMinors:"Number of minors",
    AnyoneInHouseholdEmployed:"Anyone in household employed",
    ReceivingAny:"Receiving any",
    MonthlyHouseholdIncomeMsg:"Estimated Monthly Household Income",
    MonthlyResourcesMsg:"Estimated Monthly Resources",
    GeneralQuestions:"General Questions",
    PersonalDetails:"Personal Details",
    PersonalEmail:"Personal Email",
    PersonalCellNumber:"Personal Cell Number",
    GuarantorDetails:"Guarantor Details",
    GuarantorEmail:"Guarantor Email",
    GuarantorCellNumber:"Guarantor Cell Number",
    PreferredDetails:"Preferred Details",
    PreferredEmail:"Preferred Email",
    PreferredCellNumber:"Preferred Cell Number",
  }
  public static dashboardAdvocate={
    PriorSubmissions:"Prior Submissions",
    SelectDate:"Select Date",
    Last7Days:"Last 7 Days",
    Today:"Today",
    Yesterday:"Yesterday",
    ThisMonth:"This Month",
    Last3Days:"Last 3 Days",
    SelectFilter:"Select Filter",
    NewestFirst:"Newest First",
    OldestFirst:"Oldest First",
    StartNewAssessment:"Start New Assessment",
    NoRecordsFound:"No records found!!",
    AssessmentID:"Assessment ID",
    Status:"Status",
    Patient:"Patient",
    Gender:"Gender",
    From:"From",
    Programs:"Programs",
    logoutMsg:"Are you sure you want to delete assessment?",
    No:"No",
    Yes:"Yes",
    }
    public static demographics={
      info:"lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisiut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.",
      NameReq:"First name is required!",
      NameAlp:"First name should contain only alphabets!",
      NameMax:"First name should not exceed 50 characters!",
      NameChar:"First name must contain 2 characters!",
      MiddleNameReq:"Middle name is required!",
      MiddleNameAlp:"Middle name should contain only alphabets!",
      MiddleNameMax:"Middle name should not exceed 50 characters!",
      MiddleNameChar:"Middle name must contain 2 characters!",
      NameLegal:"Please enter the legal name.",
      LastNamereq:"Last name is required!",
      LastNameAlp:"Last name should contain only alphabets!",
      LastNameMax:"Last name should not exceed 50 characters!",
      LastNameMin:"Last name should have atleast 2 characters!",
      DateReq:"Date of birth is required!",
      DateFormate:"Date must be in mm/dd/yyyy format.",
      DateFut:"Date of Birth can not be in future.",
      Gender:"Gender",
      GenderReq:"Gender is required!",
      Marital:"Marital",
      MartialReq:"Marital status is required!",
      ZipMsg:"Please enter your Zip code",
      ZipReq:"Zip Code is required!",
      ZipNum:"Zip Code should contain only numbers!",
      ZipMin:"Zip Code must contain atleast 5 digits!",
      ZipMax:"Zip Code should not exceed 5 digits!",
      ZipVal:"Please enter a valid Zip Code!",
      CityReq:"City is required!",
      CityAlp:"City should contain only alphabets!",
      CityMax:"City should not exceed 50 characters!",
      StateReq:"State is required!",
      ConfirmCitizenshipStatus:"Confirm citizenship status",
      CitizenshipStatus:"Citizenship Status",
      PatientContactDetails:"Patient Contact Details",
      EmailReq:"Email is required!",
      EmailVal:"Enter a valid email!",
      EmailMax:"Email should not exceed 100 characters!",
      CellNumReq:"Cell number is required!",
      CellVal:"Enter a valid cell number!",
      BestContact:"Best Person to Contact",
      Patient:"Patient",
      RelationshipWithPatient:"Relationship with Patient",
      RelationReq:"Relation is required!",

    }
    public static generalQuestion={
      GeneralInfo1:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna",
      GeneralInfo2:"aliqua. Ut enim ad minim veniam, quis nostrud exercitatio.",
      Proceed:"Proceed",
    }
    public static household={
      HouseholdInfo:"Household Information",
      HouseholdInfoMsg1:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna",
      HouseholdInfoMsg2:"aliqua. Ut enim ad minim veniam, quis nostrud exercitation",
      TotalNumLiving:"Total Number of members living in the household",
      MinorChildren:"Minor children for whom have full custody?",
      HouseholdEmployedQue:"Is anyone in the household employed?",
      PatientCurrently:" Does the patient currently receive any of the following?",
      ProgramsReq:"Programs is required!",
      HouseholdIncomeAndResources:"Enter household income and resources",
      EstimatedHouseholdIncome:"Estimated Household Income",
      IncomeErr:"Income accepts only numbers!",
      IncomeErrExceed:"Can't exceed $50000",
      GrossPay:"Gross Pay",
      EstimatedHousehold:"Estimated Household Resources",
      ResourceAcceptsNumbers!:"Resource accepts only numbers!",
      Next:"Next",
    }
    public static insurance={
      Last60DaysIncome:"Do you currently or in the last 60 days have/had health insurance?",
      InsuranceMsg1:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna",
      InsuranceMsg2:"aliqua. Ut enim ad minim veniam, quis nostrud exercitation.",
      No:"No",
      Yes:"Yes",
      FollowingDetails:"Enter the following details",
      PayerNameAlp:"Payer name should contain only alphabets!",
      PaterMax:"Payer name should not exceed 50 characters!",
      PayerNumOfChar:"Payer name must contain 2 characters!",
      GroupAlp:"Group name should contain only alphabets!",
      GroupNameCharMax:"Group name should not exceed 50 characters!",
      GroupNameCharMin:"Group name must contain 2 characters!",
      GroupNo:"Group No.",
      PolicyNo:"Policy No.",
      PolicyNumAlp:"Policy Number accepts only alphanumeric!",
      PolicyNumMax:"Policy Number should not exceed 50 characters!",
      EffectiveFrom:"Effective From",
      Termination:"Termination",
      VisitoeInfo:"Your visit can be covered under your insurance.Please get in touch with your insurance provider for more information.",
      InvalidPolicyNumber:"Invalid policy number",
      Next:"Next"

      


    }
    public static quickAssessment1={
      Demographics:"Demographics",
      GeneralQuestionsMsg:"General Questions",
      QuickAssessment:"Quick Assessment",
      QMB:"QMB",
      SNF:"SNF",
      AddBaby:"Add Baby",
      Verification:"Verification",
      Household:"Household",
      Insurance:"Insurance / COBRA"
    }
    public static verification={
      provideSSN:"Last Step.Please provide your SSN",
      VerificationMsg1:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed deiusmod tempor incididunt ut labore et dolore magna",
      VerificationMsg2:"aliqua. Ut enim ad minim veniam, quis nostrud exercitation.",
      SSNReq:"SSN is required!",
      SSNPatientId:"We need the SSN to verify patient's identity.",
      AcceptPrivacyStatement:"By clicking this box you acknowledge that you have received, reviewed and agree to the terms of use, privacy statement, e-signature disclosure and consent",

    }
    public static startAssessment={

      PatientInfoEnter:"Please enter patient name and date of birth to start assessemnt",
      PatientNameReq:"Patient name is required!",
      PatientNameAlp:"Patient name should contain only alphabets!",
      PatientNameMax:"Patient name should not exceed 50 characters!",
      PatientNameMin:"Patient name must contain 2 characters!",
      DateFormate:"Date must be in mm/dd/yyyy format.",
      DateReq:"Date of Birth is required!",
      DateFormateFutureErr:"Date of Birth can not be in future.",
      Locate:"Locate",
      No:"No",
      ConfirmPatientName:"Confirm patient name to proceed.",
      StartAssessmentInfo:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
      }
      public static activeAccount={
        Dear:"Dear",
        YourEmail:"Your email ",
        Verified:"has been verified",
        ExpiredMsg:"The verification link has been expired."
       }
       public static paymentOption={
         PaymentErrMsg1:"We are sorry! From your preliminary responses it appears that you do not qualify for any of the available financial assistance programs.",
         PaymentErrMsg2:"However, there are payment alternatives available for you. Please select your preferred option to proceed.",
         PaymentPlans:"Payment Plans",
         SmartCardInfo:"Apply for SmartHealth Pay Card",
         EmergencyAcuity:"Please select the emergency acuity level to proceed",
         AlternativePaymentOptions:"Alternative Payment Options",
         ShareViaText:"Share via Text",
         ShareViaEmail:"Share via Email",
         PaymentErrMsg3:"Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laborisnisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eufugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollitanim id est laborum.",

       }
       public static ChangePassword={
        ChangePassword:"Change Password",
        EnterCurrentPassword:"Enter Current Password",
        PassReq:"Current password is required!",
        PassVal:"Enter a valid password!",
        PassMinLen:"Password must contain 8 characters!",
        PassMaxLen:"Password should not exceed 20 characters!",
        NewPass:"Enter New Password",
        NewPassReq:"New password is required!",
        ReEnterYourPassword:"Re-enter your password!",
        PasswordMustMatch:"Password must match!",
        PassStrInfo:"Your password must contain at least 8 characters including an upper case, a lower case, a number and a special character.",
        Update:"Update",
      }
      public static profile={
        Dashboard:"Go back to Dashboard"

      }
      public static profileSetting={
        Theme:"Theme",
        Light:"Light",
        Dark:"Dark",
        prifileSettingMsg1:"Good job",
        prifileSettingMsg2:"! You have completed a great number of assessments.",
        prifileSettingMsg3:" All the best for your journey with us.",
        PersonalInfo:"Personal Info",
        MidNameReq:"Middle name is required!",
        MidNameAlp:"Middle name should contain only alphabets!",
        MidNameMax:"Middle name should not exceed 50 characters!",
        ContactDetails:"Contact Details",
        Cell:"Cell",
        HomeAddress:"Home Address",
        MailingAddress:"Mailing Address",
        StreetAddressReg:"Street address is required!",
        StreetAddressMax:"Street address should not exceed 250 characters!",
        SuiteReq:"Suite is required!",
        SuiteMax:"Suite should not exceed 250 characters!",
        CountyReq:"County is required!",
        CountyAlp:"County should contain only alphabets!",
        CountyMax:"County should not exceed 50 characters!",
        StateAlp:"State should contain only alphabets!",
        ValidHomeNum:"Enter a valid home number!",
        Dynamic:"Dynamic",

      }
      public static SetPassword={
        SecureAccount:"Secure your account",
      }

      public static DashboardForm={
        DashboardFormInfo1:"Good News! Detailed assessment brought back the list of programs you can continue to apply for.",
        DashboardFormInfo2:"Please sign the forms and complete the verification process to submit the application.",
        EligibilityExperts:"If you need any assistance with the application, please reach out to our eligibility experts.",
        KindlyReview:"Kindly review and submit atleast an Application to view Forms!",
      }
      public static DashboardHousehold={
        household:"Household Member/Relationship",
        DateofBirth:"Date of Birth",
        IncomeResources:"Income/Resources",
        Amount:"Amount",
        NoMembersFound:"No members found.",
        NoIncomeResources:"No Income or Resources",
        DelHouseHoldMember:"Are you sure you want to delete this Household Member?",
        HouseholdSize:"Total Household Size: 0",
        MonthlyIncome:"Total Monthly Income: $0.00",
        Resources:"Total Resources: $0.00",
        HouseholdSize1:"Total Household Size: ",
        MonthlyIncome1:"Total Monthly Income: ",
        Resources1:"Total Resources: ",
        Evaluate:"Evaluate",
        NoProgramsAvailable:"No Programs Available",
        EvaluatedPrograms:"Evaluated Programs",
        AddMorePrograms:"Add More Programs",
        AddNewMember:"Add New Member",
        EditMember:"Edit Member",
        SuffixAlp:"Suffix accepts alphabets!",
        SuffixMax:"Suffix should not exceed 50 characters!",
        RelationshipRole:"Relationship/Role",
        RelationshipReq:"Relationship is required!",
        MaritalStatus:"Marital Status",
        SSN:"SSN",
        SSNReq:"SSN is required!",
        SSNVal:"Enter a valid SSN number!",
        PatientGuarantor:"Under Care of Patient/Guarantor?",
        YesOrNo:"Please select Yes or No!",
        Medicaid:"Does the member have Medicaid?",
        MedicaidErr:"Medicaid ID shouldn't accept spaces and special characters!",
        MedicaidMax:"Medicaid ID not to exceed 50 digits!",
        StateAlp:"State accepts only alphabets!",
        StateMax:"State not to exceed 50 digits!",
        EffectiveFrom:"Effective From ",
        Termination :"Termination ",
        MemberCoverage:"Does the member have prior coverage?",
        SpaceSpecial:"Group Number shouldn't accept spaces and special characters!",
        GroupNumMax:"Group Number not to exceed 50 digits!",
        IncomeType:"Income Type",
        MonthlyGrossPay:"Monthly Gross Pay",
        EditIncome:"Add/Edit Income",
        IncomeTypeReq:"Income type is required!",
        IncomeStatus:"Income Status is required!",
        VerificationReq:"Verification status is required!",
        IncomeReq:"Income is required!",
        IncomeNum:"Income accepts only numers!",
        IncomeExceed:"Income should not exceed $50000!",
        CalMonthlyIncome:"Calculated Monthly Income $ ",
        ConfirmationContact:"Confirmation Contact",
        CompanyNameReq:"Company name is required!",
        CompanyNameAlp:"Company name should contain only alphabets!",
        CompanyNameMin:"Company name must contain 3 characters!",
        CompanyNameMax:"Company name should not exceed 50 characters!",
        ContactNumAlp:"Contact name should contain only alphabets!",
        ContactNameMin:"Contact name must contain 3 characters!",
        ContactNameMax:"Contact name should not exceed 50 characters!",
        AddressMax:"Address should not exceed 250 characters!",
        ZipMax:"Zip Code should not exceed 50 digits!",
        FaxNumVal:"Enter a valid fax number!",
        ResourceType:"Resource Type",
        ResourceValue:"Resource Value",
        EditResource:"Add/Edit Resource",
        ResourceReq:"Resource type is required!",
        ResourceStatus:"Resource Status",
        ResourcestatusReq:"Resource status is required!",
        MarketValue:"Market Value",
        PercentageReq:"Percentage is required!",
        Percentagedeci:"Percentage should contain only numbers with two decimal places!",
        PercentageMax:"Percentage should less than or equal to 100!,",
        ResourceVal:"Calculated Resource Value $",
        LocationRealProperty:"Location of real property",
        LocationReq:"Location name is required!",
        LocationMax:"Location name should not exceed 50 characters!"
      }

      public static DashboardPersonal={
        PatientBasicInfo:"Patient - Basic Info",
        MaidenNameAlp:"Maiden name should contain only alphabets!",
        MaidenNameMax:"Maiden name should not exceed 20 characters!",
        ChangeGuarantor:"Are you sure you want to change guarantor?",

      }
      public static DashboardPrograms={
        DashboardProgramsInfo1:"Good News! Detailed assessment brought back the list of programs you can continue to apply for.",
        DashboardProgramsInfo2:"Please sign the forms and complete the verification process to submit the application.",
        Programs:"Programs",
        ReviewNotes:"Review Notes",
        SelectPrograms:"Please Select Programs"

      }
      public static DashboardQuickAssessment={
        DashboardQuickAssessmentinfo1:"You have moved a step closer to receiving financial assistance.",
        DashboardQuickAssessmentinfo2:"From your preliminary responses it appears that you may be a candidate for one or more programs.Please find the list of programs and their benefits below",
        DashboardQuickAssessmentinfo3:"The patient has moved a step closer to receiving financial assistance.",
        DashboardQuickAssessmentinfo4:"From the preliminary responses it appears that the may be a candidate for one or more programs. Please find the list of programs and their benefits below",
        ReviewProgram:"Review Program"

      }
      public static DashboardVerification={
        EligibilityExperts:"If you need any assistance with the application, please reach out to our eligibility experts.",
        Emailvar:"Email Verification",
        CellVerification:"Cell Verification",
        IDVerification:"ID Verification",
        AddressVerification:"Address Verification",
        IncomeVerification:"Income Verification",
        OtherDocumentation:"Other Documentation",
        NotVerified:" has not been verified.",
        Verified:" has been verified.",
        EmailCheck:"Please check your inbox for our email verification message.Alternatively, please click on the button to be resent the veriﬁcation email.",
        PlzReq:"If you have completed email verification.please refresh this page.",
        ResendVerificationLink:"Resend Verification Link",
        SendVerificationLink:"Send Verification Link",
        ResivePassCodeInfo:"To verify your cell number we will deliver a passcode to your Cell. Please select how you would like to receive this passcode.",
        CellNumDuringAssessment:"This is the cell number provided by you during assessment.",
        DeliveryMethod:"Delivery Method",
        CodeValid10Min:"Please enter the code you received. The code is valid for 10 mins.",
        UploadCertificate:"Please upload an image of your driver‘s license,passport,state-issued photo ID card, or military/federal government photo ID.",
        PleaseEnsure:"Please ensure:",
        Documentvalid:"Document is currently valid",
        DocumentvalidInfo:"The entire ID is visible and all information is legible.",
        SelectIDType:"Select ID Type",
        ValidDriverLicense:"Valid Driver's License",
        BirthCertificate:"Birth Certificate",
        StateIssuedIdentificationCard:"State-issued Identification Card",
        StudentIdentificationCard:"Student Identification Card",
        SocialSecurityCard:"Social Security Card",
        MilitaryIdentificationCard:"Military Identification Card",
        PassportOrPassportCard:"Passport or Passport Card",
        IdType:"Please select the ID Type!",
        UploadYourBills:"To verify your address please upload your most recent utilitym bills.",
        HomeAddressAssessment:"This is the home address provided by you during assessment.",
        DocumentlegibleInfo:" The entire document is visible and all information is legible.",
        SelectDocumentType:"Select the Document Type",
        SelectHouseholdMember:"Select Household Member",
        PleaseSelectHouseholdMember:"Please select the Household Member!",
        SelectDocumentTypet1:"Select Document Type",
        BankStatement:"Bank Statement",
        SalaryReport:"Salary Report",
        PleaseSelectDocumentType:"Please select the Document Type!",
        CompleteIncomeNerification:"Kindly complete income verification.",
        UploadImg:"Please upload an image of your Parental Consent Form, HIPAA, and Privacy Form.",
        HIPAAPrivacyConsent:"HIPAA and Privacy Consent",
        ConsentTreat:"Consent to Treat",


      }
      public static DashboardWorkAddress={
        EmployerNameReq:"Employer name should contain only alphabets!",
        EmployeMax:"Employer name should not exceed 250 characters!",
        EmployeMin:"Employer name must contain 3 characters!",
        WorkNumVal:"Enter a valid work number!"


      }
      public static DashboardInfo={
        AssessmentID:"Assessment ID",
        QuickAssessmentResults:"Quick Assessment Results",
        Personal:"Personal",
        Guarantor:"Guarantor",
        ApplicationForms:"Application Forms",
        YourApplicationComplete:"Your application is Complete.",
        SubmittingVerificationInformation:"Thank you for submitting your verified information.",
        SubmittingVerificationInformationMsg:"We will review your application and a representative will contact you with any questions. If you have any questions you may contact us at help@eligibilityadvocates.com or at 888-888-8888.",
        GoDashboard:"Go to Dashboard",
      }

      public static OtpScreen={
        PleaseWait:"Please wait...",
        ConfirmIdentity:"Please confirm your identity.",
        ConfirmationCodeSent:"Where would you like the confirmation code sent?",
        ConfirmationCodeSent2Hours:"Please enter the code you received. The code is valid for 2 hours.",
        NotReceive:"Did not receive the code?",
      }

      public static ResetPassword={
        ResetYourPassword:"Reset your password",
        RetypeYourPassword:"Re-type your password!",
        Reset:"Reset"
      }

      public static PatientDemographics={
        UserDemographics:"User Demographics",
        PatientDemographics:"Patient Demographics",
        Yourself:"Tell us about yourself",
        More:"Tell us more about the patient."
      }
      public static HouseholdIncomeResource={
        HouseholdIncomeAndResourcesInfo:"Enter patient's household income and resources",
        IncludeIncome:"Include income earned by all the members of the household",
        HouseholdIncomeResourceInfo:"Please estimate the total resource value held by all the members of the household in the form of checking & savings, retirement accounts, property (home, vehicle,etc) and any others assets.",
      }
      

      public static Common={
        Cancel:"Cancel",
        No:"No",
        Yes:"Yes",
        Phone:"Phone",
        Create:"Create",
        Select:"Select",
        formDialogWorks:"form-dialog works!",
        Forms:"Forms",
        ESign:"e-Sign",
        Share:"Share",
        Close:"Close",
        Income:"Income",
        UpdateIncome:"Update Income",
        Resource:"Resource",
        Save:"Save",
        Benefits:"Benefits",
        ResendCode:"Resend Code",
        UploadDocument:"Upload Document",
        PanCard:"Pan Card",
        Others:"Others",
        Work:"Work",
        WorkAddress:"Work Address",
        Submit:"Submit",
        ProceedBySelf:"Proceed by Self",
        AskForAssistance:"Ask for Assistance",
        AccessDenied:"Access denied to this page!",
        WebViewer:"WebViewer",
        SavedTheFollowingValues:"Saved the following values",
        CitizenshipStatus:"Confirm your citizenship status.",
        Patient:"Confirm Patient's citizenship status.",
        YouritizenshipStatusInfo:"Your state does not provide financial assistance to patients with unknown citizenship status.",
        YouritizenshipStatusInfo2:"Any further assistance message (if applicable) goes here. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore",
        SSNInfo:"Please acknowledge by providing your SSN. We are sure that your SSN will be secured with us.",
        SocialSecurityNumber:"Social Security Number",
        LAstStep:"Last Step.Please provide your SSN",
        LAstStepPattern:"Last Step.Please provide the patient's SSN",
        PatientZipCode:"Please enter patient's Zip code",
        SelectThePatientType:"Select the patient type to proceed quick assessment.",
        Info:"Let's get you started",
        PatientInfo:"Let us know who the patient is.",




        

      }
  }