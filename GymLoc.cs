using System;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

namespace Go
{
    public partial class GymLoc : UserControl
    {
        private string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\users.accdb";
        private string currentLocation = string.Empty;
        public GymLoc()
        {
            InitializeComponent();
            CustomizeRichTextBox();
            richTextBoxChat.DoubleClick += RichTextBoxChat_DoubleClick;
            InitializeWebView();
        }
        private void CustomizeRichTextBox()
        {         
            richTextBoxChat.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            richTextBoxChat.ForeColor = System.Drawing.Color.Black; 
            richTextBoxChat.Font = new System.Drawing.Font("Segoe UI", 10); 
            richTextBoxChat.ReadOnly = true; 
            richTextBoxChat.BorderStyle = BorderStyle.FixedSingle;
            richTextBoxChat.ScrollBars = RichTextBoxScrollBars.Vertical; 
        }        
        private async void InitializeWebView()
        {
            try
            {
                await webViewGym.EnsureCoreWebView2Async(null);
                webViewGym.CoreWebView2.WebMessageReceived += WebView_WebMessageReceived;                
                await LoadMap();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"WebView2 initialization failed: {ex.Message}", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WebView_WebMessageReceived(object sender, Microsoft.Web.WebView2.Core.CoreWebView2WebMessageReceivedEventArgs e)
        {
            var locationData = e.TryGetWebMessageAsString();
            if (!string.IsNullOrEmpty(locationData))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    currentLocation = locationData;
                    HandleLocationSelection(locationData);
                });
            }
        }
        private void HandleLocationSelection(string locationName)
        {
            if (FormLogin.CurrentUserID == 0)
            {
                MessageBox.Show("Please login to access chat features.", "Authentication Required",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            (bool isApproved, int locationId) = GetLocationApprovalStatus(locationName);

            if (isApproved)
            {
                LoadChatMessages(locationId);
                ShowChatPanel(true);
            }
            else
            {
                if (HasUserRequested(locationName, FormLogin.CurrentUserID))
                {
                    MessageBox.Show("You have already requested a chat for this location. Waiting for admin approval.",
                                  "Request Pending", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var result = MessageBox.Show($"Request community chat for {locationName}?", "Chat Request",
                                          MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    RequestChatApproval(locationName);
                }
            }
        }
        private (bool isApproved, int locationId) GetLocationApprovalStatus(string locationName)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT LocationID, IsApproved FROM tblChatLocations WHERE LocationName = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("LocationName", locationName);
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (Convert.ToBoolean(reader["IsApproved"]), Convert.ToInt32(reader["LocationID"]));
                        }
                    }
                }
            }
            return (false, 0);
        }
        private bool HasUserRequested(string locationName, int userId)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM tblChatLocations WHERE LocationName = ? AND UserID = ?";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("LocationName", locationName);
                    cmd.Parameters.AddWithValue("UserID", userId);
                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
            }
        }
        private void RequestChatApproval(string locationName)
        {
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();

                string checkQuery = @"SELECT COUNT(*) 
                      FROM tblChatLocations 
                      WHERE LocationName = ? 
                        AND UserID = ? 
                        AND IsApproved = False";

                using (OleDbCommand checkCmd = new OleDbCommand(checkQuery, conn))
                {                   
                    checkCmd.Parameters.Add("LocationName", OleDbType.VarChar).Value = locationName;
                    checkCmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;

                    int count = (int)checkCmd.ExecuteScalar();

                    if (count == 0)
                    {
                        string insertQuery = @"INSERT INTO tblChatLocations 
            (LocationName, UserID, Message, IsApproved, RequestDate) 
            VALUES (?, ?, ?, ?, ?)";

                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            insertCmd.Parameters.Add("LocationName", OleDbType.VarChar).Value = locationName;
                            insertCmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                            insertCmd.Parameters.Add("Message", OleDbType.VarChar).Value =
                                $"Chat request from {FormLogin.CurrentUsername} for {locationName}";
                            insertCmd.Parameters.Add("IsApproved", OleDbType.Boolean).Value = false;
                            insertCmd.Parameters.Add("RequestDate", OleDbType.Date).Value = DateTime.Now;

                            insertCmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Chat request sent to admin for approval.", "Request Sent",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("You already have a pending request for this location.",
                            "Request Already Exists", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
        private void LoadChatMessages(int locationId)
        {
            try
            {
                richTextBoxChat.Clear(); 

                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string messageQuery = @"SELECT m.MessageText, u.username, m.TimeS 
                                    FROM tblChatMessages m
                                    INNER JOIN tblUser  u ON m.UserID = u.UserID
                                    WHERE m.LocationID = ?
                                    ORDER BY m.TimeS";

                    using (OleDbCommand messageCmd = new OleDbCommand(messageQuery, conn))
                    {
                        messageCmd.Parameters.AddWithValue("?", locationId);

                        using (OleDbDataReader reader = messageCmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                DateTime timeS = reader["TimeS"] != DBNull.Value ?
                                    Convert.ToDateTime(reader["TimeS"]) : DateTime.MinValue;

                                string username = reader["username"] != DBNull.Value ?
                                    reader["username"].ToString() : "[Unknown]";

                                string messageText = reader["MessageText"] != DBNull.Value ?
                                    reader["MessageText"].ToString() : "[No Message]";

                                
                                string displayMessage = timeS != DateTime.MinValue ?
                                    $"{timeS:g} - {username}: {messageText}" :
                                    $"[No Date] - {username}: {messageText}";                                
                                richTextBoxChat.AppendText(displayMessage + Environment.NewLine);
                            }
                        }
                    }
                }               
                richTextBoxChat.SelectionStart = richTextBoxChat.Text.Length; 
                richTextBoxChat.ScrollToCaret();
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Database error loading messages:\n{ex.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error:\n{ex.Message}",
                                  "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void ShowChatPanel(bool show)
        {            
            txtMessage.Visible = show;
            btnSend.Visible = show;
            if (show) txtMessage.Focus();
        }
        private async Task LoadMap()
        {
            if (webViewGym.CoreWebView2 == null)
            {
                MessageBox.Show("WebView2 is not initialized. Please try again.", "Error",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // Get all approved locations from database
            var approvedLocations = GetApprovedLocations();
            //type your API in the "YOUR_API_HERE"
            string mapHtml = $@"
        <!DOCTYPE html>
        <html>
        <head>
            <meta name='viewport' content='initial-scale=1.0, user-scalable=no' />
            <script src='YOUR_API_HERE'></script>
            <style>
                #map {{ height: 100%; width: 100%; }}
                #autocomplete {{
                    width: 100%;
                    padding: 10px;
                    box-sizing: border-box;
                    font-size: 16px;
                    margin-bottom: 10px;
                }}
                body, html {{ margin: 0; padding: 0; height: 100%; }}
                .chat-button {{
                    background-color: #4285F4;
                    color: white;
                    border: none;
                    padding: 8px 12px;
                    border-radius: 4px;
                    cursor: pointer;
                    margin-top: 5px;
                }}
                .chat-button:hover {{
                    background-color: #3367D6;
                }}
            </style>
        </head>
        <body>
            <input id='autocomplete' placeholder='Enter a gym location' type='text'/>
            <div id='map'></div>

            <script>
                let map, marker, infoWindow, selectedPlace;
                const approvedLocations = {Newtonsoft.Json.JsonConvert.SerializeObject(approvedLocations)};

                function initMap() {{
                    const location = {{ lat: 37.7749, lng: -122.4194 }};
                    map = new google.maps.Map(document.getElementById('map'), {{
                        zoom: 14,
                        center: location,
                        mapTypeControl: true,
                        streetViewControl: true
                    }});

                    marker = new google.maps.Marker({{
                        position: location,
                        map: map,
                        draggable: true,
                        title: 'Selected Location'
                    }});

                    infoWindow = new google.maps.InfoWindow();

                    marker.addListener('click', function () {{
                        if (selectedPlace) {{
                            const isApproved = approvedLocations.includes(selectedPlace.name);
                            const content = `<div>
                                <strong>${{selectedPlace.name}}</strong><br>
                                ${{selectedPlace.formatted_address}}<br>
                                <button class='chat-button' onclick='window.chrome.webview.postMessage(""${{selectedPlace.name}}"")'>
                                    ${{isApproved ? 'Join Chat' : 'Request Chat'}}
                                </button>
                            </div>`;
                            infoWindow.setContent(content);
                        }} else {{
                            const pos = marker.getPosition();
                            const content = `<div>
                                Custom Location<br>
                                ${{pos.lat()}}, ${{pos.lng()}}<br>
                                <button class='chat-button' onclick='window.chrome.webview.postMessage(""Custom Location"")'>
                                    Request Chat
                                </button>
                            </div>`;
                            infoWindow.setContent(content);
                        }}
                        infoWindow.open(map, marker);
                    }});

                    map.addListener('click', function (event) {{
                        marker.setPosition(event.latLng);
                        selectedPlace = null;
                    }});

                    initAutocomplete();
                }}

                function initAutocomplete() {{
                    const input = document.getElementById('autocomplete');
                    const autocomplete = new google.maps.places.Autocomplete(input);
                    autocomplete.bindTo('bounds', map);
                    autocomplete.setFields(['name', 'formatted_address', 'geometry']);

                    autocomplete.addListener('place_changed', function () {{
                        const place = autocomplete.getPlace();
                        if (!place.geometry) return;

                        selectedPlace = place;
                        map.setCenter(place.geometry.location);
                        marker.setPosition(place.geometry.location);
                    }});
                }}

                window.onload = initMap;
            </script>
        </body>
        </html>";

            webViewGym.NavigateToString(mapHtml);
        }
        private System.Collections.Generic.List<string> GetApprovedLocations()
        {
            var locations = new System.Collections.Generic.List<string>();
            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT LocationName FROM tblChatLocations WHERE IsApproved = True";
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            locations.Add(reader["LocationName"].ToString());
                        }
                    }
                }
            }
            return locations;
        }
        private async void btnSend_Click_1(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMessage.Text)) return;
            if (string.IsNullOrEmpty(currentLocation)) return;
            string messageText = txtMessage.Text.Trim();
            try
            {
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    conn.Open();
                    string locationQuery = "SELECT LocationID FROM tblChatLocations WHERE LocationName = ? AND IsApproved = True";
                    int locationId = 0;
                    using (OleDbCommand locationCmd = new OleDbCommand(locationQuery, conn))
                    {
                        locationCmd.Parameters.Add("LocationName", OleDbType.VarChar).Value = currentLocation;
                        object result = locationCmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value) locationId = Convert.ToInt32(result);
                    }

                    if (locationId > 0)
                    {
                        string insertQuery = @"INSERT INTO tblChatMessages 
                               (LocationID, UserID, MessageText, TimeS) 
                               VALUES (?, ?, ?, ?)";
                        using (OleDbCommand insertCmd = new OleDbCommand(insertQuery, conn))
                        {
                            DateTime messageTime = DateTime.Now;
                            insertCmd.Parameters.Add("LocationID", OleDbType.Integer).Value = locationId;
                            insertCmd.Parameters.Add("UserID", OleDbType.Integer).Value = FormLogin.CurrentUserID;
                            insertCmd.Parameters.Add("MessageText", OleDbType.VarWChar).Value = messageText;
                            insertCmd.Parameters.Add("TimeS", OleDbType.Date).Value = messageTime;

                            int rowsAffected = insertCmd.ExecuteNonQuery();
                            if (rowsAffected == 1)
                            {                                
                                string displayMessage = $"{messageTime:g} - {FormLogin.CurrentUsername}: {messageText}";
                                richTextBoxChat.AppendText(displayMessage + Environment.NewLine);
                                richTextBoxChat.SelectionStart = richTextBoxChat.Text.Length;
                                richTextBoxChat.ScrollToCaret();

                                txtMessage.Clear();
                                txtMessage.Focus();
                            
                            }
                            else
                            {
                                MessageBox.Show("Failed to send message. Please try again.", "Error",
                                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Location not found or not approved. Please select a valid location.",
                                      "Location Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (OleDbException ex)
            {
                MessageBox.Show($"Database error: {ex.Message}\n\nError code: {ex.ErrorCode}\n\n" +
                               "Possible solutions:\n" +
                               "1. Verify all field names match the database exactly\n" +
                               "2. Check that CurrentUserID is valid\n" +
                               "3. Ensure database has write permissions",
                               "Database Error",
                               MessageBoxButtons.OK, MessageBoxIcon.Error);

                Debug.WriteLine($"OleDb Exception: {ex}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unexpected error: {ex.Message}",
                              "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Debug.WriteLine($"Exception: {ex}");
            }
        }
        private void RichTextBoxChat_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
//klip
//basta kani