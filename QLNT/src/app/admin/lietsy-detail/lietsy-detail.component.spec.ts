import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LietsyDetailComponent } from './lietsy-detail.component';

describe('LietsyDetailComponent', () => {
  let component: LietsyDetailComponent;
  let fixture: ComponentFixture<LietsyDetailComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LietsyDetailComponent]
    });
    fixture = TestBed.createComponent(LietsyDetailComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
