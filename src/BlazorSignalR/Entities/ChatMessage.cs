using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorSignalR.Entities
{
    public class ChatMessage
    {
        private const string DATETIME_FORMAT_HHMM = "HH:mm";
        private const string DATETIME_FORMAT_DDMMM_HHMM = "dd/MMM HH:mm";

        public string User { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }

        public ChatMessage()
        {
            Timestamp = DateTime.Now;
        }

        public ChatMessage(string user, string message)
        {
            User = user;
            Message = message;
            Timestamp = DateTime.Now;
        }

        public ChatMessage(string user, string message, DateTime timestamp)
        {
            User = user;
            Message = message;
            Timestamp = timestamp;
        }
        public string TimestampFormated { 
            get {

                bool isToday = (Timestamp.Date == DateTime.Today);

                if (isToday)
                {
                    
                    return Timestamp.ToString(DATETIME_FORMAT_HHMM);
                }

                return Timestamp.ToString(DATETIME_FORMAT_DDMMM_HHMM);
            } 
        }

        public bool IsUser (string userInput)
        {
            return string.Equals(User, userInput, StringComparison.OrdinalIgnoreCase);

        }
    }
}
