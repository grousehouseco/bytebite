import { Component, Input, OnChanges, SimpleChange, SimpleChanges } from '@angular/core';
import {MatTableDataSource, MatTableModule} from '@angular/material/table';
import { GroceryItem } from '../../../models/grocery-item';

@Component({
  selector: 'app-grocery-table',
  standalone: true,
  imports: [MatTableModule],
  template: `
    <table mat-table [dataSource]="dataSource" class="food-table">
      <ng-container matColumnDef="upc">
        <th mat-header-cell *matHeaderCellDef> UPC </th>
        <td mat-cell *matCellDef="let element"> {{element.code}} </td>
      </ng-container>

      <!-- Name Column -->
      <ng-container matColumnDef="brand">
        <th mat-header-cell *matHeaderCellDef> Brand </th>
        <td mat-cell *matCellDef="let element"> {{element.brands}} </td>
      </ng-container>

      <!-- Weight Column -->
      <ng-container matColumnDef="name">
        <th mat-header-cell *matHeaderCellDef> Name </th>
        <td mat-cell *matCellDef="let element"> {{element.product_name}} </td>
      </ng-container>

      <!-- Weight Column -->
      <ng-container matColumnDef="quantity">
        <th mat-header-cell *matHeaderCellDef> Quantity </th>
        <td mat-cell *matCellDef="let element"> {{element.product_quantity}} {{element.product_quantity_unit}} </td>
      </ng-container>

      <!-- Weight Column -->
      <ng-container matColumnDef="image">
        <th mat-header-cell *matHeaderCellDef> Image </th>
        <td mat-cell *matCellDef="let element"> 
          <img [src]="element.image_thumb_url"/>
        </td>
      </ng-container>

      <tr mat-header-row *matHeaderRowDef="displayedColumns"></tr>
      <tr mat-row *matRowDef="let row; columns: displayedColumns;"></tr>
    </table>
  `,
  styleUrl: './grocery-table.component.css'
})
export class GroceryTableComponent implements OnChanges {
  @Input() data!: GroceryItem[];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>(this.data);
  displayedColumns: string[] = ['upc', 'brand', 'name', 'quantity', 'image'];
  constructor(){}

  ngOnChanges(changes: SimpleChanges): void{
    if(changes['data']){
      this.dataSource.data = changes['data'].currentValue;
    }
  }
}
