import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: "resourceValue"
})

export class ShowResourceValuePipe implements PipeTransform {

    transform(value: any, percentage: any) {
        try {
            return (Math.round(((Number(value) * (Number(percentage) / 100)) + Number.EPSILON) * 100) / 100).toFixed(2);
        }
        catch { return ""; }
    }
}
