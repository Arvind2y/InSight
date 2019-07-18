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
    // formContent.form.reset();

    this.service.formData = {
      TaskID: 0,
      ParentID: 0,
      TaskName: "Add task here",
      StartDate: new Date(),
      EndDate: new Date(),
      Priority: 0
    };
  }

  onSubmit(form: NgForm) {
    this.toastr.success("Submitted Successfully", 'TaskDetail add.');
    // this.service.postTaskDetails(form.value).subscribe(
    //   res => { this.resetForm(form) },
    //   err => {
    //     console.log(err);
    //   }
    // );
  }

}
