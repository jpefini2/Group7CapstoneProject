using AdvisementManagerWebApp.Data;
using AdvisementManagerWebApp.Models;
using System.Linq;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

namespace AdvisementManagerWebApp.DAL
{
    /// <summary>
    ///   The hold DAL class for managing, updating and pulling information from the student table in the DbContext/Database.
    /// </summary>
    public class HoldDAL
    {
        /// <summary>Obtains the hold with a particular holds student Id from the hold table in the DbContext.</summary>
        /// <param name="id">The identifier.</param>
        /// <param name="context">The context.</param>
        /// <returns>
        ///   The retrieved hold from the DbContext.
        /// </returns>
        public Hold ObtainHold(int? id, ApplicationDbContext context)
        {
            return (from hold in context.Hold where hold.StudentId == id select hold).FirstOrDefault();
        }
    }
}
