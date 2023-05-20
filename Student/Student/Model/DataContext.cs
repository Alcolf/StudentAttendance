using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Student.Model
{
    public class DataContext : IDisposable
    {
        private string connectionString = "Server=(LocalDb)\\MSSQLLocalDB;DataBase=StudentAttendence;Trusted_Connection=True;";
        public void Dispose()
        {

        }

        public DataContext()
        {

        }

        public UserEntity UserSignOn(string username, string password)
        {
            UserEntity user = null;
            DataSet ds = new DataSet();
            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.USER_SIGN_ON]";
                    using (SqlCommand sqlCmd = new SqlCommand(spName, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@Username", username);
                        sqlCmd.Parameters.AddWithValue("@Password", password);
                        sqlConn.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            user = new UserEntity();
                            user.Id = dataRow["USER_ID"].ToString();
                            user.Title = dataRow["Title"].ToString();
                            user.FirstName = dataRow["FIRST_NAME"].ToString();
                            user.LastName = dataRow["LAST_NAME"].ToString();
                            user.Role = (Role)Convert.ToInt32(dataRow["ROLE"]);
                        }
                    }                    
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return user;
        }

        public StudentList ListStudentByGradeAndClassroom(string grade, string classroom)
        {
            StudentList list = new StudentList();
            StudentEntity student = null;
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.LIST_STUDENT_BY_GRADE_AND_CLASSROOM]";
                    using (SqlCommand sqlCmd = new SqlCommand(spName, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@Grade", grade);
                        sqlCmd.Parameters.AddWithValue("@Classroom", classroom);
                        sqlConn.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            student = new StudentEntity();
                            student.Id = dataRow["STUDENT_ID"].ToString();
                            student.Title = dataRow["Title"].ToString();
                            student.FirstName = dataRow["FIRST_NAME"].ToString();
                            student.LastName = dataRow["LAST_NAME"].ToString();
                            student.Grade = dataRow["GRADE"].ToString();
                            student.Classroom = dataRow["CLASSROOM"].ToString();
                            student.ParentContact = dataRow["PARENT_CONTACT"].ToString();

                            list.ListStudent.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }        

        public StudentList ListStudentByTeacherIdAndGradeAndClassroomAndDate(string teacherId, string grade, string classroom, string date)
        {
            StudentList list = new StudentList();
            StudentEntity student = null;
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.LIST_STUDENT_RECORD_BY_TEACHERID_GRADE_CLASSROOM_DATE]";
                    using (SqlCommand sqlCmd = new SqlCommand(spName, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@TeacherId", teacherId);
                        sqlCmd.Parameters.AddWithValue("@Grade", grade);
                        sqlCmd.Parameters.AddWithValue("@Classroom", classroom);
                        sqlCmd.Parameters.AddWithValue("@Date", date);
                        sqlConn.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            student = new StudentEntity();
                            student.Id = dataRow["TEACHER_ID"].ToString();
                            student.Title = dataRow["COURSE_ID"].ToString();
                            student.Id = dataRow["STUDENT_ID"].ToString();
                            student.Title = dataRow["STUDENT_TITLE"].ToString();
                            student.FirstName = dataRow["STUDENT_FIRSTNAME"].ToString();
                            student.LastName = dataRow["STUDENT_LASTNAME"].ToString();
                            student.Grade = dataRow["GRADE"].ToString();
                            student.Classroom = dataRow["CLASSROOM"].ToString();
                            student.IsAbsent = Convert.ToBoolean(dataRow["IS_ABSENT"]);

                            list.ListStudent.Add(student);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public bool CheckStudentRecord(string teacherId, string courseId, string dateRecord, StudentEntity student)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.CHECK_STUDENT_RECORD]";                    

                    using (SqlCommand sqlCom = new SqlCommand(spName, sqlConn))
                    {
                        sqlCom.CommandType = CommandType.StoredProcedure;

                        sqlCom.Parameters.AddWithValue("@TeacherId", teacherId);
                        sqlCom.Parameters.AddWithValue("@CourseId", courseId);
                        sqlCom.Parameters.AddWithValue("@DateRecord", dateRecord);
                        sqlCom.Parameters.AddWithValue("@Grade", student.Grade);
                        sqlCom.Parameters.AddWithValue("@Classroom", student.Classroom);
                        sqlConn.Open();

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCom))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    return (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool SubmitStudentRecord(string teacherId, string courseId, string dateRecord, StudentEntity student, bool isUpdate)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.ADD_STUDENT_RECORD]";

                    if (isUpdate) spName = "[SP.UPDATE_STUDENT_RECORD]";

                    using (SqlCommand sqlCom = new SqlCommand(spName, sqlConn))
                    {
                        sqlCom.CommandType = CommandType.StoredProcedure;

                        sqlCom.Parameters.AddWithValue("@TeacherId", teacherId);
                        sqlCom.Parameters.AddWithValue("@CourseId", courseId);
                        sqlCom.Parameters.AddWithValue("@DateRecord", dateRecord);
                        sqlCom.Parameters.AddWithValue("@StudentId", student.Id);
                        sqlCom.Parameters.AddWithValue("@StudentTitle", student.Title);
                        sqlCom.Parameters.AddWithValue("@StudentFirstname", student.FirstName);
                        sqlCom.Parameters.AddWithValue("@StudentLastname", student.LastName);
                        sqlCom.Parameters.AddWithValue("@Grade", student.Grade);
                        sqlCom.Parameters.AddWithValue("@Classroom", student.Classroom);
                        sqlCom.Parameters.AddWithValue("@IsAbsent", student.IsAbsent);
                        sqlConn.Open();

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCom))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    return (Convert.ToInt32(ds.Tables[0].Rows[0][0]) > 0);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public CourseList ListCourse()
        {
            CourseList list = new CourseList();
            CourseEntity course = null;
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.LIST_COURSES]";                    

                    using (SqlCommand sqlCom = new SqlCommand(spName, sqlConn))
                    {
                        sqlCom.CommandType = CommandType.StoredProcedure;
                        
                        sqlConn.Open();

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCom))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            course = new CourseEntity();
                            course.CourseId = dataRow["COURSE_ID"].ToString();
                            course.CourseNameTh = dataRow["COURSE_NAME_TH"].ToString();
                            course.CourseNameEn = dataRow["COURSE_NAME_EN"].ToString();
                            course.LimitAbsent = Convert.ToInt32(dataRow["LIMIT_ABSENT"]);

                            list.ListCourse.Add(course);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public ListStudentRecord ListStudentRecordByTeacherId(string teacherId)
        {
            ListStudentRecord list = new ListStudentRecord();
            StudentRecordEntity studentRecord = null;
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.LIST_STUDENT_RECORD_BY_TEACHERID]";
                    using (SqlCommand sqlCmd = new SqlCommand(spName, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@TeacherId", teacherId);
                        sqlConn.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            studentRecord = new StudentRecordEntity();
                            studentRecord.CountAbsent = Convert.ToInt32(dataRow["COUNT_ABSENT"]);
                            studentRecord.StudentId = dataRow["STUDENT_ID"].ToString();
                            studentRecord.Classroom = dataRow["CLASSROOM"].ToString();
                            studentRecord.Grade = dataRow["GRADE"].ToString();
                            studentRecord.CourseId = dataRow["COURSE_ID"].ToString();

                            list.StudentRecordsList.Add(studentRecord);
                        }

                        foreach (DataRow dataRow in ds.Tables[1].Rows)
                        {
                            list.LimitAbsent = Convert.ToInt32(dataRow["LIMIT_ABSENT"]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }

        public bool CheckNotification(string teacherId, string date)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.GET_NOTIFICATION]";
                    using (SqlCommand sqlCmd = new SqlCommand(spName, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;

                        sqlCmd.Parameters.AddWithValue("@TeacherId", teacherId);
                        sqlCmd.Parameters.AddWithValue("@Date", date);
                        sqlConn.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                        return true;
                    else
                        return false;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void UpdateNotification(string teacherId, string date)
        {
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.UPDATE_NOTIFICATION]";

                    using (SqlCommand sqlCom = new SqlCommand(spName, sqlConn))
                    {
                        sqlCom.CommandType = CommandType.StoredProcedure;

                        sqlCom.Parameters.AddWithValue("@TeacherId", teacherId);                        
                        sqlCom.Parameters.AddWithValue("@Date", date);
                        sqlConn.Open();

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCom))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public StudentEntity GetStudentInfo(string studentId)
        {
            StudentEntity studentEntity = null;
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.GET_STUDENT]";

                    using (SqlCommand sqlCom = new SqlCommand(spName, sqlConn))
                    {
                        sqlCom.CommandType = CommandType.StoredProcedure;

                        sqlCom.Parameters.AddWithValue("@StudentId", studentId);
                        sqlConn.Open();

                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCom))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            studentEntity = new StudentEntity();
                            studentEntity.Id = dataRow["STUDENT_ID"].ToString();
                            studentEntity.Title = dataRow["TITLE"].ToString();
                            studentEntity.FirstName = dataRow["FIRST_NAME"].ToString();
                            studentEntity.LastName = dataRow["LAST_NAME"].ToString();
                            studentEntity.Grade = dataRow["GRADE"].ToString();
                            studentEntity.Classroom = dataRow["CLASSROOM"].ToString();
                            studentEntity.ParentContact = dataRow["PARENT_CONTACT"].ToString();
                        }                        
                    }

                    return studentEntity;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public ListStudentRecord ListStudentRecord()
        {
            ListStudentRecord list = new ListStudentRecord();
            StudentRecordEntity studentRecord = null;
            DataSet ds = new DataSet();

            try
            {
                using (SqlConnection sqlConn = new SqlConnection(connectionString))
                {
                    string spName = "[SP.LIST_STUDENT_RECORD]";
                    using (SqlCommand sqlCmd = new SqlCommand(spName, sqlConn))
                    {
                        sqlCmd.CommandType = CommandType.StoredProcedure;
                        sqlConn.Open();
                        using (SqlDataAdapter sqlAdapter = new SqlDataAdapter(sqlCmd))
                        {
                            sqlAdapter.Fill(ds);
                        }
                    }

                    if (ds.Tables != null && ds.Tables.Count > 0 && ds.Tables[0].Rows != null)
                    {
                        foreach (DataRow dataRow in ds.Tables[0].Rows)
                        {
                            studentRecord = new StudentRecordEntity();
                            studentRecord.CountAbsent = Convert.ToInt32(dataRow["COUNT_ABSENT"]);
                            studentRecord.StudentId = dataRow["STUDENT_ID"].ToString();
                            studentRecord.Classroom = dataRow["CLASSROOM"].ToString();
                            studentRecord.Grade = dataRow["GRADE"].ToString();
                            studentRecord.CourseId = dataRow["COURSE_ID"].ToString();

                            list.StudentRecordsList.Add(studentRecord);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }
    }
}
