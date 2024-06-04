import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NghiatrangCreateComponent } from './nghiatrang-create.component';

describe('NghiatrangCreateComponent', () => {
  let component: NghiatrangCreateComponent;
  let fixture: ComponentFixture<NghiatrangCreateComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NghiatrangCreateComponent]
    });
    fixture = TestBed.createComponent(NghiatrangCreateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
