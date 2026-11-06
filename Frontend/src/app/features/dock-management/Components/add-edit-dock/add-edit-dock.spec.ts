import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditDock } from './add-edit-dock';

describe('AddEditDock', () => {
  let component: AddEditDock;
  let fixture: ComponentFixture<AddEditDock>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [AddEditDock]
    })
    .compileComponents();

    fixture = TestBed.createComponent(AddEditDock);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
