import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DpRootComponent } from './dp-root.component';

describe('DpRootComponent', () => {
  let component: DpRootComponent;
  let fixture: ComponentFixture<DpRootComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DpRootComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DpRootComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
