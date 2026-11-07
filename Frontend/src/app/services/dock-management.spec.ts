import { TestBed } from '@angular/core/testing';

import { DockManagement } from './dock-management';

describe('DockManagement', () => {
  let service: DockManagement;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DockManagement);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
