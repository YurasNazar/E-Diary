using BLL.Factories;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Models;
using DAL.ViewModels;
using EDiary.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EDiary.Controllers
{
    public class TaskController : BaseController
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _appEnvironment;
        private readonly ITaskModelFactory _taskModelFactory;
        private readonly IFileModelFactory _fileModelFactory;
        private readonly ITaskService _taskService;
        private readonly IFileService _fileService;

        public TaskController(UserManager<ApplicationUser> userManager,
                              IWebHostEnvironment appEnvironment,
                              ITaskModelFactory taskModelFactory,
                              IFileModelFactory fileModelFactory,
                              ITaskService taskService,
                              IFileService fileService)
        {
            _taskModelFactory = taskModelFactory;
            _fileModelFactory = fileModelFactory;
            _appEnvironment = appEnvironment;
            _taskService = taskService;
            _userManager = userManager;
            _fileService = fileService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetTask(int id)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _taskModelFactory.PrepareTaskViewModel(id, userId);

            return View(model);
        }

        [HttpPost]
        public JsonResult GetTaskNotes(int taskId)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _taskModelFactory.PrepareTaskNotesViewModel(taskId, userId);

            return CreateJsonResult(true, new { model.TaskNotes });
        }

        [HttpPost]
        public JsonResult CreateTaskNote(int taskId, string note)
        {
            var user =  _userManager.GetUserAsync(User).Result;
            var taskNote = _taskModelFactory.PrepareTaskNoteForInsert(taskId, user, note);
            _taskService.IntertTaskNote(taskNote);

            return CreateJsonResult(true);
        }

        [HttpPost]
        public async Task<IActionResult> MarkAsComplete(List<IFormFile> files, int taskId)
        {
            var task = _taskService.GetById(taskId);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = "/files/" + formFile.FileName;
                    using (var fileStream = new FileStream(_appEnvironment.WebRootPath + filePath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(fileStream);
                    }

                    var file = _fileModelFactory.PrepareFileModel(formFile.FileName, filePath);
                    _fileService.SaveFile(file);

                    var taskFileMapping = _fileModelFactory.PrepareTaskFileMappingModel(taskId, file.Id);
                    _fileService.SaveTaskFileMappingModel(taskFileMapping);
                }
            }

            task.StatusId = (int)Common.Enums.TaskStatus.Completed;

            _taskService.UpdateTask(task);

            return RedirectToAction("GetTask", "Task", new { id = task.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Download(string name)
        {
            if (name == null)
                return Content("filename not present");

            var filePath = "/files/" + name;
            var path = _appEnvironment.WebRootPath + filePath;

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            return File(memory, _taskService.GetContentType(path), Path.GetFileName(path));
        }

        [HttpPost]
        public JsonResult Evaluate(int taskId, int taskAssessment)
        {
            var task = _taskService.GetById(taskId);
            task.Assessment = taskAssessment;
            task.StatusId = (int)Common.Enums.TaskStatus.Assessed;
            _taskService.UpdateTask(task);

            return CreateJsonResult(true);
        }
    }
}
