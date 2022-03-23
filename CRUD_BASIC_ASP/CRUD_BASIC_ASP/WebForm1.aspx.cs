using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace CRUD_BASIC_ASP
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        String hobby;
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Database1ConnectionString1"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            //ConnectionString = "<%$ ConnectionStrings:Database1ConnectionString1 %>"
            //DeleteCommand = "DELETE FROM [employee] WHERE [Id] = @Id" 
            //InsertCommand = "INSERT INTO [employee] ([Name], [Number], [Hobbies], [Cast], [Course], [img], [Gender]) VALUES (@Name, @Number, @Hobbies, @Cast, @Course, @img, @gender)"
            //SelectCommand = "SELECT [Id], [Name], [Number], [Hobbies], [Cast], [Course], [img], [Gender] FROM [employee]"
            //UpdateCommand = "UPDATE [employee] SET [Name] = @Name, [Number] = @Number, [Hobbies] = @Hobbies, [Cast] = @Cast, [Course] = @Course, [img] = @img, [Gender] = @gender WHERE [Id] = @Id"
            Print();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if (Button1.Text == "Submit")
            {
                if (FileUpload1.HasFile)
                {
                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (li.Selected)
                        {
                            hobby = hobby + li.Value + " , ";

                        }
                    }
                    FileUpload1.SaveAs(Server.MapPath("~/uploads/") + FileUpload1.FileName);
                    SqlCommand cmd = new SqlCommand("INSERT INTO [employee] ([Name], [Number], [Hobbies], [Cast], [Course], [img], [Gender]) VALUES (@Name, @Number, @Hobbies, @Cast, @Course, @img, @gender)", con);
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@number", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@hobbies", hobby);
                    cmd.Parameters.AddWithValue("@cast", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@course", ListBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@img", FileUpload1.FileName);
                    con.Open();
                    int s = cmd.ExecuteNonQuery();
                    con.Close();
                    if (s == 1)
                    {
                        Clear();
                        Literal8.Text = "Inserted Succefully";
                        Print();
                    }
                    else
                    {
                        Clear();
                        Literal8.Text = "Error ! Insertion";
                        Print();
                    }


                }
                else
                {
                    Literal8.Text = "Please Inser Photo";
                }
            }
            else
            {
                if (FileUpload1.HasFile)
                {
                    
                    FileUpload1.SaveAs(Server.MapPath("~/uploads/") + FileUpload1.FileName);
                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (li.Selected)
                        {
                            hobby = hobby + li.Value + ",";

                        }
                    }
                    SqlCommand cmd = new SqlCommand("UPDATE [employee] SET [Name] = @Name, [Number] = @Number, [Hobbies] = @Hobbies, [Cast] = @Cast, [Course] = @Course, [img] = @img, [Gender] = @gender WHERE [Id] = @Id", con);
                    cmd.Parameters.AddWithValue("@Name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@Number", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@Hobbies", hobby);
                    cmd.Parameters.AddWithValue("@Cast", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@Course", ListBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@img", FileUpload1.FileName);
                    cmd.Parameters.AddWithValue("@Id", ViewState["ID"]);
                    con.Open();
                    int s = cmd.ExecuteNonQuery();
                    con.Close();
                    if (s == 1)
                    {
                        Clear();
                        Literal8.Text = "Upadated Succefully";
                        Print();
                    }
                    else
                    {
                        Clear();
                        Literal8.Text = "Error ! Updation";
                        Print();
                    }


                }
                else
                {
                    foreach (ListItem li in CheckBoxList1.Items)
                    {
                        if (li.Selected)
                        {
                            hobby = hobby + li.Value + " , ";

                        }
                    }
                    
                    SqlCommand cmd = new SqlCommand("UPDATE [employee] SET [Name] = @Name, [Number] = @Number, [Hobbies] = @Hobbies, [Cast] = @Cast, [Course] = @Course,[Gender] = @gender WHERE [Id] = @Id", con);
                    cmd.Parameters.AddWithValue("@name", TextBox1.Text);
                    cmd.Parameters.AddWithValue("@number", TextBox2.Text);
                    cmd.Parameters.AddWithValue("@hobbies", hobby);
                    cmd.Parameters.AddWithValue("@cast", DropDownList1.SelectedValue);
                    cmd.Parameters.AddWithValue("@course", ListBox1.SelectedValue);
                    cmd.Parameters.AddWithValue("@gender", RadioButtonList1.SelectedValue);
                    
                    cmd.Parameters.AddWithValue("@Id", ViewState["ID"]);
                    con.Open();
                    int s = cmd.ExecuteNonQuery();
                    con.Close();
                    if (s == 1)
                    {
                        Clear();
                        Literal8.Text = "Upadated Succefully";
                        Print();
                    }
                    else
                    {
                        Clear();
                        Literal8.Text = "Error ! Updation";
                        Print();
                    }
                }
            }
        }
        public void Clear()
        {
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;
            CheckBoxList1.ClearSelection();
            //ListBox1.SelectedIndex = -1;
            ListBox1.ClearSelection();
            //DropDownList1.SelectedIndex = -1;
            DropDownList1.ClearSelection();
            RadioButtonList1.ClearSelection();
            FileUpload1.Attributes.Clear();
            Image1.ImageUrl = string.Empty;
        }
        public void Print()
        {
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [Name], [Number], [Hobbies], [Cast], [Course], [img], [Gender] FROM [employee]", con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void ImageButton2_Click(object sender, ImageClickEventArgs e)
        {
            ImageButton btn = (ImageButton)sender;
            SqlCommand cmd = new SqlCommand("DELETE FROM [employee] WHERE [Id] = @Id", con);
            cmd.Parameters.AddWithValue("@Id", btn.CommandArgument);
            con.Open();
            int s = cmd.ExecuteNonQuery();
            con.Close();
            if (s == 1)
            {
                Clear();
                Literal8.Text = "Deleted  Succefully";
                Print();
            }
            else
            {
                Clear();
                Literal8.Text = "Error ! Delete";
                Print();
            }
        }

        protected void ImageButton3_Click(object sender, ImageClickEventArgs e)
        {
            String res = "";
            ImageButton btn = (ImageButton)sender;
            SqlDataAdapter adpt = new SqlDataAdapter("SELECT [Id], [Name], [Number], [Hobbies], [Cast], [Course], [img], [Gender] FROM [employee] WHERE [Id] = " + btn.CommandArgument, con);
            DataTable dt = new DataTable();
            adpt.Fill(dt);
            TextBox1.Text = dt.Rows[0][1].ToString();
            TextBox2.Text = dt.Rows[0][2].ToString();
            res = dt.Rows[0][3].ToString();
            String[] hlist = res.Split(',');
            CheckBoxList1.ClearSelection();
            foreach (var li in hlist)
            {
                foreach (ListItem hli in CheckBoxList1.Items)
                {
                    if (li == hli.ToString())
                    {
                        hli.Selected = true;
                    }
                }
            }


            RadioButtonList1.SelectedValue = dt.Rows[0][7].ToString();
            DropDownList1.SelectedValue = dt.Rows[0][4].ToString();
            ListBox1.SelectedValue = dt.Rows[0][5].ToString();
            Image1.ImageUrl = "~/uploads/" + dt.Rows[0][6].ToString();
            ViewState["ID"] = btn.CommandArgument;
            Button1.Text = "Update";
        }
    }
}