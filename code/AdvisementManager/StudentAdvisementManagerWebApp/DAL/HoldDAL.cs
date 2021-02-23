using StudentAdvisementManagerWebApp.Data;
using StudentAdvisementManagerWebApp.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace StudentAdvisementManagerWebApp.DAL
{
    /// <summary>
    ///   The hold DAL class
    /// </summary>
    public class HoldDAL
    {
        /// <summary>Obtains the hold.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The retrieved hold
        /// </returns>
        public Hold ObtainHold(int? id, ApplicationDbContext context)
        {
            return (from hold in context.Hold where hold.StudentId == id select hold).FirstOrDefault();
        }
    }
}
