using System;
using System.Data.OleDb;
using System.Windows.Forms;
namespace Go
{
    public partial class AdminLogin : BaseForm
    {
        public static int CurrentAdminID { get; private set; }
        public static string CurrentAdminUsername { get; private set; }

        public AdminLogin()
        {
            InitializeComponent();
        }
        private void AdminLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtusername; 
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Please enter both email/username and password", "Input Required",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var con = new OleDbConnection(connectionString))
                {
                    con.Open();

                    const string loginQuery = @"SELECT ID, AdminUsername FROM tblAdmin  
                                                WHERE (AdminUsername = @Username OR AdminEmail = @Email) 
                                                AND AdminPass = @Password";

                    using (var cmd = new OleDbCommand(loginQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtusername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtusername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", txtpass.Text.Trim()); 

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                CurrentAdminID = Convert.ToInt32(dr["ID"]);
                                CurrentAdminUsername = dr["AdminUsername"].ToString();

                                var manageForm = new AdminManage(); 
                                manageForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid admin credentials", "Login Failed",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Login error: {ex.Message}", "Database Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showPasscheckbox_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = showPasscheckbox.Checked ? '\0' : '*';
        }
        private void clearbtn_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpass.Clear();
            txtusername.Focus();
        }
        private void backUserlbl_Click(object sender, EventArgs e)
        {
            new FormLogin().Show(); 
            this.Hide();
        }
        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
