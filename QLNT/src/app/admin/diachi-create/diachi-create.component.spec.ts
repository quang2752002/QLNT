import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DiachiCreateComponent } from './diachi-create.component';

describe('DiachiCreateComponent', () => {
  let component: DiachiCreateComponent;
  let fixture: ComponentFixture<DiachiCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [DiachiCreateComponent]
    });
    fixture = TestBed.createComponent(DiachiCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
