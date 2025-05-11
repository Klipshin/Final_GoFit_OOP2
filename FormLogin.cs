using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Go
{
    public partial class FormLogin : BaseForm 
    {
        public static int CurrentUserID { get; private set; }
        public static string CurrentUsername { get; private set; }

        public FormLogin()
        {
            InitializeComponent();
        }
        private void FormLogin_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtusername;
        }
        private void loginbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpass.Text))
            {
                MessageBox.Show("Please enter both username and password", "Input Required",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                using (var con = new OleDbConnection(connectionString)) 
                {
                    con.Open();
                    string hashedPassword = HashPassword(txtpass.Text); 

                    const string loginQuery = @"SELECT UserID, username FROM tblUser  
                                              WHERE (username = @Username OR email = @Email) 
                                              AND password = @Password";

                    using (var cmd = new OleDbCommand(loginQuery, con))
                    {
                        cmd.Parameters.AddWithValue("@Username", txtusername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Email", txtusername.Text.Trim());
                        cmd.Parameters.AddWithValue("@Password", hashedPassword);

                        using (var dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                CurrentUserID = Convert.ToInt32(dr["UserID"]);
                                CurrentUsername = dr["username"].ToString();

                                var mainForm = new Main(CurrentUsername);
                                mainForm.Show();
                                this.Hide();
                            }
                            else
                            {
                                MessageBox.Show("Invalid credentials", "Login Failed",
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
        private void clearbtn_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtpass.Clear();
            txtusername.Focus();
        }
        private void showPasscheckbox_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = showPasscheckbox.Checked ? '\0' : '*';
        }
        private void createAcc_Click(object sender, EventArgs e)
        {
            new Register().Show();
            this.Hide();
        }

        private void forgotpass_Click(object sender, EventArgs e)
        {
            new ForgotPass().Show();
            this.Hide();
        }

        private void FormLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.Alt && e.KeyCode == Keys.A)
            {
                AdminLogin adminForm = new AdminLogin
                {
                    StartPosition = FormStartPosition.CenterScreen
                };
                adminForm.Show();
                this.Hide();
            }
        }

        private void exitbtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}