import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditBooking } from './add-edit-booking';

describe('AddEditBooking', () => {
  let component: AddEditBooking;
  let fixture: ComponentFixture<AddEditBooking>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddEditBooking]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditBooking);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
