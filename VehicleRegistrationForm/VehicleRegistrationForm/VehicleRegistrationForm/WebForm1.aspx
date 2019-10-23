<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="VehicleRegistrationForm.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table  style="width: 664px; border: 1px solid #000000">
        <tr>
            <td colspan="3"><h2 class="text-center">Vehicle Registration Form</h2></td>
            
           </tr><tr>
            <td style="font-size: medium; width: 215px"><strong>Vehicle Manufacturer</strong></td>
            <td>
                <asp:TextBox ID="manufacturerTextBox" CssClass="form-control" runat="server" Width="407px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="manufacturerTextBoxValidator" ForeColor="red" ControlToValidate="manufacturerTextBox" Text="*"  runat="server" ErrorMessage="Please enter vehicle manufacturer name"></asp:RequiredFieldValidator></td>
           </tr><tr>
            <td style="font-size: medium; width: 215px"><strong>Model Year</strong></td>
            <td>
                <asp:TextBox ID="modelYearTextBox" CssClass="form-control" runat="server" Width="407px"></asp:TextBox></td>

            
            <td>
                <asp:RequiredFieldValidator ID="modelYearTextBoxValidator" ForeColor="red" ControlToValidate="modelYearTextBox" Text="*"  runat="server" ErrorMessage="Please enter vehicle model year"></asp:RequiredFieldValidator></td>
            
           </tr><tr>
            <td style="font-size: medium; width: 215px"><strong>Color</strong></td>
            <td>
                <asp:TextBox ID="colorTextBox" CssClass="form-control" runat="server" Width="407px"></asp:TextBox></td>
                
            
            <td>
                <asp:RequiredFieldValidator ID="colorTextBoxValidator" ForeColor="red" ControlToValidate="colorTextBox" Text="*"  runat="server" ErrorMessage="Please enter vehicle color"></asp:RequiredFieldValidator></td>
           </tr><tr>
            <td style="font-size: medium; width: 215px"><strong>Insurance Number</strong></td>
            <td>
                <asp:TextBox ID="insuranceNumberTextBox" CssClass="form-control" runat="server" Width="407px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="insuranceNumberTextBoxValidator" ForeColor="red" ControlToValidate="insuranceNumberTextBox" Text="*"  runat="server" ErrorMessage="Please enter vehicle insurance number"></asp:RequiredFieldValidator></td>
            
           </tr><tr>
            <td style="font-size: medium; width: 215px"><strong>Owner Name</strong></td>
            <td>
                <asp:TextBox ID="ownerNameTextBox" CssClass="form-control" runat="server" Width="407px"></asp:TextBox></td>
            
            <td>
                <asp:RequiredFieldValidator ID="ownerNameTextBoxValidator" ForeColor="red" ControlToValidate="ownerNameTextBox" Text="*"  runat="server" ErrorMessage="Please enter vehicle owner name"></asp:RequiredFieldValidator></td>
           </tr><tr>
            <td style="font-size: medium; width: 215px"><strong>Registration City</strong></td>
            <td>
                <asp:TextBox ID="cityTextBox" CssClass="form-control" runat="server" Width="407px"></asp:TextBox></td>
            <td>
                <asp:RequiredFieldValidator ID="cityTextBoxValidator" ForeColor="red" ControlToValidate="cityTextBox" Text="*"  runat="server" ErrorMessage="Please enter vehicle city"></asp:RequiredFieldValidator></td>
           </tr><tr>
            <td colspan="1" style="padding: 15px" dir="rtl">
               <asp:Button ID="saveButton" CssClass="btn btn-primary" runat="server" Text="Save" OnClick="saveButton_Click" /></td>
            <td>
           </tr><tr>
            <td colspan="3" style="width: 215px;"><asp:Label ID="msgLabel" runat="server"></asp:Label></td>
           
           </tr><tr>
            <td style="width: 215px" colspan="3">
                <asp:ValidationSummary ID="ValidationSummary" ForeColor="red" DisplayMode="List" HeaderText="Validation Error!!!"  runat="server" />
            </td>
           </tr>
    </table>
    <fieldset>
        <legend>Registered Vehicles</legend>
        <asp:GridView ID="showAllGridView" runat="server" AutoGenerateColumns="False">
            <Columns>
            <asp:TemplateField HeaderText="Vehicle Owner">
                <ItemTemplate>
                    <%#Eval("OwnerName") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Manufacturer">
                <ItemTemplate>
                    <%#Eval("Manufacturer") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Model Year">
                <ItemTemplate>
                    <%#Eval("ModelYear") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Color">
                <ItemTemplate>
                    <%#Eval("Color") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Insrance Number">
                <ItemTemplate>
                    <%#Eval("InsuranceNumber") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Registration City">
                <ItemTemplate>
                    <%#Eval("RegistrationCity") %>
                </ItemTemplate>
            </asp:TemplateField><asp:TemplateField HeaderText="Registration Number">
                <ItemTemplate>
                    <%#Eval("RegistrationNumber") %>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </fieldset>

</asp:Content>
