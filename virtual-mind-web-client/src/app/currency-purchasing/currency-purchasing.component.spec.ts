import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrencyPurchasingComponent } from './currency-purchasing.component';

describe('CurrencyPurchasingComponent', () => {
  let component: CurrencyPurchasingComponent;
  let fixture: ComponentFixture<CurrencyPurchasingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CurrencyPurchasingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CurrencyPurchasingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
