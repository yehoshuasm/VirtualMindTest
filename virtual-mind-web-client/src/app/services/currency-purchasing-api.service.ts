import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CurrencyPurchasingOperationResult } from '../models/currency-purchasing-operation-result.model';
import { CurrencyPurchasingOrder } from '../models/currency-purchasing-order.model';

@Injectable({
  providedIn: 'root'
})
export class CurrencyPurchasingApiService {

  constructor(private httpClient: HttpClient) { }

  postCurrencyPurchasingOrder$(userId: string, currencyPurchasingOrder: CurrencyPurchasingOrder): Observable<CurrencyPurchasingOperationResult> {
    return this.httpClient.post<CurrencyPurchasingOperationResult>(`${environment.virtualMindApiBaseUri}/api/exchange/purchasing/${userId}`, currencyPurchasingOrder);
  }
}
