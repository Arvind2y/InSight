import { TestBed } from '@angular/core/testing';

import { TaskDetailService } from './task-detail.service';
import { AppTestingModule } from '../app-testing.module';
import { TaskDetail } from '../models/TaskDetail.model';

let taskDetailService: TaskDetailService;
let mockTask: TaskDetail, mockTask2: TaskDetail;
let responsePropertyNames, expectedPropertyNames;


describe('TaskDetailService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [AppTestingModule]
    });

    taskDetailService = TestBed.get(TaskDetailService);
    mockTask = { TaskId: 1, TaskName: 'Task 1', ParentTask: 0, StartDate: new Date('07/12/2019'), EndDate: new Date("10/12/2020"), Priority: 20, IsCompleted: false };
    mockTask2 = { TaskId: 2, TaskName: 'Task 2', ParentTask: 1, StartDate: new Date('07/06/2016'), EndDate: new Date("07/05/2019"), Priority: 15, IsCompleted: false };
  });

  it('should be created', () => {
    const service: TaskDetailService = TestBed.get(TaskDetailService);
    expect(service).toBeTruthy();
  });

  it('#getTaskDetails should return an array with taskDetails objects', async () => {

    taskDetailService.getTaskDetails().then(value => {
      //Checking the property names of the returned object and the mockPaste object
      responsePropertyNames = Object.getOwnPropertyNames(value[0]);
      expectedPropertyNames = Object.getOwnPropertyNames(mockTask);
      expect(responsePropertyNames).toEqual(expectedPropertyNames);
    });
  });

  it('#postTaskDetails should create a new TaskDetail', async () => {
    //
    taskDetailService.formData = mockTask;
    taskDetailService.postTaskDetails().then(value => {
      expect(value).toEqual(mockTask);
    });
  });

  it('#putTaskDetails should update the taskDetails in Db', async () => {
    //Update existing paste with id 1
    taskDetailService.formData = mockTask2;
    taskDetailService.putTaskDetails().then(value => {
      expect(value).toEqual(mockTask2);
    })
  })

  it('#deleteTask should return null', async () => {

    taskDetailService.deleteTask(mockTask.TaskId).then(value => {
      expect(value).toEqual(null);
    })
  });



});
