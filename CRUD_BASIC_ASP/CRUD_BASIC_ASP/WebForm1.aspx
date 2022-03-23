<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="CRUD_BASIC_ASP.WebForm1" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 418px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table align="center">
                <tr>
                    <td colspan="3" align="center" ><b>EMPLOYEE DETAILS</b></td>
                </tr>
                
                <tr>
                    <td colspan="3">
                        <br />
                    </td>
                </tr>
                <tr>
                    <td width="25%">Name</td>
                    <td width="10%">:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Number</td>
                    <td >:</td>
                    <td class="auto-style1">
                        <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>Gender</td>
                    <td >:</td>
                    <td class="auto-style1">
                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                </tr>
                <tr>
                    <td>Hobbies</td>
                    <td >:</td>
                    <td class="auto-style1">
                        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem>Cricket</asp:ListItem>
                            <asp:ListItem>Hockey</asp:ListItem>
                            <asp:ListItem>Badminton</asp:ListItem>
                            <asp:ListItem>Swimming</asp:ListItem>
                        </asp:CheckBoxList>
                    </td>
                </tr>
                <tr>
                    <td>Cast</td>
                    <td >:</td>
                    <td class="auto-style1">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem>Vaniya</asp:ListItem>
                            <asp:ListItem>Patel</asp:ListItem>
                            <asp:ListItem>Soni</asp:ListItem>
                            <asp:ListItem>Brahman</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>Course</td>
                    <td >:</td>
                    <td class="auto-style1">
                        <asp:ListBox ID="ListBox1" runat="server" Rows="2">
                            <asp:ListItem>BSC IT</asp:ListItem>
                            <asp:ListItem>MSC IT</asp:ListItem>
                            <asp:ListItem>BCA</asp:ListItem>
                            <asp:ListItem>MCA</asp:ListItem>
                            <asp:ListItem>BBA</asp:ListItem>
                            <asp:ListItem>MBA</asp:ListItem>
                        </asp:ListBox>
                    </td>
                </tr>
                <tr>
                    <td>Photo</td>
                    <td >:</td>
                    <td class="auto-style1">
                        <asp:FileUpload ID="FileUpload1" runat="server" />
                        <br />
                        <br />
                        <asp:Image ID="Image1" runat="server" Height="100px" Width="100px" />
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td class="auto-style1">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Button ID="Button1" runat="server" Text="Submit" OnClick="Button1_Click" />
                    </td>
                    

                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Literal ID="Literal8" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        
                        
                        &nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                            <Columns>
                                <asp:TemplateField HeaderText="ID">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal1" runat="server" Text='<%# Eval("Id") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal2" runat="server" Text='<%# Eval("Name") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Number">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal3" runat="server" Text='<%# Eval("Number") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Gender">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal4" runat="server" Text='<%# Eval("Gender") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Hobbies">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal5" runat="server" Text='<%# Eval("Hobbies") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Cast">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal6" runat="server" Text='<%# Eval("Cast") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Course">
                                    <ItemTemplate>
                                        <asp:Literal ID="Literal7" runat="server" Text='<%# Eval("Course") %>'></asp:Literal>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Photo">
                                    <ItemTemplate>
                                        <asp:Image ID="Image3" runat="server" Height="100px" ImageUrl='<%# Eval("img","~/uploads/{0}") %>' Width="100px" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Edit">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton3" runat="server" CommandArgument='<%# Eval("Id") %>' Height="40px" ImageUrl="~/img/Edit.png" Width="40px" OnClick="ImageButton3_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Delete">
                                    <ItemTemplate>
                                        <asp:ImageButton ID="ImageButton2" runat="server" CommandArgument='<%# Eval("Id") %>' Height="50px" ImageUrl="~/img/delete.png" Width="40px" OnClick="ImageButton2_Click" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
                </table>
        </div>
    </form>
</body>
</html>
