import { Component, OnInit } from '@angular/core';
import { TaskDetailService } from '../shared/task-detail.service';
import { TaskDetail } from '../models/TaskDetail.model';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'task-list',
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css']
})
export class TaskListComponent implements OnInit {

  constructor(private taskService: TaskDetailService, private toastr: ToastrService) { }

  // loadTaskDetails will be called onInit.
  ngOnInit() {
    this.loadTaskDetails();
  }

  public loadTaskDetails() {
    //invokes taskDetails service's getTaskDetails() method
    this.taskService.getTaskDetails();
  }

  // Delete the task using the task id
  public onDelete(TaskId) {
    if (confirm('Are you sure to delete this  record ?' + TaskId)) {
      this.taskService.deleteTask(TaskId)
        //.subscribe(res => {
        .then(res => {
          debugger;
          this.taskService.refereshTask();
          this.toastr.warning('Deleted successfully!', 'Task Details');
        }
          // ,err => {
          //     debugger;
          //     console.log(err);}
        )
        .catch(this.handleError);
    }
  }

  public onEdit(td: TaskDetail) {
    // assigning a copy of td data using Object.assign so it can't update directly the formdata value
    this.taskService.formData = Object.assign({}, td);
  }

  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }

}
