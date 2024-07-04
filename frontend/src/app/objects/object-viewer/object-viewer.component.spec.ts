import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ObjectViewerComponent } from './object-viewer.component';

describe('ObjectViewerComponent', () => {
  let component: ObjectViewerComponent;
  let fixture: ComponentFixture<ObjectViewerComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ObjectViewerComponent]
    });
    fixture = TestBed.createComponent(ObjectViewerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
