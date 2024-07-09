import { TestBed } from '@angular/core/testing';

import { ApiConnectionService } from './api-connections.service';

describe('APIConnectionsService', () => {
  let service: ApiConnectionService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ApiConnectionService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
