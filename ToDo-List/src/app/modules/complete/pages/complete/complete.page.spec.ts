import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CompletePage } from './complete.page';

describe('CompletePage', () => {
  let component: CompletePage;
  let fixture: ComponentFixture<CompletePage>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CompletePage ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(CompletePage);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
