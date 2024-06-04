import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NghiatrangDetailComponent } from './nghiatrang-detail.component';

describe('NghiatrangDetailComponent', () => {
  let component: NghiatrangDetailComponent;
  let fixture: ComponentFixture<NghiatrangDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NghiatrangDetailComponent]
    });
    fixture = TestBed.createComponent(NghiatrangDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
