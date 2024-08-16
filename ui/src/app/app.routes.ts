import { Routes } from '@angular/router';
import { DpRootComponent } from './components/digital-pantry/dp-root/dp-root.component';
import { RrRootComponent } from './components/recipe-recon/rr-root/rr-root.component';

export const routes: Routes = [
  {path: 'digital-pantry', component: DpRootComponent},
  {path: 'recipe-recon', component: RrRootComponent}
];
