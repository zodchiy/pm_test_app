import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AUTH_API_URL } from '../app-injection-tokens';
import SignUpResponse from '../models/response/SignUpResponse';
import SignUpRequest from '../models/request/SignUpRequest';
@Injectable({
  providedIn: 'root'
})
export class SignUpService {
 
  constructor(private http: HttpClient,
    @Inject(AUTH_API_URL) private apiUrl: string) { }
    doSignUp(model: SignUpRequest): Observable<SignUpResponse>
    {
      return this.http.post<SignUpResponse>(this.apiUrl + 'signup', model);
    }
}
