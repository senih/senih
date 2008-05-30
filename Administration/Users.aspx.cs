using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using MyWebSite;

public partial class Administration_Users : PageBaseClass
{
    
    protected void Page_Load(object sender, EventArgs e)
    {        
        if (User.IsInRole("administrators"))
        {
            GridView UserGV = (GridView)LoginView1.FindControl("UsersGridView");
            HtmlTable UserMG = (HtmlTable)LoginView1.FindControl("UserManage");
            UserGV.DataSource = Membership.GetAllUsers();
            UserGV.DataBind();
            if (Page.IsPostBack)
            {
                UserMG.Visible = true;
            }
        }
        if ((!User.IsInRole("administrators")) && (User.Identity.IsAuthenticated))
        {
            if (!Page.IsPostBack)
            {
            TextBox UserEmailTB = (TextBox)LoginView1.FindControl("UserEmailTextBox");
            Label UserLbl = (Label)LoginView1.FindControl("UserLabel");
            MembershipUser user = Membership.GetUser(User.Identity.Name);
            UserLbl.Text = User.Identity.Name;
            UserEmailTB.Text = user.Email;            
            }
            
        }
        
    }

    protected void UsersGridView_SelectedIndexChanged(object sender, EventArgs e)
    {
        GridView UserGV = (GridView)LoginView1.FindControl("UsersGridView");
        string username = UserGV.SelectedDataKey.Value.ToString();
        MembershipUser selectedUser = Membership.GetUser(username);

        Label UserNameLbl = (Label)LoginView1.FindControl("UserNameLabel");
        UserNameLbl.Text = username;
        
        TextBox EmailTB = (TextBox)LoginView1.FindControl("EmailTextBox");
        EmailTB.Text = selectedUser.Email;
        
        CheckBox ApprovedCB = (CheckBox)LoginView1.FindControl("ApprovedCheckBox");
        ApprovedCB.Checked = selectedUser.IsApproved;


        DropDownList RolesDD = (DropDownList)LoginView1.FindControl("RolesDropDown");
        RolesDD.DataSource = Roles.GetAllRoles();
        RolesDD.DataBind();
        RolesDD.Items.Insert(0,new ListItem("None", "-1" ));
        if (Roles.IsUserInRole(username, "administrators"))
        {
            string rolestring = Roles.GetRolesForUser(username).GetValue(0).ToString();
            RolesDD.SelectedValue = rolestring;
        }
        else if (Roles.IsUserInRole(username, "users"))
        {
            string rolestring = Roles.GetRolesForUser(username).GetValue(0).ToString();
            RolesDD.SelectedValue = rolestring;
        }
        else
        {
            RolesDD.SelectedValue = "-1";
        }
       
    }
    protected void DeleteButton_Click(object sender, EventArgs e)
    {
        HtmlTable UserMG = (HtmlTable)LoginView1.FindControl("UserManage");
        GridView UserGV = (GridView)LoginView1.FindControl("UsersGridView");                
        string username = UserGV.SelectedDataKey.Value.ToString();       
        Membership.DeleteUser(username);        
        UserGV.DataSource = Membership.GetAllUsers();
        UserGV.DataBind();
        UserMG.Visible = false;


        
    }
    protected void UpdateButton_Click(object sender, EventArgs e)
    {
        HtmlTable UserMG = (HtmlTable)LoginView1.FindControl("UserManage");
        GridView UserGV = (GridView)LoginView1.FindControl("UsersGridView");        
        Label UserNameLbl = (Label)LoginView1.FindControl("UserNameLabel");
        TextBox EmailTB = (TextBox)LoginView1.FindControl("EmailTextBox");
        CheckBox ApprovedCB = (CheckBox)LoginView1.FindControl("ApprovedCheckBox");
        CheckBox LockedCB = (CheckBox)LoginView1.FindControl("LockedCheckBox");
        DropDownList RolesDD = (DropDownList)LoginView1.FindControl("RolesDropDown");

        MembershipUser updatedUser = Membership.GetUser(UserNameLbl.Text);
        updatedUser.Email = EmailTB.Text;
        updatedUser.IsApproved = ApprovedCB.Checked;

        bool cntrlvar1 = Roles.IsUserInRole(updatedUser.UserName, "administrators");
        bool cntrlvar2 = Roles.IsUserInRole(updatedUser.UserName, "users");
        string temp = RolesDD.SelectedValue;
        bool cntrlvar3 = Roles.RoleExists(temp);
        if (cntrlvar1)
        {
            Roles.RemoveUserFromRole(updatedUser.UserName, "administrators");
        }
        else if (cntrlvar2)
        {
            Roles.RemoveUserFromRole(updatedUser.UserName, "users");
        }

        if (Roles.RoleExists(temp))
        {
            Roles.AddUserToRole(updatedUser.UserName, temp);
        }
        
        Membership.UpdateUser(updatedUser);

        UserGV.DataSource = Membership.GetAllUsers();
        UserGV.DataBind();
        UserMG.Visible = false;
        
    }

    protected void UpdateUserButton_Click(object sender, EventArgs e)
    {
        MembershipUser user = Membership.GetUser(User.Identity.Name);
        TextBox UserEmailTB = (TextBox)LoginView1.FindControl("UserEmailTextBox");
        TextBox UserPasswordTB = (TextBox)LoginView1.FindControl("UserPasswordTextBox");
        TextBox ConfirmPasswordTB = (TextBox)LoginView1.FindControl("ConfirmPasswordTextBox");
        TextBox OldPasswordTB = (TextBox)LoginView1.FindControl("OldPasswordTextBox");
        Label MinPasswordLengthLbl = (Label)LoginView1.FindControl("MinPasswordLengthLabel");
        Label UserStatusLbl = (Label)LoginView1.FindControl("UserStatusLabel");
        
                
        if (UserPasswordTB.Text != "")
        {
            if (UserPasswordTB.Text.Length >= 5)
            {
                if (user.ChangePassword(OldPasswordTB.Text, UserPasswordTB.Text))
                {
                    UserStatusLbl.Text = "Password changed successfully!";
                }
                else
                {
                    UserStatusLbl.Text = "Password not changed!";
                }                
            }
            else
            {
                MinPasswordLengthLbl.Text = "Minimum password length is 5 characters";
            }
        }

            user.Email = UserEmailTB.Text;
            Membership.UpdateUser(user);
                       
        
        
            
    }
}
