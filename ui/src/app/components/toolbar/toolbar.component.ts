import { Component } from '@angular/core';
import {MatIconModule} from '@angular/material/icon';
import {MatToolbarModule} from '@angular/material/toolbar';
import { LogoButtonComponent } from "../logo-button/logo-button.component";

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [MatToolbarModule, MatIconModule, LogoButtonComponent],
  template: `
    <mat-toolbar class="toolbar">
      <app-logo-button/>
      <span class="byte">BYTE</span>
      <span class="bite">BITE</span>
    </mat-toolbar>
  `,
  styles: `
  .toolbar {
    background: #001f3f;
  }
  .byte {
    font-family: "Tiny5", sans-serif;
    color: #50c878;
    font-size: 36px;
  }  
  .bite {
    font-family: "Bungee", sans-serif;
    color: #fffff0;
    font-size: 32px;
    letter-spacing: 2px;
  }
  `
})
export class ToolbarComponent {

}
