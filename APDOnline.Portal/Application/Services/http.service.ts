import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Headers, RequestOptions } from '@angular/http';
import { SessionService } from '../services/session.service';
import { BlockUIService } from './blockui.service';


@Injectable()
export class HttpService {

    constructor(private http: Http, private blockUIService: BlockUIService) {
    }

    public httpGet(url: string): Observable<any> {

        this.blockUIService.blockUIEvent.emit({
            value: true
        });        

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'q=0.8;application/json;q=0.9');

        let options = new RequestOptions({ headers: headers });

        return this.http.get(url, options).map((response) => this.parseResponse(response, this.blockUIService, true))
            .catch((err) => this.handleError(err, this.blockUIService, true));
    }

    public httpGetWithNoBlock(url: string): Observable<any> {        

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'q=0.8;application/json;q=0.9');

        let options = new RequestOptions({ headers: headers });

        return this.http.get(url, options).map((response) => this.parseResponse(response, this.blockUIService, false))
            .catch((err) => this.handleError(err, this.blockUIService, false));
    }


    public httpDelete(url: string): Observable<any> {

        this.blockUIService.blockUIEvent.emit({
            value: true
        });

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'q=0.8;application/json;q=0.9');

        let options = new RequestOptions({ headers: headers });

        return this.http.delete(url, options).map((response) => this.parseResponse(response, this.blockUIService, true))
            .catch((err) => this.handleError(err, this.blockUIService, true));

    }


    public httpDeleteWithNoBlock(url: string): Observable<any> {        

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'q=0.8;application/json;q=0.9');

        let options = new RequestOptions({ headers: headers });

        return this.http.delete(url, options).map((response) => this.parseResponse(response, this.blockUIService, false))
            .catch((err) => this.handleError(err, this.blockUIService, false));

    }

    public httpPost(object: any, url: string): Observable<any> {

        this.blockUIService.blockUIEvent.emit({
            value: true
        });
     
        let body = JSON.stringify(object);

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'q=0.8;application/json;q=0.9');   

        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, body, options).map((response) => this.parseResponse(response, this.blockUIService, true))
            .catch((err) => this.handleError(err, this.blockUIService, true));

    }


    public httpPostWithNoBlock(object: any, url: string): Observable<any> {

        let body = JSON.stringify(object);

        let headers = new Headers();
        headers.append('Content-Type', 'application/json');
        headers.append('Accept', 'q=0.8;application/json;q=0.9');       

        let options = new RequestOptions({ headers: headers });

        return this.http.post(url, body, options).map((response) => this.parseResponse(response, this.blockUIService, false))
            .catch((err) => this.handleError(err, this.blockUIService, false));

    }


    private handleError(error: any, blockUIService: BlockUIService, blocking: Boolean) {

        let body = error.json();

        if (blocking) {
            blockUIService.blockUIEvent.emit({
                value: false
            });
        }
     
        return Observable.throw(body);

    }

    private parseResponse(response: Response, blockUIService: BlockUIService, blocking: Boolean) {

        let authorizationToken = response.headers.get("Authorization");
        if (authorizationToken != null) {
          
        }

        if (blocking) {
            blockUIService.blockUIEvent.emit({
                value: false
            });
        }
     
        let body = response.json();

        return body;
    }


}