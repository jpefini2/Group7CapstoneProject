using System.Collections.Generic;
using AdvisementManagerDesktopApp.DAL;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.Controller
{
    /// <summary>
    ///   The advisement sessions controller
    /// </summary>
    public class AdvisementSessionsController
    {
        public IList<Student> ObtainStudentsWithHolds()
        {
            var studentDal = new StudentDal();

            var students = studentDal.ObtainStudentsWithHolds();

            return students;
        }
    }
}
