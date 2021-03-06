﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminAdvisementManagerWebApp.Models
{
    public class AddStudentVM
    {
        public Student NewStudent { get; set; }

        public SelectList FacultyAdvisors { get; set; }

        public SelectList GeneralAdvisors { get; set; }

        public SelectList Gender { get; set; } = new SelectList(new List<string> { "Male", "Female", "Other" });
    }
}
