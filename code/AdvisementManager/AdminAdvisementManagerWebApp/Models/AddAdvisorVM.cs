using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvisementManagerSharedLibrary.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AdminAdvisementManagerWebApp.Models
{
    public class AddAdvisorVM
    {
        public Advisor NewAdvisor { get; set; }

        public SelectList Gender { get; set; }

        public string SelectedGender { get; set; }
    }
}
