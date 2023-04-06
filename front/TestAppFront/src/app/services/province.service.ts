import { Injectable, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { AUTH_API_URL } from '../app-injection-tokens';
import Province from '../models/dto/province';
import ProvinceListResponse from '../models/response/ProvinceListResponse';
@Injectable({
  providedIn: 'root'
})
export class ProvinceService {

  constructor(private http: HttpClient,
    @Inject(AUTH_API_URL) private apiUrl: string) { }
    getProvinces(): Observable<Province[]>
    {
      return this.http.get<Province[]>(this.apiUrl + 'provinces');
    }
    getProvincesbyCountry(countryId: string): Observable<ProvinceListResponse>
    {
      return this.http.get<ProvinceListResponse>(this.apiUrl + `provinces/byCountry/${countryId}`);
    }
}
