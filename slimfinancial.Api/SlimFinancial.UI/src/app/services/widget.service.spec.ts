import { TestBed } from '@angular/core/testing';

import { WidgetService } from './widget.service';

describe('DashboardService', () => {
  let service: WidgetService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(WidgetService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
