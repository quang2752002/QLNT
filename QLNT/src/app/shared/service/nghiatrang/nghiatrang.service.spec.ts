import { TestBed } from '@angular/core/testing';

import { NghiatrangService } from './nghiatrang.service';

describe('NghiatrangService', () => {
  let service: NghiatrangService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NghiatrangService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
