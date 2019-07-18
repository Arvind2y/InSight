import { Injectable } from '@angular/core';
import { TaskDetail } from '../models/TaskDetail.model';
import { HttpClient } from '@angular/common/http';
import { observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TaskDetailService {
  formData: TaskDetail;
  readonly rootURL = 'http://localhost:5009/api/';
  taskDetails: TaskDetail[];
  constructor(private http: HttpClient) { }

  // Post the data to the API to insert into table
  postTaskDetails() {
    return this.http.post(this.rootURL + '/TaskDetails', this.formData);
  }

  // return data to show to the table
  refereshTask() {
    return this.taskDetails = [
      { TaskID: 1, TaskName: 'Task 1', ParentID: 0, StartDate: new Date('07/12/2019'), EndDate: new Date("10/12/2020"), Priority: 20 },
      { TaskID: 2, TaskName: 'Task 2', ParentID: 1, StartDate: new Date('07/06/2016'), EndDate: new Date("07/05/2019"), Priority: 15 },
      { TaskID: 3, TaskName: 'Task 3', ParentID: 1, StartDate: new Date('01/08/2017'), EndDate: new Date("06/15/2020"), Priority: 22 },
      { TaskID: 4, TaskName: 'Task 4', ParentID: 2, StartDate: new Date('10/01/2019'), EndDate: new Date("10/12/2021"), Priority: 25 },
      { TaskID: 5, TaskName: 'Task 5', ParentID: 3, StartDate: new Date('11/18/2019'), EndDate: new Date("08/30/2019"), Priority: 6 },
      { TaskID: 6, TaskName: 'Task 6', ParentID: 1, StartDate: new Date('10/05/2018'), EndDate: new Date("11/22/2019"), Priority: 17 },
      { TaskID: 7, TaskName: 'Task 7', ParentID: 2, StartDate: new Date('09/25/2015'), EndDate: new Date("08/19/2019"), Priority: 23 },
      { TaskID: 8, TaskName: 'Task 8', ParentID: 3, StartDate: new Date('03/27/2014'), EndDate: new Date("07/28/2019"), Priority: 19 },
    ];

    // this.http.get(this.rootURL + '/TaskDetails')
    //   .toPromise()
    //   .then(res => this.taskDetails = res as TaskDetail[]);
  }

  // Delete Task
  deleteTask(id) {
    return this.http.delete(this.rootURL + '/TaskDetails/' + id);
  }

  putPaymentDetail() {
    return this.http.put(this.rootURL + '/TaskDetails/' + this.formData.TaskID, this.formData);
  }



}
