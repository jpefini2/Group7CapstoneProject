using System.Collections.Generic;
using AdvisementDesktop.DAL;
using AdvisementDesktop.Model;

namespace AdvisementDesktop.Controller
{
    /// <summary>
    ///   The advisement sessions controller for managing and processing data between the view and model for available advisement sessions
    /// </summary>
    public class AdvisementSessionsController
    {
        /// <summary>Obtains the students with active holds from the database to be passed to the view.</summary>
        /// <returns>
        ///   The list of students who currently have holds in the system.
        /// </returns>
        public IList<Student> ObtainStudentsWithHolds(Advisor advisor)
        {
            var studentDal = new StudentDal();

            var students = studentDal.ObtainStudentsWithHolds(advisor);

            return students;
        }
    }
}
