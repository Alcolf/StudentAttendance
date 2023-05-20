namespace Student.Model
{
    public class NotiResponse
    {
        public int Count { get; set; }
        public string Classroom { get; set; }
        public StudentList ListStudent { get; set; }
        public string CouseId { get; set; }
    }

    public class ListNotiResponse : BaseResponse
    {
        private List<NotiResponse> _notiResponseList;

        public ListNotiResponse()
        {
            _notiResponseList = new List<NotiResponse>();
        }

        public List<NotiResponse> NotiResponseList
        {
            get { return _notiResponseList; }
            set { _notiResponseList = value; }
        }
    }
}
