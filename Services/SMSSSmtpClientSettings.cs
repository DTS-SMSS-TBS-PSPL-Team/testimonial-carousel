

namespace TS.Services
{
    public class SMSSSmtpClientSettings
    {
        public const string SMSSCredentials = "Smtp";
        public string Host { get; set; }
        public bool EnableSsl { get; set; }
        public string FromEmail { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }
        public bool UseDefaultCredentials { get; set; }
        public int Port { get; set; }
        public string SenderName { get; set; }
        public string AppName { get; set; }
    }
}
