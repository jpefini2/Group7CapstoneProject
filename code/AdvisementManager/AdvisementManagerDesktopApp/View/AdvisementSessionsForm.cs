﻿using System;
using System.Collections.Generic;
using System.Windows.Forms;
using AdvisementManagerDesktopApp.Controller;
using AdvisementManagerDesktopApp.Model;

namespace AdvisementManagerDesktopApp.View
{
    /// <summary>
    ///   The advisement sessions form.
    /// </summary>
    public partial class AdvisementSessionsForm : Form
    {
        private readonly Advisor advisor;

        private readonly AdvisementSessionsController sessionController = new();

        private IList<Student> students;

        /// <summary>Initializes a new instance of the <see cref="AdvisementSessionsForm" /> class.</summary>
        public AdvisementSessionsForm(Advisor advisor)
        {
            this.InitializeComponent();
            this.advisor = advisor;

            this.setUpScreen();

        }

        private void setUpScreen()
        {
            this.students = this.sessionController.ObtainStudentsWithHolds();

            foreach (var student in this.students)
            {
                this.studentsWithHoldsListBox.Items.Add(student.FirstName + " " + student.LastName);
            }
        }

        private void viewBtn_Click(object sender, EventArgs e)
        {
            var selectedStudentIndex = this.studentsWithHoldsListBox.SelectedIndex;
            var selectedStudent = this.students[selectedStudentIndex];

            selectedStudent.GeneralAdvisor = this.advisor;

            var advisementSessionForm = new AdvisementSessionForm(selectedStudent, this.advisor);

            advisementSessionForm.Show();

        }
    }
}