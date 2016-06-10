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
    public partial class DepartmentDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ((!IsPostBack) && (Request.QueryString.Count > 0))
            {
                this.GetDepartment();
            }
        }

        protected void GetDepartment()
        {
            //populate the form with existing department data from the db
            int DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

            //connect to the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                //populate a department instance with the DepartmentID from the URL parameter
                Department updatedDepartment = (from department in db.Departments
                                          where department.DepartmentID == DepartmentID
                                                select department).FirstOrDefault();


                //map the department properties to the form controls
                if (updatedDepartment != null)
                {
                    DepartmentNameTextBox.Text = updatedDepartment.Name;
                    BudgetTextBox.Text = Convert.ToString(updatedDepartment.Budget);
                }
            }
        }

        protected void CancelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~.Departments.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            //connect to the EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                //use department model to save the object
                Department newDepartment = new Department();

                int DepartmentID = 0;
                if (Request.QueryString.Count > 0)
                {
                    //get the id from the URL
                    DepartmentID = Convert.ToInt32(Request.QueryString["DepartmentID"]);

                    //get the current department fromt the EF DB
                    newDepartment = (from department in db.Departments
                                  where department.DepartmentID == DepartmentID
                                  select department).FirstOrDefault();
                }

                newDepartment.Name = DepartmentNameTextBox.Text;
                newDepartment.Budget = Convert.ToInt32(BudgetTextBox.Text);

                //adds new department to the Department Table collection

                //check to see if new department is being added
                if (DepartmentID == 0)
                {
                    db.Departments.Add(newDepartment);
                }

                //save changes - run an update
                db.SaveChanges();

                //redirect to the updated department table
                Response.Redirect("~/Departments.aspx");
            }
        }
    }
}