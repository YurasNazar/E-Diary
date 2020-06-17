using BLL.Factories;
using BLL.Interfaces;
using DAL.Entities;
using DAL.ViewModels;
using EDiary.Extensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EDiary.Controllers
{
    public class SubjectsController : BaseController
    {
        private readonly ISubjectService _subjectService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISubjectModelFactory _subjectModelFactory;

        public SubjectsController(ISubjectService subjectService,
                                  UserManager<ApplicationUser> userManager,
                                  ISubjectModelFactory subjectModelFactory)
        {
            _userManager = userManager;
            _subjectService = subjectService;
            _subjectModelFactory = subjectModelFactory;
        }

        [HttpGet]
        public IActionResult Index(int? id)
        {
            var userId = User.GetLoggedInUserId<string>();
            var model = _subjectModelFactory.PrepareSubjectViewModel(userId);

            return View();
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
    }
}
