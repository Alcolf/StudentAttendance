namespace Student.Model
{
    public class LineNotificationRequestEntity
    {
        public string to;
        public List<Messages> messages; 

    }

    public class Messages
    {

        public Messages()
        {
            
        }
        public String type = "text";
        public String text { get; set; }
    }

}
