import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroceryTableComponent } from './grocery-table.component';

describe('GroceryTableComponent', () => {
  let component: GroceryTableComponent;
  let fixture: ComponentFixture<GroceryTableComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [GroceryTableComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GroceryTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
