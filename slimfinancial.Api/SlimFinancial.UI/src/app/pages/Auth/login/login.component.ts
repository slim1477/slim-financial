import { Component, computed,  inject,  signal } from '@angular/core';
import { FormGroup,FormControl ,Validators, ReactiveFormsModule} from '@angular/forms';
import { MaterialModule } from '../../../core/common/material/material.module';
import { animate, state, style, transition, trigger } from '@angular/animations';
import { AuthService } from '../../../services/auth.service';
import { Router} from '@angular/router';



@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ReactiveFormsModule,MaterialModule],
  providers: [AuthService],
  animations: [
    trigger('next', [
      state('true', style({ translate: 0})),
      state('false', style({ translate: '-100%' })),
      transition('true <=> false', animate('0.75s ease-in-out')),
    ]),
    trigger('show', [
      state('false', style({ translate: '100%' })),
      state('true', style({ translate: '-100%' })),
      transition('false => true', animate('0.75s ease-in-out')),
    ]),
    trigger('showCreds',[
      state('true',style({transform: 'translateY(0)'})),
      state('false',style({transform: 'translateY(-88%'})),
      transition('true <=> false', animate('0.75s ease-in-out'))
    ])
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent{
authService = inject(AuthService)
route = inject(Router)
isShowCred = signal(false); // controls the demo credentials card animation
 isCardOne = signal(true) // controls the username input field animation
 isCardTwo = computed(()=>!this.isCardOne()) // controls the password input field animation

//  user credentials
loginForm = new FormGroup({
  username : new FormControl('',[Validators.required]),
  password: new FormControl('',[Validators.required])
})


 // toggles credential card visibility
  showCreds(){
     this.isShowCred.set(!this.isShowCred())
  }

 
// controls the sign on form animation
  slideForm() {
    if(this.loginForm.get('username')?.valid) this.isCardOne.set(!this.isCardOne()) ;
  }
submitForm(){
  const creds   = this.loginForm.value as Credential
  this.authService.login(creds).subscribe(
    (response) => {
      if (response.success) {
        this.authService.setToken(response?.sessionToken)
        this.route.navigateByUrl("/dashboard/overview")
      }
    }
  )
}
}
