import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiQuanComponent } from './diachi-quan.component';

describe('DiachiQuanComponent', () => {
  let component: DiachiQuanComponent;
  let fixture: ComponentFixture<DiachiQuanComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiQuanComponent]
    });
    fixture = TestBed.createComponent(DiachiQuanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
