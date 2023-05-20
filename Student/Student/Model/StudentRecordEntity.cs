namespace Student.Model
{
    public class StudentRecordEntity
    {
        public string Grade { get; set; }
        public string StudentId { get; set; }
        public string Classroom { get; set; }
        public int CountAbsent { get; set; }
        public string CourseId { get; set;}
    }

    public class ListStudentRecord
    {
        private List<StudentRecordEntity> _studentRecords;
        public int LimitAbsent { get; set; }

        public ListStudentRecord()
        {
            _studentRecords = new List<StudentRecordEntity>();
        }

        public List<StudentRecordEntity> StudentRecordsList 
        { 
            get { return _studentRecords; } 
            set { _studentRecords = value; }
        }
    }
}
