import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DockList } from './dock-list';

describe('DockList', () => {
  let component: DockList;
  let fixture: ComponentFixture<DockList>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [DockList]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DockList);
    component = fixture.componentInstance;
    await fixture.whenStable();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
