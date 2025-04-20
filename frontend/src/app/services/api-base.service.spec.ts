import { TestBed } from '@angular/core/testing';

import { ApiBaseService } from './api-base.service';

describe('ApiBaseService', () => {
  let service: ApiBaseService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ApiBaseService]
    });
    service = TestBed.inject(ApiBaseService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should return correct origin based on environment', () => {
    const origin = service.Origin;
    expect(typeof origin).toBe('string');
    expect(origin.length).toBeGreaterThan(0);
  });
  
});
