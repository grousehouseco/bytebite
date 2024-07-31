import { Component } from '@angular/core';
import {MatButtonModule} from '@angular/material/button';

@Component({
  selector: 'app-logo-button',
  standalone: true,
  imports: [MatButtonModule],
  template: `
    <button mat-icon-button class="logo-button">
      <img class="logo" src="chef.svg"/>
    </button>
  `,
  styles: `
    .logo-button{
      height: 48px;
      width: 48px;
      margin-right: 5px;
    }
    .logo {
      height: 32px;
      width: 32px;
    }
  `
})
export class LogoButtonComponent {

}
