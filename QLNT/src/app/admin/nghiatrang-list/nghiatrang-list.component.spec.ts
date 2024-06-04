import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NghiatrangListComponent } from './nghiatrang-list.component';

describe('NghiatrangListComponent', () => {
  let component: NghiatrangListComponent;
  let fixture: ComponentFixture<NghiatrangListComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [NghiatrangListComponent]
    });
    fixture = TestBed.createComponent(NghiatrangListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
