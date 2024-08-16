import { NgIf, NgFor } from '@angular/common';
import {Component, OnInit, Output, EventEmitter} from '@angular/core';
import {Subject, Observable} from 'rxjs';
import {WebcamImage, WebcamInitError, WebcamModule, WebcamUtil} from 'ngx-webcam';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';

@Component({
  selector: 'app-camera',
  standalone: true,
  imports: [NgIf, NgFor, MatButtonModule, MatIconModule, WebcamModule],
  template: `
  <div class="cam-container">
    <webcam class="webcam"
            [width]="400" 
            [trigger]="triggerObservable" 
            (imageCapture)="handleImage($event)" 
            *ngIf="!webcamImage"
            [allowCameraSwitch]="false"
            [videoOptions]="videoOptions"
            [imageQuality]="1"
            (initError)="handleInitError($event)"
    ></webcam>
    <button mat-fab class="camera-button" (click)="triggerSnapshot();" *ngIf="!webcamImage">
      <mat-icon class="material-symbols-rounded">photo_camera</mat-icon>
    </button>
  </div>
  `,
  styleUrl: './camera.component.css'
})
export class CameraComponent implements OnInit {
  @Output() scan = new EventEmitter<WebcamImage>();

  public multipleWebcamsAvailable = false;
  public videoOptions: MediaTrackConstraints = {
    facingMode: { ideal: "environment" },
  };
  public errors: WebcamInitError[] = [];

  // latest snapshot
  public webcamImage: WebcamImage | undefined = undefined;

  // webcam snapshot trigger
  private trigger: Subject<void> = new Subject<void>();

  public ngOnInit(): void {
    WebcamUtil.getAvailableVideoInputs()
      .then((mediaDevices: MediaDeviceInfo[]) => {
        this.multipleWebcamsAvailable = mediaDevices && mediaDevices.length > 1;
      });
  }

  public triggerSnapshot(): void {
    this.trigger.next();
  }

  public handleInitError(error: WebcamInitError): void {
    this.errors.push(error);
  }

  public handleImage(webcamImage: WebcamImage): void {
    this.webcamImage = webcamImage;
    this.scan.emit(webcamImage);
  }

  public get triggerObservable(): Observable<void> {
    return this.trigger.asObservable();
  }
}
