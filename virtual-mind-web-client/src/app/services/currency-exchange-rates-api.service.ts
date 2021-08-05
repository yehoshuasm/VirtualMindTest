import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CurrencyExchangeRate } from '../models/currency-exchange.model';

@Injectable({
  providedIn: 'root'
})
export class CurrencyExchangeRatesApiService {

  constructor(private httpClient: HttpClient) { }

  getCurrencyExchangeRate$(currencyCode: string): Observable<CurrencyExchangeRate> {
    return this.httpClient.get<CurrencyExchangeRate>(`${environment.virtualMindApiBaseUri}/api/exchange/rates/${currencyCode}`);
  }
}
