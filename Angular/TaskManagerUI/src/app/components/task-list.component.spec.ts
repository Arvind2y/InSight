/* testing components */
import { TestBed, ComponentFixture, async } from '@angular/core/testing';
import { DebugElement } from '@angular/core';
import { By } from '@angular/platform-browser';

//Model
import { TaskDetail } from '../models/TaskDetail.model';

//Components
import { TaskListComponent } from './task-list.component';

// Service used for testing
import { TaskDetailService } from '../shared/task-detail.service';

//Modules used for testing
import { AppTestingModule } from '../app-testing.module';

describe('TaskListComponent', () => {

  //Typescript declarations.
  let comp: TaskListComponent;
  let fixture: ComponentFixture<TaskListComponent>;
  let de: DebugElement;
  let element: HTMLElement;
  let mockTasks: TaskDetail[];
  let taskDetailService: TaskDetailService;
  let spy: jasmine.Spy;



  beforeEach(async(() => { //async before is used for compiling external templates which is any async activity
    TestBed.configureTestingModule({
      // declarations: [TaskListComponent], // declare the test component
      imports: [AppTestingModule],
      // providers: [TaskDetailService]
    })
      .compileComponents(); // compile template and css
  }));


  beforeEach(() => { //And here is the synchronous async function
    fixture = TestBed.createComponent(TaskListComponent);
    comp = fixture.componentInstance;
    de = fixture.debugElement.query(By.css('.table-responsive'));
    element = de.nativeElement;

    //get the injected service from component's fixture.debugElement
    //if the service doesn't have a dependency, you can try Testbed.get()
    //The real taskDetailService is injected into the component
    taskDetailService = fixture.debugElement.injector.get(TaskDetailService);

    mockTasks = [
      { TaskId: 1, TaskName: 'Task 1', ParentTask: 0, StartDate: new Date('07/12/2019'), EndDate: new Date("10/12/2020"), Priority: 20, IsCompleted: false },
      { TaskId: 2, TaskName: 'Task 2', ParentTask: 1, StartDate: new Date('07/06/2016'), EndDate: new Date("07/05/2019"), Priority: 15, IsCompleted: false },
    ];

    spy = spyOn(taskDetailService, 'getTaskDetails')
      .and.returnValue(Promise.resolve(mockTasks));

  });

  it('should create tasklist component', () => {
    expect(comp).toBeTruthy();
  });

  it('should have a table to display the taskDetails', () => {
    expect(element.innerHTML).toContain("thead");
    expect(element.innerHTML).toContain("tbody");
  })



});
