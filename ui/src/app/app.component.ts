import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { ToolbarComponent } from './components/toolbar/toolbar.component';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [
    RouterOutlet,
    ToolbarComponent
  ],
  template: `
    <app-toolbar/>

    <router-outlet />
  `,
  styles: [],
})
export class AppComponent {
  title = 'bytebite';
}
