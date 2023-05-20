namespace Student.Model
{
    public class CourseEntity
    {
        public string CourseId { get; set; } 
        public string CourseNameTh { get; set; }
        public string CourseNameEn { get; set; }
        public int LimitAbsent { get; set; }
    }

    public class CourseList
    {
        private List<CourseEntity> _courses;

        public CourseList()
        {
            _courses = new List<CourseEntity>();
        }

        public List<CourseEntity> ListCourse
        {
            get { return _courses; }
            set { _courses = value; }
        }
    }
}
