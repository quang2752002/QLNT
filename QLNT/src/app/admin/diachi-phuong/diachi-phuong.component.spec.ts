import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiPhuongComponent } from './diachi-phuong.component';

describe('DiachiPhuongComponent', () => {
  let component: DiachiPhuongComponent;
  let fixture: ComponentFixture<DiachiPhuongComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiPhuongComponent]
    });
    fixture = TestBed.createComponent(DiachiPhuongComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
