using System;
using System.Data.OleDb;
using System.Text;
using System.Windows.Forms;
using MailKit.Net.Smtp;
using MimeKit;
using System.Security.Cryptography;

namespace Go
{
    public partial class ForgotPass : BaseForm 
    {
        private string verificationCode;
        private string userEmail;

        public ForgotPass()
        {
            InitializeComponent();
        }
        private void btnemail_Click(object sender, EventArgs e)
        {
            userEmail = txtemail.Text.Trim();

            if (string.IsNullOrEmpty(userEmail))
            {
                MessageBox.Show("Please enter your registered email.");
                return;
            }

            if (IsEmailRegistered(userEmail)) 
            {
                verificationCode = GenerateVerificationCode();
                if (SendVerificationEmail(userEmail, verificationCode))
                {
                    MessageBox.Show("A verification code has been sent to your email.");
                }
                else
                {
                    MessageBox.Show("Failed to send email. Please try again.");
                }
            }
            else
            {
                MessageBox.Show("This email is not registered.");
            }
        }
        private void btncheckcode_Click(object sender, EventArgs e)
        {
            if (txtcode.Text == verificationCode)
            {
                MessageBox.Show("Code verified. You can now reset your password.");
                txtpass.Enabled = true;
                txtconpass.Enabled = true;
                verifybtn.Enabled = true;
            }
            else
            {
                MessageBox.Show("Incorrect verification code.");
            }
        }
        private void verifybtn_Click(object sender, EventArgs e)
        {
            if (txtpass.Text != txtconpass.Text)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            if (UpdatePassword(userEmail, txtpass.Text)) 
            {
                MessageBox.Show("Password successfully reset! You can now log in.");
                new FormLogin().Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Error resetting password. Please try again.");
            }
        }
        private bool UpdatePassword(string email, string newPassword)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString)) 
            {
                string hashedPassword = HashPassword(newPassword); 
                string query = "UPDATE tblUser  SET [password] = ? WHERE email = ?";

                using (OleDbCommand cmd = new OleDbCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("?", hashedPassword);
                    cmd.Parameters.AddWithValue("?", email);

                    connection.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
            }
        }
        private string GenerateVerificationCode()
        {
            Random rnd = new Random();
            return rnd.Next(100000, 999999).ToString();
        }
        private bool SendVerificationEmail(string recipientEmail, string verificationCode)
        {
            try
            {
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Edward Alsonado", "alsonadoedward@gmail.com"));
                message.To.Add(new MailboxAddress("", recipientEmail));
                message.Subject = "Password Reset Code";

                message.Body = new TextPart("plain")
                {
                    Text = $"Your verification code is: {verificationCode}"
                };

                using (var client = new SmtpClient())
                {
                    client.Connect("smtp.gmail.com", 587, false);
                    client.Authenticate("alsonadoedward@gmail.com", "mvvw jpfc shzj nyec"); // Replace with your App Password
                    client.Send(message);
                    client.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Email sending error: {ex.Message}");
                return false;
            }
        }
        private void showPasscheckbox_CheckedChanged(object sender, EventArgs e)
        {
            txtpass.PasswordChar = showPasscheckbox.Checked ? '\0' : '*';
            txtconpass.PasswordChar = showPasscheckbox.Checked ? '\0' : '*';
        }
        private void backLog_Click(object sender, EventArgs e)
        {
            new FormLogin().Show();
            this.Hide();
        }
    }
}
