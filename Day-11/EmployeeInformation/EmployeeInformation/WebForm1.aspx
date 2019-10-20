<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="EmployeeInformation.WebForm1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <form style="width: 400px; margin: 0 auto;">
        <h2>Employee Information</h2>
        <div class="form-group">
            <label style="font-size: 1.4rem;" for="employeeNameTextBox">Employee Name</label>
            <input type="text" class="form-control" id="employeeNameTextBox" placeholder="Employee Name" runat="server" />
            <asp:RequiredFieldValidator ID="nametextBoxValidator" Display="Dynamic" ControlToValidate="employeeNameTextBox" runat="server" ErrorMessage="Please Input Employee Name" ForeColor="red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label for="genderDropDownList" style="font-size: 1.4rem;">Gender</label><br />
            <asp:DropDownList ID="genderDropDownList" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Gender" Value="0"></asp:ListItem>
                <asp:ListItem Text="Male" Value="1"></asp:ListItem>
                <asp:ListItem Text="Female" Value="2"></asp:ListItem>
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="genderDropDownListValidator" InitialValue="0" ControlToValidate="genderDropDownList" runat="server" ErrorMessage="Please Select Gender" Display="Dynamic" ForeColor="red"></asp:RequiredFieldValidator>

        </div>
        <div class="form-group">
            <label style="font-size: 1.4rem;" for="employeeCityTextBox">Employee City</label><br />
            <input id="employeeCityTextBox" class="form-control" style="width: 100%;" runat="server" type="text" placeholder="Input City" />
            <asp:RequiredFieldValidator ID="employeeCityTextBoxValidator" runat="server" Display="Dynamic" ErrorMessage="Please enter the city" ControlToValidate="dateOfBirth" ForeColor="red"></asp:RequiredFieldValidator>
        </div>
        <div class="form-group">
            <label style="font-size: 1.4rem;" for="dateOfBirth">Date Of Birth</label><br />
            <asp:TextBox ID="dateOfBirth" CssClass="form-control" TextMode="Date" Width="100%" Text="SelectDate" runat="server"></asp:TextBox>
            <asp:RangeValidator ID="RangeValidatorDateOfBirth" runat="server" ForeColor="red" Display="Dynamic" ErrorMessage="The date can't be more than 30/12/2008" ControlToValidate="dateOfBirth" Type="Date" MinimumValue="01/01/1900" MaximumValue="30/12/2008"></asp:RangeValidator>
        </div>
        <div style="margin: 0 auto; width: 100%">

            <asp:Button ID="submitButton" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="submitButton_Click" /><br />
            <asp:Label ID="msgLabel" runat="server"></asp:Label>
        </div>
        <div style="margin-top: 1.4rem;">

            <asp:GridView ID="showInformation" runat="server" AutoGenerateColumns="False">
                <Columns>
                    <asp:TemplateField HeaderText="Employee Id">
                        <ItemTemplate>
                            <%#Eval("EmployeeId") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee Name">
                        <ItemTemplate>
                            <%# Eval("EmployeeName") %>
                        </ItemTemplate>
                    </asp:TemplateField>

                    <asp:TemplateField HeaderText="Employee Gender">
                        <ItemTemplate>
                            <%# Eval("Gender") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Employee City">
                        <ItemTemplate>
                            <%# Eval("EmployeeCity") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Date Of Birth">
                        <ItemTemplate>
                            <%# Eval("DateOfBirth") %>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>

    </form>
</asp:Content>
