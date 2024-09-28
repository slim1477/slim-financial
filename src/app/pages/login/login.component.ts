import { Component, computed,  signal } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { MaterialModule } from '../../core/common/material/material.module';
import { animate, state, style, transition, trigger } from '@angular/animations';



@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule,MaterialModule],
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

  isShowCred = signal(false); // controls the demo credentials card animation
 isCardOne = signal(true) // controls the username input field animation
 isCardTwo = computed(()=>!this.isCardOne()) // controls the password input field animation

//  user credentials
 username: string = 'slim147';
 password: string = '';

 // toggles credential card visibility
  showCreds(){
  this.isShowCred.set(!this.isShowCred())
  }
// controls the sign on form animation
  slideForm() {
   this.isCardOne.set(!this.isCardOne());
   console.log(this.username)
  }

}
