import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { CurrencyPurchasingOperationResult } from '../models/currency-purchasing-operation-result.model';
import { CurrencyPurchasingOrder } from '../models/currency-purchasing-order.model';
import { CurrencyPurchasingApiService } from './currency-purchasing-api.service';

@Injectable({
  providedIn: 'root'
})
export class CurrencyPurchasingService {

  constructor(private currencyPurchasingApiService: CurrencyPurchasingApiService) { }

  postCurrencyPurschaseOrder$(userId: string, currencyPurchasingOrder: CurrencyPurchasingOrder): Observable<CurrencyPurchasingOperationResult> {
    return this.currencyPurchasingApiService.postCurrencyPurchasingOrder$(userId, currencyPurchasingOrder);
  }
}
