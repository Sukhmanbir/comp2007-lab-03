<%@ Page Title="Departments" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Departments.aspx.cs" Inherits="COMP2007_Lab03.Departments" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    

    <div class="conatiner">
        <div class="row">
            <div class="col-md-offset-2 col-md-8">
                <h1>Departments List</h1>
                <asp:GridView runat="server" ID="DepartmentsGridView" AutoGenerateColumns="false"
                                CssClass="table table-striped table-bordered table-hover"
                                DataKeyNames="DepartmentID" OnRowDeleting="DepartmentsGridView_RowDeleting"
                                AllowPaging="true" PageSize="3" OnPageIndexChanging="DepartmentsGridView_PageIndexChanging"
                                AllowSorting="true" OnSorting="DepartmentsGridView_Sorting" OnRowDataBound="DepartmentsGridView_RowDataBound">
        

                    <Columns>
                        <asp:BoundField DataField="DepartmentID" HeaderText="Department ID" Visible="true" SortExpression="DepartmentID" />
                        <asp:BoundField DataField="Name" HeaderText="Name" Visible="true" SortExpression="Name" />
                        <asp:BoundField DataField="Budget" HeaderText="First Name" Visible="true" SortExpression="Budget" />
                        
                        <asp:CommandField HeaderText="Delete" DeleteText="<i class='fa fa-trash-o fa-lg'></i> Delete" ShowDeleteButton="true" 
                            ButtonType="Link" ControlStyle-CssClass="btn btn-danger btn-sm" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
