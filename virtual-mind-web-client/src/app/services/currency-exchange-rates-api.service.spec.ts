import { TestBed } from '@angular/core/testing';

import { CurrencyExchangeRatesApiService } from './currency-exchange-rates-api.service';

describe('CurrencyExchangeRatesApiService', () => {
  let service: CurrencyExchangeRatesApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrencyExchangeRatesApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
