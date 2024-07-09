// بسم الله الرحمن الرحيم

import { AfterContentInit, AfterRenderPhase, AfterViewChecked, AfterViewInit, Component, DoCheck, NgModule, OnChanges, OnDestroy, OnInit, SimpleChanges  } from '@angular/core';

import {FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators, FormControl, FormGroupDirective, AbstractControl} from '@angular/forms' 
import { Subscription } from 'rxjs';
import { User } from '../../Model/User.Model';
import {ActivatedRoute, Router} from '@angular/router';

import { NgFor, NgForOf, NgIf } from '@angular/common';
import { ApiConnectionService } from '../../../Services/api-connections.service';


@Component({
  selector: 'app-reg-form',
  standalone: true,
  imports: [FormsModule, NgIf, ReactiveFormsModule, NgFor, NgForOf],
  templateUrl: './reg-form.component.html',
  styleUrl: './reg-form.component.css'
})
export class RegFormComponent  implements OnDestroy, OnInit{

  
  model: User;

  selectedGov: string = '';

  

govs:any[] = []
cities: any[] = [];


 

  private addUserSubscription?: Subscription;


  constructor(private addUserService: ApiConnectionService, 
    private router:Router, private route: ActivatedRoute)
  {
    this.model ={
      FirstName: '',
      MiddleName: '',
      LastName: '',
      BirthDate: new Date,
    MobileNumber: '',
    Email: '',

    Addresses: [{
        Governorate: '',
        City: '',
        Street: '',
        BuildingNumber: '',
        FlatNumber: 0
    }]
  };
}
public RegForm = new FormGroup({

  firstName: new FormControl('', [Validators.required, Validators.nullValidator]),
  middleName: new FormControl('',  [Validators.required, Validators.nullValidator]),
  lastName: new FormControl('', [Validators.required, Validators.nullValidator]),
  mobileNumber: new FormControl('', [Validators.required, Validators.nullValidator]),
  emailInput: new FormControl('', [Validators.required, Validators.email, Validators.nullValidator]),
  dateInput: new FormControl('', [Validators.required, this.validateDate, Validators.nullValidator]),
  gov: new FormControl('', [Validators.required]),
  city: new FormControl('', [Validators.required]),
  street: new FormControl('', [Validators.required]),
  buildingNumber: new FormControl('', [Validators.required, Validators.nullValidator]),
  flatNumber: new FormControl('', [Validators.required, Validators.nullValidator])

})

get firstName(){
  return this.RegForm.get('firstName');
}

get middleName(){
  return this.RegForm.get('middleName');
}

get lastName(){
  return this.RegForm.get('lastName');
}

get dateInput(){
  return this.RegForm.get('dateInput');
}
get emailInput()
{
  return this.RegForm.get('emailInput');
}
get mobileNumber(){
  return this.RegForm.get('mobileNumber');
}
get gov(){
  return this.RegForm.get('gov');
}
get city(){
  return this.RegForm.get('city');
}
get street(){
  return this.RegForm.get('street');
}
get buildingNumber(){
  return this.RegForm.get('buildingNumber');
}
get flatNumber(){
  return this.RegForm.get('flatNumber');
}

validateDate(control: AbstractControl){
  const value = control.value;

  if (value == null || value == '' 
                                 || value >= new Date(new Date().getFullYear()-20, 0, new Date().getMonth())
                                                                                                              .toISOString().split('T')[0] 
                                 ) {
                                  
    return { required: true };
  } else {
    return null;
  }
}

  ngOnInit(): void {

          this.addUserService.getgovs().subscribe({
            next:(response)=>{
              this.govs = response;
            }
        });

    }


    onSelected(value: any): void {
      this.selectedGov = value.target.value;

      this.addUserService.getCitiesBygov(this.selectedGov)
        .subscribe({
          next:(response)=>{
            this.cities = response;
          }
    });
    }


  onFormSubmit():void {
    this.addUserSubscription = this.addUserService.addUser(this.model)
    .subscribe({
      next:(response)=>{
          this.router.navigate(['']).then(() => window.location.reload());
      }
    })
  }

  ngOnDestroy(): void {
    this.addUserSubscription?.unsubscribe();  }



    



}
