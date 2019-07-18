
import { TaskDetail } from "./TaskDetail.model";

describe('TaskDetails', () => {

    it('Should create instance of TaskDetails', () => {
        expect(new TaskDetail()).toBeTruthy();
    })

    it('should accept values', () => {

        let taskDetail = new TaskDetail();

        taskDetail = {
            TaskId: 101,
            TaskName: 'Task 101',
            ParentTask: 0,
            StartDate: new Date('07/12/2019'),
            EndDate: new Date("10/12/2020"),
            Priority: 20,
            IsCompleted: false
        }

        expect(taskDetail.TaskId).toEqual(101);
        expect(taskDetail.TaskName).toEqual('Task 101');
        expect(taskDetail.StartDate).toEqual(new Date('07/12/2019'));
        expect(taskDetail.Priority).toEqual(20);
        expect(taskDetail.IsCompleted).toEqual(false);
    });
});