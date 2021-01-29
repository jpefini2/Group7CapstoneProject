using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdvisementManagerWebApp.Models
{
    public class StudentsVM
    {
        public IList<Student> Students { get; set; }
    }
}
