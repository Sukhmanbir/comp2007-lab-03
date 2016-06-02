<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StudentDetails.aspx.cs" Inherits="COMP2007_Lab03.StudentDetails" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="conatiner">
        <div class="row">
            <div class="col-md-offset-3 col-md-6">
                <h1>Student Details</h1>
                <h5>All Fields are required</h5>
                <br />
                <div class="form-group">
                    <label class="control-label" for="LastNameTextBox">Last Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="LastNameTextBox"
                        placeholder="Last Name" required="true" MaxLength="50"></asp:TextBox>

                    <label class="control-label" for="FirstNameTextBox">First Name</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="FirstNameTextBox"
                        placeholder="First Name" required="true" MaxLength="50"></asp:TextBox>

                    <label class="control-label" for="EnrollmentDateTextBox">Enrollment Date</label>
                    <asp:TextBox runat="server" CssClass="form-control" ID="EnrollmentDateTextBox"
                        placeholder="Enrollment Date" required="true" TextMode="Date"></asp:TextBox>

                </div>
                <div class="text-right">
                    <asp:Button Text="Cancel" ID="CancelButton" runat="server" CssClass="btn btn-warning" UseSubmitBehavior="false" CausesValidation="false" OnClick="CancelButton_Click" />
                    <asp:Button Text="Save" ID="SaveButton" runat="server" CssClass="btn btn-primary" OnClick="SaveButton_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
