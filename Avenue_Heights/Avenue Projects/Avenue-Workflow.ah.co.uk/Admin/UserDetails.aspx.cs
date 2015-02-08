using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avenue_Workflow.ah.co.uk.Admin
{
    public partial class UserDetails : Avenue.Workflow.WorkflowPage
    {
        protected void Page_PreInit(object sender, EventArgs e)
        {
            if (!User.Identity.IsAuthenticated)
            {
                Response.Redirect("http:\\www.avenue-workflow.ah.co.uk");
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindAdminNav();
                BindUserDetails();
                BindIterationDetails();
                BindTaskDetails();
            }
        }

        protected void Page_Init(object sender, EventArgs e)
        {
            btnSave.Click += btnSave_Click;
            btnSavePassword.Click += btnSavePassword_Click;
        }

        public void BindAdminNav()
        {
            cAdminNav.userDetailsPage = true;
        }

        public void BindIterationDetails()
        {
            lblTotalIterationsIn.Text = CurrentUser.IterationsPartOf.Count.ToString();
            lblTotalIterationsOwned.Text = CurrentUser.IterationsPartOf.Count.ToString();
        }

        public void BindTaskDetails()
        {
            lblAssigned.Text = CurrentUser.AllTasks.Count.ToString();
            lblCompleted.Text = CurrentUser.CompletedTasks.Count.ToString();
            lblInProgress.Text = CurrentUser.UnCompletedTasks.Count.ToString();
        }

        public void BindUserDetails()
        {
            lblDisplayName.Text = CurrentUser.UserName;
            txtFirstName.Text = CurrentUser.UserFirstName;
            txtLastName.Text = CurrentUser.UserLastName;
            txtEmailAddress.Text = CurrentUser.UserEmail;
            txtUserName.Text = CurrentUser.UserName;
        }

        #region Event Handlers

        void btnSavePassword_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.Text == txtConfirmNewPassword.Text)
            {
                if (Member.ChangePassword(txtOldPassword.Text, txtNewPassword.Text))
                {
                    lblMessage2.Text = "Password changed successfully";
                }
                else lblMessage2.Text = "Incorrect old password";
            }
            else lblMessage2.Text = "New Passowrds do not match";
        }

        void btnSave_Click(object sender, EventArgs e)
        {
            CurrentUser.UserFirstName = txtFirstName.Text;
            CurrentUser.UserLastName = txtLastName.Text;
            CurrentUser.UserEmail = txtEmailAddress.Text;
            CurrentUser.UserName = txtUserName.Text;

            CurrentUser.Update();

            lblMessage.Text = "Updated";
        }

        #endregion
    }
}