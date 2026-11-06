import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DockManagement } from './dock-management';

describe('DockManagement', () => {
  let component: DockManagement;
  let fixture: ComponentFixture<DockManagement>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DockManagement]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DockManagement);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
