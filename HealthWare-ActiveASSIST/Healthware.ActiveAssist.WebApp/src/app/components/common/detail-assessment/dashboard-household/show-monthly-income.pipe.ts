import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: "monthlyincome"
})

export class ShowMonthlyIncomePipe implements PipeTransform {

    transform(value: any, control: any) {
        try {
            switch (control) {

                case "Biweekly":
                    return (Math.round(((Number(value) * 2) + Number.EPSILON) * 100) / 100).toFixed(2);
                case "Weekly":
                    return (Math.round(((Number(value) * 4) + Number.EPSILON) * 100) / 100).toFixed(2);
                case "Monthly":
                    return (Math.round(((Number(value) * 1) + Number.EPSILON) * 100) / 100).toFixed(2);
                case "Bimonthly":
                    return (Math.round(((Number(value) / 2) + Number.EPSILON) * 100) / 100).toFixed(2);
                case "Yearly":
                    return (Math.round(((Number(value) / 12) + Number.EPSILON) * 100) / 100).toFixed(2);
                default: {
                    return "";
                }

            }
        }
        catch { return ""; }
    }
}
