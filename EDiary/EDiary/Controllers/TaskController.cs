using BLL.Factories;
using BLL.Interfaces;
using DAL.Entities;
using EDiary.Extensions;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IO;
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
        public async Task<IActionResult> AddFile(IFormFile uploadedFile)
        {
            if (uploadedFile != null)
            {
                // путь к папке Files
                string path = "/files/" + uploadedFile.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                var model = _fileModelFactory.PrepareFileModel(uploadedFile.FileName, path);
                _fileService.SaveFile(model);
            }

            return RedirectToAction("Index");
        }
    }
}
