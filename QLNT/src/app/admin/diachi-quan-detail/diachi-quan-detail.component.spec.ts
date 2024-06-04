import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiQuanDetailComponent } from './diachi-quan-detail.component';

describe('DiachiQuanDetailComponent', () => {
  let component: DiachiQuanDetailComponent;
  let fixture: ComponentFixture<DiachiQuanDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiQuanDetailComponent]
    });
    fixture = TestBed.createComponent(DiachiQuanDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
