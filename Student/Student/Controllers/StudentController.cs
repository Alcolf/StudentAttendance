using Microsoft.AspNetCore.Mvc;
using Student.Model;
using Student.Service;

namespace Student.Controllers
{
    [ApiController]
    
    public class StudentController : ControllerBase
    {
        [Route("UserSignon")]
        [HttpPost]
        public UserEntity UserSignOn(UserSignonRequestEntity requestEntity)
        {
            try
            {
                StudentService service = new StudentService();

                return service.UserSignOn(requestEntity.Username, requestEntity.Password);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("ListStudent")]
        [HttpPost]
        public StudentList ListStudentByGradeAndClassroom(ListStudentRequestEntity requestEntity)
        {
            try
            {
                StudentService service = new StudentService();

                return service.ListStudentByGradeAndClassroom(requestEntity.Grade, requestEntity.Classroom);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("ListStudentByTeacherIdGradeClassroomDate")]
        [HttpPost]
        public StudentList ListStudentByTeacherIdAndGradeAndClassroomAndDate(ListStudentRequestEntity requestEntity)
        {
            try
            {
                StudentService service = new StudentService();

                return service.ListStudentByTeacherIdAndGradeAndClassroomAndDate(requestEntity.TeacherId, requestEntity.Grade, requestEntity.Classroom, requestEntity.Date);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("SubmitStudentRecord")]
        [HttpPost]
        public BaseResponse SubmitStudentRecord(SubmitRecordRequestEntity requestEntity)
        {
            try
            {
                StudentService service = new StudentService();

                return service.SubmitStudentRecord(requestEntity.TeacherId, requestEntity.CourseId, requestEntity.Date, requestEntity.ListStudent, requestEntity.IsUpdate);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("ListNotification")]
        [HttpPost]
        public ListNotiResponse ListNotification(ListNotificationRequestEntity requestEntity)
        {
            try
            {
                StudentService service = new StudentService();
                return service.ListNotification(requestEntity.TeacherId, requestEntity.Date);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [Route("WeeklyNotification")]
        [HttpPost]
        public void WeeklyNotification()
        {
            try
            {
                StudentService service = new StudentService();
                service.WeeklyNotification();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
