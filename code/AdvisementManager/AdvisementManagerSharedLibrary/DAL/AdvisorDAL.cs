using System.Linq;
using AdvisementManagerSharedLibrary.Data;
using AdvisementManagerSharedLibrary.Models;

namespace AdvisementManagerSharedLibrary.DAL
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
            return context.Advisor.Find(id);
        }

        /// <summary>Obtains the advisor with the specified username.</summary>
        /// <param name="context">The context.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        ///   The advisor with the given username.
        /// </returns>
        public Advisor ObtainAdvisorWithUsername(string username, ApplicationDbContext context)
        {
            Advisor theAdvisor = (from advisor in context.Advisor
                                  where advisor.UserName == username
                                  select advisor).FirstOrDefault();

            return theAdvisor;
        }
    }
}
