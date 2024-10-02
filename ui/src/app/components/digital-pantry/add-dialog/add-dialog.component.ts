import { Component } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-add-dialog',
  standalone: true,
  imports: [MatDialogModule, MatCardModule, MatButtonModule, MatIconModule],
  template: `
  <div class="add-dialog">
    <h2 mat-dialog-title>Add Groceries</h2>
    <mat-dialog-actions>
      <button mat-flat-button [mat-dialog-close]="">Cancel</button>
      <button mat-flat-button [mat-dialog-close]="'manual'">Manual Entry</button>
      <button mat-flat-button [mat-dialog-close]="'scan'" cdkFocusInitial>Scan Receipt</button>
    </mat-dialog-actions>
  </div>

  `,
  styles: `
    .add-dialog {
    }
  `
})
export class AddDialogComponent {

}
