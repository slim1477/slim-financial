import { Signal, Type } from "@angular/core";

export interface WidgetData{
    id: number;
    label : string;
    period: string;
    content : Type<unknown>;

}