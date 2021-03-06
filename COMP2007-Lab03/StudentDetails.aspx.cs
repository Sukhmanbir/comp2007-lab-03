﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

//required for EF DB access
using COMP2007_Lab03.Models;
using System.Web.ModelBinding;

namespace COMP2007_Lab03
{
    public partial class StudentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetStudent();
            }
        }

        protected void GetStudent()
        {
            //populate the form with existing student data from the db
            int StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

            //connect to the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a student instance with the StudentsID from the URL parameter
                Student updatedStudent = (from student in db.Students
                                          where student.StudentID == StudentID
                                          select student).FirstOrDefault();


                //map the student properties to the form controls
                if(updatedStudent != null)
                {
                    LastNameTextBox.Text = updatedStudent.LastName;
                    FirstNameTextBox.Text = updatedStudent.FirstMidName;
                    EnrollmentDateTextBox.Text = updatedStudent.EnrollmentDate.ToString("yyyy-MM-dd");
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //connect to the EF DB
            using(DefaultConnection db = new DefaultConnection())
            {
                //use student model to save the object
                Student newStudent = new Student();

                int StudentID = 0;
                if(Request.QueryString.Count > 0)
                {
                    //get the id from the URL
                    StudentID = Convert.ToInt32(Request.QueryString["StudentID"]);

                    //get the current student fromt the EF DB
                    newStudent = (from student in db.Students
                                  where student.StudentID == StudentID
                                  select student).FirstOrDefault();
                }

                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                //adds news student to the Student Table collection

                //check to see if new student is being added
                if(StudentID == 0)
                {
                    db.Students.Add(newStudent);
                }

                //save changes - run an update
                db.SaveChanges();

                //redirect to the updated student table
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}