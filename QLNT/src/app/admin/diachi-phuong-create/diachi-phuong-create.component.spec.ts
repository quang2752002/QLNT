import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiPhuongCreateComponent } from './diachi-phuong-create.component';

describe('DiachiPhuongCreateComponent', () => {
  let component: DiachiPhuongCreateComponent;
  let fixture: ComponentFixture<DiachiPhuongCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiPhuongCreateComponent]
    });
    fixture = TestBed.createComponent(DiachiPhuongCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
