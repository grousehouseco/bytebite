import { Component, EventEmitter, Output } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatIconModule } from '@angular/material/icon';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { CameraComponent } from "../../shared/camera/camera.component";
import { WebcamImage } from 'ngx-webcam';
import { NgIf } from '@angular/common';

@Component({
  selector: 'app-scan-dialog',
  standalone: true,
  imports: [MatDialogModule, MatCardModule, MatButtonModule, MatIconModule, MatFormFieldModule, MatInputModule, CameraComponent, NgIf],
  template: `
  <h2 mat-dialog-title>Scan Receipt</h2>
  <mat-dialog-content>
    <app-camera *ngIf="!image" (scan)="imageTaken($event)"></app-camera>
    <img class="img-container" *ngIf="image" [src]="image" class="img-taken"/>
  </mat-dialog-content>
  <mat-dialog-actions *ngIf="image">
    <button mat-flat-button (click)="retake()">Retake</button>
    <button mat-flat-button [mat-dialog-close]="this.image" cdkFocusInitial>Confirm</button>
  </mat-dialog-actions>
  `,
  styleUrl: './scan-dialog.component.css'
})
export class ScanDialogComponent {

  image: string | undefined = undefined;
  imageTaken(img: WebcamImage){
    this.image = img.imageAsDataUrl;
  }
  retake(){
    this.image = undefined;
  }
}
