﻿using DAL.Entities;
using DAL.Models;
using System.Collections.Generic;

namespace DAL.ViewModels
{
    public class SubjectViewModel
    {
        public List<SubjectListItem> SubjectList { get; set; }

        public int? SubjectId { get; set; }
    }
}
