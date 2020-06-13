using BLL.Interfaces;
using DAL.Entities;
using DAL.Models;
using DAL.ViewModels;
using System;
using System.Linq;

namespace BLL.Factories
{
    public class TaskModelFactory : ITaskModelFactory
    {
        private readonly ITaskService _taskService;
        public TaskModelFactory(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public TaskNotesViewModel PrepareTaskNotesViewModel(int taskId, string userId = "")
        {
            var pagedList = _taskService.SearchTaskNotes(taskId, userId);

            var taskNotesViewModel = new TaskNotesViewModel
            {
                TaskNotes = pagedList.Select(PrepareTaskNoteModel).ToList(),
            };

            return taskNotesViewModel;
        }

        public TaskViewModel PrepareTaskViewModel(int taskId, string userId = "")
        {
            var task = _taskService.GetById(taskId);
            var taskNotes = _taskService.SearchTaskNotes(taskId);

            var taskViewModel = new TaskViewModel
            {
                TaskId = task.Id,
                Name = task.Name,
                Description = task.Description,
                Assessment = task.Assessment,
                MaxAssessment = task.MaxAssessment,
                CreatedOn = task.DateCreated,
                StatusId = task.StatusId,
                CreatedBy = task.CreatedBy,
                CreatedByUserName = task.CreatedBy.FullName,
                Subject = task.Subject,
                SubjectName = task.Subject.Name,
                TaskNotes = taskNotes.Select(PrepareTaskNoteModel).ToList()
            };

            return taskViewModel;
        }

        public TaskNoteModel PrepareTaskNoteModel(TaskNote taskNote)
        {
            return new TaskNoteModel
            {
                CreatedBy = taskNote.User.FullName,
                CreatedOn = taskNote.CreatedOn,
                Note = taskNote.Note
            };
        }

        public TaskNote PrepareTaskNoteForInsert(int taskId, ApplicationUser user, string note)
        {
            return new TaskNote
            {
                TaskId = taskId,
                User = user,
                Note = note,
                CreatedOn = DateTime.UtcNow
            };
        }
    }
}
