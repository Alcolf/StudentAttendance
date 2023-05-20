using Azure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Student.Model;
using System.Net;
using System.Text;
using System.Text.Json.Serialization;

namespace Student.Service
{
    public class StudentService : IDisposable
    {
        public void Dispose()
        {

        }
        public StudentService()
        {

        }
        public UserEntity UserSignOn(string username, string password)
        {
            UserEntity user = null;

            try
            {
                using (DataContext data = new DataContext())
                {
                    user = data.UserSignOn(username, password);
                }

                if (user != null)
                {
                    user.ErrorCode = "0000";
                    user.ErrorMessage = "Success";
                }
                else
                {
                    user = new UserEntity();
                    user.ErrorCode = "0001";
                    user.ErrorMessage = "Username or Password is incorrect.";
                }
            }
            catch (Exception ex)
            {
                user = new UserEntity();
                user.ErrorCode = "9999";
                user.ErrorMessage = ex.Message;
            }

            return user;
        }

        public StudentList ListStudentByGradeAndClassroom(string grade, string classroom)
        {
            StudentList list = null;

            try
            {
                using (DataContext data = new DataContext())
                {
                    list = data.ListStudentByGradeAndClassroom(grade, classroom);
                }

                if (list != null && list.ListStudent != null && list.ListStudent.Count > 0)
                {
                    list.ErrorCode = "0000";
                    list.ErrorMessage = "Success";
                }
                else
                {
                    list = new StudentList();
                    list.ErrorCode = "0002";
                    list.ErrorMessage = "No Data Found.";
                }
            }
            catch (Exception ex)
            {
                list = new StudentList();
                list.ErrorCode = "9999";
                list.ErrorMessage = ex.Message;
            }

            return list;
        }

        public StudentList ListStudentByTeacherIdAndGradeAndClassroomAndDate(string teacherId, string grade, string classroom, string date)
        {
            StudentList list = null;

            try
            {
                using (DataContext data = new DataContext())
                {
                    list = data.ListStudentByTeacherIdAndGradeAndClassroomAndDate(teacherId, grade, classroom, date);
                }

                if (list != null && list.ListStudent != null && list.ListStudent.Count > 0)
                {
                    list.ErrorCode = "0000";
                    list.ErrorMessage = "Success";
                }
                else
                {
                    list = new StudentList();
                    list.ErrorCode = "0003";
                    list.ErrorMessage = "No Record Found.";
                }
            }
            catch (Exception ex)
            {
                list = new StudentList();
                list.ErrorCode = "9999";
                list.ErrorMessage = ex.Message;
            }

            return list;
        }

        public BaseResponse SubmitStudentRecord(string teacherId, string courseId, string dateRecord, StudentList studentList, bool isUpdate)
        {
            BaseResponse response = new BaseResponse();

            try
            {
                if (studentList != null && studentList.ListStudent != null && studentList.ListStudent.Count > 0) 
                {
                    using (DataContext data = new DataContext())
                    {
                        bool isExist = data.CheckStudentRecord(teacherId, courseId, dateRecord, studentList.ListStudent[0]);

                        if (isExist)
                        {
                            response.ErrorCode = "0005";
                            response.ErrorMessage = "This record already exist if you want to re-submit the record, please go to menu Edit.";
                            return response;
                        }

                        foreach (var student in studentList.ListStudent)
                        {
                            bool result = data.SubmitStudentRecord(teacherId, courseId, dateRecord, student, isUpdate);

                            if (!result)
                            {
                                response.ErrorCode = "0004";
                                response.ErrorMessage = "Submit Student Record Failure.";
                                return response;
                            }
                        }
                    }
                }

                response.ErrorCode = "0000";
                response.ErrorMessage = "Success";
                return response;
            }
            catch (Exception ex)
            {
                response.ErrorCode = "9999";
                response.ErrorMessage = ex.Message;
                return response;
            }
        }

        public ListNotiResponse ListNotification(string teacherId, string date)
        {
            ListStudentRecord listStudentRecord = null;
            ListNotiResponse listNotiResponse = new ListNotiResponse();
            try
            {
                using (DataContext data = new DataContext())
                {
                    bool isRead = data.CheckNotification(teacherId, date);

                    if (!isRead)
                    {
                        listStudentRecord = data.ListStudentRecordByTeacherId(teacherId);

                        if (listStudentRecord != null && listStudentRecord.StudentRecordsList != null && listStudentRecord.StudentRecordsList.Count > 0)
                        {
                            CourseList courseList = data.ListCourse();

                            listNotiResponse = new ListNotiResponse();

                            foreach (var item in listStudentRecord.StudentRecordsList)
                            {
                                if (item.CountAbsent >= listStudentRecord.LimitAbsent - 1)
                                {
                                    NotiResponse res = new NotiResponse();
                                    res.Classroom = item.Grade + "/" + item.Classroom;
                                    res.CouseId = item.CourseId;
                                    res.Count++;

                                    res.ListStudent = new StudentList();
                                    StudentEntity student = new StudentEntity();
                                    student = data.GetStudentInfo(item.StudentId);
                                    res.ListStudent.ListStudent.Add(student);

                                    listNotiResponse.NotiResponseList.Add(res);
                                }
                            }

                            ////send line noti
                            //if (listNotiResponse != null && listNotiResponse.NotiResponseList != null && listNotiResponse.NotiResponseList.Count > 0)
                            //{
                            //    foreach (var item in listNotiResponse.NotiResponseList)
                            //    {                                    
                            //        if (item.ListStudent != null && item.ListStudent.ListStudent != null && item.ListStudent.ListStudent.Count > 0)
                            //        {
                            //            foreach (var student in item.ListStudent.ListStudent)
                            //            {
                            //                if (!string.IsNullOrEmpty(student.Id))
                            //                {
                            //                    var course = courseList.ListCourse.Find(x => x.CourseId == item.CouseId);
                            //                    lineNotify("เรียนผู้ปกครองของ " + student.Title + " " +
                            //                        student.FirstName + " " + student.LastName + " " +
                            //                        "มีการขาดเรียนในรายวิชา " + course.CourseNameTh + " " +
                            //                        "ใกล้ถึงเกณฑ์ไม่มีสิทธิสอบ"
                            //                        , "U4fe2347e748b5b970c5d2e0174c83a0c");
                            //                }
                            //            }
                            //        }
                            //    }
                            //}


                            listNotiResponse.NotiResponseList = listNotiResponse.NotiResponseList.GroupBy(x => x.Classroom)
                                            .Where(g => g.Count() > 1)
                                .Select(g => new NotiResponse { Classroom = g.Key, Count = g.Count() })
                                .ToList();

                            data.UpdateNotification(teacherId, date);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                listNotiResponse.ErrorCode = "9999";
                listNotiResponse.ErrorMessage = ex.Message;
                return listNotiResponse;
            }

            listNotiResponse.ErrorCode = "0000";
            listNotiResponse.ErrorMessage = "Success";
            return listNotiResponse;
        }

        public void WeeklyNotification()
        {
            ListStudentRecord listStudentRecord = null;
            ListNotiResponse listNotiResponse = new ListNotiResponse();

            try
            {
                DayOfWeek wk = DateTime.Today.DayOfWeek;

                //if (wk == DayOfWeek.Saturday)
                if (true)
                {
                    using (DataContext data = new DataContext())
                    {
                        listStudentRecord = data.ListStudentRecord();

                        if (listStudentRecord != null && listStudentRecord.StudentRecordsList != null && listStudentRecord.StudentRecordsList.Count > 0)
                        {
                            CourseList courseList = data.ListCourse();

                            listNotiResponse = new ListNotiResponse();

                            foreach (var item in listStudentRecord.StudentRecordsList)
                            {
                                int limitAbsent = courseList.ListCourse.Find(x => x.CourseId == item.CourseId).LimitAbsent;

                                if (item.CountAbsent >= limitAbsent - 1)
                                {
                                    NotiResponse res = new NotiResponse();
                                    res.Classroom = item.Grade + "/" + item.Classroom;
                                    res.CouseId = item.CourseId;
                                    res.Count++;

                                    res.ListStudent = new StudentList();
                                    StudentEntity student = new StudentEntity();
                                    student = data.GetStudentInfo(item.StudentId);
                                    res.ListStudent.ListStudent.Add(student);

                                    listNotiResponse.NotiResponseList.Add(res);
                                }
                            }

                            //send line noti
                            if (listNotiResponse != null && listNotiResponse.NotiResponseList != null && listNotiResponse.NotiResponseList.Count > 0)
                            {
                                foreach (var item in listNotiResponse.NotiResponseList)
                                {
                                    if (item.ListStudent != null && item.ListStudent.ListStudent != null && item.ListStudent.ListStudent.Count > 0)
                                    {
                                        foreach (var student in item.ListStudent.ListStudent)
                                        {
                                            if (!string.IsNullOrEmpty(student.Id))
                                            {
                                                string courseNameTh = courseList.ListCourse.Find(x => x.CourseId == item.CouseId).CourseNameTh;
                                                string parentContact = student.ParentContact;
                                                lineNotify("เรียนผู้ปกครองของ " + student.Title + " " +
                                                    student.FirstName + " " + student.LastName + " " +
                                                    "มีการขาดเรียนในรายวิชา " + courseNameTh + " " +
                                                    "ใกล้ถึงเกณฑ์ไม่มีสิทธิสอบ"
                                                    , parentContact);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private async void lineNotify(string msg, string lineID)
        {
            string token = "yYXDUJt3SamKwHU8deJyIrqzZ9Fnxd0W67U5aO0EMWr";
            try
            {
                //Official line
                //var req = new LineNotificationRequestEntity();
                //req.to = "U4fe2347e748b5b970c5d2e0174c83a0c";
                //req.to = lineID;
                //Messages messages = new Messages { text = msg };
                //req.messages = new List<Messages>();
                // req.messages.Add(messages);

                //var json = JsonConvert.SerializeObject(req);
                //  var data = new StringContent(json,Encoding.UTF8,"application/json");
                //


                var req = new Dictionary<string, string>();
                req.Add("message", msg);

                var url = "https://notify-api.line.me/api/notify";
                using var client = new HttpClient();
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                var response = await client.PostAsync(url, new FormUrlEncodedContent(req));

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
