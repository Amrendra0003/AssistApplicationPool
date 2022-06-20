import { AbstractControl, ValidationErrors } from '@angular/forms';
export default class DateValidation {
    static validateDate(val: string) {
        var regexData = /^(0?[1-9]|1[0-2])\/(0?[1-9]|1\d|2\d|3[01])\/(19|20)\d{2}$/;
        return regexData.test(val);
    }
    static validateFutureDate(val: string) {
        var choosenDate = new Date(val);
        var todayDate = new Date();
        return choosenDate > todayDate ? false : true;
    }
    static closeCal() {
        var elementstyle = document.getElementsByTagName('bs-datepicker-container') as HTMLCollectionOf<HTMLElement>;
        if (elementstyle[0] != undefined && elementstyle[0].style && elementstyle[0].style.display) {
            if (elementstyle[0].style.display == "block") {
                elementstyle[0].style.display = 'none';
            }
        }
    }
    static isValidDate(date: string) {
        var splitDate = date.split("/");
        var month = parseInt(splitDate[0]);
        var day = parseInt(splitDate[1]);
        var year = parseInt(splitDate[2]);
        if (month === 2) {
            if (DateValidation.isLeapYear(year)) {
                return day >= 1 && day <= 29 ? true : false;
            } else {
                return day >= 1 && day <= 28 ? true : false;
            }
        } else if (month === 4 || month === 6 || month === 9 || month === 11) {
            return day >= 1 && day <= 30 ? true : false;
        } else {
            return true;
        }
    }
    static isLeapYear(yr: any) {
        return ((yr % 4 == 0) && (yr % 100 != 0)) || (yr % 400 == 0);
    }
    static isToDateGreaterThanFrom(from: string, to: string) {
        var fromDate = new Date(from);
        var toDate = new Date(to);
        if (fromDate >= toDate) {
            return false;
        }
        return true;
    }
    static futureDateValidation(control: AbstractControl): ValidationErrors | null {
        var dateVal = control.value as string;
        if (dateVal) {
            if (dateVal.length == 10) {
                if (DateValidation.validateDate((control.value as string))) {
                    if (!DateValidation.validateFutureDate((control.value as string))) {
                        return { futureDateValidation: true }
                    }
                }
            }
        }
        return null;
    }
    static validateDateFormat(control: AbstractControl): ValidationErrors | null {
        var dateVal = control.value as string;
        if (dateVal) {
            if (dateVal.length == 10) {
                if (DateValidation.validateDate((control.value as string))) {
                    if (DateValidation.isValidDate((control.value as string))) {
                        return null;
                    } else {
                        return { validateDateFormat: true }
                    }
                } else {
                    return { validateDateFormat: true }
                }
            }
        }
        return null;
    }
}
