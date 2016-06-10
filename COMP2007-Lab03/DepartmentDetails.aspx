<%@ Page Title="Department Details" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DepartmentDetails.aspx.cs" Inherits="COMP2007_Lab03.DepartmentDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conatiner">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Department Details</h1>
                <h5>All Fields are required</h5>
                <br />
                <div class="form-group">

                    <label class="control-label" for="DepartmentNameTextBox">Department Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="DepartmentNameTextBox"
                        placeholder="Department Name" required="true" MaxLength="100"></asp:TextBox>

                    <label class="control-label" for="BudgetTextBox">Budget</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="BudgetTextBox"
                        placeholder="Budget" required="true" TextMode="Number"></asp:TextBox>

                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
