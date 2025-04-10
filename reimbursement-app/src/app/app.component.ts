import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
@Component({
  selector: 'app-root',
 
  imports: [ReactiveFormsModule, HttpClientModule,CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  readonly url: string = "http://localhost:5161/api/reimbursement";
  reimbursementForm !: FormGroup ;  
  selectedFile: File | null = null;
 successMessage: string = "";
 errorMessage: string ="";
  constructor(private fb: FormBuilder, private http: HttpClient) {}

  ngOnInit(): void {
    this.reimbursementForm = this.fb.group({
      purchaseDate: ['', Validators.required],
      amount: ['', [Validators.required, Validators.min(0)]],
      description: ['', Validators.required],
      receipt: [null, Validators.required],
    });
  }
  onFileChange(event: any): void {
    this.selectedFile = event.target.files[0];
  }
  onSubmit(): void {
    const formData = new FormData();
    formData.append('purchaseDate', this.reimbursementForm?.get('purchaseDate')?.value);
    formData.append('amount', this.reimbursementForm?.get('amount')?.value);
    formData.append('description', this.reimbursementForm?.get('description')?.value);
    if (this.selectedFile) {
      formData.append('receipt', this.selectedFile, this.selectedFile.name);
    }
    this.http.post( this.url, formData).subscribe(
      res => {
        console.log(res);
        this.successMessage = "Reimbursement submitted successfully!";
        this.errorMessage = '';
      },
      err => {
        console.error('Error Response:', err);
        console.error(err);
        this.errorMessage = "Something went wrong. Please try again.";
        this.successMessage = '';
      }
    );}
    
    
  }