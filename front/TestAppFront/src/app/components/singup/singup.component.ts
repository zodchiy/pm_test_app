import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EqualToValidator } from 'src/app/common/EqualToValidator';
@Component({
  selector: 'app-singup',
  templateUrl: './singup.component.html',
  styleUrls: ['./singup.component.css']
})
export class SignupComponent implements OnInit {
  public firstStepForm!: FormGroup;
  public secondStepForm!: FormGroup;
  constructor(private formbuilder: FormBuilder) { }

  ngOnInit() {
    this.firstStepForm = this.formbuilder.group({
      login: ['', { validators: [Validators.required, Validators.email], updateOn: 'blur'}],
      password: ['', [Validators.required, Validators.pattern('(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$')]],
      confirmPassword: ['', Validators.required],
      isAgree: [false, Validators.requiredTrue],
    },
    {
      Validators: EqualToValidator('password', 'confirmPassword'),
    });
    this.secondStepForm = this.formbuilder.group({
      country: ['', Validators.required],
      province: ['', Validators.required],
    });
  }
  
  get login() { return this.firstStepForm.get('login'); }
  get password() { return this.firstStepForm.get('password'); }
  get confirmPassword() { return this.firstStepForm.get('confirmPassword'); }
  get isAgree() { return this.firstStepForm.get('isAgree'); }

  
  get country() { return this.secondStepForm.get('country'); }
  get province() { return this.secondStepForm.get('province'); }
  
  
}
