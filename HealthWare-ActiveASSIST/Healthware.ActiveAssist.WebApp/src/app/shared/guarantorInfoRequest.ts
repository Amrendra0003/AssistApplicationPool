export interface GuarantorInfoRequest {
    guarantorId:number;
    assessmentId: number;
    relationshipWithPatient: string;
    firstName: string;
    lastName: string;
    middleName: string;
    suffix: string;
    dateOfBirth:string;
    emailAddress: string;
    cell: string;
    ssnNumber: string;
    countyCode :any;
    sssnNumber:any;
    basicInfoId:any;
    reasonNoSsn:any,
}