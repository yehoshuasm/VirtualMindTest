import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { CurrencyPurchasingOrder } from '../models/currency-purchasing-order.model';
import { CurrencyPurchasingService } from '../services/currency-purchasing.service';

@Component({
  selector: 'app-currency-purchasing',
  templateUrl: './currency-purchasing.component.html',
  styleUrls: ['./currency-purchasing.component.scss']
})
export class CurrencyPurchasingComponent implements OnInit {
  currencyPurchasingOrderForm: FormGroup;
  isSubmitting: boolean;
  isSubmitted: boolean;
  isError: boolean;
  error: string;

  constructor(private formBuilder: FormBuilder, private currencyPurchasingService: CurrencyPurchasingService) {
    this.currencyPurchasingOrderForm = this.buildForm();
  }

  ngOnInit(): void {
  }

  onSubmit() {
    if(this.isSubmitting){
      return;
    }

    this.isSubmitting= true;
    this.error = '';
    this.isError = false;
    this.isSubmitted = false;

    const userId = this.currencyPurchasingOrderForm.value.userId;

    const currencyPurchasingOrder: CurrencyPurchasingOrder = {
      amount: Number(this.currencyPurchasingOrderForm.value.amount),
      currencyCode: this.currencyPurchasingOrderForm.value.currencyCode,
    };

    this.currencyPurchasingService.postCurrencyPurschaseOrder$(userId, currencyPurchasingOrder)
      .subscribe(result => {
        if(result.status == "Completed") {
          this.isSubmitted = true;
        }
        else {
          this.isError = true;
          this.error = result.error;
        }
        this.isSubmitting = false;
      }, error => {
        this.error = "Ocurrió un error";
        this.isSubmitting = false;
      })
  }

  private buildForm(): FormGroup {
    return this.formBuilder.group({
      currencyCode: new FormControl('', Validators.required),
      amount: new FormControl('', Validators.required),
      userId: new FormControl('', Validators.required)
    });
  }
}
