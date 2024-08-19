import { trigger, state, style, transition, animate } from '@angular/animations';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatMenuModule } from '@angular/material/menu';
import { MatExpansionModule } from '@angular/material/expansion';

@Component({
  selector: 'app-add',
  standalone: true,
  imports: [MatCardModule, MatIconModule,MatDialogModule,CommonModule,MatMenuModule,MatExpansionModule],
  animations: [],
  template: `
  <mat-expansion-panel hideToggle>
    <mat-expansion-panel-header>
      <mat-panel-title>
        <span class="material-symbols-rounded add-menu">add</span>  
        Add Groceries 
      </mat-panel-title>
    </mat-expansion-panel-header>
    <button mat-menu-item mat-icon-button (click)="openDialog('b')"> 
      <span class="material-symbols-rounded add-menu">barcode</span>
      Scan a barcode
    </button>
    <button mat-menu-item mat-icon-button (click)="openDialog('r')"> 
      <span class="material-symbols-rounded add-menu">receipt_long</span>
      Photograph a receipt
    </button>
    <button mat-menu-item mat-icon-button (click)="openDialog('u')"> 
      <span class="material-symbols-rounded add-menu">edit</span>
      Enter a UPC
    </button>
    <button mat-menu-item mat-icon-button (click)="openDialog('us')"> 
      <span class="material-symbols-rounded add-menu">edit_note</span>
      Bulk enter UPCs
    </button>
  </mat-expansion-panel>
  `,
  styles: `
  .add-menu {
    vertical-align: -0.25em;
    margin-right: 5px;
  }
  `
})
export class AddComponent {
  isOpen = false;
  toggle() {
    this.isOpen = !this.isOpen;
    console.log(this.isOpen)
  }
  openDialog(dType: string){
    switch(dType){
      case 'b':
        break;
      case 'r':
        break;
      case 'u':
        break;
      case 'us':
        break;
    }
  }
}
