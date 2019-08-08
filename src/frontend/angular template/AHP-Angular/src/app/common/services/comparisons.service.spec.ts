import { TestBed } from '@angular/core/testing';

import { ComparisonsService } from './comparisons.service';

describe('ComparisonsService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: ComparisonsService = TestBed.get(ComparisonsService);
    expect(service).toBeTruthy();
  });
});
