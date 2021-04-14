using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;

namespace AdminAdvisementManagerWebApp.Models
{
    public class AllStudentsVM
    {
        public IList<Student> Students { get; set; }
    }
}
