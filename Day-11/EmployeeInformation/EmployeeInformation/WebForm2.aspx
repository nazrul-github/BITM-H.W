<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="EmployeeInformation.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
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
</asp:Content>
