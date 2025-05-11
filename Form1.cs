using System;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Go
{
    public partial class Register : BaseForm
    {
        public Register()
        {
            InitializeComponent();
            
            this.KeyPreview = true;
            this.KeyDown += Register_KeyDown;
        }
        private void Register_Load(object sender, EventArgs e)
        {
            this.ActiveControl = txtusername;
        }
        private void Register_KeyDown(object sender, KeyEventArgs e)
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
        private void registerbtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) ||
                string.IsNullOrWhiteSpace(txtemail.Text) ||
                string.IsNullOrWhiteSpace(txtpass.Text) ||
                string.IsNullOrWhiteSpace(txtconpass.Text))
            {
                MessageBox.Show("All fields must be filled out.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (txtpass.Text != txtconpass.Text)
            {
                MessageBox.Show("Passwords do not match.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpass.Clear();
                txtconpass.Clear();
                txtpass.Focus();
                return;
            }
            try
            {
                using (OleDbConnection con = new OleDbConnection(connectionString))
                {
                    con.Open();
                    string checkUserQuery = "SELECT COUNT(*) FROM tblUser WHERE username = ? OR email = ?";
                    using (OleDbCommand checkCmd = new OleDbCommand(checkUserQuery, con))
                    {
                        checkCmd.Parameters.AddWithValue("?", txtusername.Text);
                        checkCmd.Parameters.AddWithValue("?", txtemail.Text);

                        int userExists = (int)checkCmd.ExecuteScalar();
                        if (userExists > 0)
                        {
                            MessageBox.Show("Username or Email already exists.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }
                    string hashedPassword = HashPassword(txtpass.Text);
                    string registerQuery = "INSERT INTO tblUser (username, email, [password]) VALUES (?, ?, ?)";
                    using (OleDbCommand cmd = new OleDbCommand(registerQuery, con))
                    {
                        cmd.Parameters.AddWithValue("?", txtusername.Text);
                        cmd.Parameters.AddWithValue("?", txtemail.Text);
                        cmd.Parameters.AddWithValue("?", hashedPassword);
                        cmd.ExecuteNonQuery();
                    }
                }
                txtusername.Clear();
                txtemail.Clear();
                txtpass.Clear();
                txtconpass.Clear();
                MessageBox.Show("Account successfully created.", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void showPasscheckbox_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = showPasscheckbox.Checked ? '\0' : '*';
            txtconpass.PasswordChar = showPasscheckbox.Checked ? '\0' : '*';
        }
        private void clearbtn_Click(object sender, EventArgs e)
        {
            txtusername.Clear();
            txtemail.Clear();
            txtpass.Clear();
            txtconpass.Clear();
            txtusername.Focus();
        }
        private void backLog_Click(object sender, EventArgs e)
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
