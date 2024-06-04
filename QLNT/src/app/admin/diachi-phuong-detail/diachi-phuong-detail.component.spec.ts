import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiPhuongDetailComponent } from './diachi-phuong-detail.component';

describe('DiachiPhuongDetailComponent', () => {
  let component: DiachiPhuongDetailComponent;
  let fixture: ComponentFixture<DiachiPhuongDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiPhuongDetailComponent]
    });
    fixture = TestBed.createComponent(DiachiPhuongDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
