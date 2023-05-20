namespace Student.Model
{
    public class SubmitRecordRequestEntity
    {
        public string TeacherId { get; set; }
        public string CourseId { get; set; }
        public string Date { get; set; }
        public bool IsUpdate { get; set; }
        public StudentList ListStudent { get; set; }
    }
}
