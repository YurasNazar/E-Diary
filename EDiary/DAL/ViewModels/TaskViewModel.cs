using Common.Enums;
using DAL.Entities;
using DAL.Models;
using System;
using System.Collections.Generic;

namespace DAL.ViewModels
{
    public class TaskViewModel
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxAssessment { get; set; }
        public int? Assessment { get; set; }
        public int StatusId { get; set; }
        public string Status => ((TaskStatus)StatusId).ToString();
        public ApplicationUser CreatedBy { get; set; }
        public Subject Subject { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedByUserName { get; set; }
        public string SubjectName { get; set; }
        public List<TaskNoteModel> TaskNotes { get; set; }
        public List<File> TaskFiles { get; set; }
    }
}
