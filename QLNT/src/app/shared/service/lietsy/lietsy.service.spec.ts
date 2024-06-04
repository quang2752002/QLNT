import { TestBed } from '@angular/core/testing';

import { LietsyService } from './lietsy.service';

describe('LietsyService', () => {
  let service: LietsyService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(LietsyService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
