using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


//required for EF DB access
using COMP2007_Lab03.Models;
using System.Web.ModelBinding;
using System.Linq.Dynamic;

namespace COMP2007_Lab03
{
    public partial class Departments : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // get data
            this.GetDepartments();

        }

        protected void GetDepartments()
        {
            
            //connect to EF DB
            using (DefaultConnection db = new DefaultConnection())
            {
                //query the students table using EF and LINQ
                var Departments = (from allDepartments in db.Departments
                                select allDepartments);

                //bind the result to the GridView
                DepartmentsGridView.DataSource = Departments.AsQueryable().ToList();
                DepartmentsGridView.DataBind();
            }
        }

        protected void DepartmentsGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            //store which row was clicked
            int selectedRow = e.RowIndex;

            //get the selected StudentID using the Grid's Datakey Collection
            int DepartmentID = Convert.ToInt32(DepartmentsGridView.DataKeys[selectedRow].Values["DepartmentID"]);

            //use EF to find the selected student from DB and remove it
            using (DefaultConnection db = new DefaultConnection())
            {
                Department deletedDepartment = (from departmentRecords in db.Departments
                                          where departmentRecords.DepartmentID == DepartmentID
                                          select departmentRecords).FirstOrDefault();

                //perform the removal in the db
                db.Departments.Remove(deletedDepartment);

                //save the changes
                db.SaveChanges();

                //refresh the grid
                this.GetDepartments();
            }
        }

        protected void DepartmentsGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

        }

        protected void DepartmentsGridView_Sorting(object sender, GridViewSortEventArgs e)
        {

        }

        protected void DepartmentsGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {

        }
    }
}