import { ComponentFixture, TestBed } from '@angular/core/testing';
import { AppComponent } from './app.component';
import { ReactiveFormsModule, FormBuilder } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { of, throwError } from 'rxjs';  // To mock HTTP responses
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';

describe('AppComponent', () => {
  let fixture: ComponentFixture<AppComponent>;
  let component: AppComponent;
  let httpMock: HttpTestingController;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ReactiveFormsModule, HttpClientModule, HttpClientTestingModule,AppComponent],  
      
      providers: [FormBuilder],  
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppComponent);
    component = fixture.componentInstance;
    httpMock = TestBed.inject(HttpTestingController);  
    fixture.detectChanges();
  });

  it('should create the form with required fields', () => {
    expect(component.reimbursementForm).toBeTruthy();  
    expect(component.reimbursementForm.controls['purchaseDate']).toBeTruthy();
    expect(component.reimbursementForm.controls['amount']).toBeTruthy();
    expect(component.reimbursementForm.controls['description']).toBeTruthy();
    expect(component.reimbursementForm.controls['receipt']).toBeTruthy();
  });

  it('should mark form as invalid if fields are not filled', () => {
    const form = component.reimbursementForm;
    expect(form.valid).toBeFalsy();  
  });

  it('should validate the "amount" field to be a positive number', () => {
    const amountControl = component.reimbursementForm.controls['amount'];

    amountControl.setValue(-10);
    expect(amountControl.valid).toBeFalsy();  

    amountControl.setValue(100);
    expect(amountControl.valid).toBeTruthy();  
  });

  it('should validate the "purchaseDate" field to be required', () => {
    const purchaseDateControl = component.reimbursementForm.controls['purchaseDate'];
    purchaseDateControl.setValue('');
    expect(purchaseDateControl.invalid).toBeTruthy();  

    purchaseDateControl.setValue('2025-04-08');
    expect(purchaseDateControl.valid).toBeTruthy();  
  });

  it('should allow file to be selected', () => {
    const fileInput = document.createElement('input');
    fileInput.type = 'file';
    const file = new File(['test content'], 'receipt.jpg', { type: 'image/jpeg' });
    
    const event = { target: { files: [file] } };
    component.onFileChange(event);
    expect(component.selectedFile).toBe(file);  
  });

  it('should disable the submit button if the form is invalid', () => {
    const submitButton = fixture.nativeElement.querySelector('button');
    expect(submitButton.disabled).toBeTruthy;  

    component.reimbursementForm.controls['purchaseDate'].setValue('2025-04-08');
    component.reimbursementForm.controls['amount'].setValue(100);
    component.reimbursementForm.controls['description'].setValue('Test description');
    fixture.detectChanges();
    
    expect(submitButton.disabled).toBeFalsy;  
  });

  it('should call the onSubmit method when the form is valid and submit the form', () => {
    spyOn(component, 'onSubmit'); 

    
    component.reimbursementForm.controls['purchaseDate'].setValue('2025-04-08');
    component.reimbursementForm.controls['amount'].setValue(100);
    component.reimbursementForm.controls['description'].setValue('Test description');
    fixture.detectChanges();

    
    const form = fixture.nativeElement.querySelector('form');
    form.dispatchEvent(new Event('submit'));

    expect(component.onSubmit).toHaveBeenCalled();  
  });

});
