import { Component, OnInit } from '@angular/core';
import { TaskDetailService } from '../shared/task-detail.service';
import { NgForm } from '@angular/forms';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'task-detail',
  templateUrl: './task-detail.component.html',
  styleUrls: ['./task-detail.component.css']
})
export class TaskDetailComponent implements OnInit {

  constructor(private service: TaskDetailService, private toastr: ToastrService) { }

  ngOnInit() {
    this.resetForm();
  }

  // To reset the form
  resetForm(formContent?: NgForm) {
    if (formContent != null) {
      formContent.form.reset();
    } else {
      this.service.formData = {
        TaskId: 0,
        ParentTask: 0,
        TaskName: "",
        StartDate: new Date(),
        EndDate: new Date(),
        Priority: 0,
        IsCompleted: false
      };
    }
  }

  // On form Submit button performs this action as per the input
  onSubmit(form: NgForm) {
    //debugger;
    if (this.service.formData.TaskId == 0) {
      this.insertTaskDetail(form);
    }
    else {
      this.updateTaskDetail(form);
      this.service.formData.TaskId = 0;
    }
  }

  // Insert taskDetails to the db
  insertTaskDetail(form: NgForm) {
    this.service.postTaskDetails().then( //.subscribe(
      res => {
        this.resetForm(form);
        this.toastr.success("Submitted Successfully", 'TaskDetail added!');
        this.service.refereshTask();
      }
      // , err => {
      //   console.log(err);
      // }
    )
      .catch(this.handleError)
      ;
  }

  // Update taskDetails to the Db
  updateTaskDetail(form: NgForm) {
    console.log(form);
    this.service.putTaskDetails().then( //.subscribe(
      res => {
        this.resetForm(form);
        this.toastr.info("Updated Successfully", 'TaskDetail updated!');
        this.service.refereshTask();
      }
      // , err => {
      //   console.log(err);
      // } )
    ).catch(this.handleError);
  }

  // Write the log to console in case of error
  private handleError(error: any): Promise<any> {
    console.error('An error occurred', error);
    return Promise.reject(error.message || error);
  }
}
