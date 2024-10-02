import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExpandingCardComponent } from './expanding-card.component';

describe('ExpandingCardComponent', () => {
  let component: ExpandingCardComponent;
  let fixture: ComponentFixture<ExpandingCardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExpandingCardComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ExpandingCardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
