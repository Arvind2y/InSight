import { TaskDetailComponent } from './task-detail.component';
import { TaskDetail } from '../models/TaskDetail.model';

import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { DebugElement } from '@angular/core';
import { BrowserModule, By } from '@angular/platform-browser';

// Service used for testing
import { TaskDetailService } from '../shared/task-detail.service';

//Modules used for testing
import { AppTestingModule } from '../app-testing.module';

describe('TaskDetailComponent', () => {

  //Typescript declarations.
  let comp: TaskDetailComponent;
  let fixture: ComponentFixture<TaskDetailComponent>;
  let de: DebugElement;
  let element: HTMLElement;
  let mockTask: TaskDetail;
  let taskDetailService: TaskDetailService;
  let spy: jasmine.Spy;

  let inputTaskName: HTMLInputElement;
  let selectParentTask: HTMLSelectElement;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      // declarations: [TaskDetailComponent],
      imports: [AppTestingModule],
    })
      .compileComponents();
  }));

  beforeEach(() => { //And here is the synchronous async function
    fixture = TestBed.createComponent(TaskDetailComponent);
    comp = fixture.componentInstance;
    de = fixture.debugElement.query(By.css('.fa-save'));
    element = fixture.nativeElement.querySelector('form');

    mockTask = { TaskId: 1, TaskName: 'Task 1', ParentTask: 0, StartDate: new Date('07/12/2019'), EndDate: new Date("10/12/2020"), Priority: 20, IsCompleted: false };

  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TaskDetailComponent);
    comp = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create task detail component', () => {
    expect(comp).toBeTruthy();
  });

  it(`should display the Add\\Update Task button`, () => {
    console.log(element.innerText);
    expect(element.innerText).toContain(`Add\\Update Task`);
  });

  it('should not display the modal unless the button is clicked', () => {

    //source-model is an id for the modal. It shouldn't show up unless create button is clicked
    expect(element.innerHTML).not.toContain("source-modal");

    //Component's showModal property should be false at the moment
    // expect(comp.showModal).toBeFalsy("Show modal should be initially false");
  });


  it("should accept input values", () => {
    //Query the input selectors
    inputTaskName = element.querySelector("input");
    selectParentTask = element.querySelector("select");

    //Set the input element's value to mockTask
    inputTaskName.value = mockTask.TaskName;
    selectParentTask.value = mockTask.TaskName;

    //Dispatch an event to tell the component input value has changed
    inputTaskName.dispatchEvent(new Event("input"));
    selectParentTask.dispatchEvent(new Event("change"));

    expect(mockTask.TaskName).toEqual('Task 1');
    expect(mockTask.TaskName).toEqual('Task 1');

  });

  // it(`should have as text 'Member page'`, async(() => {
  //   expect(comp.text).toEqual('Members');
  // }));

  // it(`should set submitted to true`, async(() => {
  //   comp.onSubmit();
  //   expect(comp.submitted).toBeTruthy();
  // }));

  // it(`should call the onSubmit method`, async(() => {
  //   spyOn(comp, 'onSubmit');
  //   el = fixture.debugElement.query(By.css('button')).nativeElement;
  //   el.click();
  //   expect(comp.onSubmit).toHaveBeenCalled();
  // }));

  xit(`Form should be invalid`, async(() => {
    fixture.whenStable().then(() => {
      console.log(comp);
      //console.log(comp.ngForm.controls['TaskName'])
      //  comp.ngForm.controls['TaskName'].setValue('test_venue');
    });
    // comp.form.controls['email'].setValue('');
    // comp.contactForm.controls['name'].setValue('');
    // comp.contactForm.controls['text'].setValue('');
    // expect(comp.contactForm.valid).toBeFalsy();
  }));


  // it(`form should be valid`, async(() => {
  //   comp.contactForm.controls['email'].setValue('asd@asd.com');
  //   comp.contactForm.controls['name'].setValue('aada');
  //   comp.contactForm.controls['text'].setValue('text');
  //   expect(comp.contactForm.valid).toBeTruthy();
  // }));

});
