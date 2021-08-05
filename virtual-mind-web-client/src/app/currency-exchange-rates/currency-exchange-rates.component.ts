import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { CurrencyExchangeRate } from '../models/currency-exchange.model';
import { CurrencyExchangeRatesService } from '../services/currency-exchange-rates.service';

@Component({
  selector: 'app-currency-exchange-rates',
  templateUrl: './currency-exchange-rates.component.html',
  styleUrls: ['./currency-exchange-rates.component.scss']
})
export class CurrencyExchangeRatesComponent implements OnInit {
  isLoading: Observable<boolean> = this.currencyExchangeRatesService.isLoading;
  rates: Observable<CurrencyExchangeRate[]> = this.currencyExchangeRatesService.currencyExchangeRates;

  constructor(private currencyExchangeRatesService: CurrencyExchangeRatesService) {
  }

  ngOnInit(): void {
    this.currencyExchangeRatesService.optimisticLoadCurrencyExchangeRates();
  }

  public update(): void{
    this.currencyExchangeRatesService.optimisticLoadCurrencyExchangeRates();
  }
}
