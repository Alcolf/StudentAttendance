namespace Student.Model
{
    public class BaseResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool isSuccess
        {
            get
            {
                if (ErrorCode == "0000")
                    return true;
                else
                    return false;
            }
        }  
    }
}
