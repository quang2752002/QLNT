import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LietsyComponent } from './lietsy.component';

describe('LietsyComponent', () => {
  let component: LietsyComponent;
  let fixture: ComponentFixture<LietsyComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LietsyComponent]
    });
    fixture = TestBed.createComponent(LietsyComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
