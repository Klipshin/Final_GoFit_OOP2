using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Go
{
    public partial class ChatControl : UserControl
    {
        private FlowLayoutPanel chatPanel;
        private TextBox messageBox;
        private Button sendButton;
        private string connectionString;
        private string currentLocation;
        private int currentLocationId;
        private int currentUserId;
        private string currentUsername;

        public ChatControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        public void Initialize(string connectionString, string location, int userId, string username)
        {
            this.connectionString = connectionString;
            this.currentLocation = location;
            this.currentUserId = userId;
            this.currentUsername = username;

            // Get the location ID
            GetLocationId();
        }

        private void GetLocationId()
        {
            if (string.IsNullOrEmpty(currentLocation)) return;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT LocationID FROM tblChatLocations WHERE LocationName = ? AND IsApproved = True";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbParameter param = cmd.Parameters.Add("LocationName", OleDbType.VarChar);
                        param.Value = currentLocation;
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            currentLocationId = Convert.ToInt32(result);
                            LoadChatMessages(currentLocationId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting location ID: {ex.Message}");
            }
        }

        private void InitializeUI()
        {
            // Create the main layout
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(30, 30, 35);

            // Create the chat panel for messages
            chatPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(30, 30, 35),
                Padding = new Padding(10)
            };

            // Create input panel at the bottom
            Panel inputPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(45, 45, 48),
                Padding = new Padding(10, 8, 10, 8)
            };

            // Create message input box
            messageBox = new TextBox
            {
                Multiline = true,
                Height = 34,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f)
            };

            // Create send button
            sendButton = new Button
            {
                Text = "Send",
                Width = 80,
                Height = 34,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.FromArgb(220, 50, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // Add event handlers
            sendButton.Click += SendButton_Click;
            messageBox.KeyDown += MessageBox_KeyDown;

            // Add controls to panel
            inputPanel.Controls.Add(messageBox);
            inputPanel.Controls.Add(sendButton);

            // Add panels to user control
            this.Controls.Add(chatPanel);
            this.Controls.Add(inputPanel);
        }

        public void FocusMessageInput()
        {
            messageBox.Focus();
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                SendButton_Click(sender, e);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageBox.Text)) return;
            SendMessage(messageBox.Text.Trim());
        }

        private void SendMessage(string message)
        {
            if (currentLocationId <= 0) return;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = @"INSERT INTO tblChatMessages 
                       (LocationID, UserID, MessageText, TimeS) 
                       VALUES (?, ?, ?, ?)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        OleDbParameter locParam = insertCmd.Parameters.Add("LocationID", OleDbType.Integer);
                        locParam.Value = currentLocationId;

                        OleDbParameter userParam = insertCmd.Parameters.Add("UserID", OleDbType.Integer);
                        userParam.Value = currentUserId;

                        OleDbParameter msgParam = insertCmd.Parameters.Add("MessageText", OleDbType.VarWChar);
                        msgParam.Value = message;

                        OleDbParameter timeParam = insertCmd.Parameters.Add("TimeS", OleDbType.Date);
                        timeParam.Value = DateTime.Now;

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            LoadChatMessages(currentLocationId);
                            messageBox.Clear();
                            messageBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to send message. Please try again.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Exception sending message: {ex}");
            }
        }

        public void LoadChatMessages(int locationId)
        {
            try
            {
                currentLocationId = locationId;
                chatPanel.Controls.Clear();

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string messageQuery = @"SELECT m.MessageText, u.username, m.TimeS, m.UserID
                               FROM tblChatMessages m
                               INNER JOIN tblUser u ON m.UserID = u.UserID
                               WHERE m.LocationID = ?
                               ORDER BY m.TimeS";

                    using (OleDbCommand messageCmd = new OleDbCommand(messageQuery, conn))
                    {
                        messageCmd.Parameters.AddWithValue("?", locationId);

                        using (OleDbDataReader reader = messageCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Extract message data
                                DateTime timeS = reader["TimeS"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["TimeS"]) : DateTime.MinValue;

                                string username = reader["username"] != DBNull.Value ?
                                    reader["username"].ToString() : "[Unknown]";

                                string messageText = reader["MessageText"] != DBNull.Value ?
                                    reader["MessageText"].ToString() : "[No Message]";

                                int userId = Convert.ToInt32(reader["UserID"]);
                                bool isCurrentUser = userId == currentUserId;

                                // Add chat bubble
                                AddChatBubble(username, messageText, timeS, isCurrentUser);
                            }
                        }
                    }
                }

                // Scroll to the bottom
                if (chatPanel.Controls.Count > 0)
                {
                    chatPanel.ScrollControlIntoView(chatPanel.Controls[chatPanel.Controls.Count - 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading messages: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Exception loading messages: {ex}");
            }
        }

        private void AddChatBubble(string username, string message, DateTime timestamp, bool isCurrentUser)
        {
            // Create container panel for alignment
            FlowLayoutPanel container = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = isCurrentUser ? FlowDirection.RightToLeft : FlowDirection.LeftToRight,
                Width = chatPanel.ClientSize.Width - 20,
                Margin = new Padding(0, 5, 0, 5),
                WrapContents = false
            };

            // Create chat bubble
            Panel bubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size((int)(chatPanel.ClientSize.Width * 0.7), 0),
                Padding = new Padding(10),
                BackColor = isCurrentUser ? Color.FromArgb(220, 50, 50) : Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                Margin = new Padding(5)
            };

            // Add username label
            Label nameLabel = new Label
            {
                Text = username,
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Top
            };

            // Add message label
            Label msgLabel = new Label
            {
                Text = message,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.75f),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Padding = new Padding(0, 5, 0, 5)
            };

            // Add time label
            Label timeLabel = new Label
            {
                Text = timestamp.ToString("h:mm tt"),
                AutoSize = true,
                Font = new Font("Segoe UI", 7),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Bottom,
                TextAlign = isCurrentUser ? ContentAlignment.BottomLeft : ContentAlignment.BottomRight
            };

            // Add controls to bubble
            bubble.Controls.Add(timeLabel);
            bubble.Controls.Add(msgLabel);
            bubble.Controls.Add(nameLabel);

            // Make bubble corners rounded
            bubble.Paint += (s, e) =>
            {
                GraphicsPath gp = new GraphicsPath();
                int radius = 10;
                Rectangle rect = new Rectangle(0, 0, bubble.Width - 1, bubble.Height - 1);
                gp.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                gp.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
                gp.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
                gp.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
                gp.CloseAllFigures();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(bubble.BackColor))
                {
                    e.Graphics.FillPath(brush, gp);
                }
            };

            // Add bubble to container
            container.Controls.Add(bubble);

            // Add container to chat panel
            chatPanel.Controls.Add(container);
        }
    }

    public partial class CopyOfChatControl : UserControl
    {
        private FlowLayoutPanel chatPanel;
        private TextBox messageBox;
        private Button sendButton;
        private string connectionString;
        private string currentLocation;
        private int currentLocationId;
        private int currentUserId;
        private string currentUsername;

        public CopyOfChatControl()
        {
            InitializeComponent();
            InitializeUI();
        }

        public void Initialize(string connectionString, string location, int userId, string username)
        {
            this.connectionString = connectionString;
            this.currentLocation = location;
            this.currentUserId = userId;
            this.currentUsername = username;

            // Get the location ID
            GetLocationId();
        }

        private void GetLocationId()
        {
            if (string.IsNullOrEmpty(currentLocation)) return;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT LocationID FROM tblChatLocations WHERE LocationName = ? AND IsApproved = True";
                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        OleDbParameter param = cmd.Parameters.Add("LocationName", OleDbType.VarChar);
                        param.Value = currentLocation;
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            currentLocationId = Convert.ToInt32(result);
                            LoadChatMessages(currentLocationId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error getting location ID: {ex.Message}");
            }
        }

        private void InitializeUI()
        {
            // Create the main layout
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(30, 30, 35);

            // Create the chat panel for messages
            chatPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Fill,
                AutoScroll = true,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                BackColor = Color.FromArgb(30, 30, 35),
                Padding = new Padding(10)
            };

            // Create input panel at the bottom
            Panel inputPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                BackColor = Color.FromArgb(45, 45, 48),
                Padding = new Padding(10, 8, 10, 8)
            };

            // Create message input box
            messageBox = new TextBox
            {
                Multiline = true,
                Height = 34,
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f)
            };

            // Create send button
            sendButton = new Button
            {
                Text = "Send",
                Width = 80,
                Height = 34,
                Dock = DockStyle.Right,
                FlatStyle = FlatStyle.Flat,
                FlatAppearance = { BorderSize = 0 },
                BackColor = Color.FromArgb(220, 50, 50),
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 10f, FontStyle.Bold),
                Cursor = Cursors.Hand
            };

            // Add event handlers
            sendButton.Click += SendButton_Click;
            messageBox.KeyDown += MessageBox_KeyDown;

            // Add controls to panel
            inputPanel.Controls.Add(messageBox);
            inputPanel.Controls.Add(sendButton);

            // Add panels to user control
            this.Controls.Add(chatPanel);
            this.Controls.Add(inputPanel);
        }

        public void FocusMessageInput()
        {
            messageBox.Focus();
        }

        private void MessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                SendButton_Click(sender, e);
            }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(messageBox.Text)) return;
            SendMessage(messageBox.Text.Trim());
        }

        private void SendMessage(string message)
        {
            if (currentLocationId <= 0) return;

            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string insertQuery = @"INSERT INTO tblChatMessages 
                       (LocationID, UserID, MessageText, TimeS) 
                       VALUES (?, ?, ?, ?)";

                    using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                    {
                        OleDbParameter locParam = insertCmd.Parameters.Add("LocationID", OleDbType.Integer);
                        locParam.Value = currentLocationId;

                        OleDbParameter userParam = insertCmd.Parameters.Add("UserID", OleDbType.Integer);
                        userParam.Value = currentUserId;

                        OleDbParameter msgParam = insertCmd.Parameters.Add("MessageText", OleDbType.VarWChar);
                        msgParam.Value = message;

                        OleDbParameter timeParam = insertCmd.Parameters.Add("TimeS", OleDbType.Date);
                        timeParam.Value = DateTime.Now;

                        int rowsAffected = insertCmd.ExecuteNonQuery();
                        if (rowsAffected == 1)
                        {
                            LoadChatMessages(currentLocationId);
                            messageBox.Clear();
                            messageBox.Focus();
                        }
                        else
                        {
                            MessageBox.Show("Failed to send message. Please try again.", "Error",
                                          MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error sending message: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Exception sending message: {ex}");
            }
        }

        public void LoadChatMessages(int locationId)
        {
            try
            {
                currentLocationId = locationId;
                chatPanel.Controls.Clear();

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string messageQuery = @"SELECT m.MessageText, u.username, m.TimeS, m.UserID
                               FROM tblChatMessages m
                               INNER JOIN tblUser u ON m.UserID = u.UserID
                               WHERE m.LocationID = ?
                               ORDER BY m.TimeS";

                    using (OleDbCommand messageCmd = new OleDbCommand(messageQuery, conn))
                    {
                        messageCmd.Parameters.AddWithValue("?", locationId);

                        using (OleDbDataReader reader = messageCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Extract message data
                                DateTime timeS = reader["TimeS"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["TimeS"]) : DateTime.MinValue;

                                string username = reader["username"] != DBNull.Value ?
                                    reader["username"].ToString() : "[Unknown]";

                                string messageText = reader["MessageText"] != DBNull.Value ?
                                    reader["MessageText"].ToString() : "[No Message]";

                                int userId = Convert.ToInt32(reader["UserID"]);
                                bool isCurrentUser = userId == currentUserId;

                                // Add chat bubble
                                AddChatBubble(username, messageText, timeS, isCurrentUser);
                            }
                        }
                    }
                }

                // Scroll to the bottom
                if (chatPanel.Controls.Count > 0)
                {
                    chatPanel.ScrollControlIntoView(chatPanel.Controls[chatPanel.Controls.Count - 1]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading messages: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Exception loading messages: {ex}");
            }
        }

        private void AddChatBubble(string username, string message, DateTime timestamp, bool isCurrentUser)
        {
            // Create container panel for alignment
            FlowLayoutPanel container = new FlowLayoutPanel
            {
                AutoSize = true,
                FlowDirection = isCurrentUser ? FlowDirection.RightToLeft : FlowDirection.LeftToRight,
                Width = chatPanel.ClientSize.Width - 20,
                Margin = new Padding(0, 5, 0, 5),
                WrapContents = false
            };

            // Create chat bubble
            Panel bubble = new Panel
            {
                AutoSize = true,
                MaximumSize = new Size((int)(chatPanel.ClientSize.Width * 0.7), 0),
                Padding = new Padding(10),
                BackColor = isCurrentUser ? Color.FromArgb(220, 50, 50) : Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                Margin = new Padding(5)
            };

            // Add username label
            Label nameLabel = new Label
            {
                Text = username,
                AutoSize = true,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Top
            };

            // Add message label
            Label msgLabel = new Label
            {
                Text = message,
                AutoSize = true,
                Font = new Font("Segoe UI", 9.75f),
                ForeColor = Color.White,
                Dock = DockStyle.Top,
                Padding = new Padding(0, 5, 0, 5)
            };

            // Add time label
            Label timeLabel = new Label
            {
                Text = timestamp.ToString("h:mm tt"),
                AutoSize = true,
                Font = new Font("Segoe UI", 7),
                ForeColor = Color.LightGray,
                Dock = DockStyle.Bottom,
                TextAlign = isCurrentUser ? ContentAlignment.BottomLeft : ContentAlignment.BottomRight
            };

            // Add controls to bubble
            bubble.Controls.Add(timeLabel);
            bubble.Controls.Add(msgLabel);
            bubble.Controls.Add(nameLabel);

            // Make bubble corners rounded
            bubble.Paint += (s, e) =>
            {
                GraphicsPath gp = new GraphicsPath();
                int radius = 10;
                Rectangle rect = new Rectangle(0, 0, bubble.Width - 1, bubble.Height - 1);
                gp.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
                gp.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
                gp.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
                gp.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
                gp.CloseAllFigures();

                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (SolidBrush brush = new SolidBrush(bubble.BackColor))
                {
                    e.Graphics.FillPath(brush, gp);
                }
            };

            // Add bubble to container
            container.Controls.Add(bubble);

            // Add container to chat panel
            chatPanel.Controls.Add(container);
        }
    }
}