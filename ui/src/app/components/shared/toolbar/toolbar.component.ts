import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { Router } from '@angular/router';

@Component({
  selector: 'app-toolbar',
  standalone: true,
  imports: [MatToolbarModule, MatButtonModule, MatIconModule, MatMenuModule],
  styleUrls: ['./toolbar.component.scss'],
  template: `
    <mat-toolbar class="toolbar">
      <button mat-icon-button [matMenuTriggerFor]="menu" class="logo-button">
        <img class="logo" src="chef.svg"/>
      </button>
      <mat-menu #menu="matMenu">
        <button mat-menu-item (click)="navigate('h')">Byte Bite</button>
        <button mat-menu-item (click)="navigate('dp')">Digital Pantry</button>
        <button mat-menu-item disabled (click)="navigate('rr')">Recipe Recon</button>
      </mat-menu>
      <span id="spacer"></span>
      <div class="toolbar-buttons-container">
        <button mat-icon-button id="toolbar-action">
          <mat-icon class="material-symbols-rounded">settings</mat-icon>
        </button>
        <button mat-icon-button id="toolbar-action">
          <mat-icon class="material-symbols-rounded">face</mat-icon>
        </button>
      </div>
    </mat-toolbar>
  `
})
export class ToolbarComponent {
  constructor(private router: Router){}
  navigate(loc: string){
    switch(loc){
      case 'h':
        this.router.navigate(['']);
        break;
      case 'dp':
        this.router.navigate(['digital-pantry']);
        break;
      case 'rr':
        this.router.navigate(['recipe-recon']);
        break;
      default:
        break;
    }
  }
}
