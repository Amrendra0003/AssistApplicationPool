
export enum Role {
    UnAuthorised = 'UnAuthorised',
    Patient = 'Patient',
    Advocate = 'Advocate',
    Admin = 'Admin'
}
export enum Resource {
    PatientDashboard = 'PatientDashboard',
    Assessment = 'Assessment',
    Verification = 'Verification'
}
export class Permission1 {
    public resource: Resource;
    constructor(resource: Resource) {
        this.resource = resource;
    }
}