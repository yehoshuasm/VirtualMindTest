import { TestBed } from '@angular/core/testing';

import { CurrencyPurchasingService } from './currency-purchasing.service';

describe('CurrencyPurchasingService', () => {
  let service: CurrencyPurchasingService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(CurrencyPurchasingService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
