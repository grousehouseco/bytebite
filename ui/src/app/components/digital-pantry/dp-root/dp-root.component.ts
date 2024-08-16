import { Component, inject } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { AddDialogComponent } from '../add-dialog/add-dialog.component';
import { MatCardModule } from '@angular/material/card';
import { ScanDialogComponent } from '../scan-dialog/scan-dialog.component';
import { ExtractTextService } from '../../../services/extract-text.service';
import { NgFor, NgIf } from '@angular/common';
import { GroceryTableComponent } from "../../grocery-table/grocery-table.component";
import { GroceryItem } from '../../../models/grocery-item';

@Component({
  selector: 'app-dp-root',
  standalone: true,
  imports: [MatButtonModule, MatIconModule, MatCardModule, NgIf, NgFor, GroceryTableComponent],
  template: `
  <div class="dp-container">
    <button mat-fab extended class="pantry-button add" (click)="openAddDialog()">
      <mat-icon class="material-symbols-rounded">add</mat-icon>
      Add groceries
    </button>
    <button mat-fab extended class="pantry-button remove">
      <mat-icon class="material-symbols-rounded">remove</mat-icon>
      Remove groceries
    </button>
    <app-grocery-table *ngIf="groceryData" [data]="groceryData"></app-grocery-table>
  </div>
  `,
  styles: `
    .data-box {
      height: 60%;
      width: 90%;
      border: 1px solid #000000;
      overflow: scroll;
      display: flex;
      flex-direction: column;
    }
    .entry {
      border: 1px solid green;
    }
    .dp-container {
      height: 90%;
      width: 100%;
      display: flex;
      flex-direction: column;
      gap: 20px;
      align-items: center;
    }
    .pantry-button {
      margin: 2px;
      width: auto;
    }
  `
})
export class DpRootComponent {
  readonly dialog = inject(MatDialog);
  addAction: string = "";
  groceryData: GroceryItem[] | undefined;

  constructor(private extractService: ExtractTextService){}

  openAddDialog() {
    const dialogRef = this.dialog.open(AddDialogComponent, {
      data: {},
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        if(result === 'scan'){
          this.openScanDialog();
        }
      }
    });
  }

  openManualEntryDialog(){
    
  }
  openScanDialog(){
    const dialogRef = this.dialog.open(ScanDialogComponent, {
      data: {},
    });
    dialogRef.afterClosed().subscribe(result => {
      if (result !== undefined) {
        this.extractService.readUpcFromImage(result).then((res)=>{
          if(res !== undefined){
            console.log(res)
            this.extractService.getGroceryData(res).then(grocRes => 
            {
              console.log(grocRes);
              this.groceryData = grocRes.data.products;
            })
            //this.extractService.getMock(res).then(grocRes => this.groceryData = grocRes);
          }
        })
      }
    });
  }
}
