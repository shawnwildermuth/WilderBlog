// emailService.ts
import {Injectable} from '@angular/core';
import {Http, Headers} from '@angular/http';

export interface IContactMessage {
    name: string,
    email: string,
    subject: string,
    msg: string
}

@Injectable()
export class EmailService {
    _http: Http;

    constructor(http: Http) {
        this._http = http;
    }

    public SendMessage(msg: IContactMessage) {

        let headers = new Headers();
        headers.append("Content-Type", "application/json");

        return this._http.post("/contact", JSON.stringify(msg), { headers: headers });
    }
}