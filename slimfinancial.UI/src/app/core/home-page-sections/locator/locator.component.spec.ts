import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LocatorComponent } from './locator.component';

describe('LocatorComponent', () => {
  let component: LocatorComponent;
  let fixture: ComponentFixture<LocatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [LocatorComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LocatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
