namespace Student.Model
{
    public class StudentEntity
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Grade { get; set; }
        public string Classroom { get; set; }
        public string ParentContact { get; set; }
        public bool IsAbsent { get; set; }
    }

    public class StudentList : BaseResponse
    {
        private List<StudentEntity> _list;
        public StudentList()
        {
            _list = new List<StudentEntity>();
        }
        public List<StudentEntity> ListStudent
        {
            get { return _list; }
            set { _list = value; }
        }
    }
}
