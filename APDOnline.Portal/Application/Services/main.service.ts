import { User } from '../entities/user.entity';
import { Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { Headers, RequestOptions } from '@angular/http';
import { HttpService } from './http.service';


@Injectable()
export class MainService {

    constructor(private httpService: HttpService) { }    

    public validateuser(user: User): Observable<any> {
        let url = "APDOnlineAPI/api/main/InitializeApplication";
        return this.httpService.httpPostWithNoBlock(user, url);
    }
}