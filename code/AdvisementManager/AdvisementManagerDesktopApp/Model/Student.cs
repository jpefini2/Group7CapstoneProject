namespace AdvisementManagerDesktopApp.Model
{
    /// <summary>
    ///   The student class for managing a student in the system.
    /// </summary>
    public class Student
    {
        /// <summary>Gets or sets the unique identifier of the student.</summary>
        /// <value>The identifier.</value>
        public int Id { get; set; }

        /// <summary>Gets or sets the first name of the student.</summary>
        /// <value>The first name.</value>
        public string FirstName { get; set; }

        /// <summary>Gets or sets the last name of the student.</summary>
        /// <value>The last name.</value>
        public string LastName { get; set; }

        /// <summary>Gets or sets the email of the student.</summary>
        /// <value>The email.</value>
        public string Email { get; set; }

        /// <summary>Gets or sets the general advisor assigned to the student.</summary>
        /// <value>The general advisor.</value>
        public Advisor GeneralAdvisor { get; set; }

        /// <summary>Gets or sets the faculty advisor assigned to the student.</summary>
        /// <value>The faculty advisor.</value>
        public Advisor FacultyAdvisor { get; set; }

        /// <summary>Gets or sets the hold that a student has.</summary>
        /// <value>The hold.</value>
        public Hold Hold { get; set; }

        /// <summary>Gets or sets the meetings that a student currently has.</summary>
        /// <value>The meetings.</value>
        public AdvisementSession Meeting { get; set; }

        public string FullName => this.FirstName + " " + this.LastName;
    }
}
