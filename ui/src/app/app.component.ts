import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToolbarComponent } from "./components/shared/toolbar/toolbar.component";
import { DpRootComponent } from "./components/digital-pantry/dp-root/dp-root.component";
import { RrRootComponent } from './components/recipe-recon/rr-root/rr-root.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, ToolbarComponent, DpRootComponent, RrRootComponent],
  template: `
    <app-toolbar></app-toolbar>
    <router-outlet></router-outlet>
  `,
  styles: [],
})
export class AppComponent {
  title = 'ByteBite';
}
