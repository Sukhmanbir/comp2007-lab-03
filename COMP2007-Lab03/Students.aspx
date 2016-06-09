﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Students.aspx.cs" Inherits="COMP2007_Lab03.Students" %>


<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <div class="conatiner">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Students List</h1>
                <a href="StudentDetails.aspx" class="btn btn-success btn-sm"><i class="fa fa-plus"></i> Add Student</a>

                <asp:GridView runat="server" ID="StudentsGridView" AutoGenerateColumns="false"
                    CssClass="table table-striped table-bordered table-hover"
                    DataKeyNames="StudentID" OnRowDeleting="StudentsGridView_RowDeleting" >
                    <Columns>
                        <asp:BoundField DataField="StudentID" HeaderText="Student ID" Visible="true" />
                        <asp:BoundField DataField="LastName" HeaderText="Last Name" Visible="true" />
                        <asp:BoundField DataField="FirstMidName" HeaderText="First Name" Visible="true" />
                        <asp:BoundField DataField="EnrollmentDate" HeaderText="Enrollment Date" Visible="true" 
                            DataFormatString="{0:MMM dd, yyyy}"/>
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true" 
                            ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>

    
</asp:Content>
