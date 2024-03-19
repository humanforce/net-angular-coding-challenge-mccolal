import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SprintNavigatorComponent } from './sprint-navigator.component';

describe('SprintNavigatorComponent', () => {
  let component: SprintNavigatorComponent;
  let fixture: ComponentFixture<SprintNavigatorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [SprintNavigatorComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SprintNavigatorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
