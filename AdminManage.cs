using System;
using System.Windows.Forms;
namespace Go
{
    public partial class AdminManage : Form
    {  
        private ManageWorkout ucManageWorkout;
        private ManageUsers ucManageUsers;
        private ManageMeal ucManageMeal;
        private ManageRequest ucManageRequest;
        public AdminManage()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen; 
                    if (ucManageUsers == null) ucManageUsers = new ManageUsers();
            LoadUserControl(ucManageUsers);
        }        
        private void LoadUserControl(UserControl uc)
        {
            if (panelContainer == null) return;
            panelContainer.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContainer.Controls.Add(uc);
            uc.BringToFront();
        }
        private void homebtn_Click(object sender, EventArgs e)
        {
            if (ucManageWorkout == null) ucManageWorkout = new ManageWorkout();
            LoadUserControl(ucManageWorkout);
        }
        private void userbtn_Click(object sender, EventArgs e)
        {
            if (ucManageUsers == null) ucManageUsers = new ManageUsers();
            LoadUserControl(ucManageUsers);
        }
        private void mealbtn_Click(object sender, EventArgs e)
        {
            if (ucManageMeal == null) ucManageMeal = new ManageMeal();
            LoadUserControl(ucManageMeal);
        }
        private void requestbtn_Click(object sender, EventArgs e)
        {
            if (ucManageRequest == null) ucManageRequest = new ManageRequest();
            LoadUserControl(ucManageRequest);
        }
        private void leaveBtn_Click(object sender, EventArgs e)
        {
            AdminLogin adminLoginForm = new AdminLogin();
            adminLoginForm.StartPosition = FormStartPosition.CenterScreen; 
            adminLoginForm.Show();
            this.Close();
        }
    }
}
