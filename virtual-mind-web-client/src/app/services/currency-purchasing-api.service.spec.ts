import { TestBed } from '@angular/core/testing';

import { CurrencyPurchasingApiService } from './currency-purchasing-api.service';

describe('CurrencyPurchasingApiService', () => {
  let service: CurrencyPurchasingApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrencyPurchasingApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
