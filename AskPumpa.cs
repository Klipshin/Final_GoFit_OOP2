using System;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json; // For JSON serialization

namespace Go
{
    public partial class AskPumpa : UserControl
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string DeepSeekApiUrl = "https://api.deepseek.com/v1/chat/completions"; // Correct endpoint
        private const string DeepSeekApiKey = "sk-1a857ca9bb01423b831f5901d4cd88c2"; // Your DeepSeek API key

        public AskPumpa()
        {
            InitializeComponent();
            InitializeChatUI(); // Initialize the chat UI
        }

        private void InitializeChatUI()
        {
            // Set up the user control size
            this.Size = new Size(450, 400);

            // Chat history display (RichTextBox)
            RichTextBox chatHistory = new RichTextBox();
            chatHistory.Name = "chatHistory";
            chatHistory.ReadOnly = true;
            chatHistory.Size = new Size(400, 300);
            chatHistory.Location = new Point(10, 10);
            chatHistory.ScrollBars = RichTextBoxScrollBars.Vertical; // Add scrollbars
            this.Controls.Add(chatHistory);

            // User input textbox (TextBox)
            TextBox userInput = new TextBox();
            userInput.Name = "userInput";
            userInput.Size = new Size(300, 20);
            userInput.Location = new Point(10, 320);
            this.Controls.Add(userInput);

            // Send button (Button)
            Button sendButton = new Button();
            sendButton.Name = "sendButton";
            sendButton.Text = "Send";
            sendButton.Size = new Size(80, 25);
            sendButton.Location = new Point(320, 320);
            sendButton.Click += SendButton_Click; // Event handler for sending messages
            this.Controls.Add(sendButton);
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            // Get user input
            TextBox userInput = this.Controls.Find("userInput", true).FirstOrDefault() as TextBox;
            RichTextBox chatHistory = this.Controls.Find("chatHistory", true).FirstOrDefault() as RichTextBox;

            if (userInput != null && chatHistory != null)
            {
                string userMessage = userInput.Text;
                if (!string.IsNullOrEmpty(userMessage))
                {
                    // Display user message in chat history
                    chatHistory.AppendText($"You: {userMessage}\n");
                    chatHistory.ScrollToCaret(); // Auto-scroll to the bottom

                    // Clear the input box
                    userInput.Clear();

                    // Get Pumpa's response
                    string pumpaResponse = await GetPumpaResponse(userMessage);

                    // Display Pumpa's response in chat history
                    chatHistory.AppendText($"Pumpa: {pumpaResponse}\n");
                    chatHistory.ScrollToCaret(); // Auto-scroll to the bottom
                }
            }
        }

        private async Task<string> GetPumpaResponse(string userMessage)
        {
            try
            {
                // Prepare the request payload for DeepSeek Chat
                var requestPayload = new
                {
                    model = "deepseek-chat", // Replace with the correct model name
                    messages = new[]
                    {
                        new { role = "user", content = userMessage }
                    },
                    max_tokens = 150 // Adjust the response length
                };

                // Serialize the payload to JSON
                string jsonPayload = JsonConvert.SerializeObject(requestPayload);

                // Create the HTTP request
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, DeepSeekApiUrl);
                httpRequest.Headers.Add("Authorization", $"Bearer {DeepSeekApiKey}");
                httpRequest.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the request
                HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);

                // Read the response content
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response (adjust based on DeepSeek's API response structure)
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    return responseObject.choices[0].message.content; // Adjust based on the API response
                }
                else
                {
                    // Log the error details for debugging
                    return $"Error: {response.StatusCode}\nResponse: {responseContent}";
                }
            }
            catch (Exception ex)
            {
                return $"Oops! Something went wrong: {ex.Message}";
            }
        }
    }

    public partial class CopyOfAskPumpa : UserControl
    {
        private readonly HttpClient _httpClient = new HttpClient();
        private const string DeepSeekApiUrl = "https://api.deepseek.com/v1/chat/completions"; // Correct endpoint
        private const string DeepSeekApiKey = "sk-1a857ca9bb01423b831f5901d4cd88c2"; // Your DeepSeek API key

        public CopyOfAskPumpa()
        {
            InitializeComponent();
            InitializeChatUI(); // Initialize the chat UI
        }

        private void InitializeChatUI()
        {
            // Set up the user control size
            this.Size = new Size(450, 400);

            // Chat history display (RichTextBox)
            RichTextBox chatHistory = new RichTextBox();
            chatHistory.Name = "chatHistory";
            chatHistory.ReadOnly = true;
            chatHistory.Size = new Size(400, 300);
            chatHistory.Location = new Point(10, 10);
            chatHistory.ScrollBars = RichTextBoxScrollBars.Vertical; // Add scrollbars
            this.Controls.Add(chatHistory);

            // User input textbox (TextBox)
            TextBox userInput = new TextBox();
            userInput.Name = "userInput";
            userInput.Size = new Size(300, 20);
            userInput.Location = new Point(10, 320);
            this.Controls.Add(userInput);

            // Send button (Button)
            Button sendButton = new Button();
            sendButton.Name = "sendButton";
            sendButton.Text = "Send";
            sendButton.Size = new Size(80, 25);
            sendButton.Location = new Point(320, 320);
            sendButton.Click += SendButton_Click; // Event handler for sending messages
            this.Controls.Add(sendButton);
        }

        private async void SendButton_Click(object sender, EventArgs e)
        {
            // Get user input
            TextBox userInput = this.Controls.Find("userInput", true).FirstOrDefault() as TextBox;
            RichTextBox chatHistory = this.Controls.Find("chatHistory", true).FirstOrDefault() as RichTextBox;

            if (userInput != null && chatHistory != null)
            {
                string userMessage = userInput.Text;
                if (!string.IsNullOrEmpty(userMessage))
                {
                    // Display user message in chat history
                    chatHistory.AppendText($"You: {userMessage}\n");
                    chatHistory.ScrollToCaret(); // Auto-scroll to the bottom

                    // Clear the input box
                    userInput.Clear();

                    // Get Pumpa's response
                    string pumpaResponse = await GetPumpaResponse(userMessage);

                    // Display Pumpa's response in chat history
                    chatHistory.AppendText($"Pumpa: {pumpaResponse}\n");
                    chatHistory.ScrollToCaret(); // Auto-scroll to the bottom
                }
            }
        }

        private async Task<string> GetPumpaResponse(string userMessage)
        {
            try
            {
                // Prepare the request payload for DeepSeek Chat
                var requestPayload = new
                {
                    model = "deepseek-chat", // Replace with the correct model name
                    messages = new[]
                    {
                        new { role = "user", content = userMessage }
                    },
                    max_tokens = 150 // Adjust the response length
                };

                // Serialize the payload to JSON
                string jsonPayload = JsonConvert.SerializeObject(requestPayload);

                // Create the HTTP request
                var httpRequest = new HttpRequestMessage(HttpMethod.Post, DeepSeekApiUrl);
                httpRequest.Headers.Add("Authorization", $"Bearer {DeepSeekApiKey}");
                httpRequest.Content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send the request
                HttpResponseMessage response = await _httpClient.SendAsync(httpRequest);

                // Read the response content
                string responseContent = await response.Content.ReadAsStringAsync();

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Parse the response (adjust based on DeepSeek's API response structure)
                    var responseObject = JsonConvert.DeserializeObject<dynamic>(responseContent);
                    return responseObject.choices[0].message.content; // Adjust based on the API response
                }
                else
                {
                    // Log the error details for debugging
                    return $"Error: {response.StatusCode}\nResponse: {responseContent}";
                }
            }
            catch (Exception ex)
            {
                return $"Oops! Something went wrong: {ex.Message}";
            }
        }
    }
}