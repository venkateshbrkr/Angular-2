import { Component, ElementRef, ApplicationRef } from '@angular/core';
import { MasterComponent } from './shared/master.component';
import { APP_PROVIDERS } from './app.providers';
import 'rxjs/Rx';

@Component({
    selector: 'codeproject-application',
    template: '<master [currentRoute]="currentRoute" [title]="title" [version]="version"></master>',
    directives: [MasterComponent],
    providers: [APP_PROVIDERS]
})
    
export class AppComponent  {

    public title: string;
    public currentRoute: string;  
    public version: string;

    constructor(private elementRef: ElementRef) {

        let native = this.elementRef.nativeElement;

        this.title = native.getAttribute("title");
        this.currentRoute = native.getAttribute("currentRoute");      
        this.version = native.getAttribute("version");               

    }
    

}
