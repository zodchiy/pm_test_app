import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AUTH_API_URL } from '../app-injection-tokens';
import CountryListResponse from '../models/response/CountryListResponse';
@Injectable({
  providedIn: 'root'
})
export class CountryService {
 
  constructor(private http: HttpClient,
    @Inject(AUTH_API_URL) private apiUrl: string) { }
    getCountries(): Observable<CountryListResponse>
    {
      return this.http.get<CountryListResponse>(this.apiUrl + 'countries');
    }
}
