using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace Client
{
    class Program
    {
        
        static BusinessLayer.BusinessLayer bl = new BusinessLayer.BusinessLayer();
        static int choice;
        public static void Main(string[] args)
        {
            //----------------------------------------- Slots ------
            //static?

            //SearchStandardStudents();
            string teacherName;
            int teacherID;
            int standardID;

            string courseName;
            int courseID;

            bool doTeachers = false;
            bool doCourses = false;
            bool doGame = true;

            

            while(doGame == true)
            {
                Console.WriteLine("Modify 1. Teachers or 2. Courses?");
                choice = Console.Read();

                if (choice == 1)
                {
                    doTeachers = true;
                    doCourses = false;
                }
                else if (choice == 2)
                {
                    doCourses = true;
                    doTeachers = false;
                }
                else
                    Console.WriteLine("?????");

                while (doTeachers == true)
                {
                    menu1();
                    choice = Console.Read();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("- CREATE - ");
                            Console.WriteLine("Enter Teacher Name: ");
                            teacherName = Console.ReadLine();
                            Console.WriteLine("Enter Standard ID: ");
                            standardID = Console.Read();
                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Console.Read();
                            createTeacher(teacherName, standardID, teacherID);
                            break;
                        case 2:
                            Console.WriteLine(" - UPDATE - ");
                            Console.WriteLine("Enter Teacher Name: ");
                            teacherName = Console.ReadLine();
                            Console.WriteLine("Enter Standard ID: ");
                            standardID = Console.Read();
                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Console.Read();
                            updateTeacher(teacherName, standardID, teacherID);
                            break;
                        case 3:
                            Console.WriteLine("- DELETE - ");
                            Console.Write("Enter Teacher ID: ");
                            teacherID = Console.Read();
                            deleteTeacher(teacherID);
                            break;
                        case 4:
                            Console.WriteLine("- GET COURSES BY TEACHER ID");
                            Console.Write("Enter Teacher ID: ");
                            teacherID = Console.Read();
                            GetCourseByTeacherID(teacherID);
                            break;
                        case 5:
                            Console.WriteLine("- GET ALL TEACHERS");
                            GetAllTeachers();
                            break;
                        case 6:
                            Console.WriteLine("- GET ALL STANDARDS -");
                            //method call
                            break;
                        case 7:
                            doTeachers = false;
                            doCourses = false;
                            break;
                    }

                }

                while (doCourses == true)
                {
                    menu2();
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("- CREATE COURSE -");
                            Console.WriteLine("Enter Course Name: ");
                            courseName = Console.ReadLine();
                            Console.WriteLine("Enter Course ID: ");
                            courseID = Console.Read();
                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Console.Read();
                            createCourse(courseName, courseID, teacherID);
                            break;
                        case 2:
                            Console.WriteLine("- UPDATE COURSE -");
                            Console.WriteLine("Enter Course Name: ");
                            courseName = Console.ReadLine();
                            Console.WriteLine("Enter Course ID: ");
                            courseID = Console.Read();
                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Console.Read();
                            updateCourse(courseName, courseID, teacherID);
                            break;
                        case 3:
                            Console.WriteLine("- DELETE COURSE -"); 
                            Console.WriteLine("Enter Course ID");
                            courseID = Console.Read();
                            deleteCourse(courseID);
                            break;
                        case 4:
                            Console.WriteLine("- DISPLAY ALL COURSES - ");
                            getAllCourses();
                            break;
                        case 5:
                            doTeachers = false;
                            doCourses = false;
                            break;
                    }
                }
            }
           


        }

        private static void menu1()
        {
            Console.Write("1. CREATE " +
                        "\n2. UPDATE " +
                        "\n3. DELETE " +
                        "\n4. LIST COURSES BY TEACHER ID " +
                        "\n5. ALL TEACHERS " +
                        "\n6. ALL STANDARDS " +
                        "\n7. MAIN MENU");
        }

        private static void menu2()
        {
            Console.Write("1. CREATE " +
                        "\n2. UPDATE " +
                        "\n3. DELETE " +
                        "\n4. ALL COURSES " +
                        "\n5. MAIN MENU");
        }
        
               
        
        // ------------------- SearchStandardStudents ------
        private static void SearchStandardStudents()
        {
            Console.Write("Enter Standard ID: ");
            ReadChoice();
            Standard s = bl.GetStandardByIDWithStudents(choice);
            if (s == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if (s.Students == null || s.Students.Count == 0)
            {
                Console.WriteLine("This Standard has no Students!");
                return;
            }

            Console.WriteLine("\nContaining Students: {0}", s.Students.Count);
            foreach (Student student in s.Students)
                Console.WriteLine("- " + student.StudentName);

        }

        private static void createTeacher(string tName, int sID, int tID)
        {
            Console.Write("Create \n");
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            Teacher teacher = new Teacher();
            teacher.TeacherName = tName;
            teacher.StandardId = sID;
            teacher.TeacherId = tID;
            bl.AddTeacher(teacher); //this?
                
        }

        private static void updateTeacher(string tName, int sID, int tID)
        {
            Console.Write("Update \n");
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            Teacher teacher = bl.GetTeacherByID(123);
            teacher.TeacherName = tName;
            teacher.StandardId = sID;
            teacher.TeacherId = tID;
            //check function so it knows which one to update
            bl.UpdateTeacher(teacher);

        }

        private static void deleteTeacher(int tID)
        {
            Console.Write("Delete \n");
            Teacher teacher = bl.GetTeacherByID(tID);
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if (teacher == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }
            bl.RemoveTeacher(teacher);
        }

        private static void GetCourseByTeacherID(int tID)
        {
            Console.Write("Get Course By Teacher ID");
            Console.Write(bl.GetCourseByTeacherID(tID));
        }

        private static void GetAllTeachers()
        {
            Console.Write("All Teachers \n ");
            
            IList<Teacher> list = bl.GetAllTeachers();
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if (bl.GetAllTeachers() == null || bl.GetAllTeachers().Count == 0)
            {
                Console.WriteLine("List has no teachers!");
                return;
            }

            Console.WriteLine("\nContaining Teachers: {0}", bl.GetAllTeachers().Count);
            foreach (Teacher i in bl.GetAllTeachers())
                Console.WriteLine("- " + i.TeacherName);

        }

        private static void createCourse(string cName, int cID, int tID)
        {
            Console.Write("Create Course \n");
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            Course course = new Course();
            course.CourseId = cID;
            course.CourseName = cName;
            course.TeacherId = tID;
            bl.AddCourse(course);
        }

        private static void updateCourse(string cName, int cID, int tID)
        {
            Console.Write("Update Course \n");
            Course course = bl.GetCourseByID(111);
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if (course == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }
            course.CourseName = cName;
            course.CourseId = cID;
            course.TeacherId = tID;
            bl.UpdateCourse(course);
            Console.WriteLine("Course successfully updated");
        }

        private static void deleteCourse(int cID)
        {
            Console.Write("Delete Course \n");
            Course course = bl.GetCourseByID(cID);
            if(bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if(course == null)
            {
                Console.WriteLine("Course does not exist!");
                return;
            }
            bl.RemoveCourse(course);
            Console.WriteLine("Course successfully removed");
        }

        private static void getAllCourses()
        {
            Console.Write("Get all courses \n");

            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            else if (bl.GetAllCourses() == null || bl.GetAllCourses().Count == 0)
            {
                Console.WriteLine("List has no Courses!");
                return;
            }

            Console.WriteLine("\nContaining Courses: {0}", bl.GetAllCourses().Count);
            foreach (Course i in bl.GetAllCourses())
            {
                Console.Write(i + "\n");
            }
        }

        private static void ReadChoice()
        {
            Console.WriteLine("Enter the ID");
            choice = Console.Read();
        }
    }
}
