using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskManagerAPI.Controllers;
using TaskManagerAPI.Core.Interfaces;
using TaskManagerAPI.Core.Models;
using TaskManagerAPI.Models;
using Xunit;

namespace TaskManagerXUnitTests
{
    public class TaskDetailControllerTest
    {
        TaskDetailController _taskDetailController;
        private readonly TaskDetailsContext _dbContext;

        public TaskDetailControllerTest()
        {
           // _taskDetailController = new TaskDetailController();
        }

        [Fact]
        public async Task Create_ReturnsBadRequest_GivenInvalidModel()
        {
            // Arrange
            var mockRepo = new Mock<ITaskDetailsRepository>();
            var controller = new TaskDetailController(mockRepo.Object);

            // Act
            var result = await controller.PostTaskDetail(taskDetail: null);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDetail>>(result);
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Create_ReturnsNotFound_ForInvalidTask()
        {
            // Arrange
            int taskId = 11;
            var mockRepo = new Mock<ITaskDetailsRepository>();

            var controller = new TaskDetailController(mockRepo.Object);

            // Act
            var result = await controller.GetTaskDetail(taskId);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDetail>>(result);
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task TaskDetailRepo_ReturnsTaskDetails()
        {
            // Arrange
            var mockRepo = new Mock<ITaskDetailsRepository>();

            var controller = new TaskDetailController(mockRepo.Object);
            mockRepo.Setup(repo => repo.GetTaskByIdAsync(1))
               .ReturnsAsync(GetTestTaskDetails());

            // Act
            var result = await controller.GetTaskDetails();

            // Assert
            // var okResult = Assert.IsType<OkObjectResult>(result);
            var actionResult = Assert.IsType<ActionResult<IEnumerable<TaskDetail>>>(result);
            // Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async Task Create_ReturnsNewlyCreatedTask()
        {
            // Arrange
            var mockRepo = new Mock<ITaskDetailsRepository>();
            var controller = new TaskDetailController(mockRepo.Object);

            var newTaskDetail = new TaskDetail()
            {
                TaskName = "Task 101",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(50),
                IsCompleted = false,
                Priority = 24,
                ParentTask = 5,
                TaskId = 101
            };

            // Act
            var result = await controller.PostTaskDetail(newTaskDetail);

            // Assert
            var actionResult = Assert.IsType<ActionResult<TaskDetail>>(result);
            var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(actionResult.Result);

            var returnValue = Assert.IsType<TaskDetail>(createdAtActionResult.Value);
            mockRepo.Verify();

            Assert.Equal(newTaskDetail.TaskName, returnValue.TaskName);
            Assert.Equal(newTaskDetail.TaskId, returnValue.TaskId);
        }

        private TaskDetail GetTestTaskDetails()
        {
            return new TaskDetail()
            {
                TaskName = "Task 11",
                StartDate = DateTime.Today,
                EndDate = DateTime.Today.AddDays(50),
                IsCompleted = false,
                Priority = 24,
                ParentTask = 5,
                TaskId = 10
            };
        }

    }
}