import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProcessDialogBoxComponent } from './process-dialog-box.component';

describe('ProcessDialogBoxComponent', () => {
  let component: ProcessDialogBoxComponent;
  let fixture: ComponentFixture<ProcessDialogBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ProcessDialogBoxComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ProcessDialogBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
