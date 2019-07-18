import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

//Modules used for testing
import { HttpClientModule } from '@angular/common/http';
import { HttpModule } from '@angular/http';
import { FormsModule } from '@angular/forms';
import { RouterModule, Routes } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';
import { ToastrModule } from 'ngx-toastr';


//Components
import { AppComponent } from './app.component';
import { TaskListComponent } from './components/task-list.component';
import { TaskDetailComponent } from './components/task-detail.component';
import { TaskDetailsComponent } from './components/task-details.component';

// Service used for taskDetails
import { TaskDetailService } from './shared/task-detail.service';

//Model
import { TaskDetail } from './models/TaskDetail.model';

//Define the Routes for the taskManager Application
const appRoutes: Routes = [
  { path: '', component: TaskDetailComponent },
  // { path: 'about', component: AboutComponent },
  // { path: 'contact', component: ContactComponent},
];



@NgModule({
  declarations: [
    AppComponent,
    TaskDetailComponent,
    TaskListComponent,
    TaskDetailsComponent,
  ],

  imports: [
    CommonModule,
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    ToastrModule.forRoot(),
    RouterModule.forRoot(appRoutes),
    BsDatepickerModule.forRoot()
  ],
  providers: [TaskDetailService,
    { provide: APP_BASE_HREF, useValue: '/' }],

})
export class AppTestingModule { }
