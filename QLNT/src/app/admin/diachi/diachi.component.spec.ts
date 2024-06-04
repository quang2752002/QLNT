import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiComponent } from './diachi.component';

describe('DiachiComponent', () => {
  let component: DiachiComponent;
  let fixture: ComponentFixture<DiachiComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiComponent]
    });
    fixture = TestBed.createComponent(DiachiComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
