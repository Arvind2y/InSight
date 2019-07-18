import { Injectable } from '@angular/core';
import { TaskDetail } from '../models/TaskDetail.model';
import { HttpClient } from '@angular/common/http';
import { observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskDetailService {

  formData: TaskDetail;
  readonly rootURL = 'http://localhost:50519/api/';
  taskDetails: TaskDetail[];

  constructor(private http: HttpClient) {
    this.formData = {
      TaskId: 0,
      ParentTask: 0,
      TaskName: "",
      StartDate: new Date(),
      EndDate: new Date(),
      Priority: 0,
      IsCompleted: false
    };

  }

  //getTaskDetails() performs http.get() and returns a promise
  public getTaskDetails() {
    return this.http.get(this.rootURL + 'TaskDetail')
      .toPromise()
      .then(res => this.taskDetails = res as TaskDetail[])
      .catch(this.handleError);
  }

  // Post the data to the API to insert into table
  public postTaskDetails(): Promise<any> {
    return this.http.post(this.rootURL + 'TaskDetail', this.formData)
      .toPromise()
      .then(response => this.formData)
      .catch(this.handleError);
  }

  // UPdate the task details
  // public putTaskDetails() {
  //   return this.http.put(this.rootURL + 'TaskDetail/' + this.formData.TaskId, this.formData);
  //   // .toPromise()
  //   // .then(() => this.formData)
  //   // .catch(this.handleError);
  // }

  public putTaskDetails() {
    return this.http.put(this.rootURL + 'TaskDetail/' + this.formData.TaskId, this.formData)
      .toPromise()
      .then(() => this.formData)
      .catch(this.handleError);
  }

  // Delete Task using the task
  public deleteTask(id): Promise<void> {
    console.log(this.rootURL + 'TaskDetail/' + id);
    return this.http.delete(this.rootURL + 'TaskDetail/' + id)
      .toPromise()
      .then(() => null)
      .catch(this.handleError);
  }

  // fetch the data from the Web API and return to the UI
  public refereshTask() {
    // return this.taskDetails = [
    //   { TaskId: 1, TaskName: 'Task 1', ParentTask: 0, StartDate: new Date('07/12/2019'), EndDate: new Date("10/12/2020"), Priority: 20, IsCompleted: false },
    //   { TaskId: 2, TaskName: 'Task 2', ParentTask: 1, StartDate: new Date('07/06/2016'), EndDate: new Date("07/05/2019"), Priority: 15, IsCompleted: false },
    //   { TaskId: 3, TaskName: 'Task 3', ParentTask: 1, StartDate: new Date('01/08/2017'), EndDate: new Date("06/15/2020"), Priority: 22, IsCompleted: false },
    //   { TaskId: 4, TaskName: 'Task 4', ParentTask: 2, StartDate: new Date('10/01/2019'), EndDate: new Date("10/12/2021"), Priority: 25, IsCompleted: false },
    //   { TaskId: 5, TaskName: 'Task 5', ParentTask: 3, StartDate: new Date('11/18/2019'), EndDate: new Date("08/30/2019"), Priority: 6, IsCompleted: false },
    //   { TaskId: 6, TaskName: 'Task 6', ParentTask: 1, StartDate: new Date('10/05/2018'), EndDate: new Date("11/22/2019"), Priority: 17, IsCompleted: false },
    //   { TaskId: 7, TaskName: 'Task 7', ParentTask: 2, StartDate: new Date('09/25/2015'), EndDate: new Date("08/19/2019"), Priority: 23, IsCompleted: false },
    //   { TaskId: 8, TaskName: 'Task 8', ParentTask: 3, StartDate: new Date('03/27/2014'), EndDate: new Date("07/28/2019"), Priority: 19, IsCompleted: false },
    // ];
    //  console.log(this.getTaskDetails());
    return this.getTaskDetails();
  }




  // Write the log to console in case of error
  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }

}
