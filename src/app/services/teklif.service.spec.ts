import { TestBed } from '@angular/core/testing';

import { TeklifService } from './teklif.service';

describe('TeklifService', () => {
  let service: TeklifService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TeklifService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
