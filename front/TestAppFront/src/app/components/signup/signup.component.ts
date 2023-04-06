import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatSelectChange } from '@angular/material/select';
import { EqualToValidator } from 'src/app/helpers/EqualToValidator';
import Country from 'src/app/models/dto/country';
import Province from 'src/app/models/dto/province';
import { CountryService } from 'src/app/services/country.service';
import { ProvinceService } from 'src/app/services/province.service';
import { SignUpService } from 'src/app/services/signup.service';
import  SignUpRequest from 'src/app/models/request/SignUpRequest';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent implements OnInit {
  public firstStepForm!: FormGroup;
  public secondStepForm!: FormGroup;
  countryList: Country[] = [];
  provinceList: Province[] = [];
  constructor(
    private formbuilder: FormBuilder, 
    private countryService: CountryService, 
    private provinceService: ProvinceService,
    private signUpService: SignUpService
    ) { }

  ngOnInit() {
    this.countryService
    .getCountries()
    .subscribe((result) => (this.countryList = result.countries));

    this.firstStepForm = this.formbuilder.group({
      login: ['', { validators: [Validators.required, Validators.email], updateOn: 'blur'}],
      password: ['', [Validators.required, Validators.pattern('(?=.*[A-Za-z])(?=.*\\d)[A-Za-z\\d]{8,}$')]],
      confirmPassword: ['', Validators.required],
      isAgree: [false, Validators.requiredTrue],
    },
    {
      validator: EqualToValidator('password', 'confirmPassword'),
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
  
  onCountryChange($event: MatSelectChange){
    if(this.country != null && this.country?.value != null && this.country?.value != 0)
    {
      this.provinceService
      .getProvincesbyCountry(this.country.value)
      .subscribe((result) => (this.provinceList = result.provinces));
    }
  }
 submit(){
  let signUpRequest: SignUpRequest = {
    login: this.login?.value,
    password: this.password?.value,
    countryid: this.country?.value,
    provinceid: this.province?.value
  };
    this.signUpService.doSignUp(signUpRequest).subscribe((result) => 
    {
      if(result.result)
      {
        console.log("Получилось!");
      }
    });
 }

}
