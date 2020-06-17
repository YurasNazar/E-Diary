using BLL.Factories;
using BLL.Interfaces;
using DAL.Entities;
using DAL.ViewModels;
using EDiary.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;

namespace EDiary.Controllers
{
    public class SubjectsController : BaseController
    {
        private readonly ISubjectService _subjectService;
        private readonly ITaskService _taskService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubjectModelFactory _subjectModelFactory;

        public SubjectsController(ISubjectService subjectService,
                                  UserManager<ApplicationUser> userManager,
                                  ISubjectModelFactory subjectModelFactory,
                                  ITaskService taskService)
        {
            _taskService = taskService;
            _userManager = userManager;
            _subjectService = subjectService;
            _subjectModelFactory = subjectModelFactory;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _subjectModelFactory.PrepareSubjectViewModel(userId);
            model.SubjectId = id;

            return View(model);
        }
        
        [HttpGet]
        public IActionResult TeacherSubjectList()
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _subjectModelFactory.PrepareSubjectListViewModel(userId);
            
            return View("../Teacher/Subjects/List", model);
        }

        [HttpPost]
        public JsonResult GetTeacherSubjectList()
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _subjectModelFactory.PrepareSubjectListViewModel(userId);

            return CreateJsonResult(true, new
            {
                Subjects = model.SubjectList,
            });
        }

        [HttpPost]
        public JsonResult CreateSubject(CreateSubjectViewModel subject)
        {
            var userId = User.GetLoggedInUserId<string>();
            var subjectModel = _subjectModelFactory.PrepareSubjectModel(subject, userId);
            _subjectService.CreateSubject(subjectModel);

            var userSubjectMappingModel = _subjectModelFactory.PrepareUserSubjectMappingModel(userId, subjectModel.Id);
            _subjectService.CreateUserSubjectMapping(userSubjectMappingModel);

            return CreateJsonResult(true);
        }

        [HttpPost]
        public JsonResult GetSubjectInfo(int subjectId)
        {
            var model = _subjectModelFactory.PrepareSubjectInfoModel(subjectId);

            return CreateJsonResult(true, new
            {
                model.SubjectPosts,
                model.SubjectPeople,
                model.SubjectTeachers
            });
        }

        [HttpPost]
        public JsonResult CreatePost(string description, int subjectId)
        {
            var userId = User.GetLoggedInUserId<string>();
            var subjectPost = _subjectModelFactory.PrepareSubjectPostModelForInsert(subjectId, description, userId);
            _subjectService.CreateSubjectPost(subjectPost);

            return CreateJsonResult(true);
        }

        [HttpPost]
        public JsonResult CreateTask(CreateTaskViewModel task)
        {
            var userId = User.GetLoggedInUserId<string>();
            var subjectUsers = _subjectService.GetSubjectUsers(task.SubjectId);

            foreach (var subjectUser in subjectUsers) 
            {
                var subjectTask = new Task
                {
                    Name = task.Name,
                    Description = task.Description,
                    DeadLine = task.DeadLine,
                    StatusId = (int)Common.Enums.TaskStatus.Proposed,
                    MaxAssessment = task.MaxAssessment,
                    CreatedById = userId,
                    SubjectId = task.SubjectId,
                    DateCreated = DateTime.UtcNow
                };

                _taskService.CreateTask(subjectTask);


                var userTaskMapping = new UserTaskMapping
                {
                    UserId = subjectUser.User.Id,
                    TaskId = subjectTask.Id
                };

                _taskService.CreateUserTaskMapping(userTaskMapping);


                var teacherTaskMapping = new TeacherTaskMapping
                {
                    TeacherId = userId,
                    TaskId = subjectTask.Id
                };

                _taskService.CreateTeacherTaskMapping(teacherTaskMapping);
            }

            return CreateJsonResult(true);
        }

        [HttpPost]
        public JsonResult JoinSubject(string joinCode)
        {
            var userId = User.GetLoggedInUserId<string>();
            var subject = _subjectService.GetSubjectByCode(joinCode);

            if (subject != null) 
            {
                var userSubject = _subjectModelFactory.PrepareUserSubjectModelForInsert(subject.Id, userId);
                _subjectService.CreateUserSubject(userSubject);
            }

            return CreateJsonResult(true, new
            {
                subjectId = subject.Id
            });
        }
    }
}
