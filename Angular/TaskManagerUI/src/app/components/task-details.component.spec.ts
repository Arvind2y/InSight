import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { TaskDetailsComponent } from './task-details.component';
import { AppTestingModule } from '../app-testing.module';

describe('TaskDetailsComponent', () => {

  //Typescript declarations.
  let comp: TaskDetailsComponent;
  let fixture: ComponentFixture<TaskDetailsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [AppTestingModule],
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskDetailsComponent);
    comp = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create TaskDetailsComponent', () => {
    expect(comp).toBeTruthy();
  });
});
