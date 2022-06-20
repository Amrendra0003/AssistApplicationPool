import { Injectable } from "@angular/core";



@Injectable({
    providedIn: "root"
})
export class DashboardVerificationValidation {

    ValidateIncomeForm(documentType :string, HouseHoldMemberId : string) : boolean
    {
        if(documentType == "") return false
        else if (HouseHoldMemberId == "") return false;       
        return true;
    }
    ValidateDocumentForm(documentType :string) : boolean
    {
        if(documentType == "") return false      
        return true;
    }

}
