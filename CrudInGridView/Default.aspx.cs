using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace CrudInGridView
{
    public partial class Default : System.Web.UI.Page
    {
        string connectionString = @"Data Source=localhost;Initial Catalog=TEST;Integrated Security=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                PopulateGridview();
            }
        }

        void PopulateGridview()
        {
            DataTable dtbl = new DataTable();
            using (SqlConnection sqlCon = new SqlConnection(connectionString))
            {
                sqlCon.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("select * from ProcessStep", sqlCon);
                sqlDa.Fill(dtbl);
            }
            if (dtbl.Rows.Count > 0)
            {
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
            }
            else
            {
                dtbl.Rows.Add(dtbl.NewRow());
                gvPhoneBook.DataSource = dtbl;
                gvPhoneBook.DataBind();
                gvPhoneBook.Rows[0].Cells.Clear();
                gvPhoneBook.Rows[0].Cells.Add(new TableCell());
                gvPhoneBook.Rows[0].Cells[0].ColumnSpan = dtbl.Columns.Count;
                gvPhoneBook.Rows[0].Cells[0].Text = "No Data Found ..!";
                gvPhoneBook.Rows[0].Cells[0].HorizontalAlign = HorizontalAlign.Center;
            }

        }

        protected void gvPhoneBook_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName.Equals("AddNew"))
                {
                    using (SqlConnection sqlCon = new SqlConnection(connectionString))
                    {
                        sqlCon.Open();
                        string query = "INSERT INTO ProcessStep (StepName, Description, IsActive, LastUpdate, LastUpdateBy) VALUES (@StepName,@Description,@IsActive,@LastUpdate, @LastUpdateBy)";
                        SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                        sqlCmd.Parameters.AddWithValue("@StepName", (gvPhoneBook.FooterRow.FindControl("txtStepNameFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@Description", (gvPhoneBook.FooterRow.FindControl("txtDescriptionFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@IsActive", (gvPhoneBook.FooterRow.FindControl("txtIsActiveFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastUpdate", (gvPhoneBook.FooterRow.FindControl("txtLastUpdateFooter") as TextBox).Text.Trim());
                        sqlCmd.Parameters.AddWithValue("@LastUpdateBy", (gvPhoneBook.FooterRow.FindControl("txtLastUpdateByFooter") as TextBox).Text.Trim());
                        sqlCmd.ExecuteNonQuery();
                        PopulateGridview();
                        lblSuccessMessage.Text = "New Record Added";
                        lblErrorMessage.Text = "";
                    }
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }

        protected void gvPhoneBook_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPhoneBook.EditIndex = e.NewEditIndex;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPhoneBook.EditIndex = -1;
            PopulateGridview();
        }

        protected void gvPhoneBook_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "UPDATE ProcessStep SET StepName=@StepName,Description=@Description,IsActive=@IsActive,LastUpdate=@LastUpdate ,LastUpdateBy=@LastUpdateBy WHERE StepID= @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@StepName", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtStepName") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@Description", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtDescription") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@IsActive", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtIsActive") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastUpdate", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLastUpdate") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@LastUpdateBy", (gvPhoneBook.Rows[e.RowIndex].FindControl("txtLastUpdateBy") as TextBox).Text.Trim());
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    gvPhoneBook.EditIndex = -1;
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Updated";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
        //shoul be import function checkdata format. but i don have time, i need look the footlball match bettwen VN and UAE, so i will update late.
        bool checkdata()
        {
            return false;
        }
        protected void gvPhoneBook_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                using (SqlConnection sqlCon = new SqlConnection(connectionString))
                {
                    sqlCon.Open();
                    string query = "DELETE FROM ProcessStep WHERE StepID = @id";
                    SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
                    sqlCmd.Parameters.AddWithValue("@id", Convert.ToInt32(gvPhoneBook.DataKeys[e.RowIndex].Value.ToString()));
                    sqlCmd.ExecuteNonQuery();
                    PopulateGridview();
                    lblSuccessMessage.Text = "Selected Record Deleted";
                    lblErrorMessage.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblSuccessMessage.Text = "";
                lblErrorMessage.Text = ex.Message;
            }
        }
    }
}