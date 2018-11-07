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

        public static void Main(string[] args)
        {
            string teacherName;
            int teacherID;
            int standardID;

            string courseName;
            int courseID;

            bool doTeachers = false;
            bool doCourses = false;

            //Used to allow the menu to continue running
            bool doGame = true;

            int choice;
            String num;


            //While loop to continue displaying the main menu
            while (doGame == true)
            {
                Console.WriteLine("Modify 1. Teachers or 2. Courses?");
                choice = Convert.ToInt32(Console.ReadLine());

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
                {
                    Console.WriteLine("Invalid Input");
                }

                while (doTeachers == true)
                {
                    menu1();
                    Console.WriteLine("");
                    //choice = Convert.ToInt32(Console.ReadLine());
                    num = Console.ReadLine();
                    choice = Int32.Parse(num);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("- CREATE - ");
                            Console.WriteLine("Enter Teacher Name: ");
                            teacherName = Console.ReadLine();

                            Console.WriteLine("Enter Standard ID: ");
                            standardID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Convert.ToInt32(Console.ReadLine());
                            createTeacher(teacherName, standardID, teacherID);
                            break;
                        case 2:
                            Console.WriteLine(" - UPDATE - ");
                            Console.WriteLine("Enter Teacher Name: ");
                            teacherName = Console.ReadLine();

                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Convert.ToInt32(Console.ReadLine());
                            updateTeacher(teacherName, teacherID);
                            break;
                        case 3:
                            Console.WriteLine("- DELETE - ");
                            Console.Write("Enter Teacher ID: ");
                            teacherID = Convert.ToInt32(Console.ReadLine());
                            deleteTeacher(teacherID);
                            break;
                        case 4:
                            Console.WriteLine("- GET COURSES BY TEACHER ID");
                            Console.Write("Enter Teacher ID: ");
                            teacherID = Convert.ToInt32(Console.ReadLine());
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
                //While loop to continue showing the menu for the courses
                while (doCourses == true)
                {
                    menu2();
                    Console.WriteLine("");
                    choice = Convert.ToInt32(Console.ReadLine());
                    //num = Console.ReadLine();
                    //choice = Int32.Parse(num);
                    switch (choice)
                    {
                        case 1:
                            Console.WriteLine("- CREATE COURSE -");
                            Console.WriteLine("Enter Course Name: ");
                            courseName = Console.ReadLine();

                            Console.WriteLine("Enter Course ID: ");
                            courseID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Convert.ToInt32(Console.ReadLine());
                            createCourse(courseName, courseID, teacherID);
                            break;
                        case 2:
                            Console.WriteLine("- UPDATE COURSE -");
                            Console.WriteLine("Enter Course Name: ");
                            courseName = Console.ReadLine();

                            Console.WriteLine("Enter Course ID: ");
                            courseID = Convert.ToInt32(Console.ReadLine());

                            Console.WriteLine("Enter Teacher ID: ");
                            teacherID = Convert.ToInt32(Console.ReadLine());
                            updateCourse(courseName, courseID, teacherID);
                            break;
                        case 3:
                            Console.WriteLine("- DELETE COURSE -");
                            Console.WriteLine("Enter Course ID");
                            courseID = Convert.ToInt32(Console.ReadLine());
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

        /*
         * Method to print the courses menu
         *
         */
        private static void menu2()
        {
            Console.Write("1. CREATE " +
                        "\n2. UPDATE " +
                        "\n3. DELETE " +
                        "\n4. ALL COURSES " +
                        "\n5. MAIN MENU");
        }

        /*
         * Method to create a teacher 
         * @param teacher name, standard ID, teacher ID
         */
        private static void createTeacher(string tName, int sID, int tID)
        {
            Console.Write("Create \n");
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }

            Teacher teacher = new Teacher
            {
                TeacherName = tName,
                StandardId = sID,
                TeacherId = tID
            };
            bl.AddTeacher(teacher); //this?

        }
        /*
         * Method to update the teacher 
         * @param teacher name, teacher ID
         */
        private static void updateTeacher(string tName, int tID)
        {
            Console.Write("Update \n");
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            Teacher teacher = bl.GetTeacherByID(tID);
            teacher.TeacherName = tName;
            //check function so it knows which one to update
            bl.UpdateTeacher(teacher);

        }

        /*
         * Method to delete the specified teacher
         * @param teacherID
         */
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

        /*
         * Method to return all courses taught by a teacher
         * @param teacher ID
         */
        private static void GetCourseByTeacherID(int tID)
        {
            Console.WriteLine("Get Course By Teacher ID");
            
            foreach (Course i in bl.GetCourseByTeacherID(tID))
            {
     
                Console.WriteLine(i.CourseName + " | cID: " + i.CourseId);
            }
        }
        /*
         * Method to return a list of all teachers
         */
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
                Console.WriteLine("- " + i.TeacherName + " | tID: " + i.TeacherId + " | sID: " + i.StandardId);

        }

        /*
         * Method to create a course
         * @param Course name, course ID, teacher ID
         * Teacher ID is used to specify what teacher is teaching the course
         */
        private static void createCourse(string cName, int cID, int tID)
        {
            Console.Write("Create Course \n");
            if (bl == null)
            {
                Console.WriteLine("Standard not found!");
                return;
            }
            Course course = new Course
            {
                CourseId = cID,
                CourseName = cName,
                TeacherId = tID
            };
            bl.AddCourse(course);
            Console.WriteLine("Done");
        }

        /*
         * Method to update a course
         * @param Course name, course ID, teacher ID
         */
        private static void updateCourse(string cName, int cID, int tID)
        {
            Console.Write("Update Course \n");
            Course course = bl.GetCourseByID(cID);
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

        /*
         * Method to delete a course
         * @param course ID
         */
        private static void deleteCourse(int cID)
        {
            Console.Write("Delete Course \n");
            Course course = bl.GetCourseByID(cID);
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
            bl.RemoveCourse(course);
            Console.WriteLine("Course successfully removed");
        }

        /*
         * Method to return all courses in the database
         */
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
                Console.Write(i.CourseName + " | cID: " + i.CourseId + " | tID: " + i.TeacherId + "\n");
            }
        }
    }
}
