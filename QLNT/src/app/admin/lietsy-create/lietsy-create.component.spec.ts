import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LietsyCreateComponent } from './lietsy-create.component';

describe('LietsyCreateComponent', () => {
  let component: LietsyCreateComponent;
  let fixture: ComponentFixture<LietsyCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [LietsyCreateComponent]
    });
    fixture = TestBed.createComponent(LietsyCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
