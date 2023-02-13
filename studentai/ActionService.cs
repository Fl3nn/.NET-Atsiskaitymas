using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace studentai
{
    public class ActionService
    {
        public static void CreateDepartmentAndAddStudentsAndLectures()
        {
            using var db = new ApplicationContext();
            Console.WriteLine("Enter department name");
            var department = new Department(Console.ReadLine());
            Console.WriteLine("Kiek studentu nori add?");
            int studSk = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < studSk; i++)
            {
                Console.WriteLine("Enter student name");
                department.Students.Add(new Student(Console.ReadLine()));
            }

            Console.WriteLine("Kiek paskaitu nori add?");
            int paskSk = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= paskSk; i++)
            {
                Console.WriteLine("Enter lecture name");
                department.Lectures.Add(new Lecture(Console.ReadLine()));
            }
            db.Departments.Add(department);
            db.SaveChanges();
        }
        public static void AddLectureToDepartment()
        {
            using var db = new ApplicationContext();

            Console.WriteLine("Enter lecture name");
            string newLectureName = Console.ReadLine();
            var lecture = new Lecture(newLectureName);

            Console.Write("Iveskite department name is jau esamu arba sukursime nauja.\n jau esami department: ");
            foreach (Department department1 in db.Departments)
            {
                Console.Write($"{department1.Name} ");
            }

            Console.WriteLine("\nwhere to add");
            string departmentName = Console.ReadLine();

            Byte[] b1 = new Byte[16];
            Guid lecId = new Guid(b1);
            Guid depId = new Guid(b1);
            string depName;

            foreach (Department department in db.Departments)
            {
                if (departmentName == department.Name)
                {
                    depId = department.Id;
                    depName = department.Name;
                    Console.WriteLine($"tikrinu {department.Id} {department.Name}");
                }
            }
            if (depId == Guid.Empty)
            {
                Console.WriteLine("nera tokio department");
                var department = new Department(departmentName);
                department.Lectures.Add(lecture);
                db.Departments.Add(department);
                db.SaveChanges();
            }
            else
            {
                var department = new Department(departmentName);
                lecture.DepartmentId = depId;
                db.Lectures.Add(lecture);
                db.SaveChanges();
            }
        }
        public static void AddStudentToDepartment()
        {
            using var db = new ApplicationContext();
            Console.WriteLine("Enter student name");

            string newStudentName = Console.ReadLine();
            var student = new Student(newStudentName);

            Console.Write("kur prideti student: ");
            foreach (Department department1 in db.Departments)
            {
                Console.Write($"{department1.Name} ");
            }
            Console.WriteLine("");
            string departmentName = Console.ReadLine();

            Byte[] b1 = new Byte[16];
            Guid depId = new Guid(b1);
            string depName;

            foreach (Department department in db.Departments)
            {
                if (departmentName == department.Name)
                {
                    depId = department.Id;
                    depName = department.Name;
                    Console.WriteLine($"tikrinu {department.Id} {department.Name}");
                }
            }
            if (depId == Guid.Empty)
            {
                Console.WriteLine("nera tokio department");
            }
            else
            {
                student.DepartmentId = depId;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public static void TransferStudentToDepartment()
        {
            using var db = new ApplicationContext();
            Console.WriteLine("pasirink studenta");


            Byte[] b1 = new Byte[16];
            Guid depId = new Guid(b1);

            foreach (Student student2 in db.Students)
            {
                Console.Write($"{student2.Name} ");
            }
            Console.WriteLine("");
            string studentName = Console.ReadLine();

            Console.WriteLine("pasirink kur perkelti");
            foreach (Department department in db.Departments)
            {
                Console.Write($"{department.Name} ");
            }
            Console.WriteLine("");
            var departmentName = Console.ReadLine();

            foreach (Department department in db.Departments)
            {
                if (departmentName == department.Name)
                {
                    depId = department.Id;
                }
            }
            var student = new Student(studentName);

            if (depId == Guid.Empty)
            {
                Console.WriteLine("nera tokio department");
            }
            else
            {
                student.DepartmentId = depId;
                db.Students.Add(student);
                db.SaveChanges();
            }
        }
        public static void PrintStudentsInSelectedDepartment()
        {
            Console.Write("pasirinkite norima department: ");
            using var db = new ApplicationContext();

            foreach (Department department in db.Departments)
            {
                Console.Write($"{department.Name} ");
            }
            Console.WriteLine($"");
            string departmentName = Console.ReadLine();

            Console.WriteLine($"Studentai esantys {departmentName} department'e:");
            foreach (Student student in db.Students)
            {
                if (departmentName == student.Department.Name)
                {
                    Console.WriteLine(student.Name);
                }
            }
        }
        public static void PrintLecturesInSelectedDepartment()
        {
            Console.Write("pasirinkite norima department: ");
            using var db = new ApplicationContext();

            foreach (Department department in db.Departments)
            {
                Console.Write($"{department.Name} ");
            }
            Console.WriteLine($"");
            string departmentName = Console.ReadLine();
            Console.WriteLine($"{departmentName} department paskaitos:");
            foreach (Lecture lecture in db.Lectures)
            {
                if (departmentName == lecture.Department.Name)
                {
                    Console.WriteLine(lecture.Name);
                }
            }
        }

        public static void PrintLecturesByStudent()
        {
            Console.Write("enter student name: ");
            using var db = new ApplicationContext();

            Byte[] b1 = new Byte[16];
            Guid studDepId = new Guid(b1);

            foreach (Student student in db.Students)
            {
                Console.Write($"{student.Name} ");
            }
            Console.WriteLine($"");
            string studentName = Console.ReadLine();

            foreach (Student student in db.Students)
            {
                if (studentName == student.Name)
                {
                    studDepId = student.DepartmentId;
                }
            }
            Console.WriteLine($"{studentName} lectures:");
            foreach (Lecture lecture in db.Lectures)
            {
                if (lecture.DepartmentId == studDepId)
                {
                    Console.WriteLine($"{lecture.Name}");
                }
            }
        }
    }
}
