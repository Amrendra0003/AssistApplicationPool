import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
    name: "FormatDocumentType"
})

export class FormatDocumentType implements PipeTransform 
{

    transform(value: any, docTypeList: any) 
    {       
        var index = 0;
        var i = 0;
        for (let data in docTypeList)
        {
            if(docTypeList[i] == value) index = i;
            i++
        }
        if(index < docTypeList.length - 1) return value + ",";
        else return value;
    }
}

