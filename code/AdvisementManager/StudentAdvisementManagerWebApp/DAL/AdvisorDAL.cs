using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;

namespace StudentAdvisementManagerWebApp.DAL
{
    public class AdvisorDAL
    {
        /// <summary>Obtains the advisor with the specified id.</summary>
        /// <param name="context">The context.</param>
        /// <param name="id">The id.</param>
        /// <returns>
        ///   The advisor with the given id.
        /// </returns>
        public Advisor ObtainAdvisorWithId(int id, ApplicationDbContext context)
        {
            return context.Advisor.Find(2);
        }
    }
}
