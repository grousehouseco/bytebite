import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RrRootComponent } from './rr-root.component';

describe('RrRootComponent', () => {
  let component: RrRootComponent;
  let fixture: ComponentFixture<RrRootComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [RrRootComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(RrRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
