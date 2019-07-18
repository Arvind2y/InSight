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

  constructor(private service: TaskDetailService, private toastr: ToastrService) { }

  ngOnInit() {
    this.service.refereshTask();
  }

  onDelete(TaskId) {
    if (confirm('Are you sure to delete this record ?')) {
      this.service.deleteTask(TaskId)
        .subscribe(res => {
          debugger;
          this.service.refereshTask();
          this.toastr.warning('Deleted successfully', 'Payment Detail Register');
        },
          err => {
            debugger;
            console.log(err);
          })
    }
  }

  onEdit(td: TaskDetail) {

    this.service.formData = td;
  }

}
