using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLayer
{
    public class BusinessLayer : IBusinessLayer
    {
        private readonly IStandardRepository _standardRepository;
        private readonly IStudentRepository _studentRepository;
        private readonly ITeacherRepository _teacherRepository;
        private readonly ICourseRepository _courseRepository;
       

        public BusinessLayer()
        {
            _standardRepository = new StandardRepository();
            _studentRepository = new StudentRepository();
            _teacherRepository = new TeacherRepository();
            _courseRepository = new CourseRepository();
            
        }

        #region Standard
        public IEnumerable<Standard> GetAllStandards()
        {
            return _standardRepository.GetAll();
        }

        public Standard GetStandardByID(int id)
        {
            return _standardRepository.GetById(id);
        }

        public Standard GetStandardByName(string name)
        {
            return _standardRepository.GetSingle(
                s => s.StandardName.Equals(name),
                s => s.Students);
        }

        public void AddStandard(Standard standard)
        {
            _standardRepository.Insert(standard);
        }

        public void UpdateStandard(Standard standard)
        {
            _standardRepository.Update(standard);
        }

        public void RemoveStandard(Standard standard)
        {
            _standardRepository.Delete(standard);
        }
        //word doc
        public Standard GetStandardByIDWithStudents(int id)
        {
            return _standardRepository.GetSingle(
                s => s.StandardId == id,
                s => s.Students);
        }

        //not implemented
        IList<Standard> IBusinessLayer.GetAllStandards()
        {
            IList<Standard> getall = new List<Standard>();
            foreach(Standard i in _standardRepository.GetAll())
            {
                getall.Add(i);
            }

            return getall; 
        }


        #endregion
        public IList<Student> GetAllStudents()
        {
            IList<Student> getall = new List<Student>();
            foreach (Student i in _studentRepository.GetAll())
            {
                getall.Add(i);
            }

            return getall;

        }

        public Student GetStudentByID(int id)
        {
            return _studentRepository.GetById(id);
        }

        public Student GetStudentByName(string name)
        {
            return _studentRepository.GetSingle(
                s => s.StudentName.Equals(name),
                s => s.Standard); //not sure if this line is right
        }

        public void AddStudent(Student student)
        {
            _studentRepository.Insert(student);
        }

        public void UpdateStudent(Student student)
        {
            _studentRepository.Update(student);
        }

        public void RemoveStudent(Student student)
        {
            _studentRepository.Delete(student);
        }




        #region Student


        #endregion

        #region Teacher
        public IList<Teacher> GetAllTeachers()
        {
            IList<Teacher> getall = new List<Teacher>();
            foreach(Teacher i in _teacherRepository.GetAll())
            {
                getall.Add(i);
            }

            return getall;
        }

        public Teacher GetTeacherByID(int id)
        {
            return _teacherRepository.GetById(id);
        }

        public Teacher GetTeacherByName(string name)
        {
            return _teacherRepository.GetSingle(
                s => s.TeacherName.Equals(name),
                s => s.Standard);
        }

        public ICollection<Course> GetCourseByTeacherID(int id)
        {
            return _teacherRepository.GetById(id).Courses;
        }

        public void AddTeacher(Teacher teacher)
        {
            _teacherRepository.Insert(teacher);
        }

        public void UpdateTeacher(Teacher teacher)
        {
            _teacherRepository.Update(teacher);
        }

        public void RemoveTeacher(Teacher teacher)
        {
            _teacherRepository.Delete(teacher);
        }
        #endregion

        #region Course
        public IList<Course> GetAllCourses()
        {
            IList<Course> getall = new List<Course>();
            foreach(Course i in _courseRepository.GetAll())
            {
                getall.Add(i);
            }
            return getall;
        }

        public Course GetCourseByID(int id)
        {
            return _courseRepository.GetById(id);
        }

        public Course GetCourseByName(string name)
        {
            return _courseRepository.GetSingle(
                s => s.CourseName.Equals(name),
                s => s.CourseId);
        }

        public void AddCourse(Course course)
        {
            _courseRepository.Insert(course);
        }

        public void UpdateCourse(Course course)
        {
            _courseRepository.Update(course);
        }

        public void RemoveCourse(Course course)
        {
            _courseRepository.Delete(course);
        }
        #endregion
    }
}