import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiQuanCreateComponent } from './diachi-quan-create.component';

describe('DiachiQuanCreateComponent', () => {
  let component: DiachiQuanCreateComponent;
  let fixture: ComponentFixture<DiachiQuanCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiQuanCreateComponent]
    });
    fixture = TestBed.createComponent(DiachiQuanCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
