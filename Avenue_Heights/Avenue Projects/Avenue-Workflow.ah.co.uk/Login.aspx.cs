using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Avenue_Workflow.ah.co.uk
{
    public partial class Login : Avenue.Workflow.WorkflowPage
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            btnNext.Click += btnNext_Click;
            btnBack.Click += btnBack_Click;
            btnComplete.Click += btnComplete_Click;
            aLogin.LoggedIn += Login_LoggedIn;
            aLogin.LoginError += Login_LoginError;
            ((Button)aLogin.FindControl("btnRegister")).Click += btnRegister_Click;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindUser();
            }
        }

        #region Bindings

        void BindUser()
        {
            if (Request.Cookies["RememberMe"] != null) if (Request.Cookies["AvenueUserLogin"] != null)
                {
                    aLogin.RememberMeSet = true;
                }

            if (aLogin.UserName != null && aLogin.UserName != "")
            {
                System.Web.Security.MembershipUser membershipUser = System.Web.Security.Membership.GetUser(aLogin.UserName);
            }

        }

        #endregion

        #region Handlers

        #region Registration

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            pnlLogIn.Visible = false;
            pnlRegister.Visible = true;
        }

        void btnNext_Click(object sender, EventArgs e)
        {
            pnlRegister1.Visible = false;
            pnlRegister2.Visible = true;
            System.Globalization.TextInfo TI = new System.Globalization.CultureInfo("en-US", false).TextInfo;
            lblUserName.Text = String.Format("{0} {1}", TI.ToTitleCase(txtFirstName.Text), TI.ToTitleCase(txtLastName.Text));
        }

        void btnBack_Click(object sender, EventArgs e)
        {
            pnlRegister2.Visible = false;
            pnlRegister1.Visible = true;
        }

        void btnComplete_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text.ToLower() != txtConfirmEmail.Text.ToLower()) lblMessage2.Text = "Email Address' do not match";
            else if (txtPassword.Text != txtConfirmPassword.Text) lblMessage2.Text = "Passwords to not match";
            else
            {
                String FirstName = txtFirstName.Text;
                String LastName = txtLastName.Text;
                String UserName = lblUserName.Text;
                String Email = txtEmail.Text;
                String Password = txtConfirmPassword.Text;
                System.Web.Security.MembershipCreateStatus CreationStatus = new System.Web.Security.MembershipCreateStatus();
                System.Web.Security.MembershipUser NewMembershipUser = System.Web.Security.Membership.CreateUser(UserName, Password, Email, "First Name", FirstName, true, out CreationStatus);

                if (NewMembershipUser == null) lblMessage2.Text = CreationStatus.ToString();
                else
                {
                    System.Web.HttpContext.Current.Profile.Initialize(UserName, true);
                    System.Web.HttpContext.Current.Profile.Save();

                    Avenue.Heights.AvenueHeightsProfile newProfile = (Avenue.Heights.AvenueHeightsProfile)Avenue.Heights.AvenueHeightsProfile.GetProfile(UserName);
                    newProfile.UserID = 0;
                    newProfile.WorkflowIterationID = 0;
                    newProfile.WorkflowTaskID = 0;

                    System.Web.Security.RoleProvider aRoleProvider = System.Web.Security.Roles.Providers["AvenueHeightsRoleProvider"];
                    String[] User = { UserName };
                    String[] Role = { "Member" };
                    aRoleProvider.AddUsersToRoles(User, Role);

                    aRoleProvider = System.Web.Security.Roles.Providers["AvenueWorkflowRoleProvider"];
                    aRoleProvider.AddUsersToRoles(User, Role);

                    Avenue.Workflow.Access.User newUser = new Avenue.Workflow.Access.User();
                    newUser.UserFirstName = FirstName;
                    newUser.UserLastName = LastName;
                    newUser.UserName = UserName;
                    newUser.UserEmail = Email;
                    newUser.UserThemeID = new Avenue.Workflow.Access.Theme(1);
                    newUser.UserAspNetMembership = (Guid)NewMembershipUser.ProviderUserKey;
                    newUser.Insert();

                    lblMessage.Text = "Registration Complete";

                    newProfile.UserID = newUser.UserID;
                    newProfile.Save();

                    pnlLogIn.Visible = true;
                    pnlRegister.Visible = false;
                }
            }
        }

        #endregion

        #region LogIn

        protected void Login_LoggedIn(object sender, EventArgs e)
        {
            if (aLogin.RememberMeSet == true)
            {
                HttpCookie aCookie = new HttpCookie("AvenueUserLogin");
                aCookie.Values["UserName"] = aLogin.UserName;
                aCookie.Expires = DateTime.Now.AddYears(50);
                Response.Cookies.Add(aCookie);
            }
            else
            {
                if (Request.Cookies["AvenueUserLogin"] != null) Request.Cookies["AvenueUserLogin"].Expires = DateTime.Now;
            }

            System.Web.Security.MembershipUser aMembershipUser = System.Web.Security.Membership.GetUser(aLogin.UserName);
            if (aMembershipUser != null)
            {
                Response.Redirect("Main.aspx");
            }

        }

        protected void Login_LoginError(object sender, EventArgs e)
        {
            System.Web.Security.MembershipUser userInfo = System.Web.Security.Membership.GetUser(aLogin.UserName);

            if (userInfo == null)
            {
                lblMessage.Text = aLogin.UserName + " Does Not Exist";
            }
            else
            {
                if (ViewState["loginCount"] == null) ViewState.Add("loginCount", 1);
                else ViewState["loginCount"] = (int)ViewState["loginCount"] + 1;

                if (!userInfo.IsApproved) lblMessage.Text = "User Is Not Approved";
                else if (userInfo.IsLockedOut) lblMessage.Text = "User is Locked Out";
                else if ((int)ViewState["loginCount"] >= 3) lblMessage.Text = String.Format("{0}{1}", "Attempted Login", ViewState["loginCount"]);
                else lblMessage.Text = String.Empty;
            }
        }
        #endregion

        #endregion
    }
}