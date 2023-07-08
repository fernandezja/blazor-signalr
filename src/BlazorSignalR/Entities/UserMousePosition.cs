using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BlazorSignalR.Entities
{
    public class UserMousePosition
    {
        private const string DATETIME_FORMAT_HHMM = "HH:mm";
        private const string DATETIME_FORMAT_DDMMM_HHMM = "dd/MMM HH:mm";

        public string User { get; set; }
        public string UserHash { get; set; }
        public string Message { get; set; }
        public DateTime Timestamp { get; set; }
        public int MousePositionX { get; set; }
        public int MousePositionY { get; set; }
        public string ColorHex { get; set; }

        public UserMousePosition()
        {
                
        }

        public UserMousePosition(string user)
        {
            User = user;
            UserHash = ToSha256(user);
            Timestamp = DateTime.Now;
        }

        public UserMousePosition(string user, int mousePositionX, int mousePositionY)
        {
            User = user;
            UserHash = ToSha256(user);
            MousePositionX = mousePositionX;
            MousePositionY = mousePositionY;
            Timestamp = DateTime.Now;
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


        public bool HaveAColor
        {
            get {
                return !string.IsNullOrEmpty(ColorHex);
            }
        }


        public bool IsUser (string userInput)
        {
            return string.Equals(User, userInput, StringComparison.OrdinalIgnoreCase);
        }


        static string ToSha256(string stringToHash)
        {
            var crypt = new System.Security.Cryptography.SHA256Managed();
            var hash = new System.Text.StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }
            return hash.ToString();
        }
    }
}
