import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiDetailComponent } from './diachi-detail.component';

describe('DiachiDetailComponent', () => {
  let component: DiachiDetailComponent;
  let fixture: ComponentFixture<DiachiDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiDetailComponent]
    });
    fixture = TestBed.createComponent(DiachiDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
