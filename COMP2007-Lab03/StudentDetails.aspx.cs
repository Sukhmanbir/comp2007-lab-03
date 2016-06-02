using System;
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

        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~.Students.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //connect to the EF DB
            using(DefaultConnection db = new DefaultConnection())
            {
                //use student model to save the object
                Student newStudent = new Student();

                newStudent.LastName = LastNameTextBox.Text;
                newStudent.FirstMidName = FirstNameTextBox.Text;
                newStudent.EnrollmentDate = Convert.ToDateTime(EnrollmentDateTextBox.Text);

                //adds news student to the Student Table collection
                db.Students.Add(newStudent);

                //run insert
                db.SaveChanges();

                //redirect to the updated student table
                Response.Redirect("~/Students.aspx");
            }
        }
    }
}